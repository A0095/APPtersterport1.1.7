using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste.Logger
{
    /// <summary>
    /// Defines the severity of a log event
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Logging is turned off
        /// </summary>
        Off = -1,

        /// <summary>
        /// A fatal error, should never happen. Especially in productive systems. Really. Never!
        /// </summary>
        Fatal = 0,

        /// <summary>
        /// An error that should not happen, but the system can recover. But it result in inconsistent or invalid data.
        /// </summary>
        Error = 1,

        /// <summary>
        /// Something "not nice" has happend, but no data is corrupted and system will function without manual interaction required.
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Something really important has happend
        /// </summary>
        Notice = 3,

        /// <summary>
        /// This information might be handy and is understandable by trained personel
        /// </summary>
        Info = 4,

        /// <summary>
        /// Important debug information, should not be required in production systems and might be very technical
        /// </summary>
        Debug = 5,

        /// <summary>
        /// More verbose debug information
        /// </summary>
        Debug2 = 6,

        /// <summary>
        /// Even more verbose debug information, can flood you logs!
        /// </summary>
        Debug3 = 7,

        /// <summary>
        /// The maximal log level 
        /// </summary>
        MAX = Debug3
    }
}
