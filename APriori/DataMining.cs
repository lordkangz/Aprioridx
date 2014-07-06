using System;
using System.Data;
using VISUAL_BASIC_DATA_MINING_NET.APriori;
using VISUAL_BASIC_DATA_MINING_NET.CustomEvents;


	/// <summary>
	/// The VISUAL_BASIC_DATA_MINING_NET namespace contains namespaces and classes used by this assembly.
	/// </summary>
namespace VISUAL_BASIC_DATA_MINING_NET
{

	/// <summary>
	/// A class that provides data mining services using C#.NET, ADO.NET, XML.NET and a Market Based Analysis 
	/// Data Mining Algorithm.
	/// </summary>
	public class DataMining 
	{
		
		//test
		/// <summary>
		/// Initializes a new instance of the DataMining class using a parameterless default constructor.
		/// </summary>
		public DataMining()
		{
		}
		
		
		/// <summary>
		/// Initializes a new instance of the Market Based Analysis Data Mining class and sets it's 
		/// properties.
		/// See <see cref="VISUAL_BASIC_DATA_MINING_NET.DataMining.MarketBasedAnalysis"/> .
		/// </summary>
		/// <returns>
		/// A System.Data.DataSet object containing the tables of the Market Based Data Mining Analysis.
		/// </returns>
		public DataMining(double supportCount, double minimumConfidence, string connectionString, string													dataSource, CommandType dataSourceCommand)
		{
			this.minimumSupportCount = supportCount;

			this.minimumConfidence = minimumConfidence;

			this.connectionString = connectionString;

			this.dataSource = dataSource;

			this.dataSourceCommand = dataSourceCommand;
		}

		/// <summary>
		/// The public OnProgressMonitorEvent raises the ProgressMonitorEvent event by invoking 
		/// the delegates. The sender is always this, the current instance of the class.
		/// </summary>
		/// <param name="e">
		/// A CustomEvents.ProgressMonitorEventArgs object.
		/// </param>
		/// <remarks>
		/// This method is used to invoke a dalegate that notifies clients about the progress of an executing code.
		/// </remarks>
		public void OnProgressMonitorEvent(ProgressMonitorEventArgs e)
		{
			if (ProgressMonitorEvent != null) 
			{
				// Invokes the delegates. 
				ProgressMonitorEvent(this, e);
			}
		}

		/// <summary>
		/// The public OnProgressMonitoringCompletedEvent raises the ProgressMonitorEvent event by invoking 
		/// the public OnProgressMonitorEvent. This method is invoked by an event source when an event monitoring 
		/// is completed. 
		/// </summary>
		/// <param name="e">
		/// A CustomEvents.ProgressMonitorEventArgs object.
		/// </param>
		/// <remarks>
		/// This method is used to pass messages from event sources to clients.
		/// </remarks>
		public void OnProgressMonitoringCompletedEvent(object sender, ProgressMonitorEventArgs e)
		{
			if (ProgressMonitorEvent != null) 
			{
				// Invokes the delegates. 
				ProgressMonitorEvent(this, e);				
			}

			else
			{
				ProgressMonitorEventArgs newE = new ProgressMonitorEventArgs(e);

				ProgressMonitorEvent(this, e);
			}			
		}
			
		/// <summary>
		/// A custom event that notifies clients about the progress of the executing code.
		/// </summary>
		public event ProgressMonitorEventHandler ProgressMonitorEvent;
		
		/// <summary>
		/// APriori.Apriori implements the C#.NET market based data mining algorithm. 
		/// </summary>
		protected Apriori AP;		
		
		/// <summary>
		/// A strongly typed DataSet containing an in-memory cache of the results of the Market Based Analysis Data Mining.
		/// </summary>
		/// <value>
		/// A VISUAL_BASIC_DATA_MINING_NET.Data strongly typed System.Data.DataSet object.
		/// </value>
		protected Data dataBase;

		/// <summary>
		/// A System.Data.DataView object for viewing the tables of the Market Based Analysis tables.
		/// </summary>
		protected DataView viewDataMiningAnalysis;		
		
		/// <summary>
		/// Stores the minimum support count required for every frequent set of items.
		/// </summary>
		protected double minimumSupportCount;
		
		/// <summary>
		/// The minimum confidence required for the market based data mining rules created.
		/// See <see cref="VISUAL_BASIC_DATA_MINING_NET.DataMining.MarketBasedAnalysis"/>
		/// </summary>
		protected double minimumConfidence;
		
		/// <summary>
		/// A string used to connect to a relational database like SQL Server, Ms Access or Oracle.
		/// </summary>
		protected string connectionString;

		/// <summary>
		/// Stores the path to an XML file that contains Transactions data.
		/// </summary>
		protected string xmlFilePath;
		
		/// <summary>
		/// A stored procedure, table or SQL SELECT statement that will provide the transactions data.
		/// </summary>
		protected string dataSource;
		
		/// <summary>
		/// A CommandType enumeration of CommandType.StoredProcedure or CommandType.Text or CommandType.TableDirect.
		/// </summary>
		protected CommandType dataSourceCommand;

		/// <summary>
		/// A System.Int32 variable that contains the number of transactions in the transactions table.
		/// </summary>
		protected int transactionsCount;
		
	
		/// <summary>
		///The support count is the number of transactions in a database containing a set of items. 
		/// </summary>
		/// <value>
		/// A public read only System.Int32 variable.
		/// </value>
		public double MinimumSupportCount
		{
			get
			{
				return minimumSupportCount;
			}
		}
		
		
		/// <summary>
		/// The minimum confidence required for the market based data mining rules created.
		/// </summary>
		/// <value>
		/// A public read only System.Int32 variable.
		/// </value>
		public double MinimumConfidence
		{
			get
			{
				return minimumConfidence;
			}
		}


		/// <summary>
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
		/// <para>
		/// To use a SQL statement to select transactions data you can use the following statement :
		/// <example>
		///  "SELECT TransactionID, Transactions FROM TransactionsTable"
		/// </example>
		/// </para>
		/// </summary>
		/// <value>
		/// A public read only System.String variable.
		/// </value>
		public string ConnectionString
		{
			get
			{
				return connectionString;
			}
		}
		

		/// <summary>
		/// The path to an XML file that contains Transactions data.
		/// </summary>
		/// <value>
		/// A public read only System.String variable.
		/// </value>
		/// <include file='APrioriExamples.xml' path='Documentation/SourceCode[@name="StartingSampleC"]/*' />
		public string XMLFilePath
		{
			get
			{
				return xmlFilePath;
			}
		}
		
		
		///<summary>
		/// A string containing a SQL statement, a table name or the name of a stored procedure.
		/// <para>
		/// To use a table it must have a TransactionID field and a Transactions field.
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
		/// </summary>
		/// <value>
		/// A public System.String variable.
		/// </value>
		public string DataSource
		{
			get
			{
				return dataSource;
			}
		}
		
		
		/// <summary>
		/// A CommandType enumeration of CommandType.StoredProcedure or CommandType.Text or CommandType.TableDirect.
		/// </summary>
		/// <value>
		/// A public System.Data.CommandType enumeration.
		/// </value>
		public CommandType DataSourceCommand
		{
			get
			{
				return dataSourceCommand;
			}
		}

		
		/// <summary>
		/// A strongly typed DataSet containing an in-memory cache of the results of the Market Based Analysis Data Mining.
		/// </summary>
		/// <value>
		/// A VISUAL_BASIC_DATA_MINING_NET.Data strongly typed System.Data.DataSet object.
		/// </value>
		public Data DataBase
		{
			get
			{
				return dataBase;
			}
		}
		
		
		/// <summary>
		/// Retrieves the results of a Market Based Analysis as an in-memory cache of data.
		/// </summary>
		/// <param name="supportCount">
		/// The support count is the number of transactions containing a set of items.
		/// </param>
		/// <param name="minimumConfidence">
		/// The confidence of two sets of items A and B is the number of transactions supported by A and B
		/// divided by the number of transactions divided by A and vice versa. 
		/// <example>
		/// confidence[A->B) = (number of transactions containing both A and B) / (number of transactions 
		///																			containing only A)
		/// </example>
		/// </param>
		/// <param name="connectionString">
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
		/// <param name="dataSourceCommand">
		///  A CommandType enumeration of CommandType.StoredProcedure or CommandType.Text or CommandType.TableDirect.
		/// </param>
		/// <returns>
		/// A System.Data.DataSet in-memory database containing the Market Based Analysis results in
		/// the TransactionsTable, ItemsetTable, SubsetTable, Rulestable.
		/// </returns>
		/// <remarks>
		/// See  <see cref="VISUAL_BASIC_DATA_MINING_NET.DataAccessLayer.GetTransactionsData"/>
		/// </remarks>
		public Data MarketBasedAnalysis(double supportCount, double minimumConfidence, string connectionString, string																			dataSource, CommandType dataSourceCommand)
		{

			Database database = new Database();

			ItemsetCandidate Item = new ItemsetCandidate();

			this.AP = new APriori.Apriori();

			this.AP.ProgressMonitorEvent += new ProgressMonitorEventHandler(this.OnProgressMonitoringCompletedEvent);
			

			this.dataBase = database.GetTransactionsData(connectionString, dataSource, dataSourceCommand);

			database.Transactions = this.dataBase;
			
			
			this.transactionsCount = this.dataBase.TransactionTable.Count;
						
						
			supportCount = ((supportCount / 100) * this.transactionsCount);

			minimumConfidence = (minimumConfidence / 100);
			
			
			string support = "SupportCount >= " + supportCount + " AND Level > 1";

			string sort = "SupportCount, Level";
			
			
			ItemsetCandidate uniqueItems = AP.CreateOneItemsets(database);


			AP.AprioriGenerator(uniqueItems,database,Convert.ToInt32(supportCount));


			ItemsetArrayList [] keys = database.GetItemset(support, sort);


			
			string msg = "Creating Frequent Subsets for Items";
			
			ProgressMonitorEventArgs e = new ProgressMonitorEventArgs(1,100,95,"DataMining.MarketBasedAnalysis(3)",msg );

			this.OnProgressMonitorEvent(e);

				
			for(int counter = 0; counter < keys.Length; counter++)
			{
				AP.CreateItemsetSubsets(0,keys[counter], null, database);
			}


			
			msg = "Completed Diagnosis Affinity Analysis";
			
			e = new ProgressMonitorEventArgs(1,100,100,"DataMining.MarketBasedAnalysis(3)",msg );

			this.OnProgressMonitorEvent(e);

			
			
			//Set the public properties of the class
			this.minimumSupportCount = supportCount;

			this.minimumConfidence = minimumConfidence;

			this.connectionString = connectionString;

			this.dataSource = dataSource;

			this.dataSourceCommand = dataSourceCommand;

			//return the database of transactions
			return this.dataBase;
			
		}

		
		/// <summary>
		/// Retrieves the results of a Market Based Analysis as an in-memory cache of data from an XML file.
		/// </summary>
		/// <param name="supportCount">
		/// The support count is the number of transactions containing a set of items.
		/// </param>
		/// <param name="minimumConfidence">
		/// The confidence of two sets of items A and B is the number of transactions supported by A and B
		/// divided by the number of transactions divided by A and vice versa. 
		/// <example>
		/// confidence[A->B) = (number of transactions containing both A and B) / (number of transactions 
		///																			containing only A)
		/// </example>
		/// </param>
		/// <param name="xmlFilePath">
		/// The path to an XML file containing transaction data.
		/// </param>
		/// <returns>
		/// A System.Data.DataSet in-memory database containing the Market Based Analysis results in
		/// the TransactionsTable, ItemsetTable, SubsetTable, Rulestable.
		/// </returns>
		/// <remarks>
		/// See  <see cref="VISUAL_BASIC_DATA_MINING_NET.DataAccessLayer.GetXMLData"/>
		/// </remarks>
		public Data MarketBasedAnalysis(double supportCount, double minimumConfidence, string xmlFilePath)
		{

			Database database = new Database();

			ItemsetCandidate Item = new ItemsetCandidate();


			this.AP = new APriori.Apriori();

			this.AP.ProgressMonitorEvent += new ProgressMonitorEventHandler(this.OnProgressMonitoringCompletedEvent);
			

			this.dataBase = database.GetXMLData(xmlFilePath);


			database.Transactions = this.dataBase;
			
			
			this.transactionsCount = this.dataBase.TransactionTable.Count;
						
						
			supportCount = ((supportCount / 100) * this.transactionsCount);

			minimumConfidence = (minimumConfidence / 100);
			
			
			string support = "SupportCount >= " + supportCount + " AND Level > 1";

			string sort = "SupportCount, Level";
			
			
			ItemsetCandidate uniqueItems = AP.CreateOneItemsets(database);


			AP.AprioriGenerator(uniqueItems,database,Convert.ToInt32(supportCount));


			ItemsetArrayList [] keys = database.GetItemset(support, sort);


			
			string msg = "Creating Frequent Subsets for Items";
			
			ProgressMonitorEventArgs e = new ProgressMonitorEventArgs(1,100,95,"DataMining.MarketBasedAnalysis(3)",msg );

			this.OnProgressMonitorEvent(e);

				
			for(int counter = 0; counter < keys.Length; counter++)
			{
				AP.CreateItemsetSubsets(0,keys[counter], null, database);
			}


			
			msg = "Completed Diagnosis Affinity Analysis";
			
			e = new ProgressMonitorEventArgs(1,100,100,"DataMining.MarketBasedAnalysis(3)",msg );

			this.OnProgressMonitorEvent(e);

			
			//Set the public properties of the class
			this.minimumSupportCount = supportCount;

			this.minimumConfidence = minimumConfidence;

			this.xmlFilePath = xmlFilePath;

			//return the database of transactions
			return this.dataBase;
			
		}


		public Data MarketBasedAnalysis(double supportCount, double minimumConfidence, Data transactionsData)
		{

			Database database = new Database();

			ItemsetCandidate Item = new ItemsetCandidate();


			this.AP = new APriori.Apriori();

			this.AP.ProgressMonitorEvent += new ProgressMonitorEventHandler(this.OnProgressMonitoringCompletedEvent);
			

			this.dataBase = transactionsData;


			database.Transactions = this.dataBase;
			
			
			this.transactionsCount = this.dataBase.TransactionTable.Count;
						
						
			supportCount = ((supportCount / 100) * this.transactionsCount);

			minimumConfidence = (minimumConfidence / 100);
			
			
			string support = "SupportCount >= " + supportCount + " AND Level > 1";

			string sort = "SupportCount, Level";
			
			
			ItemsetCandidate uniqueItems = AP.CreateOneItemsets(database);


			AP.AprioriGenerator(uniqueItems,database,Convert.ToInt32(supportCount));


			ItemsetArrayList [] keys = database.GetItemset(support, sort);



			string msg = "Creating Frequent Subsets for Items";
			
			ProgressMonitorEventArgs e = new ProgressMonitorEventArgs(1,100,95,"DataMining.MarketBasedAnalysis(3)",msg );

			this.OnProgressMonitorEvent(e);
	

			for(int counter = 0; counter < keys.Length; counter++)
			{
				AP.CreateItemsetSubsets(0,keys[counter], null, database);
			}


            msg = "Completed Diagnosis Affinity Analysis";
			
			e = new ProgressMonitorEventArgs(1,100,100,"DataMining.MarketBasedAnalysis(3)",msg );

			this.OnProgressMonitorEvent(e);
			

			
			//Set the public properties of the class
			this.minimumSupportCount = supportCount;

			this.minimumConfidence = minimumConfidence;

			//return the database of transactions
			return this.dataBase;
			
		}
		
		
		/// <summary>
		/// A DataView for viewing the results of the Market Based Analysis Data Mining results. 
		/// </summary>
		/// <returns>
		///A System.Data.DataView object for viewing the tables of the Market Based Analysis tables.
		/// </returns>
		public DataView ViewDataMiningAnalysis()
		{
			double minimumconfidence = ((this.minimumConfidence) * 100);

			string confidence = "Confidence >= " + minimumconfidence + "%";
 
			viewDataMiningAnalysis = new DataView(this.dataBase.Tables["ViewRulesTable"], confidence, "Confidence",														DataViewRowState.CurrentRows);			
			
			return viewDataMiningAnalysis;
		}
				
		
		/// <summary>
		/// A DataView for viewing the contents of any of the Market Based Analysis tables.
		/// </summary>
		/// <param name="tableName">
		/// The name of the table containing the results to be viewed with the DataView object.
		/// </param>
		/// <returns>
		/// A System.Data.DataView object for viewing the tables of the Market Based Analysis tables.
		/// </returns>
		public DataView ViewDataMiningAnalysis(string tableName)
		{
			viewDataMiningAnalysis = new DataView(this.dataBase.Tables[tableName]);

			return viewDataMiningAnalysis;
		}


		/// <summary>
		/// A DataView for viewing the contents of any of the Market Based Analysis tables.
		/// </summary>
		/// <param name="tableName">
		/// The name of the table containing the results to be viewed with the DataView object.
		/// </param>
		/// <param name="sortColumn">
		/// The name of the table column to use in sorting the data to be viewed.
		/// </param>
		/// <returns>
		/// A System.Data.DataView object for viewing the tables of the Market Based Analysis tables.
		/// </returns>
		public DataView ViewDataMiningAnalysis(string tableName, string sortColumn)
		{
			viewDataMiningAnalysis = new DataView(this.dataBase.Tables[tableName],"",sortColumn,DataViewRowState.CurrentRows);

			return viewDataMiningAnalysis;
		}


		/// <summary>
		/// A DataView for viewing the contents of any of the Market Based Analysis tables.
		/// </summary>
		/// <param name="tableName">
		/// The name of the table containing the results to be viewed with the DataView object.
		/// </param>
		/// <returns>
		/// A System.Data.DataView object for viewing the tables of the Market Based Analysis tables.
		/// </returns>
		public DataView ViewDataMiningAnalysis(string tableName, double minimumConfidence)
		{
			string confidence = "Confidence >= " + minimumConfidence;
 
			viewDataMiningAnalysis = new DataView(this.dataBase.Tables[tableName], confidence, "Confidence",														DataViewRowState.CurrentRows);			
			
			return viewDataMiningAnalysis;
		}


		

	}


}
