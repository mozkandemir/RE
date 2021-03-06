using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RazorEnhanced
{
	public class Organizer
	{
		[Serializable]
		public class OrganizerItem
		{
			private string m_Name;
			public string Name { get { return m_Name; } }

			private int m_Graphics;
			public int Graphics { get { return m_Graphics; } }

			private int m_Color;
			public int Color { get { return m_Color; } }

			private int m_amount;
			public int Amount { get { return m_amount; } }

			private bool m_Selected;
			internal bool Selected { get { return m_Selected; } }

			public OrganizerItem(string name, int graphics, int color, int amount, bool selected)
			{
				m_Name = name;
				m_Graphics = graphics;
				m_Color = color;
				m_amount = amount;
				m_Selected = selected;
			}
		}

		internal class OrganizerList
		{
			private string m_Description;
			internal string Description { get { return m_Description; } }

			private int m_Delay;
			internal int Delay { get { return m_Delay; } }

			private int m_Source;
			internal int Source { get { return m_Source; } }

			private int m_Destination;
			internal int Destination { get { return m_Destination; } }

			private bool m_Selected;
			internal bool Selected { get { return m_Selected; } }

			public OrganizerList(string description, int delay, int source, int destination, bool selected)
			{
				m_Description = description;
				m_Delay = delay;
				m_Source = source;
				m_Destination = destination;
				m_Selected = selected;
			}
		}

		internal static string OrganizerListName
		{
			get
			{
				return (string)Assistant.Engine.MainWindow.OrganizerListSelect.Invoke(new Func<string>(() => Assistant.Engine.MainWindow.OrganizerListSelect.Text));
			}

			set
			{
				Assistant.Engine.MainWindow.OrganizerListSelect.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerListSelect.Text = value));
			}
		}

		internal static int OrganizerDelay
		{
			get
			{
				int delay = 100;
				Assistant.Engine.MainWindow.OrganizerDragDelay.Invoke(new Action(() => Int32.TryParse(Assistant.Engine.MainWindow.OrganizerDragDelay.Text, out delay)));
				return delay;
			}

			set
			{
				Assistant.Engine.MainWindow.OrganizerDragDelay.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerDragDelay.Text = value.ToString()));
			}
		}

		internal static int OrganizerSource
		{
			get
			{
				int serialBag = 0;

				try
				{
					serialBag = Convert.ToInt32(Assistant.Engine.MainWindow.OrganizerSourceLabel.Text, 16);
				}
				catch
				{
				}

				return serialBag;
			}

			set
			{
				Assistant.Engine.MainWindow.OrganizerSourceLabel.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerSourceLabel.Text = "0x" + value.ToString("X8")));
			}
		}

		internal static int OrganizerDestination
		{
			get
			{
				int serialBag = 0;

				try
				{
					serialBag = Convert.ToInt32(Assistant.Engine.MainWindow.OrganizerDestinationLabel.Text, 16);
				}
				catch
				{
				}

				return serialBag;
			}

			set
			{
				Assistant.Engine.MainWindow.OrganizerDestinationLabel.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerDestinationLabel.Text = "0x" + value.ToString("X8")));
			}
		}

		internal static void AddLog(string addlog)
		{
			if (!Assistant.Engine.Running)
				return;

			Assistant.Engine.MainWindow.OrganizerLogBox.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerLogBox.Items.Add(addlog)));
			Assistant.Engine.MainWindow.OrganizerLogBox.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerLogBox.SelectedIndex = Assistant.Engine.MainWindow.OrganizerLogBox.Items.Count - 1));
			if (Assistant.Engine.MainWindow.OrganizerLogBox.Items.Count > 300)
				Assistant.Engine.MainWindow.OrganizerLogBox.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerLogBox.Items.Clear()));
		}

		internal static void RefreshLists()
		{
			List<OrganizerList> lists;
			RazorEnhanced.Settings.Organizer.ListsRead(out lists);

			OrganizerList selectedList = lists.FirstOrDefault(l => l.Selected);
			if (selectedList != null && selectedList.Description == Assistant.Engine.MainWindow.OrganizerListSelect.Text)
				return;

			Assistant.Engine.MainWindow.OrganizerListSelect.Items.Clear();
			foreach (OrganizerList l in lists)
			{
				Assistant.Engine.MainWindow.OrganizerListSelect.Items.Add(l.Description);

				if (!l.Selected)
					continue;

				Assistant.Engine.MainWindow.OrganizerListSelect.SelectedIndex = Assistant.Engine.MainWindow.OrganizerListSelect.Items.IndexOf(l.Description);
				OrganizerDelay = l.Delay;
				OrganizerSource = l.Source;
				OrganizerDestination = l.Destination;
			}
		}

		internal static void CopyTable()
		{
			Settings.Organizer.ClearList(Assistant.Engine.MainWindow.OrganizerListSelect.Text); // Rimuove vecchi dati dal save

			foreach (DataGridViewRow row in Assistant.Engine.MainWindow.OrganizerDataGridView.Rows)
			{
				if (row.IsNewRow)
					continue;

				int color = 0;
				if ((string)row.Cells[3].Value == "All")
					color = -1;
				else
					color = Convert.ToInt32((string)row.Cells[3].Value, 16);

				int amount = 0;
				if ((string)row.Cells[4].Value == "All")
					amount = -1;
				else
					amount = Convert.ToInt32((string)row.Cells[4].Value);

				bool check = false;
				bool.TryParse(row.Cells[0].Value.ToString(), out check);

				Settings.Organizer.ItemInsert(Assistant.Engine.MainWindow.OrganizerListSelect.Text, new OrganizerItem((string)row.Cells[1].Value, Convert.ToInt32((string)row.Cells[2].Value, 16), color, amount, check));
			}

			Settings.Save(); // Salvo dati
		}

		internal static void InitGrid()
		{
			List<OrganizerList> lists;
			RazorEnhanced.Settings.Organizer.ListsRead(out lists);

			Assistant.Engine.MainWindow.OrganizerDataGridView.Rows.Clear();

			foreach (OrganizerList l in lists)
			{
				if (l.Selected)
				{
					List<Organizer.OrganizerItem> items = Settings.Organizer.ItemsRead(l.Description);

					foreach (OrganizerItem item in items)
					{
						string color = "All";
						if (item.Color != -1)
							color = "0x" + item.Color.ToString("X4");

						string amount = "All";
						if (item.Amount != -1)
							amount = item.Amount.ToString();

						Assistant.Engine.MainWindow.OrganizerDataGridView.Rows.Add(new object[] { item.Selected.ToString(), item.Name, "0x" + item.Graphics.ToString("X4"), color, amount });
					}

					break;
				}
			}
		}

		internal static void AddList(string newList)
		{
			RazorEnhanced.Settings.Organizer.ListInsert(newList, RazorEnhanced.Organizer.OrganizerDelay, 0, 0);

			RazorEnhanced.Organizer.RefreshLists();
			RazorEnhanced.Organizer.InitGrid();
		}

		internal static void RemoveList(string list)
		{
			if (RazorEnhanced.Settings.Organizer.ListExists(list))
			{
				RazorEnhanced.Settings.Organizer.ListDelete(list);
			}

			RazorEnhanced.Organizer.RefreshLists();
			RazorEnhanced.Organizer.InitGrid();
		}

		internal static void AddItemToList(string name, int graphics, int color)
		{
			Assistant.Engine.MainWindow.OrganizerDataGridView.Rows.Add(new object[] { "False", name, "0x" + graphics.ToString("X4"), "0x" + color.ToString("X4"), "All" });
			CopyTable();
		}

		private static bool ColorCheck(int colorDaLista, int colorDaItem)
		{
			if (colorDaLista == -1) // Wildcard colore
				return true;
			else
				if (colorDaLista == colorDaItem) // Match OK
				return true;
			else // Match fallito
				return false;
		}

		internal static int Engine(List<OrganizerItem> organizerItemList, int mseconds, int sourceBagserail, int destinationBagserial)
		{
			Item sourceBag = Items.FindBySerial(sourceBagserail);
			Item destinationBag = Items.FindBySerial(destinationBagserial);

			// Check if container is updated
			RazorEnhanced.Organizer.AddLog("- Refresh Source Container");
			Items.WaitForContents(sourceBag, 1000);
			Thread.Sleep(mseconds);

			// Inizia scansione
			foreach (RazorEnhanced.Item oggettoContenuto in sourceBag.Contains)
			{
				foreach (OrganizerItem oggettoDaLista in organizerItemList)
				{
					if (!oggettoDaLista.Selected)
						continue;

					if (oggettoContenuto.ItemID != oggettoDaLista.Graphics || !ColorCheck(oggettoDaLista.Color, oggettoContenuto.Hue))
						continue;

					// Controllo amount e caso -1
					if (oggettoDaLista.Amount == -1) // Sposta senza contare
					{
						RazorEnhanced.Organizer.AddLog("- Item (0x" + oggettoContenuto.ItemID.ToString("X4") + ") Amount in Source container: " + oggettoContenuto.Amount);
						RazorEnhanced.Organizer.AddLog("- Item (0x" + oggettoContenuto.ItemID.ToString("X4") + ") Amount to move: All ");
						RazorEnhanced.Items.Move(oggettoContenuto, destinationBag, 0);
						Thread.Sleep(mseconds);
					}
					else   // Caso con limite quantita'
					{
						if (oggettoContenuto.Amount <= oggettoDaLista.Amount)     // Caso che lo stack da spostare sia minore del limite di oggetti
						{
							RazorEnhanced.Organizer.AddLog("- Item (0x" + oggettoContenuto.ItemID.ToString("X4") + ") Amount in Source container: " + oggettoContenuto.Amount);
							RazorEnhanced.Organizer.AddLog("- Item (0x" + oggettoContenuto.ItemID.ToString("X4") + ") Amount to move " + oggettoDaLista.Amount);
							RazorEnhanced.Items.Move(oggettoContenuto, destinationBag, 0);
							Thread.Sleep(mseconds);
						}
						else  // Caso che lo stack sia superiore (sposta solo un blocco)
						{
							RazorEnhanced.Organizer.AddLog("- Item (0x" + oggettoContenuto.ItemID.ToString("X4") + ") Amount in Source container: " + oggettoContenuto.Amount);
							RazorEnhanced.Organizer.AddLog("- Item (0x" + oggettoContenuto.ItemID.ToString("X4") + ") Amount to move " + oggettoDaLista.Amount);
							RazorEnhanced.Items.Move(oggettoContenuto, destinationBag, oggettoDaLista.Amount);
							Thread.Sleep(mseconds);
						}
					}
				}
			}

			RazorEnhanced.Organizer.AddLog("Finish!");
			if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
				RazorEnhanced.Misc.SendMessage("Enhanced Organizer: Finish!", 945);
			Assistant.Engine.MainWindow.OrganizerFinishWork();
			return 0;
		}

		internal static void Engine()
		{
			// Check Bag
			Assistant.Item sbag = Assistant.World.FindItem(OrganizerSource);
			if (sbag == null)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					Misc.SendMessage("Organizer: Invalid Source Bag", 945);
				AddLog("Invalid Source Bag");
				Assistant.Engine.MainWindow.OrganizerFinishWork();
				return;
			}
			Assistant.Item dbag = Assistant.World.FindItem(OrganizerDestination);
			if (dbag == null)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					Misc.SendMessage("Organizer: Invalid Destination Bag", 945);
				AddLog("Invalid Destination Bag");
				Assistant.Engine.MainWindow.OrganizerFinishWork();
				return;
			}

			int exit = Engine(Settings.Organizer.ItemsRead(OrganizerListName), OrganizerDelay, OrganizerSource, OrganizerDestination);
		}

		private static Thread m_OrganizerThread;

		internal static void Start()
		{
			if (m_OrganizerThread == null ||
						(m_OrganizerThread != null && m_OrganizerThread.ThreadState != ThreadState.Running &&
						m_OrganizerThread.ThreadState != ThreadState.Unstarted &&
						m_OrganizerThread.ThreadState != ThreadState.WaitSleepJoin)
					)
			{
				RazorEnhanced.DragDropManager.HoldingItem = false;
				m_OrganizerThread = new Thread(Organizer.Engine);
				m_OrganizerThread.Start();
			}
		}

		internal static void ForceStop()
		{
			if (m_OrganizerThread != null && m_OrganizerThread.ThreadState != ThreadState.Stopped)
			{
				RazorEnhanced.DragDropManager.HoldingItem = false;
				m_OrganizerThread.Abort();
			}
		}

		// Funzioni da script

		public static void FStart()
		{
			if (Assistant.Engine.MainWindow.OrganizerExecute.Enabled == true)
				Assistant.Engine.MainWindow.OrganizerStartExec();
			else
			{
				Scripts.SendMessageScriptError("Script Error: Organizer.FStart: Organizer already running");
			}
		}

		public static void FStop()
		{
			if (Assistant.Engine.MainWindow.OrganizerStop.Enabled == true)
				Assistant.Engine.MainWindow.OrganizerStopExec();
			else
			{
				Scripts.SendMessageScriptError("Script Error: Organizer.FStart: Organizer not running");
			}
		}

		public static bool Status()
		{
			if (m_OrganizerThread != null && m_OrganizerThread.ThreadState != ThreadState.Stopped)
				return true;
			else
				return false;
		}

		public static void ChangeList(string nomelista)
		{
			if (!Assistant.Engine.MainWindow.OrganizerListSelect.Items.Contains(nomelista))
			{
				Scripts.SendMessageScriptError("Script Error: Organizer.ChangeList: Organizer list: " + nomelista + " not exist");
			}
			else
			{
				if (Assistant.Engine.MainWindow.OrganizerStop.Enabled == true) // Se è in esecuzione forza stop cambio lista e restart
				{
					Assistant.Engine.MainWindow.OrganizerStop.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerStop.PerformClick()));
					Assistant.Engine.MainWindow.OrganizerListSelect.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerListSelect.SelectedIndex = Assistant.Engine.MainWindow.OrganizerListSelect.Items.IndexOf(nomelista)));  // cambio lista
					Assistant.Engine.MainWindow.OrganizerExecute.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerExecute.PerformClick()));
				}
				else
				{
					Assistant.Engine.MainWindow.OrganizerListSelect.Invoke(new Action(() => Assistant.Engine.MainWindow.OrganizerListSelect.SelectedIndex = Assistant.Engine.MainWindow.OrganizerListSelect.Items.IndexOf(nomelista)));  // cambio lista
				}
			}
		}
	}
}