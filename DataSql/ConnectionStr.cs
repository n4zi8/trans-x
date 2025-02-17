using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA_Send_API.DataSql
{
    public class ConnectionStr
    {
        private const string connectionString = "Data Source=10.1.2.100;Initial Catalog=S21Plus_CP;USER ID=s21+;Password=diehards21+;MultipleActiveResultSets=true;";
        //private const string connectionString2 = @"DSN=tibero_trusRT;UID=CP_REMOTE;PWD=CP_REMOTE;";
        private const string connectionString3 = @"DSN=tibero_trusRTOUCH;UID=CP_REMOTE;PWD=cpremote123prod;";

        private const string connectionStringSys1 = @"DSN=SYS_AODB;UID=sys;PWD=tibero;";
        private const string connectionStringSys2 = @"DSN=SYS_DBBRIDGE;UID=sys;PWD=tibero;";
        private const string connectionStringSys3 = @"DSN=SYS_OTDB;UID=sys;PWD=tibero;";
        private const string connectionStringSys4 = @"DSN=SYS_RTDB;UID=sys;PWD=tibero;";
        private const string connectionStringSys5 = @"DSN=SYS_S21_DBFO;UID=sys;PWD=tibero;";
        private const string connectionStringSys6 = @"DSN=SYS_S21_LEDGER;UID=sys;PWD=tibero;";


        public static bool ProbeConnectionString()
        {
            bool result = false;
            SqlConnectionStringBuilder csBuilder = new SqlConnectionStringBuilder(connectionString) { ConnectTimeout = 3 };
            //OdbcConnectionStringBuilder odbcBuilder = new OdbcConnectionStringBuilder(connectionString2) ;
            OdbcConnectionStringBuilder odbcBuilder2 = new OdbcConnectionStringBuilder(connectionString3);

            
            OdbcConnectionStringBuilder odbcBuilderSys1 = new OdbcConnectionStringBuilder(connectionStringSys1);
            OdbcConnectionStringBuilder odbcBuilderSys2 = new OdbcConnectionStringBuilder(connectionStringSys2);
            OdbcConnectionStringBuilder odbcBuilderSys3 = new OdbcConnectionStringBuilder(connectionStringSys3);
            OdbcConnectionStringBuilder odbcBuilderSys4 = new OdbcConnectionStringBuilder(connectionStringSys4);
            OdbcConnectionStringBuilder odbcBuilderSys5 = new OdbcConnectionStringBuilder(connectionStringSys5);
            OdbcConnectionStringBuilder odbcBuilderSys6 = new OdbcConnectionStringBuilder(connectionStringSys6);



            SqlConnection connection = new SqlConnection(csBuilder.ToString());
            //OdbcConnection connection2 = new OdbcConnection(odbcBuilder.ToString());
            OdbcConnection connection3 = new OdbcConnection(odbcBuilder2.ToString());
            OdbcConnection connection5 = new OdbcConnection(odbcBuilder2.ToString());

            OdbcConnection connectionSys1 = new OdbcConnection(odbcBuilderSys1.ToString());
            OdbcConnection connectionSys2 = new OdbcConnection(odbcBuilderSys2.ToString());
            OdbcConnection connectionSys3 = new OdbcConnection(odbcBuilderSys3.ToString());
            OdbcConnection connectionSys4 = new OdbcConnection(odbcBuilderSys4.ToString());
            OdbcConnection connectionSys5 = new OdbcConnection(odbcBuilderSys5.ToString());
            OdbcConnection connectionSys6 = new OdbcConnection(odbcBuilderSys6.ToString());



            try
            {
                connection.Open();
                //connection2.Open();
                connection3.Open();
                connection5.Open();

                connectionSys1.Open();
                connectionSys2.Open();
                connectionSys3.Open();
                connectionSys4.Open();
                connectionSys5.Open();
                connectionSys6.Open();

                result = true;
            }
            catch { result = false; }
            finally 
            { 
                connection.Dispose();
                //connection2.Dispose();
                connection3.Dispose();
                connection5.Dispose();

                connectionSys1.Dispose();
                connectionSys2.Dispose();
                connectionSys3.Dispose();
                connectionSys4.Dispose();
                connectionSys5.Dispose();
                connectionSys6.Dispose();
            }

            return result;
        }
    }
}
