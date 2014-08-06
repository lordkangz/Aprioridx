using System;
using System.Data;


	/// <summary>
	/// The VISUAL_BASIC_DATA_MINING_NET namespace contains namespaces and classes used by this assembly.
	/// </summary>
namespace VISUAL_BASIC_DATA_MINING_NET
{

	
	/// <summary>
	/// This class containing members and methods used to view the results of an analysis of data 
	/// this component.
	/// </summary>
	public class ViewData
	{

		/// <summary>
		/// System.Data.DataSet variable for analyzing the Market Based Analysis data in memory.
		/// </summary>
		DataSet viewData = new DataSet("ViewData");


		/// <summary>
		/// System.Data.DataTable variable for viewing the Rules table data. 
		/// </summary>
		DataTable viewRulesTable = new DataTable("ViewRulesTable");


		/// <summary>
		/// System.Data.DataTable variable for viewing the Subsets table data. 
		/// </summary>
		DataTable viewSubsetTable = new DataTable("ViewSubsetTable");
        
		
		/// <summary>
		/// Creates the ViewSubsetTable and the ViewRulesTable and adds the tables to the Tables collection.
		/// </summary>
		public ViewData()
		{
			this.CreateSubsetTable();

			//Add the Subsets Table to the database
			this.viewData.Tables.Add(this.viewSubsetTable);

			this.CreateViewRulesTable();

			//Add the ViewRules Table to the database
			this.viewData.Tables.Add(this.viewRulesTable);
		}

		
		/// <summary>
		/// Creates the ViewSubsetTable and the ViewRulesTable.
		/// </summary>
		/// <param name="addTablesToDataSet">
		/// A boolean value of true to add the ViewRulesTable and ViewSubsetTable to the
		/// tables collection of the in-memory dataSet or false not to add them.
		/// </param>
		public ViewData(bool addTablesToDataSet)
		{
			if(addTablesToDataSet == true)
			{
				this.CreateSubsetTable();

				//Add the Subsets Table to the database
				this.viewData.Tables.Add(this.viewSubsetTable);

				this.CreateViewRulesTable();

				//Add the ViewRules Table to the database
				this.viewData.Tables.Add(this.viewRulesTable);
			}

			else
			{
				this.CreateSubsetTable();

				this.CreateViewRulesTable();
			}
		}

		
		/// <summary>
		/// Creates a ViewSubsetTable for viewing data in the Subsets table.
		/// </summary>
		/// <returns>
		/// Returns a System.Data.DataTable object.
		/// </returns>
		private DataTable CreateSubsetTable()
		{
			DataColumn [] mySubsetColumnKeys = new DataColumn[1];

			DataColumn mySubsetColumn;


			//Define the first column and primary key column for the subset table
			mySubsetColumnKeys[0] = new DataColumn("FirstKeyID",System.Type.GetType("System.Int32"));
			mySubsetColumnKeys[0].AutoIncrement = false;
			mySubsetColumnKeys[0].Unique = true;

			this.viewSubsetTable.Columns.Add(mySubsetColumnKeys[0]);
			

			//define the second column for the subset table
			mySubsetColumn = new DataColumn("ItemID",System.Type.GetType("System.String"));

			this.viewSubsetTable.Columns.Add(mySubsetColumn);


			//define the third column for the subset table
			mySubsetColumn = new DataColumn("SubsetID",System.Type.GetType("System.String"));

			this.viewSubsetTable.Columns.Add(mySubsetColumn);


			//Set the primary keys for the subset table
			this.viewSubsetTable.PrimaryKey = mySubsetColumnKeys;


			return this.viewSubsetTable;
		}

		
		/// <summary>
		/// Creates a ViewRulesTable for viewing data in the RulesTable.
		/// </summary>
		/// <returns>
		/// A System.Data.DataTable object.
		/// </returns>
		private DataTable CreateViewRulesTable()
		{
			DataColumn [] myRuleColumnKeys = new DataColumn[1];

			DataColumn myRuleColumn;


			//Define the first column and primary key column for the ViewRules table
			myRuleColumnKeys[0] = new DataColumn("UniqueID",System.Type.GetType("System.Int32"));
			myRuleColumnKeys[0].AutoIncrement = false;
			myRuleColumnKeys[0].Unique = true;


			this.viewRulesTable.Columns.Add(myRuleColumnKeys[0]);
			

			//define the second column and the rule column for the ViewRules table
			myRuleColumn = new DataColumn("Analysis",System.Type.GetType("System.String"));

			this.viewRulesTable.Columns.Add(myRuleColumn);


			
			//define the confidence column for the ViewRules table
			myRuleColumn = new DataColumn("Confidence",System.Type.GetType("System.String"));

			this.viewRulesTable.Columns.Add(myRuleColumn);


			//Set the primary keys for the ViewRule table
			this.viewRulesTable.PrimaryKey = myRuleColumnKeys;	


			return this.viewRulesTable;
		}

		
		/// <summary>
		/// Fetches and transforms data in the RulesTable into the ViewRulesTable.
		/// </summary>
		/// <param name="dataset">
		/// A DataSet containing RulesTable and SubsetsTable.
		/// </param>
		/// <returns>
		/// A System.Data.DataTable object.
		/// </returns>
		public DataTable CreateViewRulesTable(Data dataset)
		{
				
			int leftRuleID = 0;

			int rightRuleID = 0;

			DataRow newRow;

			Data.ItemsetTableRow itemLeftRow;

			Data.ItemsetTableRow itemRightRow;

			
			foreach(Data.RulesTableRow ruleRow in dataset.RulesTable.Rows)
			{
				
				newRow = this.viewRulesTable.NewRow();


				newRow["UniqueID"] = ruleRow.FirstKeyID;				

				
				leftRuleID = ruleRow.LeftRule;				

				itemLeftRow = dataset.ItemsetTable.FindByItemID(leftRuleID);

				//newRow["LeftRule"] = itemLeftRow.Itemset;


				rightRuleID = ruleRow.RightRule;

				itemRightRow = dataset.ItemsetTable.FindByItemID(rightRuleID);

				//newRow["RightRule"] = itemRightRow.Itemset;

				newRow["Analysis"] = itemLeftRow.Itemset + "  -->  " + itemRightRow.Itemset;
	
			
				newRow["Confidence%"] = ((ruleRow.Confidence) * (100) + "%");
             
				
				this.viewRulesTable.Rows.Add(newRow);
				
			}

			return this.viewRulesTable;
		}


		/// <summary>
		/// Fetches and transforms data in the RulesTable into the ViewRulesTable.
		/// </summary>
		/// <param name="dataset">
		/// A DataSet containing RulesTable and SubsetsTable.
		/// </param>
		/// <param name="minimumConfidence">
		/// The minimum confidence for each item in the ViewRulesTable.
		/// </param>
		/// <returns>
		/// A System.Data.DataTable object.
		/// </returns>
		/// <remarks>
		/// Creates a ViewRulesTable containing only items that satisfy a minimum confidence.
		/// </remarks>
		public DataTable CreateViewRulesTable(double minimumConfidence, Data dataset)
		{
				
			int leftRuleID = 0;

			int rightRuleID = 0;

			double confidence = 0;

			DataRow newRow;

			Data.ItemsetTableRow itemLeftRow;

			Data.ItemsetTableRow itemRightRow;


			minimumConfidence = (minimumConfidence/100);

			
			foreach(Data.RulesTableRow ruleRow in dataset.RulesTable.Rows)
			{

				confidence = ruleRow.Confidence;


				if( confidence >= minimumConfidence )
				{
				
					newRow = this.viewRulesTable.NewRow();


					newRow["UniqueID"] = ruleRow.FirstKeyID;
				
					leftRuleID = ruleRow.LeftRule;				

					itemLeftRow = dataset.ItemsetTable.FindByItemID(leftRuleID);
					
					rightRuleID = ruleRow.RightRule;

					itemRightRow = dataset.ItemsetTable.FindByItemID(rightRuleID);

					newRow["Analysis"] = itemLeftRow.Itemset + "  -->  " + itemRightRow.Itemset;
	
			
					//newRow["Confidence"] = ((ruleRow.Confidence) * (100) + "%");
                    newRow["Confidence"] = ((Math.Round(ruleRow.Confidence,4)) * (100));
				
					this.viewRulesTable.Rows.Add(newRow);

				}
				
			}

			return this.viewRulesTable;
		}

		
		/// <summary>
		/// Fetches and transforms data in the SubsetsTable into the ViewSubsetsTable.
		/// </summary>
		/// <param name="dataset">
		/// A DataSet containing RulesTable and SubsetsTable.
		/// </param>
		/// <returns>
		/// A System.Data.DataTable object.
		/// </returns>
		public DataTable CreateViewSubsetTable(Data dataset)
		{

			int itemID = 0;

			int subsetID = 0;

			DataRow newRow;

			Data.ItemsetTableRow itemsetItemID;

			Data.ItemsetTableRow itemsetSubsetID;

			
			foreach(Data.SubsetTableRow subsetRow in dataset.SubsetTable.Rows)
			{

				newRow = this.viewSubsetTable.NewRow();
				

				newRow["FirstKeyID"] = subsetRow.FirstKeyID;				
				
				
				itemID = subsetRow.ItemID;				

				itemsetItemID = dataset.ItemsetTable.FindByItemID(itemID);

				newRow["ItemID"] = itemsetItemID.Itemset;


				subsetID = subsetRow.SubsetID;

				itemsetSubsetID = dataset.ItemsetTable.FindByItemID(subsetID);

				newRow["SubsetID"] = itemsetSubsetID.Itemset;
	
			
				this.viewSubsetTable.Rows.Add(newRow);
				
			}

			return this.viewSubsetTable;
		}

		
		/// <summary>
		/// The in-memory dataset object containing ViewRulesTable and ViewSubsetsTable.
		/// </summary>
		/// <value>
		/// A System.Data.DataTable object containing ViewRulesTable and ViewSubsetsTable.
		/// </value>
		public DataSet ViewDataSet
		{
			get
			{
				return this.viewData;
			}
		}
		
		
	}

}
