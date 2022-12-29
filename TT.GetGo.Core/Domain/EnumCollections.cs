namespace TT.GetGo.Core.Domain
{
    public enum CarStatus
    {
        None = 1, 

        Onhold = 9999,

        Booked = 2,
    }

    /// <summary>
    /// Represents a log level
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Debug information
        /// </summary>
        Debug = 10,

        /// <summary>
        /// Log Information
        /// </summary>
        Information = 20,

        /// <summary>
        /// Warning
        /// </summary>
        Warning = 30,

        /// <summary>
        /// Error / Critical Issues
        /// </summary>
        Error = 40,

        /// <summary>
        /// Fatal Error
        /// </summary>
        Fatal = 50
    }

    public enum BookingReturnStatus
    {
        None = 0,

        Complete = 1,
        /// <summary>
        /// Car not found 
        /// </summary>
        InvalidCar = -1, 

        /// <summary>
        /// The status is not in pending / none 
        /// </summary>
        InvalidCarStatus = -2, 

        /// <summary>
        /// User and car home lot is out of min distance
        /// </summary>
        InvalidDistance = -3,

        /// <summary>
        /// System Error
        /// </summary>
        FatalError = -4,
    }


    public enum ReachReturnStatus
    {
        None = 0,

        Complete = 1,
        /// <summary>
        /// Car not found 
        /// </summary>
        InvalidCar = -1, 

        /// <summary>
        /// The status is not in pending / none 
        /// </summary>
        InvalidCarStatus = -2, 

        /// <summary>
        /// Invalid booking records
        /// </summary>
        InvalidBookingRecord = -3, 

        /// <summary>
        /// System Error
        /// </summary>
        FatalError = -4,
    }
}
