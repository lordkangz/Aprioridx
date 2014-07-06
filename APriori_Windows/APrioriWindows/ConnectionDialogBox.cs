using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using APrioriWindows;


namespace APrioriWindows
{
	/// <summary>
	/// Summary description for ConnectionDialogBox.
	/// </summary>
	public class ConnectionDialogBox : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBoxConnectionDialogBox;
		private System.Windows.Forms.GroupBox groupBoxDataStorageType;
		private System.Windows.Forms.RadioButton radioButtonDatabase;
		private System.Windows.Forms.RadioButton radioButtonXML;
		private System.Windows.Forms.GroupBox groupBoxConnectionInfo;
		private System.Windows.Forms.TextBox textBoxConnection;
		private System.Windows.Forms.OpenFileDialog openFileDialogXMLFilePath;
		private System.Windows.Forms.GroupBox groupBoxOK;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox groupBoxDataModel;
		private System.Windows.Forms.RadioButton radioButtonNorthwind;
		private System.Windows.Forms.RadioButton radioButtonTransactions;
		//
		//

		//
		//

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConnectionDialogBox()
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
            this.groupBoxConnectionDialogBox = new System.Windows.Forms.GroupBox();
            this.groupBoxDataModel = new System.Windows.Forms.GroupBox();
            this.radioButtonNorthwind = new System.Windows.Forms.RadioButton();
            this.radioButtonTransactions = new System.Windows.Forms.RadioButton();
            this.groupBoxOK = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxConnectionInfo = new System.Windows.Forms.GroupBox();
            this.textBoxConnection = new System.Windows.Forms.TextBox();
            this.groupBoxDataStorageType = new System.Windows.Forms.GroupBox();
            this.radioButtonXML = new System.Windows.Forms.RadioButton();
            this.radioButtonDatabase = new System.Windows.Forms.RadioButton();
            this.openFileDialogXMLFilePath = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxConnectionDialogBox.SuspendLayout();
            this.groupBoxDataModel.SuspendLayout();
            this.groupBoxOK.SuspendLayout();
            this.groupBoxConnectionInfo.SuspendLayout();
            this.groupBoxDataStorageType.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConnectionDialogBox
            // 
            this.groupBoxConnectionDialogBox.Controls.Add(this.groupBoxDataModel);
            this.groupBoxConnectionDialogBox.Controls.Add(this.groupBoxOK);
            this.groupBoxConnectionDialogBox.Controls.Add(this.groupBoxConnectionInfo);
            this.groupBoxConnectionDialogBox.Controls.Add(this.groupBoxDataStorageType);
            this.groupBoxConnectionDialogBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxConnectionDialogBox.Location = new System.Drawing.Point(8, 16);
            this.groupBoxConnectionDialogBox.Name = "groupBoxConnectionDialogBox";
            this.groupBoxConnectionDialogBox.Size = new System.Drawing.Size(376, 344);
            this.groupBoxConnectionDialogBox.TabIndex = 0;
            this.groupBoxConnectionDialogBox.TabStop = false;
            this.groupBoxConnectionDialogBox.Text = "Data Connection";
            this.groupBoxConnectionDialogBox.Enter += new System.EventHandler(this.groupBoxConnectionDialogBox_Enter);
            // 
            // groupBoxDataModel
            // 
            this.groupBoxDataModel.Controls.Add(this.radioButtonNorthwind);
            this.groupBoxDataModel.Controls.Add(this.radioButtonTransactions);
            this.groupBoxDataModel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDataModel.Location = new System.Drawing.Point(8, 192);
            this.groupBoxDataModel.Name = "groupBoxDataModel";
            this.groupBoxDataModel.Size = new System.Drawing.Size(360, 64);
            this.groupBoxDataModel.TabIndex = 3;
            this.groupBoxDataModel.TabStop = false;
            this.groupBoxDataModel.Text = "Choose the design of the Transactions Database";
            // 
            // radioButtonNorthwind
            // 
            this.radioButtonNorthwind.Location = new System.Drawing.Point(200, 24);
            this.radioButtonNorthwind.Name = "radioButtonNorthwind";
            this.radioButtonNorthwind.Size = new System.Drawing.Size(88, 24);
            this.radioButtonNorthwind.TabIndex = 1;
            this.radioButtonNorthwind.Text = "Northwind ";
            // 
            // radioButtonTransactions
            // 
            this.radioButtonTransactions.Checked = true;
            this.radioButtonTransactions.Location = new System.Drawing.Point(56, 24);
            this.radioButtonTransactions.Name = "radioButtonTransactions";
            this.radioButtonTransactions.Size = new System.Drawing.Size(128, 24);
            this.radioButtonTransactions.TabIndex = 0;
            this.radioButtonTransactions.TabStop = true;
            this.radioButtonTransactions.Text = "Transactions Table";
            // 
            // groupBoxOK
            // 
            this.groupBoxOK.Controls.Add(this.buttonCancel);
            this.groupBoxOK.Controls.Add(this.buttonOK);
            this.groupBoxOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOK.Location = new System.Drawing.Point(8, 288);
            this.groupBoxOK.Name = "groupBoxOK";
            this.groupBoxOK.Size = new System.Drawing.Size(360, 48);
            this.groupBoxOK.TabIndex = 2;
            this.groupBoxOK.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonCancel.Location = new System.Drawing.Point(248, 16);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonOK.Location = new System.Drawing.Point(40, 16);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBoxConnectionInfo
            // 
            this.groupBoxConnectionInfo.Controls.Add(this.textBoxConnection);
            this.groupBoxConnectionInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxConnectionInfo.Location = new System.Drawing.Point(8, 104);
            this.groupBoxConnectionInfo.Name = "groupBoxConnectionInfo";
            this.groupBoxConnectionInfo.Size = new System.Drawing.Size(360, 56);
            this.groupBoxConnectionInfo.TabIndex = 1;
            this.groupBoxConnectionInfo.TabStop = false;
            this.groupBoxConnectionInfo.Text = "Enter the Connection String to your Database";
            // 
            // textBoxConnection
            // 
            this.textBoxConnection.Location = new System.Drawing.Point(8, 24);
            this.textBoxConnection.Multiline = true;
            this.textBoxConnection.Name = "textBoxConnection";
            this.textBoxConnection.Size = new System.Drawing.Size(344, 21);
            this.textBoxConnection.TabIndex = 0;
            this.textBoxConnection.Text = "Provider=SQLOLEDB;Data Source=TSIMONJERO-PC;Initial Catalog=AprioriTest;Integrate" +
    "d Security=SSPI; ";
            // 
            // groupBoxDataStorageType
            // 
            this.groupBoxDataStorageType.Controls.Add(this.radioButtonXML);
            this.groupBoxDataStorageType.Controls.Add(this.radioButtonDatabase);
            this.groupBoxDataStorageType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDataStorageType.Location = new System.Drawing.Point(8, 32);
            this.groupBoxDataStorageType.Name = "groupBoxDataStorageType";
            this.groupBoxDataStorageType.Size = new System.Drawing.Size(360, 56);
            this.groupBoxDataStorageType.TabIndex = 0;
            this.groupBoxDataStorageType.TabStop = false;
            this.groupBoxDataStorageType.Text = "Choose the Location of your Transactions Data";
            // 
            // radioButtonXML
            // 
            this.radioButtonXML.Location = new System.Drawing.Point(200, 24);
            this.radioButtonXML.Name = "radioButtonXML";
            this.radioButtonXML.Size = new System.Drawing.Size(104, 24);
            this.radioButtonXML.TabIndex = 1;
            this.radioButtonXML.TabStop = true;
            this.radioButtonXML.Text = "XML File";
            this.radioButtonXML.CheckedChanged += new System.EventHandler(this.radioButtonXML_CheckedChanged);
            // 
            // radioButtonDatabase
            // 
            this.radioButtonDatabase.Checked = true;
            this.radioButtonDatabase.Location = new System.Drawing.Point(40, 24);
            this.radioButtonDatabase.Name = "radioButtonDatabase";
            this.radioButtonDatabase.Size = new System.Drawing.Size(104, 24);
            this.radioButtonDatabase.TabIndex = 0;
            this.radioButtonDatabase.TabStop = true;
            this.radioButtonDatabase.Text = "Database";
            this.radioButtonDatabase.CheckedChanged += new System.EventHandler(this.radioButtonDatabase_CheckedChanged);
            // 
            // openFileDialogXMLFilePath
            // 
            this.openFileDialogXMLFilePath.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogXMLFilePath_FileOk);
            // 
            // ConnectionDialogBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(392, 373);
            this.Controls.Add(this.groupBoxConnectionDialogBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(100, 100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionDialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectionDialogBox";
            this.TopMost = true;
            this.groupBoxConnectionDialogBox.ResumeLayout(false);
            this.groupBoxDataModel.ResumeLayout(false);
            this.groupBoxOK.ResumeLayout(false);
            this.groupBoxConnectionInfo.ResumeLayout(false);
            this.groupBoxConnectionInfo.PerformLayout();
            this.groupBoxDataStorageType.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void groupBoxConnectionDialogBox_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			
			if(this.radioButtonDatabase.Checked == true)
			{

				ClassInfo.ConnectionString = this.textBoxConnection.Text.Trim();

				ClassInfo.DataStorage = ClassInfo.DataStorageLocation.Database;

				if (!(ClassInfo.ConnectionString.Length > 0))
				{
					MessageBox.Show(this,"Please enter the connection string to the database!",ClassInfo.AppCaption,																			MessageBoxButtons.OK ,MessageBoxIcon.Information);
				}

				else
				{
					this.Close();
				}


				if(this.radioButtonTransactions.Checked == true)
				{
					ClassInfo.DataStorageModel = ClassInfo.DataModel.TransactionsTable;
				}

				else if(this.radioButtonNorthwind.Checked == true)
				{
					ClassInfo.DataStorageModel = ClassInfo.DataModel.NorthwindDatabase;
				}

			}

			else if (this.radioButtonXML.Checked == true)
			{
				ClassInfo.XMLFilePath = this.textBoxConnection.Text.Trim();

				ClassInfo.DataStorage = ClassInfo.DataStorageLocation.XMLFile;

				if (!(ClassInfo.XMLFilePath.Length > 0))
				{
					MessageBox.Show(this,"Please enter the path of an XML file with transactions to be analyzed!",ClassInfo.																	AppCaption, MessageBoxButtons.OK ,MessageBoxIcon.Information);
				}

				else
				{
					this.Close();
				}
			}


		}


		private void radioButtonDatabase_CheckedChanged(object sender, System.EventArgs e)
		{
			this.textBoxConnection.Text = "";

			if(this.radioButtonDatabase.Checked == true)
			{
				ClassInfo.DataStorage = ClassInfo.DataStorageLocation.Database;
			
				this.groupBoxConnectionInfo.Text = "Enter the Connection String to your transactions Database";
			}
		}

		private void radioButtonXML_CheckedChanged(object sender, System.EventArgs e)
		{
			this.textBoxConnection.Text = "";

			if (this.radioButtonXML.Checked == true)
			{
				ClassInfo.DataStorage = ClassInfo.DataStorageLocation.XMLFile;

				this.groupBoxConnectionInfo.Text = "Enter the path of an XML file with transactions to be analyzed";

				this.openFileDialogXMLFilePath.Title = ClassInfo.AppCaption;

				this.openFileDialogXMLFilePath.Filter = "xml files (*.xml)|*.xml";


				this.openFileDialogXMLFilePath.RestoreDirectory = true;

				this.openFileDialogXMLFilePath.CheckFileExists = true;

				this.openFileDialogXMLFilePath.CheckPathExists = true;			
 
				this.openFileDialogXMLFilePath.ShowDialog(this);

				ClassInfo.XMLFilePath = this.openFileDialogXMLFilePath.FileName;

				this.textBoxConnection.Text = ClassInfo.XMLFilePath;
			}
		}

        private void openFileDialogXMLFilePath_FileOk(object sender, CancelEventArgs e)
        {

        }


	}
}
