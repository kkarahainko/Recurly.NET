namespace RecurlyNET.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using RecurlyNET.Infrastructure;

    /// <summary>
    /// Recurly subscription.
    /// </summary>
    [XmlRoot("subscription"), Serializable]
    public class Subscription
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets UUID.
        /// </summary>
        [XmlElement("uuid")]
        public string UUID { get; set; }

        /// <summary>
        /// Gets or sets plan.
        /// </summary>
        [XmlElement("plan")]
        public Plan Plan { get; set; }

        /// <summary>
        /// Gets or sets state.
        /// </summary>
        [XmlElement("state")]
        public SubscriptionState? State { get; set; }

        /// <summary>
        /// Gets or sets amount in cents.
        /// </summary>
        [XmlElement("unit_amount_in_cents")]
        public int? UnitAmountInCents { get; set; }

        /// <summary>
        /// Gets or sets currency.
        /// </summary>
        [XmlElement("currency")]
        public RecurlyCurrency? Currency { get; set; }

        /// <summary>
        /// Gets or sets plan code.
        /// </summary>
        [XmlElement("plan_code")]
        public string PlanCode { get; set; }

        /// <summary>
        /// Gets or sets account.
        /// </summary>
        [XmlElement("account")]
        public Account Account { get; set; }

        /// <summary>
        /// Gets or sets timeframe.
        /// </summary>
        [XmlElement("timeframe")]
        public UpdateTimeframe? Timeframe { get; set; }

        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        [XmlElement("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets coupon code.
        /// </summary>
        [XmlElement("coupon_code")]
        public string CouponCode { get; set; }

        /// <summary>
        /// Gets or sets activated at.
        /// </summary>
        [XmlElement("activated_at")]
        public DateTime? ActivatedAt { get; set; }

        /// <summary>
        /// Gets or sets activated at.
        /// </summary>
        [XmlElement("canceled_at")]
        public NullableDateTime CanceledAt { get; set; }

        /// <summary>
        /// Gets or sets activated at.
        /// </summary>
        [XmlElement("expires_at")]
        public NullableDateTime ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets activated at.
        /// </summary>
        [XmlElement("current_period_started_at")]
        public NullableDateTime CurrentPeriodStartedAt { get; set; }

        /// <summary>
        /// Gets or sets activated at.
        /// </summary>
        [XmlElement("current_period_ends_at")]
        public NullableDateTime CurrentPeriodEndsAt { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets ShouldSerializeUnitAmountInCents flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeUnitAmountInCents()
        {
            return UnitAmountInCents != null;
        }

        /// <summary>
        /// Gets ShouldSerializeState flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeState()
        {
            return State != null;
        }

        /// <summary>
        /// Gets ShouldSerializeCurrency flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeCurrency()
        {
            return Currency != null;
        }

        /// <summary>
        /// Gets ShouldSerializeAccount flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeAccount()
        {
            return Account != null;
        }

        /// <summary>
        /// Gets ShouldSerializeTimeframe flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeTimeframe()
        {
            return Timeframe != null;
        }

        /// <summary>
        /// Gets ShouldSerializeQuantity flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeQuantity()
        {
            return Quantity != null;
        }

        /// <summary>
        /// Gets ShouldSerializeActivatedAt flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeActivatedAt()
        {
            return ActivatedAt.HasValue;
        }

        /// <summary>
        /// Gets ShouldSerializeCanceledAt flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeCanceledAt()
        {
            return CanceledAt.HasValue;
        }

        /// <summary>
        /// Gets ShouldSerializeExpiresAt flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeExpiresAt()
        {
            return ExpiresAt.HasValue;
        }

        /// <summary>
        /// Gets ShouldSerializeCurrentPeriodStartedAt flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeCurrentPeriodStartedAt()
        {
            return CurrentPeriodStartedAt.HasValue;
        }

        /// <summary>
        /// Gets ShouldSerializeCurrentPeriodEndsAt flag.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeCurrentPeriodEndsAt()
        {
            return CurrentPeriodEndsAt.HasValue;
        }

        #endregion Public Methods
    }

    /// <summary>
    /// Collection of Recurly subscriptions.
    /// </summary>
    [XmlRoot("subscriptions")]
    public class SubscriptionCollection
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets list of subscriptions.
        /// </summary>
        [XmlElement("subscription")]
        public List<Subscription> Data { get; set; }

        #endregion Public Properties
    }
}
