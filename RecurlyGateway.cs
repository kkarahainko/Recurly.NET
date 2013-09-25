namespace RecurlyNET
{
    using System;
    using RecurlyNET.Helpers;
    using RecurlyNET.Managers.Abstract;
    using RestSharp;

    /// <summary>
    /// Recurly 2.0 API client implementation.
    /// </summary>
    public class RecurlyGateway : IRecurlyGateway
    {
        #region Private Fields

        /// <summary>
        /// REST client instance.
        /// </summary>
        private RestClient _restClient;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Gets Recurly entity manager.
        /// </summary>
        /// <typeparam name="T">Type of manager.</typeparam>
        /// <returns></returns>
        public T GetManager<T>() where T : ManagerBase
        {
            return (T)Activator.CreateInstance(typeof(T), _restClient);
        }

        #endregion Public Methods

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RecurlyGateway()
        {
            _restClient = new RestClient(ConfigurationHelper.RecurlyApiEndpoint)
            {
                Authenticator = new HttpBasicAuthenticator(ConfigurationHelper.RecurlyApiKey, String.Empty)
            };
        }

        #endregion Constructors
    }
}
