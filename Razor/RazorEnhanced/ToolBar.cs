using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Assistant;

namespace RazorEnhanced
{
	internal partial class ToolBarForm : Form
	{
		internal ToolBarForm()
		{
			Name = "ToolBar";
			Text = "ToolBar";
			FormClosed += new FormClosedEventHandler(ToolBar.EnhancedToolbar_close);
			Move += new System.EventHandler(ToolBar.EnhancedToolbar_Move);
			ContextMenu = ToolBar.GeneraMenu();
			MouseDown += new System.Windows.Forms.MouseEventHandler(ToolBar.ToolbarForm_MouseDown);
			MouseMove += new System.Windows.Forms.MouseEventHandler(ToolBar.ToolbarForm_MouseMove);
			MouseUp += new System.Windows.Forms.MouseEventHandler(ToolBar.ToolbarForm_MouseUp);
			MouseClick += new System.Windows.Forms.MouseEventHandler(ToolBar.ToolbarForm_MouseClick);
			MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(ToolBar.ToolbarForm_MouseClick);
			ShowInTaskbar = false;
			TopMost = true;
			FormBorderStyle = FormBorderStyle.None;
			MinimumSize = new Size(1, 1);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = Color.FromArgb(187, 182, 137);
			BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			MaximizeBox = false;
			CausesValidation = false;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!ToolBar.Lock)
				ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
			base.OnPaint(e);
		}
	}

	internal class ToolBar
	{  
		private static int m_slot = 0;

		private static bool m_lock = false;
		internal static bool Lock
		{
			get { return m_lock; }
			set { m_lock = value; }
		}

		private static Form m_form;
		internal static Form ToolBarForm
		{
			get	{ return m_form; }
			set { m_form = value; }
		}

		// Piccola Orizzontale
		private static Label m_hitslabelSH = new System.Windows.Forms.Label();
		private static Label m_manalabelSH = new System.Windows.Forms.Label();
		private static Label m_staminalabelSH = new System.Windows.Forms.Label();
		private static Label m_weightlabelSH = new System.Windows.Forms.Label();
		private static Label m_followerlabelSH = new System.Windows.Forms.Label();

		// Piccola verticale
		private static Label m_strlabelSV = new System.Windows.Forms.Label();
		private static Label m_hitlabelSV = new System.Windows.Forms.Label();
		private static Label m_dexlabelSV = new System.Windows.Forms.Label();
		private static Label m_stamlabelSV = new System.Windows.Forms.Label();
		private static Label m_intlabelSV = new System.Windows.Forms.Label();
		private static Label m_manalabelSV = new System.Windows.Forms.Label();
		private static Label m_weightlabelSV = new System.Windows.Forms.Label();
		private static Label m_weightmaxlabelSV = new System.Windows.Forms.Label();
		private static Label m_followerlabelSV = new System.Windows.Forms.Label();

		// Grande orizzontale e verticale
		private static Label m_labelBarHitsBHV = new System.Windows.Forms.Label();
		private static Label m_labelTextHitsBHV = new System.Windows.Forms.Label();
		private static Label m_labelTextManaBHV = new System.Windows.Forms.Label();
		private static Label m_labelBarManaBHV = new System.Windows.Forms.Label();
		private static Label m_labelBarStaminaBHV = new System.Windows.Forms.Label();
		private static Label m_labelTextStaminaBHV = new System.Windows.Forms.Label();
		private static Label m_labelTextWeightBHV = new System.Windows.Forms.Label();
		private static Label m_labelTextFollowerBHV = new System.Windows.Forms.Label();

		private static List<Panel> m_panellist = new List<Panel>();
		private static List<Label> m_panelcount = new List<Label>();

		[Serializable]
		public class ToolBarItem
		{
			private string m_Name;
			public string Name { get { return m_Name; } }

			private int m_Graphics;
			public int Graphics { get { return m_Graphics; } }

			private int m_Color;
			public int Color { get { return m_Color; } }

			private bool m_Warning;
			internal bool Warning { get { return m_Warning; } }

			private int m_WarningLimit;
			public int WarningLimit { get { return m_WarningLimit; } }

			public ToolBarItem(string name, int graphics, int color, bool warning, int warninglimit)
			{
				m_Name = name;
				m_Graphics = graphics;
				m_Color = color;
				m_Warning = warning;
				m_WarningLimit = warninglimit;
			}
		}

		internal static void UpdateHits(int maxhits, int hits)
		{
			if (m_form == null)
				return;

			if (RazorEnhanced.Settings.General.ReadString("ToolBoxSizeComboBox") == "Big")
			{
				int percent = (int)(hits * 100 / (maxhits == 0 ? (ushort)1 : maxhits));

				m_labelTextHitsBHV.Text = "Hits: " + hits.ToString() + " / " + maxhits.ToString();
				m_labelBarHitsBHV.Size = RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox") == "Vertical" ? new System.Drawing.Size(percent, 10) : new System.Drawing.Size(percent, 5);
				m_labelBarHitsBHV.BackColor = GetColor(percent);
			} 
			else
			{
				if (RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox") == "Vertical")
				{
					m_strlabelSV.Text = "S: " + maxhits.ToString();
					m_hitlabelSV.Text = "H: " + hits.ToString();
				}
				else
				{
					m_hitslabelSH.Text = "H: " + hits.ToString() + " / " + maxhits.ToString();
				}
			}
		}

		internal static void UpdateStam(int maxstam, int stam)
		{
			if (m_form == null)
				return;

			if (RazorEnhanced.Settings.General.ReadString("ToolBoxSizeComboBox") == "Big")
			{
				int percent = (int)(stam * 100 / (maxstam == 0 ? (ushort)1 : maxstam));

				m_labelTextStaminaBHV.Text = "Stam: " + stam.ToString() + " / " + maxstam.ToString();
				m_labelBarStaminaBHV.Size = RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox") == "Vertical" ? new System.Drawing.Size(percent, 10) : new System.Drawing.Size(percent, 5);
				m_labelBarStaminaBHV.BackColor = GetColor(percent);
			}
			else
			{
				if (RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox") == "Vertical")
				{
					m_dexlabelSV.Text = "D: " + maxstam.ToString();
					m_stamlabelSV.Text = "S: " + stam.ToString();
				}
				else
				{
					m_staminalabelSH.Text = "S: " + stam.ToString() + " / " + maxstam.ToString();
				}
			}
		}

		internal static void UpdateMana(int maxmana, int mana)
		{
			if (m_form == null)
				return;

			if (RazorEnhanced.Settings.General.ReadString("ToolBoxSizeComboBox") == "Big")
			{
				int percent = (int)(mana * 100 / (maxmana == 0 ? (ushort)1 : maxmana));

				m_labelTextManaBHV.Text = "Mana: " + mana.ToString() + " / " + maxmana.ToString();
				m_labelBarManaBHV.Size = RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox") == "Vertical" ? new System.Drawing.Size(percent, 10) : new System.Drawing.Size(percent, 5);
				m_labelBarManaBHV.BackColor = GetColor(percent);
			}
			else
			{
				if (RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox") == "Vertical")
				{
					m_intlabelSV.Text = "I: " + maxmana.ToString();
					m_manalabelSV.Text = "M: " + mana.ToString();
				}
				else
				{
					m_manalabelSH.Text = "M: " + mana.ToString() + " / " + maxmana.ToString();
				}
			}
		}

		internal static void UpdateWeight(int maxweight, int weight)
		{
			if (m_form == null)
				return;

			if (RazorEnhanced.Settings.General.ReadString("ToolBoxSizeComboBox") == "Big")
			{
				m_labelTextWeightBHV.Text = "Weight: " + weight.ToString() + " / " + maxweight.ToString();
			}
			else
			{
				if (RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox") == "Vertical")
				{
					m_weightlabelSV.Text = "W: " + weight.ToString();
					m_weightmaxlabelSV.Text = "L: " + maxweight.ToString();
				}
				else
				{
					m_weightlabelSH.Text = "W: " + weight.ToString() + " / " + maxweight.ToString();
				}
			}
		}

		internal static void UpdateFollower()
		{
			if (m_form == null)
				return;

			if (RazorEnhanced.Settings.General.ReadString("ToolBoxSizeComboBox") == "Big")
			{
				m_labelTextFollowerBHV.Text = "Follower: " + World.Player.Followers.ToString() + " / " + World.Player.FollowersMax.ToString();
			}
			else
			{
				if (RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox") == "Vertical")
				{
					m_followerlabelSV.Text = "F: " + World.Player.Followers.ToString();
				}
				else
				{
					m_followerlabelSH.Text = "F: " + World.Player.Followers.ToString() + " / " + World.Player.FollowersMax.ToString();
				}
			}
		}


		private static Color GetColor(int percent)
		{
			if (percent <= 10)
				return Color.DarkViolet;
			else if (percent > 10 && percent <= 30)
				return Color.DarkRed;
			else if (percent > 30 && percent <= 50)
				return Color.DarkOrange;
			else if (percent > 50 && percent <= 70)
				return Color.Goldenrod;
			else if (percent > 70 && percent <= 90)
				return Color.Gold;
			else
				return Color.ForestGreen;
		}

		internal static void Close()
		{
			if (m_form == null)
				return;

			Settings.General.WriteInt("PosXToolBar", m_form.Location.X);
			Settings.General.WriteInt("PosYToolBar", m_form.Location.Y);
			m_form.Close();
			m_form = null;
			m_slot = 0;
		}

		internal static void LockUnlock()
		{
			if (m_form == null)
				return;

			m_lock = !m_lock;
			m_form.ContextMenu = GeneraMenu();
			m_form.Refresh();
			Settings.General.WriteInt("PosXToolBar", m_form.Location.X);
			Settings.General.WriteInt("PosYToolBar", m_form.Location.Y);
		}

		internal static void Open()
		{
			if (Assistant.World.Player == null)
				return;

			if (m_form == null)
				DrawToolBar();

			UpdateAll();
			UpdatePanelImage();
			UpdateCount();
			ClientCommunication.ShowWindow(m_form.Handle, 8);
			m_form.Location = new System.Drawing.Point(Settings.General.ReadInt("PosXToolBar"), Settings.General.ReadInt("PosYToolBar"));
			m_form.Opacity = ((double)RazorEnhanced.Settings.General.ReadInt("ToolBarOpacity")) / 100.0; ;
		}

		internal static void UptateToolBarComboBox(int index)
		{
			List<RazorEnhanced.ToolBar.ToolBarItem> items = RazorEnhanced.Settings.Toolbar.ReadItems();
			Assistant.Engine.MainWindow.ToolBoxCountComboBox.Items.Clear();
			int i = 0;
			foreach (RazorEnhanced.ToolBar.ToolBarItem item in items)
			{
				Assistant.Engine.MainWindow.ToolBoxCountComboBox.Items.Add("Slot " + i + ": " + item.Name);
				i++;
			}
			Assistant.Engine.MainWindow.ToolBoxCountComboBox.SelectedIndex = index;
		}

		internal static void UpdatePanelImage()
		{
			if (m_form == null)
				return;

			List<RazorEnhanced.ToolBar.ToolBarItem> items = RazorEnhanced.Settings.Toolbar.ReadItems();

			for (int x = 0; x < m_slot; x++)
			{
				if (items[x].Graphics != 0)
				{
					Bitmap m_itemimage = new Bitmap(Ultima.Art.GetStatic(items[x].Graphics));
					if (RazorEnhanced.Settings.General.ReadString("ToolBoxSizeComboBox") == "Big")
					{
						if (items[x].Color > 0)
						{
							int hue = items[x].Color;
							bool onlyHueGrayPixels = (hue & 0x8000) != 0;
							hue = (hue & 0x3FFF) - 1;
							Ultima.Hue m_hue = Ultima.Hues.GetHue(hue);
							m_hue.ApplyTo(m_itemimage, onlyHueGrayPixels);
						}
						m_panellist[x].BackgroundImage = m_itemimage;
                    }
					else
						m_panellist[x].BackgroundImage = ResizeImage(m_itemimage, Convert.ToInt16(m_itemimage.Width / 1.5), Convert.ToInt16(m_itemimage.Height / 1.5));


					m_panellist[x].Enabled = true;
					m_panelcount[x].Text = "0";
					m_panellist[x].BackColor = SystemColors.Control;
				}
				else
				{
					m_panellist[x].BackgroundImage = null;
					m_panellist[x].BackColor = Color.Transparent;
					m_panellist[x].Enabled = false;
					m_panelcount[x].Text = "";
				}
			}
		}

     	internal static void UpdateAll()
		{
			if (Assistant.World.Player != null)
			{
				UpdateHits(Assistant.World.Player.HitsMax, Assistant.World.Player.Hits);
				UpdateStam(Assistant.World.Player.StamMax, Assistant.World.Player.Stam);
				UpdateMana(Assistant.World.Player.ManaMax, Assistant.World.Player.Mana);
				UpdateWeight(Assistant.World.Player.MaxWeight, Assistant.World.Player.Weight);
				UpdateFollower();
				UpdateCount();
			}
		}

		internal static void UpdateCount()
		{
			if (Assistant.World.Player == null || m_form == null) // || m_changingmap)
				return;

			List<RazorEnhanced.ToolBar.ToolBarItem> items = RazorEnhanced.Settings.Toolbar.ReadItems();

			for (int x = 0; x < m_slot; x++)
			{
				if (items[x].Graphics == 0)
					continue;

				int amount = Items.BackpackCount(items[x].Graphics, items[x].Color);
				int oldamount = Convert.ToInt32(m_panelcount[x].Text);
				m_panelcount[x].Text = amount.ToString();

				if (!items[x].Warning)
					continue;

				if (amount <= items[x].WarningLimit)
				{
					m_panellist[x].BackColor = Color.Orange;
					if (amount < oldamount)
					{
						RazorEnhanced.Misc.SendMessage("COUNTER WARNING: Item: " + items[x].Name + " under limit left: " + amount.ToString());
					}
				}
				else
				{
					m_panellist[x].BackColor = SystemColors.Control;
				}
			}
		}

		//////////////// Load settings ////////////////
		internal static void LoadSettings()
		{
			Assistant.Engine.MainWindow.ToolBoxCountComboBox.Items.Clear();

			Assistant.Engine.MainWindow.ToolBoxSizeComboBox.Items.Clear();
			Assistant.Engine.MainWindow.ToolBoxSizeComboBox.Items.Add("Big");
			Assistant.Engine.MainWindow.ToolBoxSizeComboBox.Items.Add("Small");

			Assistant.Engine.MainWindow.ToolBoxStyleComboBox.Items.Clear();
			Assistant.Engine.MainWindow.ToolBoxStyleComboBox.Items.Add("Horizontal");
			Assistant.Engine.MainWindow.ToolBoxStyleComboBox.Items.Add("Vertical");

			Assistant.Engine.MainWindow.LockToolBarCheckBox.Checked = m_lock = RazorEnhanced.Settings.General.ReadBool("LockToolBarCheckBox");
			Assistant.Engine.MainWindow.AutoopenToolBarCheckBox.Checked = RazorEnhanced.Settings.General.ReadBool("AutoopenToolBarCheckBox");
			Assistant.Engine.MainWindow.LocationToolBarLabel.Text = "X: " + RazorEnhanced.Settings.General.ReadInt("PosXToolBar") + " - Y:" + RazorEnhanced.Settings.General.ReadInt("PosYToolBar");
			Assistant.Engine.ToolBarX = RazorEnhanced.Settings.General.ReadInt("PosXToolBar");
			Assistant.Engine.ToolBarY = RazorEnhanced.Settings.General.ReadInt("PosYToolBar");

			Assistant.Engine.MainWindow.ToolBoxSizeComboBox.SelectedItem = RazorEnhanced.Settings.General.ReadString("ToolBoxSizeComboBox");
			Assistant.Engine.MainWindow.ToolBoxStyleComboBox.SelectedItem = RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox");
			Assistant.Engine.MainWindow.ToolBoxSlotsLabel.Text = RazorEnhanced.Settings.General.ReadInt("ToolBoxSlotsTextBox").ToString();
			Assistant.Engine.MainWindow.ShowHitsToolBarCheckBox.Checked = RazorEnhanced.Settings.General.ReadBool("ShowHitsToolBarCheckBox");
			Assistant.Engine.MainWindow.ShowStaminaToolBarCheckBox.Checked = RazorEnhanced.Settings.General.ReadBool("ShowStaminaToolBarCheckBox");
			Assistant.Engine.MainWindow.ShowManaToolBarCheckBox.Checked = RazorEnhanced.Settings.General.ReadBool("ShowManaToolBarCheckBox");
			Assistant.Engine.MainWindow.ShowWeightToolBarCheckBox.Checked = RazorEnhanced.Settings.General.ReadBool("ShowWeightToolBarCheckBox");
			Assistant.Engine.MainWindow.ShowFollowerToolBarCheckBox.Checked = RazorEnhanced.Settings.General.ReadBool("ShowFollowerToolBarCheckBox");

			List<RazorEnhanced.ToolBar.ToolBarItem> items = RazorEnhanced.Settings.Toolbar.ReadItems();

			int i = 0;
			foreach (RazorEnhanced.ToolBar.ToolBarItem item in items)
			{
				Assistant.Engine.MainWindow.ToolBoxCountComboBox.Items.Add("Slot " + i + ": " + item.Name);
				i++;
			}
			Assistant.Engine.MainWindow.ToolBoxCountComboBox.SelectedIndex = 0;
		}


		////////////////////////////////////////////////////
		//////////////// DRAW TOOLBAR START ////////////////
		////////////////////////////////////////////////////

		internal static void DrawToolBar()
		{
			m_slot = RazorEnhanced.Settings.General.ReadInt("ToolBoxSlotsTextBox");

            if (RazorEnhanced.Settings.General.ReadString("ToolBoxSizeComboBox") == "Big")
			{
				if (RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox") == "Vertical")
				{
					DrawToolBarBV();
				}
				else
				{
					DrawToolBarBH();
				}
			}
			else
			{
				if (RazorEnhanced.Settings.General.ReadString("ToolBoxStyleComboBox") == "Vertical")
				{
					DrawToolBarSV();
				}
				else
				{
					DrawToolBarSH();
				}
			}
				
		}

		//////////////////////////////////////////////////////////////
		// Context Menu
		//////////////////////////////////////////////////////////////

		internal static ContextMenu GeneraMenu()
		{
			ContextMenu cm = new ContextMenu();
			MenuItem menuItem = new MenuItem();
			menuItem.Text = "Close";
			menuItem.Click += new System.EventHandler(menuItemClose_Click);
            cm.MenuItems.Add(menuItem);

			menuItem = new MenuItem();
			if (m_lock)
			{
				menuItem.Text = "UnLock";
				menuItem.Click += new System.EventHandler(menuItemUnLock_Click);	
			}
			else
			{
				menuItem.Text = "Lock";
				menuItem.Click += new System.EventHandler(menuItemLock_Click);
			}
			cm.MenuItems.Add(menuItem);

			return cm;
		}

		private static void menuItemClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}
		private static void menuItemUnLock_Click(object sender, System.EventArgs e)
		{
			LockUnlock();
			Settings.General.WriteBool("LockToolBarCheckBox", m_lock);
			Engine.MainWindow.LockToolBarCheckBox.Checked = m_lock;

		}
		private static void menuItemLock_Click(object sender, System.EventArgs e)
		{
			LockUnlock();
			Settings.General.WriteBool("LockToolBarCheckBox", m_lock);
			Engine.MainWindow.LockToolBarCheckBox.Checked = m_lock;
		}

		//////////////////////////////////////////////////////////////
		// Fine context menu
		//////////////////////////////////////////////////////////////

		//////////////////////////////////////////////////////////////
		// Form Dragmove start
		//////////////////////////////////////////////////////////////

		private static bool m_mouseDown;
		private static Point m_lastLocation;

		internal static void ToolbarForm_MouseDown(object sender, MouseEventArgs e)
		{
			if (m_lock)
				return;

			m_mouseDown = true;
			m_lastLocation = e.Location;
		}

		internal static void ToolbarForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (m_lock)
				return;

			if (!m_mouseDown)
				return;

			ToolBarForm.Location = new Point(
				(ToolBarForm.Location.X - m_lastLocation.X) + e.X, (ToolBarForm.Location.Y - m_lastLocation.Y) + e.Y);

			ToolBarForm.Update();
		}

		internal static void ToolbarForm_MouseUp(object sender, MouseEventArgs e)
		{
			if (!m_lock)
				m_mouseDown = false;
		}

		internal static void ToolbarForm_MouseClick(object sender, MouseEventArgs e)
		{
			ClientCommunication.SetForegroundWindow(ClientCommunication.FindUOWindow());
		}

		internal static void InitEvent()
		{
			foreach (Control control in m_form.Controls)
			{
				control.MouseDown += new System.Windows.Forms.MouseEventHandler(ToolbarForm_MouseDown);
				control.MouseMove += new System.Windows.Forms.MouseEventHandler(ToolbarForm_MouseMove);
				control.MouseUp += new System.Windows.Forms.MouseEventHandler(ToolbarForm_MouseUp);
				control.MouseClick += new System.Windows.Forms.MouseEventHandler(ToolbarForm_MouseClick);
				control.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(ToolBar.ToolbarForm_MouseClick);
			}
		}

		//////////////////////////////////////////////////////////////
		// Form DragMove fine
		//////////////////////////////////////////////////////////////

		//////////////////////////////////////////////////////////////
		// Inizio barre
		//////////////////////////////////////////////////////////////

		private static void DrawToolBarBV() // Grande Verticale
		{
			m_panellist = new List<Panel>();
			m_panelcount = new List<Label>();
			m_labelBarHitsBHV = new System.Windows.Forms.Label();
			m_labelTextHitsBHV = new System.Windows.Forms.Label();
			m_labelTextManaBHV = new System.Windows.Forms.Label();
			m_labelBarManaBHV = new System.Windows.Forms.Label();
			m_labelBarStaminaBHV = new System.Windows.Forms.Label();
			m_labelTextStaminaBHV = new System.Windows.Forms.Label();
			m_labelTextWeightBHV = new System.Windows.Forms.Label();
			m_labelTextFollowerBHV = new System.Windows.Forms.Label();

			m_form = new ToolBarForm();

			// Sfondo e parametri offset
			Bitmap sfondotemporaneo = Assistant.Properties.Resources.BarraGrandeVerticaleBordoSopra;
			int height = Assistant.Properties.Resources.BarraGrandeVerticaleBordoSopra.Height + Assistant.Properties.Resources.BarraGrandeVerticaleBordoSotto.Height;
			int offsetstat = 9;
			int paneloffset = 18;
			height += (m_slot * 60) / 2; // Aggiungo spazio slot

			if (RazorEnhanced.Settings.General.ReadBool("ShowHitsToolBarCheckBox"))
			{
				m_labelBarHitsBHV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
				m_labelBarHitsBHV.Location = new System.Drawing.Point(12, offsetstat + 16);
				m_labelBarHitsBHV.Name = "labelBarHits";
				m_labelBarHitsBHV.Size = new System.Drawing.Size(100, 10);
				m_labelBarHitsBHV.TabIndex = 0;
				m_labelBarHitsBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_labelTextHitsBHV.BackColor = System.Drawing.Color.Transparent;
				m_labelTextHitsBHV.Location = new System.Drawing.Point(12, offsetstat);
				m_labelTextHitsBHV.Name = "labelTextHits";
				m_labelTextHitsBHV.Size = new System.Drawing.Size(100, 16);
				m_labelTextHitsBHV.TabIndex = 1;
				m_labelTextHitsBHV.Text = "Hits: 150/150";
				m_labelTextHitsBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_form.Controls.Add(m_labelBarHitsBHV);
				m_form.Controls.Add(m_labelTextHitsBHV);

				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraGrandeVerticaleSpazioStat);

				height += 29;
				offsetstat += 30;
				paneloffset += 29;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowManaToolBarCheckBox"))
			{
				m_labelBarManaBHV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
				m_labelBarManaBHV.Location = new System.Drawing.Point(12, offsetstat + 16);
				m_labelBarManaBHV.Name = "labelBarMana";
				m_labelBarManaBHV.Size = new System.Drawing.Size(100, 10);
				m_labelBarManaBHV.TabIndex = 2;
				m_labelBarManaBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_labelTextManaBHV.BackColor = System.Drawing.Color.Transparent;
				m_labelTextManaBHV.Location = new System.Drawing.Point(12, offsetstat);
				m_labelTextManaBHV.Name = "labelTextMana";
				m_labelTextManaBHV.Size = new System.Drawing.Size(100, 16);
				m_labelTextManaBHV.TabIndex = 3;
				m_labelTextManaBHV.Text = "Mana: 150/150";
				m_labelTextManaBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_form.Controls.Add(m_labelBarManaBHV);
				m_form.Controls.Add(m_labelTextManaBHV);

				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraGrandeVerticaleSpazioStat);

				height += 29;
				offsetstat += 30;
				paneloffset += 29;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowStaminaToolBarCheckBox"))
			{
				m_labelBarStaminaBHV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
				m_labelBarStaminaBHV.Location = new System.Drawing.Point(12, offsetstat + 16);
				m_labelBarStaminaBHV.Name = "labelBarStamina";
				m_labelBarStaminaBHV.Size = new System.Drawing.Size(100, 10);
				m_labelBarStaminaBHV.TabIndex = 4;
				m_labelBarStaminaBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_labelTextStaminaBHV.BackColor = System.Drawing.Color.Transparent;
				m_labelTextStaminaBHV.Location = new System.Drawing.Point(12, offsetstat);
				m_labelTextStaminaBHV.Name = "labelTextStamina";
				m_labelTextStaminaBHV.Size = new System.Drawing.Size(100, 16);
				m_labelTextStaminaBHV.TabIndex = 5;
				m_labelTextStaminaBHV.Text = "Stam: 150/150";
				m_labelTextStaminaBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_form.Controls.Add(m_labelBarStaminaBHV);
				m_form.Controls.Add(m_labelTextStaminaBHV);

				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraGrandeVerticaleSpazioStat);

				height += 29;
				offsetstat += 30;
				paneloffset += 29;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowWeightToolBarCheckBox"))
			{
				m_labelTextWeightBHV.BackColor = System.Drawing.Color.Transparent;
				m_labelTextWeightBHV.Location = new System.Drawing.Point(12, offsetstat + 6);
				m_labelTextWeightBHV.Name = "labelTextWeight";
				m_labelTextWeightBHV.Size = new System.Drawing.Size(100, 16);
				m_labelTextWeightBHV.TabIndex = 5;
				m_labelTextWeightBHV.Text = "Weight: 150/150";
				m_labelTextWeightBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_form.Controls.Add(m_labelTextWeightBHV);

				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraGrandeVerticaleSpazioStat);

				height += 29;
				offsetstat += 30;
				paneloffset += 29;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowFollowerToolBarCheckBox"))
			{
				m_labelTextFollowerBHV.BackColor = System.Drawing.Color.Transparent;
				m_labelTextFollowerBHV.Location = new System.Drawing.Point(12, offsetstat + 6);
				m_labelTextFollowerBHV.Name = "labelTextFollower";
				m_labelTextFollowerBHV.Size = new System.Drawing.Size(100, 16);
				m_labelTextFollowerBHV.TabIndex = 5;
				m_labelTextFollowerBHV.Text = "Follower: 5/5";
				m_labelTextFollowerBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_form.Controls.Add(m_labelTextFollowerBHV);

				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraGrandeVerticaleSpazioStat);

				height += 29;
				offsetstat += 30;
				paneloffset += 29;
			}

			for (int i = 0; i < m_slot; i += 2)
			{
				//Genero sfondo slot
				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraGrandeVerticaleSlot);

				// Aggiungo panel dinamici
				Panel paneltemp1 = new Panel();
				Panel paneltemp2 = new Panel();
				Label labeltemp1 = new Label
				{
					AutoSize = true,
					Location = new System.Drawing.Point(0, 29),
					Font =
						new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular,
							System.Drawing.GraphicsUnit.Point, ((byte) (0))),
					Name = "panel" + i + "count",
					Size = new System.Drawing.Size(25, 13),
					TabIndex = 1,
					Text = "000"
				};


				labeltemp1.SuspendLayout();

				paneltemp1.BackColor = Color.Transparent;
				paneltemp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
				paneltemp1.Controls.Add(labeltemp1);
				paneltemp1.Location = new System.Drawing.Point(11, paneloffset);
				paneltemp1.Margin = new System.Windows.Forms.Padding(0);
				paneltemp1.Name = "panel" + i + 1;
				paneltemp1.Size = new System.Drawing.Size(42, 42);
				paneltemp1.TabIndex = 10;

				Label labeltemp2 = new Label();
				labeltemp2.AutoSize = true;
				labeltemp2.Location = new System.Drawing.Point(0, 29);
				labeltemp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				labeltemp2.Name = "panel" + i + "count";
				labeltemp2.Size = new System.Drawing.Size(25, 13);
				labeltemp2.TabIndex = 1;
				labeltemp2.Text = "000";
				labeltemp2.SuspendLayout();

				paneltemp2.BackColor = Color.Transparent;
				paneltemp2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
				paneltemp2.Controls.Add(labeltemp2);
				paneltemp2.Location = new System.Drawing.Point(71, paneloffset);
				paneltemp2.Margin = new System.Windows.Forms.Padding(0);
				paneltemp2.Name = "panel" + i + 1;
				paneltemp2.Size = new System.Drawing.Size(42, 42);
				paneltemp2.TabIndex = 10;

				m_panellist.Add(paneltemp1);
				m_panelcount.Add(labeltemp1);
				m_panellist.Add(paneltemp2);
				m_panelcount.Add(labeltemp2);
				m_form.SuspendLayout();

				paneltemp1.SuspendLayout();
				m_form.Controls.Add(paneltemp1);
				paneltemp2.SuspendLayout();
				m_form.Controls.Add(paneltemp2);

				paneloffset += 60;
			}

			m_form.ClientSize = new System.Drawing.Size(Assistant.Properties.Resources.BarraGrandeVerticaleBordoSopra.Width, height);

			m_form.BackgroundImage = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraGrandeVerticaleBordoSotto);
			InitEvent();
		}

		private static void DrawToolBarBH() // Grande Orizzontale
		{
			m_panellist = new List<Panel>();
			m_panelcount = new List<Label>();

			m_labelBarHitsBHV = new System.Windows.Forms.Label();
			m_labelTextHitsBHV = new System.Windows.Forms.Label();
			m_labelTextManaBHV = new System.Windows.Forms.Label();
			m_labelBarManaBHV = new System.Windows.Forms.Label();
			m_labelBarStaminaBHV = new System.Windows.Forms.Label();
			m_labelTextStaminaBHV = new System.Windows.Forms.Label();
			m_labelTextWeightBHV = new System.Windows.Forms.Label();
			m_labelTextFollowerBHV = new System.Windows.Forms.Label();

			m_form = new ToolBarForm();

			int width = Assistant.Properties.Resources.BarraGrandeOrizzontaBordoDestro.Width + Assistant.Properties.Resources.BarraGrandeOrizzontaBordoSinistro.Width;
			int offsetstat = 10;
			int paneloffset = 18;


			// Genero Sfondo
			Bitmap sfondotemporaneo = Assistant.Properties.Resources.BarraGrandeOrizzontaBordoSinistro;

			if (RazorEnhanced.Settings.General.ReadBool("ShowHitsToolBarCheckBox") || RazorEnhanced.Settings.General.ReadBool("ShowStaminaToolBarCheckBox") || RazorEnhanced.Settings.General.ReadBool("ShowManaToolBarCheckBox") ||
				RazorEnhanced.Settings.General.ReadBool("ShowWeightToolBarCheckBox") || RazorEnhanced.Settings.General.ReadBool("ShowFollowerToolBarCheckBox"))
			{
				sfondotemporaneo = BackGroundAddOrizzontale(sfondotemporaneo, Assistant.Properties.Resources.BarraGrandeOrizzontaleSpazioStat);
				width += 106;
				paneloffset += 106;
			}


			if (RazorEnhanced.Settings.General.ReadBool("ShowHitsToolBarCheckBox"))
			{
				m_labelBarHitsBHV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
				m_labelBarHitsBHV.Location = new System.Drawing.Point(12, offsetstat + 16);
				m_labelBarHitsBHV.Name = "labelBarHits";
				m_labelBarHitsBHV.Size = new System.Drawing.Size(100, 5);
				m_labelBarHitsBHV.TabIndex = 0;
				m_labelBarHitsBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_labelTextHitsBHV.BackColor = System.Drawing.Color.Transparent;
				m_labelTextHitsBHV.Location = new System.Drawing.Point(12, offsetstat);
				m_labelTextHitsBHV.Name = "labelTextHits";
				m_labelTextHitsBHV.Size = new System.Drawing.Size(100, 16);
				m_labelTextHitsBHV.TabIndex = 1;
				m_labelTextHitsBHV.Text = "Hits: 150/150";
				m_labelTextHitsBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_form.Controls.Add(m_labelBarHitsBHV);
				m_form.Controls.Add(m_labelTextHitsBHV);

				offsetstat += 23;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowManaToolBarCheckBox"))
			{
				m_labelBarManaBHV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
				m_labelBarManaBHV.Location = new System.Drawing.Point(12, offsetstat + 16);
				m_labelBarManaBHV.Name = "labelBarMana";
				m_labelBarManaBHV.Size = new System.Drawing.Size(100, 5);
				m_labelBarManaBHV.TabIndex = 0;
				m_labelBarManaBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_labelTextManaBHV.BackColor = System.Drawing.Color.Transparent;
				m_labelTextManaBHV.Location = new System.Drawing.Point(12, offsetstat);
				m_labelTextManaBHV.Name = "labelTextMana";
				m_labelTextManaBHV.Size = new System.Drawing.Size(100, 16);
				m_labelTextManaBHV.TabIndex = 1;
				m_labelTextManaBHV.Text = "Mana: 150/150";
				m_labelTextManaBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_form.Controls.Add(m_labelBarManaBHV);
				m_form.Controls.Add(m_labelTextManaBHV);

				offsetstat += 23;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowStaminaToolBarCheckBox"))
			{
				m_labelBarStaminaBHV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
				m_labelBarStaminaBHV.Location = new System.Drawing.Point(12, offsetstat + 16);
				m_labelBarStaminaBHV.Name = "labelBarStamina";
				m_labelBarStaminaBHV.Size = new System.Drawing.Size(100, 5);
				m_labelBarStaminaBHV.TabIndex = 0;
				m_labelBarStaminaBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_labelTextStaminaBHV.BackColor = System.Drawing.Color.Transparent;
				m_labelTextStaminaBHV.Location = new System.Drawing.Point(12, offsetstat);
				m_labelTextStaminaBHV.Name = "labelTextStamina";
				m_labelTextStaminaBHV.Size = new System.Drawing.Size(100, 16);
				m_labelTextStaminaBHV.TabIndex = 1;
				m_labelTextStaminaBHV.Text = "Stam: 150/150";
				m_labelTextStaminaBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_form.Controls.Add(m_labelBarStaminaBHV);
				m_form.Controls.Add(m_labelTextStaminaBHV);

				offsetstat += 23;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowWeightToolBarCheckBox"))
			{
				m_labelTextWeightBHV.BackColor = System.Drawing.Color.Transparent;
				m_labelTextWeightBHV.Location = new System.Drawing.Point(12, offsetstat);
				m_labelTextWeightBHV.Name = "labelTextStamina";
				m_labelTextWeightBHV.Size = new System.Drawing.Size(100, 16);
				m_labelTextWeightBHV.TabIndex = 1;
				m_labelTextWeightBHV.Text = "Weight: 150/150";
				m_labelTextWeightBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_form.Controls.Add(m_labelTextWeightBHV);

				offsetstat += 18;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowFollowerToolBarCheckBox"))
			{
				m_labelTextFollowerBHV.BackColor = System.Drawing.Color.Transparent;
				m_labelTextFollowerBHV.Location = new System.Drawing.Point(12, offsetstat);
				m_labelTextFollowerBHV.Name = "labelTextFollower";
				m_labelTextFollowerBHV.Size = new System.Drawing.Size(100, 16);
				m_labelTextFollowerBHV.TabIndex = 1;
				m_labelTextFollowerBHV.Text = "Follower: 5/5";
				m_labelTextFollowerBHV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

				m_form.Controls.Add(m_labelTextFollowerBHV);

				offsetstat += 18;
			}

			width += (m_slot * 60) / 2; // Aggiungo spazio slot

			m_form.ClientSize = new System.Drawing.Size(width, Assistant.Properties.Resources.BarraGrandeOrizzontaBordoDestro.Height);

			for (int i = 0; i < m_slot; i += 2)
			{
				//Genero sfondo slot
				sfondotemporaneo = BackGroundAddOrizzontale(sfondotemporaneo, Assistant.Properties.Resources.BarraGrandeOrizzontaleSlot);

				// Aggiungo panel dinamici
				// Aggiungo panel dinamici
				Panel paneltemp1 = new Panel();
				Panel paneltemp2 = new Panel();

				Label labeltemp1 = new Label
				{
					AutoSize = true,
					Location = new System.Drawing.Point(0, 29),
					Font =
						new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular,
							System.Drawing.GraphicsUnit.Point, ((byte) (0))),
					Name = "panel" + i + "count",
					Size = new System.Drawing.Size(25, 13),
					TabIndex = 1,
					Text = "000"
				};

				labeltemp1.SuspendLayout();

				paneltemp1.BackColor = Color.Transparent;
				paneltemp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
				paneltemp1.Controls.Add(labeltemp1);
				paneltemp1.Location = new System.Drawing.Point(paneloffset, 11);
				paneltemp1.Margin = new System.Windows.Forms.Padding(0);
				paneltemp1.Name = "panel" + i + 1;
				paneltemp1.Size = new System.Drawing.Size(42, 42);
				paneltemp1.TabIndex = 10;

				Label labeltemp2 = new Label
				{
					AutoSize = true,
					Location = new System.Drawing.Point(0, 29),
					Font =
						new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular,
							System.Drawing.GraphicsUnit.Point, ((byte) (0))),
					Name = "panel" + i + "count",
					Size = new System.Drawing.Size(25, 13),
					TabIndex = 1,
					Text = "000"
				};

				labeltemp2.SuspendLayout();

				paneltemp2.BackColor = Color.Transparent;
				paneltemp2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
				paneltemp2.Controls.Add(labeltemp2);
				paneltemp2.Location = new System.Drawing.Point(paneloffset, 71);
				paneltemp2.Margin = new System.Windows.Forms.Padding(0);
				paneltemp2.Name = "panel" + i + 1;
				paneltemp2.Size = new System.Drawing.Size(42, 42);
				paneltemp2.TabIndex = 10;

				m_panellist.Add(paneltemp1);
				m_panelcount.Add(labeltemp1);
				m_panellist.Add(paneltemp2);
				m_panelcount.Add(labeltemp2);
				m_form.SuspendLayout();

				paneltemp1.SuspendLayout();
				m_form.Controls.Add(paneltemp1);
				paneltemp2.SuspendLayout();
				m_form.Controls.Add(paneltemp2);

				paneloffset += 60;
			}

			m_form.BackgroundImage = BackGroundAddOrizzontale(sfondotemporaneo, Assistant.Properties.Resources.BarraGrandeOrizzontaBordoDestro);
			InitEvent();
		}

		private static void DrawToolBarSV() // Piccola Verticale
		{
			m_panellist = new List<Panel>();
			m_panelcount = new List<Label>();

			m_strlabelSV = new System.Windows.Forms.Label();
		    m_hitlabelSV = new System.Windows.Forms.Label();
		    m_dexlabelSV = new System.Windows.Forms.Label();
		    m_stamlabelSV = new System.Windows.Forms.Label();
			m_intlabelSV = new System.Windows.Forms.Label();
			m_manalabelSV = new System.Windows.Forms.Label();
			m_weightlabelSV = new System.Windows.Forms.Label();
			m_weightmaxlabelSV = new System.Windows.Forms.Label();
			m_followerlabelSV = new System.Windows.Forms.Label();

			m_form = new ToolBarForm();

			// Sfondo e parametri offset
			Bitmap sfondotemporaneo = Assistant.Properties.Resources.BarraVerticaleBordoSopra;
			int height = Assistant.Properties.Resources.BarraVerticaleBordoSopra.Height + Assistant.Properties.Resources.BarraVerticaleBordoSotto.Height;
			int offsetstat = 8;
			int paneloffset = 12;
			height += (m_slot * 36); // Aggiungo spazio slot

			if (RazorEnhanced.Settings.General.ReadBool("ShowHitsToolBarCheckBox"))
			{
				m_strlabelSV.AutoSize = true;
				m_strlabelSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_strlabelSV.Location = new System.Drawing.Point(5, offsetstat);
				m_strlabelSV.Name = "label1";
				m_strlabelSV.Size = new System.Drawing.Size(50, 12);
				m_strlabelSV.TabIndex = 0;
				m_strlabelSV.Text = "S: 999";

				m_hitlabelSV.AutoSize = true;
				m_hitlabelSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_hitlabelSV.Location = new System.Drawing.Point(5, offsetstat + 13);
				m_hitlabelSV.Name = "label1";
				m_hitlabelSV.Size = new System.Drawing.Size(50, 12);
				m_hitlabelSV.TabIndex = 0;
				m_hitlabelSV.Text = "H: 999";

				m_form.Controls.Add(m_strlabelSV);
				m_form.Controls.Add(m_hitlabelSV);

				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraVerticaleSpazioStat);

				height += 29;
				offsetstat += 30;
				paneloffset += 29;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowManaToolBarCheckBox"))
			{
				m_intlabelSV.AutoSize = true;
				m_intlabelSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_intlabelSV.Location = new System.Drawing.Point(5, offsetstat);
				m_intlabelSV.Name = "label1";
				m_intlabelSV.Size = new System.Drawing.Size(50, 12);
				m_intlabelSV.TabIndex = 0;
				m_intlabelSV.Text = "I: 999";

				m_manalabelSV.AutoSize = true;
				m_manalabelSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_manalabelSV.Location = new System.Drawing.Point(5, offsetstat + 13);
				m_manalabelSV.Name = "label1";
				m_manalabelSV.Size = new System.Drawing.Size(48, 12);
				m_manalabelSV.TabIndex = 0;
				m_manalabelSV.Text = "M: 200";


				m_form.Controls.Add(m_intlabelSV);
				m_form.Controls.Add(m_manalabelSV);

				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraVerticaleSpazioStat);

				height += 29;
				offsetstat += 30;
				paneloffset += 29;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowStaminaToolBarCheckBox"))
			{
				m_dexlabelSV.AutoSize = true;
				m_dexlabelSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_dexlabelSV.Location = new System.Drawing.Point(5, offsetstat);
				m_dexlabelSV.Name = "label1";
				m_dexlabelSV.Size = new System.Drawing.Size(50, 12);
				m_dexlabelSV.TabIndex = 0;
				m_dexlabelSV.Text = "D: 999";

				m_stamlabelSV.AutoSize = true;
				m_stamlabelSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_stamlabelSV.Location = new System.Drawing.Point(5, offsetstat + 13);
				m_stamlabelSV.Name = "label1";
				m_stamlabelSV.Size = new System.Drawing.Size(50, 12);
				m_stamlabelSV.TabIndex = 0;
				m_stamlabelSV.Text = "S: 999";

				m_form.Controls.Add(m_dexlabelSV);
				m_form.Controls.Add(m_stamlabelSV);

				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraVerticaleSpazioStat);

				height += 29;
				offsetstat += 30;
				paneloffset += 29;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowWeightToolBarCheckBox"))
			{
				m_weightlabelSV.AutoSize = true;
				m_weightlabelSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_weightlabelSV.Location = new System.Drawing.Point(5, offsetstat);
				m_weightlabelSV.Name = "label1";
				m_weightlabelSV.Size = new System.Drawing.Size(50, 12);
				m_weightlabelSV.TabIndex = 0;
				m_weightlabelSV.Text = "W: 999";

				m_weightmaxlabelSV.AutoSize = true;
				m_weightmaxlabelSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_weightmaxlabelSV.Location = new System.Drawing.Point(5, offsetstat + 13);
				m_weightmaxlabelSV.Name = "label1";
				m_weightmaxlabelSV.Size = new System.Drawing.Size(50, 12);
				m_weightmaxlabelSV.TabIndex = 0;
				m_weightmaxlabelSV.Text = "W: 999";


				m_form.Controls.Add(m_weightlabelSV);
				m_form.Controls.Add(m_weightmaxlabelSV);

				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraVerticaleSpazioStat);

				height += 29;
				offsetstat += 30;
				paneloffset += 29;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowFollowerToolBarCheckBox"))
			{
				m_followerlabelSV.AutoSize = true;
				m_followerlabelSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_followerlabelSV.Location = new System.Drawing.Point(5, offsetstat + 7);
				m_followerlabelSV.Name = "label1";
				m_followerlabelSV.Size = new System.Drawing.Size(50, 12);
				m_followerlabelSV.TabIndex = 0;
				m_followerlabelSV.Text = "F: 5";

				m_form.Controls.Add(m_followerlabelSV);

				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraVerticaleSpazioStat);

				height += 29;
				offsetstat += 30;
				paneloffset += 29;
			}

			for (int i = 0; i < m_slot; i++)
			{
				//Genero sfondo slot
				sfondotemporaneo = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraVerticaleSlot);

				// Aggiungo panel dinamici
				Panel paneltemp = new Panel();
				Label labeltemp = new Label
				{
					AutoSize = true,
					Location = new System.Drawing.Point(0, 18),
					Font =
						new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular,
							System.Drawing.GraphicsUnit.Point, ((byte) (0))),
					Name = "panel" + i + "count",
					Size = new System.Drawing.Size(10, 20),
					TabIndex = 1,
					Text = "000"
				};

				labeltemp.SuspendLayout();

				paneltemp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
				paneltemp.BackColor = Color.Transparent;
				paneltemp.Controls.Add(labeltemp);
				paneltemp.Location = new System.Drawing.Point(6, paneloffset);
				paneltemp.Margin = new System.Windows.Forms.Padding(0);
				paneltemp.Name = "panel" + i;
				paneltemp.Size = new System.Drawing.Size(29, 29);
				paneltemp.TabIndex = 15;

				m_panellist.Add(paneltemp);
				m_panelcount.Add(labeltemp);
				m_form.SuspendLayout();
				paneltemp.SuspendLayout();
				m_form.Controls.Add(paneltemp);

				paneloffset += 36;
			}

			m_form.ClientSize = new System.Drawing.Size(Assistant.Properties.Resources.BarraVerticaleBordoSopra.Width, height);

			m_form.BackgroundImage = BackGroundAddVerticale(sfondotemporaneo, Assistant.Properties.Resources.BarraVerticaleBordoSotto);
			InitEvent();
		}

		private static void DrawToolBarSH() // Piccola Orizzontale
		{
			m_panellist = new List<Panel>();
			m_panelcount = new List<Label>();

			m_hitslabelSH = new System.Windows.Forms.Label();
			m_manalabelSH = new System.Windows.Forms.Label();
			m_staminalabelSH = new System.Windows.Forms.Label();
			m_weightlabelSH = new System.Windows.Forms.Label();
			m_followerlabelSH = new System.Windows.Forms.Label();
			
			m_form = new ToolBarForm();

			int width = Assistant.Properties.Resources.BarraOrizzontaBordoDestro.Width + Assistant.Properties.Resources.BarraOrizzontaBordoSinistro.Width;
			int offsetstat = 5;
			int paneloffset = 11;

			// Genero Sfondo
			Bitmap sfondotemporaneo = Assistant.Properties.Resources.BarraOrizzontaBordoSinistro;

			if (RazorEnhanced.Settings.General.ReadBool("ShowHitsToolBarCheckBox"))
			{
				m_hitslabelSH.AutoSize = true;
				m_hitslabelSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_hitslabelSH.Location = new System.Drawing.Point(offsetstat, 14);
				m_hitslabelSH.Name = "hitslabel";
				m_hitslabelSH.Size = new System.Drawing.Size(50, 12);
				m_hitslabelSH.TabIndex = 0;
				m_hitslabelSH.Text = "H: 999/999";

				m_form.Controls.Add(m_hitslabelSH);
				sfondotemporaneo = BackGroundAddOrizzontale(sfondotemporaneo, Assistant.Properties.Resources.BarraOrizzontaleSpazioStat);

				width += 51;
				offsetstat += 56;
				paneloffset += 51;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowManaToolBarCheckBox"))
			{
				m_manalabelSH.AutoSize = true;
				m_manalabelSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_manalabelSH.Location = new System.Drawing.Point(offsetstat, 14);
				m_manalabelSH.Name = "manalabel";
				m_manalabelSH.Size = new System.Drawing.Size(52, 12);
				m_manalabelSH.TabIndex = 1;
				m_manalabelSH.Text = "M: 999/999";

				m_form.Controls.Add(m_manalabelSH);
				sfondotemporaneo = BackGroundAddOrizzontale(sfondotemporaneo, Assistant.Properties.Resources.BarraOrizzontaleSpazioStat);

				width += 51;
				offsetstat += 56;
				paneloffset += 51;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowStaminaToolBarCheckBox"))
			{
				m_staminalabelSH.AutoSize = true;
				m_staminalabelSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_staminalabelSH.Location = new System.Drawing.Point(offsetstat, 14);
				m_staminalabelSH.Name = "stamlabel";
				m_staminalabelSH.Size = new System.Drawing.Size(49, 12);
				m_staminalabelSH.TabIndex = 2;
				m_staminalabelSH.Text = "S: 999/999";

				m_form.Controls.Add(m_staminalabelSH);
				sfondotemporaneo = BackGroundAddOrizzontale(sfondotemporaneo, Assistant.Properties.Resources.BarraOrizzontaleSpazioStat);

				width += 51;
				offsetstat += 56;
				paneloffset += 51;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowWeightToolBarCheckBox"))
			{
				m_weightlabelSH.AutoSize = true;
				m_weightlabelSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_weightlabelSH.Location = new System.Drawing.Point(offsetstat-5, 14);
				m_weightlabelSH.Name = "weightlabel";
				m_weightlabelSH.Size = new System.Drawing.Size(49, 12);
				m_weightlabelSH.TabIndex = 2;
				m_weightlabelSH.Text = "W: 999/999";

				m_form.Controls.Add(m_weightlabelSH);
				sfondotemporaneo = BackGroundAddOrizzontale(sfondotemporaneo, Assistant.Properties.Resources.BarraOrizzontaleSpazioStat);

				width += 51;
				offsetstat += 49;
				paneloffset += 51;
			}

			if (RazorEnhanced.Settings.General.ReadBool("ShowFollowerToolBarCheckBox"))
			{
				m_followerlabelSH.AutoSize = true;
				m_followerlabelSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				m_followerlabelSH.Location = new System.Drawing.Point(offsetstat, 14);
				m_followerlabelSH.Name = "followerlabel";
				m_followerlabelSH.Size = new System.Drawing.Size(49, 12);
				m_followerlabelSH.TabIndex = 2;
				m_followerlabelSH.Text = "F: 5";

				m_form.Controls.Add(m_followerlabelSH);
				sfondotemporaneo = BackGroundAddOrizzontale(sfondotemporaneo, Assistant.Properties.Resources.BarraOrizzontaleSpazioStat);

				width += 51;
				offsetstat += 50;
				paneloffset += 51;
			}

			width += (m_slot * 36); // Aggiungo spazio slot

			m_form.ClientSize = new System.Drawing.Size(width, Assistant.Properties.Resources.BarraOrizzontaleSpazioStat.Height);

			for (int i = 0; i < m_slot; i++)
			{
				//Genero sfondo slot
				sfondotemporaneo = BackGroundAddOrizzontale(sfondotemporaneo, Assistant.Properties.Resources.BarraOrizzontaleSlot);

				// Aggiungo panel dinamici
				Panel paneltemp = new Panel();
				Label labeltemp = new Label
				{
					AutoSize = true,
					Location = new System.Drawing.Point(0, 18),
					Font =
						new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular,
							System.Drawing.GraphicsUnit.Point, ((byte) (0))),
					Name = "panel" + i + "count",
					Size = new System.Drawing.Size(10, 20),
					TabIndex = 1,
					Text = "000"
				};


				labeltemp.SuspendLayout();

				paneltemp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
				paneltemp.Controls.Add(labeltemp);
				paneltemp.Location = new System.Drawing.Point(paneloffset, 6);
				paneltemp.Margin = new System.Windows.Forms.Padding(0);
				paneltemp.Name = "panel" + i;
				paneltemp.Size = new System.Drawing.Size(29, 29);
				paneltemp.TabIndex = 15;
				paneltemp.BackColor = Color.Transparent;

				m_panellist.Add(paneltemp);
				m_panelcount.Add(labeltemp);
				m_form.SuspendLayout();
				paneltemp.SuspendLayout();
				m_form.Controls.Add(paneltemp);

				paneloffset += 36;
			}

			m_form.BackgroundImage = BackGroundAddOrizzontale(sfondotemporaneo, Assistant.Properties.Resources.BarraOrizzontaBordoDestro);
			InitEvent();
		}

		internal static void EnhancedToolbar_close(object sender, EventArgs e)
		{
			m_form = null;
			m_slot = 0;
        }

		internal static void EnhancedToolbar_Move(object sender, System.EventArgs e)
		{
				System.Drawing.Point pt = m_form.Location;
				if (m_form.WindowState != FormWindowState.Minimized)
				{
					Assistant.Engine.MainWindow.LocationToolBarLabel.Text = "X: " + pt.X + " - Y:" + pt.Y;
					Assistant.Engine.ToolBarX = pt.X;
					Assistant.Engine.ToolBarY = pt.Y;
				}
		}

		private static Bitmap BackGroundAddVerticale(Image firstImage, Image secondImage)
		{
			int outputImageWidth = firstImage.Width;

			int outputImageHeight = firstImage.Height + secondImage.Height;

			Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			using (Graphics graphics = Graphics.FromImage(outputImage))
			{
				graphics.DrawImage(firstImage, new Rectangle(new Point(), firstImage.Size),
					new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
				graphics.DrawImage(secondImage, new Rectangle(new Point(0, firstImage.Height), secondImage.Size),
					new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);
			}

			return outputImage;
		}

		private static Bitmap BackGroundAddOrizzontale(Image firstImage, Image secondImage)
		{
			int outputImageWidth = firstImage.Width + secondImage.Width;

			int outputImageHeight = firstImage.Height;

			Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			using (Graphics graphics = Graphics.FromImage(outputImage))
			{
				graphics.DrawImage(firstImage, new Rectangle(new Point(), firstImage.Size),
					new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
				graphics.DrawImage(secondImage, new Rectangle(new Point(firstImage.Width, 0), secondImage.Size),
					new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);
			}

			return outputImage;
		}

		public static Bitmap ResizeImage(System.Drawing.Bitmap value, int newWidth, int newHeight)
		{
			Bitmap resizedImage = new System.Drawing.Bitmap(newWidth, newHeight);
			using (Graphics graphics = Graphics.FromImage(resizedImage))
			{
				System.Drawing.Graphics.FromImage((System.Drawing.Image)resizedImage).DrawImage(value, 0, 0, newWidth, newHeight);
			}

			return (resizedImage);
		}
	}
}