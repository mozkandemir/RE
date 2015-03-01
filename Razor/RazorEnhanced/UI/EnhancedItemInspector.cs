﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RazorEnhanced.UI
{
	public partial class EnhancedItemInspector : Form
	{
		private const string m_Title = "Enhanced Item Inspect";

		internal EnhancedItemInspector(Assistant.Item itemTarg)
		{
			InitializeComponent();
			MaximizeBox = false;
			// general
			lSerial.Text = "0x" + itemTarg.Serial.Value.ToString("X8");
			lItemID.Text = "0x" + itemTarg.ItemID.Value.ToString("X4");
			lColor.Text = itemTarg.Hue.ToString();
			lPosition.Text = itemTarg.Position.ToString();
			// Details
			Assistant.PlayerData tempdata;
			Assistant.Item tempdata2;
			if (itemTarg.Container is Assistant.PlayerData)
			{
				tempdata = (Assistant.PlayerData)itemTarg.Container;
				lContainer.Text = tempdata.Serial.ToString();
			}
			if (itemTarg.Container is Assistant.Item)
			{
				tempdata2 = (Assistant.Item)itemTarg.Container;
				lContainer.Text = tempdata2.Serial.ToString();
			}

			if (itemTarg.RootContainer is Assistant.PlayerData)
			{
				tempdata = (Assistant.PlayerData)itemTarg.RootContainer;
				lRootContainer.Text = tempdata.Serial.ToString();
				if (tempdata.Serial == Assistant.World.Player.Serial)
					lOwned.Text = "Yes";
			}
			if (itemTarg.RootContainer is Assistant.Item)
			{
				tempdata2 = (Assistant.Item)itemTarg.RootContainer;
				lRootContainer.Text = tempdata2.Serial.ToString();
				if (tempdata2.Serial == Assistant.World.Player.Backpack.Serial)
					lOwned.Text = "Yes";
			}

			lAmount.Text = itemTarg.Amount.ToString();
			lLayer.Text = itemTarg.Layer.ToString();

			// Attributes
			for (int i =0; i<itemTarg.ObjPropList.Content.Count;i++)
			{
				Assistant.ObjectPropertyList.OPLEntry ent = itemTarg.ObjPropList.Content[i];
				if (i == 0)
					lName.Text = ent.ToString();
				string content = ent.ToString();
				listBoxAttributes.Items.Add(content);
			}
		}

		private void razorButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void lName_Click(object sender, EventArgs e)
		{

		}

		private void EnhancedItemInspect_Load(object sender, EventArgs e)
		{

		}

		private void bNameCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lName.Text);
		}

		private void bSerialCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lSerial.Text);
		}

		private void bItemIdCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lItemID.Text);
		}

		private void bColorCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lColor.Text);
		}

		private void bPositionCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lPosition.Text);
		}

		private void bContainerCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lContainer.Text);
		}

		private void bRContainerCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lRootContainer.Text);
		}

		private void bAmountCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lAmount.Text);
		}

		private void bLayerCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lLayer.Text);
		}

		private void bOwnedCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(lOwned.Text);
		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{

		}
	}
}