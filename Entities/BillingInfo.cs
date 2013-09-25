namespace RecurlyNET.Entities
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Recurly billing info.
    /// </summary>
    [XmlRoot("billing_info"), Serializable]
    public class BillingInfo
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets billing info href.
        /// </summary>
        [XmlAttribute("href")]
        public string Href { get; set; }

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
        /// Gets or sets address1.
        /// </summary>
        [XmlElement("address1")]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets ro sets address2.
        /// </summary>
        [XmlElement("address2")]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets city.
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets state.
        /// </summary>
        [XmlElement("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets country.
        /// </summary>
        [XmlElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets zip code.
        /// </summary>
        [XmlElement("zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets phone.
        /// </summary>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets VAT.
        /// </summary>
        [XmlElement("vat_number")]
        public string VAT { get; set; }

        /// <summary>
        /// Gets or sets IP adderess.
        /// </summary>
        [XmlElement("ip_address")]
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets number.
        /// </summary>
        [XmlElement("number")]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets card type.
        /// </summary>
        [XmlElement("card_type")]
        public string CardType { get; set; }

        /// <summary>
        /// Gets or sets first six digits.
        /// </summary>
        [XmlElement("first_six")]
        public string FirstSixDigits { get; set; }

        /// <summary>
        /// Gets or sets last four digits.
        /// </summary>
        [XmlElement("last_four")]
        public string LastFourDigits { get; set; }

        /// <summary>
        /// Gets or sets expiration month.
        /// </summary>
        [XmlElement("month")]
        public int? ExpirationMonth { get; set; }

        /// <summary>
        /// Gets or sets expiration year.
        /// </summary>
        [XmlElement("year")]
        public int? ExpirationYear { get; set; }

        /// <summary>
        /// Gets or sets CVV.
        /// </summary>
        [XmlElement("verification_value")]
        public string CVV { get; set; }

        /// <summary>
        /// Gets or sets IP address country.
        /// </summary>
        [XmlElement("ip_address_country")]
        public string IPAddressCountry { get; set; }

        /// <summary>
        /// Gets or sets billing agreement ID.
        /// </summary>
        [XmlElement("billing_agreement_id")]
        public string BillingAgreementId { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets ShouldSerializeExpirationMonth flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeExpirationMonth()
        {
            return ExpirationMonth != null;
        }

        /// <summary>
        /// Gets ShouldSerializeExpirationYear flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeExpirationYear()
        {
            return ExpirationYear != null;
        }

        #endregion Public Methods
    }
}
