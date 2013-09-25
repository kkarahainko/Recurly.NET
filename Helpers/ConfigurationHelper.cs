namespace RecurlyNET.Helpers
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Configuration helper.
    /// </summary>
    internal static class ConfigurationHelper
    {
        #region Public Properties

        /// <summary>
        /// Gets the recurly api key.
        /// </summary>
        public static string RecurlyApiKey
        {
            get { return GetValue("RecurlyApiKey"); }
        }

        /// <summary>
        /// Gets the recurly api endpoint.
        /// </summary>
        public static string RecurlyApiEndpoint
        {
            get { return GetValue("RecurlyApiEndpoint"); }
        }

        /// <summary>
        /// Gets the recurly push notification user name.
        /// </summary>
        public static string RecurlyPushUsername
        {
            get { return GetValue("RecurlyPushUsername"); }
        }

        /// <summary>
        /// Gets the recurly push notification user password.
        /// </summary>
        public static string RecurlyPushPassword
        {
            get { return GetValue("RecurlyPushPassword"); }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// Value of config by specified name.
        /// </returns>
        public static string GetValue(string name)
        {
            return ConfigurationManager.AppSettings.Get(name);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns>
        /// Casted value of config by specified name.
        /// </returns>
        public static T GetValue<T>(string name)
        {
            string strValue = GetValue(name);

            T result;

            if (typeof(T) == typeof(bool))
            {
                result = (T)((Object)Boolean.Parse(strValue));
            }
            else
            {
                result = (T)((Object)strValue);
            }

            return result;
        }

        /// <summary>
        /// Gets the value or default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns>
        /// Value of config by specified name or default.
        /// </returns>
        public static T GetValueOrDefault<T>(string name)
        {
            T result = default(T);

            try
            {
                result = GetValue<T>(name);
            }
            catch (Exception)
            {
                // Hint: Planned.
            }

            return result;
        }

        #endregion Public Methods
    }
}
