using System;


	/// <summary>
	/// The VISUAL_BASIC_DATA_MINING_NET namespace contains namespaces and classes used by this assembly.
	/// </summary>
namespace VISUAL_BASIC_DATA_MINING_NET
{

	/// <summary>
	/// Attribute marks a class member's usage as reserved for a future version.
	///  A reserved member should not be implemented or called in any code statement.
	/// </summary>
	[AttributeUsageAttribute(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
	public class ReservedAttribute: Attribute 
	{

		
		/// <summary>
		/// System.Boolean variable stores the state of a ReservedAttribute
		/// </summary>
		private Boolean isReservedMember;

		
		/// <summary>
		/// System.DateTime variable that stores the date a class or class member is tagged with the ReservedAttribute.
		/// </summary>
		private DateTime isReservedDate;
		
				
		/// <summary>
		/// Initialize the ReservedAttribute with a value of true to reserve an attribute or a value of false.
		/// </summary>
		/// <param name="reservedMember">
		/// A boolean value of true if a class member is reserved for a future use or false if it is not.
		/// </param>
		/// <example>
		/// An example of the usage of the ReservedAttribute keyword is : 
		/// <code>
		/// [ReservedAttribute(true, "December 25, 2002")]
		/// public class ASP
		/// {
		///		DataMining();
		/// }
		/// </code> 
		/// </example>
		public ReservedAttribute(Boolean reservedMember)
		{
			this.isReservedMember = reservedMember;
		}

		
		/// <summary>
		/// This constructor initializes a new instance of the class using true or false and date values.
		/// </summary>
		/// <param name="reservedMember">
		/// A value of true if the class or class member is reserved or false if it is not.
		/// </param>
		/// <param name="reservedDate">
		/// The date a class or class member is tagged as reserved.
		/// </param>
		public ReservedAttribute(Boolean reservedMember, string reservedDate)
		{
			this.isReservedMember = reservedMember;
            
			this.isReservedDate = DateTime.Parse(reservedDate);
		}

		
		/// <summary>
		/// A member tagged as reserved should not be implemented or called in any code statement.
		/// </summary>
		/// <value>
		/// A System.Boolean value of true if a class or class member is reserved and false if it is not.
		/// </value>
		public Boolean ReservedMember
		{
			get
			{
				return this.isReservedMember;
			}
		}

		
		/// <summary>
		/// The date a class or class member is tagged with the ReservedAttribute keyword.
		/// </summary>
		/// <value>
		/// A System.DateTime value specifying when a class or class member is tagged with the ReservedAttribute keyword.
		/// </value>
		public DateTime ReservedDate
		{
			get
			{
				return this.isReservedDate;
			}
		}
		

	}

}
