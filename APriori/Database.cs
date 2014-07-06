using System;
using System.Data;
using VISUAL_BASIC_DATA_MINING_NET;
using VISUAL_BASIC_DATA_MINING_NET.APriori;
using VISUAL_BASIC_DATA_MINING_NET.DataTransformationServices;
using VISUAL_BASIC_DATA_MINING_NET.CustomEvents;


	/// <summary>
	/// The VISUAL_BASIC_DATA_MINING_NET namespace contains namespaces and classes used by this assembly.
	/// </summary>
namespace VISUAL_BASIC_DATA_MINING_NET
{


	/// <summary>
	/// The VISUAL_BASIC_DATA_MINING_NET.APriori namespace contains class and methods used to implement the APriori
	/// Market Based Analysis Data Mining Algorithm.
	/// </summary>
	/// <remarks>
	namespace APriori
	{
	

		/// <summary>
		/// The Database of transactions to be analyzed.
		/// </summary>
		public class Database : DataAccessLayer
		{
		
			/// <summary>
			/// System.Data.DataSet variable for analyzing the Market Based Analysis data in memory.
			/// </summary>
			DataSet myTransactions = new DataSet("Data");		

			/// <summary>
			/// System.Data.DataTable variable for the database transactions.
			/// </summary>
			DataTable myTable = new DataTable("TransactionTable");
		
			/// <summary>
			/// System.Data.DataTable variable for the transaction itemsets. 
			/// </summary>
			DataTable itemsTable = new DataTable("ItemsetTable");

			/// <summary>
			/// System.Data.DataTable variable for the subsets of transaction itemsets. 
			/// </summary>
			DataTable subsetTable = new DataTable("SubsetTable");

			/// <summary>
			/// System.Data.DataTable variable for the rules table expressing the confidence and support between itemsets. 
			/// </summary>
			DataTable rulesTable = new DataTable("RulesTable");

		
			/// <summary>
			/// Initializes a new instance of the Database class using the parameterless default constructor.
			/// </summary>
			public Database()
			{
				//Create the transactions table.
				this.CreateTransactionsTable();
			
				//Create the Items Table.
				this.CreateItemsetTable();

				//Create the Subsets Table.
				this.CreateSubsetTable();

				//Create the Rules Table.
				this.CreateRulesTable();
			}

		
			/// <summary>
			/// Adds a transaction to the Transactions table.
			/// </summary>
			/// <param name="newDataRow">
			/// A System.Data.DataRow object containing the data to add to the transactions table.
			/// </param>
			public void AddTransaction(DataRow newDataRow)
			{
				myTable.Rows.Add(newDataRow);
			}
		
		
			/// <summary>
			/// Adds a comma separated list of transactions.
			/// </summary>
			/// <param name="Transactions">
			/// A list of transactions to add.
			/// </param>
			public void AddTransaction(string Transactions)
			{
				DataRow myRow;

				myRow = myTable.NewRow();

				myRow["Transactions"] = Transactions;

				myTable.Rows.Add(myRow);
			}
		
			/// <summary>
			/// The System.Data.Dataset database of transactions to be analyzed.
			/// </summary>
			public DataSet Transactions
			{
				get
				{
					return myTransactions;
				}
				set
				{
					myTransactions = value;
				}

			}
		
		
			/// <summary>
			/// Creates the transactions table.
			/// </summary>
			/// <returns>
			/// Returns the transactions table created.
			/// </returns>
			private DataTable CreateTransactionsTable()
			{
				DataColumn [] myColumn = new DataColumn[1];

				//Define the primary key column for the table
				myColumn[0] = new DataColumn("TransactionID",System.Type.GetType("System.Int32"));
				myColumn[0].AutoIncrement = true;
				myColumn[0].AutoIncrementSeed = 1;
				myColumn[0].AutoIncrementStep = 1;
				myColumn[0].Unique = true;
			
				myTable.Columns.Add(myColumn[0]);

			
				//Set the primary key for this table
				myTable.PrimaryKey = myColumn;

			
				//Define the column to hold Transaction Data
				DataColumn transaction_list = new DataColumn("Transactions",System.Type.GetType("System.String"));
				transaction_list.AllowDBNull = false;
				myTable.Columns.Add(transaction_list);

				//Add the table to the Database
				myTransactions.Tables.Add(myTable);

				return myTable;
		
			}

		
			/// <summary>
			/// Creates the database table that stores each itemset.
			/// </summary>
			/// <returns>
			/// Returns the itemset table created.
			/// </returns>
			/// <remarks>
			/// <example>
			/// <code>
			///	APriori.Database DB = new APriori.Database();
			/// 
			///	System.Data.DataTable myTable = DB.CreateItemsetTable();		 
			/// </code>
			/// </example>
			/// </remarks>
			private DataTable CreateItemsetTable()
			{
				DataColumn [] myItemsColumnKey = new DataColumn[1];


				//Define the primary key column for the items table
				myItemsColumnKey[0] = new DataColumn("ItemID",System.Type.GetType("System.Int32"));
				myItemsColumnKey[0].AutoIncrement = true;
				myItemsColumnKey[0].AutoIncrementSeed = 1;
				myItemsColumnKey[0].AutoIncrementStep = 1;
				myItemsColumnKey[0].Unique = true;

				itemsTable.Columns.Add(myItemsColumnKey[0]);

				//Set the primary key for the items table
				itemsTable.PrimaryKey = myItemsColumnKey; 


				//Define the other columns for the Items Table
				DataColumn myItemset = new DataColumn("Itemset",System.Type.GetType("System.String"));
			
				myItemset.AllowDBNull = false;

				myItemset.Unique = true;

				itemsTable.Columns.Add(myItemset);


				itemsTable.Columns.Add("Level",System.Type.GetType("System.Int32"));

				itemsTable.Columns.Add("SupportCount",System.Type.GetType("System.Int32"));


				//Add the Items Table to the database
				myTransactions.Tables.Add(itemsTable);

				return itemsTable;
			}


			/// <summary>
			/// Creates the database table that stores subsets of items.
			/// </summary>
			/// <returns>
			/// Returns the market based analysis suibsets table created.
			/// </returns>
			/// <remarks>
			/// <example>
			/// <code>
			///	APriori.Database DB = new APriori.Database();
			/// 
			///	System.Data.DataTable myTable = DB.CreateSubsetTable();		 
			/// </code>
			/// </example>
			/// </remarks>
			private DataTable CreateSubsetTable()
			{
				DataColumn [] mySubsetColumnKeys = new DataColumn[3];


				//Define the first column and primary key column for the subset table
				mySubsetColumnKeys[0] = new DataColumn("FirstKeyID",System.Type.GetType("System.Int32"));
				mySubsetColumnKeys[0].AutoIncrement = true;
				mySubsetColumnKeys[0].AutoIncrementSeed = 1;
				mySubsetColumnKeys[0].AutoIncrementStep = 1;
				mySubsetColumnKeys[0].Unique = true;

				subsetTable.Columns.Add(mySubsetColumnKeys[0]);
			

				//define the second column and primary key for the subset table
				mySubsetColumnKeys[1] = new DataColumn("ItemID",System.Type.GetType("System.Int32"));

				subsetTable.Columns.Add(mySubsetColumnKeys[1]);


				//define the third column and primary key for the subset table
				mySubsetColumnKeys[2] = new DataColumn("SubsetID",System.Type.GetType("System.Int32"));

				subsetTable.Columns.Add(mySubsetColumnKeys[2]);


				//Set the primary keys for the subset table
				subsetTable.PrimaryKey = mySubsetColumnKeys;			


				//Add the Subsets Table to the database
				myTransactions.Tables.Add(subsetTable);

				return subsetTable;
			}

		
			/// <summary>
			/// Creates the database table that stores each rule.
			/// </summary>
			/// <returns>
			/// Returns the market based analysis rules table created.
			/// </returns>
			/// <remarks>
			/// <example>
			/// <code>
			///	APriori.Database DB = new APriori.Database();
			/// 
			///	System.Data.DataTable myTable = DB.CreateRulesTable();		 
			/// </code>
			/// </example>
			/// </remarks>
			private DataTable CreateRulesTable()
			{
				DataColumn [] myRuleColumnKeys = new DataColumn[1];

				DataColumn myRuleColumn;


				//Define the first column and primary key column for the Rules table
				myRuleColumnKeys[0] = new DataColumn("FirstKeyID",System.Type.GetType("System.Int32"));
				myRuleColumnKeys[0].AutoIncrement = true;
				myRuleColumnKeys[0].AutoIncrementSeed = 1;
				myRuleColumnKeys[0].AutoIncrementStep = 1;
				myRuleColumnKeys[0].Unique = true;

				rulesTable.Columns.Add(myRuleColumnKeys[0]);
			

				//define the second column and left rule column for the Rules table
				myRuleColumn = new DataColumn("LeftRule",System.Type.GetType("System.Int32"));

				rulesTable.Columns.Add(myRuleColumn);


				//define the third column and right rule column for the Rules table
				myRuleColumn = new DataColumn("RightRule",System.Type.GetType("System.Int32"));

				rulesTable.Columns.Add(myRuleColumn);

			
				//define the confidence column for the Rules table
				myRuleColumn = new DataColumn("Confidence",System.Type.GetType("System.Double"));

				rulesTable.Columns.Add(myRuleColumn);


				//Set the primary keys for the Rule table
				rulesTable.PrimaryKey = myRuleColumnKeys;			


				//Add the Rules Table to the database
				myTransactions.Tables.Add(rulesTable);

				return rulesTable;
			}
		
		
			/// <summary>
			/// Adds an Itemset to the database.
			/// </summary>
			/// <param name="itemSet">
			/// An ItemsetArrayList object containing a set of items .
			/// </param>
			/// <param name="seperatorCharacters">
			///  A string used to seperate items parsed from an ItemsetArrayList object into the database.
			/// </param>
			/// <returns>
			/// An integer equal to the Primary Key of the itemset added to the database.
			/// </returns>
			public int AddItemset(ItemsetArrayList itemSet, string seperatorCharacters)
			{
				int keyID=0;

				DataRow myDataRow;
 

				myDataRow = this.myTransactions.Tables["ItemsetTable"].NewRow();


				myDataRow["Itemset"] = ItemsetArrayList.ConvertToString(itemSet, seperatorCharacters);

				myDataRow["Level"] = itemSet.Level;

				myDataRow["SupportCount"] = itemSet.SupportCount;


				this.myTransactions.Tables["ItemsetTable"].Rows.Add(myDataRow);

				keyID = (int)myDataRow[0];

				return keyID;

			}
		
		
			/// <summary>
			/// Adds an itemset to the itemset table.
			/// </summary>
			/// <param name="itemSet">
			/// The set of items to be added as a comma seperated string.
			/// </param>
			/// <param name="itemsetLevel">
			/// The hierarchy of the itemset in the market based analysis.
			/// </param>
			/// <param name="supportCount">
			/// The number of transactions in the APriori ADO.NET database that contain the itemset.
			/// </param>
			/// <returns>
			/// Returns an ADO.NET DataRow.
			/// </returns>
			public DataRow AddItemset(string itemSet, int itemsetLevel, int supportCount)
			{
				DataRow myDataRow;
 

				myDataRow = this.myTransactions.Tables["ItemsetTable"].NewRow();


				myDataRow["Itemset"] = itemSet;

				myDataRow["Level"] = itemsetLevel;

				myDataRow["SupportCount"] = supportCount;


				this.myTransactions.Tables["ItemsetTable"].Rows.Add(myDataRow);

				return myDataRow;

			}

		
			/// <summary>
			/// Retrieves a datarow containing a set of items from the APriori database. 
			/// </summary>
			/// <param name="itemSet">
			/// The exact set of comma seperated items to search for in the Market Based Analysis Database.
			/// </param>
			/// <returns>
			/// Returns an array of DataRow elements containing rows that match the itemSet parameter.
			/// </returns>
			public DataRow [] GetItemset(string itemSet)
			{
				int length = 0;


				DataView myDataView = new DataView(this.myTransactions.Tables["ItemsetTable"]);


				myDataView.Sort = "Itemset";


				DataRowView [] found = myDataView.FindRows(itemSet);


				length = found.Length;


				DataRow [] myDataRow = new DataRow[length];
				
			
				for(int count = 0; count < length; count++)
				{
					myDataRow[count] = found[count].Row;				
				}

				return myDataRow;
			
			}

		
			/// <summary>
			/// Retrieves a DataRow containing the itemset passed to it.
			/// </summary>
			/// <param name="itemSet">
			/// An ItemsetArrayList class to retrieve from the database.
			/// </param>
			/// <returns>
			/// A System.Data.DataRow object containing an itemset.
			/// </returns>
			public DataRow [] GetItemset(ItemsetArrayList itemSet)
			{
				int length = 0;

				string find = ItemsetArrayList.ConvertToString(itemSet, ",");


				DataView myDataView = new DataView(this.myTransactions.Tables[1]);


				myDataView.Sort = "Itemset";


				DataRowView [] found = myDataView.FindRows(find);


				length = found.Length;


				DataRow [] myDataRow = new DataRow[length];
				
			
				for(int count = 0; count < length; count++)
				{
					myDataRow[count] = found[count].Row;				
				}

				return myDataRow;
			
			}

		
		
			/// <summary>
			/// Retrieves an ItemsetArrayList array of frequent itemsets. 
			/// </summary>
			/// <param name="rowFilter">
			/// The minimum support count expression used in filtering itemsets.
			/// </param>
			/// <param name="sortColumn">
			/// The table column used to sort and index the itemsets.
			/// </param>
			/// <returns>
			/// An ItemsetArrayList collection containing the collection of itemsets with the minimum support count.
			/// </returns>
			public ItemsetArrayList [] GetItemset(string rowFilter, string sortColumn)
			{

				int length = 0;

				ItemsetArrayList [] items;

				DataView myDataView = new DataView(this.myTransactions.Tables["ItemsetTable"],rowFilter,sortColumn,												DataViewRowState.CurrentRows);


				DataRow [] found = this.myTransactions.Tables["ItemsetTable"].Select(rowFilter,sortColumn);

				length = found.Length;


				items = new ItemsetArrayList[length];
				
			
				for(int count = 0; count < length; count++)
				{
					items[count] = new ItemsetArrayList(1);
			
					items[count].Add(ItemsetArrayList.ConvertToItemsetArrayList((string) (found[count]["Itemset"]),new Char[] {','}));
				
					items[count].Level = (int) found[count]["Level"];

					items[count].SupportCount = (int) found[count]["SupportCount"];

					items[count].TrimToSize();
				}

				return items;
			
			}

		
			/// <summary>
			/// Retrieves the primary keys of the itemsets passed as a parameter to it.
			/// </summary>
			/// <param name="itemSet">
			/// The ArrayListItemset class to retrieve the PrimaryID for.
			/// </param>
			/// <param name="primaryKeyName">
			/// The name of the primary key column.
			/// </param>
			/// <returns>
			/// An integer value representing the primary key column.
			/// </returns>
			public int [] GetItemset(ItemsetArrayList itemSet, string primaryKeyName)
			{
				int length = 0;

				int [] primaryKey;

				string find = ItemsetArrayList.ConvertToString(itemSet, ",");


				DataView myDataView = new DataView(this.myTransactions.Tables["ItemsetTable"]);


				myDataView.Sort = "Itemset";			
			

				DataRowView [] found = myDataView.FindRows(find);


				length = found.Length;
			
			
				primaryKey = new int[length];
				
			
				for(int count = 0; count < length; count++)
				{
					primaryKey[count] = (int) found[count].Row[primaryKeyName];				
				}

				return primaryKey;
			
			}

		
			/// <summary>
			/// Adds a subset of an itemset to the Subset table.
			/// </summary>
			/// <param name="itemSet">
			/// An ItemsetArrayList to add to the Subset table.
			/// </param>
			/// <param name="subSet">
			/// The subset of items added to the database.
			/// </param>
			/// <returns>
			/// The Primary Key of the subset added to the Subset table.
			/// </returns>
			public int AddSubset(ItemsetArrayList itemSet, ItemsetArrayList subSet)
			{
				int keyID = 0;

				int [] itemID = this.GetItemset(itemSet,"ItemID");

			
				//Convert the ItemsetArrayList to a string
				string subset = ItemsetArrayList.ConvertToString(subSet, ItemsetArrayList.CommaOnly);
		
				DataRow [] mySubsetRows = this.GetItemset(subset);


				if(mySubsetRows.Length !=0)
				{

					int subsetID = (int) mySubsetRows[0][0];

			
					DataRow myDataRow = this.myTransactions.Tables["SubsetTable"].NewRow();

			
					//Only one row will actually be returned because each itemset is added only once to the itemset table
					myDataRow["ItemID"] = itemID[0];
			
					//Only one row will actually be returned because each itemset is added only once to the itemset table
					myDataRow["SubsetID"] = subsetID;

			
					this.myTransactions.Tables["SubsetTable"].Rows.Add(myDataRow);

					keyID = (int) myDataRow["FirstKeyID"];

				}

				else
				{
					keyID = 1;

				}

				return keyID;

			}

		
			/// <summary>
			/// Adds a market based analysis association rule to the rules table.
			/// </summary>
			/// <param name="parentRuleset">
			/// The set of frequent items for which rules are derived.
			/// </param>
			/// <param name="leftRuleset">
			/// The set of items on the left side of an association rule.
			/// </param>
			/// <param name="rightRuleset">
			/// The set of items on the right side of an association rule.
			/// </param>
			/// <returns>
			/// A System.Data.DataRow object containing the rule added to the database.
			/// </returns>
			public DataRow AddRuleset(ItemsetArrayList parentRuleset, ItemsetArrayList leftRuleset, ItemsetArrayList											rightRuleset)
			{
			
				int leftColumnID = 0;

				int rightColumnID = 0;

				double upperNumber = 0;

				double lowerNumber = 0;

				double confidence = 0.0;

				string rowFilter;

				string sortColumn;
			
				DataRow [] found;
            

				DataRow [] leftDataRow = this.GetItemset(leftRuleset);

				DataRow [] rightDataRow = this.GetItemset(rightRuleset);

				DataRow [] parentDataRow = this.GetItemset(parentRuleset);


				//Only one row of data will be returned as each item is unique in the database
				DataRow myDataRow = this.myTransactions.Tables["RulesTable"].NewRow();

			
				leftColumnID = (int) leftDataRow[0]["ItemID"];

				rightColumnID = (int) rightDataRow[0]["ItemID"];


				rowFilter = "LeftRule = " + leftColumnID + " AND rightRule = " + rightColumnID;

				sortColumn = "leftRule, rightRule";


				//DataView myDataView = new DataView(this.myTransactions.Tables["RulesTable"],rowFilter,sortColumn,												DataViewRowState.CurrentRows);


				found = this.myTransactions.Tables["RulesTable"].Select(rowFilter,sortColumn);

			
				//only add unique data rows
				if (found.Length == 0)
				{
					myDataRow["LeftRule"] = leftColumnID;

					myDataRow["RightRule"] = rightColumnID;


					//Calculate the confidence for each number
					upperNumber = (int)parentDataRow[0]["SupportCount"];

					lowerNumber = (int)leftDataRow[0]["SupportCount"];


					confidence = Convert.ToDouble((upperNumber / lowerNumber));


					//Add the confidence value for the rule to the data row
					myDataRow["Confidence"] = confidence;
			

					this.myTransactions.Tables["RulesTable"].Rows.Add(myDataRow);
				}

				return myDataRow;
			

			}

		}
	}

}