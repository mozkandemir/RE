using RazorEnhanced.UI;
using System;
using System.Windows.Forms;

namespace Assistant
{
	/// <summary>
	/// Summary description for MessageDialog.
	/// </summary>
	internal class MessageDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button okay;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string m_Title;
		private string m_Message;
		private System.Windows.Forms.TextBox message;
		private bool m_CanIgnore;

		internal MessageDialog(string title, string message)
			: this(title, false, message)
		{
		}

		internal MessageDialog(string title, bool ignorable, string message, params object[] msgArgs)
			: this(title, ignorable, String.Format(message, msgArgs))
		{
		}

		internal MessageDialog(string title, bool ignorable, string message)
		{
			m_Title = title;
			m_Message = message;
			m_CanIgnore = ignorable;
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
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			this.message = new System.Windows.Forms.TextBox();
			this.okay = new RazorButton();
			this.SuspendLayout();
			//
			// message
			//
			this.message.Location = new System.Drawing.Point(10, 9);
			this.message.Multiline = true;
			this.message.Name = "message";
			this.message.ReadOnly = true;
			this.message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.message.Size = new System.Drawing.Size(662, 369);
			this.message.TabIndex = 0;
			//
			// okay
			//
			this.okay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okay.Location = new System.Drawing.Point(10, 388);
			this.okay.Name = "okay";
			this.okay.Size = new System.Drawing.Size(96, 27);
			this.okay.TabIndex = 1;
			this.okay.Text = "&Okay";
			this.okay.Click += new System.EventHandler(this.okay_Click);
			//
			// MessageDialog
			//
			this.AcceptButton = this.okay;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(684, 424);
			this.ControlBox = false;
			this.Controls.Add(this.okay);
			this.Controls.Add(this.message);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MessageDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Message";
			this.Load += new System.EventHandler(this.MessageDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion Windows Form Designer generated code

		private void MessageDialog_Load(object sender, System.EventArgs e)
		{
			this.Text = m_Title;
			this.message.Text = m_Message;
			this.message.Select(0, 0);
			this.BringToFront();

			if (m_CanIgnore)
				this.okay.Text = "&Ignore";
		}

		private void okay_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}