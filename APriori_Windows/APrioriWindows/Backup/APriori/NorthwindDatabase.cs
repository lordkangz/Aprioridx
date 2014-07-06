using System;
using System.Data;
using System.Data.OleDb;


	/// <summary>
	/// The VISUAL_BASIC_DATA_MINING_NET namespace contains namespaces and classes used by this assembly.
	/// </summary>
namespace VISUAL_BASIC_DATA_MINING_NET
{

	///<summary>
	///The VISUAL_BASIC_DATA_MINING_NET.DataTransformationServices is used to transform data contained in tables and relationships
	///like the Northwind database to a single table containing a TransactionID and Transactions field which is used for 
	///the C#.NET market based sales data mining.
	///</summary>
	namespace DataTransformationServices
	{
		
		
		/// <summary>
		/// <para>
		/// This class is mainly used to create the NorthwindDatabaseSchema class using the XML Schema Definition tool, XSD.exe.
		/// The functions of the class create the products, orders and orderdetails tables and populate them.
		/// The XSD.exe is used to generate the Schema from an XML file created from the Northwind dataset.
		/// </para>
		/// The NorthWindSchema class transfroms data that confirms to the Northwind Products - Orders - Order
		/// Details table design to a DataSet that can be analyzed by the Market Based Data Mining C#.NET Algorithm.
		/// </summary>
		/// <remarks>
		/// This class provides Data Transformation Services enabling the mapping of realtional data tables designed
		/// like the famous Northwind Products - Orders - OrderDetails to a flat Transactions table {TransactionID,
		/// Transactions} that can be analyzed by this C#.NET Data Mining Algorithm.
		/// </remarks>
		/// <example>
		/// To create the Northwind tables :
		/// <code>
		/// <para>
		/// NorthwindSchema northwind = new NorthwindSchema();
		/// </para>
		/// <para>
		/// northwind.CreateOrdersTable();
		/// northwind.CreateProductsTable();
		/// northwind.CreateOrderDetailsTable();
		/// </para>
		/// </code>
		/// To fetch Products, Orders and OrderDetails information into the the newly created tables above :
		/// <code>
		/// <para>
		/// string connect = "Provider=SQLOLEDB;Data Source=localhost;Initial Catalog=APriori;Integrated Security=SSPI;"
		/// </para>
		///  <para>
		///  northwind.LoadNorthwindwindProducts(connect);
		///  northwind.LoadNorthwindwindOrders(connect);
		///  northwind.LoadNorthwindwindOrderDetails(connect);
		///  </para>
		/// </code>
		/// </example>
		public class NorthwindDatabase 
		{
			public NorthwindDatabase()
			{
			}


			/// <summary>
			/// System.Data.DataSet variable for analyzing the Northwind data in memory.
			/// </summary>
			protected DataSet northwindDataBase = new DataSet("NorthwindDataSchema");

			/// <summary>
			/// System.Data.DataTable variable for viewing the Northwind Products table data. 
			/// </summary>
			protected DataTable productsTable = new DataTable("ProductsTable");


			/// <summary>
			/// System.Data.DataTable variable for viewing the Northwind Orders table data. 
			/// </summary>
			protected DataTable ordersTable = new DataTable("OrdersTable");


			/// <summary>
			/// System.Data.DataTable variable for viewing the Northwind Orders table data. 
			/// </summary>
			protected DataTable orderDetailsTable = new DataTable("OrderDetailsTable");

			
			/// <summary>
			/// A SQL connection string for accessing a Northwind database.
			/// </summary>
			protected string connectionString;
				
			/// <summary>
			/// A System.Data.OleDb.Connection object for accessing a Northwind database.
			/// </summary>
			protected OleDbConnection oledbconnection;

			/// <summary>
			/// A System.Data.OleDb.OleDbDataAdapter object for accessing Products data in a Northwind database.
			/// </summary>
			protected OleDbDataAdapter productsOleDbDataAdapter;
			
			/// <summary>
			/// A System.Data.OleDb.OleDbDataAdapter object for accessing Orders data in a Northwind database.
			/// </summary>
			protected OleDbDataAdapter ordersOleDbDataAdapter;

			/// <summary>
			/// A System.Data.OleDb.OleDbDataAdapter object for accessing OrderDetails data in a Northwind database.
			/// </summary>
			protected OleDbDataAdapter orderDetailsOleDbDataAdapter;

			/// <summary>
			/// A System.String SQL statement for selecting Product information from the Northwind database.
			/// </summary>
			/// <value>
			/// "SELECT ProductID, ProductName FROM Products"
			/// </value>
			protected string productsSELECTSQL = ("SELECT ProductID, ProductName FROM Products");
			
			/// <summary>
			/// A System.String SQL statement for selecting Orders information from the Northwind database.
			/// </summary>
			/// <value>
			/// "SELECT OrderID FROM Orders"
			/// </value>
			protected string ordersSELECTSQL = ("SELECT OrderID FROM Orders");
			
			/// <summary>
			/// A System.String SQL statement for selecting OrderDetails information from the Northwind database.
			/// </summary>
			/// <value>
			/// "SELECT OrderID, ProductID FROM [Order Details]"
			/// </value>
			protected string orderDetailsSELECTSQL = ("SELECT OrderID, ProductID FROM [Order Details]");


			public virtual DataTable CreateProductsTable()
			{
				DataColumn [] productsColumnsKeys = new DataColumn[1];

				DataColumn productsColumns;


				//Define the ProductID and primary key column for the Northwind Products table
				productsColumnsKeys[0] = new DataColumn("ProductID",System.Type.GetType("System.Int32"));
				productsColumnsKeys[0].AutoIncrement = false;
				productsColumnsKeys[0].Unique = true;

				this.productsTable.Columns.Add(productsColumnsKeys[0]);
			

				//define the ProductName column for the Northwind Products table
				productsColumns = new DataColumn("ProductName",System.Type.GetType("System.String"));

				this.productsTable.Columns.Add(productsColumns);


				//Set the primary keys for the Northwind Products table
				this.productsTable.PrimaryKey = productsColumnsKeys;			


				//Add the Products Table to the Northwind DataSet Tables collection
				this.northwindDataBase.Tables.Add(this.productsTable);

				return this.productsTable;
			}


			public virtual DataTable CreateOrdersTable()
			{
				DataColumn [] ordersColumnsKeys = new DataColumn[1];				

				//Define the OrderID and primary key column for the Northwind Orders table
				ordersColumnsKeys[0] = new DataColumn("OrderID",System.Type.GetType("System.Int32"));
				ordersColumnsKeys[0].AutoIncrement = false;
				ordersColumnsKeys[0].Unique = true;
				
				this.ordersTable.Columns.Add(ordersColumnsKeys[0]);

				
				//Set the primary key for the Northwind Orders table
				this.ordersTable.PrimaryKey = ordersColumnsKeys;


				//Add the Orders Table to the database
				this.northwindDataBase.Tables.Add(this.ordersTable);

				return this.ordersTable;
			}


			public virtual DataTable CreateOrderDetailsTable()
			{
				DataColumn [] orderDetailsColumnsKeys = new DataColumn[2];
				

				//Define the ProductID primary key column for the Northwind OrderDetails table
				orderDetailsColumnsKeys[0] = new DataColumn("ProductID",System.Type.GetType("System.Int32"));
				orderDetailsColumnsKeys[0].AutoIncrement = false;
				orderDetailsColumnsKeys[0].Unique = false;

				this.orderDetailsTable.Columns.Add(orderDetailsColumnsKeys[0]);
			

				//Define the OrderID primary key column for the Northwind OrderDetails table
				orderDetailsColumnsKeys[1] = new DataColumn("OrderID",System.Type.GetType("System.Int32"));
				orderDetailsColumnsKeys[1].AutoIncrement = false;
				orderDetailsColumnsKeys[1].Unique = false;

				this.orderDetailsTable.Columns.Add(orderDetailsColumnsKeys[1]);


				//Set the primary keys for the Northwind OrderDetails table
				this.orderDetailsTable.PrimaryKey = orderDetailsColumnsKeys;			


				//Add the Products Table to the Northwind DataSet Tables collection
				this.northwindDataBase.Tables.Add(this.orderDetailsTable);

				return this.orderDetailsTable;
			}

			
			/// <summary>
			/// Fetches Products data from the Nortwind database into a DataSet.
			/// </summary>
			/// <param name="connectionString">
			/// The System.String connection string used to access the Northwind database.
			/// </param>
			/// <returns>
			/// A System.Data.DataSet containing the Northwind Producs data.
			/// </returns>
			public virtual DataSet LoadNorthwindwindProducts(string connectionString)
			{
				this.oledbconnection = new OleDbConnection(connectionString);				
				
				//Fetch Products information into the Products table
				this.productsOleDbDataAdapter = new OleDbDataAdapter(this.productsSELECTSQL, this.oledbconnection);

				this.productsOleDbDataAdapter.Fill(this.northwindDataBase,"ProductsTable");

				return this.northwindDataBase;
			}


			/// <summary>
			/// Fetches Orders data from the Nortwind database into a DataSet.
			/// </summary>
			/// <param name="connectionString">
			/// The System.String connection string used to access the Northwind database.
			/// </param>
			/// <returns>
			/// A System.Data.DataSet containing the Northwind Orders data.
			/// </returns>
			public virtual DataSet LoadNorthwindwindOrders(string connectionString)
			{
				this.oledbconnection = new OleDbConnection(connectionString);				
				
				//Fetch Orders information into the Orders table
				this.ordersOleDbDataAdapter = new OleDbDataAdapter(this.ordersSELECTSQL, this.oledbconnection);

				this.ordersOleDbDataAdapter.Fill(this.northwindDataBase,"OrdersTable");

				return this.northwindDataBase;
			}


			/// <summary>
			/// Fetches Orders data from the Nortwind database into a DataSet.
			/// </summary>
			/// <param name="connectionString">
			/// The System.String connection string used to access the Northwind database.
			/// </param>
			/// <returns>
			/// A System.Data.DataSet containing the Northwind Orders data.
			/// </returns>
			public virtual DataSet LoadNorthwindwindOrderDetails(string connectionString)
			{
				this.oledbconnection = new OleDbConnection(connectionString);				
				
				//Fetch OrderDetails information into the OrderDetails table
				this.orderDetailsOleDbDataAdapter = new OleDbDataAdapter(this.orderDetailsSELECTSQL, this.oledbconnection);

				this.orderDetailsOleDbDataAdapter.Fill(this.northwindDataBase,"OrderDetailsTable");

				return this.northwindDataBase;
			}

			
			/// <summary>
			/// Writes the XML and XMLSchema of the in-memory Northwind DataSet to a file.
			/// </summary>
			/// <param name="xmlFilePath">
			/// The path and name of the XML and XMLSchema file to be created.
			/// </param>
			public virtual void WriteXML(string xmlFilePath)
			{
                this.northwindDataBase.WriteXml(xmlFilePath,XmlWriteMode.WriteSchema);
			}
			
			
			/// <summary>
			/// The in-memory cache of data containing Products, Orders and OrderDetails tables.
			/// </summary>
			/// <value>
			/// A System.Data.DataSet object.
			/// </value>
			public virtual DataSet Database
			{
				get
				{
					return this.northwindDataBase;
				}
			}

			
			/// <summary>
			/// The connection string to the Northwind database.
			/// </summary>
			/// <value>
			/// A System.String value.
			/// </value>
			public virtual string ConnectionString
			{
				get
				{
					return this.connectionString;
				}

				set
				{
					this.connectionString = value;
				}
			}


		}		

	}
}
