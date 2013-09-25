namespace RecurlyNET.Managers.Concrete
{
    using System;
    using RecurlyNET.Entities;
    using RecurlyNET.Infrastructure;
    using RecurlyNET.Managers.Abstract;
    using RestSharp;

    /// <summary>
    /// Recurly subscription manager.
    /// </summary>
    public class SubscriptionManager : ManagerBase
    {
        #region Defines

        /// <summary>
        /// Enpoint postfix, ex: https://{api-endpoint}/{postfix}
        /// </summary>
        private const string ENDPOINT_POSTFIX = "subscriptions";

        #endregion Defines

        #region Public Methods

        /// <summary>
        /// Gets all subscriptions.
        /// </summary>
        /// <returns>Collection of SubscriptionResponse insances.</returns>
        public SubscriptionCollection GetAll()
        {
            return ExecuteRequest<SubscriptionCollection>(new[] { ENDPOINT_POSTFIX }, Method.GET).Data;
        }

        /// <summary>
        /// Gets subscription.
        /// </summary>
        /// <param name="uuid">Subscription ID.</param>
        /// <returns>SubscriptionResponse insance.</returns>
        public Subscription Get(string uuid)
        {
            return ExecuteRequest<Subscription>(new[] { ENDPOINT_POSTFIX, uuid }, Method.GET).Data;
        }


        /// <summary>
        /// Creates subscription.
        /// </summary>
        /// <param name="body">SubscriptionRequest instance.</param>
        /// <returns>SubscriptionResponse instance.</returns>
        public Subscription Create(Subscription body)
        {
            return ExecuteRequest<Subscription>(new[] { ENDPOINT_POSTFIX }, Method.POST, body).Data;
        }

        /// <summary>
        /// Updates account.
        /// </summary>
        /// <param name="uuid">Subscription ID.</param>
        /// <param name="body">SubscriptionUpdateRequest instance.</param>
        /// <returns>SubscriptionResponse instance.</returns>
        public Subscription UpdateSubscription(string uuid, Subscription body)
        {
            return ExecuteRequest<Subscription>(new[] { ENDPOINT_POSTFIX, uuid }, Method.PUT, body).Data;
        }

        /// <summary>
        /// Cancels subscription.
        /// </summary>
        /// <param name="uuid">Subscription ID.</param>
        public void CancelSubscription(string uuid)
        {
            ExecuteRequest(new[] { ENDPOINT_POSTFIX, uuid, "cancel" }, Method.PUT);
        }

        /// <summary>
        /// Cancels subscription.
        /// </summary>
        /// <param name="uuid">Subscription ID.</param>
        public void ReactivateSubscription(string uuid)
        {
            ExecuteRequest(new[] { ENDPOINT_POSTFIX, uuid, "reactivate" }, Method.PUT);
        }

        /// <summary>
        /// Cancels subscription.
        /// </summary>
        /// <param name="uuid">Subscription ID.</param>
        /// <param name="refund">Refund type</param>
        public void TerminateSubscription(string uuid, RefundType refund = RefundType.None)
        {
            ExecuteRequest(new[] { ENDPOINT_POSTFIX, uuid, String.Format("terminate?refund={0}", refund.ToString()) }, Method.PUT);
        }

        #endregion Public Methods

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="client">REST client.</param>
        public SubscriptionManager(RestClient client) : base(client) { }

        #endregion Constructors
    }
}
