using System;
using System.Data;
using System.Data.OleDb;


	/// <summary>
	/// The VISUAL_BASIC_DATA_MINING_NET namespace contains namespaces and classes used by this assembly.
	/// </summary>
namespace VISUAL_BASIC_DATA_MINING_NET
{


	/// <summary>
	/// Summary description for DatabaseUpdate.
	/// </summary>
	public class DatabaseUpdate
	{
		public DatabaseUpdate()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}


	public abstract class OleDbDataUpdate
	{

		public OleDbDataUpdate()
		{
		}

		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand;
		protected System.Data.OleDb.OleDbCommand oleDbInsertCommand;
		protected System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
		protected System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
		protected System.Data.OleDb.OleDbConnection oleDbConnection;
		protected System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter;
				
		public virtual void InitializeDatabaseClass()
		{
			this.oleDbSelectCommand = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection = new System.Data.OleDb.OleDbConnection();
			this.oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter();
		}
		
		public abstract OleDbCommand CreateDeleteCommand();

		public abstract OleDbCommand CreateInsertCommand();

		public abstract OleDbCommand CreateSelectCommand();

		public abstract OleDbCommand CreateUpdateCommand();		

		public abstract OleDbDataAdapter CreateDataAdapter();


		public virtual void oleDbConnection_InfoMessage(object sender, System.Data.OleDb.																							OleDbInfoMessageEventArgs e)
		{			
		}

		public virtual void oleDbDataAdapter_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
		{
		
		}


		public virtual OleDbConnection CreateConnection(string connectionString)
		{
			this.oleDbConnection.ConnectionString = connectionString;

			this.oleDbConnection.InfoMessage += new System.Data.OleDb.OleDbInfoMessageEventHandler(this.																				oleDbConnection_InfoMessage);

			return this.oleDbConnection;
		}


		public virtual OleDbDataAdapter DataAdapter
		{
			get
			{
				return this.oleDbDataAdapter;
			}
		}

	}


	


	public class SubsetsTable : OleDbDataUpdate
	{
		
		public SubsetsTable(string connectionString)
		{
			this.InitializeDatabaseClass();

			this.CreateConnection(connectionString);
			
			this.CreateDeleteCommand();

			this.CreateInsertCommand();

			this.CreateSelectCommand();

			this.CreateUpdateCommand();		

			this.CreateDataAdapter();
		}


		public override OleDbCommand CreateDeleteCommand()
		{
			this.oleDbDeleteCommand.CommandText = "DELETE FROM SubsetsTable WHERE (FirstKeyID = ?) AND (ItemID = ?) AND					(SubsetID = " +
				"?)";
			this.oleDbDeleteCommand.Connection = this.oleDbConnection;
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FirstKeyID", System.Data				.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.				Byte)(0)), "FirstKeyID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.					OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.					Byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SubsetID", System.Data.				OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.					Byte)(0)), "SubsetID", System.Data.DataRowVersion.Original, null));

			return this.oleDbDeleteCommand;
		}


		public override OleDbCommand CreateInsertCommand()
		{
			this.oleDbInsertCommand.CommandText = "INSERT INTO SubsetsTable(FirstKeyID, ItemID, SubsetID) VALUES (?, ?, ?)				";
			this.oleDbInsertCommand.Connection = this.oleDbConnection;
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("FirstKeyID", System.Data.OleDb.				OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0))				, "FirstKeyID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.					OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0))				, "ItemID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("SubsetID", System.Data.OleDb.					OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0))				, "SubsetID", System.Data.DataRowVersion.Current, null));

			return this.oleDbInsertCommand;
		}

		public override OleDbCommand CreateSelectCommand()
		{
			this.oleDbSelectCommand.CommandText = "SELECT FirstKeyID, ItemID, SubsetID FROM SubsetsTable";
			this.oleDbSelectCommand.Connection = this.oleDbConnection;

			return this.oleDbSelectCommand;
		}

		public override OleDbCommand CreateUpdateCommand()
		{
			this.oleDbUpdateCommand.CommandText = "UPDATE SubsetsTable SET FirstKeyID = ?, ItemID = ?,									SubsetID = ? WHERE (FirstKeyI" + "D = ?) AND (ItemID = ?) AND (SubsetID = ?)";
			this.oleDbUpdateCommand.Connection = this.oleDbConnection;
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("FirstKeyID", System.Data.OleDb.				OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0))				, "FirstKeyID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.					OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0))				, "ItemID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("SubsetID", System.Data.OleDb.					OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0))				, "SubsetID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FirstKeyID", System.Data				.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.				Byte)(0)), "FirstKeyID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.					OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.					Byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SubsetID", System.Data.				OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.					Byte)(0)), "SubsetID", System.Data.DataRowVersion.Original, null));

			return this.oleDbUpdateCommand;
		}


		public override OleDbDataAdapter CreateDataAdapter()
		{
			this.oleDbDataAdapter.DeleteCommand = this.oleDbDeleteCommand;
			this.oleDbDataAdapter.InsertCommand = this.oleDbInsertCommand;
			this.oleDbDataAdapter.SelectCommand = this.oleDbSelectCommand;
			this.oleDbDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
				new System.Data.Common.DataTableMapping("SubsetsTable", "SubsetsTable", new System.Data.Common.																		DataColumnMapping	[] {
																																		new System.Data.Common.DataColumnMapping("FirstKeyID", "FirstKeyID"),
																																		new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
																																		new System.Data.Common.DataColumnMapping("SubsetID", "SubsetID")})});

			this.oleDbDataAdapter.UpdateCommand = this.oleDbUpdateCommand;

			this.oleDbDataAdapter.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.									oleDbDataAdapter_RowUpdated);

			return this.oleDbDataAdapter;
		}

	}
	
	



	public class ItemsetsTable : OleDbDataUpdate
	{
		
		public ItemsetsTable(string connectionString)
		{
			this.InitializeDatabaseClass();

			this.CreateConnection(connectionString);
			
			this.CreateDeleteCommand();

			this.CreateInsertCommand();

			this.CreateSelectCommand();

			this.CreateUpdateCommand();		

			this.CreateDataAdapter();
		}


		public override OleDbCommand CreateDeleteCommand()
		{
			this.oleDbDeleteCommand.CommandText = "DELETE FROM ItemsetsTable WHERE (ItemID = ?) AND (Itemset = ? OR ? IS NULL AND It"				+ "emset IS NULL)";
			this.oleDbDeleteCommand.Connection = this.oleDbConnection;
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.						OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "ItemID",				System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Itemset", System.Data.OleDb.						OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Itemset"				, System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Itemset", System.Data.OleDb.						OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Itemset"				, System.Data.DataRowVersion.Original, null));

			return this.oleDbDeleteCommand;
		}


		public override OleDbCommand CreateInsertCommand()
		{
			this.oleDbInsertCommand.CommandText = "INSERT INTO ItemsetsTable(ItemID, Itemset, Level, SupportCount) VALUES (?, ?, ?, "				+ "?)";
			this.oleDbInsertCommand.Connection = this.oleDbConnection;
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer				, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "ItemID", System.Data.					DataRowVersion.Current, null));
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Itemset", System.Data.OleDb.OleDbType.						VarWChar, 0, "Itemset"));
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level", System.Data.OleDb.OleDbType.Integer,				0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "Level", System.Data.						DataRowVersion.Current, null));
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("SupportCount", System.Data.OleDb.OleDbType.				Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "SupportCount",					System.Data.DataRowVersion.Current, null));

			return this.oleDbInsertCommand;
		}

		public override OleDbCommand CreateSelectCommand()
		{
			this.oleDbSelectCommand.CommandText = "SELECT ItemID, Itemset, Level, SupportCount FROM ItemsetsTable";
			this.oleDbSelectCommand.Connection = this.oleDbConnection;

			return this.oleDbSelectCommand;
		}

		public override OleDbCommand CreateUpdateCommand()
		{
			this.oleDbUpdateCommand.CommandText = "UPDATE ItemsetsTable SET ItemID = ?, Itemset = ?, Level = ?, SupportCount = ? WHE"				+ "RE (ItemID = ?) AND (Itemset = ? OR ? IS NULL AND Itemset IS NULL)";
			this.oleDbUpdateCommand.Connection = this.oleDbConnection;
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer				, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "ItemID", System.Data.					DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Itemset", System.Data.OleDb.OleDbType.						VarWChar, 0, "Itemset"));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Level", System.Data.OleDb.OleDbType.Integer,				0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "Level", System.Data.						DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("SupportCount", System.Data.OleDb.OleDbType.				Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "SupportCount",					System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.						OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "ItemID",				System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Itemset", System.Data.OleDb.						OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Itemset"				, System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Itemset", System.Data.OleDb.						OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Itemset"				, System.Data.DataRowVersion.Original, null));

			return this.oleDbUpdateCommand;
		}


		public override OleDbDataAdapter CreateDataAdapter()
		{
			this.oleDbDataAdapter.DeleteCommand = this.oleDbDeleteCommand;
			this.oleDbDataAdapter.InsertCommand = this.oleDbInsertCommand;
			this.oleDbDataAdapter.SelectCommand = this.oleDbSelectCommand;
			this.oleDbDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] 
					{
				
				new System.Data.Common.DataTableMapping("ItemsetsTable", "ItemsetsTable", new System.Data.Common.DataColumnMapping[]					{
																																					new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
																																					new System.Data.Common.DataColumnMapping("Itemset", "Itemset"),
																																					new System.Data.Common.DataColumnMapping("Level", "Level"),
																																					new System.Data.Common.DataColumnMapping("SupportCount", "SupportCount")})});

			this.oleDbDataAdapter.UpdateCommand = this.oleDbUpdateCommand;

			this.oleDbDataAdapter.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.oleDbDataAdapter_RowUpdated);

			return this.oleDbDataAdapter;
		}

	}
	
	



	public class RulesTable : OleDbDataUpdate
	{
		
		public RulesTable(string connectionString)
		{
			this.InitializeDatabaseClass();

			this.CreateConnection(connectionString);
			
			this.CreateDeleteCommand();

			this.CreateInsertCommand();

			this.CreateSelectCommand();

			this.CreateUpdateCommand();		

			this.CreateDataAdapter();
		}


		public override OleDbCommand CreateDeleteCommand()
		{
			this.oleDbDeleteCommand.CommandText = "DELETE FROM RulesTable WHERE (FirstKeyID = ?) AND (Confidence = ? OR ? IS NULL AN				" + "D Confidence IS NULL)";
			this.oleDbDeleteCommand.Connection = this.oleDbConnection;
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FirstKeyID", System.Data.OleDb.					OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)),							"FirstKeyID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Confidence", System.Data.OleDb.					OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)),							"Confidence", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Confidence1", System.Data.OleDb.					OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)),							"Confidence", System.Data.DataRowVersion.Original, null));	

			return this.oleDbDeleteCommand;
		}


		public override OleDbCommand CreateInsertCommand()
		{
			this.oleDbInsertCommand.CommandText = "INSERT INTO RulesTable(Confidence, FirstKeyID, LeftRule, RightRule) VALUES (?, ?,				" + " ?, ?)";
			this.oleDbInsertCommand.Connection = this.oleDbConnection;
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Confidence", System.Data.OleDb.OleDbType.					Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "Confidence",						System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("FirstKeyID", System.Data.OleDb.OleDbType.					Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "FirstKeyID",						System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("LeftRule", System.Data.OleDb.OleDbType.					Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "LeftRule", System				.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("RightRule", System.Data.OleDb.OleDbType.					Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "RightRule",						System.Data.DataRowVersion.Current, null));

			return this.oleDbInsertCommand;
		}

		public override OleDbCommand CreateSelectCommand()
		{
			this.oleDbSelectCommand.CommandText = "SELECT Confidence, FirstKeyID, LeftRule, RightRule FROM RulesTable";

			this.oleDbSelectCommand.Connection = this.oleDbConnection;

			return this.oleDbSelectCommand;
		}

		public override OleDbCommand CreateUpdateCommand()
		{
			this.oleDbUpdateCommand.CommandText = "UPDATE RulesTable SET Confidence = ?, FirstKeyID = ?, LeftRule = ?, RightRule = ?				" + " WHERE (FirstKeyID = ?) AND (Confidence = ? OR ? IS NULL AND Confidence IS NULL)" +
				"";
			this.oleDbUpdateCommand.Connection = this.oleDbConnection;
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Confidence", System.Data.OleDb.OleDbType.					Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "Confidence",						System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("FirstKeyID", System.Data.OleDb.OleDbType.					Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "FirstKeyID",						System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("LeftRule", System.Data.OleDb.OleDbType.					Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "LeftRule", System				.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("RightRule", System.Data.OleDb.OleDbType.					Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "RightRule",						System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FirstKeyID", System.Data.OleDb.					OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)),							"FirstKeyID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Confidence", System.Data.OleDb.					OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)),							"Confidence", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Confidence1", System.Data.OleDb.					OleDbType.Double, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)),							"Confidence", System.Data.DataRowVersion.Original, null));

			return this.oleDbUpdateCommand;
		}


		public override OleDbDataAdapter CreateDataAdapter()
		{
			
			this.oleDbDataAdapter.DeleteCommand = this.oleDbDeleteCommand;
			this.oleDbDataAdapter.InsertCommand = this.oleDbInsertCommand;
			this.oleDbDataAdapter.SelectCommand = this.oleDbSelectCommand;
			this.oleDbDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] 
				{
																									  
					new System.Data.Common.DataTableMapping("RulesTable", "RulesTable", new System.Data.Common.DataColumnMapping[] {
																																						new System.Data.Common.DataColumnMapping("FirstKeyID", "FirstKeyID"),
																																						new System.Data.Common.DataColumnMapping("LeftRule", "LeftRule"),
																																						new System.Data.Common.DataColumnMapping("RightRule", "RightRule"),
																																						new System.Data.Common.DataColumnMapping("Confidence", "Confidence")})});

				this.oleDbDataAdapter.UpdateCommand = this.oleDbUpdateCommand;

				this.oleDbDataAdapter.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.												oleDbDataAdapter_RowUpdated);

			return this.oleDbDataAdapter;
		}

	}
	
	



	public class TransactionsTable : OleDbDataUpdate
	{
		
		public TransactionsTable(string connectionString)
		{
			this.InitializeDatabaseClass();

			this.CreateConnection(connectionString);
			
			this.CreateDeleteCommand();

			this.CreateInsertCommand();

			this.CreateSelectCommand();

			this.CreateUpdateCommand();		

			this.CreateDataAdapter();
		}
		

		public override OleDbCommand CreateDeleteCommand()
		{
			this.oleDbDeleteCommand.CommandText = "DELETE FROM TransactionsTable WHERE (TransactionID = ?) AND (Transactions = ? OR " +
				"? IS NULL AND Transactions IS NULL)";
			this.oleDbDeleteCommand.Connection = this.oleDbConnection;
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TransactionID", System.Data.OleDb.						OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)),									"TransactionID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Transactions", System.Data.OleDb.							OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Transactions					", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Transactions1", System.Data.OleDb.						OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Transactions					", System.Data.DataRowVersion.Original, null));

			return this.oleDbDeleteCommand;
		}

		public override OleDbCommand CreateInsertCommand()
		{
			this.oleDbInsertCommand.CommandText = "INSERT INTO TransactionsTable(TransactionID, Transactions) VALUES (?, ?)";
			this.oleDbInsertCommand.Connection = this.oleDbConnection;
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("TransactionID", System.Data.OleDb.OleDbType.						Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "TransactionID", System					.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Transactions", System.Data.OleDb.OleDbType.						VarWChar, 0, "Transactions"));

			return this.oleDbInsertCommand;
		}

		public override OleDbCommand CreateSelectCommand()
		{
			this.oleDbSelectCommand.CommandText = "SELECT TransactionID, Transactions FROM TransactionsTable";

			this.oleDbSelectCommand.Connection = this.oleDbConnection;

			return this.oleDbSelectCommand;
		}

		public override OleDbCommand CreateUpdateCommand()
		{
			this.oleDbUpdateCommand.CommandText = "UPDATE TransactionsTable SET TransactionID = ?, Transactions = ? WHERE (Transacti" +
				"onID = ?) AND (Transactions = ? OR ? IS NULL AND Transactions IS NULL)";
			this.oleDbUpdateCommand.Connection = this.oleDbConnection;
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("TransactionID", System.Data.OleDb.OleDbType.						Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "TransactionID", System					.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Transactions", System.Data.OleDb.OleDbType.						VarWChar, 0, "Transactions"));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TransactionID", System.Data.OleDb.						OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)),									"TransactionID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Transactions", System.Data.OleDb.							OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Transactions					", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Transactions1", System.Data.OleDb.						OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Transactions					", System.Data.DataRowVersion.Original, null));

			return this.oleDbUpdateCommand;
		}


		public override OleDbDataAdapter CreateDataAdapter()
		{
			this.oleDbDataAdapter.DeleteCommand = this.oleDbDeleteCommand;
			this.oleDbDataAdapter.InsertCommand = this.oleDbInsertCommand;
			this.oleDbDataAdapter.SelectCommand = this.oleDbSelectCommand;
			this.oleDbDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] 
			{
				new System.Data.Common.DataTableMapping("TransactionsTable", "TransactionsTable", 
						
				new System.Data.Common.DataColumnMapping[] {
						
				new System.Data.Common.DataColumnMapping("TransactionID", "TransactionID"),
				
				new System.Data.Common.DataColumnMapping("Transactions", "Transactions")})}
			);

			this.oleDbDataAdapter.UpdateCommand = this.oleDbUpdateCommand;

			this.oleDbDataAdapter.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.oleDbDataAdapter_RowUpdated);
								
			return this.oleDbDataAdapter;
		}

	}

}
