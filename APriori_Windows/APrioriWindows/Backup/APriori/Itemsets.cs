using System;
using System.Collections;
using System.Text;


	/// <summary>
	/// The VISUAL_BASIC_DATA_MINING_NET namespace contains namespaces and classes used by this assembly.
	/// </summary>
namespace VISUAL_BASIC_DATA_MINING_NET
{


	namespace APriori
	{

		/// <summary>
		/// An abstract class that represents a set items from a shopping cart.
		/// </summary>
		/// <remarks >
		/// Defines the Level of an Itemset, its Items and Support Count.
		/// </remarks>
		public abstract class Itemset
		{

			/// <summary>
			/// The level of an Itemset is the Hierarchy of an itemset or how many items make up the Itemset.
			/// </summary>
			/// <remarks>
			/// <example>
			/// A one level Itemset contains one item, e.g. DVDs. A two level Itemset contains two items e.g. DVDs, CDs.
			/// </example>
			/// </remarks>
			protected int level;
		
			/// <summary>
			/// The items in an Itemset.
			/// <see cref="APriori.Itemset.Level"/>
			/// </summary>
			protected ItemsetArrayList items = new ItemsetArrayList();
	
        		
			/// <summary>
			/// The parameterless default constructor for the Itemset class.
			/// </summary>
			public Itemset()
			{
				this.items = new ItemsetArrayList();
				this.level = 0;			
			}

		
			/// <summary>
			/// How many items are comtained in the Itemset.
			/// </summary>
			///<value> 
			///The number of items in a set of items defines the hierarchy of the set of items or its Level.
			///</value>
			///<remarks>
			///The level of an Itemset is define by the number of items in the items collection.
			///<see cref=" APriori.Itemset.Items"/>
			///</remarks>
			public int Level
			{
				get
				{
					return level;
				}
				set
				{
					level = value;
				}
			}

	
			/// <summary>
			/// A list of items created from a scan of transactions in the database.
			/// </summary>
			///<value>
			///An ItemsetArrayList collection of items that make up an Itemset.
			///</value>
			///<remarks>
			///<see cref="APriori.ItemsetArrayList"/>
			///</remarks>
			public ItemsetArrayList Items
			{
				get
				{
					return items;
				}
				set
				{
					items.Add(value);
				}
			}		
	
		}


		/// <summary>
		/// The set of candidate items. Inherits from the Itemset class.
		/// <para>
		/// <see cref="APriori.Itemset"/> for more information about the Itemset class.
		/// </para>
		/// </summary>
		/// <remarks>
		/// See also
		/// <seealso cref="APriori.ItemsetFrequent"/>
		/// </remarks>
		public class ItemsetCandidate : Itemset
		{
			/// <summary>
			/// The parameterless default constructor for the ItemsetCandidate class.
			/// </summary>
			public ItemsetCandidate() : base()
			{
			}
		}

	
		/// <summary>
		/// The set of frequent items. Inherits from the Itemset class.
		/// <para>
		/// See
		/// <see cref="APriori.Itemset"/> for more information about the Itemset class.
		/// </para>
		/// <para>
		/// See also
		/// <seealso cref="APriori.ItemsetCandidate"/>
		/// </para>
		/// </summary>
		public class ItemsetFrequent : Itemset
		{
			/// <summary>
			/// Initializes a new instance of the ItemsetFrequent class using the parameterless default constructor.
			/// <para>
			/// See
			/// <see cref="APriori.ItemsetFrequent()"/> for more information about the Itemset class.
			/// </para>
			/// </summary>
			public ItemsetFrequent() : base()
			{
			}
		
		
			/// <summary>
			///Initializes a new instance of the ItemsetFrequent class that contains Items, Level and SupportCount properties data							copied from the	specified ItemsetCandidate class.
			/// </summary>
			/// <param name="itemsetCandidate">
			/// The ItemsetCandidate class whose Items, Level and SupportCount members are copied to the new instance of the 
			/// ItemsetFrequent class.
			/// </param>
			public ItemsetFrequent(ItemsetCandidate itemsetCandidate) : base()
			{
				this.items = itemsetCandidate.Items;
			
				this.level = itemsetCandidate.Level;
			}
		}


	

		/// <summary>
		/// The ItemsetArrayList class inherits from the ArrayList class and implements a SupportCount and Level property
		/// </summary>
		/// <include file='APrioriExamples.xml' path='Documentation/SourceCode[@name="Copyright"]/*' />
		[SerializableAttribute()]
		public class ItemsetArrayList : ArrayList
		{
			/// <summary>
			/// Returns a string containing only a comma ","
			/// </summary>
			public static string CommaOnly =  ",";
		
			/// <summary>
			/// Returns a string containing both a comma "," and a whitespace " " after the comma
			/// </summary>
			public static string CommaSpaceAfter = ", ";
		
			/// <summary>
			/// Returns a string containing both a comma "," and a whitespace " " before the comma
			/// </summary>
			public static string CommaSpaceBefore = " ,";
		
			/// <summary>
			/// Returns a string containing both a comma "," and two whitespaces " " before and after the comma
			/// </summary>
			public static string CommaSpaceBoth = " , ";
	
			/// <summary>
			/// The number of items in a set of items.
			/// </summary>
			/// <example >
			/// E.g. the number of items in a shopping cart.
			/// </example>
			protected int level;
		
			/// <summary>
			/// Stores the support count of a set of items. 
			/// </summary>
			protected int supportcount;
			

			/// <summary>
			/// Initializes a new instance of the ItemsetArrayList class using the parameterless default constructor
			/// </summary>
			public ItemsetArrayList() : base()
			{
				level = 0;

				supportcount = 0;
			}

		
			/// <summary>
			/// Initializes a new instance of the ItemsetArrayList class that is empty and has the specified initial capacity.
			/// </summary>
			/// <param name="initialCapacity">
			/// An integer representing the initial capacity of the ItemsetArrayList
			/// </param>
			public ItemsetArrayList(int initialCapacity) : base(initialCapacity)
			{
				level = 0;

				supportcount = 0;
			}
		
		
			/// <summary>
			/// Initializes a new instance of the ItemsetArrayList class that contains elements copied from the specified collection and 		
			/// that has the same initial capacity as the number of elements copied.
			/// </summary>
			/// <param name="collectionList">
			/// The System.Collections.ICollection interface whose members are copied to the ItemsetArrayList class
			/// </param>
			public ItemsetArrayList(ICollection collectionList) : base(collectionList)
			{
				level = 0;

				supportcount = 0;
			}

		
			/// <summary>
			/// Converts a string to an ItemsetArrayList object
			/// </summary>
			/// <param name="data">
			/// The string to convert into an ItemsetArrayList object.
			/// </param>
			/// <param name="seperatorCharacters">
			/// An array of characters separating the individual data values in the string
			/// </param>
			/// <returns>
			/// An ItemsetArrayList object 
			/// </returns>
			/// <example>
			/// <code>
			///	ItemsetArrayList datum = ItemsetArrayList.ConvertToItemsetArrayList("Cheese,Eggs,Milk", new Char[] {','});
			///</code>
			/// </example>
			public static ItemsetArrayList ConvertToItemsetArrayList(string data, char [] seperatorCharacters)
			{
				string [] items = data.Split(seperatorCharacters);

				int length = items.Length;
			
				ItemsetArrayList itemSet = new ItemsetArrayList(length);
						
			
				for(int count = 0; count < length; count++)
				{
					itemSet.Add(items[count]);
				}
			
			
				itemSet.Sort();

				itemSet.TrimToSize();

				return itemSet;								
			}

		
			/// <summary>
			/// Parses the data in an ItemsetArrayList object into a string object
			/// </summary>
			/// <param name="data">
			/// An ItemsetArrayList object containing the data to be parsed into a string
			/// </param>
			/// <param name="seperatorCharacters">
			/// A string used to seperate items parsed from an ItemsetArrayList object
			/// </param>
			/// <returns>
			/// Returns a string containing data parsed from an ItemsetArrayList object
			/// </returns>
			/// <example>
			/// string items = ItemsetArrayList.ConvertToString(data, ",");
			/// </example>
			public static string ConvertToString(ItemsetArrayList data, string seperatorCharacters)
			{
				StringBuilder items = new StringBuilder();

				int length = data.Count;

		
				for(int count = 0; count < (length-1); count++)
				{
					items.Append(data[count]);
					items.Append(seperatorCharacters);
				}

				items.Append(data[(length-1)]);


				return items.ToString();
			}

		
			/// <summary>
			/// Subtracts the items in a set of items from another set of items and places the result in new itemset.
			/// </summary>
			/// <param name="itemsetLHS">
			/// The set of items on the left hand side of a subtraction operator.
			/// </param>
			/// <param name="itemsetRHS">
			/// The set of items on the right hand side of a subtraction operator.
			/// </param>
			/// <returns>
			/// A new set of items from the ItemsetArrayList subtraction operation.
			/// </returns>
			/// <remarks>
			/// <see cref="APriori.ItemsetArrayList"/>
			/// </remarks>
			public static ItemsetArrayList operator - (ItemsetArrayList itemsetLHS, ItemsetArrayList itemsetRHS)
			{
			
				int lhsLength = itemsetLHS.Count;

				int rhsLength = itemsetRHS.Count;

				int length = (lhsLength - rhsLength);

				int difference = 0;

				StringBuilder [] errorMessages = new StringBuilder[2];

				ItemsetArrayList newItemset = new ItemsetArrayList(1);

			
				//Error Messages to display
				errorMessages[0] = new StringBuilder(100);

				errorMessages[0].Append ("This operation is not allowed! The ItemsetArrayList object on the right hand side ");
			
				errorMessages[0].Append("of the operation has fewer members than allowed.");


				errorMessages[1] = new StringBuilder(100);

				errorMessages[1].Append ("This operation is not allowed! The ItemsetArrayList object on the left hand side ");
			
				errorMessages[1].Append("of the operation has fewer members than allowed.");

			
				//Sort the members of the ItemsetArrayList objects 
				itemsetLHS.Sort();

				itemsetRHS.Sort();


				if(length > 0)
				{
					difference = 1;
				}

				else if(length < 0)
				{
					difference = -1;
				}

			
				switch(difference)
				{

					case 0:
					{
						//If the ItemsetArrayList object on the Left Hand Side has fewer members than the 
						//ItemsetArrayList object on the Right Hand Side then an error will be raised 
						throw new Exception(errorMessages[0].ToString());					
					}
				
					case 1:
					{						 
						newItemset = new ItemsetArrayList(length);

						for(int count = 0; count < lhsLength; count++)
						{
							if (!itemsetRHS.Contains(itemsetLHS[count]))
							{
								newItemset.Add(itemsetLHS[count]);  
							}
						}

						break;	
					}				

					case -1:
					{
					
						newItemset = null;

						throw new Exception(errorMessages[1].ToString());
					
					}
				}

				newItemset.TrimToSize();

				return newItemset;
			}

	
			/// <summary>
			/// The level of an Itemset is the number of items in the itemset. 
			/// </summary>
			public int Level
			{
				get
				{
					return level;
				}
				set
				{
					level = value;
				}
			}
		
		
			/// <summary>
			/// The support count of a set of items is the the number of transactions in the database that contain the items.
			/// </summary>
			/// <remarks>
			/// See 
			/// <see cref="APriori.Itemset"/>
			/// </remarks>
			public int SupportCount
			{
				get
				{
					return supportcount;
				}
				set
				{
					supportcount = value;
				}
			}		
		
		} 
	
	}

}
