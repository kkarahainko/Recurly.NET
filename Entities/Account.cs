namespace RecurlyNET.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using RecurlyNET.Infrastructure;

    /// <summary>
    /// Recurly account.
    /// </summary>
    [XmlRoot("account"), Serializable]
    public class Account
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets account href.
        /// </summary>
        [XmlAttribute("href")]
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets state.
        /// </summary>
        [XmlElement("state")]
        public AccountState? State { get; set; }

        /// <summary>
        /// Gets or sets code.
        /// </summary>
        [XmlElement("account_code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets email.
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [XmlElement("username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        [XmlElement("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        [XmlElement("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets created at date.
        /// </summary>
        [XmlElement("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets company name.
        /// </summary>
        [XmlElement("company_name")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets accept language.
        /// </summary>
        [XmlElement("accept_language")]
        public string AcceptLanguage { get; set; }

        /// <summary>
        /// Gets or sets billing info.
        /// </summary>
        [XmlElement("billing_info")]
        public BillingInfo BillingInfo { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets ShouldSerializeState flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeState()
        {
            return State != null;
        }

        /// <summary>
        /// Gets ShouldSerializeCreatedAt flag.
        /// </summary>
        public bool ShouldSerializeCreatedAt()
        {
            return CreatedAt != null;
        }

        #endregion Public Methods
    }

    /// <summary>
    /// Collection of Recurly accounts.
    /// </summary>
    [XmlRoot("accounts")]
    public class AccountCollection
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets list of accounts.
        /// </summary>
        [XmlElement("account")]
        public List<Account> Data { get; set; }

        #endregion Public Properties
    }
}
