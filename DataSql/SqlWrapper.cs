using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Data.Odbc;

namespace WA_Send_API.DataSql
{
    public class SqlWrapper : IDisposable
    {
        private string _connectionString, _connectionStringTibero, _connectionStringDBBridge, _connectionStringDBS21, _connectionStringOUCH;
        private SqlConnection _connection;
        private OdbcConnection _connection2, _connection3, _connection4, _connection5;
        private SqlCommand _command;
        private OdbcCommand _command2, _command3, _command4, _command5;

        private string _connectionStringSqlSys1,
                       _connectionStringSqlSys2,
                       _connectionStringSqlSys3,
                       _connectionStringSqlSys4,
                       _connectionStringSqlSys5,
                       _connectionStringSqlSys6;

        private OdbcConnection _connectionSys1, _connectionSys2, _connectionSys3, _connectionSys4, _connectionSys5, _connectionSys6;
        private OdbcCommand _commandSys1, _commandSys2, _commandSys3, _commandSys4, _commandSys5, _commandSys6;

        private const string connectionString = "Data Source=10.1.2.100;Initial Catalog=S21Plus_CP;USER ID=s21+;Password=diehards21+;MultipleActiveResultSets=true;";
        //private const string connectionStringTibero = @"DSN=tibero_trusRT;UID=CP_REMOTE;PWD=CP_REMOTE;";
        private const string connectionStringDBBridge = @"DSN=tibero_trus;UID=S21_RT_PLUS_CP;PWD=S21_RT_PLUS_CP;";
        private const string connectionStringDBS21 = @"DSN=tibero_prod;UID=S21_RT_PLUS_CP;PWD=S21_RT_PLUS_CP;";
        private const string connectionStringOUCH = @"DSN=tibero_trusRTOUCH;UID=CP_REMOTE;PWD=cpremote123prod;";


        private const string connectionStringSqlSys1 = @"DSN=SYS_AODB;UID=sys;PWD=tibero;";
        private const string connectionStringSqlSys2 = @"DSN=SYS_DBBRIDGE;UID=sys;PWD=tibero;";
        private const string connectionStringSqlSys3 = @"DSN=SYS_OTDB;UID=sys;PWD=tibero;";
        private const string connectionStringSqlSys4 = @"DSN=SYS_RTDB;UID=sys;PWD=tibero;";
        private const string connectionStringSqlSys5 = @"DSN=SYS_S21_DBFO;UID=sys;PWD=tibero;";
        private const string connectionStringSqlSys6 = @"DSN=SYS_S21_LEDGER;UID=sys;PWD=tibero;";


        public SqlWrapper()
        {
            this._connectionString = connectionString;
            this._connection = new SqlConnection(connectionString);

          //  this._connectionStringTibero = connectionStringTibero;
          //  this._connection2 = new OdbcConnection(connectionStringTibero);

            this._connectionStringDBBridge = connectionStringDBBridge;
            this._connection3 = new OdbcConnection(connectionStringDBBridge);

            this._connectionStringDBS21 = connectionStringDBS21;
            this._connection4 = new OdbcConnection(connectionStringDBS21);

            this._connectionStringOUCH = connectionStringOUCH;
            this._connection5 = new OdbcConnection(this._connectionStringOUCH);

            /******************************************************************************************************/
            /**********************************************Sys_QUERY***********************************************/
            /******************************************************************************************************/
            this._connectionStringSqlSys1 = connectionStringSqlSys1;
            this._connectionSys1 = new OdbcConnection(connectionStringSqlSys1);
            
            this._connectionStringSqlSys2 = connectionStringSqlSys2;
            this._connectionSys2 = new OdbcConnection(connectionStringSqlSys2);

            this._connectionStringSqlSys3 = connectionStringSqlSys3;
            this._connectionSys3 = new OdbcConnection(connectionStringSqlSys3);

            this._connectionStringSqlSys4 = connectionStringSqlSys4;
            this._connectionSys4 = new OdbcConnection(connectionStringSqlSys4);

            this._connectionStringSqlSys5 = connectionStringSqlSys5;
            this._connectionSys5 = new OdbcConnection(connectionStringSqlSys5);

            this._connectionStringSqlSys6 = connectionStringSqlSys6;
            this._connectionSys6 = new OdbcConnection(connectionStringSqlSys6);
            /*****************************************************************************************************/


        }

        public void AddParameter(string name, DbType type, object value)
        {
            AddParameter(name, type, value, ParameterDirection.Input);
        }

        public void AddParameter(string name, DbType type, object value, ParameterDirection direction)
        {
            if (this._command == null)
                throw new NullReferenceException("SqlCommand is null.");

            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.DbType = type;
            param.Value = value;
            param.Direction = direction;
            
            this._command.Parameters.Add(param);
        }

        public void AddParameterTibero(string name, DbType type, object value, ParameterDirection direction)
        {
            if (this._command2 == null)
                throw new NullReferenceException("OdbcCommand is null.");

            OdbcParameter param = new OdbcParameter();
            param.ParameterName = name;
            param.DbType = type;
            param.Value = value;
            param.Direction = direction;

            this._command.Parameters.Add(param);
        }

        public void AddParameterOUCH(string name, DbType type, object value, ParameterDirection direction)
        {
            if (this._command5 == null)
                throw new NullReferenceException("OdbcCommand is null.");
            OdbcParameter param = new OdbcParameter();
            param.ParameterName = name;
            param.DbType = type;
            param.Value = value;
            param.Direction = direction;

            this._command.Parameters.Add(param);
        }

        public void PrepareSqlStatement(string sqlStatement)
        {
            if (string.IsNullOrEmpty(sqlStatement))
                throw new ArgumentNullException("sqlStatement is null.");
            if (this._connection == null)
                this._connection = new SqlConnection(this._connectionString);

            this._command = new SqlCommand(sqlStatement, this._connection);
            this._command.CommandType = CommandType.Text;
            this._command.CommandTimeout = 3;
        }

        //public void PrepareOdbcStatementTibero(string odbcStatement)
        //{
        //    if (string.IsNullOrEmpty(odbcStatement))
        //        throw new ArgumentNullException("OdbcStatement is null.");
        //    if (this._connection2 == null)
        //        this._connection2 = new OdbcConnection(this._connectionStringTibero);
        //
        //    this._command2 = new OdbcCommand(odbcStatement, this._connection2);
        //    this._command2.CommandType = CommandType.Text;
        //    this._command2.CommandTimeout = 3;
        //}

        public void PrepareOdbcStatementDBBridge(string odbcStatement)
        {
            if (string.IsNullOrEmpty(odbcStatement))
                throw new ArgumentNullException("OdbcStatement is null.");
            if (this._connection3 == null)
                this._connection3 = new OdbcConnection(this._connectionStringDBBridge);

            this._command3 = new OdbcCommand(odbcStatement, this._connection3);
            this._command3.CommandType = CommandType.Text;
            this._command3.CommandTimeout = 3;

        }

        public void PrepareOdbcStatementDBFO(string odbcStatement)
        {
            if (string.IsNullOrEmpty(odbcStatement))
                throw new ArgumentNullException("OdbcStatement is null.");
            if (this._connection4 == null)
                this._connection4 = new OdbcConnection(this._connectionStringDBS21);

            this._command4 = new OdbcCommand(odbcStatement, this._connection4);
            this._command4.CommandType = CommandType.Text;
            this._command4.CommandTimeout = 3;

        }

        //public void PrepareOdbcStatementDBOUCH(string odbcStatement)
        //{
        //    if (string.IsNullOrEmpty(odbcStatement))
        //        throw new ArgumentNullException("OdbcStatementOuch is null.");
        //    if (this._connection5 == null)
        //    {
        //        Console.WriteLine("_connection5 is null");
        //        this._connection5 = new OdbcConnection(this._connectionStringOUCH);
        //    }
        //
        //    this._command5 = new OdbcCommand(odbcStatement, this._connection5);
        //    this._command5.CommandType = CommandType.Text;
        //    this._command5.CommandTimeout = 3;
        //}

        public void PrepareOdbcStatementDBOUCH(string odbcStatement)
        {
            try
            {
                if (string.IsNullOrEmpty(odbcStatement))
                    throw new ArgumentNullException("OdbcStatementOuch is null.");

                if (this._connection5 == null)
                {
                    this._connection5 = new OdbcConnection(this._connectionStringOUCH);
                }

                this._command5 = new OdbcCommand(odbcStatement, this._connection5);

                this._command5.CommandType = CommandType.Text;

                this._command5.CommandTimeout = 3;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error preparing ODBC statement: " + ex.Message);
                throw; // Re-throw the exception after logging
            }
        }

        public void PrepareOdbcStatementDBSysAODB(string odbcStatement)
        {
            try
            {
                if (string.IsNullOrEmpty(odbcStatement))
                    throw new ArgumentNullException("OdbcStatementSysAODB is null.");

                if (this._connectionSys1 == null)
                    this._connectionSys1 = new OdbcConnection(this._connectionStringSqlSys1);

                this._commandSys1 = new OdbcCommand(odbcStatement, this._connectionSys1);
                this._commandSys1.CommandType = CommandType.Text;
                this._commandSys1.CommandTimeout = 3;
            }
            catch (Exception ex)
            { 
                Console.WriteLine ("Error Preparing ODBC Statement : " + ex.Message);
                throw;
            }
        }

        public void PrepareOdbcStatementDBSysBridge(string odbcStatement)
        {
            try
            {
                if (string.IsNullOrEmpty(odbcStatement))
                    throw new ArgumentNullException("OdbcStatementSysBridge is null.");

                if (this._connectionSys2 == null)
                    this._connectionSys2 = new OdbcConnection(this._connectionStringSqlSys2);

                this._commandSys2 = new OdbcCommand(odbcStatement, this._connectionSys2);
                this._commandSys2.CommandType = CommandType.Text;
                this._commandSys2.CommandTimeout = 3;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Preparing ODBC Statement : " + ex.Message);
                throw;
            }
        }

        public void PrepareOdbcStatementDBSysOTDB(string odbcStatement)
        {
            try
            {
                if (string.IsNullOrEmpty(odbcStatement))
                    throw new ArgumentNullException("OdbcStatementSysOTDB is null");

                if (this._connectionSys3 == null)
                    this._connectionSys3 = new OdbcConnection(this._connectionStringSqlSys3);

                this._commandSys3 = new OdbcCommand (odbcStatement, this._connectionSys3);
                this._commandSys3.CommandType = CommandType.Text;
                this._commandSys3.CommandTimeout = 3;
            }
            catch (Exception ex)
            { 
                Console.WriteLine ("Error Preparing ODBC Statement : " + ex.Message);
                throw;
            }
        }

        public void PrepareOdbcStatementDBSysRTDB(string odbcStatement)
        {
            try
            {
                if (string.IsNullOrEmpty(odbcStatement))
                    throw new ArgumentNullException("ODBCStatementSysRTDB is null");

                if (this._connectionSys4 == null)
                    this._connectionSys4 = new OdbcConnection(this._connectionStringSqlSys4);

                this._commandSys4 = new OdbcCommand (odbcStatement, this._connectionSys4);
                this._commandSys4.CommandType = CommandType.Text;
                this._commandSys4.CommandTimeout = 3;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Preparing ODBC Statement : " + ex.Message);
                throw;
            }
        }

        public void PrepareOdbcStatementDBSysDBFO(string odbcStatement)
        {
            try
            {
                if (string.IsNullOrEmpty(odbcStatement))
                    throw new ArgumentNullException("ODBCStatementSysDBFO is null");
                if(this._connectionSys5 == null)
                   this._connectionSys5 = new OdbcConnection (this._connectionStringSqlSys5);

                this._commandSys5 = new OdbcCommand(odbcStatement, this._connectionSys5);
                this._commandSys5.CommandType = CommandType.Text;
                this._commandSys5.CommandTimeout = 3;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error Preparing ODBC Statement : " + ex.Message);
                throw;
            }
        }

        public void PrepareOdbcStatementDBSysLedger(string odbcStatement)
        {
            try
            {
                if (string.IsNullOrEmpty(odbcStatement))
                    throw new ArgumentNullException("ODBCStatementSysDBLedger is null");
                
                if(this._connectionSys6 == null)
                   this._connectionSys6 = new OdbcConnection(this._connectionStringSqlSys6);

                this._commandSys6 = new OdbcCommand(odbcStatement,this._connectionSys6);
                this._commandSys6.CommandType = CommandType.Text;
                this._commandSys6.CommandTimeout = 3;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error preparing ODBC Statement : " + ex.Message);
                throw;
            }
        }



        public void PrepareStoredProcedure(string procedureName, int commandTimeout)
        {
            if (string.IsNullOrEmpty(procedureName))
                throw new ArgumentNullException("procedureName is null.");
            if (this._connection == null)
                this._connection = new SqlConnection(this._connectionString);

            this._command = new SqlCommand(procedureName, this._connection);
            this._command.CommandType = CommandType.StoredProcedure;
            this._command.CommandTimeout = commandTimeout;
        }

        protected bool GetBooleanValue(string value)
        {
            if (value.Trim().Equals("0") || value.ToLowerInvariant().Trim().Equals("false"))
                return false;
            return true;
        }

        public SqlDataReader ExecuteReader()
        {
            if (this._connection.State == ConnectionState.Open)
                this._connection.Close();

            this._connection.Open();
            return this._command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public OdbcDataReader ExecuteReaderODBC()
        {
            if (this._connection2.State == ConnectionState.Open)
                this._connection2.Close();

            this._connection2.Open();
            return this._command2.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public OdbcDataReader ExecuteReaderODBCBridge()
        {
            if (this._connection3.State == ConnectionState.Open)
                this._connection3.Close();

            this._connection3.Open();
            return this._command3.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public OdbcDataReader ExecuteReaderODBCDBFO()
        {
            if (this._connection4.State == ConnectionState.Open)
                this._connection4.Close();

            this._connection4.Open();
            return this._command4.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public OdbcDataReader ExecuteReaderODBCOUCH()
        { 
            if(this._connection5.State == ConnectionState.Open)
                this._connection5.Close();

            this._connection5.Open();
            return this._command5.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //public OdbcDataReader ExecuteReaderODBCOUCH()
        //{
        //    try
        //    {
        //        if (this._connection5 == null)
        //        {
        //            throw new InvalidOperationException("Connection object (_connection5) is not initialized.");
        //        }
        //
        //        if (this._command5 == null)
        //        {
        //            throw new InvalidOperationException("Command object (_command5) is not initialized.");
        //        }
        //
        //        // Log the connection state before opening
        //        
        //        if (this._connection5.State == ConnectionState.Open)
        //        {
        //            this._connection5.Close();
        //        }
        //
        //        this._connection5.Open();
        //
        //        // Return the reader
        //        return this._command5.ExecuteReader(CommandBehavior.CloseConnection);
        //    }
        //    catch (OdbcException ex)
        //    {
        //        throw;
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public OdbcDataReader ExecuteReaderODBCSysAODB()
        {
            if(this._connectionSys1.State == ConnectionState.Open)
                this._connectionSys1.Close();

            this._connectionSys1.Open();
            return this._commandSys1.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public OdbcDataReader ExecuteReaderODBCSysBridge()
        { 
            if(this._connectionSys2.State == ConnectionState.Open)
               this._connectionSys2.Close();

            this._connectionSys2.Open();
            return this._commandSys2.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public OdbcDataReader ExecuteReaderODBCSysOTDB()
        { 
            if(this._connectionSys3.State == ConnectionState.Open)
                this._connectionSys3.Close();
            
            this._connectionSys3.Open();
            return this._commandSys3.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public OdbcDataReader ExecuteReaderODBCSysRTDB()
        {
            if (this._connectionSys4.State == ConnectionState.Open)
                this._connectionSys4.Close();
            this._connectionSys4.Open();
            return this._commandSys4.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public OdbcDataReader ExecuteReaderODBCSysLedger()
        { 
            if(this._connectionSys6.State == ConnectionState.Open)
                this._connectionSys6.Close();
            this._connectionSys6.Open();
            return this._commandSys6.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public OdbcDataReader ExecuteReaderODBCSysDBFO()
        { 
            if(this._connectionSys5.State == ConnectionState.Open)
                this._connectionSys5.Close();
            this._connectionSys5.Open();
            return this._commandSys5.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public int ExecuteNonQuery()
        {
            if (this._connection.State == ConnectionState.Open)
                this._connection.Close();

            this._connection.Open();
            return this._command.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            if (this._connection.State == ConnectionState.Open)
                this._connection.Close();

            this._connection.Open();
            return this._command.ExecuteScalar();
        }

        public object ExecuteScalarODBC()
        {
            if (this._connection2.State == ConnectionState.Open)
                this._connection2.Close();

            this._connection2.Open();
            return this._command2.ExecuteScalar();
        }

        public SqlDataAdapter ExecuteAdapter()
        {
            if (this._connection.State == ConnectionState.Open)
                this._connection.Close();

            this._connection.Open();
            return new SqlDataAdapter(this._command);
        }

        public void ClearPool()
        {
            SqlConnection.ClearPool(this._connection);
        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                if (this._connection != null)
                    this._connection.Close();
            }
            catch { }
            finally
            {
                this._command = null;
                this._connection = null;
            }
        }

        #endregion

    }
}