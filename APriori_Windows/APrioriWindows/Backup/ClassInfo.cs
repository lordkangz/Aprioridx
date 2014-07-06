using System;

namespace APrioriWindows
{

	public class ClassInfo
	{
		public ClassInfo()
		{
		}
		
		public enum DataStorageLocation
		{
			Database = 1,
			XMLFile = 2
		}


		public enum DataModel
		{
			TransactionsTable = 1,
			NorthwindDatabase = 2
		}
		
		private static string connectionString;

		private static string xmlFilePath;

		private static string appCaption = "C#.NET Market Based Data Mining";

		private static DataStorageLocation dataStorage;

		private static DataModel dataModel;

		/// <summary>
		/// The minimum confidence required for the market based data mining rules created.
		/// See <see cref="VISUAL_BASIC_DATA_MINING_NET.DataMining.MarketBasedAnalysis"/>
		/// </summary>
		private static double minimumConfidence;
		
		/// <summary>
		/// Stores the minimum support count required for every frequent set of items.
		/// </summary>
		private static double minimumSupport;


		public static string AppCaption
		{
			get
			{
				return appCaption;
			}
		}

		public static string ConnectionString
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

		public static string XMLFilePath
		{
			get
			{
				return xmlFilePath;
			}
			
			set
			{
				xmlFilePath = value;
			}
		}

		public static DataStorageLocation DataStorage
		{
			get
			{
				return dataStorage;
			}

			set
			{
				dataStorage = value;
			}
		}

		public static DataModel DataStorageModel
		{
			get
			{
				return dataModel;
			}

			set
			{
				dataModel = value;
			}
		}

		public static double MinimumSupport
		{
			get
			{
				return minimumSupport;
			}

			set
			{
				minimumSupport = value;
			}
		}

		public static double MinimumConfidence
		{
			get
			{
				return minimumConfidence;
			}

			set
			{
				minimumConfidence = value;
			}
		}


	}
}
