using Assistant;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython.Runtime.Exceptions;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FastColoredTextBoxNS;

namespace RazorEnhanced.UI
{
	internal partial class EnhancedScriptEditor : Form
	{
		private delegate void SetHighlightLineDelegate(int iline, Color color);

		private delegate void SetStatusLabelDelegate(string text, Color color);

		private delegate string GetFastTextBoxTextDelegate();

		private delegate void SetTracebackDelegate(string text);

		private enum Command
		{
			None = 0,
			Line,
			Call,
			Return,
			Breakpoint
		}

		private static EnhancedScriptEditor m_EnhancedScriptEditor;
		internal static FastColoredTextBox EnhancedScriptEditorTextArea { get { return m_EnhancedScriptEditor.fastColoredTextBoxEditor; } }
		private static ConcurrentQueue<Command> m_Queue = new ConcurrentQueue<Command>();
		private static Command m_CurrentCommand = Command.None;
		private static AutoResetEvent m_WaitDebug = new AutoResetEvent(false);

		private const string m_Title = "Enhanced Script Editor";
		private string m_Filename = "";
		private string m_Filepath = "";

		private ScriptEngine m_Engine;
		private ScriptSource m_Source;
		private ScriptScope m_Scope;

		private TraceBackFrame m_CurrentFrame;
		private FunctionCode m_CurrentCode;
		private string m_CurrentResult;
		private object m_CurrentPayload;

		private List<int> m_Breakpoints = new List<int>();

		private volatile bool m_Breaktrace = false;
		private bool m_onclosing = false;

		private FastColoredTextBoxNS.AutocompleteMenu m_popupMenu;

		internal static void Init(string filename)
		{
			ScriptEngine engine = Python.CreateEngine();
			m_EnhancedScriptEditor = new EnhancedScriptEditor(engine, filename);
			m_EnhancedScriptEditor.Show();
		}

		internal static void End()
		{
			if (m_EnhancedScriptEditor != null)
			{
				if (ScriptRecorder.OnRecord)
					ScriptRecorder.OnRecord = false;

				m_EnhancedScriptEditor.Stop();
			}
		}

		internal EnhancedScriptEditor(ScriptEngine engine, string filename)
		{
			InitializeComponent();
			//Automenu Section
			m_popupMenu = new AutocompleteMenu(fastColoredTextBoxEditor);
			m_popupMenu.Items.ImageList = imageList2;
			m_popupMenu.SearchPattern = @"[\w\.:=!<>]";
			m_popupMenu.AllowTabKey = true;
			m_popupMenu.ToolTipDuration = 5000;
			m_popupMenu.AppearInterval = 100;

			#region Keywords

			string[] keywords =
			{
				"and", "assert", "break", "class", "continue", "def", "del", "elif", "else", "except", "exec",
				"finally", "for", "from", "global", "if", "import", "in", "is", "lambda", "not", "or", "pass", "print",
				"raise", "return", "try", "while", "yield", "None", "True", "False", "as"
			};

			#endregion

			#region Classes Autocomplete

			string[] classes =
			{
				"Player", "Spells", "Mobile", "Mobiles", "Item", "Items", "Misc", "Target", "Gumps", "Journal",
				"AutoLoot", "Scavenger", "Organizer", "Restock", "SellAgent", "BuyAgent", "Dress", "Friend", "BandageHeal",
				"Statics"
			};

			#endregion

			#region Methods Autocomplete

			string[] methodsPlayer =
			{
				"Player.BuffsExist", "Player.GetBuffDescription",
				"Player.HeadMessage", "Player.InRangeMobile", "Player.InRangeItem", "Player.GetItemOnLayer",
				"Player.UnEquipItemByLayer", "Player.EquipItem", "Player.CheckLayer", "Player.GetAssistantLayer", "Player.EquipUO3D",
				"Player.GetSkillValue", "Player.GetSkillCap", "Player.GetSkillStatus", "Player.UseSkill", "Player.ChatSay",
				"Player.ChatEmote", "Player.ChatWhisper","Player.ChatChannel",
				"Player.ChatYell", "Player.ChatGuild", "Player.ChatAlliance", "Player.SetWarMode", "Player.Attack",
				"Player.AttackLast", "Player.InParty", "Player.ChatParty",
				"Player.PartyCanLoot", "Player.PartyInvite", "Player.PartyLeave", "Player.KickMember", "Player.InvokeVirtue",
				"Player.Walk", "Player.PathFindTo", "Player.PathFindToPacket", "Player.GetPropValue", "Player.GetPropStringByIndex", "GetPropStringList", "Player.QuestButton",
				"Player.GuildButton", "Player.WeaponPrimarySA", "Player.WeaponSecondarySA", "Player.WeaponClearSA",
				"Player.WeaponStunSA", "Player.WeaponDisarmSA, Player.HasSpecial", "Player.Flying"
			};

			string[] methodsSpells =
			{
				"Spells.CastMagery", "Spells.CastNecro", "Spells.CastChivalry", "Spells.CastBushido", "Spells.CastNinjitsu", "Spells.CastSpellweaving", "Spells.CastMysticism", "Spells.CastBard"
			};

			string[] methodsMobiles =
			{
				"Mobile.GetItemOnLayer", "Mobile.GetAssistantLayer", "Mobiles.FindBySerial", "Mobiles.UseMobile", "Mobiles.SingleClick",
				"Mobiles.Filter", "Mobiles.ApplyFilter", "Mobiles.Message", "Mobiles.WaitForProps", "Mobiles.GetPropValue",
				"Mobiles.GetPropStringByIndex", "Mobiles.GetPropStringList", "Mobiles.Flying", "Mobiles.ContextExist"
			};

			string[] methodsItems =
			{
				"Items.FindBySerial", "Items.Move", "Items.MoveOnGround", "Items.DropItemOnGroundSelf", "Items.UseItem", "Items.SingleClick",
				"Items.WaitForProps", "Items.GetPropValue", "Items.GetPropStringByIndex", "Items.GetPropStringList",
				"Items.WaitForContents", "Items.Message", "Items.Filter", "Items.ApplyFilter", "Items.BackpackCount", "Items.ContainerCount", "Items.UseItemByID", "Items.Hide",
				"Items.ContextExist", "Items.UseItemOnTarget"
			};

			string[] methodsMisc =
			{
				"Misc.SendMessage", "Misc.Resync", "Misc.Pause", "Misc.Beep", "Misc.Disconnect", "Misc.WaitForContext",
				"Misc.ContextReply", "Misc.ReadSharedValue", "Misc.RemoveSharedValue", "Misc.CheckSharedValue",
				"Misc.SetSharedValue",
				"Misc.HasMenu", "Misc.CloseMenu", "Misc.MenuContains", "Misc.GetMenuTitle", "Misc.WaitForMenu",
				"Misc.MenuResponse", "Misc.HasQueryString",
				"Misc.WaitForQueryString", "Misc.QueryStringResponse", "Misc.NoOperation", "Misc.ScriptRun", "Misc.ScriptStop",
				"Misc.ScriptStatus", "Misc.PetRename"
			};

			string[] methodsTarget =
			{
				"Target.HasTarget", "Target.GetLast", "Target.GetLastAttack", "Target.WaitForTarget", "Target.TargetExecute", "Target.PromptTarget", "Target.Cancel", "Target.Last", "Target.LastQueued",
				"Target.Self", "Target.SelfQueued", "Target.SetLast", "Target.ClearLast", "Target.ClearQueue", "Target.ClearLastandQueue", "Target.SetLastTargetFromList",
				"Target.PerformTargetFromList", "Target.AttackTargetFromList"
			};

			string[] methodsGumps =
			{
				"Gumps.CurrentGump", "Gumps.HasGump", "Gumps.CloseGump", "Gumps.ResetGump", "Gumps.WaitForGump", "Gumps.SendAction",
				"Gumps.SendAdvancedAction", "Gumps.LastGumpGetLine", "Gumps.LastGumpGetLineList", "Gumps.LastGumpTextExist",
				"Gumps.LastGumpTextExistByLine"
			};

			string[] methodsJournal =
			{
				"Journal.Clear", "Journal.Search", "Journal.SearchByName", "Journal.SearchByColor",
				"Journal.SearchByType", "Journal.GetLineText", "Journal.GetSpeechName", "Journal.WaitJournal"
			};

			string[] methodsAutoLoot =
			{
				"AutoLoot.Status", "AutoLoot.Start", "AutoLoot.Stop", "AutoLoot.ChangeList", "AutoLoot.RunOnce"
			};

			string[] methodsScavenger =
			{
				"Scavenger.Status", "Scavenger.Start", "Scavenger.Stop", "Scavenger.ChangeList", "Scavenger.RunOnce"
			};

			string[] methodsOrganizer =
			{
				"Organizer.Status", "Organizer.FStart", "Organizer.FStop", "Organizer.ChangeList"
			};

			string[] methodsRestock =
			{
				"Restock.Status", "Restock.FStart", "Restock.FStop", "Restock.ChangeList"
			};

			string[] methodsSellAgent =
			{
				"SellAgent.Status", "SellAgent.Enable", "SellAgent.Disable", "SellAgent.ChangeList"
			};

			string[] methodsBuyAgent =
			{
				"BuyAgent.Status", "BuyAgent.Enable", "BuyAgent.Disable", "BuyAgent.ChangeList"
			};

			string[] methodsDress =
			{
				"Dress.DessStatus", "Dress.UnDressStatus", "Dress.DressFStart", "Dress.UnDressFStart", "Dress.DressFStop", "Dress.UnDressFStop", "Dress.ChangeList"
			};

			string[] methodsFriend =
			{
				"Friend.IsFriend", "Friend.ChangeList"
			};

			string[] methodsBandageHeal =
			{
				"BandageHeal.Status", "BandageHeal.Start", "BandageHeal.Stop"
			};

			string[] methodsStatics =
			{
				"Statics.GetLandID", "Statics.GetLandZ", "Statics.GetStaticsTileInfo"
			};

			string[] methodsGeneric =
			{
				"GetItemOnLayer", "GetAssistantLayer", "DistanceTo"
			};

			string[] methods =
				methodsPlayer.Union(methodsSpells)
					.Union(methodsMobiles)
					.Union(methodsItems)
					.Union(methodsMisc)
					.Union(methodsTarget)
					.Union(methodsGumps)
					.Union(methodsJournal)
					.Union(methodsAutoLoot)
					.Union(methodsScavenger)
					.Union(methodsOrganizer)
					.Union(methodsRestock)
					.Union(methodsSellAgent)
					.Union(methodsBuyAgent)
					.Union(methodsDress)
					.Union(methodsFriend)
					.Union(methodsBandageHeal)
					.Union(methodsStatics)
					.ToArray();

			#endregion

			#region Props Autocomplete

			string[] propsPlayer =
			{
				"Player.StatCap", "Player.AR", "Player.FireResistance", "Player.ColdResistance", "Player.EnergyResistance",
				"Player.PoisonResistance",
				"Player.Buffs", "Player.IsGhost", "Player.Female", "Player.Name", "Player.Bank",
				"Player.Gold", "Player.Luck", "Player.Body", "Player.HasSpecial",
				"Player.Followers", "Player.FollowersMax", "Player.MaxWeight", "Player.Str", "Player.Dex", "Player.Int"
			};

			string[] propsPositions =
			{
				"Position.X", "Position.Y", "Position.Z"
			};

			string[] propsWithCheck = propsPlayer.Union(propsPositions).ToArray();

			string[] propsGeneric =
			{
				"Serial", "Hue", "Name", "Body", "Color", "Direction", "Visible", "Poisoned", "YellowHits", "Paralized",
				"Human", "WarMode", "Female", "Hits", "HitsMax", "Stam", "StamMax", "Mana", "ManaMax", "Backpack", "Mount",
				"Quiver", "Notoriety", "Map", "InParty", "Properties", "Amount", "IsBagOfSending", "IsContainer", "IsCorpse",
				"IsDoor", "IsInBank", "Movable", "OnGround", "ItemID", "RootContainer", "Durability", "MaxDurability",
				"Contains", "Weight", "Position", "StaticID", "StaticHue", "StaticZ", "Flying"
			};

			string[] props = propsGeneric;

			#endregion

			#region Methods Descriptions

			ToolTipDescriptions tooltip;

			#region Description Player

			Dictionary<string, ToolTipDescriptions> descriptionPlayer = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Player.BuffsExist(string)", new string[] { "string BuffName" }, "bool", "Get a bool value if specific buff exist or not\n\tCheck the wiki for the possible strings");
			descriptionPlayer.Add("Player.BuffsExist", tooltip);

			tooltip = new ToolTipDescriptions("Player.GetBuffDescription(BuffIcon)", new string[] { "BuffIcon Name" }, "string", "Get description of a specific BuffIcon");
			descriptionPlayer.Add("Player.GetBuffDescription", tooltip);

			tooltip = new ToolTipDescriptions("Player.HeadMessage(int, string)", new string[] { "int MessageColor", "string Message" }, "void", "Display a message over self character with specified color");
			descriptionPlayer.Add("Player.HeadMessage", tooltip);

			tooltip = new ToolTipDescriptions("Player.InRangeMobile(Mobile or int, int)", new string[] { "Mobile MobileToCheck or int SerialMobileToCheck", "int range" }, "bool", "Retrieves a bool value if specific mobile is in a certain range");
			descriptionPlayer.Add("Player.InRangeMobile", tooltip);

			tooltip = new ToolTipDescriptions("Player.InRangeItem(Item or int, int)", new string[] { "Item ItemToCheck or int SerialItemToCheck", "int range" }, "bool", "Retrieves a bool value if specific item is in a certain range");
			descriptionPlayer.Add("Player.InRangeItem", tooltip);

			tooltip = new ToolTipDescriptions("Player.GetItemOnLayer(string)", new string[] { "string LayerName" }, "Item", "Retrieves a item value of item equipped on specific layer\n\tCheck the wiki for the possible strings");
			descriptionPlayer.Add("Player.GetItemOnLayer", tooltip);

			tooltip = new ToolTipDescriptions("Player.UnEquipItemByLayer(string)", new string[] { "string LayerName" }, "void", "Unequip an item on a specific layer\n\tCheck the wiki for the possible strings");
			descriptionPlayer.Add("Player.UnEquipItemByLayer", tooltip);

			tooltip = new ToolTipDescriptions("Player.EquipItem(Item or int)", new string[] { "Item ItemInstance or int SerialItem" }, "void", "Equip an item on a layer");
			descriptionPlayer.Add("Player.EquipItem", tooltip);

			tooltip = new ToolTipDescriptions("Player.EquipUO3D(List<int>)", new string[] { "List<int> SerialtoEquip" }, "void", "Equip a list o item by UO3D Packet");
			descriptionPlayer.Add("Player.EquipUO3D", tooltip);

			tooltip = new ToolTipDescriptions("Player.CheckLayer(string)", new string[] { "string LayerName" }, "bool", "Retrieves current status of a certain layer\n\tTrue: busy, False: free\n\tCheck the wiki for the possible strings");
			descriptionPlayer.Add("Player.CheckLayer", tooltip);

			tooltip = new ToolTipDescriptions("Player.GetAssistantLayer(string)", new string[] { "string LayerName" }, "Layer", "Retrives HexID from the Layer's name");
			descriptionPlayer.Add("Player.GetAssistantLayer", tooltip);

			tooltip = new ToolTipDescriptions("Player.GetSkillValue(string)", new string[] { "string SkillName" }, "dobule", "Get current value of a specific skill\n\tCheck the wiki for the possible strings");
			descriptionPlayer.Add("Player.GetSkillValue", tooltip);

			tooltip = new ToolTipDescriptions("Player.GetSkillCap(string)", new string[] { "string SkillName" }, "double", "Get current value of a specific skillcap\n\tCheck the wiki for the possible strings");
			descriptionPlayer.Add("Player.GetSkillCap", tooltip);

			tooltip = new ToolTipDescriptions("Player.GetSkillStatus(string)", new string[] { "string SkillName" }, "int", "Get lock status for a certain skill\n\tUP: 0, DOWN: 1, LOCKED: 2\n\tCheck the wiki for the possible strings");
			descriptionPlayer.Add("Player.GetSkillStatus", tooltip);

			tooltip = new ToolTipDescriptions("Player.UseSkill(string)", new string[] { "string SkillName" }, "void", "Use a specific skill\n\tCheck the wiki for the possible strings");
			descriptionPlayer.Add("Player.UseSkill", tooltip);

			tooltip = new ToolTipDescriptions("Player.ChatSay(int, string)", new string[] { "int MessageColor", "string Message" }, "void", "Send a message in say with a specific color");
			descriptionPlayer.Add("Player.ChatSay", tooltip);

			tooltip = new ToolTipDescriptions("Player.ChatEmote(int, string)", new string[] { "int MessageColor", "string Message" }, "void", "Send a message in emote with a specific color");
			descriptionPlayer.Add("Player.ChatEmote", tooltip);

			tooltip = new ToolTipDescriptions("Player.ChatWhisper(int, string)", new string[] { "int MessageColor", "string Message" }, "void", "Send a message in wishper with a specific color");
			descriptionPlayer.Add("Player.ChatWhisper", tooltip);

			tooltip = new ToolTipDescriptions("Player.ChatChannel(string)", new string[] { "string Message" }, "void", "Send a message in chat channel.");
			descriptionPlayer.Add("Player.ChatChannel", tooltip);

			tooltip = new ToolTipDescriptions("Player.ChatYell(int, string)", new string[] { "int MessageColor", "string Message" }, "void", "Send a message in yell with a specific color");
			descriptionPlayer.Add("Player.ChatYell", tooltip);

			tooltip = new ToolTipDescriptions("Player.ChatGuild(string)", new string[] { "string Message" }, "void", "Send a message in guild chat");
			descriptionPlayer.Add("Player.ChatGuild", tooltip);

			tooltip = new ToolTipDescriptions("Player.ChatAlliance(string)", new string[] { "string Message" }, "void", "Send a message in alliance chat");
			descriptionPlayer.Add("Player.ChatAlliance", tooltip);

			tooltip = new ToolTipDescriptions("Player.SetWarMode(bool)", new string[] { "bool WarStatus" }, "void", "Set character warmode status\n\t True: set Warmode ON, False: set Warmode OFF");
			descriptionPlayer.Add("Player.SetWarMode", tooltip);

			tooltip = new ToolTipDescriptions("Player.Attack(int)", new string[] { "int TargetSerial" }, "void", "Force character to atttack a specific serial");
			descriptionPlayer.Add("Player.Attack", tooltip);

			tooltip = new ToolTipDescriptions("Player.AttackLast()", new string[] { "none" }, "void", "Force character to attack last target");
			descriptionPlayer.Add("Player.AttackLast", tooltip);

			tooltip = new ToolTipDescriptions("Player.InParty()", new string[] { "none" }, "bool", "Check if a character is in party\n\tTrue: is in party, False: is not in party");
			descriptionPlayer.Add("Player.InParty", tooltip);

			tooltip = new ToolTipDescriptions("Player.ChatParty(string)", new string[] { "string Message" }, "void", "Send a message to party chat");
			descriptionPlayer.Add("Player.ChatParty", tooltip);

			tooltip = new ToolTipDescriptions("Player.PartyCanLoot(bool)", new string[] { "bool Flag" }, "void", "Set player party CanLoot flag\n\tTrue: Members can loot me, False: Member can't loot me");
			descriptionPlayer.Add("Player.PartyCanLoot", tooltip);

			tooltip = new ToolTipDescriptions("Player.PartyInvite()", new string[] { "none" }, "void", "Open a target prompt to invite new members");
			descriptionPlayer.Add("Player.PartyInvite", tooltip);

			tooltip = new ToolTipDescriptions("Player.PartyLeave()", new string[] { "none" }, "void", "Leave from party");
			descriptionPlayer.Add("Player.PartyLeave", tooltip);

			tooltip = new ToolTipDescriptions("Player.KickMember(int)", new string[] { "int SerialPersonToKick" }, "void", "Kick a member from party by serial\n\tOnly for party leader");
			descriptionPlayer.Add("Player.KickMember", tooltip);

			tooltip = new ToolTipDescriptions("Player.InvokeVirtue(string)", new string[] { "string VirtueName" }, "void", "Invoke a chracter virtue by name");
			descriptionPlayer.Add("Player.InvokeVirtue", tooltip);

			tooltip = new ToolTipDescriptions("Player.Walk(string)", new string[] { "string Direction" }, "void", "Move character in a specific direction\n\tCheck the wiki for the possible strings");
			descriptionPlayer.Add("Player.Walk", tooltip);

			tooltip = new ToolTipDescriptions("Player.PathFindTo(Point3D or (int, int, int))", new string[] { "Point3D Coords or ( int X, int Y, int Z )" }, "void", "Client pathfinder to specific location with Point3D or XYZ coordinates");
			descriptionPlayer.Add("Player.PathFindTo", tooltip);

            tooltip = new ToolTipDescriptions("Player.PathFindToPacket(int, int, int)", new string[] { "int X, int Y, int Z" }, "void", "Client pathfinder to specific location with XYZ coordinates\n\tPlayer can be blocked with items in path");
            descriptionPlayer.Add("Player.PathFindToPacket", tooltip);

            tooltip = new ToolTipDescriptions("Player.GetPropValue(string)", new string[] { "string PropName" }, "int", "Get property value of player");
			descriptionPlayer.Add("Player.GetPropValue", tooltip);

			tooltip = new ToolTipDescriptions("Player.GetPropStringByIndex(int)", new string[] { "int PropIndex" }, "string", "Get property name by index, if any property\n\tin selected index, return empty");
			descriptionPlayer.Add("Player.GetPropStringByIndex", tooltip);

			tooltip = new ToolTipDescriptions("Player.GetPropStringList()", new string[] { "none" }, "List<string>", "Get a list with all property name, if there are no\n\tproperties, list is empty");
			descriptionPlayer.Add("Player.GetPropStringList", tooltip);

			tooltip = new ToolTipDescriptions("Player.QuestButton()", new string[] { "none" }, "void", "Open quest menu linked to paperdoll quest button");
			descriptionPlayer.Add("Player.QuestButton", tooltip);

			tooltip = new ToolTipDescriptions("Player.GuildButton()", new string[] { "none" }, "void", "Open guild menu linked to paperdoll guild button");
			descriptionPlayer.Add("Player.GuildButton", tooltip);

			tooltip = new ToolTipDescriptions("Player.WeaponPrimarySA()", new string[] { "none" }, "void", "Set on Weapon Primary Ability");
			descriptionPlayer.Add("Player.WeaponPrimarySA", tooltip);

			tooltip = new ToolTipDescriptions("Player.WeaponSecondarySA()", new string[] { "none" }, "void", "Set on Weapon Secondary Ability");
			descriptionPlayer.Add("Player.WeaponSecondarySA", tooltip);

			tooltip = new ToolTipDescriptions("Player.WeaponClearSA()", new string[] { "none" }, "void", "Clear ability if active");
			descriptionPlayer.Add("Player.WeaponClearSA", tooltip);

			tooltip = new ToolTipDescriptions("Player.WeaponStunSA()", new string[] { "none" }, "void", "Set on No Weapon Stun");
			descriptionPlayer.Add("Player.WeaponStunSA", tooltip);

			tooltip = new ToolTipDescriptions("Player.WeaponDisarmSA()", new string[] { "none" }, "void", "Set on No Weapon Disarm");
			descriptionPlayer.Add("Player.WeaponDisarmSA", tooltip);

			tooltip = new ToolTipDescriptions("Player.Fly()", new string[] { "bool OnOF" }, "void", "Enable or disable Gargoyle Fly");
			descriptionPlayer.Add("Player.Fly", tooltip);

			#endregion

			#region Description Spells

			Dictionary<string, ToolTipDescriptions> descriptionSpells = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Spells.CastMagery(string)", new string[] { "string SpellName" }, "void", "Cast a magery spell by spell name\n\tCheck the wiki for the possible strings");
			descriptionSpells.Add("Spells.CastMagery", tooltip);

			tooltip = new ToolTipDescriptions("Spells.CastNecro(string)", new string[] { "string SpellName" }, "void", "Cast a necro spell by spell name\n\tCheck the wiki for the possible strings");
			descriptionSpells.Add("Spells.CastNecro", tooltip);

			tooltip = new ToolTipDescriptions("Spells.CastChivalry(string)", new string[] { "string SpellName" }, "void", "Cast a chivalry spell by spell name\n\tCheck the wiki for the possible strings");
			descriptionSpells.Add("Spells.CastChivalry", tooltip);

			tooltip = new ToolTipDescriptions("Spells.CastBushido(string)", new string[] { "string SpellName" }, "void", "Cast a bushido spell by spell name\n\tCheck the wiki for the possible strings");
			descriptionSpells.Add("Spells.CastBushido", tooltip);

			tooltip = new ToolTipDescriptions("Spells.CastNinjitsu(string)", new string[] { "string SpellName" }, "void", "Cast a ninjitsu spell by spell name\n\tCheck the wiki for the possible strings");
			descriptionSpells.Add("Spells.CastNinjitsu", tooltip);

			tooltip = new ToolTipDescriptions("Spells.CastSpellweaving(string)", new string[] { "string SpellName" }, "void", "Cast a spellweaving spell by spell name\n\tCheck the wiki for the possible strings");
			descriptionSpells.Add("Spells.CastSpellweaving", tooltip);

			tooltip = new ToolTipDescriptions("Spells.CastMysticism(string)", new string[] { "string SpellName" }, "void", "Cast a mysticism spell by spell name\n\tCheck the wiki for the possible strings");
			descriptionSpells.Add("Spells.CastMysticism", tooltip);

			tooltip = new ToolTipDescriptions("Spells.CastBard(string)", new string[] { "string SpellName" }, "void", "Cast a bard spell by spell name\n\tCheck the wiki for the possible strings");
			descriptionSpells.Add("Spells.CastBard", tooltip);

			#endregion

			#region Description Mobiles

			Dictionary<string, ToolTipDescriptions> descriptionMobiles = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Mobiles.FindBySerial(int)", new string[] { "int MobileSerial" }, "Mobile", "Find mobile instance by specific serial");
			descriptionMobiles.Add("Mobiles.FindBySerial", tooltip);

			tooltip = new ToolTipDescriptions("Mobiles.UseMobile(Mobile or int)", new string[] { "Mobile MobileIstance or int MobileSerial" }, "void", "Use (double click) specific mobile");
			descriptionMobiles.Add("Mobiles.UseMobile", tooltip);

			tooltip = new ToolTipDescriptions("Mobiles.SingleClick(Mobile or int)", new string[] { "Mobile MobileIstance or int MobileSerial" }, "void", "Perform a single click on specific mobile");
			descriptionMobiles.Add("Mobiles.SingleClick", tooltip);

			tooltip = new ToolTipDescriptions("Mobiles.Filter()", new string[] { "none" }, "Filter", "Create a new instance for a mobile filter");
			descriptionMobiles.Add("Mobiles.Filter", tooltip);

			tooltip = new ToolTipDescriptions("Mobiles.ApplyFilter(Filter)", new string[] { "Filter MobileFilter" }, "List<Mobile>", "Search mobiles by filter");
			descriptionMobiles.Add("Mobiles.ApplyFilter", tooltip);

			tooltip = new ToolTipDescriptions("Mobiles.Message(Mobile or int, int, string)", new string[] { "Mobile MobileIstance or int MobileSerial", "int ColorMessage", "string Message" }, "void", "Display a message with a certain color over a specified mobile");
			descriptionMobiles.Add("Mobiles.Message", tooltip);

			tooltip = new ToolTipDescriptions("Mobiles.WaitForProps(Mobile or int, int)", new string[] { "Mobile MobileIstance or int MobileSerial", "int TimeoutProps" }, "void", "Wait to retrieves properties of a specific mobile within a certain time");
			descriptionMobiles.Add("Mobiles.WaitForProps", tooltip);

			tooltip = new ToolTipDescriptions("Mobiles.GetPropValue(Mobile or int, string)", new string[] { "Mobile MobileIstance or int MobileSerial", "string PropName" }, "int", "Get value of a specific property from a certain mobile");
			descriptionMobiles.Add("Mobiles.GetPropValue", tooltip);

			tooltip = new ToolTipDescriptions("Mobiles.GetPropStringByIndex(Mobile or int, int)", new string[] { "Mobile MobileIstance or int MobileSerial", "int PropIndex" }, "string", "Get string name of a property by index,\n\tif there's no property in selected index, return empty");
			descriptionMobiles.Add("Mobiles.GetPropStringByIndex", tooltip);

			tooltip = new ToolTipDescriptions("Mobiles.GetPropStringList(Mobile or int)", new string[] { "Mobile MobileIstance or int MobileSerial" }, "List<string>", "Get list of all properties name of a specific mobile, if list is empty, returns empty");
			descriptionMobiles.Add("Mobiles.GetPropStringList", tooltip);

			tooltip = new ToolTipDescriptions("Mobiles.ContextExist(serial or mobile, string)", new string[] { "int serial or mobile, string nametosearch" }, "int", "Check if mobile have this context. Return Context ID or -1 if not valid item or not present");
			descriptionMobiles.Add("Mobiles.ContextExist", tooltip);

			#endregion

			#region Description Items

			Dictionary<string, ToolTipDescriptions> descriptionItems = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Items.FindBySerial(int)", new string[] { "int ItemSerial" }, "Item", "Find item instance by specific serial");
			descriptionItems.Add("Items.FindBySerial", tooltip);

            tooltip = new ToolTipDescriptions("Items.Move(Item or int, Item or Mobile or int, int, (optional)(int, int))", new string[] { "Item Source or int SourceItemSerial", "Item DestinationItem or Mobile DestinationMobile or int DestinationSerial", "int AmountToMove", "int X", "int Y" }, "void", "Move a item with a certain amount to specific destination\n\tIf amount is set to 0 or bigger value of the amount, move the entire stack\n\tIs also possible to declare coordinates where item needs to be positioned\n\tinto the container");
            descriptionItems.Add("Items.Move", tooltip);

            tooltip = new ToolTipDescriptions("Items.MoveOnGround(Item or int, int, int, int, int)", new string[] { "Item ItemInstance or ItemSerial", "int amount", "int X", "int Y", "int Z" }, "void", "Move an item with a specific amount to the ground in specified coordinates\n\tIf amount is set to 0 or bigger value of the amount, move the entire stack");
            descriptionItems.Add("Items.MoveOnGround", tooltip);

            tooltip = new ToolTipDescriptions("Items.DropItemGroundSelf(Item, int)", new string[] { "Item ItemInstance", "int Amount" }, "void", "Drop on character feets specified item with certain amount.\n\tIf amount is set to 0 or bigger value of the amount, move the entire stack");
			descriptionItems.Add("Items.DropItemGroundSelf", tooltip);

			tooltip = new ToolTipDescriptions("Items.UseItem(Item or int)", new string[] { "Item ItemInstance or int ItemSerial" }, "void", "Use (double click) specified item.");
			descriptionItems.Add("Items.UseItem", tooltip);

			tooltip = new ToolTipDescriptions("Items.SingleClick(Item or int)", new string[] { "Item ItemInstance or int ItemSerial" }, "void", "Perform a single click on a specific item");
			descriptionItems.Add("Items.SingleClick", tooltip);

			tooltip = new ToolTipDescriptions("Items.WaitForProps(Item or int, int)", new string[] { "Item ItemInstance or int ItemSerial", "int TimeoutProps" }, "void", "Wait to retrieves property of a specific item for a certain time");
			descriptionItems.Add("Items.WaitForProps", tooltip);

			tooltip = new ToolTipDescriptions("Items.GetPropValue(Item or int, string)", new string[] { "Item ItemInstance or int ItemSerial", "string PropName" }, "int", "Get value of item property");
			descriptionItems.Add("Items.GetPropValue", tooltip);

			tooltip = new ToolTipDescriptions("Items.GetPropStringByIndex(Item or int, int)", new string[] { "Item ItemInstance or int ItemSerial", "int PropIndex" }, "string", "Get name of property by index, if no property in selected index, return empty");
			descriptionItems.Add("Items.GetPropStringByIndex", tooltip);

			tooltip = new ToolTipDescriptions("Items.GetPropStringList(Item or int)", new string[] { "Item ItemInstance or int ItemSerial" }, "List<string>", "Get list of all property names on specific item, if no property, returns empty list");
			descriptionItems.Add("Items.GetPropStringList", tooltip);

			tooltip = new ToolTipDescriptions("Items.WaitForContents(Item or int, int)", new string[] { "Item ItemInstance or int ItemSerial", "int TimeoutContents" }, "void", "Force a item to open and wait for a response for item inside");
			descriptionItems.Add("Items.WaitForContents", tooltip);

			tooltip = new ToolTipDescriptions("Items.Message(Item or int, int, string)", new string[] { "Item ItemInstance or int ItemSerial", "int MessageColor", "string Message" }, "void", "Display a message with specific color over the item");
			descriptionItems.Add("Items.Message", tooltip);

			tooltip = new ToolTipDescriptions("Items.Filter()", new string[] { "none" }, "Filter", "Create a new instance for item filter");
			descriptionItems.Add("Items.Filter", tooltip);

			tooltip = new ToolTipDescriptions("Items.ApplyFilter(Filter)", new string[] { "Filter ItemFilter" }, "List<Item>", "Search items by filter");
			descriptionItems.Add("Items.ApplyFilter", tooltip);

			tooltip = new ToolTipDescriptions("Items.BackpackCount(int, int)", new string[] { "int ItemID", "int Color" }, "int", "Returns amount of specific item (by ItemID) and color in backpack and subcontainer\n\tColor -1 is wildcard for all color");
			descriptionItems.Add("Items.BackpackCount", tooltip);

			tooltip = new ToolTipDescriptions("Items.ContainerCount(item or int, int, int)", new string[] { "Item Container or int ContainerSerial", "int ItemID", "int Color" }, "List<Item>", "Returns amount of specific item (by ItemID) and color in a specific container\n\tColor -1 is wildcard for all color");
			descriptionItems.Add("Items.ContainerCount", tooltip);

			tooltip = new ToolTipDescriptions("Items.UseItemByID(int, int)", new string[] { "int ItemID", "int Color" }, "void", "Use item whit specific ID\n\tColor -1 is wildcard for all color");
			descriptionItems.Add("Items.UseItemByID", tooltip);

			tooltip = new ToolTipDescriptions("Items.UseItemOnTarget(int, int)", new string[] { "int itemserial", "int targetserial" }, "void", "Use a item on target direct whitout using target system.");
			descriptionItems.Add("Items.UseItemOnTarget", tooltip);

			tooltip = new ToolTipDescriptions("Items.Hide(int or item)", new string[] { "int serial or item itemtohide"}, "void", "Use to hide a item in screen");
			descriptionItems.Add("Items.Hide", tooltip);

			tooltip = new ToolTipDescriptions("Items.ContextExist(serial or item, string)", new string[] { "int serial or item, string nametosearch" }, "int", "Check if item have this context. Return Context ID or -1 if not valid item or not present");
			descriptionItems.Add("Items.ContextExist", tooltip);

			#endregion

			#region Description Misc

			Dictionary<string, ToolTipDescriptions> descriptionMisc = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Misc.SendMessage(string or int or bool, (optional)int)", new string[] { "string Message or int Value or bool Status", "int Color" }, "void", "Send a system message\n\tIf pass color, it colors the message");
			descriptionMisc.Add("Misc.SendMessage", tooltip);

			tooltip = new ToolTipDescriptions("Misc.Resync()", new string[] { "none" }, "void", "Resync game data");
			descriptionMisc.Add("Misc.Resync", tooltip);

			tooltip = new ToolTipDescriptions("Misc.Pause(int)", new string[] { "int Delay" }, "void", "Pause script for N milliseconds");
			descriptionMisc.Add("Misc.Pause", tooltip);

			tooltip = new ToolTipDescriptions("Misc.Beep()", new string[] { "none" }, "void", "Play beep system sound");
			descriptionMisc.Add("Misc.Beep", tooltip);

			tooltip = new ToolTipDescriptions("Misc.Disconnect()", new string[] { "none" }, "void", "Force client to disconnect");
			descriptionMisc.Add("Misc.Disconnect", tooltip);

			tooltip = new ToolTipDescriptions("Misc.WaitForContext(int or Mobile or Item, int)", new string[] { "int Serial or Mobile MobileInstance or Item ItemInstance", "int Timeout" }, "void", "Wait a server response for a context menu request");
			descriptionMisc.Add("Misc.WaitForContext", tooltip);

			tooltip = new ToolTipDescriptions("Misc.ContextReply(int or Mobile or Item, int)", new string[] { "int Serial or Mobile MobileInstance or Item ItemInstance", "int MenuID" }, "void", "Response to a context menu on mobile or item. MenuID is base zero");
			descriptionMisc.Add("Misc.ContextReply", tooltip);

			tooltip = new ToolTipDescriptions("Misc.ReadSharedValue(string)", new string[] { "string NameOfValue" }, "object", "Read a shared value, if value not exist return null");
			descriptionMisc.Add("Misc.ReadSharedValue", tooltip);

			tooltip = new ToolTipDescriptions("Misc.RemoveSharedValue(string)", new string[] { "string NameOfValue" }, "void", "Remove a shared value");
			descriptionMisc.Add("Misc.RemoveSharedValue", tooltip);

			tooltip = new ToolTipDescriptions("Misc.CheckSharedValue(string)", new string[] { "string NameOfValue" }, "bool", "Get a True or False if value exist");
			descriptionMisc.Add("Misc.CheckSharedValue", tooltip);

			tooltip = new ToolTipDescriptions("Misc.SetSharedValue(string, object)", new string[] { "string NameOfValue", "object ValueToSet" }, "void", "Set a value by specific name, if value exist, it replace the value");
			descriptionMisc.Add("Misc.SetSharedValue", tooltip);

			tooltip = new ToolTipDescriptions("Misc.HasMenu()", new string[] { "none" }, "bool", "Return status of menu\n\tTrue: menu opened, False: menu closed");
			descriptionMisc.Add("Misc.HasMenu", tooltip);

			tooltip = new ToolTipDescriptions("Misc.CloseMenu()", new string[] { "none" }, "void", "Close opened menu");
			descriptionMisc.Add("Misc.CloseMenu", tooltip);

			tooltip = new ToolTipDescriptions("Misc.MenuContains(string)", new string[] { "string TextToSearch" }, "bool", "Search in opened menu if contains a specific text");
			descriptionMisc.Add("Misc.MenuContains", tooltip);

			tooltip = new ToolTipDescriptions("Misc.GetMenuTitle()", new string[] { "none" }, "string", "Return title for opened menu");
			descriptionMisc.Add("Misc.GetMenuTitle", tooltip);

			tooltip = new ToolTipDescriptions("Misc.WaitForMenu(int)", new string[] { "int Timeout" }, "void", "Pause script until server send menu, delay in Milliseconds");
			descriptionMisc.Add("Misc.WaitForMenu", tooltip);

			tooltip = new ToolTipDescriptions("Misc.MenuResponse(string)", new string[] { "string SubmitName" }, "void", "Perform a menu response by subitem name\n\tIf item not exist, close menu");
			descriptionMisc.Add("Misc.MenuResponse", tooltip);

			tooltip = new ToolTipDescriptions("Misc.HasQueryString()", new string[] { "none" }, "bool", "Check if have a query string menu opened");
			descriptionMisc.Add("Misc.HasQueryString", tooltip);

			tooltip = new ToolTipDescriptions("Misc.WaitForQueryString(int)", new string[] { "int Timeout" }, "void", "Pause script until server send query string request, delay in Milliseconds");
			descriptionMisc.Add("Misc.WaitForQueryString", tooltip);

			tooltip = new ToolTipDescriptions("Misc.QueryStringResponse(bool, string)", new string[] { "bool YesCancelStatus", "string StringToResponse" }, "void", "Perform a query string response by ok or cancel button and specific response text");
			descriptionMisc.Add("Misc.QueryStringResponse", tooltip);

			tooltip = new ToolTipDescriptions("Misc.NoOperation()", new string[] { "none" }, "void", "Do nothing");
			descriptionMisc.Add("Misc.NoOperation", tooltip);

			tooltip = new ToolTipDescriptions("Misc.ScriptRun(string)", new string[] { "string ScriptFilename" }, "void", "Run a script by filename\n\tScript must be present in script grid");
			descriptionMisc.Add("Misc.ScriptRun", tooltip);

			tooltip = new ToolTipDescriptions("Misc.ScriptStop(string)", new string[] { "string ScriptFilename" }, "void", "Stop a script by filename\n\tScritp must be present in script grid");
			descriptionMisc.Add("Misc.ScriptStop", tooltip);

			tooltip = new ToolTipDescriptions("Misc.ScriptStatus(string)", new string[] { "string ScriptFilename" }, "bool", "Get status of a script if is running or not\n\tScript must be present in script grid");
			descriptionMisc.Add("Misc.ScriptStatus", tooltip);

			tooltip = new ToolTipDescriptions("Misc.PetRename(Mobile or int, string)", new string[] { "Mobile MobileInstance or int MobileSerial", "string NewName" }, "void", "Rename a specific pet.\n\tMust be tamed");
			descriptionMisc.Add("Misc.PetRename", tooltip);

			#endregion

			#region Description Target

			Dictionary<string, ToolTipDescriptions> descriptionTarget = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Target.HasTarget()", new string[] { "none" }, "bool", "Get status of target if exists or not");
			descriptionTarget.Add("Target.HasTarget", tooltip);

			tooltip = new ToolTipDescriptions("Target.GetLast()", new string[] { "none" }, "int", "Get serial number of last target");
			descriptionTarget.Add("Target.GetLast", tooltip);

			tooltip = new ToolTipDescriptions("Target.GetLastAttack()", new string[] { "none" }, "int", "Get serial number of last attack target");
			descriptionTarget.Add("Target.GetLastAttack", tooltip);

			tooltip = new ToolTipDescriptions("Target.WaitForTarget(int, bool)", new string[] { "int TimeoutTarget, bool NoShowTarget" }, "none", "Pause script to wait server to send target request\n\tTimeout is in Milliseconds, and can select if show or not target cursor in game");
			descriptionTarget.Add("Target.WaitForTarget", tooltip);

			tooltip = new ToolTipDescriptions("Target.TargetExecute(int or Item or Mobile or (int, int, int, (optional)int))", new string[] { "int Serial or Item ItemInstance or Mobile MobileInstance or ( int X, int Y, int Z, int TileID )" }, "void", "Send target execute to specific serial, item, mobile\n\tIn case of X Y Z coordinates, can be defined a tileid");
			descriptionTarget.Add("Target.TargetExecute", tooltip);

			tooltip = new ToolTipDescriptions("Target.PromptTarget()", new string[] { "none" }, "int", "Pick the serial from item or mobile");
			descriptionTarget.Add("Target.PromptTarget", tooltip);

			tooltip = new ToolTipDescriptions("Target.Cancel()", new string[] { "none" }, "void", "Cancel target cursor");
			descriptionTarget.Add("Target.Cancel", tooltip);

			tooltip = new ToolTipDescriptions("Target.Last()", new string[] { "none" }, "void", "Target last object or mobile targetted");
			descriptionTarget.Add("Target.Last", tooltip);

			tooltip = new ToolTipDescriptions("Target.LastQueued()", new string[] { "none" }, "void", "Queue next target to Last");
			descriptionTarget.Add("Target.LastQueued", tooltip);

			tooltip = new ToolTipDescriptions("Target.Self()", new string[] { "none" }, "void", "Target self");
			descriptionTarget.Add("Target.Self", tooltip);

			tooltip = new ToolTipDescriptions("Target.SelfQueued()", new string[] { "none" }, "void", "Queue Next target to Self");
			descriptionTarget.Add("Target.SelfQueued", tooltip);

			tooltip = new ToolTipDescriptions("Target.SetLast(Mobile or int)", new string[] { "Mobile MobileTarget or int TargetSerial" }, "void", "Force set last target to specific mobile, by mobile instance or serial");
			descriptionTarget.Add("Target.SetLast", tooltip);

			tooltip = new ToolTipDescriptions("Target.ClearLast()", new string[] { "none" }, "void", "Clear Last Target");
			descriptionTarget.Add("Target.ClearLast", tooltip);

			tooltip = new ToolTipDescriptions("Target.ClearQueue()", new string[] { "none" }, "void", "Clear Queue Target");
			descriptionTarget.Add("Target.ClearQueue", tooltip);

			tooltip = new ToolTipDescriptions("Target.ClearLastandQueue()", new string[] { "none" }, "void", "Clear Last and Queue Target");
			descriptionTarget.Add("Target.ClearLastandQueue", tooltip);

			tooltip = new ToolTipDescriptions("Target.SetLastTargetFromList(string)", new string[] { "string TargetFilterName" }, "bool", "Set Last Target from GUI Filter selector");
			descriptionTarget.Add("Target.SetLastTargetFromList", tooltip);

			tooltip = new ToolTipDescriptions("Target.PerformTargetFromList(string)", new string[] { "string TargetFilterName" }, "bool", "Execute Target from GUI Filter selector");
			descriptionTarget.Add("Target.PerformTargetFromList", tooltip);

			tooltip = new ToolTipDescriptions("Target.AttackTargetFromList(string)", new string[] { "string TargetFilterName" }, "bool", "Attack Target from GUI Filter selector");
			descriptionTarget.Add("Target.AttackTargetFromList", tooltip);

			#endregion

			#region Description Gumps

			Dictionary<string, ToolTipDescriptions> descriptionGumps = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Gumps.CurrentGump()", new string[] { "none" }, "uint", "Return a integet with ID of last gump opened and still open");
			descriptionGumps.Add("Gumps.CurrentGump", tooltip);

			tooltip = new ToolTipDescriptions("Gumps.HasGump()", new string[] { "none" }, "bool", "Get status to check if have a gump opened or not");
			descriptionGumps.Add("Gumps.HasGump", tooltip);

			tooltip = new ToolTipDescriptions("Gumps.CloseGump(uint)", new string[] { "uint GumpID" }, "void", "Close a specific Gump");
			descriptionGumps.Add("Gumps.CloseGump", tooltip);

			tooltip = new ToolTipDescriptions("Gumps.ResetGump()", new string[] { "none" }, "void", "Clean gump status");
			descriptionGumps.Add("Gumps.ResetGump", tooltip);

			tooltip = new ToolTipDescriptions("Gumps.WaitForGump(uint, int)", new string[] { "uint GumpID", "int TimeoutGump" }, "void", "Pause script to wait server to send gump after operation for call gump\n\tTimeout is in Milliseconds");
			descriptionGumps.Add("Gumps.WaitForGump", tooltip);

			tooltip = new ToolTipDescriptions("Gumps.SendAction(uint, int)", new string[] { "uint GumpID", "int ButtonID" }, "void", "Send a gump response by GumpID and ButtonID");
			descriptionGumps.Add("Gumps.SendAction", tooltip);

			tooltip = new ToolTipDescriptions("Gumps.SendAdvancedAction(uint, int, List<int>, (optional)List<int>, (optional)List<string>)", new string[] { "uint GumpID", "int ButtonID", "List<int> Switches", "List<int> TextID", "List<string> Texts" }, "void", "Send a gump response by GumpID and ButtonID and advanced switch in gumps\n\tYou can add a switch list with all parameters need setted in gump windows\n\tCan be also choose to send text to be filled in gump");
			descriptionGumps.Add("Gumps.SendAdvancedAction", tooltip);

			tooltip = new ToolTipDescriptions("Gumps.LastGumpGetLine(int)", new string[] { "int LineNumber" }, "string", "Get the text in gump by line number, Gump must be still open to get data");
			descriptionGumps.Add("Gumps.LastGumpGetLine", tooltip);

			tooltip = new ToolTipDescriptions("Gumps.LastGumpGetLineList()", new string[] { "none" }, "List<string>", "Get all texts in gump. Gump must be still open for get data");
			descriptionGumps.Add("Gumps.LastGumpGetLineList", tooltip);

			tooltip = new ToolTipDescriptions("Gumps.LastGumpTextExist(string)", new string[] { "string TextToSearch" }, "bool", "Search text inside a gump text\n\tTrue: found, False: not found\n\tGump must be still open to get data");
			descriptionGumps.Add("Gumps.LastGumpTextExist", tooltip);

			tooltip = new ToolTipDescriptions("Gumps.LastGumpTextExistByLine(int, string)", new string[] { "int LineNumber", "string TextToSearch" }, "bool", "Search text inside a gump text by line number\n\tTrue: found, False: not found\n\tGump must be still open to get data");
			descriptionGumps.Add("Gumps.LastGumpTextExistByLine", tooltip);

			#endregion

			#region Description Journal

			Dictionary<string, ToolTipDescriptions> descriptionJournal = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Journal.Clear()", new string[] { "none" }, "void", "Clear data in journal buffer");
			descriptionJournal.Add("Journal.Clear", tooltip);

			tooltip = new ToolTipDescriptions("Journal.Search(string)", new string[] { "string TextToSearch" }, "bool", "Search a text in all journal buffer, and text is case sensitive\n\tTrue: text found, False: text not found");
			descriptionJournal.Add("Journal.Search", tooltip);

			tooltip = new ToolTipDescriptions("Journal.SearchByName(string, string)", new string[] { "string TextToSearch", "string SenderName" }, "bool", "Search a text in all journal buffer by sender name, and text and sender name are case sensitive\n\tTrue: text found, False: text not found");
			descriptionJournal.Add("Journal.SearchByName", tooltip);

			tooltip = new ToolTipDescriptions("Journal.SearchByColor(string, int)", new string[] { "string TextToSearch", "int ColorToSearch" }, "bool", "Search a text in all journal buffer by color, and text is case sensitive\n\tTrue: text found, False: text not found");
			descriptionJournal.Add("Journal.SearchByColor", tooltip);

			tooltip = new ToolTipDescriptions("Journal.SearchByType(string, string)", new string[] { "string TextToSearch", "string MessageType" }, "bool", "Search a text in all journal buffer by type, and text and type are case sensitive\n\tTrue: text found, False: text not found\n\tCheck the wiki for the possible strings");
			descriptionJournal.Add("Journal.SearchByType", tooltip);

			tooltip = new ToolTipDescriptions("Journal.GetLineText(string)", new string[] { "string TextToSearch" }, "string", "Search and get last line with searched text, and text is case sensitive\n\tTrue: text found, False: text not found");
			descriptionJournal.Add("Journal.GetLineText", tooltip);

			tooltip = new ToolTipDescriptions("Journal.GetSpeechName()", new string[] { "none" }, "List<string>", "Get a list of all players name and object speech");
			descriptionJournal.Add("Journal.GetSpeechName", tooltip);

			tooltip = new ToolTipDescriptions("Journal.WaitJournal(string, int)", new string[] { "string TextToSearch", "int TimeoutJournal" }, "void", "Pause script and wait until text is present in journal, and text is case sensitive\n\tTimeout in Milliseconds");
			descriptionJournal.Add("Journal.WaitJournal", tooltip);

			#endregion

			#region Description AutoLoot

			Dictionary<string, ToolTipDescriptions> descriptionAutoLoot = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("AutoLoot.Status()", new string[] { "none" }, "bool", "Get status of autoloot engine\n\tTrue: is running, False: is not running");
			descriptionAutoLoot.Add("AutoLoot.Status", tooltip);

			tooltip = new ToolTipDescriptions("AutoLoot.Start()", new string[] { "none" }, "void", "Start autoloot engine");
			descriptionAutoLoot.Add("AutoLoot.Start", tooltip);

			tooltip = new ToolTipDescriptions("AutoLoot.Stop()", new string[] { "none" }, "void", "Stop autoloot engine");
			descriptionAutoLoot.Add("AutoLoot.Stop", tooltip);

			tooltip = new ToolTipDescriptions("AutoLoot.ChangeList(string)", new string[] { "string ListName" }, "void", "Change list of autoloot item. List must exist in autoloot GUI configuration");
			descriptionAutoLoot.Add("AutoLoot.ChangeList", tooltip);

			tooltip = new ToolTipDescriptions("AutoLoot.RunOnce(AutoLootItem, double, Filter)", new string[] { "AutoLootItem ItemList", "double DelayGrabInMs", "Filter FilterToSearch" }, "void", "Start autoloot with certain parameters. AutoLootitem is a list type for item\n\tdelay in seconds to grab and filter for search on ground");
			descriptionAutoLoot.Add("AutoLoot.RunOnce", tooltip);

			#endregion

			#region Description Scavenger

			Dictionary<string, ToolTipDescriptions> descriptionScavenger = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Scavenger.Status()", new string[] { "none" }, "bool", "Get status of scavenger engine\n\tTrue: is running, False: is not running");
			descriptionScavenger.Add("Scavenger.Status", tooltip);

			tooltip = new ToolTipDescriptions("Scavenger.Start()", new string[] { "none" }, "void", "Start scavenger engine");
			descriptionScavenger.Add("Scavenger.Start", tooltip);

			tooltip = new ToolTipDescriptions("Scavenger.Stop()", new string[] { "none" }, "void", "Stop scavenger engine");
			descriptionScavenger.Add("Scavenger.Stop", tooltip);

			tooltip = new ToolTipDescriptions("Scavenger.ChangeList(string)", new string[] { "string ListName" }, "void", "Change list of scavenger item. List must exist in scavenger GUI configuration");
			descriptionScavenger.Add("Scavenger.ChangeList", tooltip);

			tooltip = new ToolTipDescriptions("Scavenger.RunOnce(ScavengerItem, double, Filter)()", new string[] { "ScavengerItem ItemList", "double DelayGrabInMs", "Filter FilterToSearch" }, "void", "Start scavenger with certain parameters. ScavengerItem is a list type for item\n\tdelay in seconds to grab and filter for search on ground");
			descriptionScavenger.Add("Scavenger.RunOnce", tooltip);

			#endregion

			#region Description Organizer

			Dictionary<string, ToolTipDescriptions> descriptionOrganizer = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Organizer.Status()", new string[] { "none" }, "bool", "Get status of organizer engine\n\tTrue: is running, False: is not running");
			descriptionOrganizer.Add("Organizer.Status", tooltip);

			tooltip = new ToolTipDescriptions("Organizer.FStart()", new string[] { "none" }, "void", "Start organizer engine");
			descriptionOrganizer.Add("Organizer.FStart", tooltip);

			tooltip = new ToolTipDescriptions("Organizer.FStop()", new string[] { "none" }, "void", "Stop organizer engine");
			descriptionOrganizer.Add("Organizer.FStop", tooltip);

			tooltip = new ToolTipDescriptions("Organizer.ChangeList(string)", new string[] { "strign ListName" }, "void", "Change list of organizer item. List must be exist in organizer GUI configuration");
			descriptionOrganizer.Add("Organizer.ChangeList", tooltip);

			#endregion

			#region Description Restock

			Dictionary<string, ToolTipDescriptions> descriptionRestock = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Restock.Status()", new string[] { "none" }, "bool", "Get status of restock engine\n\tTrue: is running, False: is not running");
			descriptionRestock.Add("Restock.Status", tooltip);

			tooltip = new ToolTipDescriptions("Restock.FStart()", new string[] { "none" }, "void", "Start restock engine");
			descriptionRestock.Add("Restock.FStart", tooltip);

			tooltip = new ToolTipDescriptions("Restock.FStop()", new string[] { "none" }, "void", "Stop restock engine");
			descriptionRestock.Add("Restock.FStop", tooltip);

			tooltip = new ToolTipDescriptions("Restock.ChangeList(string)", new string[] { "strign ListName" }, "void", "Change list of restock item. List must be exist in restock GUI configuration");
			descriptionRestock.Add("Restock.ChangeList", tooltip);

			#endregion

			#region Description SellAgent

			Dictionary<string, ToolTipDescriptions> descriptionSellAgent = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("SellAgent.Status()", new string[] { "none" }, "bool", "Get status of vendor sell filter\n\tTrue: enabled, False: disabled");
			descriptionSellAgent.Add("SellAgent.Status", tooltip);

			tooltip = new ToolTipDescriptions("SellAgent.Enable()", new string[] { "none" }, "void", "Enable vendor sell filter");
			descriptionSellAgent.Add("SellAgent.Enable", tooltip);

			tooltip = new ToolTipDescriptions("SellAgent.Disable()", new string[] { "none" }, "void", "Disable vendor sell filter");
			descriptionSellAgent.Add("SellAgent.Disable", tooltip);

			tooltip = new ToolTipDescriptions("SellAgent.ChangeList(string)", new string[] { "string ListName" }, "void", "Change list of vendor sell filter, List must be exist in vendor sell GUI configuration");
			descriptionSellAgent.Add("SellAgent.ChangeList", tooltip);

			#endregion

			#region Description BuyAgent

			Dictionary<string, ToolTipDescriptions> descriptionBuyAgent = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("BuyAgent.Status()", new string[] { "none" }, "bool", "Get status of vendor buy filter\n\tTrue: enabled, False: disabled");
			descriptionBuyAgent.Add("BuyAgent.Status", tooltip);

			tooltip = new ToolTipDescriptions("BuyAgent.Enable()", new string[] { "none" }, "void", "Enable vendor buy filter");
			descriptionBuyAgent.Add("BuyAgent.Enable", tooltip);

			tooltip = new ToolTipDescriptions("BuyAgent.Disable()", new string[] { "none" }, "void", "Disable vendor buy filter");
			descriptionBuyAgent.Add("BuyAgent.Disable", tooltip);

			tooltip = new ToolTipDescriptions("BuyAgent.ChangeList(string)", new string[] { "string ListName" }, "void", "Change list of vendor Buy filter, List must be exist in vendor Buy GUI configuration");
			descriptionBuyAgent.Add("BuyAgent.ChangeList", tooltip);

			#endregion

			#region Description Dress

			Dictionary<string, ToolTipDescriptions> descriptionDress = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Dress.DessStatus()", new string[] { "none" }, "bool", "Get status of dress engine\n\tTrue: is running, False: is not running");
			descriptionDress.Add("Dress.DessStatus", tooltip);

			tooltip = new ToolTipDescriptions("Dress.UnDressStatus()", new string[] { "none" }, "bool", "Get status of undress engine\n\tTrue: is running, False: is not running");
			descriptionDress.Add("Dress.UnDressStatus", tooltip);

			tooltip = new ToolTipDescriptions("Dress.DressFStart()", new string[] { "none" }, "void", "Start dress engine");
			descriptionDress.Add("Dress.DressFStart", tooltip);

			tooltip = new ToolTipDescriptions("Dress.UnDressFStart()", new string[] { "none" }, "void", "Start undress engine");
			descriptionDress.Add("Dress.UnDressFStart", tooltip);

			tooltip = new ToolTipDescriptions("Dress.DressFStop()", new string[] { "none" }, "void", "Stop dress engine");
			descriptionDress.Add("Dress.DressFStop", tooltip);

			tooltip = new ToolTipDescriptions("Dress.UnDressFStop()", new string[] { "none" }, "void", "Stop undress engine");
			descriptionDress.Add("Dress.UnDressFStop", tooltip);

			tooltip = new ToolTipDescriptions("Dress.ChangeList(string)", new string[] { "string ListName" }, "void", "Change item list of dress engine, List must be exist in dress / undress GUI configuration");
			descriptionDress.Add("Dress.ChangeList", tooltip);

			#endregion

			#region Description Friend

			Dictionary<string, ToolTipDescriptions> descriptionFriend = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Friend.IsFriend(int)", new string[] { "int SerialToSearch" }, "bool", "Check if serial is in friend list or not, if partyinclude option is active on GUI, search also in party\n\tTrue: found, False: not found");
			descriptionFriend.Add("Friend.IsFriend", tooltip);

			tooltip = new ToolTipDescriptions("Friend.ChangeList(string)", new string[] { "string ListName" }, "void", "Change friend list, List must be exist in friend list GUI configuration");
			descriptionFriend.Add("Friend.ChangeList", tooltip);

			#endregion

			#region Description BandageHeal

			Dictionary<string, ToolTipDescriptions> descriptionBandageHeal = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("BandageHeal.Status()", new string[] { "none" }, "bool", "Get status of bandage heal engine\n\tTrue: is running, False: is not running");
			descriptionBandageHeal.Add("BandageHeal.Status", tooltip);

			tooltip = new ToolTipDescriptions("BandageHeal.Start()", new string[] { "none" }, "void", "Start bandage heal engine");
			descriptionBandageHeal.Add("BandageHeal.Start", tooltip);

			tooltip = new ToolTipDescriptions("BandageHeal.Stop()", new string[] { "none" }, "void", "Stop bandage heal engine");
			descriptionBandageHeal.Add("BandageHeal.Stop", tooltip);

			#endregion

			#region Description Statics

			Dictionary<string, ToolTipDescriptions> descriptionStatics = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("Statics.GetLandID(int, int, int)", new string[] { "int X", "int Y", "int MapValue" }, "int", "Get ID of tile in X, Y coordinates");
			descriptionStatics.Add("Statics.GetLandID", tooltip);

			tooltip = new ToolTipDescriptions("Statics.GetLandZ(int, int, int)", new string[] { "int X", "int Y", "int MapValue" }, "int", "Get Z level of tile in X, Y coordinates");
			descriptionStatics.Add("Statics.GetLandZ", tooltip);

			tooltip = new ToolTipDescriptions("Statics.GetStaticsTileInfo(int, int, int)", new string[] { "int X", "int Y", "int MapValue" }, "List<TileInfo>", "Get tiles info in a certain map at X, Y coordinates");
			descriptionStatics.Add("Statics.GetStaticsTileInfo", tooltip);

			#endregion

			#region Description Generics

			Dictionary<string, ToolTipDescriptions> descriptionGenerics = new Dictionary<string, ToolTipDescriptions>();

			tooltip = new ToolTipDescriptions("GetItemOnLayer(string)", new string[] { "string LayerName" }, "Item", "Retrieves a item value of item equipped on specific layer\n\tCheck the wiki for the possible strings\n\tWorks only on Mobile Instances");
			descriptionGenerics.Add("GetItemOnLayer", tooltip);

			tooltip = new ToolTipDescriptions("GetAssistantLayer(string)", new string[] { "string LayerName" }, "Layer", "Retrives HexID from the Layer's name\n\tWorks only on Mobile Instances");
			descriptionGenerics.Add("GetAssistantLayer", tooltip);

			tooltip = new ToolTipDescriptions("DistanceTo(Mobile)", new string[] { "Mobile MobileInstance" }, "int", "Return a value about distance from the mobile\n\tWorks only on Item Instances");
			descriptionGenerics.Add("DistanceTo", tooltip);

			#endregion

			Dictionary<string, ToolTipDescriptions> descriptionMethods =
				descriptionPlayer
				.Union(descriptionSpells)
				.Union(descriptionMobiles)
				.Union(descriptionItems)
				.Union(descriptionMisc)
				.Union(descriptionTarget)
				.Union(descriptionGumps)
				.Union(descriptionJournal)
				.Union(descriptionAutoLoot)
				.Union(descriptionScavenger)
				.Union(descriptionOrganizer)
				.Union(descriptionRestock)
				.Union(descriptionSellAgent)
				.Union(descriptionBuyAgent)
				.Union(descriptionDress)
				.Union(descriptionFriend)
				.Union(descriptionBandageHeal)
				.Union(descriptionStatics)
				.ToDictionary(x => x.Key, x => x.Value);

			#endregion

			List<AutocompleteItem> items = new List<AutocompleteItem>();

			//Permette la creazione del menu con la singola keyword
			Array.Sort(keywords);
			foreach (var item in keywords)
				items.Add(new AutocompleteItem(item) { ImageIndex = 0 });
			//Permette la creazione del menu con la singola classe
			Array.Sort(classes);
			foreach (var item in classes)
				items.Add(new AutocompleteItem(item) { ImageIndex = 1 });

			//Permette di creare il menu solo per i metodi della classe digitata
			Array.Sort(methods);
			foreach (var item in methods)
			{
				ToolTipDescriptions element;
				descriptionMethods.TryGetValue(item, out element);

				if (element != null)
				{
					items.Add(new MethodAutocompleteItemAdvance(item)
					{
						ImageIndex = 2,
						ToolTipTitle = element.Title,
						ToolTipText = element.ToolTipDescription()
					});
				}
				else
				{
					items.Add(new MethodAutocompleteItemAdvance(item)
					{
						ImageIndex = 2
					});
				}
			}

			//Metodi generici per instanze di tipo Item o Mobile
			Array.Sort(methodsGeneric);
			foreach (var item in methodsGeneric)
			{
				ToolTipDescriptions element;
				descriptionGenerics.TryGetValue(item, out element);

				if (element != null)
				{
					items.Add(new MethodAutocompleteItem(item)
					{
						ImageIndex = 3,
						ToolTipTitle = element.Title,
						ToolTipText = element.ToolTipDescription()
					});
				}
				else
				{
					items.Add(new MethodAutocompleteItem(item)
					{
						ImageIndex = 3
					});
				}
			}

			//Permette di creare il menu per le props solo sulla classe Player
			Array.Sort(propsWithCheck);
			foreach (var item in propsWithCheck)
				items.Add(new SubPropertiesAutocompleteItem(item) { ImageIndex = 4 });

			//Props generiche divise tra quelle Mobiles e Items, che possono
			//Appartenere a variabili istanziate di una certa classe
			//Qui sta alla cura dell'utente capire se una props va bene o no
			//Per quella istanza
			Array.Sort(props);
			foreach (var item in props)
				items.Add(new MethodAutocompleteItem(item) { ImageIndex = 5 });

			m_popupMenu.Items.SetAutocompleteItems(items);

			//Aumenta la larghezza per i singoli item, in modo che l'intero nome sia visibile
			m_popupMenu.Items.MaximumSize = new Size(m_popupMenu.Items.Width + 20, m_popupMenu.Items.Height);
			m_popupMenu.Items.Width = m_popupMenu.Items.Width + 20;

			this.Text = m_Title;
			this.m_Engine = engine;
			this.m_Engine.SetTrace(null);

			if (filename != null)
			{
				m_Filepath = filename;
				m_Filename = Path.GetFileNameWithoutExtension(filename);
				this.Text = m_Title + " - " + m_Filename + ".cs";
				fastColoredTextBoxEditor.Text = File.ReadAllText(filename);
			}
		}

		private TracebackDelegate OnTraceback(TraceBackFrame frame, string result, object payload)
		{
			if (m_Breaktrace)
			{
				m_WaitDebug.WaitOne();
				CheckCurrentCommand();

				if (m_CurrentCommand != Command.None)
				{
					UpdateCurrentState(frame, result, payload);
					int line = (int)m_CurrentFrame.f_lineno;

					switch (m_CurrentCommand)
					{
						case Command.Breakpoint:

							if (m_Breakpoints.Contains(line))
								TracebackBreakpoint();
							else
								EnqueueCommand(Command.Breakpoint);
							break;

						case Command.Call:

							if (result == "call")
								TracebackCall();
							else
								EnqueueCommand(Command.Call);
							break;

						case Command.Line:

							if (result == "line")
								TracebackLine();
							else
								EnqueueCommand(Command.Line);
							break;

						case Command.Return:

							if (result == "return")
								TracebackReturn();
							else
								EnqueueCommand(Command.Return);
							break;
					}
				}

				return OnTraceback;
			}
			else
				return null;
		}

		private void TracebackCall()
		{
			SetStatusLabel("DEBUGGER ACTIVE - " + string.Format("Call {0}", m_CurrentCode.co_name), Color.YellowGreen);
			SetHighlightLine((int)m_CurrentFrame.f_lineno - 1, Color.LightGreen);
			string locals = GetLocalsText(m_CurrentFrame);
			SetTraceback(locals);
		}

		private void TracebackReturn()
		{
			SetStatusLabel("DEBUGGER ACTIVE - " + string.Format("Return {0}", m_CurrentCode.co_name), Color.YellowGreen);
			SetHighlightLine((int)m_CurrentFrame.f_lineno - 1, Color.LightBlue);
			string locals = GetLocalsText(m_CurrentFrame);
			SetTraceback(locals);
		}

		private void TracebackLine()
		{
			SetStatusLabel("DEBUGGER ACTIVE - " + string.Format("Line {0}", (int)m_CurrentFrame.f_lineno), Color.YellowGreen);
			SetHighlightLine((int)m_CurrentFrame.f_lineno - 1, Color.Yellow);
			string locals = GetLocalsText(m_CurrentFrame);
			SetTraceback(locals);
		}

		private void TracebackBreakpoint()
		{
			SetStatusLabel("DEBUGGER ACTIVE - " + string.Format("Breakpoint at line {0}", (int)m_CurrentFrame.f_lineno), Color.YellowGreen);
			string locals = GetLocalsText(m_CurrentFrame);
			SetTraceback(locals);
		}

		private void EnqueueCommand(Command command)
		{
			m_Queue.Enqueue(command);
			m_WaitDebug.Set();
		}

		private bool CheckCurrentCommand()
		{
			m_CurrentCommand = Command.None;
			bool result = m_Queue.TryDequeue(out m_CurrentCommand);
			return result;
		}

		private void UpdateCurrentState(TraceBackFrame frame, string result, object payload)
		{
			m_CurrentFrame = frame;
			m_CurrentCode = frame.f_code;
			m_CurrentResult = result;
			m_CurrentPayload = payload;
		}

		private void Start(bool debug)
		{
			if (Scripts.ScriptEditorThread == null ||
					(Scripts.ScriptEditorThread != null && Scripts.ScriptEditorThread.ThreadState != ThreadState.Running &&
					Scripts.ScriptEditorThread.ThreadState != ThreadState.Unstarted &&
					Scripts.ScriptEditorThread.ThreadState != ThreadState.WaitSleepJoin)
				)
			{
				Scripts.ScriptEditorThread = new Thread(() => AsyncStart(debug));
                Scripts.ScriptEditorThread.Start();
			}
			else
				SetErrorBox("Starting ERROR: Can't start script if another editor is running.");
		}

		private void AsyncStart(bool debug)
		{
			if (ScriptRecorder.OnRecord)
			{
				SetErrorBox("Starting ERROR: Can't start script if record mode is ON.");
				return;
			}

			if (debug)
			{
				SetErrorBox("Starting Script in debug mode: " + m_Filename);
				SetStatusLabel("DEBUGGER ACTIVE", Color.YellowGreen);
			}
			else
			{
				SetErrorBox("Starting Script: " + m_Filename);
				SetStatusLabel("SCRIPT RUNNING", Color.Green);
			}

			try
			{
				if (debug)
				{
					m_Breaktrace = true;
				}
				else
				{
					m_Breaktrace = false;
				}

				m_Queue = new ConcurrentQueue<Command>();

				string text = GetFastTextBoxText();
				m_Source = m_Engine.CreateScriptSourceFromString(text);
				m_Scope = RazorEnhanced.Scripts.GetRazorScope(m_Engine);
				m_Engine.SetTrace(m_EnhancedScriptEditor.OnTraceback);
				m_Source.Execute(m_Scope);
				SetErrorBox("Script " + m_Filename + " run completed!");
				SetStatusLabel("IDLE", Color.DarkTurquoise);
			}
			catch (Exception ex)
			{
				if (ex is SyntaxErrorException)
				{
					SyntaxErrorException se = ex as SyntaxErrorException;
					SetErrorBox("Syntax Error:");
					SetErrorBox("--> LINE: " + se.Line);
					SetErrorBox("--> COLUMN: " + se.Column);
					SetErrorBox("--> SEVERITY: " + se.Severity);
					SetErrorBox("--> MESSAGE: " + se.Message);
				}
				else
				{
					SetErrorBox("Generic Error:");
					SetErrorBox("--> MESSAGE: " + ex.Message);
				}
				SetStatusLabel("IDLE", Color.DarkTurquoise);
			}

			if (Scripts.ScriptEditorThread != null)
				Scripts.ScriptEditorThread.Abort();
		}

		private void Stop()
		{
			if (ScriptRecorder.OnRecord)
				return;

			m_Breaktrace = false;
			m_Queue = new ConcurrentQueue<Command>();
			m_Breakpoints.Clear();

			for (int iline = 0; iline < fastColoredTextBoxEditor.LinesCount; iline++)
			{
				fastColoredTextBoxEditor[iline].BackgroundBrush = new SolidBrush(Color.White);
			}
			fastColoredTextBoxEditor.Invalidate();

			SetStatusLabel("IDLE", Color.DarkTurquoise);
			SetTraceback("");

			if (Scripts.ScriptEditorThread != null && Scripts.ScriptEditorThread.ThreadState != ThreadState.Stopped)
			{
				Scripts.ScriptEditorThread.Abort();
				SetErrorBox("Script stopped: " + m_Filename);
				Scripts.ScriptEditorThread = null;
            }
		}

		private void SetHighlightLine(int iline, Color background)
		{
			if (this.m_onclosing)
				return;

			if (this.fastColoredTextBoxEditor.InvokeRequired)
			{
				SetHighlightLineDelegate d = new SetHighlightLineDelegate(SetHighlightLine);
				this.Invoke(d, new object[] { iline, background });
			}
			else
			{
				for (int i = 0; i < fastColoredTextBoxEditor.LinesCount; i++)
				{
					if (m_Breakpoints.Contains(i))
						fastColoredTextBoxEditor[i].BackgroundBrush = new SolidBrush(Color.Red);
					else
						fastColoredTextBoxEditor[i].BackgroundBrush = new SolidBrush(Color.White);
				}

				this.fastColoredTextBoxEditor[iline].BackgroundBrush = new SolidBrush(background);
				this.fastColoredTextBoxEditor.Invalidate();
			}
		}

		private void SetStatusLabel(string text, Color color)
		{
			if (this.m_onclosing)
				return;

			if (this.InvokeRequired)
			{
				SetStatusLabelDelegate d = new SetStatusLabelDelegate(SetStatusLabel);
				this.Invoke(d, new object[] { text, color });
			}
			else
			{
				this.toolStripStatusLabelScript.Text = "--> " + text;
				this.statusStrip1.BackColor = color;

			}
		}

		private string GetFastTextBoxText()
		{
			if (this.fastColoredTextBoxEditor.InvokeRequired)
			{
				GetFastTextBoxTextDelegate d = new GetFastTextBoxTextDelegate(GetFastTextBoxText);
				return (string)this.Invoke(d, null);
			}
			else
			{
				return fastColoredTextBoxEditor.Text;
			}
		}

		private string GetLocalsText(TraceBackFrame frame)
		{
			string result = "";

			PythonDictionary locals = frame.f_locals as PythonDictionary;
			if (locals != null)
			{
				foreach (KeyValuePair<object, object> pair in locals)
				{
					if (!(pair.Key.ToString().StartsWith("__") && pair.Key.ToString().EndsWith("__")))
					{
						string line = pair.Key.ToString() + ": " + (pair.Value != null ? pair.Value.ToString() : "") + "\r\n";
						result += line;
					}
				}
			}

			return result;
		}

		private void SetTraceback(string text)
		{
			if (this.m_onclosing)
				return;

			if (this.textBoxDebug.InvokeRequired)
			{
				SetTracebackDelegate d = new SetTracebackDelegate(SetTraceback);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				this.textBoxDebug.Text = text;
			}
		}

		private void SetErrorBox(string text)
		{
			if (this.m_onclosing)
				return;

			try
			{
				if (this.listBox1.InvokeRequired)
				{
					SetTracebackDelegate d = new SetTracebackDelegate(SetErrorBox);
					this.Invoke(d, new object[] { text });
				}
				else
				{
					this.listBox1.Items.Add("[" + DateTime.Now.ToString("HH:mm:ss") + "] - " + text);
					this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
				}
			}
			catch
			{ }
		}

		private void EnhancedScriptEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_EnhancedScriptEditor.m_onclosing = true;
			Stop();
			End();
			m_EnhancedScriptEditor.m_onclosing = false;
		}

		private void toolStripButtonPlay_Click(object sender, EventArgs e)
		{
			Start(false);
		}

		private void toolStripButtonDebug_Click(object sender, EventArgs e)
		{
			Start(true);
		}

		private void toolStripNextCall_Click(object sender, EventArgs e)
		{
			EnqueueCommand(Command.Call);
		}

		private void toolStripButtonNextLine_Click(object sender, EventArgs e)
		{
			EnqueueCommand(Command.Line);
		}

		private void toolStripButtonNextReturn_Click(object sender, EventArgs e)
		{
			EnqueueCommand(Command.Return);
		}

		private void toolStripButtonNextBreakpoint_Click(object sender, EventArgs e)
		{
			EnqueueCommand(Command.Breakpoint);
		}

		private void toolStripButtonStop_Click(object sender, EventArgs e)
		{
			Stop();
		}

		private void toolStripButtonAddBreakpoint_Click(object sender, EventArgs e)
		{
			AddBreakpoint();
		}

		private void toolStripButtonRemoveBreakpoints_Click(object sender, EventArgs e)
		{
			RemoveBreakpoint();
		}

		private void toolStripButtonOpen_Click(object sender, EventArgs e)
		{
			Open();
		}

		private void toolStripButtonSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void toolStripButtonSaveAs_Click(object sender, EventArgs e)
		{
			SaveAs();
		}

		private void toolStripButtonClose_Click(object sender, EventArgs e)
		{
			CloseAndSave();
		}

		private void toolStripButtonInspect_Click(object sender, EventArgs e)
		{
			InspectEntities();
		}

		private void toolStripInspectGump_Click(object sender, EventArgs e)
		{
			InspectGumps();
		}

		private void InspectItemTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item assistantItem = Assistant.World.FindItem(serial);
			if (assistantItem != null && assistantItem.Serial.IsItem)
			{
				this.BeginInvoke((MethodInvoker)delegate
				{
					EnhancedItemInspector inspector = new EnhancedItemInspector(assistantItem);
					inspector.TopMost = true;
					inspector.Show();
				});
			}
			else
			{
				Assistant.Mobile assistantMobile = Assistant.World.FindMobile(serial);
				if (assistantMobile != null && assistantMobile.Serial.IsMobile)
				{
					this.BeginInvoke((MethodInvoker)delegate
					{
						EnhancedMobileInspector inspector = new EnhancedMobileInspector(assistantMobile);
						inspector.TopMost = true;
						inspector.Show();
					});
				}
			}
		}

		private void toolStripRecord_Click(object sender, EventArgs e)
		{
			ScriptRecord();
		}

		private void gumpinspector_close(object sender, EventArgs e)
		{
			Assistant.Engine.MainWindow.GumpInspectorEnable = false;
		}

		private void Open()
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "Script Files|*.py";
			open.RestoreDirectory = true;
			if (open.ShowDialog() == DialogResult.OK)
			{
				m_Filename = Path.GetFileNameWithoutExtension(open.FileName);
				m_Filepath = open.FileName;
				this.Text = m_Title + " - " + m_Filename + ".py";
				fastColoredTextBoxEditor.Text = File.ReadAllText(open.FileName);
			}
		}

		private void Save()
		{
			if (m_Filename != "")
			{
				this.Text = m_Title + " - " + m_Filename + ".py";
				File.WriteAllText(m_Filepath, fastColoredTextBoxEditor.Text);
				Scripts.EnhancedScript script = Scripts.Search(m_Filename + ".py");
				if (script != null)
				{
					string fullpath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Scripts", m_Filename + ".py");

					if (File.Exists(fullpath) && Scripts.EnhancedScripts.ContainsKey(m_Filename + ".py"))
					{
						string text = File.ReadAllText(fullpath);
						bool loop = script.Loop;
						bool wait = script.Wait;
						bool run = script.Run;
						bool autostart = script.AutoStart;
						bool isRunning = script.IsRunning;

						if (isRunning)
							script.Stop();

						Scripts.EnhancedScript reloaded = new Scripts.EnhancedScript(m_Filename + ".py", text, wait, loop, run, autostart);
						reloaded.Create(null);
						Scripts.EnhancedScripts[m_Filename + ".py"] = reloaded;

						if (isRunning)
							reloaded.Start();
					}
				}
			}
			else
			{
				SaveAs();
			}
		}

		private void SaveAs()
		{
			SaveFileDialog save = new SaveFileDialog();
			save.Filter = "Script Files|*.py";
			save.RestoreDirectory = true;

			if (save.ShowDialog() == DialogResult.OK)
			{
				m_Filename = Path.GetFileNameWithoutExtension(save.FileName);
				this.Text = m_Title + " - " + m_Filename + ".py";
				m_Filepath = save.FileName;
				File.WriteAllText(save.FileName, fastColoredTextBoxEditor.Text);

				string filename = Path.GetFileName(save.FileName);
				Scripts.EnhancedScript script = Scripts.Search(filename);
				if (script != null)
				{
					string fullpath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Scripts", filename);

					if (File.Exists(fullpath) && Scripts.EnhancedScripts.ContainsKey(filename))
					{
						string text = File.ReadAllText(fullpath);
						bool loop = script.Loop;
						bool wait = script.Wait;
						bool run = script.Run;
						bool isRunning = script.IsRunning;
						bool autostart = script.AutoStart;

						if (isRunning)
							script.Stop();

						Scripts.EnhancedScript reloaded = new Scripts.EnhancedScript(filename, text, wait, loop, run, autostart);
						reloaded.Create(null);
						Scripts.EnhancedScripts[filename] = reloaded;

						if (isRunning)
							reloaded.Start();
					}
				}
			}
		}

		private void CloseAndSave()
		{
			DialogResult res = MessageBox.Show("Save current file?", "WARNING", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
			if (res == System.Windows.Forms.DialogResult.Yes)
			{
				SaveFileDialog save = new SaveFileDialog();
				save.Filter = "Script Files|*.py";
				save.FileName = m_Filename;

				if (save.ShowDialog() == DialogResult.OK)
				{
					File.WriteAllText(save.FileName, fastColoredTextBoxEditor.Text);
				}
				fastColoredTextBoxEditor.Text = "";
				m_Filename = "";
				m_Filepath = "";
				this.Text = m_Title;
			}
			else if (res == System.Windows.Forms.DialogResult.No)
			{
				fastColoredTextBoxEditor.Text = "";
				m_Filename = "";
				m_Filepath = "";
				this.Text = m_Title;
			}
		}

		private void AddBreakpoint()
		{
			int iline = fastColoredTextBoxEditor.Selection.Start.iLine;

			if (!m_Breakpoints.Contains(iline))
			{
				m_Breakpoints.Add(iline + 1);
				FastColoredTextBoxNS.Line line = fastColoredTextBoxEditor[iline];
				line.BackgroundBrush = new SolidBrush(Color.Red);
				fastColoredTextBoxEditor.Invalidate();
			}
		}

		private void RemoveBreakpoint()
		{
			int iline = fastColoredTextBoxEditor.Selection.Start.iLine;

			if (m_Breakpoints.Contains(iline + 1))
			{
				m_Breakpoints.Remove(iline + 1);
				FastColoredTextBoxNS.Line line = fastColoredTextBoxEditor[iline];
				line.BackgroundBrush = new SolidBrush(Color.White);
				fastColoredTextBoxEditor.Invalidate();
			}
		}

		private void InspectEntities()
		{
			Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(InspectItemTarget_Callback));
		}

		private void InspectGumps()
		{
			EnhancedGumpInspector ginspector = new EnhancedGumpInspector();
			ginspector.FormClosed += new FormClosedEventHandler(gumpinspector_close);
			ginspector.TopMost = true;
			ginspector.Show();
		}

		private void ScriptRecord()
		{
			if (Scripts.ScriptEditorThread == null ||
					(Scripts.ScriptEditorThread != null && Scripts.ScriptEditorThread.ThreadState != ThreadState.Running &&
					Scripts.ScriptEditorThread.ThreadState != ThreadState.Unstarted &&
					Scripts.ScriptEditorThread.ThreadState != ThreadState.WaitSleepJoin)
				)
			{
				if (ScriptRecorder.OnRecord)
				{
					SetErrorBox("RECORDER: Stop Record");
					ScriptRecorder.OnRecord = false;
					SetStatusLabel("IDLE", Color.DarkTurquoise);
					return;
				}
				else
				{
					SetErrorBox("RECORDER: Start Record");
					ScriptRecorder.OnRecord = true;
					SetStatusLabel("ON RECORD", Color.Red);
					return;
				}
			}
			else
			{
				SetErrorBox("RECORDER ERROR: Can't Record if script is running");
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				//Open File
				case (Keys.Control | Keys.O):
					Open();
					return true;

				//Save File
				case (Keys.Control | Keys.S):
					Save();
					return true;

				//Save As File
				case (Keys.Control | Keys.Shift | Keys.S):
					SaveAs();
					return true;

				//Close File
				case (Keys.Control | Keys.E):
					CloseAndSave();
					return true;

				//Inspect Entities
				case (Keys.Control | Keys.I):
					InspectEntities();
					return true;

				//Inspect Gumps
				case (Keys.Control | Keys.G):
					InspectGumps();
					return true;

				case (Keys.Control | Keys.R):
					ScriptRecord();
					return true;

				//Start with Debug
				case (Keys.F5):
					Start(true);
					return true;

				//Start without Debug
				case (Keys.F6):
					Start(false);
					return true;

				//Stop
				case (Keys.F4):
					Stop();
					return true;

				//Add Breakpoint
				case (Keys.F7):
					AddBreakpoint();
					return true;

				//Remove Breakpoint
				case (Keys.F8):
					RemoveBreakpoint();
					return true;

                //Next Breakpoint
                case (Keys.F9):
                    EnqueueCommand(Command.Breakpoint);
                    return true;

                //Debug - Next Line
                case (Keys.F10):
					EnqueueCommand(Command.Line);
					return true;

                //Debug - Next Call
                case (Keys.F11):
                    EnqueueCommand(Command.Call);
                    return true;

                //Debug - Next Return
                case (Keys.F12):
					EnqueueCommand(Command.Return);
					return true;

				default:
					return base.ProcessCmdKey(ref msg, keyData);
			}
		}

		private void EnhancedScriptEditor_Load(object sender, EventArgs e)
		{
			toolStripStatusLabelScript.Width = this.Width - 20;
			SetStatusLabel("IDLE", Color.DarkTurquoise);
        }
	}

	public class ToolTipDescriptions
	{
		public string Title;
		public string[] Parameters;
		public string Returns;
		public string Description;

		public ToolTipDescriptions(string title, string[] parameter, string returns, string description)
		{
			Title = title;
			Parameters = parameter;
			Returns = returns;
			Description = description;
		}

		public string ToolTipDescription()
		{
			string complete_description = "";

			complete_description += "Parameters: ";

			foreach (string parameter in Parameters)
				complete_description += "\n\t" + parameter;

			complete_description += "\nReturns: " + Returns;

			complete_description += "\nDescription:";

			complete_description += "\n\t" + Description;

			return complete_description;
		}
	}

	#region Custom Items per Autocomplete

	/// <summary>
	/// This autocomplete item appears after dot
	/// </summary>
	public class MethodAutocompleteItemAdvance : MethodAutocompleteItem
	{
		string firstPart;
		string lastPart;

		public MethodAutocompleteItemAdvance(string text)
			: base(text)
		{
			var i = text.LastIndexOf('.');
			if (i < 0)
				firstPart = text;
			else
			{
				firstPart = text.Substring(0, i);
				lastPart = text.Substring(i + 1);
			}
		}

		public override CompareResult Compare(string fragmentText)
		{
			int i = fragmentText.LastIndexOf('.');

			if (i < 0)
			{
				if (firstPart.StartsWith(fragmentText) && string.IsNullOrEmpty(lastPart))
					return CompareResult.VisibleAndSelected;
				//if (firstPart.ToLower().Contains(fragmentText.ToLower()))
				//  return CompareResult.Visible;
			}
			else
			{
				var fragmentFirstPart = fragmentText.Substring(0, i);
				var fragmentLastPart = fragmentText.Substring(i + 1);


				if (firstPart != fragmentFirstPart)
					return CompareResult.Hidden;

				if (lastPart != null && lastPart.StartsWith(fragmentLastPart))
					return CompareResult.VisibleAndSelected;

				if (lastPart != null && lastPart.ToLower().Contains(fragmentLastPart.ToLower()))
					return CompareResult.Visible;

			}

			return CompareResult.Hidden;
		}

		public override string GetTextForReplace()
		{
			if (lastPart == null)
				return firstPart;

			return firstPart + "." + lastPart;
		}

		public override string ToString()
		{
			if (lastPart == null)
				return firstPart;

			return lastPart;
		}
	}

	/// <summary>
	/// This autocomplete item appears after dot
	/// </summary>
	public class SubPropertiesAutocompleteItem : MethodAutocompleteItem
	{
		string firstPart;
		string lastPart;

		public SubPropertiesAutocompleteItem(string text)
			: base(text)
		{
			var i = text.LastIndexOf('.');
			if (i < 0)
				firstPart = text;
			else
			{
				var keywords = text.Split('.');
				if (keywords.Length >= 2)
				{
					firstPart = keywords[keywords.Length - 2];
					lastPart = keywords[keywords.Length - 1];
				}
				else
				{
					firstPart = text.Substring(0, i);
					lastPart = text.Substring(i + 1, text.Length);
				}
			}
		}

		public override CompareResult Compare(string fragmentText)
		{
			int i = fragmentText.LastIndexOf('.');

			if (i < 0)
			{
				if (firstPart.StartsWith(fragmentText) && string.IsNullOrEmpty(lastPart))
					return CompareResult.VisibleAndSelected;
				//if (firstPart.ToLower().Contains(fragmentText.ToLower()))
				//  return CompareResult.Visible;
			}
			else
			{
				var keywords = fragmentText.Split('.');
				if (keywords.Length >= 2)
				{
					var fragmentFirstPart = keywords[keywords.Length - 2];
					var fragmentLastPart = keywords[keywords.Length - 1];


					if (firstPart != fragmentFirstPart)
						return CompareResult.Hidden;

					if (lastPart != null && lastPart.StartsWith(fragmentLastPart))
						return CompareResult.VisibleAndSelected;

					if (lastPart != null && lastPart.ToLower().Contains(fragmentLastPart.ToLower()))
						return CompareResult.Visible;
				}
				else
				{
					var fragmentFirstPart = fragmentText.Substring(0, i);
					var fragmentLastPart = fragmentText.Substring(i + 1);


					if (firstPart != fragmentFirstPart)
						return CompareResult.Hidden;

					if (lastPart != null && lastPart.StartsWith(fragmentLastPart))
						return CompareResult.VisibleAndSelected;

					if (lastPart != null && lastPart.ToLower().Contains(fragmentLastPart.ToLower()))
						return CompareResult.Visible;
				}

			}

			return CompareResult.Hidden;
		}

		public override string GetTextForReplace()
		{
			if (lastPart == null)
				return firstPart;

			return firstPart + "." + lastPart;
		}

		public override string ToString()
		{
			if (lastPart == null)
				return firstPart;

			return lastPart;
		}
	}

	#endregion
}