namespace RecurlyNET.Managers.Abstract
{
    using System;
    using System.Text;
    using RecurlyNET.Infrastructure;
    using RestSharp;

    /// <summary>
    /// Recurly manager base.
    /// </summary>
    public abstract class ManagerBase
    {
        #region Private Fields

        private RestClient _client;
        private RestSerializer _serializer;

        #endregion Private Fields

        #region Protected Properties

        /// <summary>
        /// Gets REST client.
        /// </summary>
        protected RestClient RestClient
        {
            get { return _client; }
        }

        #endregion Protected Properties

        #region Private Methods

        /// <summary>
        /// Checks HTTP status is OK.
        /// </summary>
        /// <param name="statusCode">Status code.</param>
        /// <returns>True - if status is OK.</returns>
        private bool HttpIsOK(int statusCode)
        {
            return (statusCode >= 200 && statusCode <= 299);
        }

        /// <summary>
        /// Processes error.
        /// </summary>
        /// <param name="response">REST response.</param>
        private void ProcessErrors(IRestResponse response)
        {
            int statusCode = (int)response.StatusCode;

            if (!HttpIsOK(statusCode))
            {
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.Unauthorized:
                        {
                            throw new RecurlyUnAuthorizedException(response.Content);
                        }
                    case System.Net.HttpStatusCode.PaymentRequired:
                        {
                            throw new RecurlyPaymentRequiredException(response.Content);
                        }
                    case System.Net.HttpStatusCode.NotFound:
                        {
                            throw new RecurlyNotFoundException();
                        }
                    default:
                        {
                            throw new RecurlyExceptionBase(response.Content);
                        }
                }
            }
        }

        /// <summary>
        /// Prepares REST request.
        /// </summary>
        /// <param name="segments">Resource segments.</param>
        /// <param name="method">HTTP method type.</param>
        /// <param name="body">REST body.</param>
        /// <returns>REST request instance.</returns>
        private RestRequest PrepareRequest(string[] segments, Method method, object body = null)
        {
            // Compose resource string

            var resource = new StringBuilder();

            foreach (string segment in segments)
            {
                resource.AppendFormat("/{0}", segment);
            }

            // Create && execute request

            var request = new RestRequest(resource.ToString(), method)
            {
                XmlSerializer = _serializer,
                OnBeforeDeserialization = ProcessErrors,
            };

            if (body != null)
            {
                request.AddBody(body);
            }

            return request;
        }

        #endregion Private Methods

        #region Protected Methods

        /// <summary>
        /// Executes REST request.
        /// </summary>
        /// <param name="request">REST request instance.</param>
        protected void ExecuteRequest(IRestRequest request)
        {
            _client.Execute(request);
        }

        /// <summary>
        /// Executes REST request.
        /// </summary>
        /// <typeparam name="T">Type of response result.</typeparam>
        /// <param name="request">REST request instance.</param>
        /// <returns>Request result.</returns>
        protected IRestResponse<T> ExecuteRequest<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> result = new RestResponse<T>();

            try
            {
                result = _client.Execute<T>(request);
            }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(RecurlyNotFoundException)) { throw; }
            }

            return result;
        }

        /// <summary>
        /// Executes REST request.
        /// </summary>
        /// <param name="segments">Resource segments.</param>
        /// <param name="method">HTTP method type.</param>
        /// <param name="body">REST body.</param>
        protected void ExecuteRequest(string[] segments, Method method, object body = null)
        {
            ExecuteRequest(PrepareRequest(segments, method, body));
        }

        /// <summary>
        /// Executes REST request.
        /// </summary>
        /// <typeparam name="T">Type of response result.</typeparam>
        /// <param name="segments">Resource segments.</param>
        /// <param name="method">HTTP method type.</param>
        /// <param name="body">REST body.</param>
        /// <returns>Request result.</returns>
        protected IRestResponse<T> ExecuteRequest<T>(string[] segments, Method method, object body = null) where T : new()
        {
            return ExecuteRequest<T>(PrepareRequest(segments, method, body));
        }

        #endregion Protected Methods

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected ManagerBase(RestClient client)
        {
            _client = client;

            _serializer = new RestSerializer();

            _client.AddHandler("application/xml", _serializer);
            _client.AddHandler("text/xml", _serializer);
        }

        #endregion Constructors
    }
}
