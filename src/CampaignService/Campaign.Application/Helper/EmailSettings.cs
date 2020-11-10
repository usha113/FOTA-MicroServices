using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.Application.Helper
{
    /// <summary>
    /// Global Application Settings
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// SMTP host address - IP
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// SMTP Port
        /// </summary>
        public string Port { get; set; }
    }
}
