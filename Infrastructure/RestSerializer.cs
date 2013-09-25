namespace RecurlyNET.Infrastructure
{
    using System;
    using System.IO;
    using System.Text;
    using RestSharp;
    using RestSharp.Deserializers;
    using RestSharp.Serializers;

    /// <summary>
    /// XML serializer.
    /// </summary>
    public class RestSerializer : IDeserializer, ISerializer
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets content type.
        /// </summary>
        public string ContentType
        {
            get { return "*"; }
            set { /* empty */ }
        }

        /// <summary>
        /// Gets or sets date fromat.
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Gets or sets namespace.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets root element.
        /// </summary>
        public string RootElement { get; set; }

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        /// Gets XML serializer instance.
        /// </summary>
        /// <param name="type">Type of object.</param>
        /// <returns>XML serializer instance</returns>
        private System.Xml.Serialization.XmlSerializer GetSerializer(Type type)
        {
            return new System.Xml.Serialization.XmlSerializer(type);
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Deserializes REST response.
        /// </summary>
        /// <typeparam name="T">Type of response result.</typeparam>
        /// <param name="response">REST response instance.</param>
        /// <returns>Response result instance.</returns>
        public T Deserialize<T>(IRestResponse response)
        {
            return (T)GetSerializer(typeof(T)).Deserialize(new StringReader(response.Content));
        }

        /// <summary>
        /// Serializes object to string.
        /// </summary>
        /// <param name="obj">Source object.</param>
        /// <returns>XML string.</returns>
        public string Serialize(object obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                GetSerializer(obj.GetType()).Serialize(writer, obj);

                writer.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                return (new StreamReader(stream, Encoding.UTF8)).ReadToEnd();
            }
        }

        #endregion Public Methods
    }
}
