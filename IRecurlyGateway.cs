namespace RecurlyNET
{
    using RecurlyNET.Managers.Abstract;

    /// <summary>
    /// Recurly 2.0 API client interface.
    /// </summary>
    public interface IRecurlyGateway
    {
        #region Public Methods

        /// <summary>
        /// Gets Recurly entity manager.
        /// </summary>
        /// <typeparam name="T">Type of manager.</typeparam>
        /// <returns></returns>
        T GetManager<T>() where T : ManagerBase;

        #endregion Public Methods
    }
}
