using Assistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace RazorEnhanced
{
	public class Mobile : EnhancedEntity
	{
		private Assistant.Mobile m_AssistantMobile;

		internal Mobile(Assistant.Mobile mobile)
			: base(mobile)
		{
			m_AssistantMobile = mobile;
		}

		public string Name { get { return m_AssistantMobile.Name; } }

		public int Body { get { return m_AssistantMobile.Body; } }

		public int Color { get { return m_AssistantMobile.Hue; } }

		public bool PropsUpdated { get { return m_AssistantMobile.PropsUpdated; } }

		public bool Visible { get { return m_AssistantMobile.Visible; } }

		public bool Poisoned { get { return m_AssistantMobile.Poisoned; } }

		public bool YellowHits { get { return m_AssistantMobile.Blessed; } }

		public bool Paralized { get { return m_AssistantMobile.Paralized; } }

		public bool Flying { get { return m_AssistantMobile.Flying; } }

		public bool IsHuman { get { return m_AssistantMobile.IsHuman; } }

		public bool IsGhost { get { return m_AssistantMobile.IsGhost; } }

		public bool Warmode { get { return m_AssistantMobile.Warmode; } }

		public bool Female { get { return m_AssistantMobile.Female; } }

		public int Notoriety { get { return m_AssistantMobile.Notoriety; } }

		public int HitsMax { get { return m_AssistantMobile.HitsMax; } }

		public int Hits { get { return m_AssistantMobile.Hits; } }

		public int StamMax { get { return m_AssistantMobile.StamMax; } }

		public int Stam { get { return m_AssistantMobile.Stam; } }

		public int ManaMax { get { return m_AssistantMobile.ManaMax; } }

		public int Mana { get { return m_AssistantMobile.Mana; } }

		public int Map { get { return m_AssistantMobile.Map; } }

		public bool InParty { get { return Assistant.PacketHandlers.Party.Contains(m_AssistantMobile.Serial); } }

		public Item Mount
		{
			get
			{
				Assistant.Item assistantMount = m_AssistantMobile.GetItemOnLayer(Assistant.Layer.Mount);
				if (assistantMount == null)
					return null;
				else
				{
					RazorEnhanced.Item enhancedMount = new RazorEnhanced.Item(assistantMount);
					return enhancedMount;
				}
			}
		}

		public string Direction
		{
			get
			{
				switch (m_AssistantMobile.Direction & Assistant.Direction.Mask)
				{
					case Assistant.Direction.North: return "North";
					case Assistant.Direction.South: return "South";
					case Assistant.Direction.West: return "West";
					case Assistant.Direction.East: return "East";
					case Assistant.Direction.Right: return "Right";
					case Assistant.Direction.Left: return "Left";
					case Assistant.Direction.Down: return "Down";
					case Assistant.Direction.Up: return "Up";
					default: return "Undefined";
				}
			}
		}

		public int DistanceTo(Mobile m)
		{
			int x = Math.Abs(this.Position.X - m.Position.X);
			int y = Math.Abs(this.Position.Y - m.Position.Y);

			return x > y ? x : y;
		}

		private static Assistant.Layer GetAssistantLayer(string layer)
		{
			Assistant.Layer result = Assistant.Layer.Invalid;

			switch (layer)
			{
				case "RightHand":
					result = Assistant.Layer.RightHand;
					break;

				case "LeftHand":
					result = Assistant.Layer.LeftHand;
					break;

				case "Shoes":
					result = Assistant.Layer.Shoes;
					break;

				case "Pants":
					result = Assistant.Layer.Pants;
					break;

				case "Shirt":
					result = Assistant.Layer.Shirt;
					break;

				case "Head":
					result = Assistant.Layer.Head;
					break;

				case "Gloves":
					result = Assistant.Layer.Gloves;
					break;

				case "Ring":
					result = Assistant.Layer.Ring;
					break;

				case "Neck":
					result = Assistant.Layer.Neck;
					break;

				case "Hair":
					result = Assistant.Layer.Hair;
					break;

				case "Waist":
					result = Assistant.Layer.Waist;
					break;

				case "InnerTorso":
					result = Assistant.Layer.InnerTorso;
					break;

				case "Bracelet":
					result = Assistant.Layer.Bracelet;
					break;

				case "FacialHair":
					result = Assistant.Layer.FacialHair;
					break;

				case "MiddleTorso":
					result = Assistant.Layer.MiddleTorso;
					break;

				case "Earrings":
					result = Assistant.Layer.Earrings;
					break;

				case "Arms":
					result = Assistant.Layer.Arms;
					break;

				case "Cloak":
					result = Assistant.Layer.Cloak;
					break;

				case "OuterTorso":
					result = Assistant.Layer.OuterTorso;
					break;

				case "OuterLegs":
					result = Assistant.Layer.OuterLegs;
					break;

				case "InnerLegs":
					result = Assistant.Layer.InnerLegs;
					break;

				default:
					result = Assistant.Layer.Invalid;
					break;
			}

			return result;
		}

		public Item GetItemOnLayer(String layer)
		{
			Assistant.Layer assistantLayer = GetAssistantLayer(layer);

			Assistant.Item assistantItem = null;
			if (assistantLayer != Assistant.Layer.Invalid)
			{
				assistantItem = m_AssistantMobile.GetItemOnLayer(assistantLayer);
				if (assistantItem == null)
					return null;
				else
				{
					RazorEnhanced.Item enhancedItem = new RazorEnhanced.Item(assistantItem);
					return enhancedItem;
				}
			}
			else
				return null;
		}

		public Item Backpack
		{
			get
			{
				Assistant.Item assistantBackpack = m_AssistantMobile.Backpack;
				if (assistantBackpack == null)
					return null;
				else
				{
					RazorEnhanced.Item enhancedBackpack = new RazorEnhanced.Item(assistantBackpack);
					return enhancedBackpack;
				}
			}
		}

		public Item Quiver
		{
			get
			{
				Assistant.Item assistantQuiver = m_AssistantMobile.Quiver;
				if (assistantQuiver == null)
					return null;
				else
				{
					RazorEnhanced.Item enhancedQuiver = new RazorEnhanced.Item(assistantQuiver);
					return enhancedQuiver;
				}
			}
		}

		public List<Item> Contains
		{
			get
			{
				List<Item> items = new List<Item>();
				foreach (Assistant.Item assistantItem in m_AssistantMobile.Contains)
				{
					RazorEnhanced.Item enhancedItem = new RazorEnhanced.Item(assistantItem);
					items.Add(enhancedItem);
				}
				return items;
			}
		}

		public List<Property> Properties
		{
			get
			{
				List<Property> properties = new List<Property>();
				foreach (Assistant.ObjectPropertyList.OPLEntry entry in m_AssistantMobile.ObjPropList.Content)
				{
					Property property = new Property(entry);
					properties.Add(property);
				}
				return properties;
			}
		}
	}

	public class Mobiles
	{
		public static Mobile FindBySerial(int serial)
		{
			Assistant.Mobile assistantMobile = Assistant.World.FindMobile((Assistant.Serial)((uint)serial));
			if (assistantMobile == null)
			{
				Scripts.SendMessageScriptError("Script Error: FindBySerial: Item serial: (" + serial + ") not found");
				return null;
			}
			else
			{
				RazorEnhanced.Mobile enhancedMobile = new RazorEnhanced.Mobile(assistantMobile);
				return enhancedMobile;
			}
		}

		[Serializable]
		public class Filter
		{
			public bool Enabled = false;
			public List<int> Serials = new List<int>();
			public List<int> Bodies = new List<int>();
			public string Name = "";
			public List<int> Hues = new List<int>();
			public double RangeMin = -1;
			public double RangeMax = -1;
			public int Poisoned = -1;
			public int Blessed = -1;
			public int IsHuman = -1;
			public int IsGhost = -1;
			public int Female = -1;
			public int Warmode = -1;
			public int Friend = -1;
			public int Paralized = -1;
			public List<byte> Notorieties = new List<byte>();

			public Filter()
			{
			}
		}

		public static List<Mobile> ApplyFilter(Filter filter)
		{
			List<Mobile> result = new List<Mobile>();

			List<Assistant.Mobile> assistantMobiles = Assistant.World.Mobiles.Values.ToList();

			if (filter.Enabled)
			{
				if (filter.Serials.Count > 0)
				{
					assistantMobiles = assistantMobiles.Where((m) => filter.Serials.Contains((int)m.Serial.Value)).ToList();
				}
				else
				{
					if (filter.Name != "")
					{
						Regex rgx = new Regex(filter.Name, RegexOptions.IgnoreCase);
						List<Assistant.Mobile> list = assistantMobiles.Where(i => rgx.IsMatch(i.Name)).ToList();
						assistantMobiles = list;
					}

					if (filter.Bodies.Count > 0)
					{
						assistantMobiles = assistantMobiles.Where((m) => filter.Bodies.Contains(m.Body)).ToList();
					}

					if (filter.Hues.Count > 0)
					{
						assistantMobiles = assistantMobiles.Where((i) => filter.Hues.Contains(i.Hue)).ToList();
					}

					if (filter.RangeMin != -1)
					{
						assistantMobiles = assistantMobiles.Where((m) =>
							Utility.DistanceSqrt
							(new Assistant.Point2D(Assistant.World.Player.Position.X, Assistant.World.Player.Position.Y), new Assistant.Point2D(m.Position.X, m.Position.Y)) >= filter.RangeMin
						).ToList();
					}

					if (filter.RangeMax != -1)
					{
						assistantMobiles = assistantMobiles.Where((m) =>
							Utility.DistanceSqrt
							(new Assistant.Point2D(Assistant.World.Player.Position.X, Assistant.World.Player.Position.Y), new Assistant.Point2D(m.Position.X, m.Position.Y)) <= filter.RangeMax
						).ToList();
					}

					if (filter.Warmode != -1)
					{
						assistantMobiles = assistantMobiles.Where((m) => m.Warmode == Convert.ToBoolean(filter.Warmode)).ToList();
					}

					if (filter.Poisoned != -1)
					{
						assistantMobiles = assistantMobiles.Where((m) => m.Poisoned == Convert.ToBoolean(filter.Poisoned)).ToList();
					}

					if (filter.Blessed != -1)
					{
						assistantMobiles = assistantMobiles.Where((m) => m.Blessed == Convert.ToBoolean(filter.Blessed)).ToList();
					}

					if (filter.IsHuman != -1)
					{
						assistantMobiles = assistantMobiles.Where((m) => m.IsHuman == Convert.ToBoolean(filter.IsHuman)).ToList();
					}

					if (filter.IsGhost != -1)
					{
						assistantMobiles = assistantMobiles.Where((m) => m.IsGhost == Convert.ToBoolean(filter.IsGhost)).ToList();
					}

					if (filter.Female != -1)
					{
						assistantMobiles = assistantMobiles.Where((m) => m.Female == Convert.ToBoolean(filter.Female)).ToList();
					}

					if (filter.Friend != -1)
					{
						assistantMobiles = assistantMobiles.Where((m) => RazorEnhanced.Friend.IsFriend(m.Serial) == Convert.ToBoolean(filter.Friend)).ToList();
					}

					if (filter.Paralized != -1)
					{
						assistantMobiles = assistantMobiles.Where((m) => m.Paralized == Convert.ToBoolean(filter.Paralized)).ToList();
					}

					if (filter.Notorieties.Count > 0)
					{
						assistantMobiles = assistantMobiles.Where((m) => filter.Notorieties.Contains(m.Notoriety)).ToList();
					}

					// Esclude Self dalla ricerca
					assistantMobiles = assistantMobiles.Where((m) => m.Serial != World.Player.Serial).ToList();
				}
			}

			foreach (Assistant.Mobile assistantMobile in assistantMobiles)
			{
				RazorEnhanced.Mobile enhancedMobile = new RazorEnhanced.Mobile(assistantMobile);
				result.Add(enhancedMobile);
			}
			return result;
		}

		public static Mobile Select(List<Mobile> mobiles, string selector)
		{
			Mobile result = null;

			if (mobiles.Count > 0)
			{
				switch (selector)
				{
					case "Random":
						// Esclude Last dalla ricerca

						if (mobiles.Count > 1)
							mobiles = mobiles.Where((m) => m.Serial != Target.GetLast()).ToList();

						try
						{
							result = mobiles[Utility.Random(mobiles.Count)] as Mobile;
						}
						catch { }

						break;

					case "Nearest":
						Mobile closest = null;
						double closestDist = double.MaxValue;

						foreach (Mobile m in mobiles)
						{
							if (m.Serial == World.Player.Serial)
								continue;

							double dist = Utility.DistanceSqrt(new Assistant.Point2D(m.Position.X, m.Position.Y), World.Player.Position);

							if (!(dist < closestDist) && closest != null)
								continue;

							closestDist = dist;
							closest = m;
						}
						result = closest;
						break;

					case "Farthest":
						Mobile farthest = null;
						double farthestDist = double.MinValue;

						foreach (Mobile m in mobiles)
						{
							if (m.Serial == World.Player.Serial)
								continue;

							double dist = Utility.DistanceSqrt(new Assistant.Point2D(m.Position.X, m.Position.Y), World.Player.Position);

							if (!(dist > farthestDist) && farthest != null)
								continue;

							farthestDist = dist;
							farthest = m;
						}
						result = farthest;
						break;

					case "Weakest":
						Mobile weakest = mobiles[0] as Mobile;
						if (weakest != null)
						{
							int minHits = weakest.Hits;
							foreach (Mobile t in mobiles)
							{
								if (t == null)
									continue;

								int wounds = t.Hits;
								if (wounds < minHits)
								{
									weakest = t;
									minHits = wounds;
								}
							}
							result = weakest;
						}
						break;

					case "Strongest":
						Mobile strongest = mobiles[0] as Mobile;
						if (strongest != null)
						{
							int maxHits = strongest.Hits;
							foreach (Mobile t in mobiles)
							{
								if (t == null)
									continue;

								int wounds = t.Hits;
								if (wounds <= maxHits)
									continue;

								strongest = t;
								maxHits = wounds;
							}
							result = strongest;
						}
						break;
				}
			}

			return result;
		}

		// USe

		public static void UseMobile(Mobile mobile)
		{
			Assistant.ClientCommunication.SendToServerWait(new DoubleClick(mobile.Serial));
		}

		public static void UseMobile(int mobileserial)
		{
			Assistant.Mobile mobile = Assistant.World.FindMobile(mobileserial);
			if (mobile == null)
			{
				Scripts.SendMessageScriptError("Script Error: UseMobile: Invalid Serial");
				return;
			}

			if (mobile.Serial.IsMobile)
			{
				Assistant.ClientCommunication.SendToServerWait(new DoubleClick(mobile.Serial));
			}
			else
			{
				Scripts.SendMessageScriptError("Script Error: UseMobile: (" + mobile.Serial.ToString() + ") is not a mobile");
			}
		}

		// Single Click
		public static void SingleClick(Mobile mobile)
		{
			ClientCommunication.SendToServerWait(new SingleClick(mobile));
		}

		public static void SingleClick(int mobileserial)
		{
			Assistant.Mobile mobile = Assistant.World.FindMobile(mobileserial);
			if (mobile == null)
			{
				Scripts.SendMessageScriptError("Script Error: SingleClick: Invalid Serial");
				return;
			}
			ClientCommunication.SendToServer(new SingleClick(mobile));
		}

		// Message

		internal static void MessageNoWait(int serial, int hue, string message)
		{
			Mobile mobile = FindBySerial(serial);
			Assistant.ClientCommunication.SendToClient(new UnicodeMessage(mobile.Serial, mobile.Body, MessageType.Regular, hue, 3, Language.CliLocName, mobile.Name, message));
		}

		public static void Message(Mobile mobile, int hue, string message)
		{
			Assistant.ClientCommunication.SendToClientWait(new UnicodeMessage(mobile.Serial, mobile.Body, MessageType.Regular, hue, 3, Language.CliLocName, mobile.Name, message));
		}

		public static void Message(int serial, int hue, string message)
		{
			Mobile mobile = FindBySerial(serial);
			Assistant.ClientCommunication.SendToClientWait(new UnicodeMessage(mobile.Serial, mobile.Body, MessageType.Regular, hue, 3, Language.CliLocName, mobile.Name, message));
		}

		// Props

		public static void WaitForProps(Mobile m, int delay) // Delay in MS
		{
			WaitForProps(m.Serial, delay);
		}

		public static void WaitForProps(int mobileserial, int delay) // Delay in MS
		{
			if (World.Player.Expansion <= 3) // Non esistono le props
				return;

			Assistant.Mobile m = Assistant.World.FindMobile((Assistant.Serial)((uint)mobileserial));

			if (m == null)
				return;

			if (m.PropsUpdated)
				return;

			ClientCommunication.SendToServerWait(new QueryProperties(m.Serial));
			int subdelay = delay;

			while (!m.PropsUpdated)
			{
				Thread.Sleep(2);
				subdelay -= 2;
				if (subdelay <= 0)
					break;
			}
		}

		public static List<string> GetPropStringList(int serial)
		{
			List<string> propstringlist = new List<string>();
			Assistant.Mobile assistantMobile = Assistant.World.FindMobile((uint)serial);

			if (assistantMobile == null)
				return propstringlist;

			List<Assistant.ObjectPropertyList.OPLEntry> props = assistantMobile.ObjPropList.Content;
			foreach (Assistant.ObjectPropertyList.OPLEntry prop in props)
			{
				propstringlist.Add(prop.ToString());
			}
			return propstringlist;
		}

		public static List<string> GetPropStringList(Mobile mob)
		{
			return GetPropStringList(mob.Serial);
		}

		public static string GetPropStringByIndex(int serial, int index)
		{
			string propstring = "";
			Assistant.Mobile assistantMobile = Assistant.World.FindMobile((uint)serial);

			if (assistantMobile == null)
				return propstring;

			List<Assistant.ObjectPropertyList.OPLEntry> props = assistantMobile.ObjPropList.Content;
			if (props.Count > index)
				propstring = props[index].ToString();
			return propstring;
		}

		public static string GetPropStringByIndex(Mobile mob, int index)
		{
			return GetPropStringByIndex(mob.Serial, index);
		}

		public static int GetPropValue(int serial, string name)
		{
			Assistant.Mobile assistantMobile = Assistant.World.FindMobile((uint)serial);

			if (assistantMobile != null)
			{
				List<Assistant.ObjectPropertyList.OPLEntry> props = assistantMobile.ObjPropList.Content;

				foreach (Assistant.ObjectPropertyList.OPLEntry prop in props)
				{
					RazorEnhanced.Misc.SendMessage(prop.Args);

					if (!prop.ToString().ToLower().Contains(name.ToLower()))
						continue;

					if (prop.Args == null)  // Props esiste ma non ha valore
						return 1;

					string propstring = prop.Args;
					bool subprops = false;
					int i = 0;

					if (propstring.Length > 7)
						subprops = true;

					try  // Etraggo il valore
					{
						string number = string.Empty;
						foreach (char str in propstring)
						{
							if (subprops)
							{
								if (i > 7)
									if (char.IsDigit(str))
										number += str.ToString();
							}
							else
							{
								if (char.IsDigit(str))
									number += str.ToString();
							}

							i++;
						}
						return (Convert.ToInt32(number));
					}
					catch
					{
						return 1;  // errore di conversione ma esiste
					}
				}
			}
			return 0;  // Non esiste
		}

		public static int GetPropValue(Mobile mob, string name)
		{
			return GetPropValue(mob.Serial, name);
		}

		// Context

		public static int ContextExist(Mobile mob, string name)
		{
			return ContextExist(mob.Serial, name);
		}

		public static int ContextExist(int serial, string name)
		{
			Assistant.Mobile mobile = World.FindMobile(serial);
			if (mobile == null) // Se item non valido
				return -1;

			Misc.WaitForContext(serial, 1500);

			foreach (KeyValuePair<ushort, int> entry in mobile.ContextMenu)
			{
				string menuname = string.Empty;
				menuname = Language.GetCliloc(entry.Value);
				if (menuname.ToLower() == name.ToLower())
				{
					return entry.Key;
				}
			}

			return -1; // Se non trovata
		}
	}
}