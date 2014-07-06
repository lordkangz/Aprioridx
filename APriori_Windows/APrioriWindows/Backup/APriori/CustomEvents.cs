using System;


	/// <summary>
	/// The VISUAL_BASIC_DATA_MINING_NET namespace contains namespaces and classes used by this assembly.
	/// </summary>
namespace VISUAL_BASIC_DATA_MINING_NET
{

	
	/// <summary>
	/// The VISUAL_BASIC_DATA_MINING_NET.CustomEvents namespace provides classes used in implementing custom events.
	/// </summary>
	namespace CustomEvents
	{

		/// <summary>
		/// A public delegate for the custom event class ProgressMonitorEventArgs.
		/// </summary>
		/// <value>
		/// A System.Delegate class.
		/// </value>
		public delegate void ProgressMonitorEventHandler(object sender, ProgressMonitorEventArgs e);

		
		/// <summary>
		/// Contains event data used in reporting and monitoring the progress of executing code.
		/// </summary>
		/// <remarks>
		/// Inherits from the System.EventArgs class.
		/// </remarks>
		public class ProgressMonitorEventArgs : EventArgs
		{
			
			/// <summary>
			/// Contains the minimum value used to monitor an executing code.
			/// </summary>
			private int minimumValue;
			
			/// <summary>
			/// Contains the maximum value used to monitor an executing code.
			/// </summary>
			private int maximumValue;
			
			/// <summary>
			/// Contains the value indicating the progress of the executing code on a range between the 
			/// minimumValue and maximumValue.
			/// </summary>
			private int currentValue;
			
			/// <summary>
			/// Contains the class and class member reporting the progress of its execution.
			/// </summary>
			private string eventSource;
			
			/// <summary>
			/// Contains a message sent by a class member about its progress in executing its code.
			/// </summary>
			private string eventMessage;

			
			/// <summary>
			/// This class constructor intializes the members of this class with information about the progress
			/// of code being executed by another class member.
			/// </summary>
			/// <param name="minimum">
			/// The minimum value of the range of numeric values used to report the progress of code in a class member.
			/// </param>
			/// <param name="maximum">
			/// The maximum value of the range of numeric values used to report the progress of code in a class member.
			/// </param>
			/// <param name="value">
			/// The current value of the range of numeric values used to report the progress of code in a class member.
			/// </param>
			/// <param name="source">
			/// The class member that is reporting the progress of an executing segment of code.
			/// </param>
			/// <param name="message">
			/// The message sent by a class member as it reports the progress of an executing code.
			/// </param>
			public ProgressMonitorEventArgs(int minimum, int maximum, int value, string source, string message) : base()
			{
				this.minimumValue = minimum;

				this.maximumValue= maximum;

				this.currentValue = value;

				this.eventSource = source;

				this.eventMessage = message;
			}
			
			
			///<summary
			/// This class constructor intializes the members of this class with information about the progress
			/// of code being executed by another class member.
			/// </summary>
			/// <param name="minimum">
			/// The minimum value of the range of numeric values used to report the progress of code in a class member.
			/// </param>
			/// <param name="maximum">
			/// The maximum value of the range of numeric values used to report the progress of code in a class member.
			/// </param>
			/// <param name="value">
			/// The current value of the range of numeric values used to report the progress of code in a class member.
			/// </param>
			/// <param name="source">
			/// The class member that is reporting the progress of an executing segment of code.
			public ProgressMonitorEventArgs(int minimum, int maximum, int value, string source) : base()
			{
				this.minimumValue = minimum;

				this.maximumValue= maximum;

				this.currentValue = value;

				this.eventSource = source;				
			}
			

			///<summary
			/// This class constructor intializes the members of this class with information about the progress
			/// of code being executed by another class member.
			/// </summary>
			/// <param name="e">
			/// Allows a parameter of the same type as its class to initilaize it. see <see cref="ProgressMonitorEventArgs"/>
			/// </param>
			public ProgressMonitorEventArgs(ProgressMonitorEventArgs e)
			{
				this.minimumValue = e.MinimumValue;

				this.maximumValue= e.MaximumValue;

				this.currentValue = e.CurrentValue;

				this.eventSource = e.EventSource;

				this.eventMessage = e.EventMessage;				
			}

			
			/// <summary>
			/// Gets the Maximum value of a range of numeric values used to monitor and report the progress of an operation.
			/// </summary>
			/// <value>
			/// A System.Int32 property.
			/// </value>
			public int MaximumValue
			{
				get
				{
					return this.maximumValue;
				}
			}


			/// <summary>
			/// Gets the Minimum value of a range of numeric values used to monitor and report the progress of an operation.
			/// </summary>
			/// <value>
			/// A System.Int32 property.
			/// </value>
			public int MinimumValue
			{
				get
				{
					return this.minimumValue;
				}
			}
			
			/// <summary>
			/// Gets the Current value of a range of numeric values used to monitor and report the progress of an operation.
			/// </summary>
			/// <value>
			/// A System.Int32 property.
			/// </value>
			public int CurrentValue
			{

				get
				{
					return this.currentValue;
				}
			}
			
			/// <summary>
			/// Gets the Class that is reporting the progress of an operation.
			/// </summary>
			/// <value>
			/// A System.String property.
			/// </value>
			public string EventSource
			{
				get
				{
					return this.eventSource;
				}
			}
			
			/// <summary>
			/// Gets the message used by a class to report the progress of an operation.
			/// </summary>
			/// <value>
			/// A System.String property.
			/// </value>
			public string EventMessage
			{
				get
				{
					return this.eventMessage;
				}
			}


		}

	}
	
		
}
