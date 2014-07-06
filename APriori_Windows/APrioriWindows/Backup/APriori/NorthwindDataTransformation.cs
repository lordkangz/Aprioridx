using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Collections;
using VISUAL_BASIC_DATA_MINING_NET.CustomEvents;


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
	/// This class transforms the products, orders and order details tables in the Northwind database into 
	/// a transactions table that can be analyzed by the C#.NET data mining market based algorithm.
	/// </summary>
	/// <remarks>
	/// <see cref="VISUAL_BASIC_DATA_MINING_NET.DataTransformationServices.NorthwindDatabase"/>
	/// </remarks>
		public class NorthwindDTS : NorthwindDataSchema
		{

			/// <summary>
			/// The default parameterless constructor for the NorthwindDTS class.
			/// </summary>
			public NorthwindDTS()
			{
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
			/// A public delegate for the custom event class ProgressMonitorEventArgs.
			/// </summary>
			/// <value>
			/// A System.Delegate class.
			/// </value>
			public delegate void ProgressMonitorEventHandler(object sender, ProgressMonitorEventArgs e);
			
			/// <summary>
			/// A custom event that notifies clients about the progress of the application.
			/// </summary>
			public event ProgressMonitorEventHandler ProgressMonitorEvent;
			

			/// <summary>
			/// System.Data.DataSet variable for analyzing the Northwind data in memory.
			/// </summary>
			protected NorthwindDataSchema northwindDataBase = new NorthwindDataSchema();
		
			/// <summary>
			/// The database of transactions to be analyzed.
			/// </summary>
			protected Data transactionsDatabase = new Data(false);

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


			
			/// <summary>
			/// Fetches Products data from the Nortwind database into a DataSet.
			/// </summary>
			/// <param name="connectionString">
			/// The System.String connection string used to access the Northwind database.
			/// </param>
			/// <returns>
			/// A System.Data.DataSet containing the Northwind Producs data.
			/// </returns>
			public virtual NorthwindDataSchema LoadNorthwindwindProducts(string connectionString)
			{
				this.oledbconnection = new OleDbConnection(connectionString);				
				
				//Fetch Products information into the Products table
				this.productsOleDbDataAdapter = new OleDbDataAdapter(this.productsSELECTSQL, this.oledbconnection);
					
				this.productsOleDbDataAdapter.Fill(this.northwindDataBase,"ProductsTable");

				return this.northwindDataBase;
			}


			/// <summary>
			/// Fetches Orders data from the Northwind database into a DataSet.
			/// </summary>
			/// <param name="connectionString">
			/// The System.String connection string used to access the Northwind database.
			/// </param>
			/// <returns>
			/// A System.Data.DataSet containing the Northwind Orders data.
			/// </returns>
			public virtual NorthwindDataSchema LoadNorthwindwindOrders(string connectionString)
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
			public virtual NorthwindDataSchema LoadNorthwindwindOrderDetails(string connectionString)
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
			/// Tranforms the Northwind products, orders and order details table into a transactions table.
			/// </summary>
			/// <returns>
			/// A VISUAL_BASIC_DATA_MINING_NET.Data object containing transactions to be analyzed.
			/// </returns>
			/// <remarks>
			/// Creates a transactions table in a VISUAL_BASIC_DATA_MINING_NET.Data dataset containing the set of 
			/// transactions to be analyzed by the C#.NET data mining market based algorithm.
			/// </remarks>
			public virtual Data GetOrders()
			{

				int orderID = 0;

				int productID = 0;

				int length = 0;

				int totalOrders = this.northwindDataBase.OrdersTable.Count;

				StringBuilder productName;

				ArrayList uniqueProduct;

				DataRow newRow;

				DataRow [] foundRows;


				foreach(NorthwindDataSchema.OrdersTableRow ordersRow in this.northwindDataBase.OrdersTable.Rows)
				{
					orderID = ordersRow.OrderID;

					foundRows = this.GetOrderDetails(orderID);

					length = foundRows.Length;

					productName = new StringBuilder(4);

					uniqueProduct = new ArrayList(1);


					for(int count = 0; count <= (length-1) ; count++)
					{
						productID = (int)(foundRows[count]["ProductID"]);


						if(!uniqueProduct.Contains(productID))
						{
							uniqueProduct.Add(productID);

							productName.Append(this.GetProduct(productID).Trim());

							if (count <(length-1))
							{
								productName.Append(", ");
							}

							else
							{	//Add the data to the transactions table
								newRow = transactionsDatabase.Tables["TransactionTable"].NewRow();

								newRow["TransactionID"] = orderID;

								newRow["Transactions"] = productName.ToString();

								transactionsDatabase.Tables["TransactionTable"].Rows.Add(newRow);
							}
						}
                        
						ProgressMonitorEventArgs e = new ProgressMonitorEventArgs(1, length, count,"NorthwindDTS.GetOrders()");

						this.OnProgressMonitorEvent(e);
					}
				}
			
				return this.transactionsDatabase;
			}
		
			
			/// <summary>
			/// Fetches data rows from the [Order Details] table that match an OrderID from the Orders table
			/// in the Northwind database.
			/// </summary>
			/// <param name="orderID">
			/// An OrderID from the Orders table in the Northwind database.
			/// </param>
			/// <returns>
			/// A System.Data.DataRow containing a list of [Order Detail] rows from the [Order Details] table
			/// in the Northwind database.
			/// </returns>
			public virtual DataRow [] GetOrderDetails(int orderID)
			{
				DataRow [] foundRows = this.northwindDataBase.OrderDetailsTable.Select("OrderID = " + orderID,"OrderID");

				return foundRows;
			}

			
			/// <summary>
			/// Fetches a Product's name (ProductName) from the Products table of the Northwind database.
			/// </summary>
			/// <param name="productID">
			/// A ProductID from the Products table of the Northwind database.
			/// </param>
			/// <returns>
			/// The name of a Product matches a ProductID from the Products table of the Northwind database.
			/// </returns>
			public virtual string GetProduct(int productID)
			{
				DataRow [] foundRow = this.northwindDataBase.ProductsTable.Select("ProductID = " + productID, "ProductID");

				string productName = (string) (foundRow[0]["ProductName"]);

				return productName;
			}


			/// <summary>
			/// The in-memory cache of data containing Products, Orders and OrderDetails tables.
			/// </summary>
			/// <value>
			/// A System.Data.DataSet object.
			/// </value>
			public virtual NorthwindDataSchema NorthwindDatabase
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
