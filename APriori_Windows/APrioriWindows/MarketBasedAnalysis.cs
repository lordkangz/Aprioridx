using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using VISUAL_BASIC_DATA_MINING_NET;
using VISUAL_BASIC_DATA_MINING_NET.CustomEvents;
using VISUAL_BASIC_DATA_MINING_NET.DataTransformationServices;


namespace APrioriWindows
{
	/// <summary>
	/// Summary description for MarketBasedAnalysis.
	/// </summary>
	public class MarketBasedAnalysis : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dataGridViewAnalysisResult;
		private System.Windows.Forms.GroupBox groupBoxCommands;
		private System.Windows.Forms.Button buttonDataConnection;
		//
		//
		private ConnectionDialogBox connectionDialogBox;
		private System.Windows.Forms.Button buttonOK;
		//
		//
		private System.Windows.Forms.GroupBox groupBoxSettings;
		private System.Windows.Forms.Label lblSupportCount;
		private System.Windows.Forms.Label lblMinimumConfidence;
		private System.Windows.Forms.TextBox txtMinimumSupport;
		private System.Windows.Forms.TextBox txtMinimumConfidence;
		//
		//
		private DataMining DMS;
		private ViewData dataView;
		private Data dataAnalysis;
		private NorthwindDTS dts;
		private Data orders;
		private string minimumConfidence;
		private string minimumSupport;
		private int minimumConfidenceLength;
		private int minimumSupportLength;
		private System.Windows.Forms.GroupBox groupBoxProgressMonitor;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblProgressBar;
		private System.Windows.Forms.GroupBox groupBoxViewTables;
		private System.Windows.Forms.ProgressBar progressBarMonitor;
		//
		//
		//
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
		public void OnProgressMonitorEvent(object sender, ProgressMonitorEventArgs e)
		{			
			//Sets the information to be displayed on the progress bar
			this.progressBarMonitor.Minimum = e.MinimumValue;

			this.progressBarMonitor.Maximum = e.MaximumValue;

			this.progressBarMonitor.Value = e.CurrentValue;

			this.progressBarMonitor.Refresh();

			this.lblProgressBar.Text = e.EventMessage;

			this.lblProgressBar.Refresh();
		}
		
			
		/// <summary>
		/// A custom event that notifies clients about the progress of the executing code.
		/// </summary>
		public event ProgressMonitorEventHandler ProgressMonitorEvent;


		//
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MarketBasedAnalysis()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxCommands = new System.Windows.Forms.GroupBox();
            this.groupBoxViewTables = new System.Windows.Forms.GroupBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.lblMinimumConfidence = new System.Windows.Forms.Label();
            this.txtMinimumConfidence = new System.Windows.Forms.TextBox();
            this.lblSupportCount = new System.Windows.Forms.Label();
            this.txtMinimumSupport = new System.Windows.Forms.TextBox();
            this.buttonDataConnection = new System.Windows.Forms.Button();
            this.dataGridViewAnalysisResult = new System.Windows.Forms.DataGrid();
            this.groupBoxProgressMonitor = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblProgressBar = new System.Windows.Forms.Label();
            this.progressBarMonitor = new System.Windows.Forms.ProgressBar();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxCommands.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnalysisResult)).BeginInit();
            this.groupBoxProgressMonitor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxCommands);
            this.groupBox1.Controls.Add(this.dataGridViewAnalysisResult);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 528);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disease Diagnosis Association Analysis";
            // 
            // groupBoxCommands
            // 
            this.groupBoxCommands.Controls.Add(this.groupBoxViewTables);
            this.groupBoxCommands.Controls.Add(this.groupBoxSettings);
            this.groupBoxCommands.Controls.Add(this.buttonDataConnection);
            this.groupBoxCommands.Location = new System.Drawing.Point(792, 16);
            this.groupBoxCommands.Name = "groupBoxCommands";
            this.groupBoxCommands.Size = new System.Drawing.Size(176, 504);
            this.groupBoxCommands.TabIndex = 2;
            this.groupBoxCommands.TabStop = false;
            // 
            // groupBoxViewTables
            // 
            this.groupBoxViewTables.Location = new System.Drawing.Point(8, 80);
            this.groupBoxViewTables.Name = "groupBoxViewTables";
            this.groupBoxViewTables.Size = new System.Drawing.Size(160, 264);
            this.groupBoxViewTables.TabIndex = 2;
            this.groupBoxViewTables.TabStop = false;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.lblMinimumConfidence);
            this.groupBoxSettings.Controls.Add(this.txtMinimumConfidence);
            this.groupBoxSettings.Controls.Add(this.lblSupportCount);
            this.groupBoxSettings.Controls.Add(this.txtMinimumSupport);
            this.groupBoxSettings.Location = new System.Drawing.Point(8, 360);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(160, 136);
            this.groupBoxSettings.TabIndex = 1;
            this.groupBoxSettings.TabStop = false;
            // 
            // lblMinimumConfidence
            // 
            this.lblMinimumConfidence.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimumConfidence.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMinimumConfidence.Location = new System.Drawing.Point(8, 80);
            this.lblMinimumConfidence.Name = "lblMinimumConfidence";
            this.lblMinimumConfidence.Size = new System.Drawing.Size(144, 16);
            this.lblMinimumConfidence.TabIndex = 3;
            this.lblMinimumConfidence.Text = "Minimum Confidence %";
            // 
            // txtMinimumConfidence
            // 
            this.txtMinimumConfidence.Location = new System.Drawing.Point(8, 104);
            this.txtMinimumConfidence.Name = "txtMinimumConfidence";
            this.txtMinimumConfidence.Size = new System.Drawing.Size(144, 21);
            this.txtMinimumConfidence.TabIndex = 2;
            this.txtMinimumConfidence.Text = "50";
            this.txtMinimumConfidence.Validating += new System.ComponentModel.CancelEventHandler(this.txtMinimumConfidence_Validating);
            // 
            // lblSupportCount
            // 
            this.lblSupportCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupportCount.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSupportCount.Location = new System.Drawing.Point(8, 16);
            this.lblSupportCount.Name = "lblSupportCount";
            this.lblSupportCount.Size = new System.Drawing.Size(136, 16);
            this.lblSupportCount.TabIndex = 1;
            this.lblSupportCount.Text = "Minimum Support %";
            // 
            // txtMinimumSupport
            // 
            this.txtMinimumSupport.Location = new System.Drawing.Point(8, 40);
            this.txtMinimumSupport.Name = "txtMinimumSupport";
            this.txtMinimumSupport.Size = new System.Drawing.Size(144, 21);
            this.txtMinimumSupport.TabIndex = 0;
            this.txtMinimumSupport.Text = "10";
            this.txtMinimumSupport.TextChanged += new System.EventHandler(this.txtMinimumSupport_TextChanged);
            this.txtMinimumSupport.Validating += new System.ComponentModel.CancelEventHandler(this.txtMinimumSupport_Validating);
            // 
            // buttonDataConnection
            // 
            this.buttonDataConnection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDataConnection.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonDataConnection.Location = new System.Drawing.Point(24, 40);
            this.buttonDataConnection.Name = "buttonDataConnection";
            this.buttonDataConnection.Size = new System.Drawing.Size(128, 24);
            this.buttonDataConnection.TabIndex = 0;
            this.buttonDataConnection.Text = "&Data Connection";
            this.buttonDataConnection.Click += new System.EventHandler(this.buttonDataConnection_Click);
            // 
            // dataGridViewAnalysisResult
            // 
            this.dataGridViewAnalysisResult.AlternatingBackColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewAnalysisResult.DataMember = "";
            this.dataGridViewAnalysisResult.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewAnalysisResult.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridViewAnalysisResult.Location = new System.Drawing.Point(16, 24);
            this.dataGridViewAnalysisResult.Name = "dataGridViewAnalysisResult";
            this.dataGridViewAnalysisResult.ReadOnly = true;
            this.dataGridViewAnalysisResult.Size = new System.Drawing.Size(768, 496);
            this.dataGridViewAnalysisResult.TabIndex = 1;
            this.dataGridViewAnalysisResult.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGridViewAnalysisResult_Navigate);
            // 
            // groupBoxProgressMonitor
            // 
            this.groupBoxProgressMonitor.Controls.Add(this.groupBox2);
            this.groupBoxProgressMonitor.Controls.Add(this.buttonOK);
            this.groupBoxProgressMonitor.Location = new System.Drawing.Point(16, 536);
            this.groupBoxProgressMonitor.Name = "groupBoxProgressMonitor";
            this.groupBoxProgressMonitor.Size = new System.Drawing.Size(976, 88);
            this.groupBoxProgressMonitor.TabIndex = 1;
            this.groupBoxProgressMonitor.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblProgressBar);
            this.groupBox2.Controls.Add(this.progressBarMonitor);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(880, 72);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // lblProgressBar
            // 
            this.lblProgressBar.Location = new System.Drawing.Point(16, 48);
            this.lblProgressBar.Name = "lblProgressBar";
            this.lblProgressBar.Size = new System.Drawing.Size(856, 16);
            this.lblProgressBar.TabIndex = 1;
            // 
            // progressBarMonitor
            // 
            this.progressBarMonitor.Location = new System.Drawing.Point(8, 16);
            this.progressBarMonitor.Name = "progressBarMonitor";
            this.progressBarMonitor.Size = new System.Drawing.Size(864, 24);
            this.progressBarMonitor.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonOK.Location = new System.Drawing.Point(893, 37);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "&Analyze";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // MarketBasedAnalysis
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(1000, 629);
            this.Controls.Add(this.groupBoxProgressMonitor);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarketBasedAnalysis";
            this.Text = "Diagnosis Analysis";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MarketBasedAnalysis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxCommands.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnalysisResult)).EndInit();
            this.groupBoxProgressMonitor.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for this application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MarketBasedAnalysis());
		}

		private void MarketBasedAnalysis_Load(object sender, System.EventArgs e)
		{

		}

		private void buttonDataConnection_Click(object sender, System.EventArgs e)
		{					
			connectionDialogBox = new ConnectionDialogBox();

			connectionDialogBox.ShowDialog(this);
		}


		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.DMS = new DataMining();


			this.DMS.ProgressMonitorEvent += new ProgressMonitorEventHandler(this.OnProgressMonitorEvent);

			
			if((ClassInfo.DataStorage == ClassInfo.DataStorageLocation.Database) && (ClassInfo.DataStorageModel == ClassInfo.DataModel.TransactionsTable))
			{
				this.dataAnalysis = DMS.MarketBasedAnalysis(ClassInfo.MinimumSupport, ClassInfo.MinimumConfidence,ClassInfo.														ConnectionString,"TransactionsTable",CommandType.TableDirect);				
			}

			else if (ClassInfo.DataStorage == ClassInfo.DataStorageLocation.XMLFile) 
			{
				this.dataAnalysis = DMS.MarketBasedAnalysis(ClassInfo.MinimumSupport, ClassInfo.MinimumConfidence,ClassInfo.																	XMLFilePath);		
			}


			else if((ClassInfo.DataStorage == ClassInfo.DataStorageLocation.Database) && (ClassInfo.DataStorageModel == ClassInfo.DataModel.NorthwindDatabase ))
			{
				dts = new NorthwindDTS();

				dts.LoadNorthwindwindProducts(ClassInfo.ConnectionString);

				dts.LoadNorthwindwindOrders(ClassInfo.ConnectionString);

				dts.LoadNorthwindwindOrderDetails(ClassInfo.ConnectionString);

				orders = dts.GetOrders();
				
				this.dataAnalysis = DMS.MarketBasedAnalysis(ClassInfo.MinimumSupport,ClassInfo.MinimumConfidence,orders);
			}

			
			if(this.dataAnalysis != null)
			{

				this.dataView = new ViewData();

				this.dataAnalysis.Tables.Add(this.dataView.CreateViewRulesTable(ClassInfo.MinimumConfidence,this.dataAnalysis).Copy());

				this.dataAnalysis.Tables.Add(this.dataView.CreateViewSubsetTable(this.dataAnalysis).Copy());


				this.dataGridViewAnalysisResult.DataSource = DMS.ViewDataMiningAnalysis("ViewRulesTable","Confidence desc");
			}

		}


		private void dataGridViewAnalysisResult_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{		
		}

		private void txtMinimumSupport_TextChanged(object sender, System.EventArgs e)
		{			
		}


		private void txtMinimumSupport_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{	
			if (txtMinimumSupport.Text.Length == 0)
			{
				MessageBox.Show(this,"Please enter a minimum support between 0% and 100%",ClassInfo.AppCaption,MessageBoxButtons.																							OK ,MessageBoxIcon.Information);
			}

			else if (txtMinimumSupport.Text.Length > 0)
			{
				minimumSupport = txtMinimumSupport.Text.Trim();

				minimumSupportLength = minimumSupport.Length;

				if (minimumSupport.EndsWith("%"))
				{
					ClassInfo.MinimumSupport = Convert.ToDouble(minimumSupport.Substring(0,																							minimumSupportLength-1));
				}
				else
				{
					ClassInfo.MinimumSupport = Convert.ToDouble(minimumSupport.Substring(0,																							minimumSupportLength));
				}
			}
		}
		

		private void txtMinimumConfidence_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{	
			if (txtMinimumConfidence.Text.Length == 0)
			{
				MessageBox.Show(this,"Please enter a minimum confidence between 0% and 100%",ClassInfo.AppCaption,																						MessageBoxButtons.OK ,MessageBoxIcon.Information);
			}

			else if (txtMinimumConfidence.Text.Length > 0)
			{
				minimumConfidence = txtMinimumConfidence.Text.Trim();

				minimumConfidenceLength = minimumConfidence.Length;

				if (minimumConfidence.EndsWith("%"))
				{
					
					ClassInfo.MinimumConfidence = Convert.ToDouble(minimumConfidence.Substring(0,																							minimumConfidenceLength-1));
				}
				else
				{
					ClassInfo.MinimumConfidence = Convert.ToDouble(minimumConfidence.Substring(0,																							minimumConfidenceLength));
				}
			}
		}

		

	}
}
