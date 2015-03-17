﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;
using System.IO;
using Assistant;


namespace RazorEnhanced.UI
{
	public partial class EnhancedOrganizerManualAdd : Form
	{
		private const string m_Title = "Enhanced Organizer Manual Add Item";
        private ListView OrganizerListView;
        private List<RazorEnhanced.Organizer.OrganizerItem> OrganizerItemList;
        public EnhancedOrganizerManualAdd(ListView POrganizerListView, List<RazorEnhanced.Organizer.OrganizerItem> POrganizerItemList)
		{
			InitializeComponent();
            MaximizeBox = false;
			this.Text = m_Title;
            OrganizerListView = POrganizerListView;
            OrganizerItemList = POrganizerItemList;
		}

        private void EnhancedOrganizerManualAdd_Load(object sender, EventArgs e)
        {
            tName.Text = "New Item";
            tColor.Text = "0x0000";
            tGraphics.Text = "0x0000";
            tAmount.Text = "-1";
        }



        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void bAddItem_Click(object sender, EventArgs e)
        {
            bool fail = false;
            int Graphics = 0;
            int Color = 0;
            int Amount = 0;
            if (tName.Text == null)
            {
                MessageBox.Show("Item name is not valid.",
                "Item name Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                fail = true;
            }

            try
            {
                Graphics = Convert.ToInt32(tGraphics.Text, 16); 
            }
            catch
            {
                MessageBox.Show("Item Graphics is not valid.",
                "Item Graphics Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                fail = true;
            }

            try
            {
                Amount = Convert.ToInt32(tAmount.Text);
            }
            catch
            {
                MessageBox.Show("Item Amount is not valid.",
                "Item Amount Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                fail = true;
            }
            if (tColor.Text == "-1")
                Color = -1;
            else
            {
                try
                {

                    Color = Convert.ToInt32(tColor.Text, 16);
                }
                catch
                {
                    MessageBox.Show("Item Color is not valid.",
                    "Item Color Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    fail = true;
                }
            }

            if (!fail)
            {
                RazorEnhanced.Organizer.AddItemToList(tName.Text, Graphics, Color, Amount, OrganizerListView, OrganizerItemList);
               
                this.Close();
            }

        }
	}
}