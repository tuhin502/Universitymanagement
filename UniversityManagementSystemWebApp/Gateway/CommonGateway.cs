using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CommonGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public CommonGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemConString"].ConnectionString;
            Connection=new SqlConnection(connectionString);
        }
    }
}