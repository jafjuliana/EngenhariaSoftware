using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia
{
    internal class Keys
    {
        internal static string conStr { get { return System.Configuration.ConfigurationManager.ConnectionStrings["Engenharia.Properties.Settings.sasConnectionString"].ConnectionString; } }
    }
}
