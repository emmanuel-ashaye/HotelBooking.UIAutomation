using System;

namespace UIFramework.Drivers
{
    /// <summary>
    /// The test driver interface.
    /// </summary>
    public interface ITestDriver : IDisposable
    {
        /// <summary>
        /// Opens the driver specific application.
        /// </summary>
        void OpenApplication(string applicationUrl);
    }
}
