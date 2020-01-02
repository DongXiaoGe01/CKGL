using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;  

namespace CKGLDB
{
    class DBCON
    {
        SqlConnection sqlConnection1 = new SqlConnection("server=DESKTOP-PV2RSHT; database=CKGL;Trusted_Connection=SSPI.");

    }
}
