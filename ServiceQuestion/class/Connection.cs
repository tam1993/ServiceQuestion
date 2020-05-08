using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoomLibrary;

namespace ServiceQuestion
{
	public class Connection
	{
        public static CSQLConnection CSQLConnection {
            get { return new CSQLConnection ( Properties.Settings.Default.Server, Properties.Settings.Default.Port, Properties.Settings.Default.Username, Properties.Settings.Default.Password, Properties.Settings.Default.DBSource ); }
        }
	}
}