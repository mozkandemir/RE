namespace RazorEnhanced.UI
{
	partial class EnhancedGraphFilterAdd
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnhancedGraphFilterAdd));
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tGraphicsNew = new RazorEnhanced.UI.RazorTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tGraphicsReal = new RazorEnhanced.UI.RazorTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.bAddItem = new RazorEnhanced.UI.RazorButton();
			this.bClose = new RazorEnhanced.UI.RazorButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tGraphicsNew);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tGraphicsReal);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(9, 10);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(177, 81);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Graphics";
			// 
			// tGraphicsNew
			// 
			this.tGraphicsNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tGraphicsNew.BackColor = System.Drawing.Color.White;
			this.tGraphicsNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tGraphicsNew.Location = new System.Drawing.Point(85, 48);
			this.tGraphicsNew.Margin = new System.Windows.Forms.Padding(2);
			this.tGraphicsNew.Name = "tGraphicsNew";
			this.tGraphicsNew.Size = new System.Drawing.Size(76, 20);
			this.tGraphicsNew.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 50);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Graphics New:";
			// 
			// tGraphicsReal
			// 
			this.tGraphicsReal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tGraphicsReal.BackColor = System.Drawing.Color.White;
			this.tGraphicsReal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tGraphicsReal.Location = new System.Drawing.Point(85, 23);
			this.tGraphicsReal.Margin = new System.Windows.Forms.Padding(2);
			this.tGraphicsReal.Name = "tGraphicsReal";
			this.tGraphicsReal.Size = new System.Drawing.Size(76, 20);
			this.tGraphicsReal.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 25);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Graphics Real:";
			// 
			// bAddItem
			// 	
			this.bAddItem.Location = new System.Drawing.Point(200, 22);
			this.bAddItem.Margin = new System.Windows.Forms.Padding(2);
			this.bAddItem.Name = "bAddItem";
			this.bAddItem.Size = new System.Drawing.Size(57, 19);
			this.bAddItem.TabIndex = 2;
			this.bAddItem.Text = "Add";
			this.bAddItem.UseVisualStyleBackColor = true;
			this.bAddItem.Click += new System.EventHandler(this.bAddItem_Click);
			// 
			// bClose
			// 
			this.bClose.Location = new System.Drawing.Point(200, 66);
			this.bClose.Margin = new System.Windows.Forms.Padding(2);
			this.bClose.Name = "bClose";
			this.bClose.Size = new System.Drawing.Size(57, 19);
			this.bClose.TabIndex = 3;
			this.bClose.Text = "Close";
			this.bClose.UseVisualStyleBackColor = true;
			this.bClose.Click += new System.EventHandler(this.bClose_Click);
			// 
			// EnhancedGraphFilterAdd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(279, 103);
			this.Controls.Add(this.bClose);
			this.Controls.Add(this.bAddItem);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "EnhancedGraphFilterAdd";
			this.Text = "Enhanced Graph Filter Add";
			this.Load += new System.EventHandler(this.EnhancedOrganizerManualAdd_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.GroupBox groupBox1;
		private RazorTextBox tGraphicsNew;
		private System.Windows.Forms.Label label3;
		private RazorTextBox tGraphicsReal;
		private System.Windows.Forms.Label label2;
		private RazorButton bAddItem;
		private RazorButton bClose;

	}
}