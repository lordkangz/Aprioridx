using System;
using System.Data;
using System.Data.OleDb;


/// <summary>
/// The VISUAL_BASIC_DATA_MINING_NET namespace contains namespaces and classes used by this assembly.
/// </summary>
namespace VISUAL_BASIC_DATA_MINING_NET
{


    /// <summary>
    /// Implements data access to relational databases and XML data stores.
    /// </summary>
    public class DataAccessLayer
    {

        public enum CommandAction
        {
            deleteCommand = 1,
            insertCommand = 2,
            updateCommand = 3
        }


        /// <summary>
        /// A string variable that contains the connection string for relational database access.
        /// </summary>
        protected string connectionString;

        /// <summary>
        /// A string variable that contains the path to an XML file.
        /// </summary>
        protected string filePath;

        /// <summary>
        /// A System.Data.OleDb.OleDbDataAdapter variable used to execute fill the DataSet with transactions data.
        /// </summary>
        protected OleDbDataAdapter myAdapter;

        /// <summary>
        /// A System.Data.OleDb.OleDbCommand variable used to execute a stored procedure or SQL SELECT statement.
        /// </summary>
        protected OleDbCommand myCommand;

        /// <summary>
        /// A System.Data.OleDb.OleDbConnection variable representing an open connection to the database.
        /// </summary>
        protected OleDbConnection myConnection;

        /// <summary>
        /// A System.Data.DataTable variable that stores transactions data being analyzed.
        /// </summary>
        protected DataTable myTransactionTable;

        /// <summary>
        /// A strongly typed System.Data.DataSet object containing an in-memory cache of transaction data.
        /// </summary>
        protected Data myDatabase;


        /// <summary>
        /// A parameterless default constructor that instantiates a new DataAccessLayer object.
        /// </summary>
        public DataAccessLayer()
        {
        }


        /// <summary>
        /// The connection string for accessing a relational database.
        /// </summary>
        /// <value>
        /// A string value that represents the path to a relational database containing transactions to be analyzed.
        /// </value>
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }


        /// <summary>
        /// The path to an XML file that conatins transactions to be analyzed.
        /// </summary>
        /// <value>
        /// A string value that represents the path a the XML file containing transactions to be analyzed.
        /// </value>
        public string FilePath
        {
            get
            {
                return filePath;
            }

            set
            {
                filePath = value;
            }
        }


        /// <summary>
        /// Retrieves transaction data from an XML file.
        /// </summary>
        /// <param name="xmlFilePath">
        /// The path to of the XML file containing transaction data.
        /// </param>
        /// <returns>
        /// A type safe Data object containing transaction data retrieved from the XML file.
        /// </returns>
        public Data GetXMLData(string xmlFilePath)
        {
            myDatabase = new Data();

            string errorMessage;


            try
            {
                myDatabase.ReadXml(xmlFilePath);
            }

            catch (Exception Ex)
            {
                errorMessage = Ex.ToString();
            }

            return myDatabase;
        }


        /// <summary>
        /// Retrieves transaction data from TransactionsTable.
        /// </summary>
        /// <param name="rdbmsConnectionString">
        /// The connection string used to establish connection to a relational database using ADO.NET.
        /// <example>
        /// An example of a connection string using Windows Integrated Security :
        /// <para>
        /// string connect = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=Sales;" + "Integrated Security=SSPI;";
        /// </para>
        /// An example of a string not using Windows Integrated Security : 
        /// <para>
        /// "Provider=SQLOLEDB;Data Source=localhost;User ID=Analyst;Password=DataMining;Initial Catalog=Shopping Cart";
        /// </para>
        /// </example> 
        /// </param>
        /// <returns>
        /// Returns a strongly typed DataSet object containing the transaction data to be analyzed.
        /// </returns>
        /// <value>
        /// A System.Data.DataTable object containing the TransactionID and Transactions columns and data.
        /// </value>
        /// <remarks>
        /// Assumes that a table TransactionsTable with columns TransactionID and Transactions exist in the database.
        /// </remarks>
        public Data GetTransactionsData(string rdbmsConnectionString)
        {
            string selectSQL = "SELECT TransactionID, Transactions FROM TransactionsTable";
            //string selectSQL = "SELECT TransactionID, Transactions FROM tbl_dxtransformed";
            string errorMessage;


            myDatabase = new Data();

            myConnection = new OleDbConnection(rdbmsConnectionString);


            try
            {
                myAdapter = new OleDbDataAdapter(selectSQL, myConnection);

                myAdapter.Fill(myDatabase, "TransactionTable");
            }

            catch (Exception Ex)
            {
                errorMessage = Ex.ToString();
            }

            return myDatabase;
        }


        /// <summary>
        /// Retrieves transaction data from a transactions table.
        ///  See <see cref="VISUAL_BASIC_DATA_MINING_NET.DataAccessLayer.GetTransactionsData"/>
        /// </summary>
        /// <param name="rdbmsConnectionString">
        /// The connection string used to establish connection to a relational database using ADO.NET.
        ///  See <see cref="VISUAL_BASIC_DATA_MINING_NET.DataAccessLayer.GetTransactionsData"/>
        /// </param> 
        /// <param name="dataSource">
        /// A string containing a SQL statement, a table name or the name of a stored procedure.
        /// <para>
        /// The table must have a TransactionID field and a Transactions field.
        /// </para>
        /// <para>
        /// To use a stored procedure named usp_GetTransactions, create the stored procedure in SQL Server using :
        /// <code>
        /// <example>
        /// CREATE  PROCEDURE usp_GetTransactions AS
        /// 
        ///	SELECT TransactionID, Transactions FROM TransactionsTable
        ///	</example>
        /// </code>
        /// </para>
        /// <para>
        ///  The SQL statement used to select transactions data.
        /// <example>
        ///  "SELECT TransactionID, Transactions FROM TransactionsTable"
        /// </example>
        /// </para>
        /// </param>
        /// <param name="commandType">
        /// A CommandType enumeration of CommandType.StoredProcedure or CommandType.Text or CommandType.TableDirect.
        /// </param>
        /// <returns>
        /// See
        ///  <see cref="VISUAL_BASIC_DATA_MINING_NET.DataAccessLayer.GetTransactionsData"/>
        /// </returns>
        public Data GetTransactionsData(string rdbmsConnectionString, string dataSource, CommandType commandType)
        {

            myDatabase = new Data();

            myConnection = new OleDbConnection(rdbmsConnectionString);

            myCommand = new OleDbCommand(dataSource, myConnection);


            /*if (commandType == CommandType.StoredProcedure)
            {
                myCommand.CommandType = CommandType.StoredProcedure;
            }

            else if (commandType == CommandType.Text)
            {
                myCommand.CommandType = CommandType.Text;
            }

            else if (commandType == CommandType.TableDirect)
            {
                myCommand.CommandType = CommandType.TableDirect;
            }*/
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandText = "SELECT top 100 TransactionID, Transactions FROM TransactionsTableShort where TransactionID>2000";
            

            myAdapter = new OleDbDataAdapter();

            myAdapter.SelectCommand = myCommand;

            myAdapter.Fill(myDatabase, "TransactionTable");


            return myDatabase;

        }


        /// <summary>
        /// Saves data in memory to a database table.
        /// </summary>
        /// <param name="dataBase">
        /// The in-memory database containing data to be saved to a database.
        /// </param>
        /// <param name="rdbmsConnectionString">
        /// The connection string used to connect to the database.
        /// </param>
        /// <param name="tableName">
        /// The table in the in-memory database containing data used to update a database using the DataAdapter.
        /// </param>
        /// <param name="dataSource">
        /// A string containing a SQL statement, a table name or the name of a stored procedure.
        /// <para>
        /// <param name="commandType">
        /// A CommandType enumeration of CommandType.StoredProcedure or CommandType.Text or CommandType.TableDirect.
        /// </param>
        /// <param name="commandAction">
        /// An action for the DataAdapter to take.
        /// <example>
        /// INSERT, DELETE or UPDATE action on a database.
        /// </example>
        /// </param>
        /// <returns>
        /// A System.Data.DataSet strongly typed object containing data.
        /// </returns>
        public Data SaveDatabaseData(Data dataBase, string rdbmsConnectionString, string tableName, string dataSource, CommandType commandType, CommandAction commandAction)
        {

            myConnection = new OleDbConnection(rdbmsConnectionString);

            myCommand = new OleDbCommand(dataSource, myConnection);


            if (commandType == CommandType.StoredProcedure)
            {
                myCommand.CommandType = CommandType.StoredProcedure;
            }

            else if (commandType == CommandType.Text)
            {
                myCommand.CommandType = CommandType.Text;
            }

            else if (commandType == CommandType.TableDirect)
            {
                myCommand.CommandType = CommandType.TableDirect;
            }


            myAdapter = new OleDbDataAdapter();


            if (commandAction == CommandAction.deleteCommand)
            {
                myAdapter.DeleteCommand = myCommand;
            }

            else if (commandAction == CommandAction.insertCommand)
            {
                myAdapter.InsertCommand = myCommand;
            }

            else if (commandAction == CommandAction.updateCommand)
            {
                myAdapter.UpdateCommand = myCommand;
            }


            myAdapter.Update(dataBase, tableName);


            return dataBase;

        }


    }


}
