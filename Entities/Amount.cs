namespace RecurlyNET.Entities
{
    using System;
    using System.Xml.Serialization;
    using RecurlyNET.Infrastructure;

    /// <summary>
    /// Abstract class for variuos amounts.
    /// </summary>
    public abstract class Amount
    {
        #region Public Properties

        /// <summary>
        /// Gets the currency type.
        /// </summary>
        public abstract RecurlyCurrency Currency { get; }

        /// <summary>
        /// Gets or sets the amount value in cents.
        /// </summary>
        [XmlText]
        public int Cents { get; set; }

        #endregion Public Properties
    }

    /// <summary>
    /// Amount in EUR cents.
    /// </summary>
    [Serializable]
    public class EURAmount : Amount
    {
        #region Public Properties

        /// <summary>
        /// Gets the currency type.
        /// </summary>
        public override RecurlyCurrency Currency
        {
            get { return RecurlyCurrency.EUR; }
        }

        #endregion Public Properties
    }

    /// <summary>
    /// Amount in USD cents.
    /// </summary>
    [Serializable]
    public class USDAmount : Amount
    {
        #region Public Properties

        /// <summary>
        /// Gets the currency type.
        /// </summary>
        public override RecurlyCurrency Currency
        {
            get { return RecurlyCurrency.USD; }
        }

        #endregion Public Properties
    }

    /// <summary>
    /// Amount in AUD cents.
    /// </summary>
    [Serializable]
    public class AUDAmount : Amount
    {
        #region Public Properties

        /// <summary>
        /// Gets the currency type.
        /// </summary>
        public override RecurlyCurrency Currency
        {
            get { return RecurlyCurrency.AUD; }
        }

        #endregion Public Properties
    }
}