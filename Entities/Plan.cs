namespace RecurlyNET.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Recurly plan.
    /// </summary>
    [XmlRoot("plan"), Serializable]
    public class Plan
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets code.
        /// </summary>
        [XmlElement("plan_code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unit amounts in cents and various currency.
        /// </summary>
        [XmlArray("unit_amount_in_cents")]
        [XmlArrayItem("EUR", typeof(EURAmount))]
        [XmlArrayItem("USD", typeof(USDAmount))]
        [XmlArrayItem("AUD", typeof(AUDAmount))]
        public Amount[] UnitAmount { get; set; }

        /// <summary>
        /// Gets or sets setup fee in cents and various currency.
        /// </summary>
        [XmlArray("setup_fee_in_cents")]
        [XmlArrayItem("EUR", typeof(EURAmount))]
        [XmlArrayItem("USD", typeof(USDAmount))]
        [XmlArrayItem("AUD", typeof(AUDAmount))]
        public Amount[] SetupFee { get; set; }

        #endregion Public Properties
    }

    /// <summary>
    /// Collection of Recurly plans.
    /// </summary>
    [XmlRoot("plans")]
    public class PlanCollection
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets list of plans.
        /// </summary>
        [XmlElement("plan")]
        public List<Plan> Data { get; set; }

        #endregion Public Properties
    }
}
