using System;
using System.Data;
using System.Text;
using System.Collections;
using VISUAL_BASIC_DATA_MINING_NET;
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
		/// Apriori class implements the APriori algorithm for market based analysis.
		/// </summary>
		/// <remarks>
		/// This class implements the APriori algorithm and creates association between items in a transaction. 
		/// </remarks>
		/// <example >
		/// using APriori;
		/// 
		/// Apriori shoppingCart = new Apriori(); 
		/// </example>
		/// <include file='APrioriExamples.xml' path='Documentation/SourceCode[@name="Copyright"]/*' />
		/// <include file='APrioriExamples.xml' path='Documentation/SourceCode[@name="StartingSampleA"]/*' />
		public class Apriori
		{

		
			/// <summary>
			/// An ItemsetArrayList variable that stores a collection of frequent itemsets.
			/// </summary>
			protected ItemsetArrayList itemsetsFrequentCollection;
		
			/// <summary>
			/// An ItemsetArrayList variable that stores a collection of candidate itemsets.
			/// </summary>
			protected ItemsetArrayList itemsetsCandidateCollection;		
		
		
			/// <summary>
			/// The default parameterless constructor for the Apriori class.
			/// </summary>
			public Apriori()
			{
				this.itemsetsCandidateCollection = new ItemsetArrayList();
				this.itemsetsFrequentCollection = new ItemsetArrayList();
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
			/// A custom event that notifies clients about the progress of the executing code.
			/// </summary>
			public event ProgressMonitorEventHandler ProgressMonitorEvent;

		
			/// <summary>
			/// Finds a collection of DataRows matching a filter expression.
			/// </summary>
			/// <param name="find">
			/// The expression used to filter the DataRows in a table.
			/// </param>
			/// <param name="data">
			/// A DataTable object containing the data to be filtered.
			/// </param>
			/// <returns>
			/// Returns a collection of DataRow objects.
			/// </returns>
			protected DataRow [] FindItems(string find, DataTable data)
			{
				return data.Select(find);
			}
		
		
			/// <summary>
			/// Counts the number of times a string is found in another string.
			/// </summary>
			/// <param name="find">
			/// The string to find.
			/// </param>
			/// <param name="data">
			/// The string to search.
			/// </param>
			/// <returns>
			/// Returns an integer count of the number of times a string is found in another string.
			/// </returns>
			protected int FindItems(string find, string data)
			{			
				string [] splitstring = data.Split(new Char[] {','});

				int length = splitstring.Length;

				int countFound = 0;

				string [] found = new string[length]; 

			
				for(int counter = 0; counter < length; counter++)
				{
					found[counter] = splitstring[counter].Trim();
				}
			

				foreach (string member in found)
				{
					if (member == find)
					{
						countFound++;
					}
				}

				return countFound;
			}

		
			/// <summary>
			/// Counts the number of times a string is found in another string.
			/// </summary>
			/// <param name="find">
			/// The string to find.
			/// </param>
			/// <param name="data">
			/// The string to search.
			/// </param>
			/// <returns>
			/// An ItemsetArrayList object.
			/// </returns>
			protected int FindItems(ItemsetArrayList find, string data)
			{
				string [] splitstring = data.Split(new Char[] {','});

				int length = find.Count;

				string [] found = new string[splitstring.Length]; 
			
				int minimumValue = 0;

				int [] search = new int[length];

		
				for(int counter =0; counter < splitstring.Length; counter++)
				{
					found[counter] = splitstring[counter].Trim();
				}
			
			
				for(int count = 0; count < length; count++)
				{				
					foreach (string member in found)
					{
						if (member == (string)find[count])
						{
							search[count]++;
						}
					}
				}


				switch(length)
				{
					case 0:
					{
						minimumValue = 0;

						break;
					}

					case 1:
					{
						minimumValue = search[0];

						break;
					}

					default:
					{
						for(int counter = 0; counter < search.Length; counter++)
						{
							if(counter == 0)
							{
								minimumValue = search[counter];
							}
							else
							{
								if (search[counter] < minimumValue)
								{
									minimumValue = search[counter];
								}
							}

						}

						break;
					}
				}

				return minimumValue;
			}
		
		
			/// <summary>
			/// Retrieves the support count of an item in the transactions database.
			/// </summary>
			/// <param name="find">
			/// An item to retrieve the support count for.
			/// </param>
			/// <param name="Transactions_Data">
			/// The database of transactions to be analyzed using the APriori Algorithm.
			/// </param>
			/// <returns>
			/// Returns an integer value representing the support count for the item. 
			/// </returns>
			public int SupportCount(string find, Database Transactions_Data)
			{
				int count = 0;
			
			
				DataTable datatable = Transactions_Data.Transactions.Tables[0];
			
	
				foreach(DataRow datarow in datatable.Rows)
				{		
					count = count + FindItems(find, (datarow["Transactions"]).ToString());				
				}			

				return count;
			}
		
		
			/// <summary>
			/// Gets the support count of an item.
			/// </summary>
			/// <param name="find">
			/// The item to find the support count for.
			/// </param>
			/// <param name="transactionsData">
			/// The database of transactions to analyze for associations.
			/// </param>
			/// <returns>
			/// Returns the support count of an item as an integer. 
			/// </returns>
			public int SupportCount(ItemsetArrayList find, Database transactionsData)
			{
				int count = 0;	
		
				int total = 0;

			
				DataTable dataTable = transactionsData.Transactions.Tables["TransactionTable"];
			
	
				foreach(DataRow datarow in dataTable.Rows)
				{
					count = this.FindItems(find, (datarow["Transactions"]).ToString());		
		
					total = count + total;
				}			

				return total;
			}
				
		
			/// <summary>
			/// Creates a collection of unique items from a database of transactions.
			/// </summary>
			/// <param name="dataBase">
			/// The ADO.NET in-memory database to search for unique items.
			/// </param>
			[ReservedAttribute(false,"December 25, 2002")]
			public ItemsetCandidate CreateOneItemsets(Database dataBase)
			{
				DataTable dataTable = dataBase.Transactions.Tables["TransactionTable"];

				ItemsetCandidate candidateItemset = new ItemsetCandidate();
 
				ItemsetArrayList uniqueItems = new ItemsetArrayList(1);;

				ItemsetArrayList candidateItems;

				ItemsetArrayList items;

				StringBuilder item = new StringBuilder(10);

				int itemSupportCount = 0;

				int counter = 1;


				string msg = "Creating One Itemsets";
			
				ProgressMonitorEventArgs e = new ProgressMonitorEventArgs(1,100,80,"Apriori.CreateOneItemsets(Database)",msg );

				this.OnProgressMonitorEvent(e);


				foreach (DataRow dataRow in dataTable.Rows)
				{	
					item.Append(dataRow["Transactions"].ToString());

					if(counter < (dataTable.Rows.Count))
					{
						item.Append(", ");

						counter++;
					}
				}


				candidateItems = ItemsetArrayList.ConvertToItemsetArrayList(item.ToString(), new Char[] {','});


				for(int count = 0; count < candidateItems.Count; count++)
				{
					item = new StringBuilder(10);

					item.Append(((string) candidateItems[count]).Trim());

					if(!(item.ToString() == "")) 
					{
						if(!uniqueItems.Contains(item.ToString()))
						{
							itemSupportCount = this.SupportCount(item.ToString(),dataBase);

							dataBase.AddItemset(item.ToString(),1,itemSupportCount);

							items = new ItemsetArrayList(1);

							uniqueItems.Add(item.ToString());

							items.Add(item.ToString());

							items.Level = 1;

							items.SupportCount = itemSupportCount;

							items.TrimToSize();

							candidateItemset.Items.Add(items);
						}
					}
				}

			
				candidateItemset.Items.TrimToSize();

				candidateItemset.Level = 1;

				return candidateItemset;

			}


			/// <summary>
			/// Generates both frequent and candidate itemsets and adds them to their collections.
			/// </summary>
			/// <param name="Candidate_Itemset">
			/// The candidate itemset to join.
			/// </param>
			/// <param name="TransactionsData">
			/// The database of transactions data to be analyzed.
			/// </param>
			/// <param name="minimum_support">
			/// The minimum support for the candidate itemsets in the transaction database.
			/// </param>
			public void AprioriGenerator(ItemsetCandidate Candidate_Itemset, Database TransactionsData, int	minimum_support)
			{
			
				string start = "Generating Level " + Candidate_Itemset.Level + " Candidates : " +  Candidate_Itemset.Items.					Count + " Items";
			
				ProgressMonitorEventArgs e = new ProgressMonitorEventArgs(1,100,25,"Apriori.AprioriGenerator()",start );

				this.OnProgressMonitorEvent(e);			


				//add a candidate itemset to the candidate itemsets collection
				ItemsetCandidate candidateItemset = this.JoinCandidateItemsets(Candidate_Itemset, TransactionsData,																							minimum_support);

				if(candidateItemset.Items.Count > 0)
				{			
					//find the frequent itemsets for this candidate itemset
					//ItemsetCandidate frequentItemset = this.GenerateFrequentItemsets(candidateItemset, minimum_support);	

					this.AprioriGenerator(candidateItemset, TransactionsData, minimum_support);
				}
			

			
				string done = "Finished Generating Candidate Itemsets ";
			
				e = new ProgressMonitorEventArgs(1,100,70,"Apriori.AprioriGenerator()",done );

				this.OnProgressMonitorEvent(e);
			
			}
		

			/// <summary>
			/// Generates frequent itemsets. 
			/// </summary>
			/// <param name="candidateItemset">
			/// The candidate itemset to generate frequent itemsets from.
			/// </param>
			/// <param name="minimum_support">
			/// The minimum support count needed for frequent itemsets.
			/// </param>
			/// <returns>
			/// Returns a frequent itemset.
			/// </returns>
			protected ItemsetCandidate GenerateFrequentItemsets(ItemsetCandidate candidateItemset, int minimum_support)
			{

				ItemsetCandidate itemsetFrequent = new ItemsetCandidate();

			
				foreach(ItemsetArrayList itemsFrequent in candidateItemset.Items)
				{
					if (itemsFrequent.SupportCount >= minimum_support)
					{

						itemsetFrequent.Items.Add(itemsFrequent);
					}
				}

				itemsetFrequent.Items.Capacity = itemsetFrequent.Items.Count;

				return itemsetFrequent;	
		
			}
		
		
			/// <summary>
			/// Checks if an item has a frequent subset.
			/// </summary>
			[ReservedAttribute(true,"December 25, 2002")]
			protected bool HasInfrequentSubSet()
			{
				throw new Exception("This is a reserved attribute! Do not use it");
			}	

		
			/// <summary>
			/// Collection of Frequent Itemsets.
			/// </summary>
			[ObsoleteAttribute("Retrieve the collection from the database",false)]
			[ReservedAttribute(true,"December 25, 2002")]
			public ItemsetArrayList ItemsetsFrequentCollection
			{
				get
				{
					return itemsetsFrequentCollection;
				}

				set
				{
					itemsetsFrequentCollection.Add(value);
				}
			}
			
		
			/// <summary>
			/// Collection of Candidate Itemsets.
			/// </summary>
			[ObsoleteAttribute("Retrieve the collection from the database",false)]
			[ReservedAttribute(true,"December 25, 2002")]
			public ItemsetArrayList ItemsetsCandidateCollection
			{
				get
				{
					return itemsetsCandidateCollection;
				}

				set
				{
					itemsetsCandidateCollection.Add(value);
				}
			}
		

			/// <summary>
			/// Creates an Itemset by joining a candidate itemset to itself.
			/// </summary>
			/// <param name="candidate_itemset">
			///  A candidate itemset to join.
			/// </param>
			/// <param name="minimumSupport">
			/// The minimum number transactions that must contain a set of items in the database.
			/// </param>
			/// <param name="transactionsData">
			/// The database of transactions data to be analyzed.
			/// </param>
			/// <returns>
			/// A candidate itemset object.
			/// </returns>
			public ItemsetCandidate JoinCandidateItemsets(ItemsetCandidate candidate_itemset, Database transactionsData, int																minimumSupport)
			{
			
				//Exit this function if the number of items is zero
				if (candidate_itemset.Items.Count == 0)
				{
					throw new Exception("cannot join items : no items are present!");
				}

				else
				{
					ItemsetArrayList copy_candidate_itemset = candidate_itemset.Items;

					ItemsetCandidate new_candidate_itemset = new ItemsetCandidate();

			
					new_candidate_itemset.Level = candidate_itemset.Level + 1;

				
					//members of an itemset of k items are joinable if their first (k-2) members are joinable
					int count_common_items = (new_candidate_itemset.Level - 2);
			

					foreach (ItemsetArrayList itemset in candidate_itemset.Items)
					{				
						int count_members = 0;
				
						foreach(ItemsetArrayList copy_itemset in copy_candidate_itemset)
						{
							bool join_items = true;

							for(count_members = 0; count_members < count_common_items; count_members++)
							{
								if(itemset[count_members] != copy_itemset[count_members])
								{
									join_items = false;

									break;
								}
							}

						
							//OLD VALUE :
							//if (itemset[count_common_items].ToString().CompareTo(copy_itemset[count_common_items])!= -1) 
							//January 4, 2002, 4:15 pm
							if (itemset[count_common_items].ToString().CompareTo(copy_itemset[count_common_items].ToString())!= -1) 
							{
								join_items = false;
							}
					

							if (join_items == true)
							{
								ItemsetArrayList new_itemset = new ItemsetArrayList(1);
			
								for(count_members = 0; count_members <= count_common_items; count_members++)
								{							
									if(itemset[count_members] == copy_itemset[count_members])
									{
										new_itemset.Add(itemset[count_members]);
									}
									else
									{
										new_itemset.Add(itemset[count_members]);

										new_itemset.Add(copy_itemset[count_members]);
									}

								}

								new_itemset.Capacity = new_itemset.Count;

							
								//get the support count for each item set
								new_itemset.SupportCount = this.SupportCount(new_itemset,transactionsData);

								new_itemset.Level = new_candidate_itemset.Level;

								itemset.Capacity = itemset.Count;
				

								//Add the itemset to the itemset table
								transactionsData.AddItemset(new_itemset,",");

								//Do not add itemsets that do not have a minimum support count
								if(new_itemset.SupportCount >= minimumSupport)
								{
									new_candidate_itemset.Items.Add(new_itemset);
								}

							}
						}
					}

					new_candidate_itemset.Items.Capacity = new_candidate_itemset.Items.Count;
			
					return new_candidate_itemset;

				}

			}
		
		
			/// <summary>
			/// Creates market based analysis association rules between a pair of items.
			/// </summary>
			/// <param name="parentRuleset">
			/// The parent set of frequent items.
			/// </param>
			/// <param name="leftRuleset">
			/// The set of items on the left side of a market based analysis association rule.
			/// </param>
			/// <param name="rightRuleset">
			/// The set of items on the right side of a market based analysis association rule
			/// </param>
			/// <param name="transactionsData">
			/// The database data access component containing transactions to be analyzed.
			/// </param>
			public void CreateItemsetRuleset(ItemsetArrayList parentRuleset, ItemsetArrayList leftRuleset, ItemsetArrayList												rightRuleset, Database transactionsData)
			{						
				//Create and add an association rule to the database
				transactionsData.AddRuleset(parentRuleset, leftRuleset, rightRuleset);			
			}
		
		
			/// <summary>
			/// Recursively creates all the subsets belonging to an itemset and saves them to the database.
			/// </summary>
			/// <param name="Level">
			/// The minimum number of elements for an itemset. 
			/// </param>
			/// <param name="itemSubset">
			/// An ItemsetArrayList collection of items.
			/// </param>
			/// <param name="parentItemset">
			/// The parent itemset used to generate subsets and create market based analysis association rules.
			/// </param>
			/// <param name="transactionsData">
			/// The database of transactions data.
			/// </param>
			public void CreateItemsetSubsets(int Level, ItemsetArrayList itemSubset, ItemsetArrayList parentItemset,													Database transactionsData)
			{			
				int length = 0;

				ItemsetArrayList childSubset = new ItemsetArrayList(1);	
		
				ItemsetArrayList rulesItemset;

			
				if(itemSubset.Count > Level)
				{
					foreach(ItemsetArrayList item in itemSubset)
					{
						ItemsetArrayList [] subsets = this.CreateItemsetSubsets(item);

					
						//Only one parentItemset will be used to generate association rules 
						if(parentItemset == null)
						{
							parentItemset = item;						
						}


						if (subsets != null)
						{
							length = subsets.Length;
						}

						else
						{
							break;
						}

						for(int count = 0; count < length; count++)
						{
							//Add the itemset and the subset to the subsets table
							transactionsData.AddSubset(item,subsets[count]);

							childSubset.Add(subsets[count]);

							//Only add unique values to the ItemsetArrayList class
 
							//Create an itemset containing support, confidence and association rules by
							//generating the rule [childSubset is associated with [parentItemset - childSubset]
							rulesItemset = (parentItemset-subsets[count]);

							this.CreateItemsetRuleset(parentItemset, subsets[count], rulesItemset,transactionsData);
						
						}
					}
				
					//Recursively generate subsets for the itemset
					childSubset.TrimToSize();

					this.CreateItemsetSubsets(0, childSubset, parentItemset, transactionsData);
				}
			
			}


			/// <summary>
			/// Creates the subsets of an itemset.
			/// </summary>
			/// <param name="itemSubset">
			/// The ItemsetArrayList containing the items to generate subsets for.
			/// </param>
			/// <returns>
			/// Returns an array of ItemsetArrayList object.
			/// </returns>
			public ItemsetArrayList [] CreateItemsetSubsets(ItemsetArrayList itemSubset)
			{
				int length = itemSubset.Count;

			
				ItemsetArrayList [] subset = new ItemsetArrayList[length];

			
				//There are zero subsets for an itemset with one element
				switch (length)
				{

					case 0:
					{
						subset = null;

						break;
					}

					case 1:
					{
						subset = null;

						break;
					}

					default:
					{
						//Add the first length - 1 elements
					
						subset[0] = new ItemsetArrayList(1);

						for(int count = 0; count < (length - 1); count++)
						{
							subset[0].Add(itemSubset[count]);
						}

						subset[0].TrimToSize();
					
						//Add the last length - 1 elements
						subset[1] = new ItemsetArrayList(1);

						for(int count = 1; count < (length); count++)
						{
							subset[1].Add(itemSubset[count]); 
						}

						subset[1].TrimToSize();

						//Add the last length - 1 elements
						for(int count = 1; count < (length-1); count++)
						{
							int position = 0;

							subset[(count + 1)] = new ItemsetArrayList(1);

							subset[(count + 1)].Add(itemSubset[position]);


							for(position = 1; position < length; position++)
							{
								if(position != count)
								{
									subset[(count + 1)].Add(itemSubset[position]); 
								}
							}

							subset[(count + 1)].TrimToSize();						
						}

						break;
					}

				}
					
				return subset;

			}
		
		}

	}

}
