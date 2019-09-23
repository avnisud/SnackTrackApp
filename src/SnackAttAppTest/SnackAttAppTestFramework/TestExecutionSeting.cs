using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackAttAppTestFramework
{
    /// <summary>
    /// The class to handle execution setting passed by json file.
    /// </summary>
    public class TestExecutionSeting
    {
        public string DeviceName { get; set;  }
        public string UdId { get; set; }
        public string AndroidSdkPath { get; set; }
        public string AppPath { get; set; }
    }
}
