using Assistant.Filters;
using RazorEnhanced;
using RazorEnhanced.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Management;
using Accord.Video;
using Accord.Video.DirectShow;


namespace Assistant
{
	internal class MainForm : System.Windows.Forms.Form
	{
		#region Class Variables

		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckedListBox filters;
		private System.Windows.Forms.ColumnHeader skillHDRName;
		private System.Windows.Forms.ColumnHeader skillHDRvalue;
		private System.Windows.Forms.ColumnHeader skillHDRbase;
		private System.Windows.Forms.ColumnHeader skillHDRdelta;
		private RazorButton resetDelta;
		private RazorButton setlocks;
		private RazorComboBox locks;
		private System.Windows.Forms.ListView skillList;
		private System.Windows.Forms.ColumnHeader skillHDRcap;
		private RazorCheckBox alwaysTop;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox baseTotal;
		private System.Windows.Forms.TabPage emptyTab;
		private RazorButton skillCopySel;
		private RazorButton skillCopyAll;
		private System.Windows.Forms.TabPage generalTab;
		private System.Windows.Forms.TabPage toolbarTab;
		private System.Windows.Forms.TabPage skillsTab;
		private System.Windows.Forms.TabPage moreOptTab;
		private RazorCheckBox chkForceSpeechHue;
		private System.Windows.Forms.Label label3;
		private RazorTextBox txtSpellFormat;
		private RazorCheckBox chkForceSpellHue;
		private System.Windows.Forms.Label opacityLabel;
		private System.Windows.Forms.TrackBar opacity;
		private RazorCheckBox dispDelta;
		private RazorCheckBox openCorpses;
		private RazorTextBox corpseRange;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage screenshotTab;
		private System.Windows.Forms.TabPage statusTab;
		private RazorCheckBox spamFilter;
		private System.Windows.Forms.PictureBox screenPrev;
		private System.Windows.Forms.ListBox screensList;
		private RazorButton setScnPath;
		private RazorRadioButton radioFull;
		private RazorRadioButton radioUO;
		private RazorCheckBox screenAutoCap;
		private RazorTextBox screenPath;
		private RazorButton capNow;
		private RazorCheckBox dispTime;
		private System.Windows.Forms.ColumnHeader skillHDRlock;
		private System.ComponentModel.IContainer components;
		private RazorCheckBox queueTargets;
		private RazorRadioButton systray;
		private RazorRadioButton taskbar;
		private System.Windows.Forms.Label label11;
		private RazorCheckBox autoStackRes;
		private RazorButton setExHue;
		private RazorButton setMsgHue;
		private RazorButton setWarnHue;
		private RazorButton setSpeechHue;
		private RazorButton setBeneHue;
		private RazorButton setHarmHue;
		private RazorButton setNeuHue;
		private System.Windows.Forms.Label lblWarnHue;
		private System.Windows.Forms.Label lblMsgHue;
		private System.Windows.Forms.Label lblExHue;
		private System.Windows.Forms.Label lblBeneHue;
		private System.Windows.Forms.Label lblHarmHue;
		private System.Windows.Forms.Label lblNeuHue;
		private RazorCheckBox incomingCorpse;
		private RazorCheckBox incomingMob;
		private System.Windows.Forms.TabPage enhancedFilterTab;
		private RazorCheckBox filterSnoop;
		private RazorCheckBox smartCPU;
		private RazorButton setLTHilight;
		private RazorCheckBox lthilight;
		private RazorCheckBox blockDis;
		private System.Windows.Forms.Label label12;
		private RazorComboBox imgFmt;
		private ToolTip m_Tip;

		#endregion Class Variables

		private RazorCheckBox negotiate;
		private RazorCheckBox preAOSstatbar;
		private RazorComboBox clientPrio;
		private System.Windows.Forms.Label label9;
		private TabPage scriptingTab;
		private RazorButton buttonAddScript;
		private RazorButton buttonRemoveScript;
		private RazorButton buttonScriptUp;
		private RazorButton buttonScriptDown;
		private RazorButton buttonScriptEditor;
		private Label labelStatus;
		private Panel panelUODlogo;
		private RazorButton razorButtonVisitUOD;
		private Label labelUOD;
		private RazorButton razorButtonCreateUODAccount;
		private RazorButton razorButtonWiki;
		private Panel panelLogo;
		private List<RazorEnhanced.Organizer.OrganizerItem> organizerItemList = new List<RazorEnhanced.Organizer.OrganizerItem>();
		private List<RazorEnhanced.SellAgent.SellAgentItem> sellItemList = new List<RazorEnhanced.SellAgent.SellAgentItem>();
		private List<RazorEnhanced.BuyAgent.BuyAgentItem> buyItemList = new List<RazorEnhanced.BuyAgent.BuyAgentItem>();
		private List<RazorEnhanced.Dress.DressItem> dressItemList = new List<RazorEnhanced.Dress.DressItem>();
		private TabPage EnhancedAgent;
		private TabControl tabControl1;
		private TabPage eautoloot;
		private GroupBox groupBox13;
		private ListBox autolootLogBox;
		private Label autolootContainerLabel;
		private RazorButton autoLootButtonListImport;
		private RazorButton autoLootButtonListExport;
		private RazorButton autolootItemPropsB;
		private RazorButton autolootAddItemBTarget;
		private RazorButton autolootContainerButton;
		private RazorCheckBox autoLootCheckBox;
		private TabPage escavenger;
		private Label label21;
		private RazorTextBox autoLootTextBoxDelay;
		private RazorButton autoLootButtonRemoveList;
		private RazorButton autolootButtonAddList;
		private RazorComboBox autolootListSelect;
		private Label label20;
		private RazorButton scavengerButtonRemoveList;
		private RazorButton scavengerButtonAddList;
		private RazorButton scavengerButtonImport;
		private RazorButton scavengerButtonExport;
		private RazorComboBox scavengerListSelect;
		private Label label22;
		private GroupBox groupBox12;
		private ListBox scavengerLogBox;
		private Label label23;
		private RazorTextBox scavengerDragDelay;
		private Label scavengerContainerLabel;
		private RazorButton scavengerButtonSetContainer;
		private RazorCheckBox scavengerCheckBox;
		private RazorButton scavengerButtonEditProps;
		private RazorButton scavengerButtonAddTarget;
		private TabPage organizer;
		private GroupBox groupBox16;
		private ListBox organizerLogBox;
		private Label label27;
		private RazorTextBox organizerDragDelay;
		private Label organizerDestinationLabel;
		private RazorButton organizerSetDestinationB;
		private Label organizerSourceLabel;
		private RazorButton organizerAddTargetB;
		private RazorButton organizerSetSourceB;
		private RazorButton organizerRemoveListB;
		private RazorButton organizerAddListB;
		private RazorButton organizerImportListB;
		private RazorComboBox organizerListSelect;
		private RazorButton organizerExportListB;
		private Label label24;
		private TabPage VendorBuy;
		private TabPage VendorSell;
		private RazorButton buyAddTargetB;
		private GroupBox groupBox18;
		private ListBox buyLogBox;
		private RazorCheckBox buyEnableCheckBox;
		private RazorButton buyRemoveListButton;
		private RazorButton buyAddListButton;
		private RazorButton buyImportListButton;
		private RazorComboBox buyListSelect;
		private RazorButton buyExportListButton;
		private Label label25;
		private RazorButton sellAddTargerButton;
		private GroupBox groupBox20;
		private ListBox sellLogBox;
		private RazorCheckBox sellEnableCheckBox;
		private RazorButton sellRemoveListButton;
		private RazorButton sellAddListButton;
		private RazorButton sellImportListButton;
		private RazorComboBox sellListSelect;
		private RazorButton sellExportListButton;
		private Label label26;
		private Label sellBagLabel;
		private RazorButton sellSetBagButton;
		private TabPage Dress;
		private RazorCheckBox dressConflictCheckB;
		private Label dressBagLabel;
		private RazorButton dressSetBagB;
		private RazorButton undressExecuteButton;
		private RazorButton dressExecuteButton;
		private GroupBox groupBox22;
		private RazorButton dressAddTargetB;
		private RazorButton dressAddManualB;
		private RazorButton dressRemoveB;
		private RazorButton dressReadB;
		private Label label29;
		private RazorTextBox dressDragDelay;
		private GroupBox groupBox21;
		private ListBox dressLogBox;
		private ListView dressListView;
		private ColumnHeader columnHeader24;
		private ColumnHeader columnHeader25;
		private ColumnHeader columnHeader26;
		private ColumnHeader columnHeader27;
		private RazorButton dressRemoveListB;
		private RazorButton dressAddListB;
		private RazorButton dressImportListB;
		private RazorComboBox dressListSelect;
		private RazorButton dressExportListB;
		private Label label28;
		private NotifyIcon m_NotifyIcon;
		private OpenFileDialog openFileDialogscript;
		private System.Timers.Timer m_SystemTimer;
		private RazorButton dressStopButton;
		private System.Windows.Forms.Timer timerupdatestatus;
		private TabPage friends;
		private GroupBox friendloggroupBox;
		private ListBox friendLogBox;
		private RazorCheckBox friendIncludePartyCheckBox;
		private RazorCheckBox friendAttackCheckBox;
		private RazorCheckBox friendPartyCheckBox;
		private ListView friendlistView;
		private ColumnHeader columnHeader28;
		private ColumnHeader columnHeader29;
		private ColumnHeader columnHeader30;
		private RazorButton friendButtonRemoveList;
		private RazorButton friendButtonAddList;
		private RazorButton friendButtonImportList;
		private RazorComboBox friendListSelect;
		private RazorButton friendButtonExportList;
		private Label labelfriend;
		private GroupBox friendGroupBox;
		private RazorButton friendAddTargetButton;
		private RazorButton friendRemoveButton;
		private RazorButton friendAddButton;
		private TabPage restock;
		private GroupBox groupBox2;
		private ListBox restockLogBox;
		private Label label13;
		private RazorTextBox restockDragDelay;
		private Label restockDestinationLabel;
		private RazorButton restockSetDestinationButton;
		private Label restockSourceLabel;
		private RazorButton restockAddTargetButton;
		private RazorButton restockSetSourceButton;
		private RazorButton restockRemoveListB;
		private RazorButton restockAddListB;
		private RazorButton restockImportListB;
		private RazorComboBox restockListSelect;
		private RazorButton restockExportListB;
		private Label label7;
		private TabPage bandageheal;
		private GroupBox groupBox6;
		private RazorCheckBox bandagehealcountdownCheckBox;
		private RazorCheckBox bandagehealhiddedCheckBox;
		private RazorCheckBox bandagehealmortalCheckBox;
		private RazorCheckBox bandagehealpoisonCheckBox;
		private Label label33;
		private RazorTextBox bandagehealhpTextBox;
		private Label label32;
		private RazorCheckBox bandagehealdexformulaCheckBox;
		private RazorTextBox bandagehealcustomcolorTextBox;
		private Label label30;
		private RazorTextBox bandagehealcustomIDTextBox;
		private Label label19;
		private RazorCheckBox bandagehealcustomCheckBox;
		private Label bandagehealtargetLabel;
		private Label label15;
		private RazorButton bandagehealsettargetButton;
		private RazorComboBox bandagehealtargetComboBox;
		private Label label14;
		private RazorCheckBox bandagehealenableCheckBox;
		private GroupBox groupBox5;
		private ListBox bandagehealLogBox;
		private ListView targetlistView;
		private ColumnHeader columnHeader36;
		private ColumnHeader columnHeader37;
		private ColumnHeader columnHeader38;
		private ColumnHeader columnHeader39;
		private ColumnHeader columnHeader40;
		private ColumnHeader columnHeader41;
		private ColumnHeader columnHeader42;
		private ColumnHeader columnHeader43;
		private ColumnHeader columnHeader44;
		private ColumnHeader columnHeader45;
		private ColumnHeader columnHeader46;
		private ColumnHeader columnHeader47;
		private ColumnHeader columnHeader48;
		private ColumnHeader columnHeader49;
		private ColumnHeader columnHeader50;
		private GroupBox groupBox7;
		private RazorButton editTargetButton;
		private RazorButton removeTargetButton;
		private RazorButton addTargetButton;
		private RazorButton performTargetButton;
		private ColumnHeader columnHeader51;
		private RazorCheckBox rememberPwds;
		private RazorCheckBox gameSize;
		private RazorTextBox forceSizeX;
		private RazorTextBox forceSizeY;
		private RazorCheckBox chkStealth;
		private RazorCheckBox alwaysStealth;
		private RazorCheckBox autoOpenDoors;
		private RazorCheckBox spellUnequip;
		private RazorCheckBox potionEquip;
		private Label label17;
		private RazorComboBox msglvl;
		private RazorCheckBox actionStatusMsg;
		private RazorCheckBox QueueActions;
		private RazorTextBox txtObjDelay;
		private Label label5;
		private Label label6;
		private RazorCheckBox smartLT;
		private RazorCheckBox rangeCheckLT;
		private RazorTextBox ltRange;
		private Label label8;
		private RazorCheckBox showtargtext;
		private RazorCheckBox showHealthOH;
		private RazorTextBox healthFmt;
		private Label label10;
		private RazorCheckBox chkPartyOverhead;
		private GroupBox groupBox23;
		private RazorButton mobfilterRemoveButton;
		private RazorButton mobfilterAddButton;
		private ListView mobfilterlistView;
		private ColumnHeader columnHeader52;
		private ColumnHeader columnHeader53;
		private ColumnHeader columnHeader54;
		private RazorCheckBox mobfilterCheckBox;
		private GroupBox groupBox10;
		private Label autocarverbladeLabel;
		private Label label34;
		private RazorButton autocarverrazorButton;
		private RazorCheckBox autocarverCheckBox;
		private GroupBox groupBox9;
		private Label bonebladeLabel;
		private Label label16;
		private RazorButton boneCutterrazorButton;
		private RazorCheckBox bonecutterCheckBox;
		private RazorCheckBox showstaticfieldCheckBox;
		private RazorCheckBox flagsHighlightCheckBox;
		private RazorCheckBox highlighttargetCheckBox;
		private GroupBox groupBox24;
		private RazorCheckBox blockpartyinviteCheckBox;
		private RazorCheckBox blocktraderequestCheckBox;
		private RazorButton openToolBarButton;
		private GroupBox groupBox25;
		private RazorCheckBox lockToolBarCheckBox;
		private RazorCheckBox autoopenToolBarCheckBox;
		private Label locationToolBarLabel;
		private RazorButton closeToolBarButton;
		private GroupBox groupBox26;
		private Label label38;
		private RazorTextBox toolboxcountNameTextBox;
		private Label label37;
		private RazorButton toolboxcountClearButton;
		private RazorButton toolboxcountTargetButton;
		private RazorTextBox toolboxcountWarningTextBox;
		private Label label36;
		private RazorCheckBox toolboxcountHueWarningCheckBox;
		private RazorTextBox toolboxcountHueTextBox;
		private Label label35;
		private RazorTextBox toolboxcountGraphTextBox;
		private Label label18;
		private RazorComboBox toolboxcountComboBox;
		private TabPage enhancedHotKeytabPage;
		private TreeView hotkeytreeView;
		private RazorTextBox hotkeytextbox;
		private GroupBox groupBox27;
		private RazorButton hotkeyClearButton;
		private RazorButton hotkeySetButton;
		private Label label39;
		private GroupBox groupBox28;
		private RazorButton hotkeyMasterClearButton;
		private RazorButton hotkeyMasterSetButton;
		private Label label42;
		private Label hotkeyKeyMasterLabel;
		private RazorTextBox hotkeyKeyMasterTextBox;
		private Label hotkeyStatusLabel;
		private RazorCheckBox hotkeypassCheckBox;
		private GroupBox groupBox8;
		private RazorButton hotkeyMDisableButton;
		private RazorButton hotkeyMEnableButton;
		private GroupBox groupBox29;
		private RazorButton profilesDeleteButton;
		private RazorButton profilesAddButton;
		private RazorComboBox profilesComboBox;
		private RazorButton profilesExportButton;
		private RazorButton profilesCloneButton;
		private RazorButton profilesRenameButton;
		private RazorButton profilesImportButton;
		private RazorButton profilesUnlinkButton;
		private RazorButton profilesLinkButton;
		private Label profilelinklabel;
		private ColumnHeader columnHeader55;

		private bool m_CanClose = true;
		private GroupBox groupBox32;
		private RazorTextBox remountedelay;
		private RazorTextBox remountdelay;
		private Label label48;
		private Label label40;
		private Label remountseriallabel;
		private Label label47;
		private RazorButton remountsetbutton;
		private RazorCheckBox remountcheckbox;
		private Button buttonScriptPlay;
		private Button buttonScriptStop;
		private Label labelTimerDelay;
		private TextBox textBoxDelay;
		private RazorCheckBox showheadtargetCheckBox;
		private RazorCheckBox notshowlauncher;
		private RazorCheckBox blockhealpoisonCheckBox;
		private GroupBox groupBox4;
		private Label label43;
		private RazorComboBox toolboxsizeComboBox;
		private Label label41;
		private RazorCheckBox showfollowerToolBarCheckBox;
		private RazorCheckBox showweightToolBarCheckBox;
		private RazorCheckBox showmanaToolBarCheckBox;
		private RazorCheckBox showstaminaToolBarCheckBox;
		private RazorCheckBox showhitsToolBarCheckBox;
		private RazorComboBox toolboxstyleComboBox;
		private Label label2;
		private Label toolbarslot_label;
		private RazorCheckBox colorflagsHighlightCheckBox;
		private RazorCheckBox blockchivalryhealCheckBox;
		private RazorCheckBox blockbighealCheckBox;
		private RazorCheckBox blockminihealCheckBox;
		private ScriptListView scriptlistView;
		private ColumnHeader filename;
		private ColumnHeader status;
		private ColumnHeader loop;
		private ColumnHeader wait;
		private ColumnHeader hotkey;
		private ColumnHeader heypass;
		private ColumnHeader columnHeader62;
		private GroupBox groupBox30;
		private RazorCheckBox scriptwaitmodecheckbox;
		private RazorCheckBox scriptloopmodecheckbox;
		private Label scriptfilelabel;
		private GroupBox groupBox31;
		private RazorCheckBox showagentmessageCheckBox;
		private RazorCheckBox showmessagefieldCheckBox;
		private RazorCheckBox showscriptmessageCheckBox;
		private Button buttonScriptRefresh;
		private RazorButton FriendGuildRemoveButton;
		private RazorButton FriendGuildAddButton;
		private ListView friendguildListView;
		private ColumnHeader columnHeader63;
		private ColumnHeader columnHeader64;
		private RazorCheckBox MINfriendCheckBox;
		private RazorCheckBox COMfriendCheckBox;
		private RazorCheckBox TBfriendCheckBox;
		private RazorCheckBox SLfriendCheckBox;
		private GroupBox groupBox34;
		private GroupBox groupBox33;
		private RazorButton toolbarremoveslotButton;
		private RazorButton toolbaraddslotButton;
		private RazorCheckBox autoLootnoopenCheckBox;
		private TabPage tabPage2;
		private TabPage tabPage3;
		private GroupBox groupBox37;
		private RazorButton gridhslotremove_button;
		private RazorButton gridhslotadd_button;
		private Label gridhslot_textbox;
		private Label label53;
		private RazorButton gridvslotremove_button;
		private RazorButton gridvslotadd_button;
		private Label gridvslot_textbox;
		private Label label49;
		private GroupBox groupBox36;
		private RazorComboBox gridborder_ComboBox;
		private Label label44;
		private RazorComboBox gridspell_ComboBox;
		private Label label52;
		private RazorComboBox gridgroup_ComboBox;
		private Label label51;
		private Label label45;
		private RazorComboBox gridslot_ComboBox;
		private GroupBox groupBox35;
		private RazorCheckBox gridlock_CheckBox;
		private RazorCheckBox gridopenlogin_CheckBox;
		private Label gridlocation_label;
		private RazorButton gridclose_button;
		private RazorButton gridopen_button;
		private GroupBox groupBox39;
		private TrackBar toolbar_trackBar;
		private Label toolbar_opacity_label;
		private GroupBox groupBox38;
		private TrackBar spellgrid_trackBar;
		private Label spellgrid_opacity_label;
		private TabControl toolbarstab;
		private GroupBox uomodgroupbox;
		private RazorCheckBox uomodFPSCheckBox;
		private RazorCheckBox uomodpaperdoolCheckBox;
		private RazorCheckBox uomodglobalsoundCheckBox;
		private Label labelHotride;
		private RazorTextBox bandagehealmaxrangeTextBox;
		private Label label46;
		private RazorTextBox bandagehealdelayTextBox;
		private Label label31;
		private RazorButton openchangelogButton;
		private RazorButton discordrazorButton;
		private DataGridView vendorsellGridView;
		private ContextMenuStrip datagridMenuStrip;
		private ToolStripMenuItem deleteRowToolStripMenuItem;
		private Label label50;
		private GroupBox groupBox19;
		private DataGridView scavengerdataGridView;
		private DataGridViewCheckBoxColumn VendorSellX;
		private DataGridViewTextBoxColumn VendorSellItemName;
		private DataGridViewTextBoxColumn VendorSellGraphics;
		private DataGridViewTextBoxColumn VendorSellAmount;
		private DataGridViewTextBoxColumn VendorSellColor;
		private GroupBox groupBox41;
		private Label label54;
		private DataGridViewCheckBoxColumn ScavengerX;
		private DataGridViewTextBoxColumn ScavengerItemName;
		private DataGridViewTextBoxColumn ScavenerGraphics;
		private DataGridViewTextBoxColumn ScavengerColor;
		private DataGridViewTextBoxColumn ScavengerProp;
		private DataGridView autolootdataGridView;
		private GroupBox groupBox14;
		private Label label55;
		private DataGridViewCheckBoxColumn AutolootColumnX;
		private DataGridViewTextBoxColumn AutolootColumnItemName;
		private DataGridViewTextBoxColumn AutolootColumnItemID;
		private DataGridViewTextBoxColumn AutolootColumnColor;
		private DataGridViewTextBoxColumn AutolootColumnProps;
		private DataGridView vendorbuydataGridView;
		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private DataGridView organizerdataGridView;
		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private Button organizerStopButton;
		private GroupBox groupBox11;
		private Label label57;
		private Label label56;
		private Button organizerExecuteButton;
		private DataGridView restockdataGridView;
		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
		private GroupBox groupBox3;
		private Label label59;
		private Label label58;
		private Button restockExecuteButton;
		private Button restockStopButton;
		private Label label60;
		private RazorTextBox autoLootTextBoxMaxRange;
		private Label label61;
		private RazorTextBox scavengerRange;
		private RazorCheckBox hiddedAutoOpenDoors;
		private RazorCheckBox uo3dEquipUnEquip;
		private RazorCheckBox nosearchpouches;
		private RazorCheckBox autosearchcontainers;
		private TabPage videoTab;
		private RazorTextBox videoPathTextBox;
		private RazorButton videoPathButton;
		private ListBox videolistBox;
		private GroupBox groupBox40;
		private GroupBox videosettinggroupBox;
		private Button videorecbutton;
		private Button videostopbutton;
		private Label label62;
		private RazorTextBox videoFPSTextBox;
		private GroupBox groupBox15;
		private Label videoRecStatuslabel;
		private Label label64;
		private RazorComboBox videoCodecComboBox;
		private Label label63;
		private RazorCheckBox scriptautostartcheckbox;
		private ColumnHeader autostart;
		private Accord.Controls.VideoSourcePlayer videoSourcePlayer;
		private System.Drawing.Point windowspt;

		[DllImport("User32.dll")]
		private static extern IntPtr GetSystemMenu(IntPtr wnd, bool reset);

		[DllImport("User32.dll")]
		private static extern IntPtr EnableMenuItem(IntPtr menu, uint item, uint options);

		// Enhanced Toolbar
		internal Label LocationToolBarLabel { get { return locationToolBarLabel; } }
		internal RazorCheckBox LockToolBarCheckBox { get { return lockToolBarCheckBox; } }
		internal RazorCheckBox AutoopenToolBarCheckBox { get { return autoopenToolBarCheckBox; } }
		internal RazorComboBox ToolBoxCountComboBox { get { return toolboxcountComboBox; } }
		internal RazorComboBox ToolBoxStyleComboBox { get { return toolboxstyleComboBox; } }
		internal RazorComboBox ToolBoxSizeComboBox { get { return toolboxsizeComboBox; } }
		internal RazorCheckBox ShowHitsToolBarCheckBox { get { return showhitsToolBarCheckBox; } }
		internal RazorCheckBox ShowStaminaToolBarCheckBox { get { return showstaminaToolBarCheckBox; } }
		internal RazorCheckBox ShowManaToolBarCheckBox { get { return showmanaToolBarCheckBox; } }
		internal RazorCheckBox ShowWeightToolBarCheckBox { get { return showweightToolBarCheckBox; } }
		internal RazorCheckBox ShowFollowerToolBarCheckBox { get { return showfollowerToolBarCheckBox; } }
		internal Label ToolBoxSlotsLabel { get { return toolbarslot_label; } }

		// Enhanced Grid
		internal Label GridLocationLabel { get { return gridlocation_label; } }
		internal RazorCheckBox GridLockCheckBox { get { return gridlock_CheckBox; } }
		internal RazorCheckBox GridOpenLoginCheckBox { get { return gridopenlogin_CheckBox; } }
		internal Label GridVSlotLabel { get { return gridvslot_textbox; } }
		internal Label GridHSlotLabel { get { return gridhslot_textbox; } }
		internal RazorComboBox GridSlotComboBox { get { return gridslot_ComboBox; } }
		internal RazorComboBox GridGroupComboBox { get { return gridgroup_ComboBox; } }
		internal RazorComboBox GridBorderComboBox { get { return gridborder_ComboBox; } }

		// AutoLoot
		internal RazorCheckBox AutolootCheckBox { get { return autoLootCheckBox; } }
		internal RazorTextBox AutolootLabelDelay { get { return autoLootTextBoxDelay; } }
		internal RazorTextBox AutoLootTextBoxMaxRange { get { return autoLootTextBoxMaxRange; } }
		internal Label AutoLootContainerLabel { get { return autolootContainerLabel; } }
		internal ListBox AutoLootLogBox { get { return autolootLogBox; } }
		internal RazorComboBox AutoLootListSelect { get { return autolootListSelect; } }
		internal CheckBox AutoLootNoOpenCheckBox { get { return autoLootnoopenCheckBox; } }
		internal DataGridView AutoLootDataGridView { get { return autolootdataGridView; } }

		// Scavenger
		internal RazorCheckBox ScavengerCheckBox { get { return scavengerCheckBox; } }
		internal RazorTextBox ScavengerDragDelay { get { return scavengerDragDelay; } }
		internal RazorTextBox ScavengerRange { get { return scavengerRange; } }
		internal Label ScavengerContainerLabel { get { return scavengerContainerLabel; } }
		internal ListBox ScavengerLogBox { get { return scavengerLogBox; } }
		internal RazorComboBox ScavengerListSelect { get { return scavengerListSelect; } }
		internal DataGridView ScavengerDataGridView { get { return scavengerdataGridView; } }

		// Organizer
		internal RazorTextBox OrganizerDragDelay { get { return organizerDragDelay; } }
		internal Label OrganizerSourceLabel { get { return organizerSourceLabel; } }
		internal Label OrganizerDestinationLabel { get { return organizerDestinationLabel; } }
		internal ListBox OrganizerLogBox { get { return organizerLogBox; } }
		internal DataGridView OrganizerDataGridView { get { return organizerdataGridView; } }
		internal RazorComboBox OrganizerListSelect { get { return organizerListSelect; } }
		internal Button OrganizerExecute { get { return organizerExecuteButton; } }
		internal Button OrganizerStop { get { return organizerStopButton; } }

		// Sell Agent
		internal Label SellBagLabel { get { return sellBagLabel; } }
		internal RazorCheckBox SellCheckBox { get { return sellEnableCheckBox; } }
		internal ListBox SellLogBox { get { return sellLogBox; } }
		internal RazorComboBox SellListSelect { get { return sellListSelect; } }
		internal DataGridView VendorSellGridView { get { return vendorsellGridView; } }

		// Buy Agent
		internal RazorCheckBox BuyCheckBox { get { return buyEnableCheckBox; } }
		internal ListBox BuyLogBox { get { return buyLogBox; } }
		internal RazorComboBox BuyListSelect { get { return buyListSelect; } }
		internal DataGridView VendorBuyDataGridView { get { return vendorbuydataGridView; } }

		// Dress Agent
		internal CheckBox DressCheckBox { get { return dressConflictCheckB; } }
		internal ListView DressListView { get { return dressListView; } }
		internal ListBox DressLogBox { get { return dressLogBox; } }
		internal RazorTextBox DressDragDelay { get { return dressDragDelay; } }
		internal ComboBox DressListSelect { get { return dressListSelect; } }
		internal Label DressBagLabel { get { return dressBagLabel; } }

		internal Button DressExecuteButton { get { return dressExecuteButton; } }
		internal Button UnDressExecuteButton { get { return undressExecuteButton; } }
		internal Button DressStopButton { get { return dressStopButton; } }

		// Friend List
		internal ListBox FriendLogBox { get { return friendLogBox; } }
		internal ListView FriendListView { get { return friendlistView; } }
		internal ComboBox FriendListSelect { get { return friendListSelect; } }
		internal RazorCheckBox FriendPartyCheckBox { get { return friendPartyCheckBox; } }
		internal RazorCheckBox FriendAttackCheckBox { get { return friendAttackCheckBox; } }
		internal RazorCheckBox FriendIncludePartyCheckBox { get { return friendIncludePartyCheckBox; } }
		internal RazorCheckBox FriendSLCheckBox { get { return SLfriendCheckBox; } }
		internal RazorCheckBox FriendTBCheckBox { get { return TBfriendCheckBox; } }
		internal RazorCheckBox FriendCOMCheckBox { get { return COMfriendCheckBox; } }
		internal RazorCheckBox FriendMINCheckBox { get { return MINfriendCheckBox; } }

		internal ListView FriendGuildListView { get { return friendguildListView; } }

		// Restock
		internal RazorTextBox RestockDragDelay { get { return restockDragDelay; } }
		internal Label RestockSourceLabel { get { return restockSourceLabel; } }
		internal Label RestockDestinationLabel { get { return restockDestinationLabel; } }
		internal ListBox RestockLogBox { get { return restockLogBox; } }
		internal DataGridView RestockDataGridView { get { return restockdataGridView; } }
		internal RazorComboBox RestockListSelect { get { return restockListSelect; } }
		internal Button RestockExecute { get { return restockExecuteButton; } }
		internal Button RestockStop { get { return restockStopButton; } }

		// Bandage Heal
		internal ListBox BandageHealLogBox { get { return bandagehealLogBox; } }
		internal RazorCheckBox BandageHealenableCheckBox { get { return bandagehealenableCheckBox; } }
		internal RazorComboBox BandageHealtargetComboBox { get { return bandagehealtargetComboBox; } }
		internal Label BandageHealtargetLabel { get { return bandagehealtargetLabel; } }
		internal RazorCheckBox BandageHealcustomCheckBox { get { return bandagehealcustomCheckBox; } }
		internal RazorTextBox BandageHealcustomIDTextBox { get { return bandagehealcustomIDTextBox; } }
		internal RazorTextBox BandageHealcustomcolorTextBox { get { return bandagehealcustomcolorTextBox; } }
		internal RazorCheckBox BandageHealdexformulaCheckBox { get { return bandagehealdexformulaCheckBox; } }
		internal RazorTextBox BandageHealdelayTextBox { get { return bandagehealdelayTextBox; } }
		internal RazorTextBox BandageHealhpTextBox { get { return bandagehealhpTextBox; } }
		internal RazorTextBox BandageHealMaxRangeTextBox { get { return bandagehealmaxrangeTextBox; } }
		internal RazorCheckBox BandageHealpoisonCheckBox { get { return bandagehealpoisonCheckBox; } }
		internal RazorCheckBox BandageHealmortalCheckBox { get { return bandagehealmortalCheckBox; } }
		internal RazorCheckBox BandageHealhiddedCheckBox { get { return bandagehealhiddedCheckBox; } }
		internal RazorCheckBox BandageHealcountdownCheckBox { get { return bandagehealcountdownCheckBox; } }
		internal RazorButton BandageHealsettargetButton { get { return bandagehealsettargetButton; } }

		// Target
		internal ListView TargetListView { get { return targetlistView; } }

		// Enhanced Filrers
		internal RazorCheckBox BlockPartyInviteCheckBox { get { return blockpartyinviteCheckBox; } }
		internal RazorCheckBox BlockTradeRequestCheckBox { get { return blocktraderequestCheckBox; } }
		internal RazorCheckBox ShowStaticFieldCheckBox { get { return showstaticfieldCheckBox; } }
		internal RazorCheckBox FlagsHighlightCheckBox { get { return flagsHighlightCheckBox; } }
		internal RazorCheckBox HighlightTargetCheckBox { get { return highlighttargetCheckBox; } }
		internal RazorCheckBox AutoCarverCheckBox { get { return autocarverCheckBox; } }
		internal RazorCheckBox BoneCutterCheckBox { get { return bonecutterCheckBox; } }
		internal RazorCheckBox MobFilterCheckBox { get { return mobfilterCheckBox; } }
		internal Label AutoCarverBladeLabel { get { return autocarverbladeLabel; } }
		internal Label BoneBladeLabel { get { return bonebladeLabel; } }
		internal ListView MobFilterlistView { get { return mobfilterlistView; } }
		internal RazorTextBox RemountDelay { get { return remountdelay; } }
		internal RazorTextBox RemountEDelay { get { return remountedelay; } }
		internal Label RemountSerialLabel { get { return remountseriallabel; } }
		internal RazorCheckBox RemountCheckbox { get { return remountcheckbox; } }
		internal RazorCheckBox ShowHeadTargetCheckBox { get { return showheadtargetCheckBox; } }
		internal RazorCheckBox BlockHealPoisonCheckBox { get { return blockhealpoisonCheckBox; } }
		internal RazorCheckBox ColorFlagsHighlightCheckBox { get { return colorflagsHighlightCheckBox; } }
		internal RazorCheckBox BlockMiniHealCheckBox { get { return blockminihealCheckBox; } }
		internal RazorCheckBox BlockBigHealCheckBox { get { return blockbighealCheckBox; } }
		internal RazorCheckBox BlockChivalryHealCheckBox { get { return blockchivalryhealCheckBox; } }
		internal RazorCheckBox ShowMessageFieldCheckBox { get { return showmessagefieldCheckBox; } }
		internal RazorCheckBox ShowAgentMessageCheckBox { get { return showagentmessageCheckBox; } }

		// GumpInspector Flag
		internal bool GumpInspectorEnable = false;

		// Hotkey
		internal TextBox HotKeyTextBox { get { return hotkeytextbox; } }
		internal TreeView HotKeyTreeView { get { return hotkeytreeView; } }
		internal Label HotKeyKeyMasterLabel { get { return hotkeyKeyMasterLabel; } }
		internal Label HotKeyStatusLabel { get { return hotkeyStatusLabel; } }
		internal TextBox HotKeyKeyMasterTextBox { get { return hotkeyKeyMasterTextBox; } }

		// Profiles
		internal RazorComboBox ProfilesComboBox { get { return profilesComboBox; } }

		private DataTable scriptTable;

		// Version check
		internal Thread VersionCheck;

		// General
		internal TextBox ScreenPath { get { return screenPath; } }
		internal TextBox VideoPathTextBox { get { return videoPathTextBox; } }
		

		internal MainForm()
		{
			m_Tip = new ToolTip();
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_NotifyIcon.ContextMenu =
				new ContextMenu(new MenuItem[]
				{
					new MenuItem( "Show Razor", new EventHandler( DoShowMe ) ),
					new MenuItem( "Hide Razor", new EventHandler( HideMe ) ),
					new MenuItem( "-" ),
					new MenuItem( "Toggle Razor Visibility", new EventHandler( ToggleVisible ) ),
					new MenuItem( "-" ),
					new MenuItem( "Close Razor && UO", new EventHandler( OnClose ) ),
				});
			m_NotifyIcon.ContextMenu.MenuItems[0].DefaultItem = true;
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabs = new System.Windows.Forms.TabControl();
			this.generalTab = new System.Windows.Forms.TabPage();
			this.openchangelogButton = new RazorEnhanced.UI.RazorButton();
			this.notshowlauncher = new RazorEnhanced.UI.RazorCheckBox();
			this.groupBox29 = new System.Windows.Forms.GroupBox();
			this.profilesExportButton = new RazorEnhanced.UI.RazorButton();
			this.profilesCloneButton = new RazorEnhanced.UI.RazorButton();
			this.profilesRenameButton = new RazorEnhanced.UI.RazorButton();
			this.profilesImportButton = new RazorEnhanced.UI.RazorButton();
			this.profilesUnlinkButton = new RazorEnhanced.UI.RazorButton();
			this.profilesLinkButton = new RazorEnhanced.UI.RazorButton();
			this.profilelinklabel = new System.Windows.Forms.Label();
			this.profilesDeleteButton = new RazorEnhanced.UI.RazorButton();
			this.profilesAddButton = new RazorEnhanced.UI.RazorButton();
			this.profilesComboBox = new RazorEnhanced.UI.RazorComboBox();
			this.forceSizeY = new RazorEnhanced.UI.RazorTextBox();
			this.forceSizeX = new RazorEnhanced.UI.RazorTextBox();
			this.gameSize = new RazorEnhanced.UI.RazorCheckBox();
			this.rememberPwds = new RazorEnhanced.UI.RazorCheckBox();
			this.clientPrio = new RazorEnhanced.UI.RazorComboBox();
			this.systray = new RazorEnhanced.UI.RazorRadioButton();
			this.taskbar = new RazorEnhanced.UI.RazorRadioButton();
			this.smartCPU = new RazorEnhanced.UI.RazorCheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.opacity = new System.Windows.Forms.TrackBar();
			this.alwaysTop = new RazorEnhanced.UI.RazorCheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.filters = new System.Windows.Forms.CheckedListBox();
			this.opacityLabel = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.moreOptTab = new System.Windows.Forms.TabPage();
			this.nosearchpouches = new RazorEnhanced.UI.RazorCheckBox();
			this.autosearchcontainers = new RazorEnhanced.UI.RazorCheckBox();
			this.uo3dEquipUnEquip = new RazorEnhanced.UI.RazorCheckBox();
			this.hiddedAutoOpenDoors = new RazorEnhanced.UI.RazorCheckBox();
			this.chkPartyOverhead = new RazorEnhanced.UI.RazorCheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.lblHarmHue = new System.Windows.Forms.Label();
			this.lblNeuHue = new System.Windows.Forms.Label();
			this.lblBeneHue = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblWarnHue = new System.Windows.Forms.Label();
			this.lblMsgHue = new System.Windows.Forms.Label();
			this.lblExHue = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.healthFmt = new RazorEnhanced.UI.RazorTextBox();
			this.showHealthOH = new RazorEnhanced.UI.RazorCheckBox();
			this.showtargtext = new RazorEnhanced.UI.RazorCheckBox();
			this.ltRange = new RazorEnhanced.UI.RazorTextBox();
			this.rangeCheckLT = new RazorEnhanced.UI.RazorCheckBox();
			this.smartLT = new RazorEnhanced.UI.RazorCheckBox();
			this.txtObjDelay = new RazorEnhanced.UI.RazorTextBox();
			this.QueueActions = new RazorEnhanced.UI.RazorCheckBox();
			this.actionStatusMsg = new RazorEnhanced.UI.RazorCheckBox();
			this.msglvl = new RazorEnhanced.UI.RazorComboBox();
			this.potionEquip = new RazorEnhanced.UI.RazorCheckBox();
			this.spellUnequip = new RazorEnhanced.UI.RazorCheckBox();
			this.autoOpenDoors = new RazorEnhanced.UI.RazorCheckBox();
			this.alwaysStealth = new RazorEnhanced.UI.RazorCheckBox();
			this.chkStealth = new RazorEnhanced.UI.RazorCheckBox();
			this.preAOSstatbar = new RazorEnhanced.UI.RazorCheckBox();
			this.negotiate = new RazorEnhanced.UI.RazorCheckBox();
			this.setLTHilight = new RazorEnhanced.UI.RazorButton();
			this.lthilight = new RazorEnhanced.UI.RazorCheckBox();
			this.filterSnoop = new RazorEnhanced.UI.RazorCheckBox();
			this.corpseRange = new RazorEnhanced.UI.RazorTextBox();
			this.incomingCorpse = new RazorEnhanced.UI.RazorCheckBox();
			this.incomingMob = new RazorEnhanced.UI.RazorCheckBox();
			this.setHarmHue = new RazorEnhanced.UI.RazorButton();
			this.setNeuHue = new RazorEnhanced.UI.RazorButton();
			this.setBeneHue = new RazorEnhanced.UI.RazorButton();
			this.setSpeechHue = new RazorEnhanced.UI.RazorButton();
			this.setWarnHue = new RazorEnhanced.UI.RazorButton();
			this.setMsgHue = new RazorEnhanced.UI.RazorButton();
			this.setExHue = new RazorEnhanced.UI.RazorButton();
			this.autoStackRes = new RazorEnhanced.UI.RazorCheckBox();
			this.queueTargets = new RazorEnhanced.UI.RazorCheckBox();
			this.spamFilter = new RazorEnhanced.UI.RazorCheckBox();
			this.openCorpses = new RazorEnhanced.UI.RazorCheckBox();
			this.blockDis = new RazorEnhanced.UI.RazorCheckBox();
			this.txtSpellFormat = new RazorEnhanced.UI.RazorTextBox();
			this.chkForceSpellHue = new RazorEnhanced.UI.RazorCheckBox();
			this.chkForceSpeechHue = new RazorEnhanced.UI.RazorCheckBox();
			this.enhancedFilterTab = new System.Windows.Forms.TabPage();
			this.uomodgroupbox = new System.Windows.Forms.GroupBox();
			this.uomodpaperdoolCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.uomodglobalsoundCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.uomodFPSCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.groupBox32 = new System.Windows.Forms.GroupBox();
			this.remountedelay = new RazorEnhanced.UI.RazorTextBox();
			this.remountdelay = new RazorEnhanced.UI.RazorTextBox();
			this.label48 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.remountseriallabel = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.remountsetbutton = new RazorEnhanced.UI.RazorButton();
			this.remountcheckbox = new RazorEnhanced.UI.RazorCheckBox();
			this.groupBox24 = new System.Windows.Forms.GroupBox();
			this.showagentmessageCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.showmessagefieldCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.colorflagsHighlightCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.blockchivalryhealCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.blockbighealCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.blockminihealCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.blockhealpoisonCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.showheadtargetCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.blockpartyinviteCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.blocktraderequestCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.highlighttargetCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.flagsHighlightCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.showstaticfieldCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.groupBox23 = new System.Windows.Forms.GroupBox();
			this.mobfilterRemoveButton = new RazorEnhanced.UI.RazorButton();
			this.mobfilterAddButton = new RazorEnhanced.UI.RazorButton();
			this.mobfilterlistView = new System.Windows.Forms.ListView();
			this.columnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.mobfilterCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.autocarverbladeLabel = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.autocarverrazorButton = new RazorEnhanced.UI.RazorButton();
			this.autocarverCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.bonebladeLabel = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.boneCutterrazorButton = new RazorEnhanced.UI.RazorButton();
			this.bonecutterCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.toolbarTab = new System.Windows.Forms.TabPage();
			this.toolbarstab = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox39 = new System.Windows.Forms.GroupBox();
			this.toolbar_trackBar = new System.Windows.Forms.TrackBar();
			this.toolbar_opacity_label = new System.Windows.Forms.Label();
			this.groupBox25 = new System.Windows.Forms.GroupBox();
			this.lockToolBarCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.autoopenToolBarCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.locationToolBarLabel = new System.Windows.Forms.Label();
			this.closeToolBarButton = new RazorEnhanced.UI.RazorButton();
			this.openToolBarButton = new RazorEnhanced.UI.RazorButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.toolbarremoveslotButton = new RazorEnhanced.UI.RazorButton();
			this.toolbaraddslotButton = new RazorEnhanced.UI.RazorButton();
			this.toolbarslot_label = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.toolboxsizeComboBox = new RazorEnhanced.UI.RazorComboBox();
			this.label41 = new System.Windows.Forms.Label();
			this.showfollowerToolBarCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.showweightToolBarCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.showmanaToolBarCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.showstaminaToolBarCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.showhitsToolBarCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.toolboxstyleComboBox = new RazorEnhanced.UI.RazorComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox26 = new System.Windows.Forms.GroupBox();
			this.label38 = new System.Windows.Forms.Label();
			this.toolboxcountNameTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.toolboxcountClearButton = new RazorEnhanced.UI.RazorButton();
			this.toolboxcountTargetButton = new RazorEnhanced.UI.RazorButton();
			this.toolboxcountWarningTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.toolboxcountHueWarningCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.toolboxcountHueTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.toolboxcountGraphTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.toolboxcountComboBox = new RazorEnhanced.UI.RazorComboBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox38 = new System.Windows.Forms.GroupBox();
			this.spellgrid_trackBar = new System.Windows.Forms.TrackBar();
			this.spellgrid_opacity_label = new System.Windows.Forms.Label();
			this.groupBox37 = new System.Windows.Forms.GroupBox();
			this.gridhslotremove_button = new RazorEnhanced.UI.RazorButton();
			this.gridhslotadd_button = new RazorEnhanced.UI.RazorButton();
			this.gridhslot_textbox = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.gridvslotremove_button = new RazorEnhanced.UI.RazorButton();
			this.gridvslotadd_button = new RazorEnhanced.UI.RazorButton();
			this.gridvslot_textbox = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.groupBox36 = new System.Windows.Forms.GroupBox();
			this.gridborder_ComboBox = new RazorEnhanced.UI.RazorComboBox();
			this.label44 = new System.Windows.Forms.Label();
			this.gridspell_ComboBox = new RazorEnhanced.UI.RazorComboBox();
			this.label52 = new System.Windows.Forms.Label();
			this.gridgroup_ComboBox = new RazorEnhanced.UI.RazorComboBox();
			this.label51 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.gridslot_ComboBox = new RazorEnhanced.UI.RazorComboBox();
			this.groupBox35 = new System.Windows.Forms.GroupBox();
			this.gridlock_CheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.gridopenlogin_CheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.gridlocation_label = new System.Windows.Forms.Label();
			this.gridclose_button = new RazorEnhanced.UI.RazorButton();
			this.gridopen_button = new RazorEnhanced.UI.RazorButton();
			this.emptyTab = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.performTargetButton = new RazorEnhanced.UI.RazorButton();
			this.editTargetButton = new RazorEnhanced.UI.RazorButton();
			this.removeTargetButton = new RazorEnhanced.UI.RazorButton();
			this.addTargetButton = new RazorEnhanced.UI.RazorButton();
			this.targetlistView = new System.Windows.Forms.ListView();
			this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.skillsTab = new System.Windows.Forms.TabPage();
			this.dispDelta = new RazorEnhanced.UI.RazorCheckBox();
			this.skillCopyAll = new RazorEnhanced.UI.RazorButton();
			this.skillCopySel = new RazorEnhanced.UI.RazorButton();
			this.baseTotal = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.locks = new RazorEnhanced.UI.RazorComboBox();
			this.setlocks = new RazorEnhanced.UI.RazorButton();
			this.resetDelta = new RazorEnhanced.UI.RazorButton();
			this.skillList = new System.Windows.Forms.ListView();
			this.skillHDRName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.skillHDRvalue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.skillHDRbase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.skillHDRdelta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.skillHDRcap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.skillHDRlock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.screenshotTab = new System.Windows.Forms.TabPage();
			this.imgFmt = new RazorEnhanced.UI.RazorComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.capNow = new RazorEnhanced.UI.RazorButton();
			this.screenPath = new RazorEnhanced.UI.RazorTextBox();
			this.radioUO = new RazorEnhanced.UI.RazorRadioButton();
			this.radioFull = new RazorEnhanced.UI.RazorRadioButton();
			this.screenAutoCap = new RazorEnhanced.UI.RazorCheckBox();
			this.setScnPath = new RazorEnhanced.UI.RazorButton();
			this.screensList = new System.Windows.Forms.ListBox();
			this.screenPrev = new System.Windows.Forms.PictureBox();
			this.dispTime = new RazorEnhanced.UI.RazorCheckBox();
			this.statusTab = new System.Windows.Forms.TabPage();
			this.discordrazorButton = new RazorEnhanced.UI.RazorButton();
			this.labelHotride = new System.Windows.Forms.Label();
			this.panelLogo = new System.Windows.Forms.Panel();
			this.labelUOD = new System.Windows.Forms.Label();
			this.panelUODlogo = new System.Windows.Forms.Panel();
			this.labelStatus = new System.Windows.Forms.Label();
			this.razorButtonWiki = new RazorEnhanced.UI.RazorButton();
			this.razorButtonCreateUODAccount = new RazorEnhanced.UI.RazorButton();
			this.razorButtonVisitUOD = new RazorEnhanced.UI.RazorButton();
			this.scriptingTab = new System.Windows.Forms.TabPage();
			this.groupBox31 = new System.Windows.Forms.GroupBox();
			this.buttonScriptRefresh = new System.Windows.Forms.Button();
			this.showscriptmessageCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.buttonAddScript = new RazorEnhanced.UI.RazorButton();
			this.buttonRemoveScript = new RazorEnhanced.UI.RazorButton();
			this.buttonScriptDown = new RazorEnhanced.UI.RazorButton();
			this.labelTimerDelay = new System.Windows.Forms.Label();
			this.textBoxDelay = new System.Windows.Forms.TextBox();
			this.buttonScriptUp = new RazorEnhanced.UI.RazorButton();
			this.buttonScriptEditor = new RazorEnhanced.UI.RazorButton();
			this.buttonScriptStop = new System.Windows.Forms.Button();
			this.buttonScriptPlay = new System.Windows.Forms.Button();
			this.groupBox30 = new System.Windows.Forms.GroupBox();
			this.scriptautostartcheckbox = new RazorEnhanced.UI.RazorCheckBox();
			this.scriptwaitmodecheckbox = new RazorEnhanced.UI.RazorCheckBox();
			this.scriptloopmodecheckbox = new RazorEnhanced.UI.RazorCheckBox();
			this.scriptfilelabel = new System.Windows.Forms.Label();
			this.scriptlistView = new RazorEnhanced.UI.ScriptListView();
			this.columnHeader62 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.loop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.autostart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.wait = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.hotkey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.heypass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.EnhancedAgent = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.eautoloot = new System.Windows.Forms.TabPage();
			this.label60 = new System.Windows.Forms.Label();
			this.autoLootTextBoxMaxRange = new RazorEnhanced.UI.RazorTextBox();
			this.autolootItemPropsB = new RazorEnhanced.UI.RazorButton();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.label55 = new System.Windows.Forms.Label();
			this.autolootContainerLabel = new System.Windows.Forms.Label();
			this.autolootContainerButton = new RazorEnhanced.UI.RazorButton();
			this.autolootAddItemBTarget = new RazorEnhanced.UI.RazorButton();
			this.autolootdataGridView = new System.Windows.Forms.DataGridView();
			this.AutolootColumnX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.AutolootColumnItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AutolootColumnItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AutolootColumnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AutolootColumnProps = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.autoLootnoopenCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.label21 = new System.Windows.Forms.Label();
			this.autoLootTextBoxDelay = new RazorEnhanced.UI.RazorTextBox();
			this.autoLootButtonRemoveList = new RazorEnhanced.UI.RazorButton();
			this.autolootButtonAddList = new RazorEnhanced.UI.RazorButton();
			this.autoLootButtonListImport = new RazorEnhanced.UI.RazorButton();
			this.autolootListSelect = new RazorEnhanced.UI.RazorComboBox();
			this.autoLootButtonListExport = new RazorEnhanced.UI.RazorButton();
			this.label20 = new System.Windows.Forms.Label();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.autolootLogBox = new System.Windows.Forms.ListBox();
			this.autoLootCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.escavenger = new System.Windows.Forms.TabPage();
			this.label61 = new System.Windows.Forms.Label();
			this.groupBox41 = new System.Windows.Forms.GroupBox();
			this.label54 = new System.Windows.Forms.Label();
			this.scavengerContainerLabel = new System.Windows.Forms.Label();
			this.scavengerButtonSetContainer = new RazorEnhanced.UI.RazorButton();
			this.scavengerdataGridView = new System.Windows.Forms.DataGridView();
			this.ScavengerX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ScavengerItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ScavenerGraphics = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ScavengerColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ScavengerProp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.scavengerLogBox = new System.Windows.Forms.ListBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.scavengerRange = new RazorEnhanced.UI.RazorTextBox();
			this.scavengerButtonEditProps = new RazorEnhanced.UI.RazorButton();
			this.scavengerButtonAddTarget = new RazorEnhanced.UI.RazorButton();
			this.scavengerDragDelay = new RazorEnhanced.UI.RazorTextBox();
			this.scavengerCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.scavengerButtonRemoveList = new RazorEnhanced.UI.RazorButton();
			this.scavengerButtonAddList = new RazorEnhanced.UI.RazorButton();
			this.scavengerButtonImport = new RazorEnhanced.UI.RazorButton();
			this.scavengerListSelect = new RazorEnhanced.UI.RazorComboBox();
			this.scavengerButtonExport = new RazorEnhanced.UI.RazorButton();
			this.organizer = new System.Windows.Forms.TabPage();
			this.organizerExecuteButton = new System.Windows.Forms.Button();
			this.organizerStopButton = new System.Windows.Forms.Button();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.label57 = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.organizerSetSourceB = new RazorEnhanced.UI.RazorButton();
			this.organizerSetDestinationB = new RazorEnhanced.UI.RazorButton();
			this.organizerSourceLabel = new System.Windows.Forms.Label();
			this.organizerDestinationLabel = new System.Windows.Forms.Label();
			this.organizerdataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox16 = new System.Windows.Forms.GroupBox();
			this.organizerLogBox = new System.Windows.Forms.ListBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.organizerAddTargetB = new RazorEnhanced.UI.RazorButton();
			this.organizerDragDelay = new RazorEnhanced.UI.RazorTextBox();
			this.organizerRemoveListB = new RazorEnhanced.UI.RazorButton();
			this.organizerAddListB = new RazorEnhanced.UI.RazorButton();
			this.organizerImportListB = new RazorEnhanced.UI.RazorButton();
			this.organizerListSelect = new RazorEnhanced.UI.RazorComboBox();
			this.organizerExportListB = new RazorEnhanced.UI.RazorButton();
			this.VendorBuy = new System.Windows.Forms.TabPage();
			this.vendorbuydataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox18 = new System.Windows.Forms.GroupBox();
			this.buyLogBox = new System.Windows.Forms.ListBox();
			this.label25 = new System.Windows.Forms.Label();
			this.buyAddTargetB = new RazorEnhanced.UI.RazorButton();
			this.buyEnableCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.buyRemoveListButton = new RazorEnhanced.UI.RazorButton();
			this.buyAddListButton = new RazorEnhanced.UI.RazorButton();
			this.buyImportListButton = new RazorEnhanced.UI.RazorButton();
			this.buyListSelect = new RazorEnhanced.UI.RazorComboBox();
			this.buyExportListButton = new RazorEnhanced.UI.RazorButton();
			this.VendorSell = new System.Windows.Forms.TabPage();
			this.groupBox19 = new System.Windows.Forms.GroupBox();
			this.sellSetBagButton = new RazorEnhanced.UI.RazorButton();
			this.label50 = new System.Windows.Forms.Label();
			this.sellBagLabel = new System.Windows.Forms.Label();
			this.vendorsellGridView = new System.Windows.Forms.DataGridView();
			this.VendorSellX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.VendorSellItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VendorSellGraphics = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VendorSellAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VendorSellColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox20 = new System.Windows.Forms.GroupBox();
			this.sellLogBox = new System.Windows.Forms.ListBox();
			this.label26 = new System.Windows.Forms.Label();
			this.sellAddTargerButton = new RazorEnhanced.UI.RazorButton();
			this.sellEnableCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.sellRemoveListButton = new RazorEnhanced.UI.RazorButton();
			this.sellAddListButton = new RazorEnhanced.UI.RazorButton();
			this.sellImportListButton = new RazorEnhanced.UI.RazorButton();
			this.sellListSelect = new RazorEnhanced.UI.RazorComboBox();
			this.sellExportListButton = new RazorEnhanced.UI.RazorButton();
			this.Dress = new System.Windows.Forms.TabPage();
			this.dressStopButton = new RazorEnhanced.UI.RazorButton();
			this.dressConflictCheckB = new RazorEnhanced.UI.RazorCheckBox();
			this.dressBagLabel = new System.Windows.Forms.Label();
			this.groupBox22 = new System.Windows.Forms.GroupBox();
			this.dressAddTargetB = new RazorEnhanced.UI.RazorButton();
			this.dressAddManualB = new RazorEnhanced.UI.RazorButton();
			this.dressRemoveB = new RazorEnhanced.UI.RazorButton();
			this.dressReadB = new RazorEnhanced.UI.RazorButton();
			this.label29 = new System.Windows.Forms.Label();
			this.groupBox21 = new System.Windows.Forms.GroupBox();
			this.dressLogBox = new System.Windows.Forms.ListBox();
			this.dressSetBagB = new RazorEnhanced.UI.RazorButton();
			this.undressExecuteButton = new RazorEnhanced.UI.RazorButton();
			this.dressExecuteButton = new RazorEnhanced.UI.RazorButton();
			this.dressDragDelay = new RazorEnhanced.UI.RazorTextBox();
			this.dressListView = new System.Windows.Forms.ListView();
			this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label28 = new System.Windows.Forms.Label();
			this.dressRemoveListB = new RazorEnhanced.UI.RazorButton();
			this.dressAddListB = new RazorEnhanced.UI.RazorButton();
			this.dressImportListB = new RazorEnhanced.UI.RazorButton();
			this.dressListSelect = new RazorEnhanced.UI.RazorComboBox();
			this.dressExportListB = new RazorEnhanced.UI.RazorButton();
			this.friends = new System.Windows.Forms.TabPage();
			this.groupBox34 = new System.Windows.Forms.GroupBox();
			this.FriendGuildAddButton = new RazorEnhanced.UI.RazorButton();
			this.FriendGuildRemoveButton = new RazorEnhanced.UI.RazorButton();
			this.groupBox33 = new System.Windows.Forms.GroupBox();
			this.MINfriendCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.SLfriendCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.TBfriendCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.COMfriendCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.friendguildListView = new System.Windows.Forms.ListView();
			this.columnHeader63 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader64 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.friendGroupBox = new System.Windows.Forms.GroupBox();
			this.friendAddTargetButton = new RazorEnhanced.UI.RazorButton();
			this.friendRemoveButton = new RazorEnhanced.UI.RazorButton();
			this.friendAddButton = new RazorEnhanced.UI.RazorButton();
			this.friendloggroupBox = new System.Windows.Forms.GroupBox();
			this.friendLogBox = new System.Windows.Forms.ListBox();
			this.friendIncludePartyCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.friendAttackCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.friendPartyCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.friendlistView = new System.Windows.Forms.ListView();
			this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labelfriend = new System.Windows.Forms.Label();
			this.friendButtonRemoveList = new RazorEnhanced.UI.RazorButton();
			this.friendButtonAddList = new RazorEnhanced.UI.RazorButton();
			this.friendButtonImportList = new RazorEnhanced.UI.RazorButton();
			this.friendListSelect = new RazorEnhanced.UI.RazorComboBox();
			this.friendButtonExportList = new RazorEnhanced.UI.RazorButton();
			this.restock = new System.Windows.Forms.TabPage();
			this.restockExecuteButton = new System.Windows.Forms.Button();
			this.restockStopButton = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label59 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.restockSetSourceButton = new RazorEnhanced.UI.RazorButton();
			this.restockSourceLabel = new System.Windows.Forms.Label();
			this.restockDestinationLabel = new System.Windows.Forms.Label();
			this.restockSetDestinationButton = new RazorEnhanced.UI.RazorButton();
			this.restockdataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.restockLogBox = new System.Windows.Forms.ListBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.restockAddTargetButton = new RazorEnhanced.UI.RazorButton();
			this.restockDragDelay = new RazorEnhanced.UI.RazorTextBox();
			this.restockRemoveListB = new RazorEnhanced.UI.RazorButton();
			this.restockAddListB = new RazorEnhanced.UI.RazorButton();
			this.restockImportListB = new RazorEnhanced.UI.RazorButton();
			this.restockListSelect = new RazorEnhanced.UI.RazorComboBox();
			this.restockExportListB = new RazorEnhanced.UI.RazorButton();
			this.bandageheal = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.bandagehealmaxrangeTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.bandagehealcountdownCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.bandagehealhiddedCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.bandagehealmortalCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.bandagehealpoisonCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.label33 = new System.Windows.Forms.Label();
			this.bandagehealhpTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.bandagehealdelayTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.bandagehealdexformulaCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.bandagehealcustomcolorTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.bandagehealcustomIDTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.bandagehealcustomCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.bandagehealtargetLabel = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.bandagehealsettargetButton = new RazorEnhanced.UI.RazorButton();
			this.bandagehealtargetComboBox = new RazorEnhanced.UI.RazorComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.bandagehealLogBox = new System.Windows.Forms.ListBox();
			this.bandagehealenableCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.enhancedHotKeytabPage = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.hotkeyMasterClearButton = new RazorEnhanced.UI.RazorButton();
			this.hotkeyKeyMasterTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.hotkeyMasterSetButton = new RazorEnhanced.UI.RazorButton();
			this.label42 = new System.Windows.Forms.Label();
			this.groupBox28 = new System.Windows.Forms.GroupBox();
			this.hotkeyMDisableButton = new RazorEnhanced.UI.RazorButton();
			this.hotkeyMEnableButton = new RazorEnhanced.UI.RazorButton();
			this.hotkeyKeyMasterLabel = new System.Windows.Forms.Label();
			this.hotkeyStatusLabel = new System.Windows.Forms.Label();
			this.groupBox27 = new System.Windows.Forms.GroupBox();
			this.hotkeypassCheckBox = new RazorEnhanced.UI.RazorCheckBox();
			this.hotkeyClearButton = new RazorEnhanced.UI.RazorButton();
			this.hotkeySetButton = new RazorEnhanced.UI.RazorButton();
			this.label39 = new System.Windows.Forms.Label();
			this.hotkeytextbox = new RazorEnhanced.UI.RazorTextBox();
			this.hotkeytreeView = new System.Windows.Forms.TreeView();
			this.videoTab = new System.Windows.Forms.TabPage();
			this.videoRecStatuslabel = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.groupBox40 = new System.Windows.Forms.GroupBox();
			this.videoSourcePlayer = new Accord.Controls.VideoSourcePlayer();
			this.videosettinggroupBox = new System.Windows.Forms.GroupBox();
			this.videoCodecComboBox = new RazorEnhanced.UI.RazorComboBox();
			this.label63 = new System.Windows.Forms.Label();
			this.label62 = new System.Windows.Forms.Label();
			this.videoFPSTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.videorecbutton = new System.Windows.Forms.Button();
			this.videostopbutton = new System.Windows.Forms.Button();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.videolistBox = new System.Windows.Forms.ListBox();
			this.videoPathButton = new RazorEnhanced.UI.RazorButton();
			this.videoPathTextBox = new RazorEnhanced.UI.RazorTextBox();
			this.m_NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.openFileDialogscript = new System.Windows.Forms.OpenFileDialog();
			this.timerupdatestatus = new System.Windows.Forms.Timer(this.components);
			this.datagridMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabs.SuspendLayout();
			this.generalTab.SuspendLayout();
			this.groupBox29.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.opacity)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.moreOptTab.SuspendLayout();
			this.enhancedFilterTab.SuspendLayout();
			this.uomodgroupbox.SuspendLayout();
			this.groupBox32.SuspendLayout();
			this.groupBox24.SuspendLayout();
			this.groupBox23.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.toolbarTab.SuspendLayout();
			this.toolbarstab.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox39.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.toolbar_trackBar)).BeginInit();
			this.groupBox25.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox26.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox38.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spellgrid_trackBar)).BeginInit();
			this.groupBox37.SuspendLayout();
			this.groupBox36.SuspendLayout();
			this.groupBox35.SuspendLayout();
			this.emptyTab.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.skillsTab.SuspendLayout();
			this.screenshotTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.screenPrev)).BeginInit();
			this.statusTab.SuspendLayout();
			this.scriptingTab.SuspendLayout();
			this.groupBox31.SuspendLayout();
			this.groupBox30.SuspendLayout();
			this.EnhancedAgent.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.eautoloot.SuspendLayout();
			this.groupBox14.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.autolootdataGridView)).BeginInit();
			this.groupBox13.SuspendLayout();
			this.escavenger.SuspendLayout();
			this.groupBox41.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scavengerdataGridView)).BeginInit();
			this.groupBox12.SuspendLayout();
			this.organizer.SuspendLayout();
			this.groupBox11.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.organizerdataGridView)).BeginInit();
			this.groupBox16.SuspendLayout();
			this.VendorBuy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vendorbuydataGridView)).BeginInit();
			this.groupBox18.SuspendLayout();
			this.VendorSell.SuspendLayout();
			this.groupBox19.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vendorsellGridView)).BeginInit();
			this.groupBox20.SuspendLayout();
			this.Dress.SuspendLayout();
			this.groupBox22.SuspendLayout();
			this.groupBox21.SuspendLayout();
			this.friends.SuspendLayout();
			this.groupBox34.SuspendLayout();
			this.groupBox33.SuspendLayout();
			this.friendGroupBox.SuspendLayout();
			this.friendloggroupBox.SuspendLayout();
			this.restock.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.restockdataGridView)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.bandageheal.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.enhancedHotKeytabPage.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox28.SuspendLayout();
			this.groupBox27.SuspendLayout();
			this.videoTab.SuspendLayout();
			this.groupBox40.SuspendLayout();
			this.videosettinggroupBox.SuspendLayout();
			this.groupBox15.SuspendLayout();
			this.datagridMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.generalTab);
			this.tabs.Controls.Add(this.moreOptTab);
			this.tabs.Controls.Add(this.enhancedFilterTab);
			this.tabs.Controls.Add(this.toolbarTab);
			this.tabs.Controls.Add(this.emptyTab);
			this.tabs.Controls.Add(this.skillsTab);
			this.tabs.Controls.Add(this.screenshotTab);
			this.tabs.Controls.Add(this.statusTab);
			this.tabs.Controls.Add(this.scriptingTab);
			this.tabs.Controls.Add(this.EnhancedAgent);
			this.tabs.Controls.Add(this.enhancedHotKeytabPage);
			this.tabs.Controls.Add(this.videoTab);
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.Location = new System.Drawing.Point(0, 0);
			this.tabs.Multiline = true;
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(674, 410);
			this.tabs.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
			this.tabs.TabIndex = 0;
			this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_IndexChanged);
			// 
			// generalTab
			// 
			this.generalTab.Controls.Add(this.openchangelogButton);
			this.generalTab.Controls.Add(this.notshowlauncher);
			this.generalTab.Controls.Add(this.groupBox29);
			this.generalTab.Controls.Add(this.forceSizeY);
			this.generalTab.Controls.Add(this.forceSizeX);
			this.generalTab.Controls.Add(this.gameSize);
			this.generalTab.Controls.Add(this.rememberPwds);
			this.generalTab.Controls.Add(this.clientPrio);
			this.generalTab.Controls.Add(this.systray);
			this.generalTab.Controls.Add(this.taskbar);
			this.generalTab.Controls.Add(this.smartCPU);
			this.generalTab.Controls.Add(this.label11);
			this.generalTab.Controls.Add(this.opacity);
			this.generalTab.Controls.Add(this.alwaysTop);
			this.generalTab.Controls.Add(this.groupBox1);
			this.generalTab.Controls.Add(this.opacityLabel);
			this.generalTab.Controls.Add(this.label9);
			this.generalTab.Location = new System.Drawing.Point(4, 40);
			this.generalTab.Name = "generalTab";
			this.generalTab.Size = new System.Drawing.Size(666, 366);
			this.generalTab.TabIndex = 0;
			this.generalTab.Text = "General";
			// 
			// openchangelogButton
			// 
			this.openchangelogButton.Location = new System.Drawing.Point(542, 24);
			this.openchangelogButton.Name = "openchangelogButton";
			this.openchangelogButton.Size = new System.Drawing.Size(95, 23);
			this.openchangelogButton.TabIndex = 68;
			this.openchangelogButton.Text = "Changelog";
			this.openchangelogButton.UseVisualStyleBackColor = true;
			this.openchangelogButton.Click += new System.EventHandler(this.openchangelogButton_Click);
			// 
			// notshowlauncher
			// 
			this.notshowlauncher.Location = new System.Drawing.Point(253, 124);
			this.notshowlauncher.Name = "notshowlauncher";
			this.notshowlauncher.Size = new System.Drawing.Size(241, 22);
			this.notshowlauncher.TabIndex = 67;
			this.notshowlauncher.Text = "Don\'t Show Launcher Window";
			this.notshowlauncher.CheckedChanged += new System.EventHandler(this.notshowlauncher_CheckedChanged);
			// 
			// groupBox29
			// 
			this.groupBox29.Controls.Add(this.profilesExportButton);
			this.groupBox29.Controls.Add(this.profilesCloneButton);
			this.groupBox29.Controls.Add(this.profilesRenameButton);
			this.groupBox29.Controls.Add(this.profilesImportButton);
			this.groupBox29.Controls.Add(this.profilesUnlinkButton);
			this.groupBox29.Controls.Add(this.profilesLinkButton);
			this.groupBox29.Controls.Add(this.profilelinklabel);
			this.groupBox29.Controls.Add(this.profilesDeleteButton);
			this.groupBox29.Controls.Add(this.profilesAddButton);
			this.groupBox29.Controls.Add(this.profilesComboBox);
			this.groupBox29.Location = new System.Drawing.Point(253, 216);
			this.groupBox29.Name = "groupBox29";
			this.groupBox29.Size = new System.Drawing.Size(390, 98);
			this.groupBox29.TabIndex = 66;
			this.groupBox29.TabStop = false;
			this.groupBox29.Text = "Profiles";
			// 
			// profilesExportButton
			// 
			this.profilesExportButton.Location = new System.Drawing.Point(321, 70);
			this.profilesExportButton.Name = "profilesExportButton";
			this.profilesExportButton.Size = new System.Drawing.Size(63, 21);
			this.profilesExportButton.TabIndex = 9;
			this.profilesExportButton.Text = "Export";
			this.profilesExportButton.Click += new System.EventHandler(this.profilesExportButton_Click);
			// 
			// profilesCloneButton
			// 
			this.profilesCloneButton.Location = new System.Drawing.Point(321, 44);
			this.profilesCloneButton.Name = "profilesCloneButton";
			this.profilesCloneButton.Size = new System.Drawing.Size(63, 21);
			this.profilesCloneButton.TabIndex = 9;
			this.profilesCloneButton.Text = "Clone";
			this.profilesCloneButton.Click += new System.EventHandler(this.profilesCloneButton_Click);
			// 
			// profilesRenameButton
			// 
			this.profilesRenameButton.Location = new System.Drawing.Point(252, 44);
			this.profilesRenameButton.Name = "profilesRenameButton";
			this.profilesRenameButton.Size = new System.Drawing.Size(63, 21);
			this.profilesRenameButton.TabIndex = 8;
			this.profilesRenameButton.Text = "Rename";
			this.profilesRenameButton.Click += new System.EventHandler(this.profilesRenameButton_Click);
			// 
			// profilesImportButton
			// 
			this.profilesImportButton.Location = new System.Drawing.Point(252, 70);
			this.profilesImportButton.Name = "profilesImportButton";
			this.profilesImportButton.Size = new System.Drawing.Size(63, 21);
			this.profilesImportButton.TabIndex = 8;
			this.profilesImportButton.Text = "Import";
			this.profilesImportButton.Click += new System.EventHandler(this.profilesImportButton_Click);
			// 
			// profilesUnlinkButton
			// 
			this.profilesUnlinkButton.Location = new System.Drawing.Point(75, 70);
			this.profilesUnlinkButton.Name = "profilesUnlinkButton";
			this.profilesUnlinkButton.Size = new System.Drawing.Size(63, 21);
			this.profilesUnlinkButton.TabIndex = 7;
			this.profilesUnlinkButton.Text = "UnLink";
			this.profilesUnlinkButton.Click += new System.EventHandler(this.profilesUnlinkButton_Click);
			// 
			// profilesLinkButton
			// 
			this.profilesLinkButton.Location = new System.Drawing.Point(6, 70);
			this.profilesLinkButton.Name = "profilesLinkButton";
			this.profilesLinkButton.Size = new System.Drawing.Size(63, 21);
			this.profilesLinkButton.TabIndex = 6;
			this.profilesLinkButton.Text = "Link";
			this.profilesLinkButton.Click += new System.EventHandler(this.profilesLinkButton_Click);
			// 
			// profilelinklabel
			// 
			this.profilelinklabel.AutoSize = true;
			this.profilelinklabel.Location = new System.Drawing.Point(7, 50);
			this.profilelinklabel.Name = "profilelinklabel";
			this.profilelinklabel.Size = new System.Drawing.Size(83, 13);
			this.profilelinklabel.TabIndex = 5;
			this.profilelinklabel.Text = "Linked to: None";
			// 
			// profilesDeleteButton
			// 
			this.profilesDeleteButton.Location = new System.Drawing.Point(321, 18);
			this.profilesDeleteButton.Name = "profilesDeleteButton";
			this.profilesDeleteButton.Size = new System.Drawing.Size(63, 21);
			this.profilesDeleteButton.TabIndex = 4;
			this.profilesDeleteButton.Text = "Delete";
			this.profilesDeleteButton.Click += new System.EventHandler(this.profilesDeleteButton_Click);
			// 
			// profilesAddButton
			// 
			this.profilesAddButton.Location = new System.Drawing.Point(252, 18);
			this.profilesAddButton.Name = "profilesAddButton";
			this.profilesAddButton.Size = new System.Drawing.Size(63, 21);
			this.profilesAddButton.TabIndex = 3;
			this.profilesAddButton.Text = "Add";
			this.profilesAddButton.Click += new System.EventHandler(this.profilesAddButton_Click);
			// 
			// profilesComboBox
			// 
			this.profilesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.profilesComboBox.FormattingEnabled = true;
			this.profilesComboBox.Location = new System.Drawing.Point(6, 19);
			this.profilesComboBox.Name = "profilesComboBox";
			this.profilesComboBox.Size = new System.Drawing.Size(240, 21);
			this.profilesComboBox.TabIndex = 0;
			this.profilesComboBox.SelectedIndexChanged += new System.EventHandler(this.profilesComboBox_SelectedIndexChanged);
			// 
			// forceSizeY
			// 
			this.forceSizeY.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.forceSizeY.BackColor = System.Drawing.Color.White;
			this.forceSizeY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.forceSizeY.Location = new System.Drawing.Point(411, 99);
			this.forceSizeY.Name = "forceSizeY";
			this.forceSizeY.Size = new System.Drawing.Size(30, 20);
			this.forceSizeY.TabIndex = 64;
			this.forceSizeY.TextChanged += new System.EventHandler(this.forceSizeY_TextChanged);
			// 
			// forceSizeX
			// 
			this.forceSizeX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.forceSizeX.BackColor = System.Drawing.Color.White;
			this.forceSizeX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.forceSizeX.Location = new System.Drawing.Point(375, 99);
			this.forceSizeX.Name = "forceSizeX";
			this.forceSizeX.Size = new System.Drawing.Size(30, 20);
			this.forceSizeX.TabIndex = 63;
			this.forceSizeX.TextChanged += new System.EventHandler(this.forceSizeX_TextChanged);
			// 
			// gameSize
			// 
			this.gameSize.Location = new System.Drawing.Point(253, 99);
			this.gameSize.Name = "gameSize";
			this.gameSize.Size = new System.Drawing.Size(114, 22);
			this.gameSize.TabIndex = 65;
			this.gameSize.Text = "Force Game Size:";
			this.gameSize.CheckedChanged += new System.EventHandler(this.gameSize_CheckedChanged);
			// 
			// rememberPwds
			// 
			this.rememberPwds.Location = new System.Drawing.Point(253, 74);
			this.rememberPwds.Name = "rememberPwds";
			this.rememberPwds.Size = new System.Drawing.Size(190, 22);
			this.rememberPwds.TabIndex = 54;
			this.rememberPwds.Text = "Remember passwords ";
			this.rememberPwds.CheckedChanged += new System.EventHandler(this.rememberPwds_CheckedChanged);
			// 
			// clientPrio
			// 
			this.clientPrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.clientPrio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.clientPrio.Items.AddRange(new object[] {
            "Idle",
            "BelowNormal",
            "Normal",
            "AboveNormal",
            "High",
            "Realtime"});
			this.clientPrio.Location = new System.Drawing.Point(363, 186);
			this.clientPrio.Name = "clientPrio";
			this.clientPrio.Size = new System.Drawing.Size(88, 23);
			this.clientPrio.TabIndex = 60;
			this.clientPrio.SelectedIndexChanged += new System.EventHandler(this.clientPrio_SelectedIndexChanged);
			// 
			// systray
			// 
			this.systray.Location = new System.Drawing.Point(363, 153);
			this.systray.Name = "systray";
			this.systray.Size = new System.Drawing.Size(99, 20);
			this.systray.TabIndex = 35;
			this.systray.Text = "System Tray";
			this.systray.CheckedChanged += new System.EventHandler(this.systray_CheckedChanged);
			// 
			// taskbar
			// 
			this.taskbar.Location = new System.Drawing.Point(301, 154);
			this.taskbar.Name = "taskbar";
			this.taskbar.Size = new System.Drawing.Size(63, 20);
			this.taskbar.TabIndex = 34;
			this.taskbar.Text = "Taskbar";
			this.taskbar.CheckedChanged += new System.EventHandler(this.taskbar_CheckedChanged);
			// 
			// smartCPU
			// 
			this.smartCPU.Location = new System.Drawing.Point(253, 24);
			this.smartCPU.Name = "smartCPU";
			this.smartCPU.Size = new System.Drawing.Size(241, 22);
			this.smartCPU.TabIndex = 53;
			this.smartCPU.Text = "Use smart CPU usage reduction";
			this.smartCPU.CheckedChanged += new System.EventHandler(this.smartCPU_CheckedChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(251, 156);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(50, 15);
			this.label11.TabIndex = 33;
			this.label11.Text = "Show in:";
			// 
			// opacity
			// 
			this.opacity.AutoSize = false;
			this.opacity.Cursor = System.Windows.Forms.Cursors.SizeWE;
			this.opacity.Location = new System.Drawing.Point(331, 334);
			this.opacity.Maximum = 100;
			this.opacity.Minimum = 10;
			this.opacity.Name = "opacity";
			this.opacity.Size = new System.Drawing.Size(312, 16);
			this.opacity.TabIndex = 22;
			this.opacity.TickFrequency = 0;
			this.opacity.TickStyle = System.Windows.Forms.TickStyle.None;
			this.opacity.Value = 100;
			this.opacity.Scroll += new System.EventHandler(this.opacity_Scroll);
			// 
			// alwaysTop
			// 
			this.alwaysTop.Location = new System.Drawing.Point(253, 49);
			this.alwaysTop.Name = "alwaysTop";
			this.alwaysTop.Size = new System.Drawing.Size(241, 22);
			this.alwaysTop.TabIndex = 3;
			this.alwaysTop.Text = "Use Smart Always on Top";
			this.alwaysTop.CheckedChanged += new System.EventHandler(this.alwaysTop_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.filters);
			this.groupBox1.Location = new System.Drawing.Point(3, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(202, 350);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filters";
			// 
			// filters
			// 
			this.filters.CheckOnClick = true;
			this.filters.IntegralHeight = false;
			this.filters.Location = new System.Drawing.Point(6, 16);
			this.filters.Name = "filters";
			this.filters.Size = new System.Drawing.Size(190, 328);
			this.filters.TabIndex = 0;
			this.filters.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnFilterCheck);
			// 
			// opacityLabel
			// 
			this.opacityLabel.Location = new System.Drawing.Point(253, 334);
			this.opacityLabel.Name = "opacityLabel";
			this.opacityLabel.Size = new System.Drawing.Size(78, 16);
			this.opacityLabel.TabIndex = 23;
			this.opacityLabel.Text = "Opacity: 100%";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(251, 189);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(114, 19);
			this.label9.TabIndex = 59;
			this.label9.Text = "Default Client Priority:";
			// 
			// moreOptTab
			// 
			this.moreOptTab.Controls.Add(this.nosearchpouches);
			this.moreOptTab.Controls.Add(this.autosearchcontainers);
			this.moreOptTab.Controls.Add(this.uo3dEquipUnEquip);
			this.moreOptTab.Controls.Add(this.hiddedAutoOpenDoors);
			this.moreOptTab.Controls.Add(this.chkPartyOverhead);
			this.moreOptTab.Controls.Add(this.label10);
			this.moreOptTab.Controls.Add(this.label8);
			this.moreOptTab.Controls.Add(this.label5);
			this.moreOptTab.Controls.Add(this.label6);
			this.moreOptTab.Controls.Add(this.label17);
			this.moreOptTab.Controls.Add(this.lblHarmHue);
			this.moreOptTab.Controls.Add(this.lblNeuHue);
			this.moreOptTab.Controls.Add(this.lblBeneHue);
			this.moreOptTab.Controls.Add(this.label4);
			this.moreOptTab.Controls.Add(this.lblWarnHue);
			this.moreOptTab.Controls.Add(this.lblMsgHue);
			this.moreOptTab.Controls.Add(this.lblExHue);
			this.moreOptTab.Controls.Add(this.label3);
			this.moreOptTab.Controls.Add(this.healthFmt);
			this.moreOptTab.Controls.Add(this.showHealthOH);
			this.moreOptTab.Controls.Add(this.showtargtext);
			this.moreOptTab.Controls.Add(this.ltRange);
			this.moreOptTab.Controls.Add(this.rangeCheckLT);
			this.moreOptTab.Controls.Add(this.smartLT);
			this.moreOptTab.Controls.Add(this.txtObjDelay);
			this.moreOptTab.Controls.Add(this.QueueActions);
			this.moreOptTab.Controls.Add(this.actionStatusMsg);
			this.moreOptTab.Controls.Add(this.msglvl);
			this.moreOptTab.Controls.Add(this.potionEquip);
			this.moreOptTab.Controls.Add(this.spellUnequip);
			this.moreOptTab.Controls.Add(this.autoOpenDoors);
			this.moreOptTab.Controls.Add(this.alwaysStealth);
			this.moreOptTab.Controls.Add(this.chkStealth);
			this.moreOptTab.Controls.Add(this.preAOSstatbar);
			this.moreOptTab.Controls.Add(this.negotiate);
			this.moreOptTab.Controls.Add(this.setLTHilight);
			this.moreOptTab.Controls.Add(this.lthilight);
			this.moreOptTab.Controls.Add(this.filterSnoop);
			this.moreOptTab.Controls.Add(this.corpseRange);
			this.moreOptTab.Controls.Add(this.incomingCorpse);
			this.moreOptTab.Controls.Add(this.incomingMob);
			this.moreOptTab.Controls.Add(this.setHarmHue);
			this.moreOptTab.Controls.Add(this.setNeuHue);
			this.moreOptTab.Controls.Add(this.setBeneHue);
			this.moreOptTab.Controls.Add(this.setSpeechHue);
			this.moreOptTab.Controls.Add(this.setWarnHue);
			this.moreOptTab.Controls.Add(this.setMsgHue);
			this.moreOptTab.Controls.Add(this.setExHue);
			this.moreOptTab.Controls.Add(this.autoStackRes);
			this.moreOptTab.Controls.Add(this.queueTargets);
			this.moreOptTab.Controls.Add(this.spamFilter);
			this.moreOptTab.Controls.Add(this.openCorpses);
			this.moreOptTab.Controls.Add(this.blockDis);
			this.moreOptTab.Controls.Add(this.txtSpellFormat);
			this.moreOptTab.Controls.Add(this.chkForceSpellHue);
			this.moreOptTab.Controls.Add(this.chkForceSpeechHue);
			this.moreOptTab.Location = new System.Drawing.Point(4, 40);
			this.moreOptTab.Name = "moreOptTab";
			this.moreOptTab.Size = new System.Drawing.Size(666, 366);
			this.moreOptTab.TabIndex = 5;
			this.moreOptTab.Text = "Options";
			// 
			// nosearchpouches
			// 
			this.nosearchpouches.Location = new System.Drawing.Point(455, 316);
			this.nosearchpouches.Name = "nosearchpouches";
			this.nosearchpouches.Size = new System.Drawing.Size(185, 22);
			this.nosearchpouches.TabIndex = 77;
			this.nosearchpouches.Text = "Ignore pouches";
			this.nosearchpouches.CheckedChanged += new System.EventHandler(this.nosearchpouches_CheckedChanged);
			// 
			// autosearchcontainers
			// 
			this.autosearchcontainers.Location = new System.Drawing.Point(437, 296);
			this.autosearchcontainers.Name = "autosearchcontainers";
			this.autosearchcontainers.Size = new System.Drawing.Size(214, 22);
			this.autosearchcontainers.TabIndex = 76;
			this.autosearchcontainers.Text = "Auto search new containers";
			this.autosearchcontainers.CheckedChanged += new System.EventHandler(this.autosearchcontainers_CheckedChanged);
			// 
			// uo3dEquipUnEquip
			// 
			this.uo3dEquipUnEquip.Location = new System.Drawing.Point(437, 274);
			this.uo3dEquipUnEquip.Name = "uo3dEquipUnEquip";
			this.uo3dEquipUnEquip.Size = new System.Drawing.Size(214, 22);
			this.uo3dEquipUnEquip.TabIndex = 75;
			this.uo3dEquipUnEquip.Text = "Use UO3D Equip and UnEquip";
			this.uo3dEquipUnEquip.CheckedChanged += new System.EventHandler(this.uo3dEquipUnEquip_CheckedChanged);
			// 
			// hiddedAutoOpenDoors
			// 
			this.hiddedAutoOpenDoors.Location = new System.Drawing.Point(222, 294);
			this.hiddedAutoOpenDoors.Name = "hiddedAutoOpenDoors";
			this.hiddedAutoOpenDoors.Size = new System.Drawing.Size(190, 22);
			this.hiddedAutoOpenDoors.TabIndex = 74;
			this.hiddedAutoOpenDoors.Text = "Disable if hidded";
			this.hiddedAutoOpenDoors.CheckedChanged += new System.EventHandler(this.hiddedAutoOpenDoors_CheckedChanged);
			// 
			// chkPartyOverhead
			// 
			this.chkPartyOverhead.Location = new System.Drawing.Point(437, 209);
			this.chkPartyOverhead.Name = "chkPartyOverhead";
			this.chkPartyOverhead.Size = new System.Drawing.Size(226, 21);
			this.chkPartyOverhead.TabIndex = 72;
			this.chkPartyOverhead.Text = "Show mana/stam above party members";
			this.chkPartyOverhead.CheckedChanged += new System.EventHandler(this.chkPartyOverhead_CheckedChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(453, 188);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 17);
			this.label10.TabIndex = 73;
			this.label10.Text = "Health Format:";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(453, 121);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 18);
			this.label8.TabIndex = 72;
			this.label8.Text = "Tiles:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(453, 60);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 18);
			this.label5.TabIndex = 70;
			this.label5.Text = "Object delay:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(568, 59);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(30, 18);
			this.label6.TabIndex = 71;
			this.label6.Text = "ms";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(7, 250);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(92, 18);
			this.label17.TabIndex = 68;
			this.label17.Text = "Razor messages:";
			// 
			// lblHarmHue
			// 
			this.lblHarmHue.Location = new System.Drawing.Point(77, 167);
			this.lblHarmHue.Name = "lblHarmHue";
			this.lblHarmHue.Size = new System.Drawing.Size(45, 14);
			this.lblHarmHue.TabIndex = 46;
			this.lblHarmHue.Text = "Harmful";
			// 
			// lblNeuHue
			// 
			this.lblNeuHue.Location = new System.Drawing.Point(135, 167);
			this.lblNeuHue.Name = "lblNeuHue";
			this.lblNeuHue.Size = new System.Drawing.Size(42, 14);
			this.lblNeuHue.TabIndex = 45;
			this.lblNeuHue.Text = "Neutral";
			// 
			// lblBeneHue
			// 
			this.lblBeneHue.Location = new System.Drawing.Point(17, 167);
			this.lblBeneHue.Name = "lblBeneHue";
			this.lblBeneHue.Size = new System.Drawing.Size(55, 14);
			this.lblBeneHue.TabIndex = 44;
			this.lblBeneHue.Text = "Beneficial";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(384, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 16);
			this.label4.TabIndex = 24;
			this.label4.Text = "tiles";
			// 
			// lblWarnHue
			// 
			this.lblWarnHue.Location = new System.Drawing.Point(7, 69);
			this.lblWarnHue.Name = "lblWarnHue";
			this.lblWarnHue.Size = new System.Drawing.Size(139, 16);
			this.lblWarnHue.TabIndex = 16;
			this.lblWarnHue.Text = "Warning Message Hue";
			// 
			// lblMsgHue
			// 
			this.lblMsgHue.Location = new System.Drawing.Point(7, 44);
			this.lblMsgHue.Name = "lblMsgHue";
			this.lblMsgHue.Size = new System.Drawing.Size(139, 17);
			this.lblMsgHue.TabIndex = 15;
			this.lblMsgHue.Text = "Razor Message Hue";
			// 
			// lblExHue
			// 
			this.lblExHue.Location = new System.Drawing.Point(7, 20);
			this.lblExHue.Name = "lblExHue";
			this.lblExHue.Size = new System.Drawing.Size(139, 16);
			this.lblExHue.TabIndex = 14;
			this.lblExHue.Text = "Search Exemption Hue";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 220);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Spell Format:";
			// 
			// healthFmt
			// 
			this.healthFmt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.healthFmt.BackColor = System.Drawing.Color.White;
			this.healthFmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.healthFmt.Location = new System.Drawing.Point(539, 185);
			this.healthFmt.Name = "healthFmt";
			this.healthFmt.Size = new System.Drawing.Size(46, 20);
			this.healthFmt.TabIndex = 71;
			this.healthFmt.TextChanged += new System.EventHandler(this.healthFmt_TextChanged);
			// 
			// showHealthOH
			// 
			this.showHealthOH.Location = new System.Drawing.Point(437, 162);
			this.showHealthOH.Name = "showHealthOH";
			this.showHealthOH.Size = new System.Drawing.Size(222, 22);
			this.showHealthOH.TabIndex = 69;
			this.showHealthOH.Text = "Show health above people/creatures";
			this.showHealthOH.CheckedChanged += new System.EventHandler(this.showHealthOH_CheckedChanged);
			// 
			// showtargtext
			// 
			this.showtargtext.Location = new System.Drawing.Point(437, 140);
			this.showtargtext.Name = "showtargtext";
			this.showtargtext.Size = new System.Drawing.Size(190, 22);
			this.showtargtext.TabIndex = 53;
			this.showtargtext.Text = "Show target flag on single click";
			this.showtargtext.CheckedChanged += new System.EventHandler(this.showtargtext_CheckedChanged);
			// 
			// ltRange
			// 
			this.ltRange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ltRange.BackColor = System.Drawing.Color.White;
			this.ltRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ltRange.Location = new System.Drawing.Point(491, 119);
			this.ltRange.Name = "ltRange";
			this.ltRange.Size = new System.Drawing.Size(32, 20);
			this.ltRange.TabIndex = 41;
			this.ltRange.TextChanged += new System.EventHandler(this.ltRange_TextChanged);
			// 
			// rangeCheckLT
			// 
			this.rangeCheckLT.Location = new System.Drawing.Point(437, 99);
			this.rangeCheckLT.Name = "rangeCheckLT";
			this.rangeCheckLT.Size = new System.Drawing.Size(185, 22);
			this.rangeCheckLT.TabIndex = 40;
			this.rangeCheckLT.Text = "Range check Last Target:";
			this.rangeCheckLT.CheckedChanged += new System.EventHandler(this.rangeCheckLT_CheckedChanged);
			// 
			// smartLT
			// 
			this.smartLT.Location = new System.Drawing.Point(437, 77);
			this.smartLT.Name = "smartLT";
			this.smartLT.Size = new System.Drawing.Size(185, 22);
			this.smartLT.TabIndex = 52;
			this.smartLT.Text = "Use smart last target";
			this.smartLT.CheckedChanged += new System.EventHandler(this.smartLT_CheckedChanged);
			// 
			// txtObjDelay
			// 
			this.txtObjDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtObjDelay.BackColor = System.Drawing.Color.White;
			this.txtObjDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtObjDelay.Location = new System.Drawing.Point(530, 56);
			this.txtObjDelay.Name = "txtObjDelay";
			this.txtObjDelay.Size = new System.Drawing.Size(32, 20);
			this.txtObjDelay.TabIndex = 37;
			this.txtObjDelay.TextChanged += new System.EventHandler(this.txtObjDelay_TextChanged);
			// 
			// QueueActions
			// 
			this.QueueActions.Location = new System.Drawing.Point(437, 36);
			this.QueueActions.Name = "QueueActions";
			this.QueueActions.Size = new System.Drawing.Size(222, 22);
			this.QueueActions.TabIndex = 34;
			this.QueueActions.Text = "Auto-Queue Object Delay actions ";
			this.QueueActions.CheckedChanged += new System.EventHandler(this.QueueActions_CheckedChanged);
			// 
			// actionStatusMsg
			// 
			this.actionStatusMsg.Location = new System.Drawing.Point(437, 14);
			this.actionStatusMsg.Name = "actionStatusMsg";
			this.actionStatusMsg.Size = new System.Drawing.Size(222, 22);
			this.actionStatusMsg.TabIndex = 38;
			this.actionStatusMsg.Text = "Show Action-Queue status messages";
			this.actionStatusMsg.CheckedChanged += new System.EventHandler(this.actionStatusMsg_CheckedChanged);
			// 
			// msglvl
			// 
			this.msglvl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.msglvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.msglvl.Items.AddRange(new object[] {
            "Show All",
            "Warnings & Errors",
            "Errors Only",
            "None"});
			this.msglvl.Location = new System.Drawing.Point(106, 246);
			this.msglvl.Name = "msglvl";
			this.msglvl.Size = new System.Drawing.Size(88, 23);
			this.msglvl.TabIndex = 69;
			this.msglvl.SelectedIndexChanged += new System.EventHandler(this.msglvl_SelectedIndexChanged);
			// 
			// potionEquip
			// 
			this.potionEquip.Location = new System.Drawing.Point(437, 252);
			this.potionEquip.Name = "potionEquip";
			this.potionEquip.Size = new System.Drawing.Size(214, 22);
			this.potionEquip.TabIndex = 67;
			this.potionEquip.Text = "Auto Un/Re-equip hands for potions";
			this.potionEquip.CheckedChanged += new System.EventHandler(this.potionEquip_CheckedChanged);
			// 
			// spellUnequip
			// 
			this.spellUnequip.Location = new System.Drawing.Point(437, 230);
			this.spellUnequip.Name = "spellUnequip";
			this.spellUnequip.Size = new System.Drawing.Size(214, 22);
			this.spellUnequip.TabIndex = 39;
			this.spellUnequip.Text = "Auto Unequip hands before casting";
			this.spellUnequip.CheckedChanged += new System.EventHandler(this.spellUnequip_CheckedChanged);
			// 
			// autoOpenDoors
			// 
			this.autoOpenDoors.Location = new System.Drawing.Point(204, 274);
			this.autoOpenDoors.Name = "autoOpenDoors";
			this.autoOpenDoors.Size = new System.Drawing.Size(190, 22);
			this.autoOpenDoors.TabIndex = 59;
			this.autoOpenDoors.Text = "Automatically open doors";
			this.autoOpenDoors.CheckedChanged += new System.EventHandler(this.autoOpenDoors_CheckedChanged);
			// 
			// alwaysStealth
			// 
			this.alwaysStealth.Location = new System.Drawing.Point(204, 252);
			this.alwaysStealth.Name = "alwaysStealth";
			this.alwaysStealth.Size = new System.Drawing.Size(190, 22);
			this.alwaysStealth.TabIndex = 57;
			this.alwaysStealth.Text = "Always show stealth steps ";
			this.alwaysStealth.CheckedChanged += new System.EventHandler(this.alwaysStealth_CheckedChanged);
			// 
			// chkStealth
			// 
			this.chkStealth.Location = new System.Drawing.Point(204, 230);
			this.chkStealth.Name = "chkStealth";
			this.chkStealth.Size = new System.Drawing.Size(190, 22);
			this.chkStealth.TabIndex = 12;
			this.chkStealth.Text = "Count stealth steps";
			this.chkStealth.CheckedChanged += new System.EventHandler(this.chkStealth_CheckedChanged);
			// 
			// preAOSstatbar
			// 
			this.preAOSstatbar.Location = new System.Drawing.Point(204, 13);
			this.preAOSstatbar.Name = "preAOSstatbar";
			this.preAOSstatbar.Size = new System.Drawing.Size(190, 22);
			this.preAOSstatbar.TabIndex = 57;
			this.preAOSstatbar.Text = "Use Pre-AOS status window";
			this.preAOSstatbar.CheckedChanged += new System.EventHandler(this.preAOSstatbar_CheckedChanged);
			// 
			// negotiate
			// 
			this.negotiate.Location = new System.Drawing.Point(204, 186);
			this.negotiate.Name = "negotiate";
			this.negotiate.Size = new System.Drawing.Size(224, 22);
			this.negotiate.TabIndex = 56;
			this.negotiate.Text = "Negotiate features with server";
			this.negotiate.CheckedChanged += new System.EventHandler(this.negotiate_CheckedChanged);
			// 
			// setLTHilight
			// 
			this.setLTHilight.Location = new System.Drawing.Point(152, 115);
			this.setLTHilight.Name = "setLTHilight";
			this.setLTHilight.Size = new System.Drawing.Size(32, 20);
			this.setLTHilight.TabIndex = 51;
			this.setLTHilight.Text = "Set";
			this.setLTHilight.Click += new System.EventHandler(this.setLTHilight_Click);
			// 
			// lthilight
			// 
			this.lthilight.Location = new System.Drawing.Point(7, 118);
			this.lthilight.Name = "lthilight";
			this.lthilight.Size = new System.Drawing.Size(139, 22);
			this.lthilight.TabIndex = 50;
			this.lthilight.Text = "Last Target Highlight:";
			this.lthilight.CheckedChanged += new System.EventHandler(this.lthilight_CheckedChanged);
			// 
			// filterSnoop
			// 
			this.filterSnoop.Location = new System.Drawing.Point(204, 143);
			this.filterSnoop.Name = "filterSnoop";
			this.filterSnoop.Size = new System.Drawing.Size(230, 22);
			this.filterSnoop.TabIndex = 49;
			this.filterSnoop.Text = "Filter Snooping Messages";
			this.filterSnoop.CheckedChanged += new System.EventHandler(this.filterSnoop_CheckedChanged);
			// 
			// corpseRange
			// 
			this.corpseRange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.corpseRange.BackColor = System.Drawing.Color.White;
			this.corpseRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.corpseRange.Location = new System.Drawing.Point(355, 100);
			this.corpseRange.Name = "corpseRange";
			this.corpseRange.Size = new System.Drawing.Size(24, 20);
			this.corpseRange.TabIndex = 23;
			this.corpseRange.TextChanged += new System.EventHandler(this.corpseRange_TextChanged);
			// 
			// incomingCorpse
			// 
			this.incomingCorpse.Location = new System.Drawing.Point(204, 208);
			this.incomingCorpse.Name = "incomingCorpse";
			this.incomingCorpse.Size = new System.Drawing.Size(226, 22);
			this.incomingCorpse.TabIndex = 48;
			this.incomingCorpse.Text = "Show Names of New/Incoming Corpses";
			this.incomingCorpse.CheckedChanged += new System.EventHandler(this.incomingCorpse_CheckedChanged);
			// 
			// incomingMob
			// 
			this.incomingMob.Location = new System.Drawing.Point(204, 165);
			this.incomingMob.Name = "incomingMob";
			this.incomingMob.Size = new System.Drawing.Size(244, 22);
			this.incomingMob.TabIndex = 47;
			this.incomingMob.Text = "Show Names of Incoming People/Creatures";
			this.incomingMob.CheckedChanged += new System.EventHandler(this.incomingMob_CheckedChanged);
			// 
			// setHarmHue
			// 
			this.setHarmHue.Enabled = false;
			this.setHarmHue.Location = new System.Drawing.Point(83, 184);
			this.setHarmHue.Name = "setHarmHue";
			this.setHarmHue.Size = new System.Drawing.Size(32, 20);
			this.setHarmHue.TabIndex = 42;
			this.setHarmHue.Text = "Set";
			this.setHarmHue.Click += new System.EventHandler(this.setHarmHue_Click);
			// 
			// setNeuHue
			// 
			this.setNeuHue.Enabled = false;
			this.setNeuHue.Location = new System.Drawing.Point(140, 184);
			this.setNeuHue.Name = "setNeuHue";
			this.setNeuHue.Size = new System.Drawing.Size(31, 20);
			this.setNeuHue.TabIndex = 43;
			this.setNeuHue.Text = "Set";
			this.setNeuHue.Click += new System.EventHandler(this.setNeuHue_Click);
			// 
			// setBeneHue
			// 
			this.setBeneHue.Location = new System.Drawing.Point(28, 184);
			this.setBeneHue.Name = "setBeneHue";
			this.setBeneHue.Size = new System.Drawing.Size(33, 20);
			this.setBeneHue.TabIndex = 41;
			this.setBeneHue.Text = "Set";
			this.setBeneHue.Click += new System.EventHandler(this.setBeneHue_Click);
			// 
			// setSpeechHue
			// 
			this.setSpeechHue.Location = new System.Drawing.Point(152, 91);
			this.setSpeechHue.Name = "setSpeechHue";
			this.setSpeechHue.Size = new System.Drawing.Size(32, 20);
			this.setSpeechHue.TabIndex = 40;
			this.setSpeechHue.Text = "Set";
			this.setSpeechHue.Click += new System.EventHandler(this.setSpeechHue_Click);
			// 
			// setWarnHue
			// 
			this.setWarnHue.Location = new System.Drawing.Point(152, 67);
			this.setWarnHue.Name = "setWarnHue";
			this.setWarnHue.Size = new System.Drawing.Size(32, 20);
			this.setWarnHue.TabIndex = 39;
			this.setWarnHue.Text = "Set";
			this.setWarnHue.Click += new System.EventHandler(this.setWarnHue_Click);
			// 
			// setMsgHue
			// 
			this.setMsgHue.Location = new System.Drawing.Point(152, 43);
			this.setMsgHue.Name = "setMsgHue";
			this.setMsgHue.Size = new System.Drawing.Size(32, 19);
			this.setMsgHue.TabIndex = 38;
			this.setMsgHue.Text = "Set";
			this.setMsgHue.Click += new System.EventHandler(this.setMsgHue_Click);
			// 
			// setExHue
			// 
			this.setExHue.Location = new System.Drawing.Point(152, 18);
			this.setExHue.Name = "setExHue";
			this.setExHue.Size = new System.Drawing.Size(32, 20);
			this.setExHue.TabIndex = 37;
			this.setExHue.Text = "Set";
			this.setExHue.Click += new System.EventHandler(this.setExHue_Click);
			// 
			// autoStackRes
			// 
			this.autoStackRes.Location = new System.Drawing.Point(204, 78);
			this.autoStackRes.Name = "autoStackRes";
			this.autoStackRes.Size = new System.Drawing.Size(228, 22);
			this.autoStackRes.TabIndex = 35;
			this.autoStackRes.Text = "Auto-Stack Ore/Fish/Logs at Feet";
			this.autoStackRes.CheckedChanged += new System.EventHandler(this.autoStackRes_CheckedChanged);
			// 
			// queueTargets
			// 
			this.queueTargets.Location = new System.Drawing.Point(204, 35);
			this.queueTargets.Name = "queueTargets";
			this.queueTargets.Size = new System.Drawing.Size(228, 22);
			this.queueTargets.TabIndex = 34;
			this.queueTargets.Text = "Queue LastTarget and TargetSelf";
			this.queueTargets.CheckedChanged += new System.EventHandler(this.queueTargets_CheckedChanged);
			// 
			// spamFilter
			// 
			this.spamFilter.Location = new System.Drawing.Point(204, 121);
			this.spamFilter.Name = "spamFilter";
			this.spamFilter.Size = new System.Drawing.Size(228, 22);
			this.spamFilter.TabIndex = 26;
			this.spamFilter.Text = "Filter repeating system messages";
			this.spamFilter.CheckedChanged += new System.EventHandler(this.spamFilter_CheckedChanged);
			// 
			// openCorpses
			// 
			this.openCorpses.Location = new System.Drawing.Point(204, 100);
			this.openCorpses.Name = "openCorpses";
			this.openCorpses.Size = new System.Drawing.Size(156, 22);
			this.openCorpses.TabIndex = 22;
			this.openCorpses.Text = "Open new corpses within";
			this.openCorpses.CheckedChanged += new System.EventHandler(this.openCorpses_CheckedChanged);
			// 
			// blockDis
			// 
			this.blockDis.Location = new System.Drawing.Point(204, 56);
			this.blockDis.Name = "blockDis";
			this.blockDis.Size = new System.Drawing.Size(184, 22);
			this.blockDis.TabIndex = 55;
			this.blockDis.Text = "Block dismount in war mode";
			this.blockDis.CheckedChanged += new System.EventHandler(this.blockDis_CheckedChanged);
			// 
			// txtSpellFormat
			// 
			this.txtSpellFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSpellFormat.BackColor = System.Drawing.Color.White;
			this.txtSpellFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSpellFormat.Location = new System.Drawing.Point(106, 218);
			this.txtSpellFormat.Name = "txtSpellFormat";
			this.txtSpellFormat.Size = new System.Drawing.Size(87, 20);
			this.txtSpellFormat.TabIndex = 5;
			this.txtSpellFormat.TextChanged += new System.EventHandler(this.txtSpellFormat_TextChanged);
			// 
			// chkForceSpellHue
			// 
			this.chkForceSpellHue.Location = new System.Drawing.Point(7, 142);
			this.chkForceSpellHue.Name = "chkForceSpellHue";
			this.chkForceSpellHue.Size = new System.Drawing.Size(139, 22);
			this.chkForceSpellHue.TabIndex = 2;
			this.chkForceSpellHue.Text = "Override Spell Hues:";
			this.chkForceSpellHue.CheckedChanged += new System.EventHandler(this.chkForceSpellHue_CheckedChanged);
			// 
			// chkForceSpeechHue
			// 
			this.chkForceSpeechHue.Location = new System.Drawing.Point(7, 94);
			this.chkForceSpeechHue.Name = "chkForceSpeechHue";
			this.chkForceSpeechHue.Size = new System.Drawing.Size(139, 22);
			this.chkForceSpeechHue.TabIndex = 0;
			this.chkForceSpeechHue.Text = "Override Speech Hue";
			this.chkForceSpeechHue.CheckedChanged += new System.EventHandler(this.chkForceSpeechHue_CheckedChanged);
			// 
			// enhancedFilterTab
			// 
			this.enhancedFilterTab.Controls.Add(this.uomodgroupbox);
			this.enhancedFilterTab.Controls.Add(this.groupBox32);
			this.enhancedFilterTab.Controls.Add(this.groupBox24);
			this.enhancedFilterTab.Controls.Add(this.groupBox23);
			this.enhancedFilterTab.Controls.Add(this.groupBox10);
			this.enhancedFilterTab.Controls.Add(this.groupBox9);
			this.enhancedFilterTab.Location = new System.Drawing.Point(4, 40);
			this.enhancedFilterTab.Name = "enhancedFilterTab";
			this.enhancedFilterTab.Size = new System.Drawing.Size(666, 366);
			this.enhancedFilterTab.TabIndex = 10;
			this.enhancedFilterTab.Text = "Enhanced Filters";
			// 
			// uomodgroupbox
			// 
			this.uomodgroupbox.Controls.Add(this.uomodpaperdoolCheckBox);
			this.uomodgroupbox.Controls.Add(this.uomodglobalsoundCheckBox);
			this.uomodgroupbox.Controls.Add(this.uomodFPSCheckBox);
			this.uomodgroupbox.Location = new System.Drawing.Point(192, 266);
			this.uomodgroupbox.Name = "uomodgroupbox";
			this.uomodgroupbox.Size = new System.Drawing.Size(283, 65);
			this.uomodgroupbox.TabIndex = 69;
			this.uomodgroupbox.TabStop = false;
			this.uomodgroupbox.Text = "UoMod (Client < 7.0.50.x)";
			// 
			// uomodpaperdoolCheckBox
			// 
			this.uomodpaperdoolCheckBox.Location = new System.Drawing.Point(119, 15);
			this.uomodpaperdoolCheckBox.Name = "uomodpaperdoolCheckBox";
			this.uomodpaperdoolCheckBox.Size = new System.Drawing.Size(158, 22);
			this.uomodpaperdoolCheckBox.TabIndex = 61;
			this.uomodpaperdoolCheckBox.Text = "Show Paperdool Slot";
			this.uomodpaperdoolCheckBox.CheckedChanged += new System.EventHandler(this.uomodpaperdoolCheckBox_CheckedChanged);
			// 
			// uomodglobalsoundCheckBox
			// 
			this.uomodglobalsoundCheckBox.Location = new System.Drawing.Point(6, 38);
			this.uomodglobalsoundCheckBox.Name = "uomodglobalsoundCheckBox";
			this.uomodglobalsoundCheckBox.Size = new System.Drawing.Size(99, 22);
			this.uomodglobalsoundCheckBox.TabIndex = 60;
			this.uomodglobalsoundCheckBox.Text = "Global Sound";
			this.uomodglobalsoundCheckBox.CheckedChanged += new System.EventHandler(this.uomodglobalsoundCheckBox_CheckedChanged);
			// 
			// uomodFPSCheckBox
			// 
			this.uomodFPSCheckBox.Location = new System.Drawing.Point(6, 15);
			this.uomodFPSCheckBox.Name = "uomodFPSCheckBox";
			this.uomodFPSCheckBox.Size = new System.Drawing.Size(99, 22);
			this.uomodFPSCheckBox.TabIndex = 59;
			this.uomodFPSCheckBox.Text = "Increase FPS";
			this.uomodFPSCheckBox.CheckedChanged += new System.EventHandler(this.uomodFPSCheckBox_CheckedChanged);
			// 
			// groupBox32
			// 
			this.groupBox32.Controls.Add(this.remountedelay);
			this.groupBox32.Controls.Add(this.remountdelay);
			this.groupBox32.Controls.Add(this.label48);
			this.groupBox32.Controls.Add(this.label40);
			this.groupBox32.Controls.Add(this.remountseriallabel);
			this.groupBox32.Controls.Add(this.label47);
			this.groupBox32.Controls.Add(this.remountsetbutton);
			this.groupBox32.Controls.Add(this.remountcheckbox);
			this.groupBox32.Location = new System.Drawing.Point(491, 186);
			this.groupBox32.Name = "groupBox32";
			this.groupBox32.Size = new System.Drawing.Size(165, 118);
			this.groupBox32.TabIndex = 68;
			this.groupBox32.TabStop = false;
			this.groupBox32.Text = "Auto Remount";
			// 
			// remountedelay
			// 
			this.remountedelay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.remountedelay.BackColor = System.Drawing.Color.White;
			this.remountedelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.remountedelay.Location = new System.Drawing.Point(93, 89);
			this.remountedelay.Name = "remountedelay";
			this.remountedelay.Size = new System.Drawing.Size(58, 20);
			this.remountedelay.TabIndex = 68;
			this.remountedelay.TextChanged += new System.EventHandler(this.remountedelay_TextChanged);
			// 
			// remountdelay
			// 
			this.remountdelay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.remountdelay.BackColor = System.Drawing.Color.White;
			this.remountdelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.remountdelay.Location = new System.Drawing.Point(93, 64);
			this.remountdelay.Name = "remountdelay";
			this.remountdelay.Size = new System.Drawing.Size(58, 20);
			this.remountdelay.TabIndex = 67;
			this.remountdelay.TextChanged += new System.EventHandler(this.remountdelay_TextChanged);
			// 
			// label48
			// 
			this.label48.AutoSize = true;
			this.label48.Location = new System.Drawing.Point(6, 91);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(79, 13);
			this.label48.TabIndex = 66;
			this.label48.Text = "Ethereal Delay:";
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(6, 70);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(70, 13);
			this.label40.TabIndex = 65;
			this.label40.Text = "Mount Delay:";
			// 
			// remountseriallabel
			// 
			this.remountseriallabel.AutoSize = true;
			this.remountseriallabel.Location = new System.Drawing.Point(90, 48);
			this.remountseriallabel.Name = "remountseriallabel";
			this.remountseriallabel.Size = new System.Drawing.Size(66, 13);
			this.remountseriallabel.TabIndex = 64;
			this.remountseriallabel.Text = "0x00000000";
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.Location = new System.Drawing.Point(6, 48);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(69, 13);
			this.label47.TabIndex = 63;
			this.label47.Text = "Mount Serial:";
			// 
			// remountsetbutton
			// 
			this.remountsetbutton.Location = new System.Drawing.Point(73, 19);
			this.remountsetbutton.Name = "remountsetbutton";
			this.remountsetbutton.Size = new System.Drawing.Size(75, 21);
			this.remountsetbutton.TabIndex = 62;
			this.remountsetbutton.Text = "Set Mount";
			this.remountsetbutton.UseVisualStyleBackColor = true;
			this.remountsetbutton.Click += new System.EventHandler(this.remountsetbutton_Click);
			// 
			// remountcheckbox
			// 
			this.remountcheckbox.Location = new System.Drawing.Point(6, 19);
			this.remountcheckbox.Name = "remountcheckbox";
			this.remountcheckbox.Size = new System.Drawing.Size(62, 22);
			this.remountcheckbox.TabIndex = 61;
			this.remountcheckbox.Text = "Enable";
			this.remountcheckbox.CheckedChanged += new System.EventHandler(this.remountcheckbox_CheckedChanged);
			// 
			// groupBox24
			// 
			this.groupBox24.Controls.Add(this.showagentmessageCheckBox);
			this.groupBox24.Controls.Add(this.showmessagefieldCheckBox);
			this.groupBox24.Controls.Add(this.colorflagsHighlightCheckBox);
			this.groupBox24.Controls.Add(this.blockchivalryhealCheckBox);
			this.groupBox24.Controls.Add(this.blockbighealCheckBox);
			this.groupBox24.Controls.Add(this.blockminihealCheckBox);
			this.groupBox24.Controls.Add(this.blockhealpoisonCheckBox);
			this.groupBox24.Controls.Add(this.showheadtargetCheckBox);
			this.groupBox24.Controls.Add(this.blockpartyinviteCheckBox);
			this.groupBox24.Controls.Add(this.blocktraderequestCheckBox);
			this.groupBox24.Controls.Add(this.highlighttargetCheckBox);
			this.groupBox24.Controls.Add(this.flagsHighlightCheckBox);
			this.groupBox24.Controls.Add(this.showstaticfieldCheckBox);
			this.groupBox24.Location = new System.Drawing.Point(8, 14);
			this.groupBox24.Name = "groupBox24";
			this.groupBox24.Size = new System.Drawing.Size(178, 317);
			this.groupBox24.TabIndex = 67;
			this.groupBox24.TabStop = false;
			this.groupBox24.Text = "Misc";
			// 
			// showagentmessageCheckBox
			// 
			this.showagentmessageCheckBox.Location = new System.Drawing.Point(6, 290);
			this.showagentmessageCheckBox.Name = "showagentmessageCheckBox";
			this.showagentmessageCheckBox.Size = new System.Drawing.Size(166, 22);
			this.showagentmessageCheckBox.TabIndex = 70;
			this.showagentmessageCheckBox.Text = "Show Agent Message";
			this.showagentmessageCheckBox.CheckedChanged += new System.EventHandler(this.showagentmessageCheckBox_CheckedChanged);
			// 
			// showmessagefieldCheckBox
			// 
			this.showmessagefieldCheckBox.Location = new System.Drawing.Point(6, 108);
			this.showmessagefieldCheckBox.Name = "showmessagefieldCheckBox";
			this.showmessagefieldCheckBox.Size = new System.Drawing.Size(157, 22);
			this.showmessagefieldCheckBox.TabIndex = 69;
			this.showmessagefieldCheckBox.Text = "Show Filed Message";
			this.showmessagefieldCheckBox.CheckedChanged += new System.EventHandler(this.showmessagefieldCheckBox_CheckedChanged);
			// 
			// colorflagsHighlightCheckBox
			// 
			this.colorflagsHighlightCheckBox.Location = new System.Drawing.Point(6, 63);
			this.colorflagsHighlightCheckBox.Name = "colorflagsHighlightCheckBox";
			this.colorflagsHighlightCheckBox.Size = new System.Drawing.Size(145, 22);
			this.colorflagsHighlightCheckBox.TabIndex = 68;
			this.colorflagsHighlightCheckBox.Text = "Color Flag Highlight";
			this.colorflagsHighlightCheckBox.CheckedChanged += new System.EventHandler(this.colorflagsHighlightCheckBox_CheckedChanged);
			// 
			// blockchivalryhealCheckBox
			// 
			this.blockchivalryhealCheckBox.Location = new System.Drawing.Point(6, 267);
			this.blockchivalryhealCheckBox.Name = "blockchivalryhealCheckBox";
			this.blockchivalryhealCheckBox.Size = new System.Drawing.Size(166, 22);
			this.blockchivalryhealCheckBox.TabIndex = 67;
			this.blockchivalryhealCheckBox.Text = "Block ChivaHeal if no need";
			this.blockchivalryhealCheckBox.CheckedChanged += new System.EventHandler(this.blockchivalryhealCheckBox_CheckedChanged);
			// 
			// blockbighealCheckBox
			// 
			this.blockbighealCheckBox.Location = new System.Drawing.Point(6, 244);
			this.blockbighealCheckBox.Name = "blockbighealCheckBox";
			this.blockbighealCheckBox.Size = new System.Drawing.Size(157, 22);
			this.blockbighealCheckBox.TabIndex = 66;
			this.blockbighealCheckBox.Text = "Block BigHeal if no need";
			this.blockbighealCheckBox.CheckedChanged += new System.EventHandler(this.blockbighealCheckBox_CheckedChanged);
			// 
			// blockminihealCheckBox
			// 
			this.blockminihealCheckBox.Location = new System.Drawing.Point(6, 221);
			this.blockminihealCheckBox.Name = "blockminihealCheckBox";
			this.blockminihealCheckBox.Size = new System.Drawing.Size(157, 22);
			this.blockminihealCheckBox.TabIndex = 65;
			this.blockminihealCheckBox.Text = "Block MiniHeal if no need";
			this.blockminihealCheckBox.CheckedChanged += new System.EventHandler(this.blockminihealCheckBox_CheckedChanged);
			// 
			// blockhealpoisonCheckBox
			// 
			this.blockhealpoisonCheckBox.Location = new System.Drawing.Point(6, 198);
			this.blockhealpoisonCheckBox.Name = "blockhealpoisonCheckBox";
			this.blockhealpoisonCheckBox.Size = new System.Drawing.Size(166, 22);
			this.blockhealpoisonCheckBox.TabIndex = 64;
			this.blockhealpoisonCheckBox.Text = "Block Heal if Poison/Mortal";
			this.blockhealpoisonCheckBox.CheckedChanged += new System.EventHandler(this.blockhealpoisonCheckBox_CheckedChanged);
			// 
			// showheadtargetCheckBox
			// 
			this.showheadtargetCheckBox.Location = new System.Drawing.Point(6, 175);
			this.showheadtargetCheckBox.Name = "showheadtargetCheckBox";
			this.showheadtargetCheckBox.Size = new System.Drawing.Size(141, 22);
			this.showheadtargetCheckBox.TabIndex = 63;
			this.showheadtargetCheckBox.Text = "Show Target on Head";
			this.showheadtargetCheckBox.CheckedChanged += new System.EventHandler(this.showheadtargetCheckBox_CheckedChanged);
			// 
			// blockpartyinviteCheckBox
			// 
			this.blockpartyinviteCheckBox.Location = new System.Drawing.Point(6, 152);
			this.blockpartyinviteCheckBox.Name = "blockpartyinviteCheckBox";
			this.blockpartyinviteCheckBox.Size = new System.Drawing.Size(141, 22);
			this.blockpartyinviteCheckBox.TabIndex = 62;
			this.blockpartyinviteCheckBox.Text = "Block Party Invite";
			this.blockpartyinviteCheckBox.CheckedChanged += new System.EventHandler(this.blockpartyinviteCheckBox_CheckedChanged);
			// 
			// blocktraderequestCheckBox
			// 
			this.blocktraderequestCheckBox.Location = new System.Drawing.Point(6, 130);
			this.blocktraderequestCheckBox.Name = "blocktraderequestCheckBox";
			this.blocktraderequestCheckBox.Size = new System.Drawing.Size(141, 22);
			this.blocktraderequestCheckBox.TabIndex = 61;
			this.blocktraderequestCheckBox.Text = "Block Trade Request";
			this.blocktraderequestCheckBox.CheckedChanged += new System.EventHandler(this.blocktraderequestCheckBox_CheckedChanged);
			// 
			// highlighttargetCheckBox
			// 
			this.highlighttargetCheckBox.Location = new System.Drawing.Point(6, 19);
			this.highlighttargetCheckBox.Name = "highlighttargetCheckBox";
			this.highlighttargetCheckBox.Size = new System.Drawing.Size(145, 22);
			this.highlighttargetCheckBox.TabIndex = 58;
			this.highlighttargetCheckBox.Text = "Text Current Target";
			this.highlighttargetCheckBox.CheckedChanged += new System.EventHandler(this.highlighttargetCheckBox_CheckedChanged);
			// 
			// flagsHighlightCheckBox
			// 
			this.flagsHighlightCheckBox.Location = new System.Drawing.Point(6, 41);
			this.flagsHighlightCheckBox.Name = "flagsHighlightCheckBox";
			this.flagsHighlightCheckBox.Size = new System.Drawing.Size(132, 22);
			this.flagsHighlightCheckBox.TabIndex = 59;
			this.flagsHighlightCheckBox.Text = "Text Flags Highlight";
			this.flagsHighlightCheckBox.CheckedChanged += new System.EventHandler(this.flagsHighlightCheckBox_CheckedChanged);
			// 
			// showstaticfieldCheckBox
			// 
			this.showstaticfieldCheckBox.Location = new System.Drawing.Point(6, 85);
			this.showstaticfieldCheckBox.Name = "showstaticfieldCheckBox";
			this.showstaticfieldCheckBox.Size = new System.Drawing.Size(118, 22);
			this.showstaticfieldCheckBox.TabIndex = 60;
			this.showstaticfieldCheckBox.Text = "Show Static Field";
			this.showstaticfieldCheckBox.CheckedChanged += new System.EventHandler(this.showstaticfieldCheckBox_CheckedChanged);
			// 
			// groupBox23
			// 
			this.groupBox23.Controls.Add(this.mobfilterRemoveButton);
			this.groupBox23.Controls.Add(this.mobfilterAddButton);
			this.groupBox23.Controls.Add(this.mobfilterlistView);
			this.groupBox23.Controls.Add(this.mobfilterCheckBox);
			this.groupBox23.Location = new System.Drawing.Point(192, 14);
			this.groupBox23.Name = "groupBox23";
			this.groupBox23.Size = new System.Drawing.Size(283, 246);
			this.groupBox23.TabIndex = 66;
			this.groupBox23.TabStop = false;
			this.groupBox23.Text = "Mobile Graphics Change Filter";
			// 
			// mobfilterRemoveButton
			// 
			this.mobfilterRemoveButton.Location = new System.Drawing.Point(202, 76);
			this.mobfilterRemoveButton.Name = "mobfilterRemoveButton";
			this.mobfilterRemoveButton.Size = new System.Drawing.Size(75, 23);
			this.mobfilterRemoveButton.TabIndex = 68;
			this.mobfilterRemoveButton.Text = "Remove";
			this.mobfilterRemoveButton.UseVisualStyleBackColor = true;
			this.mobfilterRemoveButton.Click += new System.EventHandler(this.mobfilterRemoveButton_Click);
			// 
			// mobfilterAddButton
			// 
			this.mobfilterAddButton.Location = new System.Drawing.Point(202, 47);
			this.mobfilterAddButton.Name = "mobfilterAddButton";
			this.mobfilterAddButton.Size = new System.Drawing.Size(75, 23);
			this.mobfilterAddButton.TabIndex = 67;
			this.mobfilterAddButton.Text = "Add";
			this.mobfilterAddButton.UseVisualStyleBackColor = true;
			this.mobfilterAddButton.Click += new System.EventHandler(this.mobfilterAddButton_Click);
			// 
			// mobfilterlistView
			// 
			this.mobfilterlistView.CheckBoxes = true;
			this.mobfilterlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader52,
            this.columnHeader53,
            this.columnHeader54});
			this.mobfilterlistView.FullRowSelect = true;
			this.mobfilterlistView.GridLines = true;
			this.mobfilterlistView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.mobfilterlistView.HideSelection = false;
			this.mobfilterlistView.LabelWrap = false;
			this.mobfilterlistView.Location = new System.Drawing.Point(6, 47);
			this.mobfilterlistView.MultiSelect = false;
			this.mobfilterlistView.Name = "mobfilterlistView";
			this.mobfilterlistView.Size = new System.Drawing.Size(192, 193);
			this.mobfilterlistView.TabIndex = 67;
			this.mobfilterlistView.UseCompatibleStateImageBehavior = false;
			this.mobfilterlistView.View = System.Windows.Forms.View.Details;
			this.mobfilterlistView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.mobfilterlistView_ItemChecked);
			// 
			// columnHeader52
			// 
			this.columnHeader52.Text = "X";
			this.columnHeader52.Width = 22;
			// 
			// columnHeader53
			// 
			this.columnHeader53.Text = "Old Graphics";
			this.columnHeader53.Width = 80;
			// 
			// columnHeader54
			// 
			this.columnHeader54.Text = "New Graphics";
			this.columnHeader54.Width = 80;
			// 
			// mobfilterCheckBox
			// 
			this.mobfilterCheckBox.Location = new System.Drawing.Point(6, 19);
			this.mobfilterCheckBox.Name = "mobfilterCheckBox";
			this.mobfilterCheckBox.Size = new System.Drawing.Size(79, 22);
			this.mobfilterCheckBox.TabIndex = 61;
			this.mobfilterCheckBox.Text = "Enable";
			this.mobfilterCheckBox.CheckedChanged += new System.EventHandler(this.mobfilterCheckBox_CheckedChanged);
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.autocarverbladeLabel);
			this.groupBox10.Controls.Add(this.label34);
			this.groupBox10.Controls.Add(this.autocarverrazorButton);
			this.groupBox10.Controls.Add(this.autocarverCheckBox);
			this.groupBox10.Location = new System.Drawing.Point(490, 14);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(166, 80);
			this.groupBox10.TabIndex = 65;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Auto Carver";
			// 
			// autocarverbladeLabel
			// 
			this.autocarverbladeLabel.AutoSize = true;
			this.autocarverbladeLabel.Location = new System.Drawing.Point(78, 48);
			this.autocarverbladeLabel.Name = "autocarverbladeLabel";
			this.autocarverbladeLabel.Size = new System.Drawing.Size(66, 13);
			this.autocarverbladeLabel.TabIndex = 64;
			this.autocarverbladeLabel.Text = "0x00000000";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(6, 48);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(66, 13);
			this.label34.TabIndex = 63;
			this.label34.Text = "Blade Serial:";
			// 
			// autocarverrazorButton
			// 
			this.autocarverrazorButton.Location = new System.Drawing.Point(74, 18);
			this.autocarverrazorButton.Name = "autocarverrazorButton";
			this.autocarverrazorButton.Size = new System.Drawing.Size(75, 21);
			this.autocarverrazorButton.TabIndex = 62;
			this.autocarverrazorButton.Text = "Set Blade";
			this.autocarverrazorButton.UseVisualStyleBackColor = true;
			this.autocarverrazorButton.Click += new System.EventHandler(this.autocarverrazorButton_Click);
			// 
			// autocarverCheckBox
			// 
			this.autocarverCheckBox.Location = new System.Drawing.Point(6, 19);
			this.autocarverCheckBox.Name = "autocarverCheckBox";
			this.autocarverCheckBox.Size = new System.Drawing.Size(79, 22);
			this.autocarverCheckBox.TabIndex = 61;
			this.autocarverCheckBox.Text = "Enable";
			this.autocarverCheckBox.CheckedChanged += new System.EventHandler(this.autocarverCheckBox_CheckedChanged);
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.bonebladeLabel);
			this.groupBox9.Controls.Add(this.label16);
			this.groupBox9.Controls.Add(this.boneCutterrazorButton);
			this.groupBox9.Controls.Add(this.bonecutterCheckBox);
			this.groupBox9.Location = new System.Drawing.Point(490, 100);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(166, 80);
			this.groupBox9.TabIndex = 62;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Bone Cutter";
			// 
			// bonebladeLabel
			// 
			this.bonebladeLabel.AutoSize = true;
			this.bonebladeLabel.Location = new System.Drawing.Point(78, 48);
			this.bonebladeLabel.Name = "bonebladeLabel";
			this.bonebladeLabel.Size = new System.Drawing.Size(66, 13);
			this.bonebladeLabel.TabIndex = 64;
			this.bonebladeLabel.Text = "0x00000000";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(6, 48);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(66, 13);
			this.label16.TabIndex = 63;
			this.label16.Text = "Blade Serial:";
			// 
			// boneCutterrazorButton
			// 
			this.boneCutterrazorButton.Location = new System.Drawing.Point(74, 19);
			this.boneCutterrazorButton.Name = "boneCutterrazorButton";
			this.boneCutterrazorButton.Size = new System.Drawing.Size(75, 21);
			this.boneCutterrazorButton.TabIndex = 62;
			this.boneCutterrazorButton.Text = "Set Blade";
			this.boneCutterrazorButton.UseVisualStyleBackColor = true;
			this.boneCutterrazorButton.Click += new System.EventHandler(this.boneCutterrazorButton_Click);
			// 
			// bonecutterCheckBox
			// 
			this.bonecutterCheckBox.Location = new System.Drawing.Point(6, 19);
			this.bonecutterCheckBox.Name = "bonecutterCheckBox";
			this.bonecutterCheckBox.Size = new System.Drawing.Size(79, 22);
			this.bonecutterCheckBox.TabIndex = 61;
			this.bonecutterCheckBox.Text = "Enable";
			this.bonecutterCheckBox.CheckedChanged += new System.EventHandler(this.bonecutterCheckBox_CheckedChanged);
			// 
			// toolbarTab
			// 
			this.toolbarTab.Controls.Add(this.toolbarstab);
			this.toolbarTab.Location = new System.Drawing.Point(4, 40);
			this.toolbarTab.Name = "toolbarTab";
			this.toolbarTab.Size = new System.Drawing.Size(666, 366);
			this.toolbarTab.TabIndex = 1;
			this.toolbarTab.Text = "Enhanced Toolbars";
			// 
			// toolbarstab
			// 
			this.toolbarstab.Controls.Add(this.tabPage2);
			this.toolbarstab.Controls.Add(this.tabPage3);
			this.toolbarstab.Location = new System.Drawing.Point(3, 3);
			this.toolbarstab.Name = "toolbarstab";
			this.toolbarstab.SelectedIndex = 0;
			this.toolbarstab.Size = new System.Drawing.Size(660, 363);
			this.toolbarstab.TabIndex = 62;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.groupBox39);
			this.tabPage2.Controls.Add(this.groupBox25);
			this.tabPage2.Controls.Add(this.groupBox4);
			this.tabPage2.Controls.Add(this.groupBox26);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(652, 337);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Counter / Stat Bar";
			// 
			// groupBox39
			// 
			this.groupBox39.Controls.Add(this.toolbar_trackBar);
			this.groupBox39.Controls.Add(this.toolbar_opacity_label);
			this.groupBox39.Location = new System.Drawing.Point(351, 159);
			this.groupBox39.Name = "groupBox39";
			this.groupBox39.Size = new System.Drawing.Size(295, 50);
			this.groupBox39.TabIndex = 65;
			this.groupBox39.TabStop = false;
			this.groupBox39.Text = "Opacity";
			// 
			// toolbar_trackBar
			// 
			this.toolbar_trackBar.AutoSize = false;
			this.toolbar_trackBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
			this.toolbar_trackBar.Location = new System.Drawing.Point(54, 24);
			this.toolbar_trackBar.Maximum = 100;
			this.toolbar_trackBar.Minimum = 10;
			this.toolbar_trackBar.Name = "toolbar_trackBar";
			this.toolbar_trackBar.Size = new System.Drawing.Size(235, 16);
			this.toolbar_trackBar.TabIndex = 62;
			this.toolbar_trackBar.TickFrequency = 0;
			this.toolbar_trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.toolbar_trackBar.Value = 100;
			this.toolbar_trackBar.Scroll += new System.EventHandler(this.toolbar_trackBar_Scroll);
			// 
			// toolbar_opacity_label
			// 
			this.toolbar_opacity_label.Location = new System.Drawing.Point(8, 24);
			this.toolbar_opacity_label.Name = "toolbar_opacity_label";
			this.toolbar_opacity_label.Size = new System.Drawing.Size(40, 16);
			this.toolbar_opacity_label.TabIndex = 63;
			this.toolbar_opacity_label.Text = "100%";
			// 
			// groupBox25
			// 
			this.groupBox25.Controls.Add(this.lockToolBarCheckBox);
			this.groupBox25.Controls.Add(this.autoopenToolBarCheckBox);
			this.groupBox25.Controls.Add(this.locationToolBarLabel);
			this.groupBox25.Controls.Add(this.closeToolBarButton);
			this.groupBox25.Controls.Add(this.openToolBarButton);
			this.groupBox25.Location = new System.Drawing.Point(6, 6);
			this.groupBox25.Name = "groupBox25";
			this.groupBox25.Size = new System.Drawing.Size(121, 159);
			this.groupBox25.TabIndex = 59;
			this.groupBox25.TabStop = false;
			this.groupBox25.Text = "General";
			// 
			// lockToolBarCheckBox
			// 
			this.lockToolBarCheckBox.Location = new System.Drawing.Point(6, 71);
			this.lockToolBarCheckBox.Name = "lockToolBarCheckBox";
			this.lockToolBarCheckBox.Size = new System.Drawing.Size(99, 22);
			this.lockToolBarCheckBox.TabIndex = 63;
			this.lockToolBarCheckBox.Text = "Lock ToolBar";
			this.lockToolBarCheckBox.CheckedChanged += new System.EventHandler(this.lockToolBarCheckBox_CheckedChanged);
			// 
			// autoopenToolBarCheckBox
			// 
			this.autoopenToolBarCheckBox.Location = new System.Drawing.Point(6, 93);
			this.autoopenToolBarCheckBox.Name = "autoopenToolBarCheckBox";
			this.autoopenToolBarCheckBox.Size = new System.Drawing.Size(112, 22);
			this.autoopenToolBarCheckBox.TabIndex = 62;
			this.autoopenToolBarCheckBox.Text = "Open On Login";
			this.autoopenToolBarCheckBox.CheckedChanged += new System.EventHandler(this.autoopenToolBarCheckBox_CheckedChanged);
			// 
			// locationToolBarLabel
			// 
			this.locationToolBarLabel.AutoSize = true;
			this.locationToolBarLabel.Location = new System.Drawing.Point(6, 118);
			this.locationToolBarLabel.Name = "locationToolBarLabel";
			this.locationToolBarLabel.Size = new System.Drawing.Size(42, 13);
			this.locationToolBarLabel.TabIndex = 61;
			this.locationToolBarLabel.Text = "X:0 Y:0";
			// 
			// closeToolBarButton
			// 
			this.closeToolBarButton.Location = new System.Drawing.Point(6, 45);
			this.closeToolBarButton.Name = "closeToolBarButton";
			this.closeToolBarButton.Size = new System.Drawing.Size(90, 21);
			this.closeToolBarButton.TabIndex = 59;
			this.closeToolBarButton.Text = "Close";
			this.closeToolBarButton.Click += new System.EventHandler(this.closeToolBarButton_Click);
			// 
			// openToolBarButton
			// 
			this.openToolBarButton.Location = new System.Drawing.Point(6, 19);
			this.openToolBarButton.Name = "openToolBarButton";
			this.openToolBarButton.Size = new System.Drawing.Size(90, 21);
			this.openToolBarButton.TabIndex = 58;
			this.openToolBarButton.Text = "Open";
			this.openToolBarButton.Click += new System.EventHandler(this.openToolBarButton_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.toolbarremoveslotButton);
			this.groupBox4.Controls.Add(this.toolbaraddslotButton);
			this.groupBox4.Controls.Add(this.toolbarslot_label);
			this.groupBox4.Controls.Add(this.label43);
			this.groupBox4.Controls.Add(this.toolboxsizeComboBox);
			this.groupBox4.Controls.Add(this.label41);
			this.groupBox4.Controls.Add(this.showfollowerToolBarCheckBox);
			this.groupBox4.Controls.Add(this.showweightToolBarCheckBox);
			this.groupBox4.Controls.Add(this.showmanaToolBarCheckBox);
			this.groupBox4.Controls.Add(this.showstaminaToolBarCheckBox);
			this.groupBox4.Controls.Add(this.showhitsToolBarCheckBox);
			this.groupBox4.Controls.Add(this.toolboxstyleComboBox);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Location = new System.Drawing.Point(351, 6);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(295, 147);
			this.groupBox4.TabIndex = 61;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Layout";
			// 
			// toolbarremoveslotButton
			// 
			this.toolbarremoveslotButton.Location = new System.Drawing.Point(86, 85);
			this.toolbarremoveslotButton.Name = "toolbarremoveslotButton";
			this.toolbarremoveslotButton.Size = new System.Drawing.Size(20, 20);
			this.toolbarremoveslotButton.TabIndex = 79;
			this.toolbarremoveslotButton.Text = "-";
			this.toolbarremoveslotButton.Click += new System.EventHandler(this.toolbarremoveslotButton_Click);
			// 
			// toolbaraddslotButton
			// 
			this.toolbaraddslotButton.Location = new System.Drawing.Point(61, 85);
			this.toolbaraddslotButton.Name = "toolbaraddslotButton";
			this.toolbaraddslotButton.Size = new System.Drawing.Size(20, 20);
			this.toolbaraddslotButton.TabIndex = 71;
			this.toolbaraddslotButton.Text = "+";
			this.toolbaraddslotButton.Click += new System.EventHandler(this.toolbaraddslotButton_Click);
			// 
			// toolbarslot_label
			// 
			this.toolbarslot_label.AutoSize = true;
			this.toolbarslot_label.Location = new System.Drawing.Point(42, 89);
			this.toolbarslot_label.Name = "toolbarslot_label";
			this.toolbarslot_label.Size = new System.Drawing.Size(13, 13);
			this.toolbarslot_label.TabIndex = 78;
			this.toolbarslot_label.Text = "0";
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(6, 89);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(33, 13);
			this.label43.TabIndex = 71;
			this.label43.Text = "Slots:";
			// 
			// toolboxsizeComboBox
			// 
			this.toolboxsizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toolboxsizeComboBox.FormattingEnabled = true;
			this.toolboxsizeComboBox.Location = new System.Drawing.Point(45, 52);
			this.toolboxsizeComboBox.Name = "toolboxsizeComboBox";
			this.toolboxsizeComboBox.Size = new System.Drawing.Size(112, 21);
			this.toolboxsizeComboBox.TabIndex = 77;
			this.toolboxsizeComboBox.SelectedIndexChanged += new System.EventHandler(this.toolboxsizeComboBox_SelectedIndexChanged);
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(6, 58);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(30, 13);
			this.label41.TabIndex = 76;
			this.label41.Text = "Size:";
			// 
			// showfollowerToolBarCheckBox
			// 
			this.showfollowerToolBarCheckBox.Location = new System.Drawing.Point(181, 121);
			this.showfollowerToolBarCheckBox.Name = "showfollowerToolBarCheckBox";
			this.showfollowerToolBarCheckBox.Size = new System.Drawing.Size(99, 22);
			this.showfollowerToolBarCheckBox.TabIndex = 75;
			this.showfollowerToolBarCheckBox.Text = "Show Follower";
			this.showfollowerToolBarCheckBox.CheckedChanged += new System.EventHandler(this.showfollowerToolBarCheckBox_CheckedChanged);
			// 
			// showweightToolBarCheckBox
			// 
			this.showweightToolBarCheckBox.Location = new System.Drawing.Point(181, 95);
			this.showweightToolBarCheckBox.Name = "showweightToolBarCheckBox";
			this.showweightToolBarCheckBox.Size = new System.Drawing.Size(99, 22);
			this.showweightToolBarCheckBox.TabIndex = 74;
			this.showweightToolBarCheckBox.Text = "Show Weight";
			this.showweightToolBarCheckBox.CheckedChanged += new System.EventHandler(this.showweightToolBarCheckBox_CheckedChanged);
			// 
			// showmanaToolBarCheckBox
			// 
			this.showmanaToolBarCheckBox.Location = new System.Drawing.Point(181, 69);
			this.showmanaToolBarCheckBox.Name = "showmanaToolBarCheckBox";
			this.showmanaToolBarCheckBox.Size = new System.Drawing.Size(99, 22);
			this.showmanaToolBarCheckBox.TabIndex = 73;
			this.showmanaToolBarCheckBox.Text = "Show Mana";
			this.showmanaToolBarCheckBox.CheckedChanged += new System.EventHandler(this.showmanaToolBarCheckBox_CheckedChanged);
			// 
			// showstaminaToolBarCheckBox
			// 
			this.showstaminaToolBarCheckBox.Location = new System.Drawing.Point(181, 43);
			this.showstaminaToolBarCheckBox.Name = "showstaminaToolBarCheckBox";
			this.showstaminaToolBarCheckBox.Size = new System.Drawing.Size(99, 22);
			this.showstaminaToolBarCheckBox.TabIndex = 72;
			this.showstaminaToolBarCheckBox.Text = "Show Stamina";
			this.showstaminaToolBarCheckBox.CheckedChanged += new System.EventHandler(this.showstaminaToolBarCheckBox_CheckedChanged);
			// 
			// showhitsToolBarCheckBox
			// 
			this.showhitsToolBarCheckBox.Location = new System.Drawing.Point(181, 17);
			this.showhitsToolBarCheckBox.Name = "showhitsToolBarCheckBox";
			this.showhitsToolBarCheckBox.Size = new System.Drawing.Size(99, 22);
			this.showhitsToolBarCheckBox.TabIndex = 64;
			this.showhitsToolBarCheckBox.Text = "Show Hits";
			this.showhitsToolBarCheckBox.CheckedChanged += new System.EventHandler(this.showhitsToolBarCheckBox_CheckedChanged);
			// 
			// toolboxstyleComboBox
			// 
			this.toolboxstyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toolboxstyleComboBox.FormattingEnabled = true;
			this.toolboxstyleComboBox.Location = new System.Drawing.Point(45, 19);
			this.toolboxstyleComboBox.Name = "toolboxstyleComboBox";
			this.toolboxstyleComboBox.Size = new System.Drawing.Size(112, 21);
			this.toolboxstyleComboBox.TabIndex = 71;
			this.toolboxstyleComboBox.SelectedIndexChanged += new System.EventHandler(this.toolboxstyleComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Style:";
			// 
			// groupBox26
			// 
			this.groupBox26.Controls.Add(this.label38);
			this.groupBox26.Controls.Add(this.toolboxcountNameTextBox);
			this.groupBox26.Controls.Add(this.label37);
			this.groupBox26.Controls.Add(this.toolboxcountClearButton);
			this.groupBox26.Controls.Add(this.toolboxcountTargetButton);
			this.groupBox26.Controls.Add(this.toolboxcountWarningTextBox);
			this.groupBox26.Controls.Add(this.label36);
			this.groupBox26.Controls.Add(this.toolboxcountHueWarningCheckBox);
			this.groupBox26.Controls.Add(this.toolboxcountHueTextBox);
			this.groupBox26.Controls.Add(this.label35);
			this.groupBox26.Controls.Add(this.toolboxcountGraphTextBox);
			this.groupBox26.Controls.Add(this.label18);
			this.groupBox26.Controls.Add(this.toolboxcountComboBox);
			this.groupBox26.Location = new System.Drawing.Point(130, 6);
			this.groupBox26.Name = "groupBox26";
			this.groupBox26.Size = new System.Drawing.Size(214, 203);
			this.groupBox26.TabIndex = 60;
			this.groupBox26.TabStop = false;
			this.groupBox26.Text = "Item Count";
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(131, 102);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(44, 13);
			this.label38.TabIndex = 70;
			this.label38.Text = "-1 for all";
			// 
			// toolboxcountNameTextBox
			// 
			this.toolboxcountNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.toolboxcountNameTextBox.BackColor = System.Drawing.Color.White;
			this.toolboxcountNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.toolboxcountNameTextBox.Location = new System.Drawing.Point(64, 49);
			this.toolboxcountNameTextBox.Name = "toolboxcountNameTextBox";
			this.toolboxcountNameTextBox.Size = new System.Drawing.Size(144, 20);
			this.toolboxcountNameTextBox.TabIndex = 69;
			this.toolboxcountNameTextBox.TextChanged += new System.EventHandler(this.toolboxcountNameTextBox_TextChanged);
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(6, 52);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(38, 13);
			this.label37.TabIndex = 68;
			this.label37.Text = "Name:";
			// 
			// toolboxcountClearButton
			// 
			this.toolboxcountClearButton.Location = new System.Drawing.Point(131, 177);
			this.toolboxcountClearButton.Name = "toolboxcountClearButton";
			this.toolboxcountClearButton.Size = new System.Drawing.Size(77, 21);
			this.toolboxcountClearButton.TabIndex = 67;
			this.toolboxcountClearButton.Text = "Clear Slot";
			this.toolboxcountClearButton.Click += new System.EventHandler(this.toolboxcountClearButton_Click);
			// 
			// toolboxcountTargetButton
			// 
			this.toolboxcountTargetButton.Location = new System.Drawing.Point(9, 177);
			this.toolboxcountTargetButton.Name = "toolboxcountTargetButton";
			this.toolboxcountTargetButton.Size = new System.Drawing.Size(77, 21);
			this.toolboxcountTargetButton.TabIndex = 64;
			this.toolboxcountTargetButton.Text = "Get Data";
			this.toolboxcountTargetButton.Click += new System.EventHandler(this.toolboxcountTargetButton_Click);
			// 
			// toolboxcountWarningTextBox
			// 
			this.toolboxcountWarningTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.toolboxcountWarningTextBox.BackColor = System.Drawing.Color.White;
			this.toolboxcountWarningTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.toolboxcountWarningTextBox.Location = new System.Drawing.Point(64, 148);
			this.toolboxcountWarningTextBox.Name = "toolboxcountWarningTextBox";
			this.toolboxcountWarningTextBox.Size = new System.Drawing.Size(61, 20);
			this.toolboxcountWarningTextBox.TabIndex = 66;
			this.toolboxcountWarningTextBox.TextChanged += new System.EventHandler(this.toolboxcountWarningTextBox_TextChanged);
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(6, 151);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(50, 13);
			this.label36.TabIndex = 65;
			this.label36.Text = "Warning:";
			// 
			// toolboxcountHueWarningCheckBox
			// 
			this.toolboxcountHueWarningCheckBox.Location = new System.Drawing.Point(9, 125);
			this.toolboxcountHueWarningCheckBox.Name = "toolboxcountHueWarningCheckBox";
			this.toolboxcountHueWarningCheckBox.Size = new System.Drawing.Size(99, 22);
			this.toolboxcountHueWarningCheckBox.TabIndex = 64;
			this.toolboxcountHueWarningCheckBox.Text = "Show Warning";
			this.toolboxcountHueWarningCheckBox.CheckedChanged += new System.EventHandler(this.toolboxcountHueWarningCheckBox_CheckedChanged);
			// 
			// toolboxcountHueTextBox
			// 
			this.toolboxcountHueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.toolboxcountHueTextBox.BackColor = System.Drawing.Color.White;
			this.toolboxcountHueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.toolboxcountHueTextBox.Location = new System.Drawing.Point(64, 99);
			this.toolboxcountHueTextBox.Name = "toolboxcountHueTextBox";
			this.toolboxcountHueTextBox.Size = new System.Drawing.Size(61, 20);
			this.toolboxcountHueTextBox.TabIndex = 4;
			this.toolboxcountHueTextBox.TextChanged += new System.EventHandler(this.toolboxcountHueTextBox_TextChanged);
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(6, 102);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(34, 13);
			this.label35.TabIndex = 3;
			this.label35.Text = "Color:";
			// 
			// toolboxcountGraphTextBox
			// 
			this.toolboxcountGraphTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.toolboxcountGraphTextBox.BackColor = System.Drawing.Color.White;
			this.toolboxcountGraphTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.toolboxcountGraphTextBox.Location = new System.Drawing.Point(64, 73);
			this.toolboxcountGraphTextBox.Name = "toolboxcountGraphTextBox";
			this.toolboxcountGraphTextBox.Size = new System.Drawing.Size(61, 20);
			this.toolboxcountGraphTextBox.TabIndex = 2;
			this.toolboxcountGraphTextBox.TextChanged += new System.EventHandler(this.toolboxcountGraphTextBox_TextChanged);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(6, 76);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(52, 13);
			this.label18.TabIndex = 1;
			this.label18.Text = "Graphics:";
			// 
			// toolboxcountComboBox
			// 
			this.toolboxcountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toolboxcountComboBox.FormattingEnabled = true;
			this.toolboxcountComboBox.Location = new System.Drawing.Point(6, 19);
			this.toolboxcountComboBox.Name = "toolboxcountComboBox";
			this.toolboxcountComboBox.Size = new System.Drawing.Size(202, 21);
			this.toolboxcountComboBox.TabIndex = 0;
			this.toolboxcountComboBox.SelectedIndexChanged += new System.EventHandler(this.toolboxcountComboBox_SelectedIndexChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage3.Controls.Add(this.groupBox38);
			this.tabPage3.Controls.Add(this.groupBox37);
			this.tabPage3.Controls.Add(this.groupBox36);
			this.tabPage3.Controls.Add(this.groupBox35);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(652, 337);
			this.tabPage3.TabIndex = 1;
			this.tabPage3.Text = "Spell Grid";
			// 
			// groupBox38
			// 
			this.groupBox38.Controls.Add(this.spellgrid_trackBar);
			this.groupBox38.Controls.Add(this.spellgrid_opacity_label);
			this.groupBox38.Location = new System.Drawing.Point(427, 103);
			this.groupBox38.Name = "groupBox38";
			this.groupBox38.Size = new System.Drawing.Size(219, 48);
			this.groupBox38.TabIndex = 66;
			this.groupBox38.TabStop = false;
			this.groupBox38.Text = "Opacity";
			// 
			// spellgrid_trackBar
			// 
			this.spellgrid_trackBar.AutoSize = false;
			this.spellgrid_trackBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
			this.spellgrid_trackBar.Location = new System.Drawing.Point(43, 20);
			this.spellgrid_trackBar.Maximum = 100;
			this.spellgrid_trackBar.Minimum = 10;
			this.spellgrid_trackBar.Name = "spellgrid_trackBar";
			this.spellgrid_trackBar.Size = new System.Drawing.Size(170, 16);
			this.spellgrid_trackBar.TabIndex = 62;
			this.spellgrid_trackBar.TickFrequency = 0;
			this.spellgrid_trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.spellgrid_trackBar.Value = 100;
			this.spellgrid_trackBar.Scroll += new System.EventHandler(this.spellgrid_trackBar_Scroll);
			// 
			// spellgrid_opacity_label
			// 
			this.spellgrid_opacity_label.Location = new System.Drawing.Point(6, 20);
			this.spellgrid_opacity_label.Name = "spellgrid_opacity_label";
			this.spellgrid_opacity_label.Size = new System.Drawing.Size(36, 16);
			this.spellgrid_opacity_label.TabIndex = 63;
			this.spellgrid_opacity_label.Text = "100%";
			// 
			// groupBox37
			// 
			this.groupBox37.Controls.Add(this.gridhslotremove_button);
			this.groupBox37.Controls.Add(this.gridhslotadd_button);
			this.groupBox37.Controls.Add(this.gridhslot_textbox);
			this.groupBox37.Controls.Add(this.label53);
			this.groupBox37.Controls.Add(this.gridvslotremove_button);
			this.groupBox37.Controls.Add(this.gridvslotadd_button);
			this.groupBox37.Controls.Add(this.gridvslot_textbox);
			this.groupBox37.Controls.Add(this.label49);
			this.groupBox37.Location = new System.Drawing.Point(427, 6);
			this.groupBox37.Name = "groupBox37";
			this.groupBox37.Size = new System.Drawing.Size(129, 91);
			this.groupBox37.TabIndex = 65;
			this.groupBox37.TabStop = false;
			this.groupBox37.Text = "Layout";
			// 
			// gridhslotremove_button
			// 
			this.gridhslotremove_button.Location = new System.Drawing.Point(90, 47);
			this.gridhslotremove_button.Name = "gridhslotremove_button";
			this.gridhslotremove_button.Size = new System.Drawing.Size(20, 20);
			this.gridhslotremove_button.TabIndex = 83;
			this.gridhslotremove_button.Text = "-";
			this.gridhslotremove_button.Click += new System.EventHandler(this.gridhslotremove_button_Click);
			// 
			// gridhslotadd_button
			// 
			this.gridhslotadd_button.Location = new System.Drawing.Point(65, 47);
			this.gridhslotadd_button.Name = "gridhslotadd_button";
			this.gridhslotadd_button.Size = new System.Drawing.Size(20, 20);
			this.gridhslotadd_button.TabIndex = 80;
			this.gridhslotadd_button.Text = "+";
			this.gridhslotadd_button.Click += new System.EventHandler(this.gridhslotadd_button_Click);
			// 
			// gridhslot_textbox
			// 
			this.gridhslot_textbox.AutoSize = true;
			this.gridhslot_textbox.Location = new System.Drawing.Point(48, 51);
			this.gridhslot_textbox.Name = "gridhslot_textbox";
			this.gridhslot_textbox.Size = new System.Drawing.Size(13, 13);
			this.gridhslot_textbox.TabIndex = 82;
			this.gridhslot_textbox.Text = "0";
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(6, 51);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(44, 13);
			this.label53.TabIndex = 81;
			this.label53.Text = "Slots H:";
			// 
			// gridvslotremove_button
			// 
			this.gridvslotremove_button.Location = new System.Drawing.Point(90, 21);
			this.gridvslotremove_button.Name = "gridvslotremove_button";
			this.gridvslotremove_button.Size = new System.Drawing.Size(20, 20);
			this.gridvslotremove_button.TabIndex = 79;
			this.gridvslotremove_button.Text = "-";
			this.gridvslotremove_button.Click += new System.EventHandler(this.gridvslotremove_button_Click);
			// 
			// gridvslotadd_button
			// 
			this.gridvslotadd_button.Location = new System.Drawing.Point(65, 21);
			this.gridvslotadd_button.Name = "gridvslotadd_button";
			this.gridvslotadd_button.Size = new System.Drawing.Size(20, 20);
			this.gridvslotadd_button.TabIndex = 71;
			this.gridvslotadd_button.Text = "+";
			this.gridvslotadd_button.Click += new System.EventHandler(this.gridvslotadd_button_Click);
			// 
			// gridvslot_textbox
			// 
			this.gridvslot_textbox.AutoSize = true;
			this.gridvslot_textbox.Location = new System.Drawing.Point(48, 25);
			this.gridvslot_textbox.Name = "gridvslot_textbox";
			this.gridvslot_textbox.Size = new System.Drawing.Size(13, 13);
			this.gridvslot_textbox.TabIndex = 78;
			this.gridvslot_textbox.Text = "0";
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.Location = new System.Drawing.Point(6, 25);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(43, 13);
			this.label49.TabIndex = 71;
			this.label49.Text = "Slots V:";
			// 
			// groupBox36
			// 
			this.groupBox36.Controls.Add(this.gridborder_ComboBox);
			this.groupBox36.Controls.Add(this.label44);
			this.groupBox36.Controls.Add(this.gridspell_ComboBox);
			this.groupBox36.Controls.Add(this.label52);
			this.groupBox36.Controls.Add(this.gridgroup_ComboBox);
			this.groupBox36.Controls.Add(this.label51);
			this.groupBox36.Controls.Add(this.label45);
			this.groupBox36.Controls.Add(this.gridslot_ComboBox);
			this.groupBox36.Location = new System.Drawing.Point(133, 6);
			this.groupBox36.Name = "groupBox36";
			this.groupBox36.Size = new System.Drawing.Size(288, 145);
			this.groupBox36.TabIndex = 64;
			this.groupBox36.TabStop = false;
			this.groupBox36.Text = "Grid Item";
			// 
			// gridborder_ComboBox
			// 
			this.gridborder_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gridborder_ComboBox.FormattingEnabled = true;
			this.gridborder_ComboBox.Location = new System.Drawing.Point(75, 107);
			this.gridborder_ComboBox.Name = "gridborder_ComboBox";
			this.gridborder_ComboBox.Size = new System.Drawing.Size(202, 21);
			this.gridborder_ComboBox.TabIndex = 76;
			this.gridborder_ComboBox.SelectedIndexChanged += new System.EventHandler(this.gridborder_ComboBox_SelectedIndexChanged);
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(6, 112);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(44, 13);
			this.label44.TabIndex = 75;
			this.label44.Text = "Border: ";
			// 
			// gridspell_ComboBox
			// 
			this.gridspell_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gridspell_ComboBox.FormattingEnabled = true;
			this.gridspell_ComboBox.Location = new System.Drawing.Point(75, 77);
			this.gridspell_ComboBox.Name = "gridspell_ComboBox";
			this.gridspell_ComboBox.Size = new System.Drawing.Size(202, 21);
			this.gridspell_ComboBox.TabIndex = 74;
			this.gridspell_ComboBox.SelectedIndexChanged += new System.EventHandler(this.gridspell_ComboBox_SelectedIndexChanged);
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.Location = new System.Drawing.Point(6, 82);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(68, 13);
			this.label52.TabIndex = 73;
			this.label52.Text = "Abilitie/Spell:";
			// 
			// gridgroup_ComboBox
			// 
			this.gridgroup_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gridgroup_ComboBox.FormattingEnabled = true;
			this.gridgroup_ComboBox.Location = new System.Drawing.Point(75, 47);
			this.gridgroup_ComboBox.Name = "gridgroup_ComboBox";
			this.gridgroup_ComboBox.Size = new System.Drawing.Size(202, 21);
			this.gridgroup_ComboBox.TabIndex = 72;
			this.gridgroup_ComboBox.SelectedIndexChanged += new System.EventHandler(this.gridgroup_ComboBox_SelectedIndexChanged);
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.Location = new System.Drawing.Point(6, 23);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(28, 13);
			this.label51.TabIndex = 71;
			this.label51.Text = "Slot:";
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(6, 52);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(39, 13);
			this.label45.TabIndex = 68;
			this.label45.Text = "Group:";
			// 
			// gridslot_ComboBox
			// 
			this.gridslot_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gridslot_ComboBox.FormattingEnabled = true;
			this.gridslot_ComboBox.Location = new System.Drawing.Point(75, 17);
			this.gridslot_ComboBox.Name = "gridslot_ComboBox";
			this.gridslot_ComboBox.Size = new System.Drawing.Size(202, 21);
			this.gridslot_ComboBox.TabIndex = 0;
			this.gridslot_ComboBox.SelectedIndexChanged += new System.EventHandler(this.gridslot_ComboBox_SelectedIndexChanged);
			// 
			// groupBox35
			// 
			this.groupBox35.Controls.Add(this.gridlock_CheckBox);
			this.groupBox35.Controls.Add(this.gridopenlogin_CheckBox);
			this.groupBox35.Controls.Add(this.gridlocation_label);
			this.groupBox35.Controls.Add(this.gridclose_button);
			this.groupBox35.Controls.Add(this.gridopen_button);
			this.groupBox35.Location = new System.Drawing.Point(6, 6);
			this.groupBox35.Name = "groupBox35";
			this.groupBox35.Size = new System.Drawing.Size(121, 145);
			this.groupBox35.TabIndex = 63;
			this.groupBox35.TabStop = false;
			this.groupBox35.Text = "General";
			// 
			// gridlock_CheckBox
			// 
			this.gridlock_CheckBox.Location = new System.Drawing.Point(6, 71);
			this.gridlock_CheckBox.Name = "gridlock_CheckBox";
			this.gridlock_CheckBox.Size = new System.Drawing.Size(99, 22);
			this.gridlock_CheckBox.TabIndex = 63;
			this.gridlock_CheckBox.Text = "Lock Grid";
			this.gridlock_CheckBox.CheckedChanged += new System.EventHandler(this.gridlock_CheckBox_CheckedChanged);
			// 
			// gridopenlogin_CheckBox
			// 
			this.gridopenlogin_CheckBox.Location = new System.Drawing.Point(6, 93);
			this.gridopenlogin_CheckBox.Name = "gridopenlogin_CheckBox";
			this.gridopenlogin_CheckBox.Size = new System.Drawing.Size(112, 22);
			this.gridopenlogin_CheckBox.TabIndex = 62;
			this.gridopenlogin_CheckBox.Text = "Open On Login";
			this.gridopenlogin_CheckBox.CheckedChanged += new System.EventHandler(this.gridopenlogin_CheckBox_CheckedChanged);
			// 
			// gridlocation_label
			// 
			this.gridlocation_label.AutoSize = true;
			this.gridlocation_label.Location = new System.Drawing.Point(6, 118);
			this.gridlocation_label.Name = "gridlocation_label";
			this.gridlocation_label.Size = new System.Drawing.Size(42, 13);
			this.gridlocation_label.TabIndex = 61;
			this.gridlocation_label.Text = "X:0 Y:0";
			// 
			// gridclose_button
			// 
			this.gridclose_button.Location = new System.Drawing.Point(6, 45);
			this.gridclose_button.Name = "gridclose_button";
			this.gridclose_button.Size = new System.Drawing.Size(90, 21);
			this.gridclose_button.TabIndex = 59;
			this.gridclose_button.Text = "Close";
			this.gridclose_button.Click += new System.EventHandler(this.gridclose_button_Click);
			// 
			// gridopen_button
			// 
			this.gridopen_button.Location = new System.Drawing.Point(6, 19);
			this.gridopen_button.Name = "gridopen_button";
			this.gridopen_button.Size = new System.Drawing.Size(90, 21);
			this.gridopen_button.TabIndex = 58;
			this.gridopen_button.Text = "Open";
			this.gridopen_button.Click += new System.EventHandler(this.gridopen_button_Click);
			// 
			// emptyTab
			// 
			this.emptyTab.Controls.Add(this.groupBox7);
			this.emptyTab.Controls.Add(this.targetlistView);
			this.emptyTab.Location = new System.Drawing.Point(4, 40);
			this.emptyTab.Name = "emptyTab";
			this.emptyTab.Size = new System.Drawing.Size(666, 366);
			this.emptyTab.TabIndex = 3;
			this.emptyTab.Text = "Enhanced Targetting";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.performTargetButton);
			this.groupBox7.Controls.Add(this.editTargetButton);
			this.groupBox7.Controls.Add(this.removeTargetButton);
			this.groupBox7.Controls.Add(this.addTargetButton);
			this.groupBox7.Location = new System.Drawing.Point(8, 297);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(650, 61);
			this.groupBox7.TabIndex = 49;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Manage Targets";
			// 
			// performTargetButton
			// 
			this.performTargetButton.Location = new System.Drawing.Point(495, 23);
			this.performTargetButton.Name = "performTargetButton";
			this.performTargetButton.Size = new System.Drawing.Size(136, 23);
			this.performTargetButton.TabIndex = 3;
			this.performTargetButton.Text = "Perform Target Filter";
			this.performTargetButton.UseVisualStyleBackColor = true;
			this.performTargetButton.Click += new System.EventHandler(this.performTargetButton_Click);
			// 
			// editTargetButton
			// 
			this.editTargetButton.Location = new System.Drawing.Point(338, 23);
			this.editTargetButton.Name = "editTargetButton";
			this.editTargetButton.Size = new System.Drawing.Size(136, 23);
			this.editTargetButton.TabIndex = 2;
			this.editTargetButton.Text = "Edit Target Filter";
			this.editTargetButton.UseVisualStyleBackColor = true;
			this.editTargetButton.Click += new System.EventHandler(this.editTargetButton_Click);
			// 
			// removeTargetButton
			// 
			this.removeTargetButton.Location = new System.Drawing.Point(177, 23);
			this.removeTargetButton.Name = "removeTargetButton";
			this.removeTargetButton.Size = new System.Drawing.Size(136, 23);
			this.removeTargetButton.TabIndex = 1;
			this.removeTargetButton.Text = "Remove Target Filter";
			this.removeTargetButton.UseVisualStyleBackColor = true;
			this.removeTargetButton.Click += new System.EventHandler(this.removeTargetButton_Click);
			// 
			// addTargetButton
			// 
			this.addTargetButton.Location = new System.Drawing.Point(16, 23);
			this.addTargetButton.Name = "addTargetButton";
			this.addTargetButton.Size = new System.Drawing.Size(136, 23);
			this.addTargetButton.TabIndex = 0;
			this.addTargetButton.Text = "Add Target Filter";
			this.addTargetButton.UseVisualStyleBackColor = true;
			this.addTargetButton.Click += new System.EventHandler(this.addTargetButton_Click);
			// 
			// targetlistView
			// 
			this.targetlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader51,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader41,
            this.columnHeader42,
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader48,
            this.columnHeader55,
            this.columnHeader49,
            this.columnHeader50});
			this.targetlistView.FullRowSelect = true;
			this.targetlistView.GridLines = true;
			this.targetlistView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.targetlistView.HideSelection = false;
			this.targetlistView.LabelWrap = false;
			this.targetlistView.Location = new System.Drawing.Point(8, 12);
			this.targetlistView.MultiSelect = false;
			this.targetlistView.Name = "targetlistView";
			this.targetlistView.Size = new System.Drawing.Size(650, 279);
			this.targetlistView.TabIndex = 48;
			this.targetlistView.UseCompatibleStateImageBehavior = false;
			this.targetlistView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader51
			// 
			this.columnHeader51.Text = "";
			this.columnHeader51.Width = 1;
			// 
			// columnHeader36
			// 
			this.columnHeader36.Text = "Target ID";
			// 
			// columnHeader37
			// 
			this.columnHeader37.Text = "Body List";
			this.columnHeader37.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader37.Width = 80;
			// 
			// columnHeader38
			// 
			this.columnHeader38.Text = "Name";
			this.columnHeader38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// columnHeader39
			// 
			this.columnHeader39.Text = "Hue List";
			this.columnHeader39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader39.Width = 80;
			// 
			// columnHeader40
			// 
			this.columnHeader40.Text = "Min";
			this.columnHeader40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader40.Width = 32;
			// 
			// columnHeader41
			// 
			this.columnHeader41.Text = "Max";
			this.columnHeader41.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader41.Width = 32;
			// 
			// columnHeader42
			// 
			this.columnHeader42.Text = "P";
			this.columnHeader42.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader42.Width = 25;
			// 
			// columnHeader43
			// 
			this.columnHeader43.Text = "B";
			this.columnHeader43.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader43.Width = 25;
			// 
			// columnHeader44
			// 
			this.columnHeader44.Text = "H";
			this.columnHeader44.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader44.Width = 25;
			// 
			// columnHeader45
			// 
			this.columnHeader45.Text = "G";
			this.columnHeader45.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader45.Width = 25;
			// 
			// columnHeader46
			// 
			this.columnHeader46.Text = "S";
			this.columnHeader46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader46.Width = 25;
			// 
			// columnHeader47
			// 
			this.columnHeader47.Text = "W";
			this.columnHeader47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader47.Width = 25;
			// 
			// columnHeader48
			// 
			this.columnHeader48.Text = "F";
			this.columnHeader48.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader48.Width = 25;
			// 
			// columnHeader55
			// 
			this.columnHeader55.Text = "Pa";
			this.columnHeader55.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader55.Width = 25;
			// 
			// columnHeader49
			// 
			this.columnHeader49.Text = "Notorietie";
			this.columnHeader49.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// columnHeader50
			// 
			this.columnHeader50.Text = "Selector";
			this.columnHeader50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// skillsTab
			// 
			this.skillsTab.Controls.Add(this.dispDelta);
			this.skillsTab.Controls.Add(this.skillCopyAll);
			this.skillsTab.Controls.Add(this.skillCopySel);
			this.skillsTab.Controls.Add(this.baseTotal);
			this.skillsTab.Controls.Add(this.label1);
			this.skillsTab.Controls.Add(this.locks);
			this.skillsTab.Controls.Add(this.setlocks);
			this.skillsTab.Controls.Add(this.resetDelta);
			this.skillsTab.Controls.Add(this.skillList);
			this.skillsTab.Location = new System.Drawing.Point(4, 40);
			this.skillsTab.Name = "skillsTab";
			this.skillsTab.Size = new System.Drawing.Size(666, 366);
			this.skillsTab.TabIndex = 2;
			this.skillsTab.Text = "Skills";
			// 
			// dispDelta
			// 
			this.dispDelta.Location = new System.Drawing.Point(517, 144);
			this.dispDelta.Name = "dispDelta";
			this.dispDelta.Size = new System.Drawing.Size(113, 22);
			this.dispDelta.TabIndex = 11;
			this.dispDelta.Text = "Display Changes";
			this.dispDelta.CheckedChanged += new System.EventHandler(this.dispDelta_CheckedChanged);
			// 
			// skillCopyAll
			// 
			this.skillCopyAll.Location = new System.Drawing.Point(517, 109);
			this.skillCopyAll.Name = "skillCopyAll";
			this.skillCopyAll.Size = new System.Drawing.Size(131, 20);
			this.skillCopyAll.TabIndex = 9;
			this.skillCopyAll.Text = "Copy All";
			this.skillCopyAll.Click += new System.EventHandler(this.skillCopyAll_Click);
			// 
			// skillCopySel
			// 
			this.skillCopySel.Location = new System.Drawing.Point(517, 81);
			this.skillCopySel.Name = "skillCopySel";
			this.skillCopySel.Size = new System.Drawing.Size(131, 21);
			this.skillCopySel.TabIndex = 8;
			this.skillCopySel.Text = "Copy Selected";
			this.skillCopySel.Click += new System.EventHandler(this.skillCopySel_Click);
			// 
			// baseTotal
			// 
			this.baseTotal.Location = new System.Drawing.Point(586, 175);
			this.baseTotal.Name = "baseTotal";
			this.baseTotal.ReadOnly = true;
			this.baseTotal.Size = new System.Drawing.Size(44, 20);
			this.baseTotal.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(516, 179);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "Base Total:";
			// 
			// locks
			// 
			this.locks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.locks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.locks.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Locked"});
			this.locks.Location = new System.Drawing.Point(598, 45);
			this.locks.Name = "locks";
			this.locks.Size = new System.Drawing.Size(50, 23);
			this.locks.TabIndex = 5;
			// 
			// setlocks
			// 
			this.setlocks.Location = new System.Drawing.Point(517, 46);
			this.setlocks.Name = "setlocks";
			this.setlocks.Size = new System.Drawing.Size(76, 20);
			this.setlocks.TabIndex = 4;
			this.setlocks.Text = "Set all locks:";
			this.setlocks.Click += new System.EventHandler(this.OnSetSkillLocks);
			// 
			// resetDelta
			// 
			this.resetDelta.Location = new System.Drawing.Point(517, 13);
			this.resetDelta.Name = "resetDelta";
			this.resetDelta.Size = new System.Drawing.Size(131, 20);
			this.resetDelta.TabIndex = 3;
			this.resetDelta.Text = "Reset  +/-";
			this.resetDelta.Click += new System.EventHandler(this.OnResetSkillDelta);
			// 
			// skillList
			// 
			this.skillList.AutoArrange = false;
			this.skillList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.skillHDRName,
            this.skillHDRvalue,
            this.skillHDRbase,
            this.skillHDRdelta,
            this.skillHDRcap,
            this.skillHDRlock});
			this.skillList.FullRowSelect = true;
			this.skillList.Location = new System.Drawing.Point(7, 13);
			this.skillList.Name = "skillList";
			this.skillList.Size = new System.Drawing.Size(492, 345);
			this.skillList.TabIndex = 1;
			this.skillList.UseCompatibleStateImageBehavior = false;
			this.skillList.View = System.Windows.Forms.View.Details;
			this.skillList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnSkillColClick);
			this.skillList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.skillList_MouseDown);
			// 
			// skillHDRName
			// 
			this.skillHDRName.Text = "Skill Name";
			this.skillHDRName.Width = 180;
			// 
			// skillHDRvalue
			// 
			this.skillHDRvalue.Text = "Value";
			// 
			// skillHDRbase
			// 
			this.skillHDRbase.Text = "Base";
			this.skillHDRbase.Width = 50;
			// 
			// skillHDRdelta
			// 
			this.skillHDRdelta.Text = "+/-";
			this.skillHDRdelta.Width = 40;
			// 
			// skillHDRcap
			// 
			this.skillHDRcap.Text = "Cap";
			this.skillHDRcap.Width = 40;
			// 
			// skillHDRlock
			// 
			this.skillHDRlock.Text = "Lock";
			this.skillHDRlock.Width = 55;
			// 
			// screenshotTab
			// 
			this.screenshotTab.Controls.Add(this.imgFmt);
			this.screenshotTab.Controls.Add(this.label12);
			this.screenshotTab.Controls.Add(this.capNow);
			this.screenshotTab.Controls.Add(this.screenPath);
			this.screenshotTab.Controls.Add(this.radioUO);
			this.screenshotTab.Controls.Add(this.radioFull);
			this.screenshotTab.Controls.Add(this.screenAutoCap);
			this.screenshotTab.Controls.Add(this.setScnPath);
			this.screenshotTab.Controls.Add(this.screensList);
			this.screenshotTab.Controls.Add(this.screenPrev);
			this.screenshotTab.Controls.Add(this.dispTime);
			this.screenshotTab.Location = new System.Drawing.Point(4, 40);
			this.screenshotTab.Name = "screenshotTab";
			this.screenshotTab.Size = new System.Drawing.Size(666, 366);
			this.screenshotTab.TabIndex = 8;
			this.screenshotTab.Text = "Screen Shots";
			// 
			// imgFmt
			// 
			this.imgFmt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.imgFmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.imgFmt.Items.AddRange(new object[] {
            "jpg",
            "png",
            "bmp",
            "gif",
            "tif",
            "wmf",
            "exif",
            "emf"});
			this.imgFmt.Location = new System.Drawing.Point(94, 202);
			this.imgFmt.Name = "imgFmt";
			this.imgFmt.Size = new System.Drawing.Size(71, 23);
			this.imgFmt.TabIndex = 11;
			this.imgFmt.SelectedIndexChanged += new System.EventHandler(this.imgFmt_SelectedIndexChanged);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 205);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(80, 20);
			this.label12.TabIndex = 10;
			this.label12.Text = "Image Format:";
			// 
			// capNow
			// 
			this.capNow.Location = new System.Drawing.Point(314, 14);
			this.capNow.Name = "capNow";
			this.capNow.Size = new System.Drawing.Size(285, 20);
			this.capNow.TabIndex = 8;
			this.capNow.Text = "Take Screen Shot Now";
			this.capNow.Click += new System.EventHandler(this.capNow_Click);
			// 
			// screenPath
			// 
			this.screenPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.screenPath.BackColor = System.Drawing.Color.White;
			this.screenPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.screenPath.Location = new System.Drawing.Point(7, 14);
			this.screenPath.Name = "screenPath";
			this.screenPath.Size = new System.Drawing.Size(196, 20);
			this.screenPath.TabIndex = 7;
			this.screenPath.TextChanged += new System.EventHandler(this.screenPath_TextChanged);
			// 
			// radioUO
			// 
			this.radioUO.Location = new System.Drawing.Point(11, 228);
			this.radioUO.Name = "radioUO";
			this.radioUO.Size = new System.Drawing.Size(87, 20);
			this.radioUO.TabIndex = 6;
			this.radioUO.Text = "UO Only";
			this.radioUO.CheckedChanged += new System.EventHandler(this.radioUO_CheckedChanged);
			// 
			// radioFull
			// 
			this.radioFull.Location = new System.Drawing.Point(102, 228);
			this.radioFull.Name = "radioFull";
			this.radioFull.Size = new System.Drawing.Size(89, 20);
			this.radioFull.TabIndex = 5;
			this.radioFull.Text = "Full Screen";
			this.radioFull.CheckedChanged += new System.EventHandler(this.radioFull_CheckedChanged);
			// 
			// screenAutoCap
			// 
			this.screenAutoCap.Location = new System.Drawing.Point(11, 284);
			this.screenAutoCap.Name = "screenAutoCap";
			this.screenAutoCap.Size = new System.Drawing.Size(180, 22);
			this.screenAutoCap.TabIndex = 4;
			this.screenAutoCap.Text = "Auto Death Screen Capture";
			this.screenAutoCap.CheckedChanged += new System.EventHandler(this.screenAutoCap_CheckedChanged);
			// 
			// setScnPath
			// 
			this.setScnPath.Location = new System.Drawing.Point(208, 16);
			this.setScnPath.Name = "setScnPath";
			this.setScnPath.Size = new System.Drawing.Size(22, 17);
			this.setScnPath.TabIndex = 3;
			this.setScnPath.Text = "...";
			this.setScnPath.Click += new System.EventHandler(this.setScnPath_Click);
			// 
			// screensList
			// 
			this.screensList.IntegralHeight = false;
			this.screensList.Location = new System.Drawing.Point(7, 40);
			this.screensList.Name = "screensList";
			this.screensList.Size = new System.Drawing.Size(223, 147);
			this.screensList.Sorted = true;
			this.screensList.TabIndex = 1;
			this.screensList.SelectedIndexChanged += new System.EventHandler(this.screensList_SelectedIndexChanged);
			this.screensList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.screensList_MouseDown);
			// 
			// screenPrev
			// 
			this.screenPrev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.screenPrev.Location = new System.Drawing.Point(246, 36);
			this.screenPrev.Name = "screenPrev";
			this.screenPrev.Size = new System.Drawing.Size(412, 322);
			this.screenPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.screenPrev.TabIndex = 0;
			this.screenPrev.TabStop = false;
			this.screenPrev.Click += new System.EventHandler(this.screenPrev_Click);
			// 
			// dispTime
			// 
			this.dispTime.Location = new System.Drawing.Point(11, 256);
			this.dispTime.Name = "dispTime";
			this.dispTime.Size = new System.Drawing.Size(180, 22);
			this.dispTime.TabIndex = 9;
			this.dispTime.Text = "Include Timestamp on images";
			this.dispTime.CheckedChanged += new System.EventHandler(this.dispTime_CheckedChanged);
			// 
			// statusTab
			// 
			this.statusTab.Controls.Add(this.discordrazorButton);
			this.statusTab.Controls.Add(this.labelHotride);
			this.statusTab.Controls.Add(this.panelLogo);
			this.statusTab.Controls.Add(this.labelUOD);
			this.statusTab.Controls.Add(this.panelUODlogo);
			this.statusTab.Controls.Add(this.labelStatus);
			this.statusTab.Controls.Add(this.razorButtonWiki);
			this.statusTab.Controls.Add(this.razorButtonCreateUODAccount);
			this.statusTab.Controls.Add(this.razorButtonVisitUOD);
			this.statusTab.Location = new System.Drawing.Point(4, 40);
			this.statusTab.Name = "statusTab";
			this.statusTab.Size = new System.Drawing.Size(666, 366);
			this.statusTab.TabIndex = 9;
			this.statusTab.Text = "Help / Status";
			// 
			// discordrazorButton
			// 
			this.discordrazorButton.Location = new System.Drawing.Point(304, 198);
			this.discordrazorButton.Name = "discordrazorButton";
			this.discordrazorButton.Size = new System.Drawing.Size(145, 28);
			this.discordrazorButton.TabIndex = 9;
			this.discordrazorButton.Text = "Razor Enhanced Discord";
			this.discordrazorButton.UseVisualStyleBackColor = true;
			this.discordrazorButton.Click += new System.EventHandler(this.discordrazorButton_Click);
			// 
			// labelHotride
			// 
			this.labelHotride.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHotride.Location = new System.Drawing.Point(8, 291);
			this.labelHotride.Name = "labelHotride";
			this.labelHotride.Size = new System.Drawing.Size(650, 38);
			this.labelHotride.TabIndex = 8;
			this.labelHotride.Text = "Many thanks to Hotride for his  FPS multiclient patch! Hotride is the author of O" +
    "penGL OrionUO Client project (you can point your browser to the link http://foru" +
    "m.orion-client.online for more info)";
			// 
			// panelLogo
			// 
			this.panelLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogo.BackgroundImage")));
			this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.panelLogo.Location = new System.Drawing.Point(250, 171);
			this.panelLogo.Name = "panelLogo";
			this.panelLogo.Size = new System.Drawing.Size(48, 49);
			this.panelLogo.TabIndex = 7;
			// 
			// labelUOD
			// 
			this.labelUOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUOD.Location = new System.Drawing.Point(8, 175);
			this.labelUOD.Name = "labelUOD";
			this.labelUOD.Size = new System.Drawing.Size(213, 64);
			this.labelUOD.TabIndex = 4;
			this.labelUOD.Text = "To support the Razor Enhanced developers,  please visit UODreams shard and stay w" +
    "ith us! You are welcome!";
			this.labelUOD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelUODlogo
			// 
			this.panelUODlogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelUODlogo.BackgroundImage")));
			this.panelUODlogo.Location = new System.Drawing.Point(8, 9);
			this.panelUODlogo.Name = "panelUODlogo";
			this.panelUODlogo.Size = new System.Drawing.Size(213, 163);
			this.panelUODlogo.TabIndex = 2;
			// 
			// labelStatus
			// 
			this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelStatus.Location = new System.Drawing.Point(483, 9);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(175, 268);
			this.labelStatus.TabIndex = 1;
			// 
			// razorButtonWiki
			// 
			this.razorButtonWiki.Location = new System.Drawing.Point(304, 164);
			this.razorButtonWiki.Name = "razorButtonWiki";
			this.razorButtonWiki.Size = new System.Drawing.Size(145, 28);
			this.razorButtonWiki.TabIndex = 6;
			this.razorButtonWiki.Text = "Razor Enhanced wiki";
			this.razorButtonWiki.UseVisualStyleBackColor = true;
			this.razorButtonWiki.Click += new System.EventHandler(this.razorButtonWiki_Click);
			// 
			// razorButtonCreateUODAccount
			// 
			this.razorButtonCreateUODAccount.Location = new System.Drawing.Point(250, 60);
			this.razorButtonCreateUODAccount.Name = "razorButtonCreateUODAccount";
			this.razorButtonCreateUODAccount.Size = new System.Drawing.Size(199, 28);
			this.razorButtonCreateUODAccount.TabIndex = 5;
			this.razorButtonCreateUODAccount.Text = "create your UOD account";
			this.razorButtonCreateUODAccount.UseVisualStyleBackColor = true;
			this.razorButtonCreateUODAccount.Click += new System.EventHandler(this.razorButtonCreateUODAccount_Click);
			// 
			// razorButtonVisitUOD
			// 
			this.razorButtonVisitUOD.Location = new System.Drawing.Point(250, 26);
			this.razorButtonVisitUOD.Name = "razorButtonVisitUOD";
			this.razorButtonVisitUOD.Size = new System.Drawing.Size(199, 28);
			this.razorButtonVisitUOD.TabIndex = 3;
			this.razorButtonVisitUOD.Text = "visit www.uodreams.com";
			this.razorButtonVisitUOD.UseVisualStyleBackColor = true;
			this.razorButtonVisitUOD.Click += new System.EventHandler(this.razorButtonVisitUOD_Click);
			// 
			// scriptingTab
			// 
			this.scriptingTab.BackColor = System.Drawing.SystemColors.Control;
			this.scriptingTab.Controls.Add(this.groupBox31);
			this.scriptingTab.Controls.Add(this.groupBox30);
			this.scriptingTab.Controls.Add(this.scriptlistView);
			this.scriptingTab.Location = new System.Drawing.Point(4, 40);
			this.scriptingTab.Name = "scriptingTab";
			this.scriptingTab.Padding = new System.Windows.Forms.Padding(3);
			this.scriptingTab.Size = new System.Drawing.Size(666, 366);
			this.scriptingTab.TabIndex = 12;
			this.scriptingTab.Text = "Enhanced Scripting";
			// 
			// groupBox31
			// 
			this.groupBox31.Controls.Add(this.buttonScriptRefresh);
			this.groupBox31.Controls.Add(this.showscriptmessageCheckBox);
			this.groupBox31.Controls.Add(this.buttonAddScript);
			this.groupBox31.Controls.Add(this.buttonRemoveScript);
			this.groupBox31.Controls.Add(this.buttonScriptDown);
			this.groupBox31.Controls.Add(this.labelTimerDelay);
			this.groupBox31.Controls.Add(this.textBoxDelay);
			this.groupBox31.Controls.Add(this.buttonScriptUp);
			this.groupBox31.Controls.Add(this.buttonScriptEditor);
			this.groupBox31.Controls.Add(this.buttonScriptStop);
			this.groupBox31.Controls.Add(this.buttonScriptPlay);
			this.groupBox31.Location = new System.Drawing.Point(482, 112);
			this.groupBox31.Name = "groupBox31";
			this.groupBox31.Size = new System.Drawing.Size(175, 246);
			this.groupBox31.TabIndex = 50;
			this.groupBox31.TabStop = false;
			this.groupBox31.Text = "Script Operation";
			// 
			// buttonScriptRefresh
			// 
			this.buttonScriptRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonScriptRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonScriptRefresh.Image")));
			this.buttonScriptRefresh.Location = new System.Drawing.Point(53, 130);
			this.buttonScriptRefresh.Name = "buttonScriptRefresh";
			this.buttonScriptRefresh.Size = new System.Drawing.Size(73, 27);
			this.buttonScriptRefresh.TabIndex = 73;
			this.buttonScriptRefresh.Text = "Refresh";
			this.buttonScriptRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonScriptRefresh.UseVisualStyleBackColor = true;
			this.buttonScriptRefresh.Click += new System.EventHandler(this.buttonScriptRefresh_Click);
			// 
			// showscriptmessageCheckBox
			// 
			this.showscriptmessageCheckBox.Location = new System.Drawing.Point(7, 222);
			this.showscriptmessageCheckBox.Name = "showscriptmessageCheckBox";
			this.showscriptmessageCheckBox.Size = new System.Drawing.Size(160, 22);
			this.showscriptmessageCheckBox.TabIndex = 72;
			this.showscriptmessageCheckBox.Text = "Show Script Message";
			this.showscriptmessageCheckBox.CheckedChanged += new System.EventHandler(this.showscriptmessageCheckBox_CheckedChanged);
			// 
			// buttonAddScript
			// 
			this.buttonAddScript.Location = new System.Drawing.Point(7, 19);
			this.buttonAddScript.Name = "buttonAddScript";
			this.buttonAddScript.Size = new System.Drawing.Size(75, 21);
			this.buttonAddScript.TabIndex = 14;
			this.buttonAddScript.Text = "Add";
			this.buttonAddScript.Click += new System.EventHandler(this.buttonScriptAdd_Click);
			// 
			// buttonRemoveScript
			// 
			this.buttonRemoveScript.Location = new System.Drawing.Point(94, 19);
			this.buttonRemoveScript.Name = "buttonRemoveScript";
			this.buttonRemoveScript.Size = new System.Drawing.Size(75, 21);
			this.buttonRemoveScript.TabIndex = 15;
			this.buttonRemoveScript.Text = "Remove";
			this.buttonRemoveScript.Click += new System.EventHandler(this.buttonScriptRemove_Click);
			// 
			// buttonScriptDown
			// 
			this.buttonScriptDown.Location = new System.Drawing.Point(7, 45);
			this.buttonScriptDown.Name = "buttonScriptDown";
			this.buttonScriptDown.Size = new System.Drawing.Size(75, 21);
			this.buttonScriptDown.TabIndex = 17;
			this.buttonScriptDown.Text = "Move Down";
			this.buttonScriptDown.UseVisualStyleBackColor = true;
			this.buttonScriptDown.Click += new System.EventHandler(this.buttonScriptDown_Click);
			// 
			// labelTimerDelay
			// 
			this.labelTimerDelay.AutoSize = true;
			this.labelTimerDelay.Location = new System.Drawing.Point(6, 202);
			this.labelTimerDelay.Name = "labelTimerDelay";
			this.labelTimerDelay.Size = new System.Drawing.Size(92, 13);
			this.labelTimerDelay.TabIndex = 24;
			this.labelTimerDelay.Text = "Engine Delay (ms)";
			// 
			// textBoxDelay
			// 
			this.textBoxDelay.Location = new System.Drawing.Point(104, 199);
			this.textBoxDelay.Name = "textBoxDelay";
			this.textBoxDelay.Size = new System.Drawing.Size(42, 20);
			this.textBoxDelay.TabIndex = 23;
			this.textBoxDelay.Text = "100";
			this.textBoxDelay.TextChanged += new System.EventHandler(this.textBoxEngineDelay_TextChanged);
			// 
			// buttonScriptUp
			// 
			this.buttonScriptUp.Location = new System.Drawing.Point(94, 45);
			this.buttonScriptUp.Name = "buttonScriptUp";
			this.buttonScriptUp.Size = new System.Drawing.Size(75, 21);
			this.buttonScriptUp.TabIndex = 18;
			this.buttonScriptUp.Text = "Move Up";
			this.buttonScriptUp.UseVisualStyleBackColor = true;
			this.buttonScriptUp.Click += new System.EventHandler(this.buttonScriptUp_Click);
			// 
			// buttonScriptEditor
			// 
			this.buttonScriptEditor.Location = new System.Drawing.Point(7, 71);
			this.buttonScriptEditor.Name = "buttonScriptEditor";
			this.buttonScriptEditor.Size = new System.Drawing.Size(162, 21);
			this.buttonScriptEditor.TabIndex = 20;
			this.buttonScriptEditor.Text = "Open Editor";
			this.buttonScriptEditor.UseVisualStyleBackColor = true;
			this.buttonScriptEditor.Click += new System.EventHandler(this.buttonOpenEditor_Click);
			// 
			// buttonScriptStop
			// 
			this.buttonScriptStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonScriptStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonScriptStop.Image")));
			this.buttonScriptStop.Location = new System.Drawing.Point(53, 163);
			this.buttonScriptStop.Name = "buttonScriptStop";
			this.buttonScriptStop.Size = new System.Drawing.Size(73, 27);
			this.buttonScriptStop.TabIndex = 22;
			this.buttonScriptStop.Text = "Stop";
			this.buttonScriptStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonScriptStop.UseVisualStyleBackColor = true;
			this.buttonScriptStop.Click += new System.EventHandler(this.buttonScriptStop_Click);
			// 
			// buttonScriptPlay
			// 
			this.buttonScriptPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonScriptPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonScriptPlay.Image")));
			this.buttonScriptPlay.Location = new System.Drawing.Point(53, 97);
			this.buttonScriptPlay.Name = "buttonScriptPlay";
			this.buttonScriptPlay.Size = new System.Drawing.Size(73, 27);
			this.buttonScriptPlay.TabIndex = 21;
			this.buttonScriptPlay.Text = "Play";
			this.buttonScriptPlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonScriptPlay.UseVisualStyleBackColor = true;
			this.buttonScriptPlay.Click += new System.EventHandler(this.buttonScriptPlay_Click);
			// 
			// groupBox30
			// 
			this.groupBox30.Controls.Add(this.scriptautostartcheckbox);
			this.groupBox30.Controls.Add(this.scriptwaitmodecheckbox);
			this.groupBox30.Controls.Add(this.scriptloopmodecheckbox);
			this.groupBox30.Controls.Add(this.scriptfilelabel);
			this.groupBox30.Location = new System.Drawing.Point(482, 6);
			this.groupBox30.Name = "groupBox30";
			this.groupBox30.Size = new System.Drawing.Size(175, 100);
			this.groupBox30.TabIndex = 49;
			this.groupBox30.TabStop = false;
			this.groupBox30.Text = "Script Info";
			// 
			// scriptautostartcheckbox
			// 
			this.scriptautostartcheckbox.Location = new System.Drawing.Point(6, 76);
			this.scriptautostartcheckbox.Name = "scriptautostartcheckbox";
			this.scriptautostartcheckbox.Size = new System.Drawing.Size(138, 22);
			this.scriptautostartcheckbox.TabIndex = 51;
			this.scriptautostartcheckbox.Text = "AutoStart at Login";
			this.scriptautostartcheckbox.CheckedChanged += new System.EventHandler(this.scriptautostartcheckbox_CheckedChanged);
			// 
			// scriptwaitmodecheckbox
			// 
			this.scriptwaitmodecheckbox.Location = new System.Drawing.Point(6, 56);
			this.scriptwaitmodecheckbox.Name = "scriptwaitmodecheckbox";
			this.scriptwaitmodecheckbox.Size = new System.Drawing.Size(138, 22);
			this.scriptwaitmodecheckbox.TabIndex = 50;
			this.scriptwaitmodecheckbox.Text = "Wait before interrupt";
			this.scriptwaitmodecheckbox.CheckedChanged += new System.EventHandler(this.scriptwaitmodecheckbox_CheckedChanged);
			// 
			// scriptloopmodecheckbox
			// 
			this.scriptloopmodecheckbox.Location = new System.Drawing.Point(6, 36);
			this.scriptloopmodecheckbox.Name = "scriptloopmodecheckbox";
			this.scriptloopmodecheckbox.Size = new System.Drawing.Size(103, 22);
			this.scriptloopmodecheckbox.TabIndex = 49;
			this.scriptloopmodecheckbox.Text = "Loop Mode";
			this.scriptloopmodecheckbox.CheckedChanged += new System.EventHandler(this.scriptloopmodecheckbox_CheckedChanged);
			// 
			// scriptfilelabel
			// 
			this.scriptfilelabel.AutoSize = true;
			this.scriptfilelabel.Location = new System.Drawing.Point(4, 20);
			this.scriptfilelabel.Name = "scriptfilelabel";
			this.scriptfilelabel.Size = new System.Drawing.Size(29, 13);
			this.scriptfilelabel.TabIndex = 0;
			this.scriptfilelabel.Text = "File: ";
			// 
			// scriptlistView
			// 
			this.scriptlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader62,
            this.filename,
            this.status,
            this.loop,
            this.autostart,
            this.wait,
            this.hotkey,
            this.heypass});
			this.scriptlistView.FullRowSelect = true;
			this.scriptlistView.GridLines = true;
			this.scriptlistView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.scriptlistView.HideSelection = false;
			this.scriptlistView.LabelWrap = false;
			this.scriptlistView.Location = new System.Drawing.Point(8, 6);
			this.scriptlistView.MultiSelect = false;
			this.scriptlistView.Name = "scriptlistView";
			this.scriptlistView.Size = new System.Drawing.Size(468, 354);
			this.scriptlistView.TabIndex = 48;
			this.scriptlistView.UseCompatibleStateImageBehavior = false;
			this.scriptlistView.View = System.Windows.Forms.View.Details;
			this.scriptlistView.SelectedIndexChanged += new System.EventHandler(this.scriptlistView_SelectedIndexChanged);
			// 
			// columnHeader62
			// 
			this.columnHeader62.Text = "";
			this.columnHeader62.Width = 0;
			// 
			// filename
			// 
			this.filename.Text = "Filename";
			this.filename.Width = 150;
			// 
			// status
			// 
			this.status.Text = "Status";
			this.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.status.Width = 67;
			// 
			// loop
			// 
			this.loop.Text = "Loop";
			this.loop.Width = 37;
			// 
			// autostart
			// 
			this.autostart.DisplayIndex = 5;
			this.autostart.Text = "A.S.";
			this.autostart.Width = 37;
			// 
			// wait
			// 
			this.wait.DisplayIndex = 4;
			this.wait.Text = "Wait";
			this.wait.Width = 37;
			// 
			// hotkey
			// 
			this.hotkey.Text = "HotKey";
			this.hotkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.hotkey.Width = 80;
			// 
			// heypass
			// 
			this.heypass.Text = "KeyPass";
			this.heypass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// EnhancedAgent
			// 
			this.EnhancedAgent.Controls.Add(this.tabControl1);
			this.EnhancedAgent.Location = new System.Drawing.Point(4, 40);
			this.EnhancedAgent.Name = "EnhancedAgent";
			this.EnhancedAgent.Padding = new System.Windows.Forms.Padding(3);
			this.EnhancedAgent.Size = new System.Drawing.Size(666, 366);
			this.EnhancedAgent.TabIndex = 14;
			this.EnhancedAgent.Text = "Enhanced Agents";
			this.EnhancedAgent.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.eautoloot);
			this.tabControl1.Controls.Add(this.escavenger);
			this.tabControl1.Controls.Add(this.organizer);
			this.tabControl1.Controls.Add(this.VendorBuy);
			this.tabControl1.Controls.Add(this.VendorSell);
			this.tabControl1.Controls.Add(this.Dress);
			this.tabControl1.Controls.Add(this.friends);
			this.tabControl1.Controls.Add(this.restock);
			this.tabControl1.Controls.Add(this.bandageheal);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(667, 367);
			this.tabControl1.TabIndex = 0;
			// 
			// eautoloot
			// 
			this.eautoloot.Controls.Add(this.label60);
			this.eautoloot.Controls.Add(this.autoLootTextBoxMaxRange);
			this.eautoloot.Controls.Add(this.autolootItemPropsB);
			this.eautoloot.Controls.Add(this.groupBox14);
			this.eautoloot.Controls.Add(this.autolootAddItemBTarget);
			this.eautoloot.Controls.Add(this.autolootdataGridView);
			this.eautoloot.Controls.Add(this.autoLootnoopenCheckBox);
			this.eautoloot.Controls.Add(this.label21);
			this.eautoloot.Controls.Add(this.autoLootTextBoxDelay);
			this.eautoloot.Controls.Add(this.autoLootButtonRemoveList);
			this.eautoloot.Controls.Add(this.autolootButtonAddList);
			this.eautoloot.Controls.Add(this.autoLootButtonListImport);
			this.eautoloot.Controls.Add(this.autolootListSelect);
			this.eautoloot.Controls.Add(this.autoLootButtonListExport);
			this.eautoloot.Controls.Add(this.label20);
			this.eautoloot.Controls.Add(this.groupBox13);
			this.eautoloot.Controls.Add(this.autoLootCheckBox);
			this.eautoloot.Location = new System.Drawing.Point(4, 22);
			this.eautoloot.Name = "eautoloot";
			this.eautoloot.Padding = new System.Windows.Forms.Padding(3);
			this.eautoloot.Size = new System.Drawing.Size(659, 341);
			this.eautoloot.TabIndex = 0;
			this.eautoloot.Text = "Autoloot";
			this.eautoloot.UseVisualStyleBackColor = true;
			// 
			// label60
			// 
			this.label60.AutoSize = true;
			this.label60.Location = new System.Drawing.Point(464, 68);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(62, 13);
			this.label60.TabIndex = 65;
			this.label60.Text = "Max Range";
			// 
			// autoLootTextBoxMaxRange
			// 
			this.autoLootTextBoxMaxRange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.autoLootTextBoxMaxRange.BackColor = System.Drawing.Color.White;
			this.autoLootTextBoxMaxRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.autoLootTextBoxMaxRange.Location = new System.Drawing.Point(411, 65);
			this.autoLootTextBoxMaxRange.Name = "autoLootTextBoxMaxRange";
			this.autoLootTextBoxMaxRange.Size = new System.Drawing.Size(45, 20);
			this.autoLootTextBoxMaxRange.TabIndex = 64;
			this.autoLootTextBoxMaxRange.TextChanged += new System.EventHandler(this.autoLootTextBoxMaxRange_TextChanged);
			// 
			// autolootItemPropsB
			// 
			this.autolootItemPropsB.Location = new System.Drawing.Point(558, 66);
			this.autolootItemPropsB.Name = "autolootItemPropsB";
			this.autolootItemPropsB.Size = new System.Drawing.Size(90, 21);
			this.autolootItemPropsB.TabIndex = 49;
			this.autolootItemPropsB.Text = "Edit Props";
			this.autolootItemPropsB.Click += new System.EventHandler(this.autoLootItemProps_Click);
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.label55);
			this.groupBox14.Controls.Add(this.autolootContainerLabel);
			this.groupBox14.Controls.Add(this.autolootContainerButton);
			this.groupBox14.Location = new System.Drawing.Point(9, 42);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(252, 47);
			this.groupBox14.TabIndex = 63;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "AutoLoot Bag";
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(6, 21);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(36, 13);
			this.label55.TabIndex = 90;
			this.label55.Text = "Serial:";
			// 
			// autolootContainerLabel
			// 
			this.autolootContainerLabel.Location = new System.Drawing.Point(48, 21);
			this.autolootContainerLabel.Name = "autolootContainerLabel";
			this.autolootContainerLabel.Size = new System.Drawing.Size(82, 19);
			this.autolootContainerLabel.TabIndex = 50;
			this.autolootContainerLabel.Text = "0x00000000";
			// 
			// autolootContainerButton
			// 
			this.autolootContainerButton.Location = new System.Drawing.Point(157, 16);
			this.autolootContainerButton.Name = "autolootContainerButton";
			this.autolootContainerButton.Size = new System.Drawing.Size(89, 21);
			this.autolootContainerButton.TabIndex = 49;
			this.autolootContainerButton.Text = "Set Bag";
			this.autolootContainerButton.Click += new System.EventHandler(this.autolootContainerButton_Click);
			// 
			// autolootAddItemBTarget
			// 
			this.autolootAddItemBTarget.Location = new System.Drawing.Point(558, 39);
			this.autolootAddItemBTarget.Name = "autolootAddItemBTarget";
			this.autolootAddItemBTarget.Size = new System.Drawing.Size(90, 21);
			this.autolootAddItemBTarget.TabIndex = 47;
			this.autolootAddItemBTarget.Text = "Add Item";
			this.autolootAddItemBTarget.Click += new System.EventHandler(this.autoLootAddItemTarget_Click);
			// 
			// autolootdataGridView
			// 
			this.autolootdataGridView.AllowDrop = true;
			this.autolootdataGridView.AllowUserToResizeRows = false;
			this.autolootdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.autolootdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AutolootColumnX,
            this.AutolootColumnItemName,
            this.AutolootColumnItemID,
            this.AutolootColumnColor,
            this.AutolootColumnProps});
			this.autolootdataGridView.Location = new System.Drawing.Point(9, 95);
			this.autolootdataGridView.Name = "autolootdataGridView";
			this.autolootdataGridView.RowHeadersVisible = false;
			this.autolootdataGridView.Size = new System.Drawing.Size(356, 238);
			this.autolootdataGridView.TabIndex = 62;
			this.autolootdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
			this.autolootdataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.autolootdataGridView_CellEndEdit);
			this.autolootdataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_CellMouseUp);
			this.autolootdataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.GridView_CurrentCellDirtyStateChanged);
			this.autolootdataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridView_DataError);
			this.autolootdataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.autolootdataGridView_DefaultValuesNeeded);
			this.autolootdataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridView_DragDrop);
			this.autolootdataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.GridView_DragOver);
			this.autolootdataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseDown);
			this.autolootdataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseMove);
			// 
			// AutolootColumnX
			// 
			this.AutolootColumnX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.AutolootColumnX.FalseValue = "False";
			this.AutolootColumnX.HeaderText = "X";
			this.AutolootColumnX.IndeterminateValue = "False";
			this.AutolootColumnX.Name = "AutolootColumnX";
			this.AutolootColumnX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.AutolootColumnX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.AutolootColumnX.TrueValue = "True";
			this.AutolootColumnX.Width = 22;
			// 
			// AutolootColumnItemName
			// 
			this.AutolootColumnItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.AutolootColumnItemName.HeaderText = "Item Name";
			this.AutolootColumnItemName.Name = "AutolootColumnItemName";
			this.AutolootColumnItemName.Width = 206;
			// 
			// AutolootColumnItemID
			// 
			this.AutolootColumnItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.AutolootColumnItemID.HeaderText = "Graphics";
			this.AutolootColumnItemID.Name = "AutolootColumnItemID";
			this.AutolootColumnItemID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.AutolootColumnItemID.Width = 54;
			// 
			// AutolootColumnColor
			// 
			this.AutolootColumnColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.AutolootColumnColor.HeaderText = "Color";
			this.AutolootColumnColor.Name = "AutolootColumnColor";
			this.AutolootColumnColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.AutolootColumnColor.Width = 54;
			// 
			// AutolootColumnProps
			// 
			this.AutolootColumnProps.HeaderText = "Props";
			this.AutolootColumnProps.Name = "AutolootColumnProps";
			this.AutolootColumnProps.Visible = false;
			// 
			// autoLootnoopenCheckBox
			// 
			this.autoLootnoopenCheckBox.Location = new System.Drawing.Point(275, 65);
			this.autoLootnoopenCheckBox.Name = "autoLootnoopenCheckBox";
			this.autoLootnoopenCheckBox.Size = new System.Drawing.Size(126, 22);
			this.autoLootnoopenCheckBox.TabIndex = 61;
			this.autoLootnoopenCheckBox.Text = "No Open Corpse";
			this.autoLootnoopenCheckBox.CheckedChanged += new System.EventHandler(this.autoLootnoopenCheckBox_CheckedChanged);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(464, 44);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(56, 13);
			this.label21.TabIndex = 59;
			this.label21.Text = "Delay (ms)";
			// 
			// autoLootTextBoxDelay
			// 
			this.autoLootTextBoxDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.autoLootTextBoxDelay.BackColor = System.Drawing.Color.White;
			this.autoLootTextBoxDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.autoLootTextBoxDelay.Location = new System.Drawing.Point(411, 41);
			this.autoLootTextBoxDelay.Name = "autoLootTextBoxDelay";
			this.autoLootTextBoxDelay.Size = new System.Drawing.Size(45, 20);
			this.autoLootTextBoxDelay.TabIndex = 58;
			this.autoLootTextBoxDelay.TextChanged += new System.EventHandler(this.autoLootTextBoxDelay_TextChanged);
			// 
			// autoLootButtonRemoveList
			// 
			this.autoLootButtonRemoveList.Location = new System.Drawing.Point(366, 12);
			this.autoLootButtonRemoveList.Name = "autoLootButtonRemoveList";
			this.autoLootButtonRemoveList.Size = new System.Drawing.Size(90, 21);
			this.autoLootButtonRemoveList.TabIndex = 57;
			this.autoLootButtonRemoveList.Text = "Remove";
			this.autoLootButtonRemoveList.Click += new System.EventHandler(this.autoLootButtonRemoveList_Click);
			// 
			// autolootButtonAddList
			// 
			this.autolootButtonAddList.Location = new System.Drawing.Point(270, 12);
			this.autolootButtonAddList.Name = "autolootButtonAddList";
			this.autolootButtonAddList.Size = new System.Drawing.Size(90, 21);
			this.autolootButtonAddList.TabIndex = 56;
			this.autolootButtonAddList.Text = "Add";
			this.autolootButtonAddList.Click += new System.EventHandler(this.autoLootButtonAddList_Click);
			// 
			// autoLootButtonListImport
			// 
			this.autoLootButtonListImport.Location = new System.Drawing.Point(462, 12);
			this.autoLootButtonListImport.Name = "autoLootButtonListImport";
			this.autoLootButtonListImport.Size = new System.Drawing.Size(90, 21);
			this.autoLootButtonListImport.TabIndex = 49;
			this.autoLootButtonListImport.Text = "Import";
			this.autoLootButtonListImport.Click += new System.EventHandler(this.autoLootImport_Click);
			// 
			// autolootListSelect
			// 
			this.autolootListSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.autolootListSelect.FormattingEnabled = true;
			this.autolootListSelect.Location = new System.Drawing.Point(78, 12);
			this.autolootListSelect.Name = "autolootListSelect";
			this.autolootListSelect.Size = new System.Drawing.Size(183, 21);
			this.autolootListSelect.TabIndex = 55;
			this.autolootListSelect.SelectedIndexChanged += new System.EventHandler(this.autoLootListSelect_SelectedIndexChanged);
			// 
			// autoLootButtonListExport
			// 
			this.autoLootButtonListExport.Location = new System.Drawing.Point(558, 12);
			this.autoLootButtonListExport.Name = "autoLootButtonListExport";
			this.autoLootButtonListExport.Size = new System.Drawing.Size(90, 21);
			this.autoLootButtonListExport.TabIndex = 48;
			this.autoLootButtonListExport.Text = "Export";
			this.autoLootButtonListExport.Click += new System.EventHandler(this.autoLootButtonListExport_Click);
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(6, 18);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(68, 13);
			this.label20.TabIndex = 54;
			this.label20.Text = "Autoloot List:";
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.autolootLogBox);
			this.groupBox13.Location = new System.Drawing.Point(371, 94);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(278, 239);
			this.groupBox13.TabIndex = 53;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Autoloot Log";
			// 
			// autolootLogBox
			// 
			this.autolootLogBox.FormattingEnabled = true;
			this.autolootLogBox.Location = new System.Drawing.Point(7, 18);
			this.autolootLogBox.Name = "autolootLogBox";
			this.autolootLogBox.Size = new System.Drawing.Size(265, 212);
			this.autolootLogBox.TabIndex = 0;
			// 
			// autoLootCheckBox
			// 
			this.autoLootCheckBox.Location = new System.Drawing.Point(275, 42);
			this.autoLootCheckBox.Name = "autoLootCheckBox";
			this.autoLootCheckBox.Size = new System.Drawing.Size(126, 22);
			this.autoLootCheckBox.TabIndex = 48;
			this.autoLootCheckBox.Text = "Enable autoloot";
			this.autoLootCheckBox.CheckedChanged += new System.EventHandler(this.autoLootEnable_CheckedChanged);
			// 
			// escavenger
			// 
			this.escavenger.Controls.Add(this.label61);
			this.escavenger.Controls.Add(this.groupBox41);
			this.escavenger.Controls.Add(this.scavengerdataGridView);
			this.escavenger.Controls.Add(this.groupBox12);
			this.escavenger.Controls.Add(this.label23);
			this.escavenger.Controls.Add(this.label22);
			this.escavenger.Controls.Add(this.scavengerRange);
			this.escavenger.Controls.Add(this.scavengerButtonEditProps);
			this.escavenger.Controls.Add(this.scavengerButtonAddTarget);
			this.escavenger.Controls.Add(this.scavengerDragDelay);
			this.escavenger.Controls.Add(this.scavengerCheckBox);
			this.escavenger.Controls.Add(this.scavengerButtonRemoveList);
			this.escavenger.Controls.Add(this.scavengerButtonAddList);
			this.escavenger.Controls.Add(this.scavengerButtonImport);
			this.escavenger.Controls.Add(this.scavengerListSelect);
			this.escavenger.Controls.Add(this.scavengerButtonExport);
			this.escavenger.Location = new System.Drawing.Point(4, 22);
			this.escavenger.Name = "escavenger";
			this.escavenger.Padding = new System.Windows.Forms.Padding(3);
			this.escavenger.Size = new System.Drawing.Size(659, 341);
			this.escavenger.TabIndex = 1;
			this.escavenger.Text = "Scavenger";
			this.escavenger.UseVisualStyleBackColor = true;
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.Location = new System.Drawing.Point(469, 71);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(62, 13);
			this.label61.TabIndex = 75;
			this.label61.Text = "Max Range";
			// 
			// groupBox41
			// 
			this.groupBox41.Controls.Add(this.label54);
			this.groupBox41.Controls.Add(this.scavengerContainerLabel);
			this.groupBox41.Controls.Add(this.scavengerButtonSetContainer);
			this.groupBox41.Location = new System.Drawing.Point(9, 42);
			this.groupBox41.Name = "groupBox41";
			this.groupBox41.Size = new System.Drawing.Size(257, 47);
			this.groupBox41.TabIndex = 73;
			this.groupBox41.TabStop = false;
			this.groupBox41.Text = "Scavenger Bag";
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.Location = new System.Drawing.Point(6, 21);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(36, 13);
			this.label54.TabIndex = 89;
			this.label54.Text = "Serial:";
			// 
			// scavengerContainerLabel
			// 
			this.scavengerContainerLabel.Location = new System.Drawing.Point(48, 21);
			this.scavengerContainerLabel.Name = "scavengerContainerLabel";
			this.scavengerContainerLabel.Size = new System.Drawing.Size(82, 19);
			this.scavengerContainerLabel.TabIndex = 67;
			this.scavengerContainerLabel.Text = "0x00000000";
			// 
			// scavengerButtonSetContainer
			// 
			this.scavengerButtonSetContainer.Location = new System.Drawing.Point(161, 16);
			this.scavengerButtonSetContainer.Name = "scavengerButtonSetContainer";
			this.scavengerButtonSetContainer.Size = new System.Drawing.Size(90, 21);
			this.scavengerButtonSetContainer.TabIndex = 66;
			this.scavengerButtonSetContainer.Text = "Set Bag";
			this.scavengerButtonSetContainer.Click += new System.EventHandler(this.scavengerSetContainer_Click);
			// 
			// scavengerdataGridView
			// 
			this.scavengerdataGridView.AllowDrop = true;
			this.scavengerdataGridView.AllowUserToResizeRows = false;
			this.scavengerdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.scavengerdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScavengerX,
            this.ScavengerItemName,
            this.ScavenerGraphics,
            this.ScavengerColor,
            this.ScavengerProp});
			this.scavengerdataGridView.Location = new System.Drawing.Point(9, 95);
			this.scavengerdataGridView.Name = "scavengerdataGridView";
			this.scavengerdataGridView.RowHeadersVisible = false;
			this.scavengerdataGridView.Size = new System.Drawing.Size(356, 238);
			this.scavengerdataGridView.TabIndex = 72;
			this.scavengerdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
			this.scavengerdataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.scavengerdataGridView_CellEndEdit);
			this.scavengerdataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_CellMouseUp);
			this.scavengerdataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.GridView_CurrentCellDirtyStateChanged);
			this.scavengerdataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridView_DataError);
			this.scavengerdataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.scavengerdataGridView_DefaultValuesNeeded);
			this.scavengerdataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridView_DragDrop);
			this.scavengerdataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.GridView_DragOver);
			this.scavengerdataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseDown);
			this.scavengerdataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseMove);
			// 
			// ScavengerX
			// 
			this.ScavengerX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.ScavengerX.FalseValue = "False";
			this.ScavengerX.HeaderText = "X";
			this.ScavengerX.IndeterminateValue = "False";
			this.ScavengerX.Name = "ScavengerX";
			this.ScavengerX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ScavengerX.TrueValue = "True";
			this.ScavengerX.Width = 22;
			// 
			// ScavengerItemName
			// 
			this.ScavengerItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.ScavengerItemName.HeaderText = "Item Name";
			this.ScavengerItemName.Name = "ScavengerItemName";
			this.ScavengerItemName.Width = 206;
			// 
			// ScavenerGraphics
			// 
			this.ScavenerGraphics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.ScavenerGraphics.HeaderText = "Graphics";
			this.ScavenerGraphics.Name = "ScavenerGraphics";
			this.ScavenerGraphics.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ScavenerGraphics.Width = 54;
			// 
			// ScavengerColor
			// 
			this.ScavengerColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.ScavengerColor.HeaderText = "Color";
			this.ScavengerColor.Name = "ScavengerColor";
			this.ScavengerColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ScavengerColor.Width = 54;
			// 
			// ScavengerProp
			// 
			this.ScavengerProp.HeaderText = "Prop";
			this.ScavengerProp.Name = "ScavengerProp";
			this.ScavengerProp.Visible = false;
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.scavengerLogBox);
			this.groupBox12.Location = new System.Drawing.Point(371, 94);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(278, 239);
			this.groupBox12.TabIndex = 70;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Scavenger Log";
			// 
			// scavengerLogBox
			// 
			this.scavengerLogBox.FormattingEnabled = true;
			this.scavengerLogBox.Location = new System.Drawing.Point(7, 18);
			this.scavengerLogBox.Name = "scavengerLogBox";
			this.scavengerLogBox.Size = new System.Drawing.Size(265, 212);
			this.scavengerLogBox.TabIndex = 0;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(469, 45);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(56, 13);
			this.label23.TabIndex = 69;
			this.label23.Text = "Delay (ms)";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(6, 18);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(81, 13);
			this.label22.TabIndex = 60;
			this.label22.Text = "Scavenger List:";
			// 
			// scavengerRange
			// 
			this.scavengerRange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scavengerRange.BackColor = System.Drawing.Color.White;
			this.scavengerRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.scavengerRange.Location = new System.Drawing.Point(416, 68);
			this.scavengerRange.Name = "scavengerRange";
			this.scavengerRange.Size = new System.Drawing.Size(45, 20);
			this.scavengerRange.TabIndex = 74;
			this.scavengerRange.TextChanged += new System.EventHandler(this.scavengerRange_TextChanged);
			// 
			// scavengerButtonEditProps
			// 
			this.scavengerButtonEditProps.Location = new System.Drawing.Point(563, 66);
			this.scavengerButtonEditProps.Name = "scavengerButtonEditProps";
			this.scavengerButtonEditProps.Size = new System.Drawing.Size(90, 21);
			this.scavengerButtonEditProps.TabIndex = 49;
			this.scavengerButtonEditProps.Text = "Edit Props";
			this.scavengerButtonEditProps.Click += new System.EventHandler(this.scavengerEditProps_Click);
			// 
			// scavengerButtonAddTarget
			// 
			this.scavengerButtonAddTarget.Location = new System.Drawing.Point(563, 39);
			this.scavengerButtonAddTarget.Name = "scavengerButtonAddTarget";
			this.scavengerButtonAddTarget.Size = new System.Drawing.Size(90, 21);
			this.scavengerButtonAddTarget.TabIndex = 47;
			this.scavengerButtonAddTarget.Text = "Add Item";
			this.scavengerButtonAddTarget.Click += new System.EventHandler(this.scavengerAddItemTarget_Click);
			// 
			// scavengerDragDelay
			// 
			this.scavengerDragDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scavengerDragDelay.BackColor = System.Drawing.Color.White;
			this.scavengerDragDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.scavengerDragDelay.Location = new System.Drawing.Point(416, 42);
			this.scavengerDragDelay.Name = "scavengerDragDelay";
			this.scavengerDragDelay.Size = new System.Drawing.Size(45, 20);
			this.scavengerDragDelay.TabIndex = 68;
			this.scavengerDragDelay.TextChanged += new System.EventHandler(this.scavengerDragDelay_TextChanged);
			// 
			// scavengerCheckBox
			// 
			this.scavengerCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.scavengerCheckBox.Location = new System.Drawing.Point(275, 56);
			this.scavengerCheckBox.Name = "scavengerCheckBox";
			this.scavengerCheckBox.Size = new System.Drawing.Size(115, 22);
			this.scavengerCheckBox.TabIndex = 65;
			this.scavengerCheckBox.Text = "Enable scavenger";
			this.scavengerCheckBox.CheckedChanged += new System.EventHandler(this.scavengerEnableCheck_CheckedChanged);
			// 
			// scavengerButtonRemoveList
			// 
			this.scavengerButtonRemoveList.Location = new System.Drawing.Point(371, 12);
			this.scavengerButtonRemoveList.Name = "scavengerButtonRemoveList";
			this.scavengerButtonRemoveList.Size = new System.Drawing.Size(90, 21);
			this.scavengerButtonRemoveList.TabIndex = 63;
			this.scavengerButtonRemoveList.Text = "Remove";
			this.scavengerButtonRemoveList.Click += new System.EventHandler(this.scavengerRemoveList_Click);
			// 
			// scavengerButtonAddList
			// 
			this.scavengerButtonAddList.Location = new System.Drawing.Point(275, 12);
			this.scavengerButtonAddList.Name = "scavengerButtonAddList";
			this.scavengerButtonAddList.Size = new System.Drawing.Size(90, 21);
			this.scavengerButtonAddList.TabIndex = 62;
			this.scavengerButtonAddList.Text = "Add";
			this.scavengerButtonAddList.Click += new System.EventHandler(this.scavengerAddList_Click);
			// 
			// scavengerButtonImport
			// 
			this.scavengerButtonImport.Location = new System.Drawing.Point(467, 12);
			this.scavengerButtonImport.Name = "scavengerButtonImport";
			this.scavengerButtonImport.Size = new System.Drawing.Size(90, 21);
			this.scavengerButtonImport.TabIndex = 59;
			this.scavengerButtonImport.Text = "Import";
			this.scavengerButtonImport.Click += new System.EventHandler(this.scavengerButtonImport_Click);
			// 
			// scavengerListSelect
			// 
			this.scavengerListSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.scavengerListSelect.FormattingEnabled = true;
			this.scavengerListSelect.Location = new System.Drawing.Point(91, 12);
			this.scavengerListSelect.Name = "scavengerListSelect";
			this.scavengerListSelect.Size = new System.Drawing.Size(175, 21);
			this.scavengerListSelect.TabIndex = 61;
			this.scavengerListSelect.SelectedIndexChanged += new System.EventHandler(this.scavengertListSelect_SelectedIndexChanged);
			// 
			// scavengerButtonExport
			// 
			this.scavengerButtonExport.Location = new System.Drawing.Point(563, 12);
			this.scavengerButtonExport.Name = "scavengerButtonExport";
			this.scavengerButtonExport.Size = new System.Drawing.Size(90, 21);
			this.scavengerButtonExport.TabIndex = 58;
			this.scavengerButtonExport.Text = "Export";
			this.scavengerButtonExport.Click += new System.EventHandler(this.scavengerButtonExport_Click);
			// 
			// organizer
			// 
			this.organizer.Controls.Add(this.organizerExecuteButton);
			this.organizer.Controls.Add(this.organizerStopButton);
			this.organizer.Controls.Add(this.groupBox11);
			this.organizer.Controls.Add(this.organizerdataGridView);
			this.organizer.Controls.Add(this.groupBox16);
			this.organizer.Controls.Add(this.label27);
			this.organizer.Controls.Add(this.label24);
			this.organizer.Controls.Add(this.organizerAddTargetB);
			this.organizer.Controls.Add(this.organizerDragDelay);
			this.organizer.Controls.Add(this.organizerRemoveListB);
			this.organizer.Controls.Add(this.organizerAddListB);
			this.organizer.Controls.Add(this.organizerImportListB);
			this.organizer.Controls.Add(this.organizerListSelect);
			this.organizer.Controls.Add(this.organizerExportListB);
			this.organizer.Location = new System.Drawing.Point(4, 22);
			this.organizer.Name = "organizer";
			this.organizer.Padding = new System.Windows.Forms.Padding(3);
			this.organizer.Size = new System.Drawing.Size(659, 341);
			this.organizer.TabIndex = 2;
			this.organizer.Text = "Organizer";
			this.organizer.UseVisualStyleBackColor = true;
			// 
			// organizerExecuteButton
			// 
			this.organizerExecuteButton.BackgroundImage = global::Assistant.Properties.Resources.playagent;
			this.organizerExecuteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.organizerExecuteButton.FlatAppearance.BorderSize = 0;
			this.organizerExecuteButton.Location = new System.Drawing.Point(283, 58);
			this.organizerExecuteButton.Name = "organizerExecuteButton";
			this.organizerExecuteButton.Size = new System.Drawing.Size(30, 30);
			this.organizerExecuteButton.TabIndex = 91;
			this.organizerExecuteButton.UseVisualStyleBackColor = true;
			this.organizerExecuteButton.Click += new System.EventHandler(this.organizerExecute_Click);
			// 
			// organizerStopButton
			// 
			this.organizerStopButton.BackgroundImage = global::Assistant.Properties.Resources.stopagent;
			this.organizerStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.organizerStopButton.FlatAppearance.BorderSize = 0;
			this.organizerStopButton.Location = new System.Drawing.Point(319, 58);
			this.organizerStopButton.Name = "organizerStopButton";
			this.organizerStopButton.Size = new System.Drawing.Size(30, 30);
			this.organizerStopButton.TabIndex = 1;
			this.organizerStopButton.UseVisualStyleBackColor = true;
			this.organizerStopButton.Click += new System.EventHandler(this.organizerStop_Click);
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.label57);
			this.groupBox11.Controls.Add(this.label56);
			this.groupBox11.Controls.Add(this.organizerSetSourceB);
			this.groupBox11.Controls.Add(this.organizerSetDestinationB);
			this.groupBox11.Controls.Add(this.organizerSourceLabel);
			this.groupBox11.Controls.Add(this.organizerDestinationLabel);
			this.groupBox11.Location = new System.Drawing.Point(9, 42);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(252, 65);
			this.groupBox11.TabIndex = 90;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Organizer Bags";
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.Location = new System.Drawing.Point(6, 41);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(63, 13);
			this.label57.TabIndex = 91;
			this.label57.Text = "Destination:";
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.Location = new System.Drawing.Point(6, 17);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(44, 13);
			this.label56.TabIndex = 90;
			this.label56.Text = "Source:";
			// 
			// organizerSetSourceB
			// 
			this.organizerSetSourceB.Location = new System.Drawing.Point(156, 12);
			this.organizerSetSourceB.Name = "organizerSetSourceB";
			this.organizerSetSourceB.Size = new System.Drawing.Size(90, 21);
			this.organizerSetSourceB.TabIndex = 66;
			this.organizerSetSourceB.Text = "Set Bag";
			this.organizerSetSourceB.Click += new System.EventHandler(this.organizerSetSource_Click);
			// 
			// organizerSetDestinationB
			// 
			this.organizerSetDestinationB.Location = new System.Drawing.Point(156, 37);
			this.organizerSetDestinationB.Name = "organizerSetDestinationB";
			this.organizerSetDestinationB.Size = new System.Drawing.Size(90, 21);
			this.organizerSetDestinationB.TabIndex = 69;
			this.organizerSetDestinationB.Text = "Set Bag";
			this.organizerSetDestinationB.Click += new System.EventHandler(this.organizerSetDestination_Click);
			// 
			// organizerSourceLabel
			// 
			this.organizerSourceLabel.Location = new System.Drawing.Point(75, 17);
			this.organizerSourceLabel.Name = "organizerSourceLabel";
			this.organizerSourceLabel.Size = new System.Drawing.Size(82, 19);
			this.organizerSourceLabel.TabIndex = 67;
			this.organizerSourceLabel.Text = "0x00000000";
			// 
			// organizerDestinationLabel
			// 
			this.organizerDestinationLabel.Location = new System.Drawing.Point(75, 41);
			this.organizerDestinationLabel.Name = "organizerDestinationLabel";
			this.organizerDestinationLabel.Size = new System.Drawing.Size(82, 19);
			this.organizerDestinationLabel.TabIndex = 70;
			this.organizerDestinationLabel.Text = "0x00000000";
			// 
			// organizerdataGridView
			// 
			this.organizerdataGridView.AllowDrop = true;
			this.organizerdataGridView.AllowUserToResizeRows = false;
			this.organizerdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.organizerdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn7});
			this.organizerdataGridView.Location = new System.Drawing.Point(9, 113);
			this.organizerdataGridView.Name = "organizerdataGridView";
			this.organizerdataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.organizerdataGridView.RowHeadersVisible = false;
			this.organizerdataGridView.Size = new System.Drawing.Size(357, 220);
			this.organizerdataGridView.TabIndex = 89;
			this.organizerdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
			this.organizerdataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.organizerdataGridView_CellEndEdit);
			this.organizerdataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_CellMouseUp);
			this.organizerdataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.GridView_CurrentCellDirtyStateChanged);
			this.organizerdataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridView_DataError);
			this.organizerdataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.organizerdataGridView_DefaultValuesNeeded);
			this.organizerdataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridView_DragDrop);
			this.organizerdataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.GridView_DragOver);
			this.organizerdataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseDown);
			this.organizerdataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseMove);
			// 
			// dataGridViewCheckBoxColumn2
			// 
			this.dataGridViewCheckBoxColumn2.FalseValue = "False";
			this.dataGridViewCheckBoxColumn2.HeaderText = "X";
			this.dataGridViewCheckBoxColumn2.IndeterminateValue = "False";
			this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
			this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewCheckBoxColumn2.ToolTipText = "Check This for enable item in list";
			this.dataGridViewCheckBoxColumn2.TrueValue = "True";
			this.dataGridViewCheckBoxColumn2.Width = 22;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn5.HeaderText = "Item Name";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn5.ToolTipText = "Here the item name";
			this.dataGridViewTextBoxColumn5.Width = 153;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn6.HeaderText = "Graphics";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn6.ToolTipText = "Here Graphics item ID";
			this.dataGridViewTextBoxColumn6.Width = 54;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn8.HeaderText = "Color";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn8.ToolTipText = "Here item color, use -1 for all color";
			this.dataGridViewTextBoxColumn8.Width = 54;
			// 
			// dataGridViewTextBoxColumn7
			// 
			this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn7.HeaderText = "Amount";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn7.ToolTipText = "Here amount to move, use -1 for all item";
			this.dataGridViewTextBoxColumn7.Width = 54;
			// 
			// groupBox16
			// 
			this.groupBox16.Controls.Add(this.organizerLogBox);
			this.groupBox16.Location = new System.Drawing.Point(373, 84);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new System.Drawing.Size(278, 251);
			this.groupBox16.TabIndex = 73;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "Organizer Log";
			// 
			// organizerLogBox
			// 
			this.organizerLogBox.FormattingEnabled = true;
			this.organizerLogBox.Location = new System.Drawing.Point(6, 19);
			this.organizerLogBox.Name = "organizerLogBox";
			this.organizerLogBox.Size = new System.Drawing.Size(265, 225);
			this.organizerLogBox.TabIndex = 0;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(415, 54);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(105, 13);
			this.label27.TabIndex = 72;
			this.label27.Text = "Drag Item Delay (ms)";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(6, 18);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(74, 13);
			this.label24.TabIndex = 60;
			this.label24.Text = "Organizer List:";
			// 
			// organizerAddTargetB
			// 
			this.organizerAddTargetB.Location = new System.Drawing.Point(561, 52);
			this.organizerAddTargetB.Name = "organizerAddTargetB";
			this.organizerAddTargetB.Size = new System.Drawing.Size(90, 20);
			this.organizerAddTargetB.TabIndex = 47;
			this.organizerAddTargetB.Text = "Add Item";
			this.organizerAddTargetB.Click += new System.EventHandler(this.organizerAddTarget_Click);
			// 
			// organizerDragDelay
			// 
			this.organizerDragDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.organizerDragDelay.BackColor = System.Drawing.Color.White;
			this.organizerDragDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.organizerDragDelay.Location = new System.Drawing.Point(369, 51);
			this.organizerDragDelay.Name = "organizerDragDelay";
			this.organizerDragDelay.Size = new System.Drawing.Size(45, 20);
			this.organizerDragDelay.TabIndex = 71;
			this.organizerDragDelay.TextChanged += new System.EventHandler(this.organizerDragDelay_TextChanged);
			// 
			// organizerRemoveListB
			// 
			this.organizerRemoveListB.Location = new System.Drawing.Point(369, 12);
			this.organizerRemoveListB.Name = "organizerRemoveListB";
			this.organizerRemoveListB.Size = new System.Drawing.Size(90, 21);
			this.organizerRemoveListB.TabIndex = 63;
			this.organizerRemoveListB.Text = "Remove";
			this.organizerRemoveListB.Click += new System.EventHandler(this.organizerRemoveList_Click);
			// 
			// organizerAddListB
			// 
			this.organizerAddListB.Location = new System.Drawing.Point(273, 12);
			this.organizerAddListB.Name = "organizerAddListB";
			this.organizerAddListB.Size = new System.Drawing.Size(90, 21);
			this.organizerAddListB.TabIndex = 62;
			this.organizerAddListB.Text = "Add";
			this.organizerAddListB.Click += new System.EventHandler(this.organizerAddList_Click);
			// 
			// organizerImportListB
			// 
			this.organizerImportListB.Location = new System.Drawing.Point(465, 12);
			this.organizerImportListB.Name = "organizerImportListB";
			this.organizerImportListB.Size = new System.Drawing.Size(90, 21);
			this.organizerImportListB.TabIndex = 59;
			this.organizerImportListB.Text = "Import";
			this.organizerImportListB.Click += new System.EventHandler(this.organizerImportListB_Click);
			// 
			// organizerListSelect
			// 
			this.organizerListSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.organizerListSelect.FormattingEnabled = true;
			this.organizerListSelect.Location = new System.Drawing.Point(89, 12);
			this.organizerListSelect.Name = "organizerListSelect";
			this.organizerListSelect.Size = new System.Drawing.Size(172, 21);
			this.organizerListSelect.TabIndex = 61;
			this.organizerListSelect.SelectedIndexChanged += new System.EventHandler(this.organizerListSelect_SelectedIndexChanged);
			// 
			// organizerExportListB
			// 
			this.organizerExportListB.Location = new System.Drawing.Point(561, 12);
			this.organizerExportListB.Name = "organizerExportListB";
			this.organizerExportListB.Size = new System.Drawing.Size(90, 21);
			this.organizerExportListB.TabIndex = 58;
			this.organizerExportListB.Text = "Export";
			this.organizerExportListB.Click += new System.EventHandler(this.organizerExportListB_Click);
			// 
			// VendorBuy
			// 
			this.VendorBuy.Controls.Add(this.vendorbuydataGridView);
			this.VendorBuy.Controls.Add(this.groupBox18);
			this.VendorBuy.Controls.Add(this.label25);
			this.VendorBuy.Controls.Add(this.buyAddTargetB);
			this.VendorBuy.Controls.Add(this.buyEnableCheckBox);
			this.VendorBuy.Controls.Add(this.buyRemoveListButton);
			this.VendorBuy.Controls.Add(this.buyAddListButton);
			this.VendorBuy.Controls.Add(this.buyImportListButton);
			this.VendorBuy.Controls.Add(this.buyListSelect);
			this.VendorBuy.Controls.Add(this.buyExportListButton);
			this.VendorBuy.Location = new System.Drawing.Point(4, 22);
			this.VendorBuy.Name = "VendorBuy";
			this.VendorBuy.Padding = new System.Windows.Forms.Padding(3);
			this.VendorBuy.Size = new System.Drawing.Size(659, 341);
			this.VendorBuy.TabIndex = 3;
			this.VendorBuy.Text = "Vendor Buy";
			this.VendorBuy.UseVisualStyleBackColor = true;
			// 
			// vendorbuydataGridView
			// 
			this.vendorbuydataGridView.AllowDrop = true;
			this.vendorbuydataGridView.AllowUserToResizeRows = false;
			this.vendorbuydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.vendorbuydataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
			this.vendorbuydataGridView.Location = new System.Drawing.Point(6, 54);
			this.vendorbuydataGridView.Name = "vendorbuydataGridView";
			this.vendorbuydataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.vendorbuydataGridView.RowHeadersVisible = false;
			this.vendorbuydataGridView.Size = new System.Drawing.Size(357, 274);
			this.vendorbuydataGridView.TabIndex = 88;
			this.vendorbuydataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
			this.vendorbuydataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.vendorbuydataGridView_CellEndEdit);
			this.vendorbuydataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_CellMouseUp);
			this.vendorbuydataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.GridView_CurrentCellDirtyStateChanged);
			this.vendorbuydataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridView_DataError);
			this.vendorbuydataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.vendorbuydataGridView_DefaultValuesNeeded);
			this.vendorbuydataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridView_DragDrop);
			this.vendorbuydataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.GridView_DragOver);
			this.vendorbuydataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseDown);
			this.vendorbuydataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseMove);
			// 
			// dataGridViewCheckBoxColumn1
			// 
			this.dataGridViewCheckBoxColumn1.FalseValue = "False";
			this.dataGridViewCheckBoxColumn1.HeaderText = "X";
			this.dataGridViewCheckBoxColumn1.IndeterminateValue = "False";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewCheckBoxColumn1.ToolTipText = "Check This for enable item in list";
			this.dataGridViewCheckBoxColumn1.TrueValue = "True";
			this.dataGridViewCheckBoxColumn1.Width = 22;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn1.HeaderText = "Item Name";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn1.ToolTipText = "Here the item name";
			this.dataGridViewTextBoxColumn1.Width = 153;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn2.HeaderText = "Graphics";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.ToolTipText = "Here Graphics item ID";
			this.dataGridViewTextBoxColumn2.Width = 54;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn3.ToolTipText = "Here Item Amount to sell";
			this.dataGridViewTextBoxColumn3.Width = 54;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn4.HeaderText = "Color";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn4.ToolTipText = "Here item color, use -1 for all color";
			this.dataGridViewTextBoxColumn4.Width = 54;
			// 
			// groupBox18
			// 
			this.groupBox18.Controls.Add(this.buyLogBox);
			this.groupBox18.Location = new System.Drawing.Point(373, 72);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new System.Drawing.Size(278, 256);
			this.groupBox18.TabIndex = 73;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Buy Log";
			// 
			// buyLogBox
			// 
			this.buyLogBox.FormattingEnabled = true;
			this.buyLogBox.Location = new System.Drawing.Point(7, 18);
			this.buyLogBox.Name = "buyLogBox";
			this.buyLogBox.Size = new System.Drawing.Size(265, 225);
			this.buyLogBox.TabIndex = 0;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(3, 18);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(65, 13);
			this.label25.TabIndex = 66;
			this.label25.Text = "Vendor Buy:";
			// 
			// buyAddTargetB
			// 
			this.buyAddTargetB.Location = new System.Drawing.Point(561, 39);
			this.buyAddTargetB.Name = "buyAddTargetB";
			this.buyAddTargetB.Size = new System.Drawing.Size(90, 21);
			this.buyAddTargetB.TabIndex = 45;
			this.buyAddTargetB.Text = "Add Item";
			this.buyAddTargetB.Click += new System.EventHandler(this.buyAddTarget_Click);
			// 
			// buyEnableCheckBox
			// 
			this.buyEnableCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buyEnableCheckBox.Location = new System.Drawing.Point(373, 44);
			this.buyEnableCheckBox.Name = "buyEnableCheckBox";
			this.buyEnableCheckBox.Size = new System.Drawing.Size(135, 22);
			this.buyEnableCheckBox.TabIndex = 72;
			this.buyEnableCheckBox.Text = "Enable Buy List";
			this.buyEnableCheckBox.CheckedChanged += new System.EventHandler(this.buyEnableCheckB_CheckedChanged);
			// 
			// buyRemoveListButton
			// 
			this.buyRemoveListButton.Location = new System.Drawing.Point(369, 12);
			this.buyRemoveListButton.Name = "buyRemoveListButton";
			this.buyRemoveListButton.Size = new System.Drawing.Size(90, 21);
			this.buyRemoveListButton.TabIndex = 69;
			this.buyRemoveListButton.Text = "Remove";
			this.buyRemoveListButton.Click += new System.EventHandler(this.buyRemoveList_Click);
			// 
			// buyAddListButton
			// 
			this.buyAddListButton.Location = new System.Drawing.Point(273, 12);
			this.buyAddListButton.Name = "buyAddListButton";
			this.buyAddListButton.Size = new System.Drawing.Size(90, 21);
			this.buyAddListButton.TabIndex = 68;
			this.buyAddListButton.Text = "Add";
			this.buyAddListButton.Click += new System.EventHandler(this.buyAddList_Click);
			// 
			// buyImportListButton
			// 
			this.buyImportListButton.Location = new System.Drawing.Point(465, 12);
			this.buyImportListButton.Name = "buyImportListButton";
			this.buyImportListButton.Size = new System.Drawing.Size(90, 21);
			this.buyImportListButton.TabIndex = 65;
			this.buyImportListButton.Text = "Import";
			this.buyImportListButton.Click += new System.EventHandler(this.buyImportListButton_Click);
			// 
			// buyListSelect
			// 
			this.buyListSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.buyListSelect.FormattingEnabled = true;
			this.buyListSelect.Location = new System.Drawing.Point(78, 12);
			this.buyListSelect.Name = "buyListSelect";
			this.buyListSelect.Size = new System.Drawing.Size(183, 21);
			this.buyListSelect.TabIndex = 67;
			this.buyListSelect.SelectedIndexChanged += new System.EventHandler(this.buyListSelect_SelectedIndexChanged);
			// 
			// buyExportListButton
			// 
			this.buyExportListButton.Location = new System.Drawing.Point(561, 12);
			this.buyExportListButton.Name = "buyExportListButton";
			this.buyExportListButton.Size = new System.Drawing.Size(90, 21);
			this.buyExportListButton.TabIndex = 64;
			this.buyExportListButton.Text = "Export";
			this.buyExportListButton.Click += new System.EventHandler(this.buyExportListButton_Click);
			// 
			// VendorSell
			// 
			this.VendorSell.Controls.Add(this.groupBox19);
			this.VendorSell.Controls.Add(this.vendorsellGridView);
			this.VendorSell.Controls.Add(this.groupBox20);
			this.VendorSell.Controls.Add(this.label26);
			this.VendorSell.Controls.Add(this.sellAddTargerButton);
			this.VendorSell.Controls.Add(this.sellEnableCheckBox);
			this.VendorSell.Controls.Add(this.sellRemoveListButton);
			this.VendorSell.Controls.Add(this.sellAddListButton);
			this.VendorSell.Controls.Add(this.sellImportListButton);
			this.VendorSell.Controls.Add(this.sellListSelect);
			this.VendorSell.Controls.Add(this.sellExportListButton);
			this.VendorSell.Location = new System.Drawing.Point(4, 22);
			this.VendorSell.Name = "VendorSell";
			this.VendorSell.Padding = new System.Windows.Forms.Padding(3);
			this.VendorSell.Size = new System.Drawing.Size(659, 341);
			this.VendorSell.TabIndex = 4;
			this.VendorSell.Text = "Vendor Sell";
			this.VendorSell.UseVisualStyleBackColor = true;
			// 
			// groupBox19
			// 
			this.groupBox19.Controls.Add(this.sellSetBagButton);
			this.groupBox19.Controls.Add(this.label50);
			this.groupBox19.Controls.Add(this.sellBagLabel);
			this.groupBox19.Location = new System.Drawing.Point(6, 42);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Size = new System.Drawing.Size(255, 42);
			this.groupBox19.TabIndex = 89;
			this.groupBox19.TabStop = false;
			this.groupBox19.Text = "Sell Bag";
			// 
			// sellSetBagButton
			// 
			this.sellSetBagButton.Location = new System.Drawing.Point(157, 14);
			this.sellSetBagButton.Name = "sellSetBagButton";
			this.sellSetBagButton.Size = new System.Drawing.Size(90, 21);
			this.sellSetBagButton.TabIndex = 85;
			this.sellSetBagButton.Text = "Set Bag";
			this.sellSetBagButton.Click += new System.EventHandler(this.sellSetBag_Click);
			// 
			// label50
			// 
			this.label50.AutoSize = true;
			this.label50.Location = new System.Drawing.Point(6, 19);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(36, 13);
			this.label50.TabIndex = 88;
			this.label50.Text = "Serial:";
			// 
			// sellBagLabel
			// 
			this.sellBagLabel.Location = new System.Drawing.Point(47, 19);
			this.sellBagLabel.Name = "sellBagLabel";
			this.sellBagLabel.Size = new System.Drawing.Size(72, 19);
			this.sellBagLabel.TabIndex = 86;
			this.sellBagLabel.Text = "0x00000000";
			// 
			// vendorsellGridView
			// 
			this.vendorsellGridView.AllowDrop = true;
			this.vendorsellGridView.AllowUserToResizeRows = false;
			this.vendorsellGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.vendorsellGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VendorSellX,
            this.VendorSellItemName,
            this.VendorSellGraphics,
            this.VendorSellAmount,
            this.VendorSellColor});
			this.vendorsellGridView.Location = new System.Drawing.Point(6, 90);
			this.vendorsellGridView.Name = "vendorsellGridView";
			this.vendorsellGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.vendorsellGridView.RowHeadersVisible = false;
			this.vendorsellGridView.Size = new System.Drawing.Size(357, 238);
			this.vendorsellGridView.TabIndex = 87;
			this.vendorsellGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
			this.vendorsellGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.vendorsellGridView_CellEndEdit);
			this.vendorsellGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_CellMouseUp);
			this.vendorsellGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.GridView_CurrentCellDirtyStateChanged);
			this.vendorsellGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridView_DataError);
			this.vendorsellGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.vendorsellGridView_DefaultValuesNeeded);
			this.vendorsellGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridView_DragDrop);
			this.vendorsellGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.GridView_DragOver);
			this.vendorsellGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseDown);
			this.vendorsellGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseMove);
			// 
			// VendorSellX
			// 
			this.VendorSellX.FalseValue = "False";
			this.VendorSellX.HeaderText = "X";
			this.VendorSellX.IndeterminateValue = "False";
			this.VendorSellX.Name = "VendorSellX";
			this.VendorSellX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.VendorSellX.ToolTipText = "Check This for enable item in list";
			this.VendorSellX.TrueValue = "True";
			this.VendorSellX.Width = 22;
			// 
			// VendorSellItemName
			// 
			this.VendorSellItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.VendorSellItemName.HeaderText = "Item Name";
			this.VendorSellItemName.Name = "VendorSellItemName";
			this.VendorSellItemName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.VendorSellItemName.ToolTipText = "Here the item name";
			this.VendorSellItemName.Width = 153;
			// 
			// VendorSellGraphics
			// 
			this.VendorSellGraphics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.VendorSellGraphics.HeaderText = "Graphics";
			this.VendorSellGraphics.Name = "VendorSellGraphics";
			this.VendorSellGraphics.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.VendorSellGraphics.ToolTipText = "Here Graphics item ID";
			this.VendorSellGraphics.Width = 54;
			// 
			// VendorSellAmount
			// 
			this.VendorSellAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.VendorSellAmount.HeaderText = "Amount";
			this.VendorSellAmount.Name = "VendorSellAmount";
			this.VendorSellAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.VendorSellAmount.ToolTipText = "Here Item Amount to sell";
			this.VendorSellAmount.Width = 54;
			// 
			// VendorSellColor
			// 
			this.VendorSellColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.VendorSellColor.HeaderText = "Color";
			this.VendorSellColor.Name = "VendorSellColor";
			this.VendorSellColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.VendorSellColor.ToolTipText = "Here item color, use -1 for all color";
			this.VendorSellColor.Width = 54;
			// 
			// groupBox20
			// 
			this.groupBox20.Controls.Add(this.sellLogBox);
			this.groupBox20.Location = new System.Drawing.Point(373, 72);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Size = new System.Drawing.Size(278, 256);
			this.groupBox20.TabIndex = 83;
			this.groupBox20.TabStop = false;
			this.groupBox20.Text = "Sell Log";
			// 
			// sellLogBox
			// 
			this.sellLogBox.FormattingEnabled = true;
			this.sellLogBox.Location = new System.Drawing.Point(7, 18);
			this.sellLogBox.Name = "sellLogBox";
			this.sellLogBox.Size = new System.Drawing.Size(265, 225);
			this.sellLogBox.TabIndex = 0;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(3, 18);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(64, 13);
			this.label26.TabIndex = 77;
			this.label26.Text = "Vendor Sell:";
			// 
			// sellAddTargerButton
			// 
			this.sellAddTargerButton.Location = new System.Drawing.Point(561, 49);
			this.sellAddTargerButton.Name = "sellAddTargerButton";
			this.sellAddTargerButton.Size = new System.Drawing.Size(90, 21);
			this.sellAddTargerButton.TabIndex = 47;
			this.sellAddTargerButton.Text = "Add Item";
			this.sellAddTargerButton.Click += new System.EventHandler(this.sellAddTarget_Click);
			// 
			// sellEnableCheckBox
			// 
			this.sellEnableCheckBox.Location = new System.Drawing.Point(273, 49);
			this.sellEnableCheckBox.Name = "sellEnableCheckBox";
			this.sellEnableCheckBox.Size = new System.Drawing.Size(105, 22);
			this.sellEnableCheckBox.TabIndex = 82;
			this.sellEnableCheckBox.Text = "Enable Sell List";
			this.sellEnableCheckBox.CheckedChanged += new System.EventHandler(this.sellEnableCheck_CheckedChanged);
			// 
			// sellRemoveListButton
			// 
			this.sellRemoveListButton.Location = new System.Drawing.Point(369, 12);
			this.sellRemoveListButton.Name = "sellRemoveListButton";
			this.sellRemoveListButton.Size = new System.Drawing.Size(90, 21);
			this.sellRemoveListButton.TabIndex = 80;
			this.sellRemoveListButton.Text = "Remove";
			this.sellRemoveListButton.Click += new System.EventHandler(this.sellRemoveList_Click);
			// 
			// sellAddListButton
			// 
			this.sellAddListButton.Location = new System.Drawing.Point(273, 12);
			this.sellAddListButton.Name = "sellAddListButton";
			this.sellAddListButton.Size = new System.Drawing.Size(90, 21);
			this.sellAddListButton.TabIndex = 79;
			this.sellAddListButton.Text = "Add";
			this.sellAddListButton.Click += new System.EventHandler(this.sellAddList_Click);
			// 
			// sellImportListButton
			// 
			this.sellImportListButton.Location = new System.Drawing.Point(465, 12);
			this.sellImportListButton.Name = "sellImportListButton";
			this.sellImportListButton.Size = new System.Drawing.Size(90, 21);
			this.sellImportListButton.TabIndex = 76;
			this.sellImportListButton.Text = "Import";
			this.sellImportListButton.Click += new System.EventHandler(this.sellImportListButton_Click);
			// 
			// sellListSelect
			// 
			this.sellListSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sellListSelect.FormattingEnabled = true;
			this.sellListSelect.Location = new System.Drawing.Point(78, 12);
			this.sellListSelect.Name = "sellListSelect";
			this.sellListSelect.Size = new System.Drawing.Size(183, 21);
			this.sellListSelect.TabIndex = 78;
			this.sellListSelect.SelectedIndexChanged += new System.EventHandler(this.sellListSelect_SelectedIndexChanged);
			// 
			// sellExportListButton
			// 
			this.sellExportListButton.Location = new System.Drawing.Point(561, 12);
			this.sellExportListButton.Name = "sellExportListButton";
			this.sellExportListButton.Size = new System.Drawing.Size(90, 21);
			this.sellExportListButton.TabIndex = 75;
			this.sellExportListButton.Text = "Export";
			this.sellExportListButton.Click += new System.EventHandler(this.sellExportListButton_Click);
			// 
			// Dress
			// 
			this.Dress.Controls.Add(this.dressStopButton);
			this.Dress.Controls.Add(this.dressConflictCheckB);
			this.Dress.Controls.Add(this.dressBagLabel);
			this.Dress.Controls.Add(this.groupBox22);
			this.Dress.Controls.Add(this.label29);
			this.Dress.Controls.Add(this.groupBox21);
			this.Dress.Controls.Add(this.dressSetBagB);
			this.Dress.Controls.Add(this.undressExecuteButton);
			this.Dress.Controls.Add(this.dressExecuteButton);
			this.Dress.Controls.Add(this.dressDragDelay);
			this.Dress.Controls.Add(this.dressListView);
			this.Dress.Controls.Add(this.label28);
			this.Dress.Controls.Add(this.dressRemoveListB);
			this.Dress.Controls.Add(this.dressAddListB);
			this.Dress.Controls.Add(this.dressImportListB);
			this.Dress.Controls.Add(this.dressListSelect);
			this.Dress.Controls.Add(this.dressExportListB);
			this.Dress.Location = new System.Drawing.Point(4, 22);
			this.Dress.Name = "Dress";
			this.Dress.Padding = new System.Windows.Forms.Padding(3);
			this.Dress.Size = new System.Drawing.Size(659, 341);
			this.Dress.TabIndex = 5;
			this.Dress.Text = "Dress / Arm";
			this.Dress.UseVisualStyleBackColor = true;
			// 
			// dressStopButton
			// 
			this.dressStopButton.Location = new System.Drawing.Point(407, 58);
			this.dressStopButton.Name = "dressStopButton";
			this.dressStopButton.Size = new System.Drawing.Size(61, 20);
			this.dressStopButton.TabIndex = 91;
			this.dressStopButton.Text = "Stop";
			this.dressStopButton.Click += new System.EventHandler(this.dressStopButton_Click);
			// 
			// dressConflictCheckB
			// 
			this.dressConflictCheckB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.dressConflictCheckB.Location = new System.Drawing.Point(274, 84);
			this.dressConflictCheckB.Name = "dressConflictCheckB";
			this.dressConflictCheckB.Size = new System.Drawing.Size(224, 22);
			this.dressConflictCheckB.TabIndex = 90;
			this.dressConflictCheckB.Text = "Remove Conflict Item";
			this.dressConflictCheckB.CheckedChanged += new System.EventHandler(this.dressConflictCheckB_CheckedChanged);
			// 
			// dressBagLabel
			// 
			this.dressBagLabel.Location = new System.Drawing.Point(570, 154);
			this.dressBagLabel.Name = "dressBagLabel";
			this.dressBagLabel.Size = new System.Drawing.Size(82, 19);
			this.dressBagLabel.TabIndex = 89;
			this.dressBagLabel.Text = "0x00000000";
			// 
			// groupBox22
			// 
			this.groupBox22.Controls.Add(this.dressAddTargetB);
			this.groupBox22.Controls.Add(this.dressAddManualB);
			this.groupBox22.Controls.Add(this.dressRemoveB);
			this.groupBox22.Controls.Add(this.dressReadB);
			this.groupBox22.Location = new System.Drawing.Point(551, 186);
			this.groupBox22.Name = "groupBox22";
			this.groupBox22.Size = new System.Drawing.Size(100, 125);
			this.groupBox22.TabIndex = 85;
			this.groupBox22.TabStop = false;
			this.groupBox22.Text = "Item List";
			// 
			// dressAddTargetB
			// 
			this.dressAddTargetB.Location = new System.Drawing.Point(5, 68);
			this.dressAddTargetB.Name = "dressAddTargetB";
			this.dressAddTargetB.Size = new System.Drawing.Size(90, 20);
			this.dressAddTargetB.TabIndex = 48;
			this.dressAddTargetB.Text = "Add Target";
			this.dressAddTargetB.Click += new System.EventHandler(this.dressAddTargetB_Click);
			// 
			// dressAddManualB
			// 
			this.dressAddManualB.Location = new System.Drawing.Point(5, 43);
			this.dressAddManualB.Name = "dressAddManualB";
			this.dressAddManualB.Size = new System.Drawing.Size(90, 20);
			this.dressAddManualB.TabIndex = 47;
			this.dressAddManualB.Text = "Add Clear Layer";
			this.dressAddManualB.Click += new System.EventHandler(this.dressAddManualB_Click);
			// 
			// dressRemoveB
			// 
			this.dressRemoveB.Location = new System.Drawing.Point(5, 94);
			this.dressRemoveB.Name = "dressRemoveB";
			this.dressRemoveB.Size = new System.Drawing.Size(90, 20);
			this.dressRemoveB.TabIndex = 46;
			this.dressRemoveB.Text = "Remove";
			this.dressRemoveB.Click += new System.EventHandler(this.dressRemoveB_Click);
			// 
			// dressReadB
			// 
			this.dressReadB.Location = new System.Drawing.Point(5, 18);
			this.dressReadB.Name = "dressReadB";
			this.dressReadB.Size = new System.Drawing.Size(90, 20);
			this.dressReadB.TabIndex = 45;
			this.dressReadB.Text = "Read Current";
			this.dressReadB.Click += new System.EventHandler(this.dressReadB_Click);
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(521, 61);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(105, 13);
			this.label29.TabIndex = 76;
			this.label29.Text = "Drag Item Delay (ms)";
			// 
			// groupBox21
			// 
			this.groupBox21.Controls.Add(this.dressLogBox);
			this.groupBox21.Location = new System.Drawing.Point(267, 109);
			this.groupBox21.Name = "groupBox21";
			this.groupBox21.Size = new System.Drawing.Size(278, 226);
			this.groupBox21.TabIndex = 74;
			this.groupBox21.TabStop = false;
			this.groupBox21.Text = "Organizer Log";
			// 
			// dressLogBox
			// 
			this.dressLogBox.FormattingEnabled = true;
			this.dressLogBox.Location = new System.Drawing.Point(7, 18);
			this.dressLogBox.Name = "dressLogBox";
			this.dressLogBox.Size = new System.Drawing.Size(265, 199);
			this.dressLogBox.TabIndex = 0;
			// 
			// dressSetBagB
			// 
			this.dressSetBagB.Location = new System.Drawing.Point(558, 127);
			this.dressSetBagB.Name = "dressSetBagB";
			this.dressSetBagB.Size = new System.Drawing.Size(88, 20);
			this.dressSetBagB.TabIndex = 88;
			this.dressSetBagB.Text = "Undress Bag";
			this.dressSetBagB.Click += new System.EventHandler(this.dressSetBagB_Click);
			// 
			// undressExecuteButton
			// 
			this.undressExecuteButton.Location = new System.Drawing.Point(340, 58);
			this.undressExecuteButton.Name = "undressExecuteButton";
			this.undressExecuteButton.Size = new System.Drawing.Size(61, 20);
			this.undressExecuteButton.TabIndex = 87;
			this.undressExecuteButton.Text = "Undres";
			this.undressExecuteButton.Click += new System.EventHandler(this.razorButton10_Click);
			// 
			// dressExecuteButton
			// 
			this.dressExecuteButton.Location = new System.Drawing.Point(274, 58);
			this.dressExecuteButton.Name = "dressExecuteButton";
			this.dressExecuteButton.Size = new System.Drawing.Size(61, 20);
			this.dressExecuteButton.TabIndex = 86;
			this.dressExecuteButton.Text = "Dress";
			this.dressExecuteButton.Click += new System.EventHandler(this.dressExecuteButton_Click);
			// 
			// dressDragDelay
			// 
			this.dressDragDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dressDragDelay.BackColor = System.Drawing.Color.White;
			this.dressDragDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dressDragDelay.Location = new System.Drawing.Point(475, 58);
			this.dressDragDelay.Name = "dressDragDelay";
			this.dressDragDelay.Size = new System.Drawing.Size(45, 20);
			this.dressDragDelay.TabIndex = 75;
			this.dressDragDelay.TextChanged += new System.EventHandler(this.dressDragDelay_TextChanged);
			// 
			// dressListView
			// 
			this.dressListView.CheckBoxes = true;
			this.dressListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27});
			this.dressListView.FullRowSelect = true;
			this.dressListView.GridLines = true;
			this.dressListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.dressListView.HideSelection = false;
			this.dressListView.LabelWrap = false;
			this.dressListView.Location = new System.Drawing.Point(6, 51);
			this.dressListView.MultiSelect = false;
			this.dressListView.Name = "dressListView";
			this.dressListView.Size = new System.Drawing.Size(255, 284);
			this.dressListView.TabIndex = 64;
			this.dressListView.UseCompatibleStateImageBehavior = false;
			this.dressListView.View = System.Windows.Forms.View.Details;
			this.dressListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.dresslistView_ItemChecked);
			// 
			// columnHeader24
			// 
			this.columnHeader24.Text = "X";
			this.columnHeader24.Width = 22;
			// 
			// columnHeader25
			// 
			this.columnHeader25.Text = "Layer";
			this.columnHeader25.Width = 90;
			// 
			// columnHeader26
			// 
			this.columnHeader26.Text = "Name";
			// 
			// columnHeader27
			// 
			this.columnHeader27.Text = "Serial";
			this.columnHeader27.Width = 75;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(6, 18);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(56, 13);
			this.label28.TabIndex = 60;
			this.label28.Text = "Dress List:";
			// 
			// dressRemoveListB
			// 
			this.dressRemoveListB.Location = new System.Drawing.Point(366, 12);
			this.dressRemoveListB.Name = "dressRemoveListB";
			this.dressRemoveListB.Size = new System.Drawing.Size(90, 21);
			this.dressRemoveListB.TabIndex = 63;
			this.dressRemoveListB.Text = "Remove";
			this.dressRemoveListB.Click += new System.EventHandler(this.dressRemoveListB_Click);
			// 
			// dressAddListB
			// 
			this.dressAddListB.Location = new System.Drawing.Point(270, 12);
			this.dressAddListB.Name = "dressAddListB";
			this.dressAddListB.Size = new System.Drawing.Size(90, 21);
			this.dressAddListB.TabIndex = 62;
			this.dressAddListB.Text = "Add";
			this.dressAddListB.Click += new System.EventHandler(this.dressAddListB_Click);
			// 
			// dressImportListB
			// 
			this.dressImportListB.Location = new System.Drawing.Point(462, 12);
			this.dressImportListB.Name = "dressImportListB";
			this.dressImportListB.Size = new System.Drawing.Size(90, 21);
			this.dressImportListB.TabIndex = 59;
			this.dressImportListB.Text = "Import";
			this.dressImportListB.Click += new System.EventHandler(this.dressImportListB_Click);
			// 
			// dressListSelect
			// 
			this.dressListSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dressListSelect.FormattingEnabled = true;
			this.dressListSelect.Location = new System.Drawing.Point(78, 12);
			this.dressListSelect.Name = "dressListSelect";
			this.dressListSelect.Size = new System.Drawing.Size(183, 21);
			this.dressListSelect.TabIndex = 61;
			this.dressListSelect.SelectedIndexChanged += new System.EventHandler(this.dressListSelect_SelectedIndexChanged);
			// 
			// dressExportListB
			// 
			this.dressExportListB.Location = new System.Drawing.Point(558, 12);
			this.dressExportListB.Name = "dressExportListB";
			this.dressExportListB.Size = new System.Drawing.Size(90, 21);
			this.dressExportListB.TabIndex = 58;
			this.dressExportListB.Text = "Export";
			this.dressExportListB.Click += new System.EventHandler(this.dressExportListB_Click);
			// 
			// friends
			// 
			this.friends.Controls.Add(this.groupBox34);
			this.friends.Controls.Add(this.groupBox33);
			this.friends.Controls.Add(this.friendguildListView);
			this.friends.Controls.Add(this.friendGroupBox);
			this.friends.Controls.Add(this.friendloggroupBox);
			this.friends.Controls.Add(this.friendIncludePartyCheckBox);
			this.friends.Controls.Add(this.friendAttackCheckBox);
			this.friends.Controls.Add(this.friendPartyCheckBox);
			this.friends.Controls.Add(this.friendlistView);
			this.friends.Controls.Add(this.labelfriend);
			this.friends.Controls.Add(this.friendButtonRemoveList);
			this.friends.Controls.Add(this.friendButtonAddList);
			this.friends.Controls.Add(this.friendButtonImportList);
			this.friends.Controls.Add(this.friendListSelect);
			this.friends.Controls.Add(this.friendButtonExportList);
			this.friends.Location = new System.Drawing.Point(4, 22);
			this.friends.Name = "friends";
			this.friends.Padding = new System.Windows.Forms.Padding(3);
			this.friends.Size = new System.Drawing.Size(659, 341);
			this.friends.TabIndex = 6;
			this.friends.Text = "Friends";
			this.friends.UseVisualStyleBackColor = true;
			// 
			// groupBox34
			// 
			this.groupBox34.Controls.Add(this.FriendGuildAddButton);
			this.groupBox34.Controls.Add(this.FriendGuildRemoveButton);
			this.groupBox34.Location = new System.Drawing.Point(547, 230);
			this.groupBox34.Name = "groupBox34";
			this.groupBox34.Size = new System.Drawing.Size(106, 75);
			this.groupBox34.TabIndex = 82;
			this.groupBox34.TabStop = false;
			this.groupBox34.Text = "Guild Friend";
			// 
			// FriendGuildAddButton
			// 
			this.FriendGuildAddButton.Location = new System.Drawing.Point(9, 19);
			this.FriendGuildAddButton.Name = "FriendGuildAddButton";
			this.FriendGuildAddButton.Size = new System.Drawing.Size(90, 20);
			this.FriendGuildAddButton.TabIndex = 80;
			this.FriendGuildAddButton.Text = "Add Manual";
			this.FriendGuildAddButton.Click += new System.EventHandler(this.FriendGuildAddButton_Click);
			// 
			// FriendGuildRemoveButton
			// 
			this.FriendGuildRemoveButton.Location = new System.Drawing.Point(9, 45);
			this.FriendGuildRemoveButton.Name = "FriendGuildRemoveButton";
			this.FriendGuildRemoveButton.Size = new System.Drawing.Size(90, 20);
			this.FriendGuildRemoveButton.TabIndex = 81;
			this.FriendGuildRemoveButton.Text = "Remove";
			this.FriendGuildRemoveButton.Click += new System.EventHandler(this.FriendGuildRemoveButton_Click);
			// 
			// groupBox33
			// 
			this.groupBox33.Controls.Add(this.MINfriendCheckBox);
			this.groupBox33.Controls.Add(this.SLfriendCheckBox);
			this.groupBox33.Controls.Add(this.TBfriendCheckBox);
			this.groupBox33.Controls.Add(this.COMfriendCheckBox);
			this.groupBox33.Location = new System.Drawing.Point(547, 147);
			this.groupBox33.Name = "groupBox33";
			this.groupBox33.Size = new System.Drawing.Size(106, 77);
			this.groupBox33.TabIndex = 78;
			this.groupBox33.TabStop = false;
			this.groupBox33.Text = "Faction Friend";
			// 
			// MINfriendCheckBox
			// 
			this.MINfriendCheckBox.Location = new System.Drawing.Point(50, 47);
			this.MINfriendCheckBox.Name = "MINfriendCheckBox";
			this.MINfriendCheckBox.Size = new System.Drawing.Size(47, 22);
			this.MINfriendCheckBox.TabIndex = 81;
			this.MINfriendCheckBox.Text = "MIN";
			this.MINfriendCheckBox.CheckedChanged += new System.EventHandler(this.MINfriendCheckBox_CheckedChanged);
			// 
			// SLfriendCheckBox
			// 
			this.SLfriendCheckBox.Location = new System.Drawing.Point(5, 20);
			this.SLfriendCheckBox.Name = "SLfriendCheckBox";
			this.SLfriendCheckBox.Size = new System.Drawing.Size(41, 22);
			this.SLfriendCheckBox.TabIndex = 78;
			this.SLfriendCheckBox.Text = "SL";
			this.SLfriendCheckBox.CheckedChanged += new System.EventHandler(this.SLfriendCheckBox_CheckedChanged);
			// 
			// TBfriendCheckBox
			// 
			this.TBfriendCheckBox.Location = new System.Drawing.Point(5, 47);
			this.TBfriendCheckBox.Name = "TBfriendCheckBox";
			this.TBfriendCheckBox.Size = new System.Drawing.Size(41, 22);
			this.TBfriendCheckBox.TabIndex = 79;
			this.TBfriendCheckBox.Text = "TB";
			this.TBfriendCheckBox.CheckedChanged += new System.EventHandler(this.TBfriendCheckBox_CheckedChanged);
			// 
			// COMfriendCheckBox
			// 
			this.COMfriendCheckBox.Location = new System.Drawing.Point(50, 20);
			this.COMfriendCheckBox.Name = "COMfriendCheckBox";
			this.COMfriendCheckBox.Size = new System.Drawing.Size(50, 22);
			this.COMfriendCheckBox.TabIndex = 80;
			this.COMfriendCheckBox.Text = "CoM";
			this.COMfriendCheckBox.CheckedChanged += new System.EventHandler(this.COMfriendCheckBox_CheckedChanged);
			// 
			// friendguildListView
			// 
			this.friendguildListView.CheckBoxes = true;
			this.friendguildListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader63,
            this.columnHeader64});
			this.friendguildListView.FullRowSelect = true;
			this.friendguildListView.GridLines = true;
			this.friendguildListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.friendguildListView.HideSelection = false;
			this.friendguildListView.LabelWrap = false;
			this.friendguildListView.Location = new System.Drawing.Point(6, 198);
			this.friendguildListView.MultiSelect = false;
			this.friendguildListView.Name = "friendguildListView";
			this.friendguildListView.Size = new System.Drawing.Size(255, 135);
			this.friendguildListView.TabIndex = 77;
			this.friendguildListView.UseCompatibleStateImageBehavior = false;
			this.friendguildListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader63
			// 
			this.columnHeader63.Text = "X";
			this.columnHeader63.Width = 22;
			// 
			// columnHeader64
			// 
			this.columnHeader64.Text = "Guild";
			this.columnHeader64.Width = 223;
			// 
			// friendGroupBox
			// 
			this.friendGroupBox.Controls.Add(this.friendAddTargetButton);
			this.friendGroupBox.Controls.Add(this.friendRemoveButton);
			this.friendGroupBox.Controls.Add(this.friendAddButton);
			this.friendGroupBox.Location = new System.Drawing.Point(547, 41);
			this.friendGroupBox.Name = "friendGroupBox";
			this.friendGroupBox.Size = new System.Drawing.Size(106, 100);
			this.friendGroupBox.TabIndex = 76;
			this.friendGroupBox.TabStop = false;
			this.friendGroupBox.Text = "User Friend";
			// 
			// friendAddTargetButton
			// 
			this.friendAddTargetButton.Location = new System.Drawing.Point(9, 46);
			this.friendAddTargetButton.Name = "friendAddTargetButton";
			this.friendAddTargetButton.Size = new System.Drawing.Size(90, 20);
			this.friendAddTargetButton.TabIndex = 50;
			this.friendAddTargetButton.Text = "Add Target";
			this.friendAddTargetButton.Click += new System.EventHandler(this.friendAddTargetButton_Click);
			// 
			// friendRemoveButton
			// 
			this.friendRemoveButton.Location = new System.Drawing.Point(9, 72);
			this.friendRemoveButton.Name = "friendRemoveButton";
			this.friendRemoveButton.Size = new System.Drawing.Size(90, 20);
			this.friendRemoveButton.TabIndex = 49;
			this.friendRemoveButton.Text = "Remove";
			this.friendRemoveButton.Click += new System.EventHandler(this.friendRemoveButton_Click);
			// 
			// friendAddButton
			// 
			this.friendAddButton.Location = new System.Drawing.Point(9, 21);
			this.friendAddButton.Name = "friendAddButton";
			this.friendAddButton.Size = new System.Drawing.Size(90, 20);
			this.friendAddButton.TabIndex = 48;
			this.friendAddButton.Text = "Add Manual";
			this.friendAddButton.Click += new System.EventHandler(this.friendAddButton_Click);
			// 
			// friendloggroupBox
			// 
			this.friendloggroupBox.Controls.Add(this.friendLogBox);
			this.friendloggroupBox.Location = new System.Drawing.Point(270, 131);
			this.friendloggroupBox.Name = "friendloggroupBox";
			this.friendloggroupBox.Size = new System.Drawing.Size(271, 204);
			this.friendloggroupBox.TabIndex = 74;
			this.friendloggroupBox.TabStop = false;
			this.friendloggroupBox.Text = "Friend Log";
			// 
			// friendLogBox
			// 
			this.friendLogBox.FormattingEnabled = true;
			this.friendLogBox.Location = new System.Drawing.Point(6, 19);
			this.friendLogBox.Name = "friendLogBox";
			this.friendLogBox.Size = new System.Drawing.Size(259, 173);
			this.friendLogBox.TabIndex = 0;
			// 
			// friendIncludePartyCheckBox
			// 
			this.friendIncludePartyCheckBox.Location = new System.Drawing.Point(270, 101);
			this.friendIncludePartyCheckBox.Name = "friendIncludePartyCheckBox";
			this.friendIncludePartyCheckBox.Size = new System.Drawing.Size(234, 22);
			this.friendIncludePartyCheckBox.TabIndex = 68;
			this.friendIncludePartyCheckBox.Text = "Include party member in Friend List";
			this.friendIncludePartyCheckBox.CheckedChanged += new System.EventHandler(this.friendIncludePartyCheckBox_CheckedChanged);
			// 
			// friendAttackCheckBox
			// 
			this.friendAttackCheckBox.Location = new System.Drawing.Point(270, 76);
			this.friendAttackCheckBox.Name = "friendAttackCheckBox";
			this.friendAttackCheckBox.Size = new System.Drawing.Size(241, 22);
			this.friendAttackCheckBox.TabIndex = 67;
			this.friendAttackCheckBox.Text = "Prevent attacking friends in warmode";
			this.friendAttackCheckBox.CheckedChanged += new System.EventHandler(this.friendAttackCheckBox_CheckedChanged);
			// 
			// friendPartyCheckBox
			// 
			this.friendPartyCheckBox.Location = new System.Drawing.Point(270, 51);
			this.friendPartyCheckBox.Name = "friendPartyCheckBox";
			this.friendPartyCheckBox.Size = new System.Drawing.Size(241, 22);
			this.friendPartyCheckBox.TabIndex = 66;
			this.friendPartyCheckBox.Text = "Autoaccept party from Friends";
			this.friendPartyCheckBox.CheckedChanged += new System.EventHandler(this.friendPartyCheckBox_CheckedChanged);
			// 
			// friendlistView
			// 
			this.friendlistView.CheckBoxes = true;
			this.friendlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30});
			this.friendlistView.FullRowSelect = true;
			this.friendlistView.GridLines = true;
			this.friendlistView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.friendlistView.HideSelection = false;
			this.friendlistView.LabelWrap = false;
			this.friendlistView.Location = new System.Drawing.Point(6, 51);
			this.friendlistView.MultiSelect = false;
			this.friendlistView.Name = "friendlistView";
			this.friendlistView.Size = new System.Drawing.Size(255, 135);
			this.friendlistView.TabIndex = 64;
			this.friendlistView.UseCompatibleStateImageBehavior = false;
			this.friendlistView.View = System.Windows.Forms.View.Details;
			this.friendlistView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.friendlistView_PlayerChecked);
			// 
			// columnHeader28
			// 
			this.columnHeader28.Text = "X";
			this.columnHeader28.Width = 22;
			// 
			// columnHeader29
			// 
			this.columnHeader29.Text = "Name";
			this.columnHeader29.Width = 145;
			// 
			// columnHeader30
			// 
			this.columnHeader30.Text = "Serial";
			this.columnHeader30.Width = 75;
			// 
			// labelfriend
			// 
			this.labelfriend.AutoSize = true;
			this.labelfriend.Location = new System.Drawing.Point(6, 18);
			this.labelfriend.Name = "labelfriend";
			this.labelfriend.Size = new System.Drawing.Size(58, 13);
			this.labelfriend.TabIndex = 60;
			this.labelfriend.Text = "Friend List:";
			// 
			// friendButtonRemoveList
			// 
			this.friendButtonRemoveList.Location = new System.Drawing.Point(366, 12);
			this.friendButtonRemoveList.Name = "friendButtonRemoveList";
			this.friendButtonRemoveList.Size = new System.Drawing.Size(90, 21);
			this.friendButtonRemoveList.TabIndex = 63;
			this.friendButtonRemoveList.Text = "Remove";
			this.friendButtonRemoveList.Click += new System.EventHandler(this.friendButtonRemoveList_Click);
			// 
			// friendButtonAddList
			// 
			this.friendButtonAddList.Location = new System.Drawing.Point(270, 12);
			this.friendButtonAddList.Name = "friendButtonAddList";
			this.friendButtonAddList.Size = new System.Drawing.Size(90, 21);
			this.friendButtonAddList.TabIndex = 62;
			this.friendButtonAddList.Text = "Add";
			this.friendButtonAddList.Click += new System.EventHandler(this.friendButtonAddList_Click);
			// 
			// friendButtonImportList
			// 
			this.friendButtonImportList.Location = new System.Drawing.Point(462, 12);
			this.friendButtonImportList.Name = "friendButtonImportList";
			this.friendButtonImportList.Size = new System.Drawing.Size(90, 21);
			this.friendButtonImportList.TabIndex = 59;
			this.friendButtonImportList.Text = "Import";
			this.friendButtonImportList.Click += new System.EventHandler(this.friendButtonImportList_Click);
			// 
			// friendListSelect
			// 
			this.friendListSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.friendListSelect.FormattingEnabled = true;
			this.friendListSelect.Location = new System.Drawing.Point(78, 12);
			this.friendListSelect.Name = "friendListSelect";
			this.friendListSelect.Size = new System.Drawing.Size(183, 21);
			this.friendListSelect.TabIndex = 61;
			this.friendListSelect.SelectedIndexChanged += new System.EventHandler(this.friendListSelect_SelectedIndexChanged);
			// 
			// friendButtonExportList
			// 
			this.friendButtonExportList.Location = new System.Drawing.Point(558, 12);
			this.friendButtonExportList.Name = "friendButtonExportList";
			this.friendButtonExportList.Size = new System.Drawing.Size(90, 21);
			this.friendButtonExportList.TabIndex = 58;
			this.friendButtonExportList.Text = "Export";
			this.friendButtonExportList.Click += new System.EventHandler(this.friendButtonExportList_Click);
			// 
			// restock
			// 
			this.restock.Controls.Add(this.restockExecuteButton);
			this.restock.Controls.Add(this.restockStopButton);
			this.restock.Controls.Add(this.groupBox3);
			this.restock.Controls.Add(this.restockdataGridView);
			this.restock.Controls.Add(this.groupBox2);
			this.restock.Controls.Add(this.label13);
			this.restock.Controls.Add(this.label7);
			this.restock.Controls.Add(this.restockAddTargetButton);
			this.restock.Controls.Add(this.restockDragDelay);
			this.restock.Controls.Add(this.restockRemoveListB);
			this.restock.Controls.Add(this.restockAddListB);
			this.restock.Controls.Add(this.restockImportListB);
			this.restock.Controls.Add(this.restockListSelect);
			this.restock.Controls.Add(this.restockExportListB);
			this.restock.Location = new System.Drawing.Point(4, 22);
			this.restock.Name = "restock";
			this.restock.Padding = new System.Windows.Forms.Padding(3);
			this.restock.Size = new System.Drawing.Size(659, 341);
			this.restock.TabIndex = 7;
			this.restock.Text = "Restock";
			this.restock.UseVisualStyleBackColor = true;
			// 
			// restockExecuteButton
			// 
			this.restockExecuteButton.BackgroundImage = global::Assistant.Properties.Resources.playagent;
			this.restockExecuteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.restockExecuteButton.FlatAppearance.BorderSize = 0;
			this.restockExecuteButton.Location = new System.Drawing.Point(283, 58);
			this.restockExecuteButton.Name = "restockExecuteButton";
			this.restockExecuteButton.Size = new System.Drawing.Size(30, 30);
			this.restockExecuteButton.TabIndex = 93;
			this.restockExecuteButton.UseVisualStyleBackColor = true;
			this.restockExecuteButton.Click += new System.EventHandler(this.restockExecuteButton_Click);
			// 
			// restockStopButton
			// 
			this.restockStopButton.BackgroundImage = global::Assistant.Properties.Resources.stopagent;
			this.restockStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.restockStopButton.FlatAppearance.BorderSize = 0;
			this.restockStopButton.Location = new System.Drawing.Point(319, 58);
			this.restockStopButton.Name = "restockStopButton";
			this.restockStopButton.Size = new System.Drawing.Size(30, 30);
			this.restockStopButton.TabIndex = 92;
			this.restockStopButton.UseVisualStyleBackColor = true;
			this.restockStopButton.Click += new System.EventHandler(this.restockStopButton_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label59);
			this.groupBox3.Controls.Add(this.label58);
			this.groupBox3.Controls.Add(this.restockSetSourceButton);
			this.groupBox3.Controls.Add(this.restockSourceLabel);
			this.groupBox3.Controls.Add(this.restockDestinationLabel);
			this.groupBox3.Controls.Add(this.restockSetDestinationButton);
			this.groupBox3.Location = new System.Drawing.Point(9, 42);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(252, 65);
			this.groupBox3.TabIndex = 91;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Restock Bags";
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Location = new System.Drawing.Point(6, 42);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(63, 13);
			this.label59.TabIndex = 92;
			this.label59.Text = "Destination:";
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Location = new System.Drawing.Point(6, 18);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(44, 13);
			this.label58.TabIndex = 91;
			this.label58.Text = "Source:";
			// 
			// restockSetSourceButton
			// 
			this.restockSetSourceButton.Location = new System.Drawing.Point(156, 12);
			this.restockSetSourceButton.Name = "restockSetSourceButton";
			this.restockSetSourceButton.Size = new System.Drawing.Size(90, 21);
			this.restockSetSourceButton.TabIndex = 76;
			this.restockSetSourceButton.Text = "Set Bag";
			this.restockSetSourceButton.Click += new System.EventHandler(this.restockSetSourceButton_Click);
			// 
			// restockSourceLabel
			// 
			this.restockSourceLabel.Location = new System.Drawing.Point(71, 18);
			this.restockSourceLabel.Name = "restockSourceLabel";
			this.restockSourceLabel.Size = new System.Drawing.Size(82, 19);
			this.restockSourceLabel.TabIndex = 77;
			this.restockSourceLabel.Text = "0x00000000";
			// 
			// restockDestinationLabel
			// 
			this.restockDestinationLabel.Location = new System.Drawing.Point(71, 42);
			this.restockDestinationLabel.Name = "restockDestinationLabel";
			this.restockDestinationLabel.Size = new System.Drawing.Size(82, 19);
			this.restockDestinationLabel.TabIndex = 80;
			this.restockDestinationLabel.Text = "0x00000000";
			// 
			// restockSetDestinationButton
			// 
			this.restockSetDestinationButton.Location = new System.Drawing.Point(156, 38);
			this.restockSetDestinationButton.Name = "restockSetDestinationButton";
			this.restockSetDestinationButton.Size = new System.Drawing.Size(90, 21);
			this.restockSetDestinationButton.TabIndex = 79;
			this.restockSetDestinationButton.Text = "Set Bag";
			this.restockSetDestinationButton.Click += new System.EventHandler(this.restockSetDestinationButton_Click);
			// 
			// restockdataGridView
			// 
			this.restockdataGridView.AllowDrop = true;
			this.restockdataGridView.AllowUserToResizeRows = false;
			this.restockdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.restockdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn3,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
			this.restockdataGridView.Location = new System.Drawing.Point(9, 113);
			this.restockdataGridView.Name = "restockdataGridView";
			this.restockdataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.restockdataGridView.RowHeadersVisible = false;
			this.restockdataGridView.Size = new System.Drawing.Size(357, 220);
			this.restockdataGridView.TabIndex = 90;
			this.restockdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
			this.restockdataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.restockdataGridView_CellEndEdit);
			this.restockdataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_CellMouseUp);
			this.restockdataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.GridView_CurrentCellDirtyStateChanged);
			this.restockdataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridView_DataError);
			this.restockdataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.restockdataGridView_DefaultValuesNeeded);
			this.restockdataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridView_DragDrop);
			this.restockdataGridView.DragOver += new System.Windows.Forms.DragEventHandler(this.GridView_DragOver);
			this.restockdataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseDown);
			this.restockdataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridView_MouseMove);
			// 
			// dataGridViewCheckBoxColumn3
			// 
			this.dataGridViewCheckBoxColumn3.FalseValue = "False";
			this.dataGridViewCheckBoxColumn3.HeaderText = "X";
			this.dataGridViewCheckBoxColumn3.IndeterminateValue = "False";
			this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
			this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewCheckBoxColumn3.ToolTipText = "Check This for enable item in list";
			this.dataGridViewCheckBoxColumn3.TrueValue = "True";
			this.dataGridViewCheckBoxColumn3.Width = 22;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn9.HeaderText = "Item Name";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn9.ToolTipText = "Here the item name";
			this.dataGridViewTextBoxColumn9.Width = 153;
			// 
			// dataGridViewTextBoxColumn10
			// 
			this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn10.HeaderText = "Graphics";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn10.ToolTipText = "Here Graphics item ID";
			this.dataGridViewTextBoxColumn10.Width = 54;
			// 
			// dataGridViewTextBoxColumn11
			// 
			this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn11.HeaderText = "Color";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn11.ToolTipText = "Here item color, use -1 for all color";
			this.dataGridViewTextBoxColumn11.Width = 54;
			// 
			// dataGridViewTextBoxColumn12
			// 
			this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.dataGridViewTextBoxColumn12.HeaderText = "Limit";
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn12.ToolTipText = "Here amount limit to move";
			this.dataGridViewTextBoxColumn12.Width = 54;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.restockLogBox);
			this.groupBox2.Location = new System.Drawing.Point(373, 84);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(278, 251);
			this.groupBox2.TabIndex = 83;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Restock Log";
			// 
			// restockLogBox
			// 
			this.restockLogBox.FormattingEnabled = true;
			this.restockLogBox.Location = new System.Drawing.Point(7, 18);
			this.restockLogBox.Name = "restockLogBox";
			this.restockLogBox.Size = new System.Drawing.Size(265, 225);
			this.restockLogBox.TabIndex = 0;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(415, 54);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(105, 13);
			this.label13.TabIndex = 82;
			this.label13.Text = "Drag Item Delay (ms)";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 18);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 13);
			this.label7.TabIndex = 66;
			this.label7.Text = "Restock List:";
			// 
			// restockAddTargetButton
			// 
			this.restockAddTargetButton.Location = new System.Drawing.Point(558, 49);
			this.restockAddTargetButton.Name = "restockAddTargetButton";
			this.restockAddTargetButton.Size = new System.Drawing.Size(90, 21);
			this.restockAddTargetButton.TabIndex = 47;
			this.restockAddTargetButton.Text = "Add Item";
			this.restockAddTargetButton.Click += new System.EventHandler(this.restockAddTargetButton_Click);
			// 
			// restockDragDelay
			// 
			this.restockDragDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.restockDragDelay.BackColor = System.Drawing.Color.White;
			this.restockDragDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.restockDragDelay.Location = new System.Drawing.Point(369, 51);
			this.restockDragDelay.Name = "restockDragDelay";
			this.restockDragDelay.Size = new System.Drawing.Size(45, 20);
			this.restockDragDelay.TabIndex = 81;
			this.restockDragDelay.TextChanged += new System.EventHandler(this.restockDragDelay_TextChanged);
			// 
			// restockRemoveListB
			// 
			this.restockRemoveListB.Location = new System.Drawing.Point(366, 12);
			this.restockRemoveListB.Name = "restockRemoveListB";
			this.restockRemoveListB.Size = new System.Drawing.Size(90, 21);
			this.restockRemoveListB.TabIndex = 69;
			this.restockRemoveListB.Text = "Remove";
			this.restockRemoveListB.Click += new System.EventHandler(this.restockRemoveListB_Click);
			// 
			// restockAddListB
			// 
			this.restockAddListB.Location = new System.Drawing.Point(270, 12);
			this.restockAddListB.Name = "restockAddListB";
			this.restockAddListB.Size = new System.Drawing.Size(90, 21);
			this.restockAddListB.TabIndex = 68;
			this.restockAddListB.Text = "Add";
			this.restockAddListB.Click += new System.EventHandler(this.restockAddListB_Click);
			// 
			// restockImportListB
			// 
			this.restockImportListB.Location = new System.Drawing.Point(462, 12);
			this.restockImportListB.Name = "restockImportListB";
			this.restockImportListB.Size = new System.Drawing.Size(90, 21);
			this.restockImportListB.TabIndex = 65;
			this.restockImportListB.Text = "Import";
			this.restockImportListB.Click += new System.EventHandler(this.restockImportB_Click);
			// 
			// restockListSelect
			// 
			this.restockListSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.restockListSelect.FormattingEnabled = true;
			this.restockListSelect.Location = new System.Drawing.Point(78, 12);
			this.restockListSelect.Name = "restockListSelect";
			this.restockListSelect.Size = new System.Drawing.Size(183, 21);
			this.restockListSelect.TabIndex = 67;
			this.restockListSelect.SelectedIndexChanged += new System.EventHandler(this.restockListSelect_SelectedIndexChanged);
			// 
			// restockExportListB
			// 
			this.restockExportListB.Location = new System.Drawing.Point(558, 12);
			this.restockExportListB.Name = "restockExportListB";
			this.restockExportListB.Size = new System.Drawing.Size(90, 21);
			this.restockExportListB.TabIndex = 64;
			this.restockExportListB.Text = "Export";
			this.restockExportListB.Click += new System.EventHandler(this.restockExportListB_Click);
			// 
			// bandageheal
			// 
			this.bandageheal.Controls.Add(this.groupBox6);
			this.bandageheal.Controls.Add(this.groupBox5);
			this.bandageheal.Controls.Add(this.bandagehealenableCheckBox);
			this.bandageheal.Location = new System.Drawing.Point(4, 22);
			this.bandageheal.Name = "bandageheal";
			this.bandageheal.Padding = new System.Windows.Forms.Padding(3);
			this.bandageheal.Size = new System.Drawing.Size(659, 341);
			this.bandageheal.TabIndex = 8;
			this.bandageheal.Text = "Bandage Heal";
			this.bandageheal.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.bandagehealmaxrangeTextBox);
			this.groupBox6.Controls.Add(this.label46);
			this.groupBox6.Controls.Add(this.bandagehealcountdownCheckBox);
			this.groupBox6.Controls.Add(this.bandagehealhiddedCheckBox);
			this.groupBox6.Controls.Add(this.bandagehealmortalCheckBox);
			this.groupBox6.Controls.Add(this.bandagehealpoisonCheckBox);
			this.groupBox6.Controls.Add(this.label33);
			this.groupBox6.Controls.Add(this.bandagehealhpTextBox);
			this.groupBox6.Controls.Add(this.label32);
			this.groupBox6.Controls.Add(this.bandagehealdelayTextBox);
			this.groupBox6.Controls.Add(this.label31);
			this.groupBox6.Controls.Add(this.bandagehealdexformulaCheckBox);
			this.groupBox6.Controls.Add(this.bandagehealcustomcolorTextBox);
			this.groupBox6.Controls.Add(this.label30);
			this.groupBox6.Controls.Add(this.bandagehealcustomIDTextBox);
			this.groupBox6.Controls.Add(this.label19);
			this.groupBox6.Controls.Add(this.bandagehealcustomCheckBox);
			this.groupBox6.Controls.Add(this.bandagehealtargetLabel);
			this.groupBox6.Controls.Add(this.label15);
			this.groupBox6.Controls.Add(this.bandagehealsettargetButton);
			this.groupBox6.Controls.Add(this.bandagehealtargetComboBox);
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Location = new System.Drawing.Point(304, 43);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(347, 295);
			this.groupBox6.TabIndex = 74;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Settings";
			// 
			// bandagehealmaxrangeTextBox
			// 
			this.bandagehealmaxrangeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bandagehealmaxrangeTextBox.BackColor = System.Drawing.Color.White;
			this.bandagehealmaxrangeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bandagehealmaxrangeTextBox.Location = new System.Drawing.Point(77, 270);
			this.bandagehealmaxrangeTextBox.Name = "bandagehealmaxrangeTextBox";
			this.bandagehealmaxrangeTextBox.Size = new System.Drawing.Size(29, 20);
			this.bandagehealmaxrangeTextBox.TabIndex = 91;
			this.bandagehealmaxrangeTextBox.TextChanged += new System.EventHandler(this.bandagehealmaxrangeTextBox_TextChanged);
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.Location = new System.Drawing.Point(7, 273);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(65, 13);
			this.label46.TabIndex = 90;
			this.label46.Text = "Max Range:";
			// 
			// bandagehealcountdownCheckBox
			// 
			this.bandagehealcountdownCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bandagehealcountdownCheckBox.Location = new System.Drawing.Point(10, 246);
			this.bandagehealcountdownCheckBox.Name = "bandagehealcountdownCheckBox";
			this.bandagehealcountdownCheckBox.Size = new System.Drawing.Size(155, 22);
			this.bandagehealcountdownCheckBox.TabIndex = 89;
			this.bandagehealcountdownCheckBox.Text = "Show Heal Countdown";
			this.bandagehealcountdownCheckBox.CheckedChanged += new System.EventHandler(this.bandagehealcountdownCheckBox_CheckedChanged);
			// 
			// bandagehealhiddedCheckBox
			// 
			this.bandagehealhiddedCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bandagehealhiddedCheckBox.Location = new System.Drawing.Point(10, 218);
			this.bandagehealhiddedCheckBox.Name = "bandagehealhiddedCheckBox";
			this.bandagehealhiddedCheckBox.Size = new System.Drawing.Size(155, 22);
			this.bandagehealhiddedCheckBox.TabIndex = 88;
			this.bandagehealhiddedCheckBox.Text = "Block heal if Hidden";
			this.bandagehealhiddedCheckBox.CheckedChanged += new System.EventHandler(this.bandagehealhiddedCheckBox_CheckedChanged);
			// 
			// bandagehealmortalCheckBox
			// 
			this.bandagehealmortalCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bandagehealmortalCheckBox.Location = new System.Drawing.Point(10, 190);
			this.bandagehealmortalCheckBox.Name = "bandagehealmortalCheckBox";
			this.bandagehealmortalCheckBox.Size = new System.Drawing.Size(155, 22);
			this.bandagehealmortalCheckBox.TabIndex = 87;
			this.bandagehealmortalCheckBox.Text = "Block heal if Mortal struck";
			this.bandagehealmortalCheckBox.CheckedChanged += new System.EventHandler(this.bandagehealmortalCheckBox_CheckedChanged);
			// 
			// bandagehealpoisonCheckBox
			// 
			this.bandagehealpoisonCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bandagehealpoisonCheckBox.Location = new System.Drawing.Point(10, 162);
			this.bandagehealpoisonCheckBox.Name = "bandagehealpoisonCheckBox";
			this.bandagehealpoisonCheckBox.Size = new System.Drawing.Size(155, 22);
			this.bandagehealpoisonCheckBox.TabIndex = 86;
			this.bandagehealpoisonCheckBox.Text = "Block heal if Poisoned";
			this.bandagehealpoisonCheckBox.CheckedChanged += new System.EventHandler(this.bandagehealpoisonCheckBox_CheckedChanged);
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(135, 139);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(34, 13);
			this.label33.TabIndex = 85;
			this.label33.Text = "% hits";
			// 
			// bandagehealhpTextBox
			// 
			this.bandagehealhpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bandagehealhpTextBox.BackColor = System.Drawing.Color.White;
			this.bandagehealhpTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bandagehealhpTextBox.Location = new System.Drawing.Point(76, 136);
			this.bandagehealhpTextBox.Name = "bandagehealhpTextBox";
			this.bandagehealhpTextBox.Size = new System.Drawing.Size(53, 20);
			this.bandagehealhpTextBox.TabIndex = 84;
			this.bandagehealhpTextBox.TextChanged += new System.EventHandler(this.bandagehealhpTextBox_TextChanged);
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(7, 138);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(64, 13);
			this.label32.TabIndex = 83;
			this.label32.Text = "Start Below:";
			// 
			// bandagehealdelayTextBox
			// 
			this.bandagehealdelayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bandagehealdelayTextBox.BackColor = System.Drawing.Color.White;
			this.bandagehealdelayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bandagehealdelayTextBox.Location = new System.Drawing.Point(234, 103);
			this.bandagehealdelayTextBox.Name = "bandagehealdelayTextBox";
			this.bandagehealdelayTextBox.Size = new System.Drawing.Size(53, 20);
			this.bandagehealdelayTextBox.TabIndex = 82;
			this.bandagehealdelayTextBox.TextChanged += new System.EventHandler(this.bandagehealdelayTextBox_TextChanged);
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(153, 106);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(75, 13);
			this.label31.TabIndex = 81;
			this.label31.Text = "Custom Delay:";
			// 
			// bandagehealdexformulaCheckBox
			// 
			this.bandagehealdexformulaCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bandagehealdexformulaCheckBox.Location = new System.Drawing.Point(10, 102);
			this.bandagehealdexformulaCheckBox.Name = "bandagehealdexformulaCheckBox";
			this.bandagehealdexformulaCheckBox.Size = new System.Drawing.Size(155, 22);
			this.bandagehealdexformulaCheckBox.TabIndex = 80;
			this.bandagehealdexformulaCheckBox.Text = "Use DEX formula delay";
			this.bandagehealdexformulaCheckBox.CheckedChanged += new System.EventHandler(this.bandagehealdexformulaCheckBox_CheckedChanged);
			// 
			// bandagehealcustomcolorTextBox
			// 
			this.bandagehealcustomcolorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bandagehealcustomcolorTextBox.BackColor = System.Drawing.Color.White;
			this.bandagehealcustomcolorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bandagehealcustomcolorTextBox.Enabled = false;
			this.bandagehealcustomcolorTextBox.Location = new System.Drawing.Point(286, 76);
			this.bandagehealcustomcolorTextBox.Name = "bandagehealcustomcolorTextBox";
			this.bandagehealcustomcolorTextBox.Size = new System.Drawing.Size(53, 20);
			this.bandagehealcustomcolorTextBox.TabIndex = 79;
			this.bandagehealcustomcolorTextBox.TextChanged += new System.EventHandler(this.bandagehealcustomcolorTextBox_TextChanged);
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(246, 79);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(34, 13);
			this.label30.TabIndex = 78;
			this.label30.Text = "Color:";
			// 
			// bandagehealcustomIDTextBox
			// 
			this.bandagehealcustomIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bandagehealcustomIDTextBox.BackColor = System.Drawing.Color.White;
			this.bandagehealcustomIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bandagehealcustomIDTextBox.Enabled = false;
			this.bandagehealcustomIDTextBox.Location = new System.Drawing.Point(180, 75);
			this.bandagehealcustomIDTextBox.Name = "bandagehealcustomIDTextBox";
			this.bandagehealcustomIDTextBox.Size = new System.Drawing.Size(53, 20);
			this.bandagehealcustomIDTextBox.TabIndex = 77;
			this.bandagehealcustomIDTextBox.TextChanged += new System.EventHandler(this.bandagehealcustomIDTextBox_TextChanged);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(153, 78);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(21, 13);
			this.label19.TabIndex = 76;
			this.label19.Text = "ID:";
			// 
			// bandagehealcustomCheckBox
			// 
			this.bandagehealcustomCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bandagehealcustomCheckBox.Location = new System.Drawing.Point(10, 74);
			this.bandagehealcustomCheckBox.Name = "bandagehealcustomCheckBox";
			this.bandagehealcustomCheckBox.Size = new System.Drawing.Size(137, 22);
			this.bandagehealcustomCheckBox.TabIndex = 75;
			this.bandagehealcustomCheckBox.Text = "Use Custom Bandage";
			this.bandagehealcustomCheckBox.CheckedChanged += new System.EventHandler(this.bandagehealcustomCheckBox_CheckedChanged);
			// 
			// bandagehealtargetLabel
			// 
			this.bandagehealtargetLabel.AutoSize = true;
			this.bandagehealtargetLabel.Location = new System.Drawing.Point(73, 49);
			this.bandagehealtargetLabel.Name = "bandagehealtargetLabel";
			this.bandagehealtargetLabel.Size = new System.Drawing.Size(93, 13);
			this.bandagehealtargetLabel.TabIndex = 4;
			this.bandagehealtargetLabel.Text = "Null (0x00000000)";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(7, 49);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(41, 13);
			this.label15.TabIndex = 3;
			this.label15.Text = "Target:";
			// 
			// bandagehealsettargetButton
			// 
			this.bandagehealsettargetButton.Location = new System.Drawing.Point(213, 14);
			this.bandagehealsettargetButton.Name = "bandagehealsettargetButton";
			this.bandagehealsettargetButton.Size = new System.Drawing.Size(75, 23);
			this.bandagehealsettargetButton.TabIndex = 2;
			this.bandagehealsettargetButton.Text = "Set Target";
			this.bandagehealsettargetButton.UseVisualStyleBackColor = true;
			this.bandagehealsettargetButton.Click += new System.EventHandler(this.bandagehealsettargetButton_Click);
			// 
			// bandagehealtargetComboBox
			// 
			this.bandagehealtargetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.bandagehealtargetComboBox.FormattingEnabled = true;
			this.bandagehealtargetComboBox.Location = new System.Drawing.Point(76, 15);
			this.bandagehealtargetComboBox.Name = "bandagehealtargetComboBox";
			this.bandagehealtargetComboBox.Size = new System.Drawing.Size(121, 21);
			this.bandagehealtargetComboBox.TabIndex = 1;
			this.bandagehealtargetComboBox.SelectedIndexChanged += new System.EventHandler(this.bandagehealtargetComboBox_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(7, 20);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(66, 13);
			this.label14.TabIndex = 0;
			this.label14.Text = "Heal Target:";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.bandagehealLogBox);
			this.groupBox5.Location = new System.Drawing.Point(6, 6);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(278, 332);
			this.groupBox5.TabIndex = 54;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Bandage Heal Log";
			// 
			// bandagehealLogBox
			// 
			this.bandagehealLogBox.FormattingEnabled = true;
			this.bandagehealLogBox.Location = new System.Drawing.Point(7, 18);
			this.bandagehealLogBox.Name = "bandagehealLogBox";
			this.bandagehealLogBox.Size = new System.Drawing.Size(265, 303);
			this.bandagehealLogBox.TabIndex = 0;
			// 
			// bandagehealenableCheckBox
			// 
			this.bandagehealenableCheckBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bandagehealenableCheckBox.Location = new System.Drawing.Point(304, 15);
			this.bandagehealenableCheckBox.Name = "bandagehealenableCheckBox";
			this.bandagehealenableCheckBox.Size = new System.Drawing.Size(185, 22);
			this.bandagehealenableCheckBox.TabIndex = 73;
			this.bandagehealenableCheckBox.Text = "Enable Bandage Heal";
			this.bandagehealenableCheckBox.CheckedChanged += new System.EventHandler(this.bandagehealenableCheckBox_CheckedChanged);
			// 
			// enhancedHotKeytabPage
			// 
			this.enhancedHotKeytabPage.Controls.Add(this.groupBox8);
			this.enhancedHotKeytabPage.Controls.Add(this.groupBox28);
			this.enhancedHotKeytabPage.Controls.Add(this.groupBox27);
			this.enhancedHotKeytabPage.Controls.Add(this.hotkeytreeView);
			this.enhancedHotKeytabPage.Location = new System.Drawing.Point(4, 40);
			this.enhancedHotKeytabPage.Name = "enhancedHotKeytabPage";
			this.enhancedHotKeytabPage.Padding = new System.Windows.Forms.Padding(3);
			this.enhancedHotKeytabPage.Size = new System.Drawing.Size(666, 366);
			this.enhancedHotKeytabPage.TabIndex = 15;
			this.enhancedHotKeytabPage.Text = "Enhanced HotKey";
			this.enhancedHotKeytabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.hotkeyMasterClearButton);
			this.groupBox8.Controls.Add(this.hotkeyKeyMasterTextBox);
			this.groupBox8.Controls.Add(this.hotkeyMasterSetButton);
			this.groupBox8.Controls.Add(this.label42);
			this.groupBox8.Location = new System.Drawing.Point(502, 105);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(156, 84);
			this.groupBox8.TabIndex = 4;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Master Key";
			// 
			// hotkeyMasterClearButton
			// 
			this.hotkeyMasterClearButton.Location = new System.Drawing.Point(92, 50);
			this.hotkeyMasterClearButton.Name = "hotkeyMasterClearButton";
			this.hotkeyMasterClearButton.Size = new System.Drawing.Size(53, 23);
			this.hotkeyMasterClearButton.TabIndex = 5;
			this.hotkeyMasterClearButton.Text = "Clear";
			this.hotkeyMasterClearButton.UseVisualStyleBackColor = true;
			this.hotkeyMasterClearButton.Click += new System.EventHandler(this.hotkeyMasterClearButton_Click);
			// 
			// hotkeyKeyMasterTextBox
			// 
			this.hotkeyKeyMasterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hotkeyKeyMasterTextBox.BackColor = System.Drawing.Color.White;
			this.hotkeyKeyMasterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.hotkeyKeyMasterTextBox.Location = new System.Drawing.Point(41, 19);
			this.hotkeyKeyMasterTextBox.Name = "hotkeyKeyMasterTextBox";
			this.hotkeyKeyMasterTextBox.ReadOnly = true;
			this.hotkeyKeyMasterTextBox.Size = new System.Drawing.Size(104, 20);
			this.hotkeyKeyMasterTextBox.TabIndex = 5;
			this.hotkeyKeyMasterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotKey_KeyDown);
			this.hotkeyKeyMasterTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HotKey_KeyUp);
			this.hotkeyKeyMasterTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HotKey_MouseDown);
			this.hotkeyKeyMasterTextBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.HotKey_MouseRoll);
			// 
			// hotkeyMasterSetButton
			// 
			this.hotkeyMasterSetButton.Location = new System.Drawing.Point(10, 50);
			this.hotkeyMasterSetButton.Name = "hotkeyMasterSetButton";
			this.hotkeyMasterSetButton.Size = new System.Drawing.Size(53, 23);
			this.hotkeyMasterSetButton.TabIndex = 7;
			this.hotkeyMasterSetButton.Text = "Set";
			this.hotkeyMasterSetButton.UseVisualStyleBackColor = true;
			this.hotkeyMasterSetButton.Click += new System.EventHandler(this.hotkeyMasterSetButton_Click);
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.Location = new System.Drawing.Point(7, 22);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(28, 13);
			this.label42.TabIndex = 6;
			this.label42.Text = "Key:";
			// 
			// groupBox28
			// 
			this.groupBox28.Controls.Add(this.hotkeyMDisableButton);
			this.groupBox28.Controls.Add(this.hotkeyMEnableButton);
			this.groupBox28.Controls.Add(this.hotkeyKeyMasterLabel);
			this.groupBox28.Controls.Add(this.hotkeyStatusLabel);
			this.groupBox28.Location = new System.Drawing.Point(502, 7);
			this.groupBox28.Name = "groupBox28";
			this.groupBox28.Size = new System.Drawing.Size(156, 92);
			this.groupBox28.TabIndex = 3;
			this.groupBox28.TabStop = false;
			this.groupBox28.Text = "General";
			// 
			// hotkeyMDisableButton
			// 
			this.hotkeyMDisableButton.Location = new System.Drawing.Point(92, 58);
			this.hotkeyMDisableButton.Name = "hotkeyMDisableButton";
			this.hotkeyMDisableButton.Size = new System.Drawing.Size(53, 23);
			this.hotkeyMDisableButton.TabIndex = 8;
			this.hotkeyMDisableButton.Text = "Disable";
			this.hotkeyMDisableButton.UseVisualStyleBackColor = true;
			this.hotkeyMDisableButton.Click += new System.EventHandler(this.hotkeyDisableButton_Click);
			// 
			// hotkeyMEnableButton
			// 
			this.hotkeyMEnableButton.Location = new System.Drawing.Point(10, 58);
			this.hotkeyMEnableButton.Name = "hotkeyMEnableButton";
			this.hotkeyMEnableButton.Size = new System.Drawing.Size(53, 23);
			this.hotkeyMEnableButton.TabIndex = 9;
			this.hotkeyMEnableButton.Text = "Enable";
			this.hotkeyMEnableButton.UseVisualStyleBackColor = true;
			this.hotkeyMEnableButton.Click += new System.EventHandler(this.hotkeyEnableButton_Click);
			// 
			// hotkeyKeyMasterLabel
			// 
			this.hotkeyKeyMasterLabel.AutoSize = true;
			this.hotkeyKeyMasterLabel.Location = new System.Drawing.Point(7, 38);
			this.hotkeyKeyMasterLabel.Name = "hotkeyKeyMasterLabel";
			this.hotkeyKeyMasterLabel.Size = new System.Drawing.Size(101, 13);
			this.hotkeyKeyMasterLabel.TabIndex = 4;
			this.hotkeyKeyMasterLabel.Text = "ON/OFF Key: None";
			// 
			// hotkeyStatusLabel
			// 
			this.hotkeyStatusLabel.AutoSize = true;
			this.hotkeyStatusLabel.Location = new System.Drawing.Point(7, 16);
			this.hotkeyStatusLabel.Name = "hotkeyStatusLabel";
			this.hotkeyStatusLabel.Size = new System.Drawing.Size(82, 13);
			this.hotkeyStatusLabel.TabIndex = 3;
			this.hotkeyStatusLabel.Text = "Status: Enabled";
			// 
			// groupBox27
			// 
			this.groupBox27.Controls.Add(this.hotkeypassCheckBox);
			this.groupBox27.Controls.Add(this.hotkeyClearButton);
			this.groupBox27.Controls.Add(this.hotkeySetButton);
			this.groupBox27.Controls.Add(this.label39);
			this.groupBox27.Controls.Add(this.hotkeytextbox);
			this.groupBox27.Location = new System.Drawing.Point(502, 195);
			this.groupBox27.Name = "groupBox27";
			this.groupBox27.Size = new System.Drawing.Size(156, 107);
			this.groupBox27.TabIndex = 2;
			this.groupBox27.TabStop = false;
			this.groupBox27.Text = "Modify Key";
			// 
			// hotkeypassCheckBox
			// 
			this.hotkeypassCheckBox.Location = new System.Drawing.Point(10, 43);
			this.hotkeypassCheckBox.Name = "hotkeypassCheckBox";
			this.hotkeypassCheckBox.Size = new System.Drawing.Size(103, 22);
			this.hotkeypassCheckBox.TabIndex = 49;
			this.hotkeypassCheckBox.Text = "Pass Key to UO";
			this.hotkeypassCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// hotkeyClearButton
			// 
			this.hotkeyClearButton.Location = new System.Drawing.Point(92, 71);
			this.hotkeyClearButton.Name = "hotkeyClearButton";
			this.hotkeyClearButton.Size = new System.Drawing.Size(53, 23);
			this.hotkeyClearButton.TabIndex = 4;
			this.hotkeyClearButton.Text = "Clear";
			this.hotkeyClearButton.UseVisualStyleBackColor = true;
			this.hotkeyClearButton.Click += new System.EventHandler(this.hotkeyClearButton_Click);
			// 
			// hotkeySetButton
			// 
			this.hotkeySetButton.Location = new System.Drawing.Point(10, 71);
			this.hotkeySetButton.Name = "hotkeySetButton";
			this.hotkeySetButton.Size = new System.Drawing.Size(53, 23);
			this.hotkeySetButton.TabIndex = 3;
			this.hotkeySetButton.Text = "Set";
			this.hotkeySetButton.UseVisualStyleBackColor = true;
			this.hotkeySetButton.Click += new System.EventHandler(this.hotkeySetButton_Click);
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(7, 20);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(28, 13);
			this.label39.TabIndex = 2;
			this.label39.Text = "Key:";
			// 
			// hotkeytextbox
			// 
			this.hotkeytextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hotkeytextbox.BackColor = System.Drawing.Color.White;
			this.hotkeytextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.hotkeytextbox.Location = new System.Drawing.Point(41, 17);
			this.hotkeytextbox.Name = "hotkeytextbox";
			this.hotkeytextbox.ReadOnly = true;
			this.hotkeytextbox.Size = new System.Drawing.Size(104, 20);
			this.hotkeytextbox.TabIndex = 1;
			this.hotkeytextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotKey_KeyDown);
			this.hotkeytextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HotKey_KeyUp);
			this.hotkeytextbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HotKey_MouseDown);
			this.hotkeytextbox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.HotKey_MouseRoll);
			// 
			// hotkeytreeView
			// 
			this.hotkeytreeView.Location = new System.Drawing.Point(9, 7);
			this.hotkeytreeView.Name = "hotkeytreeView";
			this.hotkeytreeView.Size = new System.Drawing.Size(487, 353);
			this.hotkeytreeView.TabIndex = 0;
			this.hotkeytreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.hotkeytreeView_AfterSelect);
			// 
			// videoTab
			// 
			this.videoTab.BackColor = System.Drawing.SystemColors.Control;
			this.videoTab.Controls.Add(this.videoRecStatuslabel);
			this.videoTab.Controls.Add(this.label64);
			this.videoTab.Controls.Add(this.groupBox40);
			this.videoTab.Controls.Add(this.videosettinggroupBox);
			this.videoTab.Controls.Add(this.videorecbutton);
			this.videoTab.Controls.Add(this.videostopbutton);
			this.videoTab.Controls.Add(this.groupBox15);
			this.videoTab.Location = new System.Drawing.Point(4, 40);
			this.videoTab.Name = "videoTab";
			this.videoTab.Padding = new System.Windows.Forms.Padding(3);
			this.videoTab.Size = new System.Drawing.Size(666, 366);
			this.videoTab.TabIndex = 16;
			this.videoTab.Text = "Video Recorder";
			// 
			// videoRecStatuslabel
			// 
			this.videoRecStatuslabel.AutoSize = true;
			this.videoRecStatuslabel.ForeColor = System.Drawing.Color.Green;
			this.videoRecStatuslabel.Location = new System.Drawing.Point(185, 334);
			this.videoRecStatuslabel.Name = "videoRecStatuslabel";
			this.videoRecStatuslabel.Size = new System.Drawing.Size(24, 13);
			this.videoRecStatuslabel.TabIndex = 95;
			this.videoRecStatuslabel.Text = "Idle";
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(120, 334);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(63, 13);
			this.label64.TabIndex = 94;
			this.label64.Text = "Rec Status:";
			// 
			// groupBox40
			// 
			this.groupBox40.Controls.Add(this.videoSourcePlayer);
			this.groupBox40.Location = new System.Drawing.Point(259, 6);
			this.groupBox40.Name = "groupBox40";
			this.groupBox40.Size = new System.Drawing.Size(399, 352);
			this.groupBox40.TabIndex = 64;
			this.groupBox40.TabStop = false;
			this.groupBox40.Text = "Playback";
			// 
			// videoSourcePlayer
			// 
			this.videoSourcePlayer.Location = new System.Drawing.Point(7, 20);
			this.videoSourcePlayer.Name = "videoSourcePlayer";
			this.videoSourcePlayer.Size = new System.Drawing.Size(386, 321);
			this.videoSourcePlayer.TabIndex = 0;
			this.videoSourcePlayer.Text = "videoSourcePlayer";
			this.videoSourcePlayer.VideoSource = null;
			// 
			// videosettinggroupBox
			// 
			this.videosettinggroupBox.Controls.Add(this.videoCodecComboBox);
			this.videosettinggroupBox.Controls.Add(this.label63);
			this.videosettinggroupBox.Controls.Add(this.label62);
			this.videosettinggroupBox.Controls.Add(this.videoFPSTextBox);
			this.videosettinggroupBox.Location = new System.Drawing.Point(10, 250);
			this.videosettinggroupBox.Name = "videosettinggroupBox";
			this.videosettinggroupBox.Size = new System.Drawing.Size(243, 66);
			this.videosettinggroupBox.TabIndex = 63;
			this.videosettinggroupBox.TabStop = false;
			this.videosettinggroupBox.Text = "Video Settings";
			// 
			// videoCodecComboBox
			// 
			this.videoCodecComboBox.FormattingEnabled = true;
			this.videoCodecComboBox.Items.AddRange(new object[] {
            "Default",
            "MPEG4",
            "WMV1",
            "WMV2",
            "MSMPEG4v2",
            "MSMPEG4v3",
            "H263P",
            "FLV1",
            "MPEG2",
            "Raw",
            "FFV1",
            "FFVHUFF",
            "H264",
            "H265",
            "Theora",
            "VP8",
            "VP9"});
			this.videoCodecComboBox.Location = new System.Drawing.Point(122, 27);
			this.videoCodecComboBox.Name = "videoCodecComboBox";
			this.videoCodecComboBox.Size = new System.Drawing.Size(110, 21);
			this.videoCodecComboBox.TabIndex = 63;
			this.videoCodecComboBox.SelectedIndexChanged += new System.EventHandler(this.videoCodecComboBox_SelectedIndexChanged);
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.Location = new System.Drawing.Point(81, 31);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(41, 13);
			this.label63.TabIndex = 62;
			this.label63.Text = "Codec:";
			// 
			// label62
			// 
			this.label62.AutoSize = true;
			this.label62.Location = new System.Drawing.Point(7, 31);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(33, 13);
			this.label62.TabIndex = 61;
			this.label62.Text = "FPS: ";
			// 
			// videoFPSTextBox
			// 
			this.videoFPSTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.videoFPSTextBox.BackColor = System.Drawing.Color.White;
			this.videoFPSTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.videoFPSTextBox.Location = new System.Drawing.Point(42, 28);
			this.videoFPSTextBox.Name = "videoFPSTextBox";
			this.videoFPSTextBox.Size = new System.Drawing.Size(33, 20);
			this.videoFPSTextBox.TabIndex = 60;
			this.videoFPSTextBox.TextChanged += new System.EventHandler(this.videoFPSTextBox_TextChanged);
			// 
			// videorecbutton
			// 
			this.videorecbutton.BackgroundImage = global::Assistant.Properties.Resources.record;
			this.videorecbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.videorecbutton.FlatAppearance.BorderSize = 0;
			this.videorecbutton.Location = new System.Drawing.Point(43, 325);
			this.videorecbutton.Name = "videorecbutton";
			this.videorecbutton.Size = new System.Drawing.Size(30, 30);
			this.videorecbutton.TabIndex = 93;
			this.videorecbutton.UseVisualStyleBackColor = true;
			this.videorecbutton.Click += new System.EventHandler(this.videorecbutton_Click);
			// 
			// videostopbutton
			// 
			this.videostopbutton.BackgroundImage = global::Assistant.Properties.Resources.stopagent;
			this.videostopbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.videostopbutton.FlatAppearance.BorderSize = 0;
			this.videostopbutton.Location = new System.Drawing.Point(79, 325);
			this.videostopbutton.Name = "videostopbutton";
			this.videostopbutton.Size = new System.Drawing.Size(30, 30);
			this.videostopbutton.TabIndex = 92;
			this.videostopbutton.UseVisualStyleBackColor = true;
			this.videostopbutton.Click += new System.EventHandler(this.videostopbutton_Click);
			// 
			// groupBox15
			// 
			this.groupBox15.Controls.Add(this.videolistBox);
			this.groupBox15.Controls.Add(this.videoPathButton);
			this.groupBox15.Controls.Add(this.videoPathTextBox);
			this.groupBox15.Location = new System.Drawing.Point(8, 6);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(245, 238);
			this.groupBox15.TabIndex = 62;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "File";
			// 
			// videolistBox
			// 
			this.videolistBox.IntegralHeight = false;
			this.videolistBox.Location = new System.Drawing.Point(11, 41);
			this.videolistBox.Name = "videolistBox";
			this.videolistBox.Size = new System.Drawing.Size(223, 183);
			this.videolistBox.Sorted = true;
			this.videolistBox.TabIndex = 8;
			this.videolistBox.SelectedIndexChanged += new System.EventHandler(this.videoList_SelectedIndexChanged);
			this.videolistBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoList_MouseDown);
			// 
			// videoPathButton
			// 
			this.videoPathButton.Location = new System.Drawing.Point(212, 17);
			this.videoPathButton.Name = "videoPathButton";
			this.videoPathButton.Size = new System.Drawing.Size(22, 17);
			this.videoPathButton.TabIndex = 9;
			this.videoPathButton.Text = "...";
			this.videoPathButton.Click += new System.EventHandler(this.videoPathButton_Click);
			// 
			// videoPathTextBox
			// 
			this.videoPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.videoPathTextBox.BackColor = System.Drawing.Color.White;
			this.videoPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.videoPathTextBox.Location = new System.Drawing.Point(11, 15);
			this.videoPathTextBox.Name = "videoPathTextBox";
			this.videoPathTextBox.Size = new System.Drawing.Size(195, 20);
			this.videoPathTextBox.TabIndex = 10;
			// 
			// m_NotifyIcon
			// 
			this.m_NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_NotifyIcon.Icon")));
			this.m_NotifyIcon.Text = "Razor Enhanced";
			this.m_NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
			// 
			// openFileDialogscript
			// 
			this.openFileDialogscript.Filter = "Script Files|*.py";
			this.openFileDialogscript.RestoreDirectory = true;
			// 
			// timerupdatestatus
			// 
			this.timerupdatestatus.Enabled = true;
			this.timerupdatestatus.Interval = 1000;
			this.timerupdatestatus.Tick += new System.EventHandler(this.timerupdatestatus_Tick);
			// 
			// datagridMenuStrip
			// 
			this.datagridMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRowToolStripMenuItem});
			this.datagridMenuStrip.Name = "datagridMenuStrip";
			this.datagridMenuStrip.Size = new System.Drawing.Size(134, 26);
			this.datagridMenuStrip.Click += new System.EventHandler(this.datagridMenuStrip_Click);
			// 
			// deleteRowToolStripMenuItem
			// 
			this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
			this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.deleteRowToolStripMenuItem.Text = "Delete Row";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(674, 410);
			this.Controls.Add(this.tabs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Razor Enhanced {0}";
			this.Activated += new System.EventHandler(this.MainForm_Activated);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Move += new System.EventHandler(this.MainForm_Move);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.tabs.ResumeLayout(false);
			this.generalTab.ResumeLayout(false);
			this.generalTab.PerformLayout();
			this.groupBox29.ResumeLayout(false);
			this.groupBox29.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.opacity)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.moreOptTab.ResumeLayout(false);
			this.moreOptTab.PerformLayout();
			this.enhancedFilterTab.ResumeLayout(false);
			this.uomodgroupbox.ResumeLayout(false);
			this.groupBox32.ResumeLayout(false);
			this.groupBox32.PerformLayout();
			this.groupBox24.ResumeLayout(false);
			this.groupBox23.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.toolbarTab.ResumeLayout(false);
			this.toolbarstab.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox39.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.toolbar_trackBar)).EndInit();
			this.groupBox25.ResumeLayout(false);
			this.groupBox25.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox26.ResumeLayout(false);
			this.groupBox26.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.groupBox38.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spellgrid_trackBar)).EndInit();
			this.groupBox37.ResumeLayout(false);
			this.groupBox37.PerformLayout();
			this.groupBox36.ResumeLayout(false);
			this.groupBox36.PerformLayout();
			this.groupBox35.ResumeLayout(false);
			this.groupBox35.PerformLayout();
			this.emptyTab.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.skillsTab.ResumeLayout(false);
			this.skillsTab.PerformLayout();
			this.screenshotTab.ResumeLayout(false);
			this.screenshotTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.screenPrev)).EndInit();
			this.statusTab.ResumeLayout(false);
			this.scriptingTab.ResumeLayout(false);
			this.groupBox31.ResumeLayout(false);
			this.groupBox31.PerformLayout();
			this.groupBox30.ResumeLayout(false);
			this.groupBox30.PerformLayout();
			this.EnhancedAgent.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.eautoloot.ResumeLayout(false);
			this.eautoloot.PerformLayout();
			this.groupBox14.ResumeLayout(false);
			this.groupBox14.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.autolootdataGridView)).EndInit();
			this.groupBox13.ResumeLayout(false);
			this.escavenger.ResumeLayout(false);
			this.escavenger.PerformLayout();
			this.groupBox41.ResumeLayout(false);
			this.groupBox41.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.scavengerdataGridView)).EndInit();
			this.groupBox12.ResumeLayout(false);
			this.organizer.ResumeLayout(false);
			this.organizer.PerformLayout();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.organizerdataGridView)).EndInit();
			this.groupBox16.ResumeLayout(false);
			this.VendorBuy.ResumeLayout(false);
			this.VendorBuy.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.vendorbuydataGridView)).EndInit();
			this.groupBox18.ResumeLayout(false);
			this.VendorSell.ResumeLayout(false);
			this.VendorSell.PerformLayout();
			this.groupBox19.ResumeLayout(false);
			this.groupBox19.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.vendorsellGridView)).EndInit();
			this.groupBox20.ResumeLayout(false);
			this.Dress.ResumeLayout(false);
			this.Dress.PerformLayout();
			this.groupBox22.ResumeLayout(false);
			this.groupBox21.ResumeLayout(false);
			this.friends.ResumeLayout(false);
			this.friends.PerformLayout();
			this.groupBox34.ResumeLayout(false);
			this.groupBox33.ResumeLayout(false);
			this.friendGroupBox.ResumeLayout(false);
			this.friendloggroupBox.ResumeLayout(false);
			this.restock.ResumeLayout(false);
			this.restock.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.restockdataGridView)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.bandageheal.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.enhancedHotKeytabPage.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox28.ResumeLayout(false);
			this.groupBox28.PerformLayout();
			this.groupBox27.ResumeLayout(false);
			this.groupBox27.PerformLayout();
			this.videoTab.ResumeLayout(false);
			this.videoTab.PerformLayout();
			this.groupBox40.ResumeLayout(false);
			this.videosettinggroupBox.ResumeLayout(false);
			this.videosettinggroupBox.PerformLayout();
			this.groupBox15.ResumeLayout(false);
			this.groupBox15.PerformLayout();
			this.datagridMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion Windows Form Designer generated code


		protected override void WndProc(ref Message msg)
		{
			if (msg.Msg == 1025)
			{
				msg.Result = (IntPtr)(ClientCommunication.OnMessage(this, (uint)msg.WParam.ToInt32(), msg.LParam.ToInt32()) ? 1 : 0);
				return;
			}
			if (msg.Msg >= 1224 && msg.Msg <= 1338)
			{
				msg.Result = (IntPtr)ClientCommunication.OnUOAMessage(this, msg.Msg, msg.WParam.ToInt32(), msg.LParam.ToInt32());
				return;
			}
			base.WndProc(ref msg);
		}

		private void DisableCloseButton()
		{
			IntPtr menu = GetSystemMenu(this.Handle, false);
			EnableMenuItem(menu, 0xF060, 0x00000002); //menu, SC_CLOSE, MF_BYCOMMAND|MF_GRAYED
			m_CanClose = false;
		}

		private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
		{
			Assistant.Timer.Slice();
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			m_SystemTimer = new System.Timers.Timer(5);
			m_SystemTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
			Timer.SystemTimer = m_SystemTimer;

			this.Hide();

			bool st = RazorEnhanced.Settings.General.ReadBool("Systray");
			taskbar.Checked = this.ShowInTaskbar = !st;
			systray.Checked = m_NotifyIcon.Visible = st;

			UpdateTitle();

			if (!ClientCommunication.InstallHooks(this.Handle)) // WaitForInputIdle done here
			{
				m_CanClose = true;
				SplashScreen.End();
				this.Close();
				System.Diagnostics.Process.GetCurrentProcess().Kill();
				return;
			}

			InitConfig();

			this.Show();
			this.BringToFront();

			Engine.ActiveWindow = this;

			DisableCloseButton();

			tabs_IndexChanged(this, null); // load first tab

			m_Tip.Active = true;
			SplashScreen.End();

			// Avvio thread version check
			VersionCheck = new Thread(VersionCheckWorker);
			VersionCheck.Start();


		}

		internal void LoadSettings()
		{
			// -------------- SCRIPTING --------------------
			scriptTable = RazorEnhanced.Settings.Dataset.Tables["SCRIPTING"];
			ReloadScriptTable();

			// ---------------- AUTOLOOT -----------------
			RazorEnhanced.AutoLoot.RefreshLists();

			// ------------ SCAVENGER -------------------
			RazorEnhanced.Scavenger.RefreshLists();

			// ---------------- ORGANIZER ----------------
			RazorEnhanced.Organizer.RefreshLists();

			// ----------- SELL AGENT -----------------
			RazorEnhanced.SellAgent.RefreshLists();

			// ------------------- BUY AGENT ----------------------
			RazorEnhanced.BuyAgent.RefreshLists();

			// ------------------ DRESS AGENT -------------------------
			RazorEnhanced.Dress.RefreshLists();

			// ------------------ FRIEND -------------------------
			RazorEnhanced.Friend.RefreshLists();

			// ------------------ RESTOCK -------------------------
			RazorEnhanced.Restock.RefreshLists();

			// ------------------ BANDAGE HEAL --------------------
			RazorEnhanced.BandageHeal.LoadSettings();

			// ------------------ ENHANCED FILTERS --------------------
			RazorEnhanced.Filters.LoadSettings();

			// ------------------ ENHANCED TOOLBAR --------------------
			RazorEnhanced.ToolBar.LoadSettings();
			toolbar_trackBar.Value = RazorEnhanced.Settings.General.ReadInt("ToolBarOpacity");

			// ------------------ ENHANCED SPELLGRID --------------------
			RazorEnhanced.SpellGrid.LoadSettings();
			spellgrid_trackBar.Value = RazorEnhanced.Settings.General.ReadInt("GridOpacity");

			// ------------------ TARGETS --------------------
			RazorEnhanced.TargetGUI.RefreshTarget();

			// ------------------ HOTKEY --------------------
			RazorEnhanced.HotKey.Init();

			// ------------------ PARAMETRI GENERALI -------------------
			imgFmt.SelectedItem = RazorEnhanced.Settings.General.ReadString("ImageFormat");

			screenPath.Text = RazorEnhanced.Settings.General.ReadString("CapPath");
			radioUO.Checked = !(radioFull.Checked = RazorEnhanced.Settings.General.ReadBool("CapFullScreen"));
			imgFmt.SelectedItem = RazorEnhanced.Settings.General.ReadString("ImageFormat");
			dispTime.Checked = RazorEnhanced.Settings.General.ReadBool("CapTimeStamp");
			screenAutoCap.Checked = RazorEnhanced.Settings.General.ReadBool("AutoCap");
			Filter.Load();
			Filter.Draw(filters);
			smartCPU.Checked = RazorEnhanced.Settings.General.ReadBool("SmartCPU");
			if (smartCPU.Checked)
				ClientCommunication.ClientProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal;

			this.TopMost = alwaysTop.Checked = RazorEnhanced.Settings.General.ReadBool("AlwaysOnTop");
			rememberPwds.Checked = RazorEnhanced.Settings.General.ReadBool("RememberPwds");

			forceSizeX.Text = RazorEnhanced.Settings.General.ReadInt("ForceSizeX").ToString();
			forceSizeY.Text = RazorEnhanced.Settings.General.ReadInt("ForceSizeY").ToString();
			gameSize.Checked = RazorEnhanced.Settings.General.ReadBool("ForceSizeEnabled");

			notshowlauncher.Checked = RazorEnhanced.Settings.General.ReadBool("NotShowLauncher");
			forceSizeX.Enabled = forceSizeY.Enabled = gameSize.Checked;
			taskbar.Checked = !(systray.Checked = RazorEnhanced.Settings.General.ReadBool("Systray"));
			clientPrio.SelectedItem = RazorEnhanced.Settings.General.ReadString("ClientPrio");
			opacity.AutoSize = false;
			opacity.Value = RazorEnhanced.Settings.General.ReadInt("Opacity");
			this.Opacity = ((float)opacity.Value) / 100.0;
			opacityLabel.Text = String.Format("Opacity: {0}%", opacity.Value);
			msglvl.SelectedIndex = RazorEnhanced.Settings.General.ReadInt("MessageLevel");

			this.Location = new System.Drawing.Point(RazorEnhanced.Settings.General.ReadInt("WindowX"), RazorEnhanced.Settings.General.ReadInt("WindowY"));
			Assistant.Engine.MainWindowX = RazorEnhanced.Settings.General.ReadInt("WindowX");
			Assistant.Engine.MainWindowY = RazorEnhanced.Settings.General.ReadInt("WindowY");

			this.TopLevel = true;

			bool onScreen = false;
			foreach (Screen s in Screen.AllScreens)
			{
				if (s.Bounds.Contains(this.Location.X + this.Width, this.Location.Y + this.Height) ||
					s.Bounds.Contains(this.Location.X - this.Width, this.Location.Y - this.Height))
				{
					onScreen = true;
					break;
				}
			}

			if (!onScreen)
				this.Location = Point.Empty;

			dispDelta.Checked = RazorEnhanced.Settings.General.ReadBool("DisplaySkillChanges");
			actionStatusMsg.Checked = RazorEnhanced.Settings.General.ReadBool("ActionStatusMsg");
			QueueActions.Checked = RazorEnhanced.Settings.General.ReadBool("QueueActions");
			txtObjDelay.Text = RazorEnhanced.Settings.General.ReadInt("ObjectDelay").ToString();
			smartLT.Checked = RazorEnhanced.Settings.General.ReadBool("SmartLastTarget");
			ltRange.Enabled = rangeCheckLT.Checked = RazorEnhanced.Settings.General.ReadBool("RangeCheckLT");
			ltRange.Text = RazorEnhanced.Settings.General.ReadInt("LTRange").ToString();
			showtargtext.Checked = RazorEnhanced.Settings.General.ReadBool("LastTargTextFlags");
			healthFmt.Enabled = showHealthOH.Checked = RazorEnhanced.Settings.General.ReadBool("ShowHealth");
			healthFmt.Text = RazorEnhanced.Settings.General.ReadString("HealthFmt");
			chkPartyOverhead.Checked = RazorEnhanced.Settings.General.ReadBool("ShowPartyStats");
			preAOSstatbar.Checked = RazorEnhanced.Settings.General.ReadBool("OldStatBar");
			queueTargets.Checked = RazorEnhanced.Settings.General.ReadBool("QueueTargets");
			blockDis.Checked = RazorEnhanced.Settings.General.ReadBool("BlockDismount");
			autoStackRes.Checked = RazorEnhanced.Settings.General.ReadBool("AutoStack");
			corpseRange.Enabled = openCorpses.Checked = RazorEnhanced.Settings.General.ReadBool("AutoOpenCorpses");
			corpseRange.Text = RazorEnhanced.Settings.General.ReadInt("CorpseRange").ToString();
			spamFilter.Checked = RazorEnhanced.Settings.General.ReadBool("FilterSpam");
			filterSnoop.Checked = RazorEnhanced.Settings.General.ReadBool("FilterSnoopMsg");
			incomingMob.Checked = RazorEnhanced.Settings.General.ReadBool("ShowMobNames");
			negotiate.Checked = RazorEnhanced.Settings.General.ReadBool("Negotiate");
			incomingCorpse.Checked = RazorEnhanced.Settings.General.ReadBool("ShowCorpseNames");
			chkStealth.Checked = RazorEnhanced.Settings.General.ReadBool("CountStealthSteps");
			alwaysStealth.Checked = RazorEnhanced.Settings.General.ReadBool("AlwaysStealth");
			autoOpenDoors.Checked = hiddedAutoOpenDoors.Enabled = RazorEnhanced.Settings.General.ReadBool("AutoOpenDoors");
			hiddedAutoOpenDoors.Checked = RazorEnhanced.Settings.General.ReadBool("HiddedAutoOpenDoors");
			spellUnequip.Checked = RazorEnhanced.Settings.General.ReadBool("SpellUnequip");
			potionEquip.Checked = RazorEnhanced.Settings.General.ReadBool("PotionEquip");
			uo3dEquipUnEquip.Checked = RazorEnhanced.Settings.General.ReadBool("UO3dEquipUnEquip");
			autosearchcontainers.Checked = RazorEnhanced.Settings.General.ReadBool("AutoSearch");
			nosearchpouches.Checked = RazorEnhanced.Settings.General.ReadBool("NoSearchPouches");

			chkForceSpeechHue.Checked = setSpeechHue.Enabled = RazorEnhanced.Settings.General.ReadBool("ForceSpeechHue");
			chkForceSpellHue.Checked = setBeneHue.Enabled = setNeuHue.Enabled = setHarmHue.Enabled = RazorEnhanced.Settings.General.ReadBool("ForceSpellHue");
			if (RazorEnhanced.Settings.General.ReadInt("LTHilight") != 0)
			{
				InitPreviewHue(lthilight, "LTHilight");
				lthilight.Checked = setLTHilight.Enabled = true;
			}
			else
			{
				lthilight.Checked = setLTHilight.Enabled = false;
			}
			InitPreviewHue(lblExHue, "ExemptColor");
			InitPreviewHue(lblMsgHue, "SysColor");
			InitPreviewHue(lblWarnHue, "WarningColor");
			InitPreviewHue(chkForceSpeechHue, "SpeechHue");
			InitPreviewHue(lblBeneHue, "BeneficialSpellHue");
			InitPreviewHue(lblHarmHue, "HarmfulSpellHue");
			InitPreviewHue(lblNeuHue, "NeutralSpellHue");

			txtSpellFormat.Text = RazorEnhanced.Settings.General.ReadString("SpellFormat");

			// Script
			showscriptmessageCheckBox.Checked = RazorEnhanced.Settings.General.ReadBool("ShowScriptMessageCheckBox");

			// UoMod
			if (Engine.ClientMajor >= 7)
			{
				if (Engine.ClientBuild < 49)
				{
					uomodFPSCheckBox.Checked = RazorEnhanced.Settings.General.ReadBool("UoModFPS");
					uomodpaperdoolCheckBox.Checked = RazorEnhanced.Settings.General.ReadBool("UoModPaperdool");
					uomodglobalsoundCheckBox.Checked = RazorEnhanced.Settings.General.ReadBool("UoModSound");
				}
				else
					uomodgroupbox.Enabled = false;
			}
			else
			{
				uomodFPSCheckBox.Enabled = false;
				uomodpaperdoolCheckBox.Enabled = false;
				uomodglobalsoundCheckBox.Enabled = false;
			}

			// Video Recorder
			videoPathTextBox.Text = Settings.General.ReadString("VideoPath");
			videoFPSTextBox.Text = Settings.General.ReadInt("VideoFPS").ToString();
			videoCodecComboBox.SelectedIndex = Settings.General.ReadInt("VideoFormat");
		}

		private bool m_Initializing = false;
		internal bool Initializing
		{
			get { return m_Initializing; }
			set { m_Initializing = value; }
		}


		internal void InitConfig()
		{
			m_Initializing = true;
			LoadSettings();
			RazorEnhanced.Profiles.Refresh();

			// Init mappe ultima.dll
			Ultima.Map.InitializeMap("Felucca");
			Ultima.Map.InitializeMap("Trammel");
			Ultima.Map.InitializeMap("Ilshenar");
			Ultima.Map.InitializeMap("Malas");
			Ultima.Map.InitializeMap("Tokuno");
			Ultima.Map.InitializeMap("TerMur");

			m_Initializing = false;
		}

		private void tabs_IndexChanged(object sender, System.EventArgs e)
		{
			if (tabs == null)
				return;
			else if (tabs.SelectedTab == skillsTab)
			{
				RedrawSkills();
			}
			else if (tabs.SelectedTab == statusTab)
			{
				UpdateRazorStatus();
			}
			else if (tabs.SelectedTab == screenshotTab)
			{
				ReloadScreenShotsList();
			}
			else if (tabs.SelectedTab == scriptingTab)
			{
				UpdateScriptGrid();
			}
			else if (tabs.SelectedTab == videoTab)
			{
				ReloadVideoList();
			}
		}

		private Version m_Ver = System.Reflection.Assembly.GetCallingAssembly().GetName().Version;

		private uint m_OutPrev;
		private uint m_InPrev;

		private void UpdateRazorStatus()
		{
			if (!ClientCommunication.ClientRunning)
				Close();

			if (tabs.SelectedTab != statusTab)
				return;

			uint ps = m_OutPrev;
			uint pr = m_InPrev;
			m_OutPrev = ClientCommunication.TotalOut();
			m_InPrev = ClientCommunication.TotalIn();

			int time = 0;
			if (ClientCommunication.ConnectionStart != DateTime.MinValue)
				time = (int)((DateTime.Now - ClientCommunication.ConnectionStart).TotalSeconds);

			string status = Language.Format(LocString.RazorStatus1,
				m_Ver,
				Utility.FormatSize(System.GC.GetTotalMemory(false)),
				Utility.FormatSize(m_OutPrev), Utility.FormatSize((long)((m_OutPrev - ps))),
				Utility.FormatSize(m_InPrev), Utility.FormatSize((long)((m_InPrev - pr))),
				Utility.FormatTime(time),
				World.Player != null ? (uint)World.Player.Serial : 0,
				World.Player != null && World.Player.Backpack != null ? (uint)World.Player.Backpack.Serial : 0,
				World.Items.Count,
				World.Mobiles.Count);

			if (World.Player != null)
				status += String.Format("\r\nCoordinates\r\nX: {0}\r\nY: {1}\r\nZ: {2}", World.Player.Position.X, World.Player.Position.Y, World.Player.Position.Z);

			labelStatus.Text = status;
		}

		internal void UpdateSkill(Skill skill)
		{
			double Total = 0;
			for (int i = 0; i < Skill.Count; i++)
				Total += World.Player.Skills[i].Base;
			baseTotal.Text = String.Format("{0:F1}", Total);

			for (int i = 0; i < skillList.Items.Count; i++)
			{
				ListViewItem cur = skillList.Items[i];
				if (cur.Tag == skill)
				{
					cur.SubItems[1].Text = String.Format("{0:F1}", skill.Value);
					cur.SubItems[2].Text = String.Format("{0:F1}", skill.Base);
					cur.SubItems[3].Text = String.Format("{0}{1:F1}", (skill.Delta > 0 ? "+" : ""), skill.Delta);
					cur.SubItems[4].Text = String.Format("{0:F1}", skill.Cap);
					cur.SubItems[5].Text = skill.Lock.ToString()[0].ToString();
					SortSkills();
					return;
				}
			}
		}

		internal void RedrawSkills()
		{
			skillList.BeginUpdate();
			skillList.Items.Clear();
			double Total = 0;
			if (World.Player != null && World.Player.SkillsSent)
			{
				string[] items = new string[6];
				for (int i = 0; i < Skill.Count; i++)
				{
					Skill sk = World.Player.Skills[i];
					Total += sk.Base;
					items[0] = Language.Skill2Str(i);//((SkillName)i).ToString();
					items[1] = String.Format("{0:F1}", sk.Value);
					items[2] = String.Format("{0:F1}", sk.Base);
					items[3] = String.Format("{0}{1:F1}", (sk.Delta > 0 ? "+" : ""), sk.Delta);
					items[4] = String.Format("{0:F1}", sk.Cap);
					items[5] = sk.Lock.ToString()[0].ToString();

					ListViewItem lvi = new ListViewItem(items);
					lvi.Tag = sk;
					skillList.Items.Add(lvi);
				}

				//Config.SetProperty( "SkillListAsc", false );
				SortSkills();
			}
			skillList.EndUpdate();
			baseTotal.Text = String.Format("{0:F1}", Total);
		}

		private void OnFilterCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			((Filter)filters.Items[e.Index]).OnCheckChanged(e.NewValue);
		}

		private void incomingMob_CheckedChanged(object sender, System.EventArgs e)
		{
			if (incomingMob.Focused)
				RazorEnhanced.Settings.General.WriteBool("ShowMobNames", incomingMob.Checked);
		}

		private void incomingCorpse_CheckedChanged(object sender, System.EventArgs e)
		{
			if (incomingCorpse.Focused)
				RazorEnhanced.Settings.General.WriteBool("ShowCorpseNames", incomingCorpse.Checked);
		}

		private ContextMenu m_SkillMenu;

		private void skillList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ListView.SelectedListViewItemCollection items = skillList.SelectedItems;
				if (items.Count <= 0)
					return;
				Skill s = items[0].Tag as Skill;
				if (s == null)
					return;

				if (m_SkillMenu == null)
				{
					m_SkillMenu = new ContextMenu(new MenuItem[]
					{
						new MenuItem( Language.GetString( LocString.SetSLUp ), new EventHandler( onSetSkillLockUP ) ),
						new MenuItem( Language.GetString( LocString.SetSLDown ), new EventHandler( onSetSkillLockDOWN ) ),
						new MenuItem( Language.GetString( LocString.SetSLLocked ), new EventHandler( onSetSkillLockLOCKED ) ),
					});
				}

				for (int i = 0; i < 3; i++)
					m_SkillMenu.MenuItems[i].Checked = ((int)s.Lock) == i;

				m_SkillMenu.Show(skillList, new Point(e.X, e.Y));
			}
		}

		private void onSetSkillLockUP(object sender, EventArgs e)
		{
			SetLock(LockType.Up);
		}

		private void onSetSkillLockDOWN(object sender, EventArgs e)
		{
			SetLock(LockType.Down);
		}

		private void onSetSkillLockLOCKED(object sender, EventArgs e)
		{
			SetLock(LockType.Locked);
		}

		private void SetLock(LockType lockType)
		{
			ListView.SelectedListViewItemCollection items = skillList.SelectedItems;
			if (items.Count <= 0)
				return;
			Skill s = items[0].Tag as Skill;
			if (s == null)
				return;

			try
			{
				ClientCommunication.SendToServer(new SetSkillLock(s.Index, lockType));

				s.Lock = lockType;
				UpdateSkill(s);

				ClientCommunication.SendToClient(new SkillUpdate(s));
			}
			catch
			{
			}
		}

		private void OnSkillColClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			if (e.Column == RazorEnhanced.Settings.General.ReadInt("SkillListCol"))
				RazorEnhanced.Settings.General.WriteBool("SkillListAsc", !RazorEnhanced.Settings.General.ReadBool("SkillListAsc"));
			else
				RazorEnhanced.Settings.General.WriteInt("SkillListCol", e.Column);
			SortSkills();
		}

		private void SortSkills()
		{
			int col = RazorEnhanced.Settings.General.ReadInt("SkillListCol");
			bool asc = RazorEnhanced.Settings.General.ReadBool("SkillListAsc");

			if (col < 0 || col > 5)
				col = 0;

			skillList.BeginUpdate();
			if (col == 0 || col == 5)
			{
				skillList.ListViewItemSorter = null;
				skillList.Sorting = asc ? SortOrder.Ascending : SortOrder.Descending;
			}
			else
			{
				LVDoubleComparer.Column = col;
				LVDoubleComparer.Asc = asc;

				skillList.ListViewItemSorter = LVDoubleComparer.Instance;

				skillList.Sorting = SortOrder.None;
				skillList.Sort();
			}
			skillList.EndUpdate();
			skillList.Refresh();
		}

		private class LVDoubleComparer : IComparer
		{
			internal static readonly LVDoubleComparer Instance = new LVDoubleComparer();
			internal static int Column { set { Instance.m_Col = value; } }
			internal static bool Asc { set { Instance.m_Asc = value; } }

			private int m_Col;
			private bool m_Asc;

			private LVDoubleComparer()
			{
			}

			public int Compare(object x, object y)
			{
				if (x == null || !(x is ListViewItem))
					return m_Asc ? 1 : -1;
				else if (y == null || !(y is ListViewItem))
					return m_Asc ? -1 : 1;

				try
				{
					double dx = Convert.ToDouble(((ListViewItem)x).SubItems[m_Col].Text);
					double dy = Convert.ToDouble(((ListViewItem)y).SubItems[m_Col].Text);

					if (dx > dy)
						return m_Asc ? -1 : 1;
					else if (dx == dy)
						return 0;
					else //if ( dx > dy )
						return m_Asc ? 1 : -1;
				}
				catch
				{
					return ((ListViewItem)x).Text.CompareTo(((ListViewItem)y).Text) * (m_Asc ? 1 : -1);
				}
			}
		}

		private void OnResetSkillDelta(object sender, System.EventArgs e)
		{
			if (World.Player == null)
				return;

			for (int i = 0; i < Skill.Count; i++)
				World.Player.Skills[i].Delta = 0;

			RedrawSkills();
		}

		private void OnSetSkillLocks(object sender, System.EventArgs e)
		{
			if (locks.SelectedIndex == -1 || World.Player == null)
				return;

			LockType type = (LockType)locks.SelectedIndex;

			for (short i = 0; i < Skill.Count; i++)
			{
				World.Player.Skills[i].Lock = type;
				ClientCommunication.SendToServer(new SetSkillLock(i, type));
			}
			ClientCommunication.SendToClient(new SkillsList());
			RedrawSkills();
		}

		private void OnDispSkillCheck(object sender, System.EventArgs e)
		{
			RazorEnhanced.Settings.General.WriteBool("DispSkillChanges", dispDelta.Checked);
		}

		private void alwaysTop_CheckedChanged(object sender, System.EventArgs e)
		{
			if (alwaysTop.Focused)
				RazorEnhanced.Settings.General.WriteBool("AlwaysOnTop", this.TopMost = alwaysTop.Checked);
		}

		internal bool CanClose
		{
			get
			{
				return m_CanClose;
			}
			set
			{
				m_CanClose = value;
			}
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!m_CanClose && ClientCommunication.ClientRunning)
			{
				DisableCloseButton();
				e.Cancel = true;
			}
		}

		private void skillCopySel_Click(object sender, System.EventArgs e)
		{
			if (skillList.SelectedItems == null || skillList.SelectedItems.Count <= 0)
				return;

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < skillList.SelectedItems.Count; i++)
			{
				ListViewItem vi = skillList.SelectedItems[i];
				if (vi != null && vi.SubItems != null && vi.SubItems.Count > 4)
				{
					string name = vi.SubItems[0].Text;
					if (name != null && name.Length > 20)
						name = name.Substring(0, 16) + "...";

					sb.AppendFormat("{0,-20} {1,5:F1} {2,5:F1} {4:F1} {5,5:F1}\n",
						name,
						vi.SubItems[1].Text,
						vi.SubItems[2].Text,
						Utility.ToInt32(vi.SubItems[3].Text, 0) < 0 ? "" : "+",
						vi.SubItems[3].Text,
						vi.SubItems[4].Text);
				}
			}

			if (sb.Length > 0)
				Clipboard.SetDataObject(sb.ToString(), true);
		}

		private void skillCopyAll_Click(object sender, System.EventArgs e)
		{
			if (World.Player == null)
				return;

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < Skill.Count; i++)
			{
				Skill sk = World.Player.Skills[i];
				sb.AppendFormat("{0,-20} {1,-5:F1} {2,-5:F1} {3}{4,-5:F1} {5,-5:F1}\n", (SkillName)i, sk.Value, sk.Base, sk.Delta > 0 ? "+" : "", sk.Delta, sk.Cap);
			}

			if (sb.Length > 0)
				Clipboard.SetDataObject(sb.ToString(), true);
		}

		private void queueTargets_CheckedChanged(object sender, System.EventArgs e)
		{
			if (queueTargets.Focused)
				RazorEnhanced.Settings.General.WriteBool("QueueTargets", queueTargets.Checked);
		}

		private void chkForceSpeechHue_CheckedChanged(object sender, System.EventArgs e)
		{
			setSpeechHue.Enabled = chkForceSpeechHue.Checked;
			if (chkForceSpeechHue.Focused)
				RazorEnhanced.Settings.General.WriteBool("ForceSpeechHue", chkForceSpeechHue.Checked);
		}

		private void lthilight_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!(setLTHilight.Enabled = lthilight.Checked))
			{
				RazorEnhanced.Settings.General.WriteInt("LTHilight", 0);
				ClientCommunication.SetCustomNotoHue(0);
				lthilight.BackColor = SystemColors.Control;
				lthilight.ForeColor = SystemColors.ControlText;
			}
		}

		private void chkForceSpellHue_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkForceSpellHue.Checked)
			{
				setBeneHue.Enabled = setHarmHue.Enabled = setNeuHue.Enabled = true;
				RazorEnhanced.Settings.General.WriteBool("ForceSpellHue", true);
			}
			else
			{
				setBeneHue.Enabled = setHarmHue.Enabled = setNeuHue.Enabled = false;
				RazorEnhanced.Settings.General.WriteBool("ForceSpellHue", false);
			}
		}

		private void txtSpellFormat_TextChanged(object sender, System.EventArgs e)
		{
			if (txtSpellFormat.Focused)
				RazorEnhanced.Settings.General.WriteString("SpellFormat", txtSpellFormat.Text.Trim());
		}

		private void InitPreviewHue(Control ctrl, string cfg)
		{
			int hueIdx = RazorEnhanced.Settings.General.ReadInt(cfg);
			if (hueIdx > 0 && hueIdx < 3000)
			{
				if (ctrl.Name == "mapChatColorlabel")
					ctrl.ForeColor = Ultima.Hues.GetHue(hueIdx - 1).GetColor(HueEntry.TextHueIDX);
				else
					ctrl.BackColor = Ultima.Hues.GetHue(hueIdx - 1).GetColor(HueEntry.TextHueIDX);
			}
			else
			{
				if (ctrl.Name == "mapChatColorlabel")
					ctrl.ForeColor = SystemColors.Control;
				else
					ctrl.BackColor = SystemColors.Control;
			}

			if (ctrl.Name != "mapChatColorlabel")
				ctrl.ForeColor = (ctrl.BackColor.GetBrightness() < 0.35 ? System.Drawing.Color.White : System.Drawing.Color.Black);
		}

		private bool SetHue(Control ctrl, string cfg)
		{
			HueEntry h = new HueEntry(RazorEnhanced.Settings.General.ReadInt(cfg));

			if (h.ShowDialog(this) == DialogResult.OK)
			{
				int hueIdx = h.Hue;
				RazorEnhanced.Settings.General.WriteInt(cfg, hueIdx);
				if (hueIdx > 0 && hueIdx < 3000)
				{
					if (ctrl.Name == "mapChatColorlabel")
						ctrl.ForeColor = Ultima.Hues.GetHue(hueIdx - 1).GetColor(HueEntry.TextHueIDX);
					else
						ctrl.BackColor = Ultima.Hues.GetHue(hueIdx - 1).GetColor(HueEntry.TextHueIDX);
				}
				else
				{
					if (ctrl.Name == "mapChatColorlabel")
						ctrl.ForeColor = System.Drawing.Color.White;
					else
						ctrl.BackColor = System.Drawing.Color.White;
				}

				if (ctrl.Name != "mapChatColorlabel")
					ctrl.ForeColor = (ctrl.BackColor.GetBrightness() < 0.35 ? System.Drawing.Color.White : System.Drawing.Color.Black);

				return true;
			}
			else
			{
				return false;
			}
		}

		private void setExHue_Click(object sender, System.EventArgs e)
		{
			SetHue(lblExHue, "ExemptColor");
		}

		private void setMsgHue_Click(object sender, System.EventArgs e)
		{
			SetHue(lblMsgHue, "SysColor");
		}

		private void setWarnHue_Click(object sender, System.EventArgs e)
		{
			SetHue(lblWarnHue, "WarningColor");
		}

		private void setSpeechHue_Click(object sender, System.EventArgs e)
		{
			SetHue(chkForceSpeechHue, "SpeechHue");
		}

		private void setLTHilight_Click(object sender, System.EventArgs e)
		{
			if (SetHue(lthilight, "LTHilight"))
				ClientCommunication.SetCustomNotoHue(RazorEnhanced.Settings.General.ReadInt("LTHilight"));
		}

		private void setBeneHue_Click(object sender, System.EventArgs e)
		{
			SetHue(lblBeneHue, "BeneficialSpellHue");
		}

		private void setHarmHue_Click(object sender, System.EventArgs e)
		{
			SetHue(lblHarmHue, "HarmfulSpellHue");
		}

		private void setNeuHue_Click(object sender, System.EventArgs e)
		{
			SetHue(lblNeuHue, "NeutralSpellHue");
		}

		private void QueueActions_CheckedChanged(object sender, System.EventArgs e)
		{
			if (QueueActions.Focused)
				RazorEnhanced.Settings.General.WriteBool("QueueActions", QueueActions.Checked);
		}

		private void txtObjDelay_TextChanged(object sender, System.EventArgs e)
		{
			if (txtObjDelay.Focused)
				RazorEnhanced.Settings.General.WriteInt("ObjectDelay", Utility.ToInt32(txtObjDelay.Text.Trim(), 500));
		}

		private void chkStealth_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkStealth.Focused)
				RazorEnhanced.Settings.General.WriteBool("CountStealthSteps", chkStealth.Checked);
		}

		private void MainForm_Activated(object sender, System.EventArgs e)
		{
			DisableCloseButton();
		}

		private void MainForm_Deactivate(object sender, System.EventArgs e)
		{
			if (this.TopMost)
				this.TopMost = false;
		}

		private void MainForm_Resize(object sender, System.EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized && !this.ShowInTaskbar)
				this.Hide();
		}

		private void MainForm_Move(object sender, System.EventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized)
			{
				windowspt = this.Location;
				Assistant.Engine.MainWindowX = this.Location.X;
				Assistant.Engine.MainWindowY = this.Location.Y;
			}
		}

		private void opacity_Scroll(object sender, System.EventArgs e)
		{
			int o = opacity.Value;

			if (opacity.Focused)
				RazorEnhanced.Settings.General.WriteInt("Opacity", o);

			opacityLabel.Text = String.Format("Opacity: {0}%", o);
			this.Opacity = ((double)o) / 100.0;
		}

		private void dispDelta_CheckedChanged(object sender, System.EventArgs e)
		{
			if (dispDelta.Focused)
				RazorEnhanced.Settings.General.WriteBool("DisplaySkillChanges", dispDelta.Checked);
		}

		private void openCorpses_CheckedChanged(object sender, System.EventArgs e)
		{
			if (openCorpses.Focused)
				RazorEnhanced.Settings.General.WriteBool("AutoOpenCorpses", openCorpses.Checked);
			corpseRange.Enabled = openCorpses.Checked;
		}

		private void corpseRange_TextChanged(object sender, System.EventArgs e)
		{
			if (corpseRange.Focused)
				RazorEnhanced.Settings.General.WriteInt("CorpseRange", Utility.ToInt32(corpseRange.Text, 2));
		}

		private static char[] m_InvalidNameChars = new char[] { '/', '\\', ';', '?', ':', '*' };

		private void spamFilter_CheckedChanged(object sender, System.EventArgs e)
		{
			if (spamFilter.Focused)
				RazorEnhanced.Settings.General.WriteBool("FilterSpam", spamFilter.Checked);
		}

		private void screenAutoCap_CheckedChanged(object sender, System.EventArgs e)
		{
			if (screenAutoCap.Focused)
				RazorEnhanced.Settings.General.WriteBool("AutoCap", screenAutoCap.Checked);
		}

		private void setScnPath_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog folder = new FolderBrowserDialog();
			folder.Description = Language.GetString(LocString.SelSSFolder);
			folder.SelectedPath = RazorEnhanced.Settings.General.ReadString("CapPath");
			folder.ShowNewFolderButton = true;

			if (folder.ShowDialog(this) == DialogResult.OK)
			{
				RazorEnhanced.Settings.General.WriteString("CapPath", folder.SelectedPath);
				screenPath.Text = folder.SelectedPath;

				ReloadScreenShotsList();
			}
		}

		internal void ReloadScreenShotsList() 
		{
			ScreenCapManager.DisplayTo(screensList);
			if (screenPrev.Image != null)
			{
				screenPrev.Image.Dispose();
				screenPrev.Image = null;
			}
		}

		private void radioFull_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioFull.Checked)
			{
				radioUO.Checked = false;
				RazorEnhanced.Settings.General.WriteBool("CapFullScreen", true);
			}
		}

		private void radioUO_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioUO.Checked)
			{
				radioFull.Checked = false;
				RazorEnhanced.Settings.General.WriteBool("CapFullScreen", false);
			}
		}

		private void screensList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (screenPrev.Image != null)
			{
				screenPrev.Image.Dispose();
				screenPrev.Image = null;
			}

			if (screensList.SelectedIndex == -1)
				return;

			string file = Path.Combine(RazorEnhanced.Settings.General.ReadString("CapPath"), screensList.SelectedItem.ToString());
			if (!File.Exists(file))
			{
				MessageBox.Show(this, Language.Format(LocString.FileNotFoundA1, file), "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				screensList.Items.RemoveAt(screensList.SelectedIndex);
				screensList.SelectedIndex = -1;
				return;
			}

			using (Stream reader = new FileStream(file, FileMode.Open, FileAccess.Read))
			{
				screenPrev.Image = Image.FromStream(reader);
			}
		}

		private void screensList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.Clicks == 1)
			{
				ContextMenu menu = new ContextMenu();
				menu.MenuItems.Add("Delete", new EventHandler(DeleteScreenCap));
				if (screensList.SelectedIndex == -1)
					menu.MenuItems[menu.MenuItems.Count - 1].Enabled = false;
				menu.MenuItems.Add("Delete ALL", new EventHandler(ClearScreensDirectory));
				menu.Show(screensList, new Point(e.X, e.Y));
			}
		}

		private void DeleteScreenCap(object sender, System.EventArgs e)
		{
			int sel = screensList.SelectedIndex;
			if (sel == -1)
				return;

			string file = Path.Combine(RazorEnhanced.Settings.General.ReadString("CapPath"), (string)screensList.SelectedItem);
			if (MessageBox.Show(this, Language.Format(LocString.DelConf, file), "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			screensList.SelectedIndex = -1;
			if (screenPrev.Image != null)
			{
				screenPrev.Image.Dispose();
				screenPrev.Image = null;
			}

			try
			{
				File.Delete(file);
				screensList.Items.RemoveAt(sel);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ReloadScreenShotsList();
		}

		private void ClearScreensDirectory(object sender, System.EventArgs e)
		{
			string dir = RazorEnhanced.Settings.General.ReadString("CapPath");
			if (MessageBox.Show(this, Language.Format(LocString.Confirm, dir), "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			string[] files = Directory.GetFiles(dir, "*.jpg");
			StringBuilder sb = new StringBuilder();
			int failed = 0;
			for (int i = 0; i < files.Length; i++)
			{
				try
				{
					File.Delete(files[i]);
				}
				catch
				{
					sb.AppendFormat("{0}\n", files[i]);
					failed++;
				}
			}

			if (failed > 0)
				MessageBox.Show(this, Language.Format(LocString.FileDelError, failed, failed != 1 ? "s" : "", sb.ToString()), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			ReloadScreenShotsList();
		}

		private void capNow_Click(object sender, System.EventArgs e)
		{
			ScreenCapManager.CaptureNow();
		}

		private void dispTime_CheckedChanged(object sender, System.EventArgs e)
		{
			if (dispTime.Focused)
				RazorEnhanced.Settings.General.WriteBool("CapTimeStamp", dispTime.Checked);
		}

		private void taskbar_CheckedChanged(object sender, System.EventArgs e)
		{
			if (taskbar.Focused)
			{
				if (taskbar.Checked)
				{
					systray.Checked = false;
					RazorEnhanced.Settings.General.WriteBool("Systray", false);
					if (!this.ShowInTaskbar)
						MessageBox.Show(this, Language.GetString(LocString.NextRestart), "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void systray_CheckedChanged(object sender, System.EventArgs e)
		{
			if (systray.Focused)
			{
				if (systray.Checked)
				{
					taskbar.Checked = false;
					RazorEnhanced.Settings.General.WriteBool("Systray", true);
					if (this.ShowInTaskbar)
						MessageBox.Show(this, Language.GetString(LocString.NextRestart), "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		internal void UpdateTitle()
		{
			string str = Language.GetControlText(this.Name);
			if (str == null || str == "")
				str = "Razor Enhanced {0}";

			str = String.Format(str, Engine.Version);
			if (World.Player != null)
				this.Text = String.Format("{0} - {1} ({2})", str, World.Player.Name, World.ShardName);
			else
				this.Text = str;

			UpdateSystray();
		}

		internal void UpdateSystray()
		{
			if (m_NotifyIcon != null && m_NotifyIcon.Visible)
			{
				if (World.Player != null)
					m_NotifyIcon.Text = String.Format("Razor Enhanced - {0} ({1})", World.Player.Name, World.ShardName);
				else
					m_NotifyIcon.Text = "Razor Enhanced";
			}
		}

		private void DoShowMe(object sender, System.EventArgs e)
		{
			ShowMe();
		}

		internal void ShowMe()
		{
			// Fuck windows, seriously.

			ClientCommunication.BringToFront(this.Handle);
			if (RazorEnhanced.Settings.General.ReadBool("AlwaysOnTop"))
				this.TopMost = true;
			if (WindowState != FormWindowState.Normal)
				WindowState = FormWindowState.Normal;
		}

		private void HideMe(object sender, System.EventArgs e)
		{
			//this.WindowState = FormWindowState.Minimized;
			this.TopMost = false;
			this.SendToBack();
			this.Hide();
		}

		private void NotifyIcon_DoubleClick(object sender, System.EventArgs e)
		{
			ShowMe();
		}

		private void ToggleVisible(object sender, System.EventArgs e)
		{
			if (this.Visible)
				HideMe(sender, e);
			else
				ShowMe();
		}

		private void OnClose(object sender, System.EventArgs e)
		{
			m_CanClose = true;
			this.Close();
		}

		private void actionStatusMsg_CheckedChanged(object sender, System.EventArgs e)
		{
			if (actionStatusMsg.Focused)
				RazorEnhanced.Settings.General.WriteBool("ActionStatusMsg", actionStatusMsg.Checked);
		}

		private void autoStackRes_CheckedChanged(object sender, System.EventArgs e)
		{
			if (autoStackRes.Focused)
				RazorEnhanced.Settings.General.WriteBool("AutoStack", autoStackRes.Checked);
		}

		private void screenPath_TextChanged(object sender, System.EventArgs e)
		{
			RazorEnhanced.Settings.General.WriteString("CapPath", screenPath.Text);
		}

		private void rememberPwds_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rememberPwds.Focused)
				RazorEnhanced.Settings.General.WriteBool("RememberPwds", rememberPwds.Checked);
		}

		private bool m_isKeyPressed;
		private Keys m_lastKey;
		private void HotKey_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (!m_isKeyPressed || m_lastKey != e.KeyData)
				RazorEnhanced.HotKey.KeyDown(e.KeyData);
			m_isKeyPressed = true;
			m_lastKey = e.KeyData;
			e.SuppressKeyPress = true;
		}

		private void HotKey_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_isKeyPressed = false;
			m_lastKey = Keys.None;
		}

		private void HotKey_MouseRoll(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Delta > 0)
				RazorEnhanced.HotKey.KeyDown((Keys)502 | Control.ModifierKeys);
			else if (e.Delta < 0)
				RazorEnhanced.HotKey.KeyDown((Keys)501 | Control.ModifierKeys);
		}

		private void HotKey_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Middle)
				RazorEnhanced.HotKey.KeyDown((Keys)500 | Control.ModifierKeys);
			else if (e.Button == MouseButtons.XButton1)
				RazorEnhanced.HotKey.KeyDown((Keys)503 | Control.ModifierKeys);
			else if (e.Button == MouseButtons.XButton2)
				RazorEnhanced.HotKey.KeyDown((Keys)504 | Control.ModifierKeys);
		}

		private void spellUnequip_CheckedChanged(object sender, System.EventArgs e)
		{
			if (spellUnequip.Focused)
				RazorEnhanced.Settings.General.WriteBool("SpellUnequip", spellUnequip.Checked);
		}

		private void rangeCheckLT_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rangeCheckLT.Focused)
				RazorEnhanced.Settings.General.WriteBool("RangeCheckLT", rangeCheckLT.Checked);
			ltRange.Enabled = rangeCheckLT.Checked;
		}

		private void ltRange_TextChanged(object sender, System.EventArgs e)
		{
			if (ltRange.Focused)
				RazorEnhanced.Settings.General.WriteInt("LTRange", Utility.ToInt32(ltRange.Text, 11));
		}

		private void clientPrio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string str = (string)clientPrio.SelectedItem;

			if (clientPrio.Focused)
				RazorEnhanced.Settings.General.WriteString("ClientPrio", str);

			try
			{
				ClientCommunication.ClientProcess.PriorityClass = (System.Diagnostics.ProcessPriorityClass)Enum.Parse(typeof(System.Diagnostics.ProcessPriorityClass), str, true);
			}
			catch
			{
			}
		}

		private void filterSnoop_CheckedChanged(object sender, System.EventArgs e)
		{
			if (filterSnoop.Focused)
				RazorEnhanced.Settings.General.WriteBool("FilterSnoopMsg", filterSnoop.Checked);
		}

		private void preAOSstatbar_CheckedChanged(object sender, System.EventArgs e)
		{
			if (preAOSstatbar.Focused)
				RazorEnhanced.Settings.General.WriteBool("OldStatBar", preAOSstatbar.Checked);

			ClientCommunication.RequestStatbarPatch(preAOSstatbar.Checked);
			if (World.Player != null && !m_Initializing)
				MessageBox.Show(this, "Close and re-open your status bar for the change to take effect.", "Status Window Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void smartLT_CheckedChanged(object sender, System.EventArgs e)
		{
			if (smartLT.Focused)
				RazorEnhanced.Settings.General.WriteBool("SmartLastTarget", smartLT.Checked);
		}

		private void showtargtext_CheckedChanged(object sender, System.EventArgs e)
		{
			if (showtargtext.Focused)
				RazorEnhanced.Settings.General.WriteBool("LastTargTextFlags", showtargtext.Checked);
		}

		private void smartCPU_CheckedChanged(object sender, System.EventArgs e)
		{
			if (smartCPU.Focused)
				RazorEnhanced.Settings.General.WriteBool("SmartCPU", smartCPU.Checked);
			ClientCommunication.SetSmartCPU(smartCPU.Checked);
		}

		private void blockDis_CheckedChanged(object sender, System.EventArgs e)
		{
			if (blockDis.Focused)
				RazorEnhanced.Settings.General.WriteBool("BlockDismount", blockDis.Checked);
		}

		private void imgFmt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (imgFmt.SelectedIndex != -1)
				RazorEnhanced.Settings.General.WriteString("ImageFormat", imgFmt.SelectedItem.ToString());
			else
				RazorEnhanced.Settings.General.WriteString("ImageFormat", "jpg");
		}

		private void alwaysStealth_CheckedChanged(object sender, System.EventArgs e)
		{
			if (alwaysStealth.Focused)
				RazorEnhanced.Settings.General.WriteBool("AlwaysStealth", alwaysStealth.Checked);
		}

		private void autoOpenDoors_CheckedChanged(object sender, System.EventArgs e)
		{
			if (autoOpenDoors.Focused)
				RazorEnhanced.Settings.General.WriteBool("AutoOpenDoors", autoOpenDoors.Checked);

			hiddedAutoOpenDoors.Enabled = autoOpenDoors.Checked;
		}


		private void hiddedAutoOpenDoors_CheckedChanged(object sender, EventArgs e)
		{
			if (hiddedAutoOpenDoors.Focused)
				RazorEnhanced.Settings.General.WriteBool("HiddedAutoOpenDoors", hiddedAutoOpenDoors.Checked);
		}

		private void msglvl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (msglvl.Focused)
				RazorEnhanced.Settings.General.WriteInt("MessageLevel", msglvl.SelectedIndex);
		}

		private void screenPrev_Click(object sender, System.EventArgs e)
		{
			string file = screensList.SelectedItem as String;
			if (file != null)
				System.Diagnostics.Process.Start(Path.Combine(RazorEnhanced.Settings.General.ReadString("CapPath"), file));
		}

		private Timer m_ResizeTimer = Timer.DelayedCallback(TimeSpan.FromSeconds(1.0), new TimerCallback(ForceSize));

		private static void ForceSize()
		{
			int x, y;

			if (RazorEnhanced.Settings.General.ReadBool("ForceSizeEnabled"))
			{
				x = RazorEnhanced.Settings.General.ReadInt("ForceSizeX");
				y = RazorEnhanced.Settings.General.ReadInt("ForceSizeY");

				if (x > 100 && x < 2000 && y > 100 && y < 2000)
					ClientCommunication.SetGameSize(x, y);
				else
					MessageBox.Show(Engine.MainWindow, Language.GetString(LocString.ForceSizeBad), "Bad Size", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void gameSize_CheckedChanged(object sender, System.EventArgs e)
		{
			if (gameSize.Focused)
				RazorEnhanced.Settings.General.WriteBool("ForceSizeEnabled", gameSize.Checked);

			forceSizeX.Enabled = forceSizeY.Enabled = gameSize.Checked;

			if (gameSize.Checked)
			{
				int x = Utility.ToInt32(forceSizeX.Text, 800);
				int y = Utility.ToInt32(forceSizeY.Text, 600);

				if (x < 100 || y < 100 || x > 2000 || y > 2000)
					MessageBox.Show(this, Language.GetString(LocString.ForceSizeBad), "Bad Size", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				else
					ClientCommunication.SetGameSize(x, y);
			}
			else
			{
				ClientCommunication.SetGameSize(800, 600);
			}

			if (World.Player != null)
				MessageBox.Show(this, Language.GetString(LocString.RelogRequired), "Relog Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void forceSizeX_TextChanged(object sender, System.EventArgs e)
		{
			int x = Utility.ToInt32(forceSizeX.Text, 600);
			if (x >= 100 && x <= 3000)
				RazorEnhanced.Settings.General.WriteInt("ForceSizeX", x);

			if (!m_Initializing)
			{
				if (x > 100 && x < 3000)
				{
					m_ResizeTimer.Stop();
					m_ResizeTimer.Start();
				}
			}
		}

		private void notshowlauncher_CheckedChanged(object sender, EventArgs e)
		{
			if (notshowlauncher.Focused)
				RazorEnhanced.Settings.General.WriteBool("NotShowLauncher", notshowlauncher.Checked);
		}

		private void forceSizeY_TextChanged(object sender, System.EventArgs e)
		{
			int y = Utility.ToInt32(forceSizeY.Text, 600);
			if (y >= 100 && y <= 3000)
				RazorEnhanced.Settings.General.WriteInt("ForceSizeY", y);

			if (!m_Initializing)
			{
				if (y > 100 && y < 2000)
				{
					m_ResizeTimer.Stop();
					m_ResizeTimer.Start();
				}
			}
		}

		private void potionEquip_CheckedChanged(object sender, System.EventArgs e)
		{
			if (potionEquip.Focused)
				RazorEnhanced.Settings.General.WriteBool("PotionEquip", potionEquip.Checked);
		}

		private void uo3dEquipUnEquip_CheckedChanged(object sender, EventArgs e)
		{
			if (uo3dEquipUnEquip.Focused)
				RazorEnhanced.Settings.General.WriteBool("UO3DEquipUnEquip", uo3dEquipUnEquip.Checked);
		}

		private void autosearchcontainers_CheckedChanged(object sender, EventArgs e)
		{
			if (autosearchcontainers.Focused)
				RazorEnhanced.Settings.General.WriteBool("AutoSearch", autosearchcontainers.Checked);
		}

		private void nosearchpouches_CheckedChanged(object sender, EventArgs e)
		{
			if (nosearchpouches.Focused)
				RazorEnhanced.Settings.General.WriteBool("NoSearchPouches", nosearchpouches.Checked);
		}

		private void negotiate_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!m_Initializing)
			{
				if (negotiate.Focused)
					RazorEnhanced.Settings.General.WriteBool("Negotiate", negotiate.Checked);
				ClientCommunication.SetNegotiate(negotiate.Checked);
			}
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern IntPtr SetParent(IntPtr child, IntPtr newParent);

		private void showHealthOH_CheckedChanged(object sender, System.EventArgs e)
		{
			if (showHealthOH.Focused)
				RazorEnhanced.Settings.General.WriteBool("ShowHealth", showHealthOH.Checked);
			healthFmt.Enabled = showHealthOH.Checked;
		}

		private void healthFmt_TextChanged(object sender, System.EventArgs e)
		{
			if (healthFmt.Focused)
				RazorEnhanced.Settings.General.WriteString("HealthFmt", healthFmt.Text);
		}

		private void chkPartyOverhead_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkPartyOverhead.Focused)
				RazorEnhanced.Settings.General.WriteBool("ShowPartyStats", chkPartyOverhead.Checked);
		}

		// ------------------- SCRIPTING ----------------------------

		private static string LoadFromFile(string filename, bool wait, bool loop, bool run, bool autostart)
		{
			string status = "Loaded";
			string classname = Path.GetFileNameWithoutExtension(filename);
			string fullpath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Scripts", filename);
			string text = null;

			if (File.Exists(fullpath))
			{
				text = File.ReadAllText(fullpath);
			}
			else
			{
				return "ERROR: file not found";
			}

			Scripts.EnhancedScript script = new Scripts.EnhancedScript(filename, text, wait, loop, run, autostart);
			string result = script.Create(null);

			if (result == "Created")
			{
				Scripts.EnhancedScripts.TryAdd(filename, script);
			}
			else
			{
				status = "ERROR: " + result;
			}

			return status;
		}

		private void LoadAndInitializeScripts()
		{
			foreach (Scripts.EnhancedScript script in Scripts.EnhancedScripts.Values.ToList())
			{
				script.Stop();
				script.Reset();
			}

			Scripts.EnhancedScripts.Clear();

			scriptlistView.Items.Clear();

			DataTable scriptTable = RazorEnhanced.Settings.Dataset.Tables["SCRIPTING"];
			foreach (DataRow row in scriptTable.Rows)
			{
				string filename = (string)row["Filename"];
				bool wait = (bool)row["Wait"];
				bool loop = (bool)row["Loop"];
				string status = (string)row["Status"];
				bool passkey = (bool)row["HotKeyPass"];
				Keys key = (Keys)row["HotKey"];
				bool autostart = (bool)row["AutoStart"];

				bool run = false;
				if (status == "Running")
					run = true;

				string result = LoadFromFile(filename, wait, loop, run, autostart);

				if (result == "Loaded")
				{
					ListViewItem listitem = new ListViewItem();

					listitem.SubItems.Add(filename);

					listitem.SubItems.Add(status);

					if (loop)
						listitem.SubItems.Add("Yes");
					else
						listitem.SubItems.Add("No");

					if (autostart)
						listitem.SubItems.Add("Yes");
					else
						listitem.SubItems.Add("No");

					if (wait)
						listitem.SubItems.Add("Yes");
					else
						listitem.SubItems.Add("No");


					listitem.SubItems.Add(key.ToString());

					if (passkey)
						listitem.SubItems.Add("Yes");
					else
						listitem.SubItems.Add("No");

					scriptlistView.Items.Add(listitem);


					row["Flag"] = Assistant.Properties.Resources.red;
					row["Status"] = "Stopped";
				}
				else
				{
					ListViewItem listitem = new ListViewItem();

					listitem.SubItems.Add("File Not Found");

					listitem.SubItems.Add("Error");

					listitem.SubItems.Add("No");

					listitem.SubItems.Add("No");

					listitem.SubItems.Add("No");

					listitem.SubItems.Add(key.ToString());

					listitem.SubItems.Add("No");

					scriptlistView.Items.Add(listitem);


					row["Flag"] = Assistant.Properties.Resources.red;
					row["Status"] = "Error";
				}
			}
		}


		private void MoveDown()
		{
			if (scriptTable != null && scriptTable.Rows.Count > 0 && scriptlistView.SelectedItems.Count == 1)
			{
				int rowCount = scriptlistView.Items.Count;
				int index = scriptlistView.SelectedItems[0].Index;

				if (index >= rowCount - 1)
				{
					return;
				}

				DataRow newRow = scriptTable.NewRow();
				// We "clone" the row
				newRow.ItemArray = scriptTable.Rows[index + 1].ItemArray;
				// We remove the old and insert the new
				scriptTable.Rows.RemoveAt(index + 1);
				scriptTable.Rows.InsertAt(newRow, index);
				ReloadScriptTable();
				scriptlistView.Items[index + 1].Selected = true;
			}
		}

		private void MoveUp()
		{
			if (scriptTable != null && scriptTable.Rows.Count > 0 && scriptlistView.SelectedItems.Count == 1)
			{
				int rowCount = scriptlistView.Items.Count;
				int index = scriptlistView.SelectedItems[0].Index;

				if (index == 0) // include the header row
				{
					return;
				}

				DataRow newRow = scriptTable.NewRow();
				// We "clone" the row
				newRow.ItemArray = scriptTable.Rows[index - 1].ItemArray;
				// We remove the old and insert the new
				scriptTable.Rows.RemoveAt(index - 1);
				scriptTable.Rows.InsertAt(newRow, index);
				ReloadScriptTable();
				scriptlistView.Items[index - 1].Selected = true;
			}
		}

		internal void ReloadScriptTable()
		{
			RazorEnhanced.Settings.Save();
			LoadAndInitializeScripts();
			RazorEnhanced.HotKey.Init();
		}

		internal void UpdateScriptGridKey()
		{
			int i = 0;
			scriptlistView.BeginUpdate();
			DataTable scriptTable = RazorEnhanced.Settings.Dataset.Tables["SCRIPTING"];
			foreach (DataRow row in scriptTable.Rows)
			{
				bool passkey = (bool)row["HotKeyPass"];
				Keys key = (Keys)row["HotKey"];
				scriptlistView.Items[i].SubItems[5].Text = key.ToString();
				if (passkey)
					scriptlistView.Items[i].SubItems[6].Text = "Yes";
				else
					scriptlistView.Items[i].SubItems[6].Text = "No";
				i++;
			}
			scriptlistView.EndUpdate();
		}

		internal void UpdateScriptGrid()
		{

			if (tabs.SelectedTab != scriptingTab)
				return;

			if (scriptlistView.Items.Count > 0)
			{
				scriptlistView.BeginUpdate();
				try
				{
					foreach (ListViewItem litem in scriptlistView.Items)
					{
						string filename = litem.SubItems[1].Text;
						Scripts.EnhancedScript script = Scripts.Search(filename);
						{
							if (script != null)
							{
								if (script.Run)
								{
									litem.SubItems[2].Text = "Running";
								}
								else
								{
									litem.SubItems[2].Text = "Stopped";
								}
							}
						}
					}
				}
				finally
				{
					scriptlistView.EndUpdate();
				}
			}

		}

		private void RunCurrentScript(bool run)
		{
			if (scriptlistView.SelectedItems.Count == 1)
			{
				string filename = scriptlistView.SelectedItems[0].SubItems[1].Text;
				Scripts.EnhancedScript script = Scripts.Search(filename);
				if (script != null)
				{
					script.Run = run;
				}
			}
		}

		private void buttonScriptAdd_Click(object sender, EventArgs e)
		{
			DialogResult result = openFileDialogscript.ShowDialog();

			if (result == DialogResult.OK) // Test result.
			{
				string filename = Path.GetFileName(openFileDialogscript.FileName);
				string scriptPath = openFileDialogscript.FileName.Substring(0, openFileDialogscript.FileName.LastIndexOf("\\") + 1).ToLower();
				string razorPath = (Process.GetCurrentProcess().MainModule.FileName.Substring(0, Process.GetCurrentProcess().MainModule.FileName.LastIndexOf("\\") + 1) + "Scripts\\").ToLower();

				if (scriptPath == razorPath)
				{
					Scripts.EnhancedScript script = Scripts.Search(filename);
					if (script == null)
					{
						scriptTable.Rows.Add(filename, Properties.Resources.red, "Idle", false, false, false, Keys.None, false);
						ReloadScriptTable();
					}
				}
				else
				{
					MessageBox.Show("Error, Script file must be in Scripts folder!");
				}
			}
		}

		private void buttonScriptRefresh_Click(object sender, EventArgs e)
		{
			if (scriptTable != null && scriptTable.Rows.Count > 0 && scriptlistView.SelectedItems.Count == 1)
			{
				DataRow row = scriptTable.Rows[scriptlistView.SelectedItems[0].Index];
				string scriptname = row[0].ToString();
				Scripts.EnhancedScript script = Scripts.Search(scriptname);
				if (script != null)
				{
					string fullpath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Scripts",
						scriptname);

					if (File.Exists(fullpath) && Scripts.EnhancedScripts.ContainsKey(scriptname))
					{
						string text = File.ReadAllText(fullpath);
						bool loop = script.Loop;
						bool wait = script.Wait;
						bool run = script.Run;
						bool autostart = script.AutoStart;
						bool isRunning = script.IsRunning;

						if (isRunning)
							script.Stop();

						Scripts.EnhancedScript reloaded = new Scripts.EnhancedScript(scriptname, text, wait,
							loop, run, autostart);
						reloaded.Create(null);
						Scripts.EnhancedScripts[scriptname] = reloaded;

						if (isRunning)
							reloaded.Start();
					}
				}
			}
		}

		private void buttonScriptRemove_Click(object sender, EventArgs e)
		{
			if (scriptTable != null && scriptTable.Rows.Count > 0 && scriptlistView.SelectedItems.Count == 1)
			{
				DataRow row = scriptTable.Rows[scriptlistView.SelectedItems[0].Index];
				RunCurrentScript(false);
				scriptTable.Rows.Remove(row);
				ReloadScriptTable();
			}
		}

		private void buttonScriptDown_Click(object sender, EventArgs e)
		{
			MoveDown();
		}

		private void buttonScriptUp_Click(object sender, EventArgs e)
		{
			MoveUp();
		}

		private void buttonOpenEditor_Click(object sender, EventArgs e)
		{
			string fullPath = null;

			if (scriptTable != null && scriptTable.Rows.Count > 0 && scriptlistView.SelectedItems.Count == 1)
			{
				string filename = scriptlistView.SelectedItems[0].SubItems[1].Text;
				fullPath = (Process.GetCurrentProcess().MainModule.FileName.Substring(0, Process.GetCurrentProcess().MainModule.FileName.LastIndexOf("\\") + 1) + "Scripts\\") + filename;
			}

			EnhancedScriptEditor.Init(fullPath);
		}

		private void buttonScriptPlay_Click(object sender, EventArgs e)
		{
			if (scriptlistView.SelectedItems.Count == 1)
			{
				RunCurrentScript(true);
			}
		}

		private void buttonScriptStop_Click(object sender, EventArgs e)
		{
			if (scriptlistView.SelectedItems.Count == 1)
			{
				RunCurrentScript(false);
			}
		}

		private void textBoxEngineDelay_TextChanged(object sender, EventArgs e)
		{
			int millliseconds = 100;
			Int32.TryParse(textBoxDelay.Text, out millliseconds);
			TimeSpan delay = TimeSpan.FromMilliseconds(millliseconds);
			Scripts.TimerDelay = delay;
		}

		private void showscriptmessageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (showscriptmessageCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("ShowScriptMessageCheckBox", showscriptmessageCheckBox.Checked);
		}

		private void scriptlistView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (scriptlistView.SelectedItems.Count == 1)
			{
				scriptfilelabel.Text = "File: " + scriptlistView.SelectedItems[0].SubItems[1].Text;

				if (scriptlistView.SelectedItems[0].SubItems[3].Text == "Yes")
					scriptloopmodecheckbox.Checked = true;
				else
					scriptloopmodecheckbox.Checked = false;

				if (scriptlistView.SelectedItems[0].SubItems[4].Text == "Yes")
					scriptautostartcheckbox.Checked = true;
				else
					scriptautostartcheckbox.Checked = false;

				if (scriptlistView.SelectedItems[0].SubItems[5].Text == "Yes")
					scriptwaitmodecheckbox.Checked = true;
				else
					scriptwaitmodecheckbox.Checked = false;
			}
		}

		private void scriptautostartcheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (scriptautostartcheckbox.Focused && scriptlistView.SelectedItems.Count == 1)
			{
				if (scriptautostartcheckbox.Checked)
					scriptTable.Rows[scriptlistView.SelectedItems[0].Index]["AutoStart"] = true;
				else
					scriptTable.Rows[scriptlistView.SelectedItems[0].Index]["AutoStart"] = false;
				ReloadScriptTable();
			}
		}

		private void scriptloopmodecheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (scriptloopmodecheckbox.Focused && scriptlistView.SelectedItems.Count == 1)
			{
				if (scriptloopmodecheckbox.Checked)
					scriptTable.Rows[scriptlistView.SelectedItems[0].Index]["Loop"] = true;
				else
					scriptTable.Rows[scriptlistView.SelectedItems[0].Index]["Loop"] = false;
				ReloadScriptTable();
			}
		}

		private void scriptwaitmodecheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (scriptwaitmodecheckbox.Focused && scriptlistView.SelectedItems.Count == 1)
			{
				if (scriptwaitmodecheckbox.Checked)
					scriptTable.Rows[scriptlistView.SelectedItems[0].Index]["Wait"] = true;
				else
					scriptTable.Rows[scriptlistView.SelectedItems[0].Index]["Wait"] = false;
				ReloadScriptTable();
			}
		}

		// ------------------- SCRIPTING END ----------------------------

		private void razorButtonVisitUOD_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.uodreams.com");
			System.Diagnostics.Debug.WriteLine(sender.ToString() + " - " + e.ToString());
		}

		private void razorButtonCreateUODAccount_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.gamesnet.it/register.php");
		}

		private void razorButtonWiki_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://razorenhanced.org/");
		}

		private void discordrazorButton_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://discord.gg/P3Q7mKT");
		}

		private void openchangelogButton_Click(object sender, EventArgs e)
		{
			EnhancedChangeLog changelogform = new EnhancedChangeLog();
			changelogform.TopMost = true;
			changelogform.Show();
		}

		// ------------ AUTOLOOT ----------------

		private void autolootContainerButton_Click(object sender, EventArgs e)
		{
			if (autolootListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(autoLootSetContainerTarget_Callback));
			else
				RazorEnhanced.AutoLoot.AddLog("Item list not selected!");
		}

		private void autoLootSetContainerTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item autoLootBag = Assistant.World.FindItem(serial);

			if (autoLootBag == null)
				return;

			if (autoLootBag != null && autoLootBag.Serial.IsItem && autoLootBag.IsContainer && autoLootBag.RootContainer == Assistant.World.Player)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Autoloot Container set to: " + autoLootBag.ToString());
				RazorEnhanced.AutoLoot.AddLog("Autoloot Container set to: " + autoLootBag.ToString());
				AutoLoot.AutoLootBag = (int)autoLootBag.Serial.Value;
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Autoloot Container, set backpack");
				RazorEnhanced.AutoLoot.AddLog("Invalid Autoloot Container, set backpack");
				AutoLoot.AutoLootBag = (int)World.Player.Backpack.Serial.Value;
			}
			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Settings.AutoLoot.ListUpdate(autolootListSelect.Text, RazorEnhanced.AutoLoot.AutoLootDelay, serial, true, RazorEnhanced.AutoLoot.NoOpenCorpse, RazorEnhanced.AutoLoot.MaxRange); });
			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.AutoLoot.RefreshLists(); });
		}

		private void autoLootAddItemTarget_Click(object sender, EventArgs e)
		{
			if (autolootListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(autoLootItemTarget_Callback));
			else
				RazorEnhanced.AutoLoot.AddLog("Item list not selected!");
		}

		private void autoLootItemTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item autoLootItem = Assistant.World.FindItem(serial);
			if (autoLootItem != null && autoLootItem.Serial.IsItem)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Autoloot item added: " + autoLootItem.ToString());
				RazorEnhanced.AutoLoot.AddLog("Autoloot item added: " + autoLootItem.ToString());
				this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.AutoLoot.AddItemToList(autoLootItem.Name, autoLootItem.ItemID, autoLootItem.Hue); });
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid target");
				RazorEnhanced.AutoLoot.AddLog("Invalid target");
			}
		}

		private void autoLootItemProps_Click(object sender, EventArgs e)
		{
			if (autolootListSelect.Text != "")
			{
				DataGridViewRow row = autolootdataGridView.Rows[autolootdataGridView.CurrentCell.RowIndex];
				EnhancedAutolootEditItemProps editProp = new EnhancedAutolootEditItemProps(ref row);
				editProp.TopMost = true;
				editProp.Show();
			}
			else
				RazorEnhanced.AutoLoot.AddLog("Item list not selected!");
		}

		private void autoLootEnable_CheckedChanged(object sender, EventArgs e)
		{
			if (World.Player != null)
			{
				if (autolootListSelect.Text != "")
				{
					if (autoLootCheckBox.Checked)
					{
						int delay = -1;
						autolootListSelect.Enabled = false;
						autolootButtonAddList.Enabled = false;
						autoLootButtonListExport.Enabled = false;
						autoLootButtonListImport.Enabled = false;
						autoLootButtonRemoveList.Enabled = false;
						autoLootTextBoxDelay.Enabled = false;
						try
						{
							delay = Convert.ToInt32(autoLootTextBoxDelay.Text);
						}
						catch
						{
							RazorEnhanced.AutoLoot.AutoMode = false;
							RazorEnhanced.AutoLoot.AddLog("ERROR: Loot item delay is not valid");
							return;
						}

						if (delay < 0)
						{
							RazorEnhanced.AutoLoot.AutoMode = false;
							RazorEnhanced.AutoLoot.AddLog("ERROR: Loot item delay is not valid");
							return;
						}
						RazorEnhanced.AutoLoot.ResetIgnore();
						RazorEnhanced.AutoLoot.AutoMode = true;
						RazorEnhanced.DragDropManager.HoldingItem = false;
						RazorEnhanced.AutoLoot.AddLog("Autoloot Engine Start...");
						if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
							RazorEnhanced.Misc.SendMessage("AUTOLOOT: Engine Start...");
					}
					else
					{
						autolootListSelect.Enabled = true;
						autolootButtonAddList.Enabled = true;
						autoLootButtonListExport.Enabled = true;
						autoLootButtonListImport.Enabled = true;
						autoLootButtonRemoveList.Enabled = true;
						autoLootTextBoxDelay.Enabled = true;

						// Stop autoloot
						RazorEnhanced.AutoLoot.AutoMode = false;
						RazorEnhanced.DragDropManager.HoldingItem = false;
						if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
							RazorEnhanced.Misc.SendMessage("AUTOLOOT: Engine Stop...");
						RazorEnhanced.AutoLoot.AddLog("Autoloot Engine Stop...");
					}
				}
				else
				{
					autoLootCheckBox.Checked = false;
					RazorEnhanced.AutoLoot.AddLog("Item list not selected!");
				}
			}
			else
			{
				autoLootCheckBox.Checked = false;
				RazorEnhanced.AutoLoot.AddLog("You are not logged in game!");
			}
		}

		private void autoLootListSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			int bag = 0;
			int delay = 0;
			int maxrange = 0;
			bool noopencorpse = false;
			RazorEnhanced.Settings.AutoLoot.ListDetailsRead(autolootListSelect.Text, out bag, out delay, out noopencorpse, out maxrange);
			RazorEnhanced.AutoLoot.AutoLootBag = bag;
			RazorEnhanced.AutoLoot.AutoLootDelay = delay;
			RazorEnhanced.AutoLoot.NoOpenCorpse = noopencorpse;
			RazorEnhanced.AutoLoot.MaxRange = maxrange;

			RazorEnhanced.Settings.AutoLoot.ListUpdate(autolootListSelect.Text, delay, bag, true, noopencorpse, maxrange);
			RazorEnhanced.AutoLoot.InitGrid();

			if (autolootListSelect.Text != "")
				RazorEnhanced.AutoLoot.AddLog("Autoloot list changed to: " + autolootListSelect.Text);
		}

		private void autoLootTextBoxDelay_TextChanged(object sender, EventArgs e)
		{
			if (autoLootTextBoxDelay.Focused)
			{
				RazorEnhanced.Settings.AutoLoot.ListUpdate(autolootListSelect.Text, AutoLoot.AutoLootDelay, AutoLoot.AutoLootBag, true, AutoLoot.NoOpenCorpse, AutoLoot.MaxRange);
				RazorEnhanced.AutoLoot.RefreshLists();
			}
		}

		private void autoLootnoopenCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (autoLootnoopenCheckBox.Focused)
			{
				RazorEnhanced.Settings.AutoLoot.ListUpdate(autolootListSelect.Text, AutoLoot.AutoLootDelay, AutoLoot.AutoLootBag, true, AutoLoot.NoOpenCorpse, AutoLoot.MaxRange);
				RazorEnhanced.AutoLoot.RefreshLists();
			}
		}

		private void autoLootButtonAddList_Click(object sender, EventArgs e)
		{
			EnhancedAgentAddList AddItemList = new EnhancedAgentAddList(1);
			AddItemList.TopMost = true;
			AddItemList.Show();
		}

		private void autoLootButtonRemoveList_Click(object sender, EventArgs e)
		{
			if (autolootListSelect.Text != "")
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure to delete this AutoLoot list: " + autolootListSelect.Text, "Delete AutoLoot List?", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					RazorEnhanced.AutoLoot.AddLog("Autoloot list " + autolootListSelect.Text + " removed!");
					RazorEnhanced.AutoLoot.AutoLootBag = 0;
					RazorEnhanced.AutoLoot.RemoveList(autolootListSelect.Text);
				}
			}
		}

		private void autoLootButtonListExport_Click(object sender, EventArgs e)
		{
			if (autolootListSelect.Text != "")
				RazorEnhanced.ImportExport.ExportAutoloot(autolootListSelect.Text);
			else
				RazorEnhanced.AutoLoot.AddLog("Item list not selected!");
		}

		private void autoLootImport_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ImportExport.ImportAutoloot();
		}

		private void autoLootTextBoxMaxRange_TextChanged(object sender, EventArgs e)
		{
			if (autoLootTextBoxMaxRange.Focused)
			{
				RazorEnhanced.Settings.AutoLoot.ListUpdate(autolootListSelect.Text, RazorEnhanced.AutoLoot.AutoLootDelay, RazorEnhanced.AutoLoot.AutoLootBag, true, RazorEnhanced.AutoLoot.NoOpenCorpse, RazorEnhanced.AutoLoot.MaxRange);
				RazorEnhanced.AutoLoot.RefreshLists();
			}
		}

		private void autolootdataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewCell cell = autolootdataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

			if (e.ColumnIndex == 3)
			{
				if (cell.Value.ToString() == "-1")
				{
					cell.Value = "All";
				}
				else
				{
					int color = 0;
					if (!cell.Value.ToString().Contains("-"))
					{
						try
						{
							color = Convert.ToInt32((string)cell.Value, 16);
						}
						catch { }

						if (color > 65535)
							color = 65535;
					}
					cell.Value = "0x" + color.ToString("X4");
				}
			}
			else if (e.ColumnIndex == 2)
			{
				int itemid = 0;
				if (!cell.Value.ToString().Contains("-"))
				{
					try
					{
						itemid = Convert.ToInt32((string)cell.Value, 16);
					}
					catch { }

					if (itemid > 65535)
						itemid = 65535;
				}
				cell.Value = "0x" + itemid.ToString("X4");
			}
			RazorEnhanced.AutoLoot.CopyTable();
		}

		private void autolootdataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells[0].Value = false;
			e.Row.Cells[1].Value = "New Item";
			e.Row.Cells[2].Value = "0x0000";
			e.Row.Cells[3].Value = "0x0000";
			e.Row.Cells[4].Value = null;
		}

		// ------------ AUTOLOOT END ----------------

		// ------------ SCAVENGER ----------------

		private void scavengerEditProps_Click(object sender, EventArgs e)
		{
			if (scavengerListSelect.Text != "")
			{
				DataGridViewRow row = scavengerdataGridView.Rows[scavengerdataGridView.CurrentCell.RowIndex];
				EnhancedScavengerEditItemProps editProp = new EnhancedScavengerEditItemProps(ref row);
				editProp.TopMost = true;
				editProp.Show();
			}
			else
				RazorEnhanced.Scavenger.AddLog("Item list not selected!");
		}

		private void scavengerAddItemTarget_Click(object sender, EventArgs e)
		{
			if (scavengerListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(ScavengerItemTarget_Callback));
			else
				RazorEnhanced.Scavenger.AddLog("Item list not selected!");
		}

		private void ScavengerItemTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item scavengerItem = Assistant.World.FindItem(serial);
			if (scavengerItem != null && scavengerItem.Serial.IsItem)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Scavenger item added: " + scavengerItem.ToString());
				RazorEnhanced.Scavenger.AddLog("Scavenger item added: " + scavengerItem.ToString());
				this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Scavenger.AddItemToList(scavengerItem.Name, scavengerItem.ItemID, scavengerItem.Hue); });
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid target");
				RazorEnhanced.Scavenger.AddLog("Invalid target");
			}
		}

		private void scavengerSetContainer_Click(object sender, EventArgs e)
		{
			if (scavengerListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(ScavengerItemContainerTarget_Callback));
			else
				RazorEnhanced.Scavenger.AddLog("Item list not selected!");
		}

		private void ScavengerItemContainerTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item scavengerBag = Assistant.World.FindItem(serial);

			if (scavengerBag == null)
				return;

			if (scavengerBag != null && scavengerBag.Serial.IsItem && scavengerBag.IsContainer && scavengerBag.RootContainer == Assistant.World.Player)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Scavenger Container set to: " + scavengerBag.ToString());
				RazorEnhanced.Scavenger.AddLog("Scavenger Container set to: " + scavengerBag.ToString());
				Scavenger.ScavengerBag = (int)scavengerBag.Serial.Value;
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Scavenger Container, set backpack");
				RazorEnhanced.Scavenger.AddLog("Invalid Scavenger Container, set backpack");
				Scavenger.ScavengerBag = (int)World.Player.Backpack.Serial.Value;
			}

			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Settings.Scavenger.ListUpdate(scavengerListSelect.Text, RazorEnhanced.Scavenger.ScavengerDelay, serial, true, Scavenger.MaxRange); });
			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Scavenger.RefreshLists(); });
		}

		private void scavengerAddList_Click(object sender, EventArgs e)
		{
			EnhancedAgentAddList AddItemList = new EnhancedAgentAddList(2);
			AddItemList.TopMost = true;
			AddItemList.Show();
		}

		private void scavengerRemoveList_Click(object sender, EventArgs e)
		{
			if (scavengerListSelect.Text != "")
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Scavenger list: " + scavengerListSelect.Text, "Delete Scavenger List?", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					RazorEnhanced.Scavenger.AddLog("Scavenger list " + scavengerListSelect.Text + " removed!");
					RazorEnhanced.Scavenger.ScavengerBag = 0;
					RazorEnhanced.Scavenger.RemoveList(scavengerListSelect.Text);
				}
			}
		}

		private void scavengertListSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			int bag = 0;
			int delay = 0;
			int range = 0;
			Settings.Scavenger.ListDetailsRead(scavengerListSelect.Text, out bag, out delay, out range);
			Scavenger.ScavengerBag = bag;
			Scavenger.ScavengerDelay = delay;
			Scavenger.MaxRange = range;

			Settings.Scavenger.ListUpdate(scavengerListSelect.Text, delay, bag, true, range);
			Scavenger.InitGrid();

			if (scavengerListSelect.Text != "")
				Scavenger.AddLog("Scavenger list changed to: " + scavengerListSelect.Text);
		}

		private void scavengerEnableCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (World.Player != null)
			{
				if (scavengerListSelect.Text != "")
				{
					if (scavengerCheckBox.Checked)
					{
						int delay = -1;
						ScavengerListSelect.Enabled = false;
						scavengerButtonAddList.Enabled = false;
						scavengerButtonRemoveList.Enabled = false;
						scavengerButtonExport.Enabled = false;
						scavengerButtonImport.Enabled = false;
						scavengerDragDelay.Enabled = false;
						try
						{
							delay = Convert.ToInt32(scavengerDragDelay.Text);
						}
						catch
						{
							RazorEnhanced.Scavenger.AddLog("ERROR: Drag item delay is not valid");
							RazorEnhanced.Scavenger.AutoMode = false;
							return;
						}
						if (delay < 0)
						{
							RazorEnhanced.Scavenger.AddLog("ERROR: Drag item delay is not valid");
							RazorEnhanced.Scavenger.AutoMode = false;
							return;
						}
						RazorEnhanced.Scavenger.ResetIgnore();
						RazorEnhanced.Scavenger.AutoMode = true;
						RazorEnhanced.Scavenger.AddLog("Scavenger Engine Start...");
						RazorEnhanced.DragDropManager.HoldingItem = false;
						if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
							RazorEnhanced.Misc.SendMessage("SCAVENGER: Engine Start...");
					}
					else
					{
						ScavengerListSelect.Enabled = true;
						scavengerButtonAddList.Enabled = true;
						scavengerButtonRemoveList.Enabled = true;
						scavengerButtonExport.Enabled = true;
						scavengerButtonImport.Enabled = true;
						scavengerDragDelay.Enabled = true;

						RazorEnhanced.Scavenger.AutoMode = false;
						RazorEnhanced.Scavenger.AddLog("Scavenger Engine Stop...");
						RazorEnhanced.DragDropManager.HoldingItem = false;
						if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
							RazorEnhanced.Misc.SendMessage("SCAVENGER: Engine Stop...");
					}
				}
				else
				{
					scavengerCheckBox.Checked = false;
					RazorEnhanced.Scavenger.AddLog("Item list not selected!");
				}
			}
			else
			{
				scavengerCheckBox.Checked = false;
				RazorEnhanced.Scavenger.AddLog("You are not logged in game!");
			}
		}

		private void scavengerDragDelay_TextChanged(object sender, EventArgs e)
		{
			if (scavengerDragDelay.Focused)
			{
				RazorEnhanced.Settings.Scavenger.ListUpdate(scavengerListSelect.Text, Scavenger.ScavengerDelay, Scavenger.ScavengerBag, true, Scavenger.MaxRange);
				RazorEnhanced.Scavenger.RefreshLists();
			}
		}

		private void scavengerButtonImport_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ImportExport.ImportScavenger();
		}

		private void scavengerButtonExport_Click(object sender, EventArgs e)
		{
			if (scavengerListSelect.Text != "")
				RazorEnhanced.ImportExport.ExportScavenger(scavengerListSelect.Text);
			else
				RazorEnhanced.Scavenger.AddLog("Item list not selected!");
		}

		private void scavengerdataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewCell cell = scavengerdataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

			if (e.ColumnIndex == 3)
			{
				if (cell.Value.ToString() == "-1")
				{
					cell.Value = "All";
				}
				else
				{
					int color = 0;
					if (!cell.Value.ToString().Contains("-"))
					{
						try
						{
							color = Convert.ToInt32((string)cell.Value, 16);
						}
						catch { }

						if (color > 65535)
							color = 65535;
					}
					cell.Value = "0x" + color.ToString("X4");
				}
			}
			else if (e.ColumnIndex == 2)
			{
				int itemid = 0;
				if (!cell.Value.ToString().Contains("-"))
				{
					try
					{
						itemid = Convert.ToInt32((string)cell.Value, 16);
					}
					catch { }

					if (itemid > 65535)
						itemid = 65535;
				}
				cell.Value = "0x" + itemid.ToString("X4");
			}
			RazorEnhanced.Scavenger.CopyTable();
		}

		private void scavengerdataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells[0].Value = false;
			e.Row.Cells[1].Value = "New Item";
			e.Row.Cells[2].Value = "0x0000";
			e.Row.Cells[3].Value = "0x0000";
			e.Row.Cells[4].Value = null;
		}

		// ------------ SCAVENGER END ----------------

		// ------------ ORGANIZER ----------------

		private void organizerAddList_Click(object sender, EventArgs e)
		{
			EnhancedAgentAddList AddItemList = new EnhancedAgentAddList(3);
			AddItemList.TopMost = true;
			AddItemList.Show();
		}

		private void organizerRemoveList_Click(object sender, EventArgs e)
		{
			if (organizerListSelect.Text != "")
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Organizer list: " + organizerListSelect.Text, "Delete Organizer List?", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					RazorEnhanced.Organizer.AddLog("Organizer list " + organizerListSelect.Text + " removed!");
					RazorEnhanced.Organizer.OrganizerSource = 0;
					RazorEnhanced.Organizer.OrganizerDestination = 0;
					RazorEnhanced.Organizer.OrganizerDelay = 100;
					RazorEnhanced.Organizer.RemoveList(organizerListSelect.Text);
				}
			}
		}

		private void organizerSetSource_Click(object sender, EventArgs e)
		{
			if (organizerListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(OrganizerSourceContainerTarget_Callback));
			else
				RazorEnhanced.Organizer.AddLog("Item list not selected!");
		}

		private void OrganizerSourceContainerTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item organizerBag = Assistant.World.FindItem((Assistant.Serial)((uint)serial));
			if (organizerBag == null)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Source Container, set backpack");
				RazorEnhanced.Organizer.AddLog("Invalid Source Container, set backpack");
				RazorEnhanced.Organizer.OrganizerSource = (int)World.Player.Backpack.Serial.Value;
				return;
			}

			if (organizerBag != null && organizerBag.Serial.IsItem && organizerBag.IsContainer)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Source Container set to: " + organizerBag.ToString());
				RazorEnhanced.Organizer.AddLog("Source Container set to: " + organizerBag.ToString());
				RazorEnhanced.Organizer.OrganizerSource = (int)organizerBag.Serial.Value;
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Source Container, set backpack");
				RazorEnhanced.Organizer.AddLog("Invalid Source Container, set backpack");
				RazorEnhanced.Organizer.OrganizerSource = (int)World.Player.Backpack.Serial.Value;
			}

			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Settings.Organizer.ListUpdate(organizerListSelect.Text, RazorEnhanced.Organizer.OrganizerDelay, serial, RazorEnhanced.Organizer.OrganizerDestination, true); });
			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Organizer.RefreshLists(); });
		}

		private void organizerSetDestination_Click(object sender, EventArgs e)
		{
			if (organizerListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(OrganizerDestinationContainerTarget_Callback));
			else
				RazorEnhanced.Organizer.AddLog("Item list not selected!");
		}

		private void OrganizerDestinationContainerTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item organizerBag = Assistant.World.FindItem((Assistant.Serial)((uint)serial));

			if (organizerBag == null)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Destination Container, set backpack");
				RazorEnhanced.Organizer.AddLog("Invalid Destination Container, set backpack");
				RazorEnhanced.Organizer.OrganizerDestination = (int)World.Player.Backpack.Serial.Value;
				return;
			}

			if (organizerBag != null && organizerBag.Serial.IsItem && organizerBag.IsContainer)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Destination Container set to: " + organizerBag.ToString());
				RazorEnhanced.Organizer.AddLog("Destination Container set to: " + organizerBag.ToString());
				RazorEnhanced.Organizer.OrganizerDestination = (int)organizerBag.Serial.Value;
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Destination Container, set backpack");
				RazorEnhanced.Organizer.AddLog("Invalid Destination Container, set backpack");
				RazorEnhanced.Organizer.OrganizerDestination = (int)World.Player.Backpack.Serial.Value;
			}

			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Settings.Organizer.ListUpdate(organizerListSelect.Text, RazorEnhanced.Organizer.OrganizerDelay, RazorEnhanced.Organizer.OrganizerSource, serial, true); });
			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Organizer.RefreshLists(); });
		}

		private void organizerListSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			int bagsource;
			int bagdestination;
			int delay;
			RazorEnhanced.Settings.Organizer.ListDetailsRead(organizerListSelect.Text, out bagsource, out bagdestination, out delay);
			RazorEnhanced.Organizer.OrganizerDelay = delay;
			RazorEnhanced.Organizer.OrganizerSource = bagsource;
			RazorEnhanced.Organizer.OrganizerDestination = bagdestination;

			RazorEnhanced.Settings.Organizer.ListUpdate(organizerListSelect.Text, RazorEnhanced.Organizer.OrganizerDelay, RazorEnhanced.Organizer.OrganizerSource, RazorEnhanced.Organizer.OrganizerDestination, true);
			RazorEnhanced.Organizer.InitGrid();

			if (organizerListSelect.Text != "")
				RazorEnhanced.Organizer.AddLog("Organizer list changed to: " + organizerListSelect.Text);
		}

		private void organizerAddTarget_Click(object sender, EventArgs e)
		{
			if (organizerListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(OrganizerItemTarget_Callback));
			else
				RazorEnhanced.Organizer.AddLog("Item list not selected!");
		}

		private void OrganizerItemTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item organizerItem = Assistant.World.FindItem(serial);
			if (organizerItem != null && organizerItem.Serial.IsItem)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Organizer item added: " + organizerItem.ToString());
				RazorEnhanced.Organizer.AddLog("Organizer item added: " + organizerItem.ToString());
				this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Organizer.AddItemToList(organizerItem.Name, organizerItem.ItemID, organizerItem.Hue); });
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid target");
				RazorEnhanced.Organizer.AddLog("Invalid target");
			}
		}

		private void organizerDragDelay_TextChanged(object sender, EventArgs e)
		{
			if (organizerDragDelay.Focused)
			{
				RazorEnhanced.Settings.Organizer.ListUpdate(organizerListSelect.Text, RazorEnhanced.Organizer.OrganizerDelay, RazorEnhanced.Organizer.OrganizerSource, RazorEnhanced.Organizer.OrganizerDestination, true);
				RazorEnhanced.Organizer.RefreshLists();
			}
		}

		private void organizerExecute_Click(object sender, EventArgs e)
		{
			OrganizerStartExec();
		}

		internal void OrganizerStartExec()
		{
			if (World.Player != null)
			{
				RazorEnhanced.Organizer.Start();
				RazorEnhanced.Organizer.AddLog("Organizer Engine Start...");
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("ORGANIZER: Engine Start...");
				OrganizerStartWork();
			}
			else
			{
				RazorEnhanced.Organizer.AddLog("You are not logged in game!");
				OrganizerFinishWork();
			}
		}

		private void organizerStop_Click(object sender, EventArgs e)
		{
			OrganizerStopExec();
		}

		internal void OrganizerStopExec()
		{
			RazorEnhanced.Organizer.ForceStop();

			RazorEnhanced.Organizer.AddLog("Organizer Engine force stop...");
			if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
				RazorEnhanced.Misc.SendMessage("ORGANIZER: Organizer Engine force stop...");
			OrganizerFinishWork();
		}

		private delegate void OrganizerStartWorkCallback();

		internal void OrganizerStartWork()
		{
			if (organizerStopButton.InvokeRequired ||
				organizerExecuteButton.InvokeRequired ||
				organizerListSelect.InvokeRequired ||
				organizerAddListB.InvokeRequired ||
				organizerRemoveListB.InvokeRequired ||
				organizerExportListB.InvokeRequired ||
				organizerImportListB.InvokeRequired ||
				organizerDragDelay.InvokeRequired)
			{
				OrganizerStartWorkCallback d = new OrganizerStartWorkCallback(OrganizerStartWork);
				this.Invoke(d, null);
			}
			else
			{
				organizerStopButton.Enabled = true;
				organizerExecuteButton.Enabled = false;
				organizerListSelect.Enabled = false;
				organizerAddListB.Enabled = false;
				organizerRemoveListB.Enabled = false;
				organizerExportListB.Enabled = false;
				organizerImportListB.Enabled = false;
				organizerDragDelay.Enabled = false;
			}
		}

		private delegate void OrganizerFinishWorkCallback();

		internal void OrganizerFinishWork()
		{
			if (organizerStopButton.InvokeRequired ||
				organizerExecuteButton.InvokeRequired ||
				organizerListSelect.InvokeRequired ||
				organizerAddListB.InvokeRequired ||
				organizerRemoveListB.InvokeRequired ||
				organizerExportListB.InvokeRequired ||
				organizerImportListB.InvokeRequired ||
				organizerDragDelay.InvokeRequired)
			{
				OrganizerFinishWorkCallback d = new OrganizerFinishWorkCallback(OrganizerFinishWork);
				this.Invoke(d, null);
			}
			else
			{
				organizerStopButton.Enabled = false;
				organizerExecuteButton.Enabled = true;
				organizerListSelect.Enabled = true;
				organizerAddListB.Enabled = true;
				organizerRemoveListB.Enabled = true;
				organizerExportListB.Enabled = true;
				organizerImportListB.Enabled = true;
				organizerDragDelay.Enabled = true;
			}
		}

		private void organizerImportListB_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ImportExport.ImportOrganizer();
		}

		private void organizerExportListB_Click(object sender, EventArgs e)
		{
			if (organizerListSelect.Text != "")
				RazorEnhanced.ImportExport.ExportOrganizer(organizerListSelect.Text);
			else
				RazorEnhanced.Organizer.AddLog("Item list not selected!");
		}
		private void organizerdataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewCell cell = organizerdataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

			if (e.ColumnIndex == 3)
			{
				if (cell.Value.ToString() == "-1")
				{
					cell.Value = "All";
				}
				else
				{
					int color = 0;
					if (!cell.Value.ToString().Contains("-"))
					{
						try
						{
							color = Convert.ToInt32((string)cell.Value, 16);
						}
						catch { }

						if (color > 65535)
							color = 65535;
					}
					cell.Value = "0x" + color.ToString("X4");
				}
			}
			else if (e.ColumnIndex == 4)
			{
				if (cell.Value.ToString() == "-1")
				{
					cell.Value = "All";
				}
				else
				{
					int amount = 0;
					Int32.TryParse(cell.Value.ToString(), out amount);

					if (amount < 0 || amount > 9999)
						amount = 9999;

					cell.Value = amount.ToString();
				}
			}
			else if (e.ColumnIndex == 2)
			{
				int itemid = 0;
				if (!cell.Value.ToString().Contains("-"))
				{
					try
					{
						itemid = Convert.ToInt32((string)cell.Value, 16);
					}
					catch { }

					if (itemid > 65535)
						itemid = 65535;
				}
				cell.Value = "0x" + itemid.ToString("X4");
			}
			RazorEnhanced.Organizer.CopyTable();
		}

		private void organizerdataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells[0].Value = false;
			e.Row.Cells[1].Value = "New Item";
			e.Row.Cells[2].Value = "0x0000";
			e.Row.Cells[3].Value = "0x0000";
			e.Row.Cells[4].Value = "1";
		}


		// ------------------ ORGANIZER END--------------------------

		// ------------------ SELL AGENT --------------------------
		private void sellListSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			RazorEnhanced.SellAgent.SellBag = RazorEnhanced.Settings.SellAgent.BagRead(sellListSelect.Text);
			RazorEnhanced.Settings.SellAgent.ListUpdate(sellListSelect.Text, RazorEnhanced.SellAgent.SellBag, true);
			RazorEnhanced.SellAgent.InitGrid();
			if (sellListSelect.Text != "")
				RazorEnhanced.SellAgent.AddLog("Sell Agent list changed to: " + sellListSelect.Text);
		}

		private void sellAddList_Click(object sender, EventArgs e)
		{
			EnhancedAgentAddList AddItemList = new EnhancedAgentAddList(5);
			AddItemList.TopMost = true;
			AddItemList.Show();
		}

		private void sellRemoveList_Click(object sender, EventArgs e)
		{
			if (sellListSelect.Text != "")
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Vendor Sell list: " + sellListSelect.Text, "Delete Vendor Sell List?", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					RazorEnhanced.SellAgent.AddLog("Sell Agent list " + sellListSelect.Text + " removed!");
					RazorEnhanced.SellAgent.RemoveList(sellListSelect.Text);
				}
			}
		}

		private void sellAddTarget_Click(object sender, EventArgs e)
		{
			if (sellListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(SellAgentItemTarget_Callback));
			else
				RazorEnhanced.SellAgent.AddLog("Item list not selected!");
		}

		private void SellAgentItemTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item sellItem = Assistant.World.FindItem(serial);
			if (sellItem != null && sellItem.Serial.IsItem)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Sell Agent item added: " + sellItem.ToString());
				RazorEnhanced.SellAgent.AddLog("Sell Agent item added: " + sellItem.ToString());
				this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.SellAgent.AddItemToList(sellItem.Name, sellItem.ItemID, 999, sellItem.Hue); });
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid target");
				RazorEnhanced.SellAgent.AddLog("Invalid target");
			}
		}

		private void sellEnableCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (World.Player != null)
			{
				if (sellEnableCheckBox.Checked)
				{
					if (sellListSelect.Text != "")
					{
						Assistant.Item bag = Assistant.World.FindItem(RazorEnhanced.SellAgent.SellBag);

						if (bag != null)
							if (bag.RootContainer != World.Player || !bag.IsContainer)
							{
								RazorEnhanced.SellAgent.AddLog("Invalid or not accessible Container!");
								if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
									RazorEnhanced.Misc.SendMessage("Invalid or not accessible Container!");
								sellEnableCheckBox.Checked = false;
							}
							else
							{
								sellListSelect.Enabled = false;
								sellAddListButton.Enabled = false;
								sellRemoveListButton.Enabled = false;
								sellImportListButton.Enabled = false;
								sellExportListButton.Enabled = false;
								RazorEnhanced.SellAgent.AddLog("Apply item list " + sellListSelect.SelectedItem.ToString() + " filter ok!");
								if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
									RazorEnhanced.Misc.SendMessage("Apply item list " + sellListSelect.SelectedItem.ToString() + " filter ok!");
								RazorEnhanced.SellAgent.EnableSellFilter();
							}
						else
						{
							RazorEnhanced.SellAgent.AddLog("Invalid or not accessible Container!");
							if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
								RazorEnhanced.Misc.SendMessage("Invalid or not accessible Container!");
							sellEnableCheckBox.Checked = false;
						}
					}
					else
					{
						sellEnableCheckBox.Checked = false;
						RazorEnhanced.SellAgent.AddLog("Item list not selected!");
					}
				}
				else
				{
					sellListSelect.Enabled = true;
					sellAddListButton.Enabled = true;
					sellRemoveListButton.Enabled = true;
					sellImportListButton.Enabled = true;
					sellExportListButton.Enabled = true;
					if (sellListSelect.Text != "")
					{
						RazorEnhanced.SellAgent.AddLog("Remove item list " + sellListSelect.SelectedItem.ToString() + " filter ok!");
						if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
							RazorEnhanced.Misc.SendMessage("Remove item list " + sellListSelect.SelectedItem.ToString() + " filter ok!");
					}
				}
			}
			else
			{
				sellEnableCheckBox.Checked = false;
				RazorEnhanced.SellAgent.AddLog("You are not logged in game!");
			}
		}

		private void sellSetBag_Click(object sender, EventArgs e)
		{
			if (sellListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(sellBagTarget_Callback));
			else
				RazorEnhanced.SellAgent.AddLog("Item list not selected!");
		}

		private void sellBagTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item sellBag = Assistant.World.FindItem(serial);

			if (sellBag == null)
				return;

			if (sellBag != null && sellBag.Serial.IsItem && sellBag.IsContainer && sellBag.RootContainer == Assistant.World.Player)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Container set to: " + sellBag.ToString());
				RazorEnhanced.SellAgent.AddLog("Container set to: " + sellBag.ToString());
				RazorEnhanced.SellAgent.SellBag = (int)sellBag.Serial.Value;
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid container, set backpack");
				RazorEnhanced.SellAgent.AddLog("Invalid container, set backpack");
				RazorEnhanced.SellAgent.SellBag = (int)World.Player.Backpack.Serial.Value;
			}

			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Settings.SellAgent.ListUpdate(sellListSelect.Text, serial, true); });
			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.SellAgent.RefreshLists(); });
		}

		private void sellImportListButton_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ImportExport.ImportSell();
		}

		private void sellExportListButton_Click(object sender, EventArgs e)
		{
			if (sellListSelect.Text != "")
				RazorEnhanced.ImportExport.ExportSell(sellListSelect.Text);
			else
				RazorEnhanced.SellAgent.AddLog("Item list not selected!");
		}

		private void vendorsellGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewCell cell = vendorsellGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

			if (e.ColumnIndex == 4)
			{
				if (cell.Value.ToString() == "-1")
				{
					cell.Value = "All";
				}
				else
				{
					int color = 0;
					if (!cell.Value.ToString().Contains("-"))
					{
						try
						{
							color = Convert.ToInt32((string)cell.Value, 16);
						}
						catch { }

						if (color > 65535)
							color = 65535;
					}
					cell.Value = "0x" + color.ToString("X4");
				}
			}
			else if (e.ColumnIndex == 3)
			{
				int amount = 0;
				Int32.TryParse(cell.Value.ToString(), out amount);

				if (amount < 0 || amount > 999)
					amount = 999;

				cell.Value = amount.ToString();
			}
			else if (e.ColumnIndex == 2)
			{
				int itemid = 0;
				if (!cell.Value.ToString().Contains("-"))
				{
					try
					{
						itemid = Convert.ToInt32((string)cell.Value, 16);
					}
					catch { }

					if (itemid > 65535)
						itemid = 65535;
				}
				cell.Value = "0x" + itemid.ToString("X4");
			}
			RazorEnhanced.SellAgent.CopyTable();
		}

		private void vendorsellGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells[0].Value = false;
			e.Row.Cells[1].Value = "New Item";
			e.Row.Cells[2].Value = "0x0000";
			e.Row.Cells[3].Value = 999;
			e.Row.Cells[4].Value = "0x0000";
		}

		// ------------------ SELL AGENT END--------------------------

		// ------------------ BUY AGENT --------------------------

		private void buyListSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			RazorEnhanced.Settings.BuyAgent.ListUpdate(buyListSelect.Text, true);
			RazorEnhanced.BuyAgent.InitGrid();

			if (sellListSelect.Text != "")
				RazorEnhanced.BuyAgent.AddLog("Buy Agent list changed to: " + buyListSelect.Text);
			else
				RazorEnhanced.BuyAgent.AddLog("Item list not selected!");
		}

		private void buyAddList_Click(object sender, EventArgs e)
		{
			EnhancedAgentAddList AddItemList = new EnhancedAgentAddList(4);
			AddItemList.TopMost = true;
			AddItemList.Show();
		}

		private void buyRemoveList_Click(object sender, EventArgs e)
		{
			if (buyListSelect.Text != "")
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Vendor Buy list: " + buyListSelect.Text, "Delete Vendor Buy List?", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					RazorEnhanced.BuyAgent.AddLog("Buy Agent list " + buyListSelect.Text + " removed!");
					RazorEnhanced.BuyAgent.RemoveList(buyListSelect.Text);
				}
			}
		}

		private void buyAddTarget_Click(object sender, EventArgs e)
		{
			if (buyListSelect.Text != "")
			{
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(BuyAgentItemTarget_Callback));
			}
			else
				RazorEnhanced.BuyAgent.AddLog("Item list not selected!");
		}

		private void BuyAgentItemTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item buyItem = Assistant.World.FindItem(serial);
			if (buyItem != null && buyItem.Serial.IsItem)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Buy Agent item added: " + buyItem.ToString());
				RazorEnhanced.BuyAgent.AddLog("Buy Agent item added: " + buyItem.ToString());
				this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.BuyAgent.AddItemToList(buyItem.Name, buyItem.ItemID, 999, buyItem.Hue); });
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid target");
				RazorEnhanced.BuyAgent.AddLog("Invalid target");
			}
		}

		private void buyEnableCheckB_CheckedChanged(object sender, EventArgs e)
		{
			if (World.Player != null)
			{
				if (buyListSelect.Text != "")
				{
					if (buyEnableCheckBox.Checked)
					{
						buyListSelect.Enabled = false;
						buyAddListButton.Enabled = false;
						buyRemoveListButton.Enabled = false;
						buyImportListButton.Enabled = false;
						buyExportListButton.Enabled = false;
						RazorEnhanced.BuyAgent.AddLog("Apply item list " + buyListSelect.SelectedItem.ToString() + " filter ok!");
						if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
							RazorEnhanced.Misc.SendMessage("Apply item list " + buyListSelect.SelectedItem.ToString() + " filter ok!");
						RazorEnhanced.BuyAgent.EnableBuyFilter();
					}
					else
					{
						buyListSelect.Enabled = true;
						buyAddListButton.Enabled = true;
						buyRemoveListButton.Enabled = true;
						buyImportListButton.Enabled = true;
						buyExportListButton.Enabled = true;
						RazorEnhanced.BuyAgent.AddLog("Remove item list " + buyListSelect.SelectedItem.ToString() + " filter ok!");
						if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
							RazorEnhanced.Misc.SendMessage("Remove item list " + buyListSelect.SelectedItem.ToString() + " filter ok!");
					}
				}
				else
				{
					buyEnableCheckBox.Checked = false;
					RazorEnhanced.BuyAgent.AddLog("Item list not selected!");
					return;
				}
			}
			else
			{
				buyEnableCheckBox.Checked = false;
				RazorEnhanced.BuyAgent.AddLog("You are not logged in game!");
				return;
			}
		}

		private void buyImportListButton_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ImportExport.ImportBuy();
		}

		private void buyExportListButton_Click(object sender, EventArgs e)
		{
			if (buyListSelect.Text != "")
				RazorEnhanced.ImportExport.ExportBuy(buyListSelect.Text);
			else
				RazorEnhanced.BuyAgent.AddLog("Item list not selected!");
		}

		private void vendorbuydataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewCell cell = vendorbuydataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

			if (e.ColumnIndex == 4)
			{
				if (cell.Value.ToString() == "-1")
				{
					cell.Value = "All";
				}
				else
				{
					int color = 0;
					if (!cell.Value.ToString().Contains("-"))
					{
						try
						{
							color = Convert.ToInt32((string)cell.Value, 16);
						}
						catch { }

						if (color > 65535)
							color = 65535;
					}
					cell.Value = "0x" + color.ToString("X4");
				}
			}
			else if (e.ColumnIndex == 3)
			{
				int amount = 0;
				Int32.TryParse(cell.Value.ToString(), out amount);

				if (amount < 0 || amount > 999)
					amount = 999;

				cell.Value = amount.ToString();
			}
			else if (e.ColumnIndex == 2)
			{
				int itemid = 0;
				if (!cell.Value.ToString().Contains("-"))
				{
					try
					{
						itemid = Convert.ToInt32((string)cell.Value, 16);
					}
					catch { }

					if (itemid > 65535)
						itemid = 65535;
				}
				cell.Value = "0x" + itemid.ToString("X4");
			}
			RazorEnhanced.BuyAgent.CopyTable();
		}

		private void vendorbuydataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells[0].Value = false;
			e.Row.Cells[1].Value = "New Item";
			e.Row.Cells[2].Value = "0x0000";
			e.Row.Cells[3].Value = 999;
			e.Row.Cells[4].Value = "0x0000";
		}

		// --------------- BUY AGENT END ---------

		// --------------- DRESS START ---------
		private void dressListSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			int bag = 0;
			int delay = 0;
			bool conflict = false;
			RazorEnhanced.Settings.Dress.ListDetailsRead(dressListSelect.Text, out bag, out delay, out conflict);
			RazorEnhanced.Dress.DressBag = bag;
			RazorEnhanced.Dress.DressDelay = delay;
			RazorEnhanced.Dress.DressConflict = conflict;
			RazorEnhanced.Settings.Dress.ListUpdate(dressListSelect.Text, RazorEnhanced.Dress.DressDelay, RazorEnhanced.Dress.DressBag, RazorEnhanced.Dress.DressConflict, true);
			RazorEnhanced.Dress.RefreshItems();

			if (dressListSelect.Text != "")
				RazorEnhanced.Dress.AddLog("Dress list changed to: " + dressListSelect.Text);
		}

		private void dressAddListB_Click(object sender, EventArgs e)
		{
			EnhancedAgentAddList AddItemList = new EnhancedAgentAddList(6);
			AddItemList.TopMost = true;
			AddItemList.Show();
		}

		private void dressRemoveListB_Click(object sender, EventArgs e)
		{
			if (dressListSelect.Text != "")
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Dress list: " + dressListSelect.Text, "Delete Dress List?", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					RazorEnhanced.Dress.AddLog("Dress list " + dressListSelect.Text + " removed!");
					RazorEnhanced.Dress.DressBag = 0;
					RazorEnhanced.Dress.DressDelay = 100;
					RazorEnhanced.Dress.DressConflict = false;
					RazorEnhanced.Dress.RemoveList(dressListSelect.Text);
					HotKey.Init();
				}
			}
		}

		private void dressDragDelay_TextChanged(object sender, EventArgs e)
		{
			if (dressDragDelay.Focused)
			{
				RazorEnhanced.Settings.Dress.ListUpdate(dressListSelect.Text, RazorEnhanced.Dress.DressDelay, RazorEnhanced.Dress.DressBag, RazorEnhanced.Dress.DressConflict, true);
				RazorEnhanced.Dress.RefreshLists();
			}
		}

		private void dressConflictCheckB_CheckedChanged(object sender, EventArgs e)
		{
			RazorEnhanced.Settings.Dress.ListUpdate(dressListSelect.Text, RazorEnhanced.Dress.DressDelay, RazorEnhanced.Dress.DressBag, RazorEnhanced.Dress.DressConflict, true);
			RazorEnhanced.Dress.RefreshLists();
		}

		private void dressReadB_Click(object sender, EventArgs e)
		{
			if (dressListSelect.Text != "")
				RazorEnhanced.Dress.ReadPlayerDress();
			else
				RazorEnhanced.Dress.AddLog("Item list not selected!");
		}

		private void dressSetBagB_Click(object sender, EventArgs e)
		{
			if (dressListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(DressItemContainerTarget_Callback));
			else
				RazorEnhanced.Dress.AddLog("Item list not selected!");
		}

		private void DressItemContainerTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item dressBag = Assistant.World.FindItem(serial);

			if (dressBag == null)
				return;

			if (dressBag != null && dressBag.Serial.IsItem && dressBag.IsContainer)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Undress Container set to: " + dressBag.ToString());
				RazorEnhanced.Dress.AddLog("Undress Container set to: " + dressBag.ToString());
				RazorEnhanced.Dress.DressBag = (int)dressBag.Serial.Value;
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Undress Container, set backpack");
				RazorEnhanced.Dress.AddLog("Invalid Undress Container, set backpack");
				RazorEnhanced.Dress.DressBag = (int)World.Player.Backpack.Serial.Value;
			}

			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Settings.Dress.ListUpdate(dressListSelect.Text, RazorEnhanced.Dress.DressDelay, RazorEnhanced.Dress.DressBag, RazorEnhanced.Dress.DressConflict, true); });
			this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Dress.RefreshLists(); });
		}

		private void dressRemoveB_Click(object sender, EventArgs e)
		{
			if (dressListSelect.Text != "")
			{
				if (dressListView.SelectedItems.Count == 1)
				{
					int index = dressListView.SelectedItems[0].Index;
					string selection = dressListSelect.Text;

					if (RazorEnhanced.Settings.Dress.ListExists(selection))
					{
						List<Dress.DressItem> items = Settings.Dress.ItemsRead(selection);
						if (index <= items.Count - 1)
						{
							RazorEnhanced.Settings.Dress.ItemDelete(selection, items[index]);
							RazorEnhanced.Dress.RefreshItems();
						}
					}
				}
			}
			else
				RazorEnhanced.AutoLoot.AddLog("Item list not selected!");
		}

		private void dresslistView_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (dressListView.FocusedItem != null)
			{
				ListViewItem item = e.Item as ListViewItem;
				RazorEnhanced.Dress.UpdateSelectedItems(item.Index);
			}
		}

		private void dressAddTargetB_Click(object sender, EventArgs e)
		{
			if (dressListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(DressItemTarget_Callback));
			else
				RazorEnhanced.Dress.AddLog("Item list not selected!");
		}

		private void DressItemTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item dressItem = Assistant.World.FindItem(serial);
			if (dressItem != null && dressItem.Serial.IsItem)
				this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Dress.AddItemByTarger(dressItem); });
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid target");
				RazorEnhanced.Dress.AddLog("Invalid target");
			}
		}

		private void dressAddManualB_Click(object sender, EventArgs e)
		{
			if (dressListSelect.Text != "")
			{
				EnhancedDressAddUndressLayer ManualAddLayer = new EnhancedDressAddUndressLayer();
				ManualAddLayer.TopMost = true;
				ManualAddLayer.Show();
			}
			else
				RazorEnhanced.Dress.AddLog("Item list not selected!");
		}

		private void dressImportListB_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ImportExport.ImportDress();
		}

		private void dressExportListB_Click(object sender, EventArgs e)
		{
			if (dressListSelect.Text != "")
				RazorEnhanced.ImportExport.ExportDress(dressListSelect.Text);
			else
				RazorEnhanced.Dress.AddLog("Item list not selected!");
		}

		private void razorButton10_Click(object sender, EventArgs e)
		{
			UndressStart();
		}

		internal void UndressStart()
		{
			if (World.Player != null)
			{
				RazorEnhanced.Dress.UndressStart();

				RazorEnhanced.Organizer.AddLog("Undress Engine Start...");
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("UNDRESS: Engine Start...");

				UndressStartWork();
			}
			else
			{
				RazorEnhanced.Dress.AddLog("You are not logged in game!");
				UndressFinishWork();
			}
		}

		private delegate void UndressFinishWorkCallback();

		internal void UndressFinishWork()
		{
			if (dressConflictCheckB.InvokeRequired ||
				dressExecuteButton.InvokeRequired ||
				undressExecuteButton.InvokeRequired ||
				dressAddListB.InvokeRequired ||
				dressRemoveListB.InvokeRequired ||
				organizerExportListB.InvokeRequired ||
				organizerImportListB.InvokeRequired ||
				dressStopButton.InvokeRequired ||
				organizerDragDelay.InvokeRequired)
			{
				UndressFinishWorkCallback d = new UndressFinishWorkCallback(UndressFinishWork);
				this.Invoke(d, null);
			}
			else
			{
				dressStopButton.Enabled = false;
				dressConflictCheckB.Enabled = true;
				dressExecuteButton.Enabled = true;
				undressExecuteButton.Enabled = true;
				dressAddListB.Enabled = true;
				dressRemoveListB.Enabled = true;
				dressExportListB.Enabled = true;
				dressImportListB.Enabled = true;
				dressDragDelay.Enabled = true;
			}
		}

		private delegate void UndressStartWorkCallback();

		internal void UndressStartWork()
		{
			if (dressConflictCheckB.InvokeRequired ||
				dressExecuteButton.InvokeRequired ||
				undressExecuteButton.InvokeRequired ||
				dressAddListB.InvokeRequired ||
				dressRemoveListB.InvokeRequired ||
				organizerExportListB.InvokeRequired ||
				organizerImportListB.InvokeRequired ||
				dressStopButton.InvokeRequired ||
				organizerDragDelay.InvokeRequired)
			{
				UndressStartWorkCallback d = new UndressStartWorkCallback(UndressStartWork);
				this.Invoke(d, null);
			}
			else
			{
				dressStopButton.Enabled = true;
				dressConflictCheckB.Enabled = false;
				dressExecuteButton.Enabled = false;
				undressExecuteButton.Enabled = false;
				dressAddListB.Enabled = false;
				dressRemoveListB.Enabled = false;
				dressExportListB.Enabled = false;
				dressImportListB.Enabled = false;
				dressDragDelay.Enabled = false;
			}
		}

		private void dressExecuteButton_Click(object sender, EventArgs e)
		{
			DressStart();
		}

		internal void DressStart()
		{
			if (World.Player != null)
			{
				RazorEnhanced.Dress.DressStart();

				RazorEnhanced.Organizer.AddLog("Dress Engine Start...");
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("DRESS: Engine Start...");

				UndressStartWork();
			}
			else
			{
				RazorEnhanced.Dress.AddLog("You are not logged in game!");
				UndressFinishWork();
			}
		}

		private void dressStopButton_Click(object sender, EventArgs e)
		{
			DressStop();
		}

		internal void DressStop()
		{
			RazorEnhanced.Dress.ForceStop();

			RazorEnhanced.Dress.AddLog("Dress / Undress Engine force stop...");
			if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
				RazorEnhanced.Misc.SendMessage("DRESS/UNDRESS: Engine force stop...");
			UndressFinishWork();
		}

		// --------------- DRESS END ---------

		// --------------- FRIENDS START ---------
		private void friendButtonAddList_Click(object sender, EventArgs e)
		{
			EnhancedAgentAddList AddItemList = new EnhancedAgentAddList(7);
			AddItemList.TopMost = true;
			AddItemList.Show();
		}

		private void friendButtonRemoveList_Click(object sender, EventArgs e)
		{
			if (friendListSelect.Text != "")
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Friend list: " + friendListSelect.Text, "Delete Friend List?", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					RazorEnhanced.Friend.AddLog("Friends list " + friendListSelect.Text + " removed!");
					RazorEnhanced.Friend.AutoacceptParty = false;
					RazorEnhanced.Friend.IncludeParty = false;
					RazorEnhanced.Friend.PreventAttack = false;
					RazorEnhanced.Friend.RemoveList(friendListSelect.Text);
				}
			}
		}

		private void friendButtonImportList_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ImportExport.ImportFriends();
		}

		private void friendButtonExportList_Click(object sender, EventArgs e)
		{
			if (friendListSelect.Text != "")
				RazorEnhanced.ImportExport.ExportFriends(friendListSelect.Text);
			else
				RazorEnhanced.Friend.AddLog("Friend list not selected!");
		}

		private void friendPartyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (friendPartyCheckBox.Focused)
				RazorEnhanced.Settings.Friend.ListUpdate(friendListSelect.Text, RazorEnhanced.Friend.IncludeParty, RazorEnhanced.Friend.PreventAttack, RazorEnhanced.Friend.AutoacceptParty, Friend.SLFriend, Friend.TBFriend, Friend.COMFriend, Friend.MINFriend, true);
		}

		private void friendAttackCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (friendAttackCheckBox.Focused)
				RazorEnhanced.Settings.Friend.ListUpdate(friendListSelect.Text, RazorEnhanced.Friend.IncludeParty, RazorEnhanced.Friend.PreventAttack, RazorEnhanced.Friend.AutoacceptParty, Friend.SLFriend, Friend.TBFriend, Friend.COMFriend, Friend.MINFriend, true);
		}

		private void friendIncludePartyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (friendIncludePartyCheckBox.Focused)
				RazorEnhanced.Settings.Friend.ListUpdate(friendListSelect.Text, RazorEnhanced.Friend.IncludeParty, RazorEnhanced.Friend.PreventAttack, RazorEnhanced.Friend.AutoacceptParty, Friend.SLFriend, Friend.TBFriend, Friend.COMFriend, Friend.MINFriend, true);
		}

		private void friendListSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool includeparty = false;
			bool preventattack = false;
			bool autoacceptparty = false;
			bool slfriend = false;
			bool tbfriend = false;
			bool minfriend = false;
			bool comfriend = false;

			RazorEnhanced.Settings.Friend.ListDetailsRead(friendListSelect.Text, out includeparty, out preventattack, out autoacceptparty, out slfriend, out tbfriend, out comfriend, out minfriend);
			RazorEnhanced.Friend.IncludeParty = includeparty;
			RazorEnhanced.Friend.PreventAttack = preventattack;
			RazorEnhanced.Friend.AutoacceptParty = autoacceptparty;
			RazorEnhanced.Friend.SLFriend = slfriend;
			RazorEnhanced.Friend.TBFriend = tbfriend;
			RazorEnhanced.Friend.COMFriend = comfriend;
			RazorEnhanced.Friend.MINFriend = minfriend;

			RazorEnhanced.Settings.Friend.ListUpdate(friendListSelect.Text, RazorEnhanced.Friend.IncludeParty, RazorEnhanced.Friend.PreventAttack, RazorEnhanced.Friend.AutoacceptParty, Friend.SLFriend, Friend.TBFriend, Friend.COMFriend, Friend.MINFriend, true);
			RazorEnhanced.Friend.RefreshPlayers();
			RazorEnhanced.Friend.RefreshGuilds();

			if (friendListSelect.Text != "")
				RazorEnhanced.Friend.AddLog("Friends list changed to: " + friendListSelect.Text);
		}

		private void friendlistView_PlayerChecked(object sender, ItemCheckedEventArgs e)
		{
			if (friendlistView.FocusedItem != null)
			{
				ListViewItem item = e.Item as ListViewItem;
				RazorEnhanced.Friend.UpdateSelectedPlayer(item.Index);
			}
		}

		private void friendAddTargetButton_Click(object sender, EventArgs e)
		{
			if (friendListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(FriendPlayerTarget_Callback));
			else
				RazorEnhanced.Friend.AddLog("Friends list not selected!");
		}

		private void FriendPlayerTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Mobile friendplayer = Assistant.World.FindMobile(serial);
			if (friendplayer != null && friendplayer.Serial.IsMobile && friendplayer.Serial != World.Player.Serial)
			{
				this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Friend.AddPlayerToList(friendplayer.Name, friendplayer.Serial); });
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid target");
				RazorEnhanced.Friend.AddLog("Invalid target");
			}
		}

		private void friendRemoveButton_Click(object sender, EventArgs e)
		{
			if (friendListSelect.Text != "")
			{
				if (friendlistView.SelectedItems.Count == 1)
				{
					int index = friendlistView.SelectedItems[0].Index;
					string selection = friendListSelect.Text;

					if (RazorEnhanced.Settings.Friend.ListExists(selection))
					{
						List<Friend.FriendPlayer> players;
						RazorEnhanced.Settings.Friend.PlayersRead(selection, out players);
						if (index <= players.Count - 1)
						{
							RazorEnhanced.Settings.Friend.PlayerDelete(selection, players[index]);
							RazorEnhanced.Friend.RefreshPlayers();
						}
					}
				}
			}
			else
				RazorEnhanced.Friend.AddLog("Friends list not selected!");
		}

		private void friendAddButton_Click(object sender, EventArgs e)
		{
			if (friendListSelect.Text != "")
			{
				EnhancedFriendAddPlayerManual ManualAddPlayer = new EnhancedFriendAddPlayerManual();
				ManualAddPlayer.TopMost = true;
				ManualAddPlayer.Show();
			}
			else
				RazorEnhanced.Friend.AddLog("Friends list not selected!");
		}

		private void FriendGuildAddButton_Click(object sender, EventArgs e)
		{
			if (friendListSelect.Text != "")
			{
				EnhancedFriendAddGuildManual ManualAddGuild = new EnhancedFriendAddGuildManual();
				ManualAddGuild.TopMost = true;
				ManualAddGuild.Show();
			}
			else
				RazorEnhanced.Friend.AddLog("Friends list not selected!");
		}

		private void SLfriendCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (SLfriendCheckBox.Focused)
				RazorEnhanced.Settings.Friend.ListUpdate(friendListSelect.Text, RazorEnhanced.Friend.IncludeParty, RazorEnhanced.Friend.PreventAttack, RazorEnhanced.Friend.AutoacceptParty, Friend.SLFriend, Friend.TBFriend, Friend.COMFriend, Friend.MINFriend, true);
		}

		private void COMfriendCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (COMfriendCheckBox.Focused)
				RazorEnhanced.Settings.Friend.ListUpdate(friendListSelect.Text, RazorEnhanced.Friend.IncludeParty, RazorEnhanced.Friend.PreventAttack, RazorEnhanced.Friend.AutoacceptParty, Friend.SLFriend, Friend.TBFriend, Friend.COMFriend, Friend.MINFriend, true);
		}

		private void TBfriendCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (TBfriendCheckBox.Focused)
				RazorEnhanced.Settings.Friend.ListUpdate(friendListSelect.Text, RazorEnhanced.Friend.IncludeParty, RazorEnhanced.Friend.PreventAttack, RazorEnhanced.Friend.AutoacceptParty, Friend.SLFriend, Friend.TBFriend, Friend.COMFriend, Friend.MINFriend, true);
		}

		private void MINfriendCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (MINfriendCheckBox.Focused)
				RazorEnhanced.Settings.Friend.ListUpdate(friendListSelect.Text, RazorEnhanced.Friend.IncludeParty, RazorEnhanced.Friend.PreventAttack, RazorEnhanced.Friend.AutoacceptParty, Friend.SLFriend, Friend.TBFriend, Friend.COMFriend, Friend.MINFriend, true);
		}

		private void FriendGuildRemoveButton_Click(object sender, EventArgs e)
		{
			if (friendListSelect.Text != "")
			{
				if (friendguildListView.SelectedItems.Count == 1)
				{
					int index = friendguildListView.SelectedItems[0].Index;
					string selection = friendListSelect.Text;

					if (RazorEnhanced.Settings.Friend.ListExists(selection))
					{
						List<Friend.FriendGuild> guilds;
						RazorEnhanced.Settings.Friend.GuildRead(selection, out guilds);
						if (index <= guilds.Count - 1)
						{
							RazorEnhanced.Settings.Friend.GuildDelete(selection, guilds[index]);
							RazorEnhanced.Friend.RefreshGuilds();
						}
					}
				}
			}
			else
				RazorEnhanced.Friend.AddLog("Friends list not selected!");
		}

		// --------------- FRIENDS END ---------

		// --------------- RESTOCK START -------------

		private void restockListSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			int bagsource;
			int bagdestination;
			int delay;
			RazorEnhanced.Settings.Restock.ListDetailsRead(restockListSelect.Text, out bagsource, out bagdestination, out delay);
			RazorEnhanced.Restock.RestockDelay = delay;
			RazorEnhanced.Restock.RestockSource = bagsource;
			RazorEnhanced.Restock.RestockDestination = bagdestination;

			RazorEnhanced.Settings.Restock.ListUpdate(restockListSelect.Text, RazorEnhanced.Restock.RestockDelay, RazorEnhanced.Restock.RestockSource, RazorEnhanced.Restock.RestockDestination, true);
			RazorEnhanced.Restock.InitGrid();

			if (restockListSelect.Text != "")
				RazorEnhanced.Restock.AddLog("Restock list changed to: " + restockListSelect.Text);
		}

		private void restockAddListB_Click(object sender, EventArgs e)
		{
			EnhancedAgentAddList AddItemList = new EnhancedAgentAddList(8);
			AddItemList.TopMost = true;
			AddItemList.Show();
		}

		private void restockRemoveListB_Click(object sender, EventArgs e)
		{
			if (restockListSelect.Text != "")
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Restock list: " + restockListSelect.Text, "Delete Restock List?", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					RazorEnhanced.Restock.AddLog("Restock list " + restockListSelect.Text + " removed!");
					RazorEnhanced.Restock.RestockSource = 0;
					RazorEnhanced.Restock.RestockDestination = 0;
					RazorEnhanced.Restock.RestockDelay = 100;
					RazorEnhanced.Restock.RemoveList(restockListSelect.Text);
				}
			}
		}

		private void restockImportB_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ImportExport.ImportRestock();
		}

		private void restockExportListB_Click(object sender, EventArgs e)
		{
			if (restockListSelect.Text != "")
				RazorEnhanced.ImportExport.ExportRestock(restockListSelect.Text);
			else
				RazorEnhanced.Restock.AddLog("Item list not selected!");
		}

		private void restockSetSourceButton_Click(object sender, EventArgs e)
		{
			if (restockListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(RestockSourceContainerTarget_Callback));
			else
				RazorEnhanced.Restock.AddLog("Item list not selected!");
		}

		private void RestockSourceContainerTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item restockBag = Assistant.World.FindItem((Assistant.Serial)((uint)serial));
			if (restockBag == null)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Source Container, set backpack");
				RazorEnhanced.Restock.AddLog("Invalid Source Container, set backpack");
				RazorEnhanced.Restock.RestockSource = (int)World.Player.Backpack.Serial.Value;
				return;
			}

			if (restockBag != null && restockBag.Serial.IsItem && restockBag.IsContainer)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Source Container set to: " + restockBag.ToString());
				RazorEnhanced.Restock.AddLog("Source Container set to: " + restockBag.ToString());
				RazorEnhanced.Restock.RestockSource = (int)restockBag.Serial.Value;
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Source Container, set backpack");
				RazorEnhanced.Restock.AddLog("Invalid Source Container, set backpack");
				RazorEnhanced.Restock.RestockSource = (int)World.Player.Backpack.Serial.Value;
			}

			this.BeginInvoke((MethodInvoker)delegate
			{
				RazorEnhanced.Settings.Restock.ListUpdate(restockListSelect.Text, RazorEnhanced.Restock.RestockDelay, serial, RazorEnhanced.Restock.RestockDestination, true);
				RazorEnhanced.Restock.RefreshLists();
			});
		}

		private void restockSetDestinationButton_Click(object sender, EventArgs e)
		{
			if (restockListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(RestockDestinationContainerTarget_Callback));
			else
				RazorEnhanced.Restock.AddLog("Item list not selected!");
		}

		private void RestockDestinationContainerTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item restockBag = Assistant.World.FindItem((Assistant.Serial)((uint)serial));
			if (restockBag == null)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Destination Container, set backpack");
				RazorEnhanced.Restock.AddLog("Invalid Destination Container, set backpack");
				RazorEnhanced.Restock.RestockDestination = (int)World.Player.Backpack.Serial.Value;
				return;
			}

			if (restockBag != null && restockBag.Serial.IsItem && restockBag.IsContainer)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Destination Container set to: " + restockBag.ToString());
				RazorEnhanced.Restock.AddLog("Destination Container set to: " + restockBag.ToString());
				RazorEnhanced.Restock.RestockDestination = (int)restockBag.Serial.Value;
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Destination Container, set backpack");
				RazorEnhanced.Restock.AddLog("Invalid Destination Container, set backpack");
				RazorEnhanced.Restock.RestockDestination = (int)World.Player.Backpack.Serial.Value;
			}

			this.BeginInvoke((MethodInvoker)delegate
			{
				RazorEnhanced.Settings.Restock.ListUpdate(restockListSelect.Text, RazorEnhanced.Restock.RestockDelay, RazorEnhanced.Restock.RestockSource, serial, true);
				RazorEnhanced.Restock.RefreshLists();
			});
		}

		private void restockDragDelay_TextChanged(object sender, EventArgs e)
		{
			if (restockDragDelay.Focused)
			{
				RazorEnhanced.Settings.Restock.ListUpdate(restockListSelect.Text, RazorEnhanced.Restock.RestockDelay, RazorEnhanced.Restock.RestockSource, RazorEnhanced.Restock.RestockDestination, true);
				RazorEnhanced.Restock.RefreshLists();
			}
		}

		private void restockExecuteButton_Click(object sender, EventArgs e)
		{
			RestockStartExec();
		}

		internal void RestockStartExec()
		{
			if (World.Player != null)
			{
				RazorEnhanced.Restock.Start();
				RazorEnhanced.Restock.AddLog("Restock Engine Start...");
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("RESTOCK: Engine Start...");
				RestockStartWork();
			}
			else
			{
				RazorEnhanced.Restock.AddLog("You are not logged in game!");
				RestockFinishWork();
			}
		}

		private void restockStopButton_Click(object sender, EventArgs e)
		{
			RestockStopExec();
		}

		internal void RestockStopExec()
		{
			RazorEnhanced.Restock.ForceStop();

			RazorEnhanced.Restock.AddLog("Restock Engine force stop...");
			if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
				RazorEnhanced.Misc.SendMessage("RESTOCK: Organizer Engine force stop...");
			RestockFinishWork();
		}

		private delegate void RestockFinishWorkCallback();

		internal void RestockFinishWork()
		{
			if (restockStopButton.InvokeRequired ||
				restockExecuteButton.InvokeRequired ||
				restockListSelect.InvokeRequired ||
				restockAddListB.InvokeRequired ||
				restockRemoveListB.InvokeRequired ||
				restockExportListB.InvokeRequired ||
				restockImportListB.InvokeRequired ||
				restockDragDelay.InvokeRequired)
			{
				RestockFinishWorkCallback d = new RestockFinishWorkCallback(RestockFinishWork);
				this.Invoke(d, null);
			}
			else
			{
				restockStopButton.Enabled = false;
				restockExecuteButton.Enabled = true;
				restockListSelect.Enabled = true;
				restockAddListB.Enabled = true;
				restockRemoveListB.Enabled = true;
				restockExportListB.Enabled = true;
				restockImportListB.Enabled = true;
				restockDragDelay.Enabled = true;
			}
		}

		private delegate void RestockStartWorkCallback();

		internal void RestockStartWork()
		{
			if (restockStopButton.InvokeRequired ||
				restockExecuteButton.InvokeRequired ||
				restockListSelect.InvokeRequired ||
				restockAddListB.InvokeRequired ||
				restockRemoveListB.InvokeRequired ||
				restockExportListB.InvokeRequired ||
				restockImportListB.InvokeRequired ||
				restockDragDelay.InvokeRequired)
			{
				RestockStartWorkCallback d = new RestockStartWorkCallback(RestockStartWork);
				this.Invoke(d, null);
			}
			else
			{
				restockStopButton.Enabled = true;
				restockExecuteButton.Enabled = false;
				restockListSelect.Enabled = false;
				restockAddListB.Enabled = false;
				restockRemoveListB.Enabled = false;
				restockExportListB.Enabled = false;
				restockImportListB.Enabled = false;
				restockDragDelay.Enabled = false;
			}
		}

		private void restockAddTargetButton_Click(object sender, EventArgs e)
		{
			if (restockListSelect.Text != "")
				Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(RestockItemTarget_Callback));
			else
				RazorEnhanced.Restock.AddLog("Item list not selected!");
		}

		private void RestockItemTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item restockItem = Assistant.World.FindItem(serial);
			if (restockItem != null && restockItem.Serial.IsItem)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Restock item added: " + restockItem.ToString());
				RazorEnhanced.Restock.AddLog("Restock item added: " + restockItem.ToString());
				this.BeginInvoke((MethodInvoker)delegate { RazorEnhanced.Restock.AddItemToList(restockItem.Name, restockItem.ItemID, restockItem.Hue); });
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid target");
				RazorEnhanced.Restock.AddLog("Invalid target");
			}
		}

		private void restockdataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewCell cell = restockdataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

			if (e.ColumnIndex == 3)
			{
				if (cell.Value.ToString() == "-1")
				{
					cell.Value = "All";
				}
				else
				{
					int color = 0;
					if (!cell.Value.ToString().Contains("-"))
					{
						try
						{
							color = Convert.ToInt32((string)cell.Value, 16);
						}
						catch { }

						if (color > 65535)
							color = 65535;
					}
					cell.Value = "0x" + color.ToString("X4");
				}
			}
			else if (e.ColumnIndex == 4)
			{
				int limit = 0;
				Int32.TryParse(cell.Value.ToString(), out limit);

				if (limit < 0 || limit > 9999)
					limit = 0;

				cell.Value = limit.ToString();
			}
			else if (e.ColumnIndex == 2)
			{
				int itemid = 0;
				if (!cell.Value.ToString().Contains("-"))
				{
					try
					{
						itemid = Convert.ToInt32((string)cell.Value, 16);
					}
					catch { }

					if (itemid > 65535)
						itemid = 65535;
				}
				cell.Value = "0x" + itemid.ToString("X4");
			}
			RazorEnhanced.Restock.CopyTable();
		}

		private void restockdataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
		{
			e.Row.Cells[0].Value = false;
			e.Row.Cells[1].Value = "New Item";
			e.Row.Cells[2].Value = "0x0000";
			e.Row.Cells[3].Value = "0x0000";
			e.Row.Cells[4].Value = "1";
		}

		// --------------- RESTOCK END -------------

		// ---------------- HEAL BANDAGE START -----------------

		private void bandagehealenableCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (World.Player != null)
			{
				if (bandagehealenableCheckBox.Checked)
				{
					RazorEnhanced.BandageHeal.AutoMode = true;
					RazorEnhanced.BandageHeal.AddLog("BANDAGE HEAL: Engine Start...");
					if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
						RazorEnhanced.Misc.SendMessage("BANDAGE HEAL: Engine Start...");
				}
				else
				{
					// Stop BANDAGEHEAL
					RazorEnhanced.BandageHeal.AutoMode = false;
					if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
						RazorEnhanced.Misc.SendMessage("BANDAGE HEAL: Engine Stop...");
					RazorEnhanced.BandageHeal.AddLog("BANDAGE HEAL: Engine Stop...");
				}
			}
			else
			{
				bandagehealenableCheckBox.Checked = false;
				RazorEnhanced.BandageHeal.AddLog("You are not logged in game!");
			}

			if (bandagehealenableCheckBox.Checked)
				groupBox6.Enabled = false;
			else
				groupBox6.Enabled = true;

			// Avvio healer engine e check vari
		}

		private void bandagehealtargetComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (BandageHealtargetComboBox.Text == "Target")
			{
				bandagehealsettargetButton.Enabled = true;
				bandagehealtargetLabel.Enabled = true;
			}
			else
			{
				bandagehealsettargetButton.Enabled = false;
				bandagehealtargetLabel.Enabled = false;
			}

			RazorEnhanced.Settings.General.WriteString("BandageHealtargetComboBox", bandagehealtargetComboBox.Text);
		}

		private void bandagehealsettargetButton_Click(object sender, EventArgs e)
		{
			Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(BandageHeakMobileTarget_Callback));
		}

		private void BandageHeakMobileTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Mobile mobile = Assistant.World.FindMobile(serial);

			if (mobile == null)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Target!");
				RazorEnhanced.BandageHeal.AddLog("Invalid Target!");
				return;
			}

			if (mobile.Serial.IsMobile)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Bandage Heal target set to: " + mobile.Name);
				RazorEnhanced.BandageHeal.AddLog("Bandage Heal target set to: " + mobile.Name);
				BandageHeal.TargetSerial = mobile.Serial;
				RazorEnhanced.Settings.General.WriteInt("BandageHealtargetLabel", mobile.Serial);
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid Target!");
				RazorEnhanced.Scavenger.AddLog("Invalid Target!");
			}
		}

		private void bandagehealcustomCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (bandagehealcustomCheckBox.Checked)
			{
				bandagehealcustomIDTextBox.Enabled = true;
				bandagehealcustomcolorTextBox.Enabled = true;
			}
			else
			{
				bandagehealcustomIDTextBox.Enabled = false;
				bandagehealcustomcolorTextBox.Enabled = false;
			}

			if (bandagehealcustomCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BandageHealcustomCheckBox", bandagehealcustomCheckBox.Checked);
		}

		private void bandagehealcustomIDTextBox_TextChanged(object sender, EventArgs e)
		{
			if (bandagehealcustomIDTextBox.Focused)
				RazorEnhanced.Settings.General.WriteInt("BandageHealcustomIDTextBox", RazorEnhanced.BandageHeal.CustomID);
		}

		private void bandagehealcustomcolorTextBox_TextChanged(object sender, EventArgs e)
		{
			if (bandagehealcustomcolorTextBox.Focused)
				RazorEnhanced.Settings.General.WriteInt("BandageHealcustomcolorTextBox", RazorEnhanced.BandageHeal.CustomColor);
		}

		private void bandagehealdexformulaCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (bandagehealdexformulaCheckBox.Checked)
				bandagehealdelayTextBox.Enabled = false;
			else
				bandagehealdelayTextBox.Enabled = true;

			if (bandagehealdexformulaCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BandageHealdexformulaCheckBox", bandagehealdexformulaCheckBox.Checked);
		}

		private void bandagehealdelayTextBox_TextChanged(object sender, EventArgs e)
		{
			if (bandagehealdelayTextBox.Focused)
				RazorEnhanced.Settings.General.WriteInt("BandageHealdelayTextBox", RazorEnhanced.BandageHeal.CustomDelay);
		}

		private void bandagehealhpTextBox_TextChanged(object sender, EventArgs e)
		{
			if (bandagehealhpTextBox.Focused)
				RazorEnhanced.Settings.General.WriteInt("BandageHealhpTextBox", RazorEnhanced.BandageHeal.HpLimit);
		}

		private void bandagehealpoisonCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (bandagehealpoisonCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BandageHealpoisonCheckBox", bandagehealpoisonCheckBox.Checked);
		}

		private void bandagehealmortalCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (bandagehealmortalCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BandageHealmortalCheckBox", bandagehealmortalCheckBox.Checked);
		}

		private void bandagehealhiddedCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (bandagehealhiddedCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BandageHealhiddedCheckBox", bandagehealhiddedCheckBox.Checked);
		}

		private void bandagehealcountdownCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (bandagehealcountdownCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BandageHealcountdownCheckBox", bandagehealcountdownCheckBox.Checked);
		}

		private void bandagehealmaxrangeTextBox_TextChanged(object sender, EventArgs e)
		{
			if (bandagehealmaxrangeTextBox.Focused)
				RazorEnhanced.Settings.General.WriteInt("BandageHealMaxRangeTextBox", RazorEnhanced.BandageHeal.MaxRange);
		}

		// ---------------- HEAL BANDAGE END ----------------

		// ---------------- TARGETTING START ----------------

		private void addTargetButton_Click(object sender, EventArgs e)
		{
			EnhancedTargetAdd addtarget = new EnhancedTargetAdd();
			addtarget.TopMost = true;
			addtarget.Show();
		}

		private void removeTargetButton_Click(object sender, EventArgs e)
		{
			if (targetlistView.SelectedItems.Count == 1)
			{
				RazorEnhanced.Settings.Target.TargetDelete(targetlistView.SelectedItems[0].SubItems[1].Text);
				TargetGUI.RefreshTarget();
				RazorEnhanced.HotKey.Init();
			}
		}

		private void performTargetButton_Click(object sender, EventArgs e)
		{
			if (targetlistView.SelectedItems.Count == 1)
			{
				RazorEnhanced.Target.PerformTargetFromList(targetlistView.SelectedItems[0].SubItems[1].Text);
			}
		}

		private void editTargetButton_Click(object sender, EventArgs e)
		{
			if (targetlistView.SelectedItems.Count == 1)
			{
				EnhancedTargetEdit edittarget = new EnhancedTargetEdit(targetlistView.SelectedItems[0].SubItems[1].Text);
				edittarget.TopMost = true;
				edittarget.Show();
			}
		}

		// ---------------- TARGETTING END ----------------

		// ---------------- FILTERS START ----------------
		private void autocarverrazorButton_Click(object sender, EventArgs e)
		{
			Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(autocarverbladeTarget_Callback));
		}

		private void autocarverbladeTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item blade = Assistant.World.FindItem(serial);

			if (blade == null)
				return;

			if (blade != null && blade.Serial.IsItem && blade.RootContainer == Assistant.World.Player)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("AutoCarve Blade Set to: " + blade.ToString());
				RazorEnhanced.Filters.AutoCarverBlade = (int)blade.Serial.Value;
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid AutoCarve Blade");
				RazorEnhanced.Filters.AutoCarverBlade = 0;
			}

			RazorEnhanced.Settings.General.WriteInt("AutoCarverBladeLabel", RazorEnhanced.Filters.AutoCarverBlade);
		}

		private void boneCutterrazorButton_Click(object sender, EventArgs e)
		{
			Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(bonecutterbladeTarget_Callback));
		}

		private void bonecutterbladeTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			Assistant.Item blade = Assistant.World.FindItem(serial);

			if (blade == null)
				return;

			if (blade != null && blade.Serial.IsItem && blade.RootContainer == Assistant.World.Player)
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("BoneCutter Blade Set to: " + blade.ToString());
				RazorEnhanced.Filters.BoneCutterBlade = (int)blade.Serial.Value;
			}
			else
			{
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("Invalid BoneCutter Blade");
				RazorEnhanced.Filters.BoneCutterBlade = 0;
			}

			RazorEnhanced.Settings.General.WriteInt("BoneBladeLabel", RazorEnhanced.Filters.BoneCutterBlade);
		}

		private void autocarverCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (autocarverCheckBox.Checked)
			{
				RazorEnhanced.Filters.AutoCarver = true;
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("AutoCarver Engine Start...");
			}
			else
			{
				RazorEnhanced.Filters.AutoCarver = false;
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("AutoCarver Engine Stop...");
			}

			if (autocarverCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("AutoCarverCheckBox", autocarverCheckBox.Checked);
		}

		private void bonecutterCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (bonecutterCheckBox.Checked)
			{
				RazorEnhanced.Filters.BoneCutter = true;
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("BoneCutter Engine Start...");
			}
			else
			{
				RazorEnhanced.Filters.BoneCutter = false;
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("BoneCutter Engine Start...");
			}

			if (bonecutterCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BoneCutterCheckBox", bonecutterCheckBox.Checked);
		}

		private void highlighttargetCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (highlighttargetCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("HighlightTargetCheckBox", highlighttargetCheckBox.Checked);
		}

		private void flagsHighlightCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (flagsHighlightCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("FlagsHighlightCheckBox", flagsHighlightCheckBox.Checked);
		}

		private void showstaticfieldCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (showstaticfieldCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("ShowStaticFieldCheckBox", showstaticfieldCheckBox.Checked);
		}

		private void blocktraderequestCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (blocktraderequestCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BlockTradeRequestCheckBox", blocktraderequestCheckBox.Checked);
		}

		private void blockpartyinviteCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (blockpartyinviteCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BlockPartyInviteCheckBox", blockpartyinviteCheckBox.Checked);
		}

		private void showheadtargetCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (showheadtargetCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("ShowHeadTargetCheckBox", showheadtargetCheckBox.Checked);
		}

		private void blockhealpoisonCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (blockhealpoisonCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BlockHealPoison", blockhealpoisonCheckBox.Checked);
		}

		private void colorflagsHighlightCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (colorflagsHighlightCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("ColorFlagsHighlightCheckBox", colorflagsHighlightCheckBox.Checked);
		}

		private void blockminihealCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (blockminihealCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BlockMiniHealCheckBox", blockminihealCheckBox.Checked);
		}

		private void blockbighealCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (blockbighealCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BlockBigHealCheckBox", blockbighealCheckBox.Checked);
		}

		private void blockchivalryhealCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (blockchivalryhealCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("BlockChivalryHealCheckBox", blockchivalryhealCheckBox.Checked);
		}

		private void showmessagefieldCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (showmessagefieldCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("ShowMessageFieldCheckBox", showmessagefieldCheckBox.Checked);
		}

		private void showagentmessageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (showagentmessageCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("ShowAgentMessageCheckBox", showagentmessageCheckBox.Checked);
		}

		private void mobfilterRemoveButton_Click(object sender, EventArgs e)
		{
			if (mobfilterlistView.SelectedItems.Count == 1)
			{
				int index = mobfilterlistView.SelectedIndices[0];
				int graph = 0;
				try
				{
					graph = Convert.ToInt32(mobfilterlistView.Items[index].SubItems[1].Text.ToString(), 16);
				}
				catch
				{ }

				RazorEnhanced.Settings.GraphFilter.Delete(graph);
				RazorEnhanced.Filters.RefreshLists();
			}
		}

		private void mobfilterAddButton_Click(object sender, EventArgs e)
		{
			EnhancedGraphFilterAdd ManualAddGraphFilter = new EnhancedGraphFilterAdd();
			ManualAddGraphFilter.TopMost = true;
			ManualAddGraphFilter.Show();
		}

		private void mobfilterlistView_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (mobfilterlistView.FocusedItem != null)
			{
				ListViewItem item = e.Item as ListViewItem;
				RazorEnhanced.Filters.UpdateSelectedItems(item.Index);
			}
		}

		private void mobfilterCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
			{
				if (mobfilterCheckBox.Checked)
					RazorEnhanced.Misc.SendMessage("Graphics changer filter: ENABLED!");
				else
					RazorEnhanced.Misc.SendMessage("Graphics changer filter: DISABLED!");
			}

			if (mobfilterCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("MobFilterCheckBox", mobfilterCheckBox.Checked);
		}

		private void remountdelay_TextChanged(object sender, EventArgs e)
		{
			if (remountdelay.Focused)
			{
				int delay = 100;
				Int32.TryParse(Assistant.Engine.MainWindow.remountdelay.Text, out delay);
				RazorEnhanced.Filters.AutoRemountDelay = delay;
				RazorEnhanced.Settings.General.WriteInt("MountDelay", delay);
			}
		}

		private void remountedelay_TextChanged(object sender, EventArgs e)
		{
			if (remountedelay.Focused)
			{
				int delay = 100;
				Int32.TryParse(Assistant.Engine.MainWindow.remountedelay.Text, out delay);
				RazorEnhanced.Filters.AutoRemountEDelay = delay;
				RazorEnhanced.Settings.General.WriteInt("EMountDelay", delay);
			}
		}

		private void remountcheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (remountcheckbox.Checked)
			{
				RazorEnhanced.Filters.AutoModeRemount = true;
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("AutoRemount Engine Start...");
			}
			else
			{
				RazorEnhanced.Filters.AutoModeRemount = false;
				if (Settings.General.ReadBool("ShowAgentMessageCheckBox"))
					RazorEnhanced.Misc.SendMessage("AutoRemount Engine Stop...");
			}

			if (remountcheckbox.Focused)
				RazorEnhanced.Settings.General.WriteBool("RemountCheckbox", remountcheckbox.Checked);
		}

		private void remountsetbutton_Click(object sender, EventArgs e)
		{
			Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(remountSetMountTarget_Callback));
		}

		private void remountSetMountTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			if (serial != 0)
			{
				RazorEnhanced.Filters.AutoRemountSerial = serial;
				RazorEnhanced.Settings.General.WriteInt("MountSerial", serial);
			}
		}

		// ---------------- FILTERS END ----------------

		private void timerupdatestatus_Tick(object sender, EventArgs e)
		{
			UpdateRazorStatus();
			UpdateScriptGrid();
			RazorEnhanced.ToolBar.UpdateCount();
		}

		// ---------------- TOOLBAR START ----------------
		private void openToolBarButton_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ToolBar.Open();
		}

		private void closeToolBarButton_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ToolBar.Close();
		}

		private void lockToolBarCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (lockToolBarCheckBox.Focused)
			{
				RazorEnhanced.ToolBar.LockUnlock();
				RazorEnhanced.Settings.General.WriteBool("LockToolBarCheckBox", lockToolBarCheckBox.Checked);
				if (RazorEnhanced.ToolBar.ToolBarForm != null)
					RazorEnhanced.ToolBar.ToolBarForm.Show();
			}
		}

		private void autoopenToolBarCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (autoopenToolBarCheckBox.Focused)
				RazorEnhanced.Settings.General.WriteBool("AutoopenToolBarCheckBox", autoopenToolBarCheckBox.Checked);
		}

		private void toolboxcountComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = toolboxcountComboBox.SelectedIndex;
			RazorEnhanced.ToolBar.ToolBarItem item = RazorEnhanced.Settings.Toolbar.ReadSelectedItem(index);

			toolboxcountNameTextBox.Text = item.Name;
			toolboxcountHueTextBox.Text = "0x" + item.Color.ToString("X4");
			toolboxcountGraphTextBox.Text = "0x" + item.Graphics.ToString("X4");
			toolboxcountHueWarningCheckBox.Checked = item.Warning;
			toolboxcountWarningTextBox.Text = item.WarningLimit.ToString();

			if (toolboxcountComboBox.Focused)
				RazorEnhanced.ToolBar.Open();
		}

		private void toolboxcountNameTextBox_TextChanged(object sender, EventArgs e)
		{
			if (toolboxcountNameTextBox.Focused)
			{
				int index = toolboxcountComboBox.SelectedIndex;
				RazorEnhanced.Settings.Toolbar.UpdateItem(index, toolboxcountNameTextBox.Text, toolboxcountGraphTextBox.Text, toolboxcountHueTextBox.Text, toolboxcountHueWarningCheckBox.Checked, toolboxcountWarningTextBox.Text);
				RazorEnhanced.ToolBar.UptateToolBarComboBox(index);
				RazorEnhanced.ToolBar.Open();
			}
		}

		private void toolboxcountGraphTextBox_TextChanged(object sender, EventArgs e)
		{
			if (toolboxcountGraphTextBox.Focused)
			{
				RazorEnhanced.Settings.Toolbar.UpdateItem(toolboxcountComboBox.SelectedIndex, toolboxcountNameTextBox.Text, toolboxcountGraphTextBox.Text, toolboxcountHueTextBox.Text, toolboxcountHueWarningCheckBox.Checked, toolboxcountWarningTextBox.Text);
				RazorEnhanced.ToolBar.UpdatePanelImage();
				RazorEnhanced.ToolBar.UpdateCount();
				RazorEnhanced.ToolBar.Open();
			}
		}

		private void toolboxcountHueTextBox_TextChanged(object sender, EventArgs e)
		{
			if (toolboxcountHueTextBox.Focused)
			{
				RazorEnhanced.Settings.Toolbar.UpdateItem(toolboxcountComboBox.SelectedIndex, toolboxcountNameTextBox.Text, toolboxcountGraphTextBox.Text, toolboxcountHueTextBox.Text, toolboxcountHueWarningCheckBox.Checked, toolboxcountWarningTextBox.Text);
				RazorEnhanced.ToolBar.UpdatePanelImage();
				RazorEnhanced.ToolBar.Open();
			}
		}

		private void toolboxcountHueWarningCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (toolboxcountHueWarningCheckBox.Focused)
				RazorEnhanced.Settings.Toolbar.UpdateItem(toolboxcountComboBox.SelectedIndex, toolboxcountNameTextBox.Text, toolboxcountGraphTextBox.Text, toolboxcountHueTextBox.Text, toolboxcountHueWarningCheckBox.Checked, toolboxcountWarningTextBox.Text);
		}

		private void toolboxcountWarningTextBox_TextChanged(object sender, EventArgs e)
		{
			if (toolboxcountWarningTextBox.Focused)
				RazorEnhanced.Settings.Toolbar.UpdateItem(toolboxcountComboBox.SelectedIndex, toolboxcountNameTextBox.Text, toolboxcountGraphTextBox.Text, toolboxcountHueTextBox.Text, toolboxcountHueWarningCheckBox.Checked, toolboxcountWarningTextBox.Text);
		}

		private void toolboxcountClearButton_Click(object sender, EventArgs e)
		{
			int index = toolboxcountComboBox.SelectedIndex;
			toolboxcountNameTextBox.Text = "Empty";
			toolboxcountGraphTextBox.Text = "0x0000";
			toolboxcountHueTextBox.Text = "0x0000";
			toolboxcountHueWarningCheckBox.Checked = false;
			toolboxcountWarningTextBox.Text = "0";
			RazorEnhanced.Settings.Toolbar.UpdateItem(toolboxcountComboBox.SelectedIndex, toolboxcountNameTextBox.Text, toolboxcountGraphTextBox.Text, toolboxcountHueTextBox.Text, toolboxcountHueWarningCheckBox.Checked, toolboxcountWarningTextBox.Text);
			RazorEnhanced.ToolBar.UptateToolBarComboBox(index);
			RazorEnhanced.ToolBar.UpdatePanelImage();
			RazorEnhanced.ToolBar.UpdateCount();
		}

		private void toolboxcountTargetButton_Click(object sender, EventArgs e)
		{
			Targeting.OneTimeTarget(new Targeting.TargetResponseCallback(ToolBarItemTarget_Callback));
		}

		private void ToolBarItemTarget_Callback(bool loc, Assistant.Serial serial, Assistant.Point3D pt, ushort itemid)
		{
			this.BeginInvoke((MethodInvoker)delegate
			{
				int index = toolboxcountComboBox.SelectedIndex;
				Assistant.Item item = Assistant.World.FindItem(serial);

				if (item == null)
					return;

				if (item.Serial.IsItem)
				{
					toolboxcountNameTextBox.Text = item.Name;
					int itemgraph = item.ItemID;
					toolboxcountGraphTextBox.Text = itemgraph.ToString("X4");
					toolboxcountHueTextBox.Text = item.Hue.ToString("X4");
					RazorEnhanced.Settings.Toolbar.UpdateItem(toolboxcountComboBox.SelectedIndex, toolboxcountNameTextBox.Text, toolboxcountGraphTextBox.Text, toolboxcountHueTextBox.Text, toolboxcountHueWarningCheckBox.Checked, toolboxcountWarningTextBox.Text);
					RazorEnhanced.ToolBar.UptateToolBarComboBox(index);
					RazorEnhanced.ToolBar.UpdatePanelImage();
					RazorEnhanced.ToolBar.UpdateCount();
				}
			});
		}

		private void toolboxstyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (toolboxstyleComboBox.Focused)
			{
				RazorEnhanced.Settings.General.WriteString("ToolBoxStyleComboBox", toolboxstyleComboBox.Text);
				RazorEnhanced.ToolBar.Close();
				RazorEnhanced.ToolBar.Open();
			}
		}

		private void toolboxsizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (toolboxsizeComboBox.Focused)
			{
				RazorEnhanced.Settings.General.WriteString("ToolBoxSizeComboBox", toolboxsizeComboBox.Text);
				if (toolboxsizeComboBox.SelectedItem.ToString() == "Big")
				{
					int slot = 2;
					Int32.TryParse(toolbarslot_label.Text, out slot);
					if (slot == 0)
						slot = 2;

					if (slot % 2 != 0)
					{
						toolbarslot_label.Text = slot.ToString();
						RazorEnhanced.Settings.General.WriteInt("ToolBoxSlotsTextBox", slot);
					}
				}
				RazorEnhanced.ToolBar.Close();
				RazorEnhanced.ToolBar.Open();
			}
		}

		private void toolbaraddslotButton_Click(object sender, EventArgs e)
		{
			int slot = RazorEnhanced.Settings.General.ReadInt("ToolBoxSlotsTextBox");
			if (toolboxsizeComboBox.SelectedItem.ToString() == "Big")
			{
				slot += 2;
			}
			else
				slot += 1;

			RazorEnhanced.Settings.General.WriteInt("ToolBoxSlotsTextBox", slot);
			RazorEnhanced.ToolBar.Close();
			RazorEnhanced.ToolBar.Open();
		}

		private void toolbarremoveslotButton_Click(object sender, EventArgs e)
		{
			int slot = RazorEnhanced.Settings.General.ReadInt("ToolBoxSlotsTextBox");
			if (toolboxsizeComboBox.SelectedItem.ToString() == "Big")
				if (slot - 2 < 2)
					slot = 2;
				else
					slot -= 2;
			else
				if (slot - 1 < 1)
				slot = 1;
			else
				slot -= 1;

			toolbarslot_label.Text = slot.ToString();
			RazorEnhanced.Settings.General.WriteInt("ToolBoxSlotsTextBox", slot);

			RazorEnhanced.ToolBar.Close();
			RazorEnhanced.ToolBar.Open();
		}

		private void showhitsToolBarCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (showhitsToolBarCheckBox.Focused)
			{
				RazorEnhanced.Settings.General.WriteBool("ShowHitsToolBarCheckBox", showhitsToolBarCheckBox.Checked);
				RazorEnhanced.ToolBar.Close();
				RazorEnhanced.ToolBar.Open();
			}
		}

		private void showstaminaToolBarCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (showstaminaToolBarCheckBox.Focused)
			{
				RazorEnhanced.Settings.General.WriteBool("ShowStaminaToolBarCheckBox", showstaminaToolBarCheckBox.Checked);
				RazorEnhanced.ToolBar.Close();
				RazorEnhanced.ToolBar.Open();
			}
		}

		private void showmanaToolBarCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (showmanaToolBarCheckBox.Focused)
			{
				RazorEnhanced.Settings.General.WriteBool("ShowManaToolBarCheckBox", showmanaToolBarCheckBox.Checked);
				RazorEnhanced.ToolBar.Close();
				RazorEnhanced.ToolBar.Open();
			}
		}

		private void showweightToolBarCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (showweightToolBarCheckBox.Focused)
			{
				RazorEnhanced.Settings.General.WriteBool("ShowWeightToolBarCheckBox", showweightToolBarCheckBox.Checked);
				RazorEnhanced.ToolBar.Close();
				RazorEnhanced.ToolBar.Open();
			}
		}

		private void showfollowerToolBarCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (showfollowerToolBarCheckBox.Focused)
			{
				RazorEnhanced.Settings.General.WriteBool("ShowFollowerToolBarCheckBox", showfollowerToolBarCheckBox.Checked);
				RazorEnhanced.ToolBar.Close();
				RazorEnhanced.ToolBar.Open();
			}
		}

		private void toolbar_trackBar_Scroll(object sender, EventArgs e)
		{
			int o = toolbar_trackBar.Value;

			if (toolbar_trackBar.Focused)
			{
				RazorEnhanced.Settings.General.WriteInt("ToolBarOpacity", o);
				if (RazorEnhanced.ToolBar.ToolBarForm != null)
				{
					RazorEnhanced.ToolBar.ToolBarForm.Show();
					RazorEnhanced.ToolBar.ToolBarForm.Opacity = ((double)o) / 100.0;
				}
			}

			toolbar_opacity_label.Text = String.Format("{0}%", o);
		}
		// ---------------- TOOLBAR END ----------------

		// ----------------- HOT KEY -----------------------
		private void hotkeySetButton_Click(object sender, EventArgs e)
		{
			if (hotkeytreeView.SelectedNode != null && hotkeytreeView.SelectedNode.Name != null && hotkeytextbox.Text != "" && hotkeytextbox.Text != "None")
			{
				if (hotkeytreeView.SelectedNode.Name == "")
				{
					return;
				}
				if (hotkeytreeView.SelectedNode.Parent.Name != null && hotkeytreeView.SelectedNode.Parent.Name == "TList")
					RazorEnhanced.HotKey.UpdateTargetKey(hotkeytreeView.SelectedNode, hotkeypassCheckBox.Checked);     // Aggiorno hotkey target
				else if (hotkeytreeView.SelectedNode.Parent.Name != null && hotkeytreeView.SelectedNode.Parent.Name == "SList")
				{
					RazorEnhanced.HotKey.UpdateScriptKey(hotkeytreeView.SelectedNode, hotkeypassCheckBox.Checked);     // Aggiorno hotkey Script
				}
				else if (hotkeytreeView.SelectedNode.Parent.Name != null && hotkeytreeView.SelectedNode.Parent.Name == "DList")
				{
					RazorEnhanced.HotKey.UpdateDressKey(hotkeytreeView.SelectedNode, hotkeypassCheckBox.Checked);     // Aggiorno hotkey Dress List
				}
				else
					RazorEnhanced.HotKey.UpdateKey(hotkeytreeView.SelectedNode, hotkeypassCheckBox.Checked);
			}
		}

		private void hotkeyClearButton_Click(object sender, EventArgs e)
		{
			if (hotkeytreeView.SelectedNode != null && hotkeytreeView.SelectedNode.Name != null)
			{
				if (hotkeytreeView.SelectedNode.Name == "")
				{
					return;
				}
				if (hotkeytreeView.SelectedNode.Parent.Name != null)
					RazorEnhanced.HotKey.ClearKey(hotkeytreeView.SelectedNode, hotkeytreeView.SelectedNode.Parent.Name);
				else
					RazorEnhanced.HotKey.ClearKey(hotkeytreeView.SelectedNode, "General");
			}
			hotkeytextbox.Text = Keys.None.ToString();
		}

		private void hotkeytreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (hotkeytreeView.SelectedNode != null && hotkeytreeView.SelectedNode.Name != null)
			{
				bool passkey = true;
				Keys k = Keys.None;
				RazorEnhanced.Settings.HotKey.FindKeyGui(hotkeytreeView.SelectedNode.Name, out k, out passkey);
				hotkeytextbox.Text = HotKey.KeyString(k);
				hotkeypassCheckBox.Checked = passkey;
			}
		}

		private void hotkeyMasterSetButton_Click(object sender, EventArgs e)
		{
			if (hotkeyKeyMasterTextBox.Text != "" && hotkeyKeyMasterTextBox.Text != "None")
			{
				RazorEnhanced.HotKey.UpdateMaster();
				hotkeyKeyMasterTextBox.Text = "";
			}
		}

		private void hotkeyMasterClearButton_Click(object sender, EventArgs e)
		{
			RazorEnhanced.HotKey.ClearMasterKey();
		}

		private void hotkeyEnableButton_Click(object sender, EventArgs e)
		{
			Assistant.Engine.MainWindow.HotKeyStatusLabel.Text = "Status: Enable";
			RazorEnhanced.Settings.General.WriteBool("HotKeyEnable", true);
			if (World.Player != null)
				RazorEnhanced.Misc.SendMessageNoWait("HotKey: ENABLED", 168);
		}

		private void hotkeyDisableButton_Click(object sender, EventArgs e)
		{
			RazorEnhanced.Settings.General.WriteBool("HotKeyEnable", false);
			Assistant.Engine.MainWindow.HotKeyStatusLabel.Text = "Status: Disable";
			if (World.Player != null)
				RazorEnhanced.Misc.SendMessageNoWait("HotKey: DISABLED", 37);
		}

		// ----------------- HOT KEY END -------------------

		// ----------------- PROFILES START -------------------
		private void profilesAddButton_Click(object sender, EventArgs e)
		{
			EnhancedProfileAdd addprofile = new EnhancedProfileAdd();
			addprofile.TopMost = true;
			addprofile.Show();
		}

		private void profilesDeleteButton_Click(object sender, EventArgs e)
		{
			string profiletodelete = profilesComboBox.Text;

			DialogResult dialogResult = MessageBox.Show("Are you sure to delete this profile: " + profiletodelete, "Delete Profile?", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				if (profiletodelete == "default")
				{
					MessageBox.Show("Can't delete default profile",
					"Can't delete default profile!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);
				}
				else
				{
					RazorEnhanced.Profiles.SetLast("default");
					RazorEnhanced.Profiles.Delete(profiletodelete);
					RazorEnhanced.Profiles.Refresh();
					RazorEnhanced.Profiles.ProfileChange("default");
					try
					{
						File.Delete(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "RazorEnhanced." + profiletodelete + ".settings"));
					}
					catch
					{ }
				}
			}
		}

		private void profilesComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (profilesComboBox.Focused)
			{
				if (RazorEnhanced.Profiles.LastUsed() != profilesComboBox.Text)
				{
					RazorEnhanced.Profiles.ProfileChange(profilesComboBox.Text);
				}
			}
			profilelinklabel.Text = "Linked to: " + RazorEnhanced.Profiles.GetLinkName(profilesComboBox.Text);
		}

		private void profilesLinkButton_Click(object sender, EventArgs e)
		{
			if (World.Player == null)
			{
				MessageBox.Show("You can't link a profile to player if not logged in game",
				"Profiles",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation,
				MessageBoxDefaultButton.Button1);
				return;
			}

			RazorEnhanced.Profiles.Link(World.Player.Serial, profilesComboBox.Text, World.Player.Name);
			profilelinklabel.Text = "Linked to: " + World.Player.Name;
			Misc.SendMessage("Profile: " + profilesComboBox.Text + " linked to player: " + World.Player.Name);
		}

		private void profilesUnlinkButton_Click(object sender, EventArgs e)
		{
			RazorEnhanced.Profiles.UnLink(profilesComboBox.Text);
			profilelinklabel.Text = "Linked to: None";
		}

		private void profilesRenameButton_Click(object sender, EventArgs e)
		{
			if (profilesComboBox.Text == "default")
			{
				MessageBox.Show("Can't rename default profile",
				"Can't rename default profile!",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation,
				MessageBoxDefaultButton.Button1);
			}
			else
			{
				EnhancedProfileRename renameprofile = new EnhancedProfileRename();
				renameprofile.TopMost = true;
				renameprofile.Show();
			}
		}

		private void profilesCloneButton_Click(object sender, EventArgs e)
		{
			EnhancedProfileClone cloneprofile = new EnhancedProfileClone();
			cloneprofile.TopMost = true;
			cloneprofile.Show();
		}

		private void profilesExportButton_Click(object sender, EventArgs e)
		{
			RazorEnhanced.ImportExport.ExportProfiles(profilesComboBox.Text);
		}

		private void profilesImportButton_Click(object sender, EventArgs e)
		{
			EnhancedProfileImport importprofile = new EnhancedProfileImport();
			importprofile.TopMost = true;
			importprofile.Show();
		}

		// ----------------- PROFILES END -------------------

		// ----------------- FEATURE START -------------------

		public void UpdateControlLocks()
		{
			if (File.Exists(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "bypassnegoziate")))
				return;

			if (!ClientCommunication.AllowBit(FeatureBit.AutolootAgent))
			{
				autoLootCheckBox.Enabled = false;
				autoLootCheckBox.Checked = false;
				if (RazorEnhanced.AutoLoot.Status())
					RazorEnhanced.AutoLoot.Stop();
			}
			else
			{
				if (!autoLootCheckBox.Enabled)
					autoLootCheckBox.Enabled = true;
			}

			if (!ClientCommunication.AllowBit(FeatureBit.RangeCheckLT))
			{
				rangeCheckLT.Checked = false;
				rangeCheckLT.Enabled = false;
				Settings.General.WriteBoolNoSave("RangeCheckLT", false);
			}
			else
			{
				if (!rangeCheckLT.Enabled)
					rangeCheckLT.Enabled = true;
			}


			if (!ClientCommunication.AllowBit(FeatureBit.AutoOpenDoors))
			{
				autoOpenDoors.Checked = false;
				autoOpenDoors.Enabled = false;
				Settings.General.WriteBoolNoSave("AutoOpenDoors", false);
			}
			else
			{
				if (!autoOpenDoors.Enabled)
					autoOpenDoors.Enabled = true;
			}


			if (!ClientCommunication.AllowBit(FeatureBit.UnequipBeforeCast))
			{
				spellUnequip.Checked = false;
				spellUnequip.Enabled = false;
				Settings.General.WriteBoolNoSave("SpellUnequip", false);
			}
			else
			{
				if (!spellUnequip.Enabled)
					spellUnequip.Enabled = true;
			}

			if (!ClientCommunication.AllowBit(FeatureBit.AutoPotionEquip))
			{
				potionEquip.Checked = false;
				potionEquip.Enabled = false;
				Settings.General.WriteBoolNoSave("PotionEquip", false);
			}
			else
			{
				if (!potionEquip.Enabled)
					potionEquip.Enabled = true;
			}

			if (!ClientCommunication.AllowBit(FeatureBit.BlockHealPoisoned))
			{
				blockhealpoisonCheckBox.Checked = false;
				blockhealpoisonCheckBox.Enabled = false;
				Settings.General.WriteBoolNoSave("BlockHealPoison", false);
			}
			else
			{
				if (!blockhealpoisonCheckBox.Enabled)
					blockhealpoisonCheckBox.Enabled = true;
			}

			if (!ClientCommunication.AllowBit(FeatureBit.SellAgent))
			{
				sellEnableCheckBox.Enabled = false;
				sellEnableCheckBox.Checked = false;
			}
			else
			{
				if (!sellEnableCheckBox.Enabled)
					sellEnableCheckBox.Enabled = true;
			}


			if (!ClientCommunication.AllowBit(FeatureBit.BuyAgent))
			{
				buyEnableCheckBox.Enabled = false;
				buyEnableCheckBox.Checked = false;
			}
			else
			{
				if (!buyEnableCheckBox.Enabled)
					buyEnableCheckBox.Enabled = true;
			}

			if (!ClientCommunication.AllowBit(FeatureBit.OverheadHealth))
			{
				chkPartyOverhead.Checked = false;
				chkPartyOverhead.Enabled = false;
				Settings.General.WriteBoolNoSave("ShowPartyStats", false);
			}
			else
			{
				if (!chkPartyOverhead.Enabled)
					chkPartyOverhead.Enabled = true;
			}

			if (!ClientCommunication.AllowBit(FeatureBit.BoneCutterAgent))
			{
				bonecutterCheckBox.Checked = false;
				bonecutterCheckBox.Enabled = false;
				Settings.General.WriteBoolNoSave("BoneCutterCheckBox", false);
			}
			else
			{
				if (!bonecutterCheckBox.Enabled)
					bonecutterCheckBox.Enabled = true;
			}

			if (!ClientCommunication.AllowBit(FeatureBit.AutoRemount))
			{
				remountcheckbox.Checked = false;
				remountcheckbox.Enabled = false;
				Settings.General.WriteBoolNoSave("RemountCheckbox", false);
			}
			else
			{
				if (!remountcheckbox.Enabled)
					remountcheckbox.Enabled = true;
			}


			if (!ClientCommunication.AllowBit(FeatureBit.AutoBandage))
			{
				bandagehealenableCheckBox.Enabled = false;
				bandagehealenableCheckBox.Checked = false;
				if (RazorEnhanced.BandageHeal.Status())
					RazorEnhanced.BandageHeal.Stop();
			}
			else
			{
				if (!bandagehealenableCheckBox.Enabled)
					bandagehealenableCheckBox.Enabled = true;
			}

		}
		// ----------------- FEATURE END -------------------

		// ----------------- CHECK UPDATE START -------------------

		private static string UniqueMachineId()
		{
			string cpuInfo = string.Empty;
			ManagementClass mc = new ManagementClass("win32_processor");
			ManagementObjectCollection moc = mc.GetInstances();

			foreach (ManagementObject mo in moc)
			{
				cpuInfo = mo.Properties["processorID"].Value.ToString();
				break;
			}
			return cpuInfo;
		}


		internal static void VersionCheckWorker()
		{
			WebClient client = new WebClient();

			// Controllo versione
			try // Try catch in caso che il server sia irraggiungibile
			{
				string reply = client.DownloadString("http://razorenhanced.org/download/version.dat");

				if (reply != Assembly.GetEntryAssembly().GetName().Version.ToString())
				{
					DialogResult dialogResult = MessageBox.Show("A newer version of Razor Enhanced is available! Do you want to open your browser to download it?", "Newer Version Available", MessageBoxButtons.YesNo);
					if (dialogResult == DialogResult.Yes)
					{
						System.Diagnostics.Process.Start("http://www.razorenhanced.org/");
					}
				}
			}
			catch
			{
			}

			// Utilizzo
			try // Try catch in caso che il server sia irraggiungibile
			{
				string reply = client.DownloadString("http://razorenhanced.org/use.php?Serial=" + UniqueMachineId());
			}
			catch
			{
			}

		}
		// ----------------- CHECK UPDATE END -------------------

		// ----------------- GRID START -------------------

		private void gridopen_button_Click(object sender, EventArgs e)
		{
			RazorEnhanced.SpellGrid.Open();
		}

		private void gridclose_button_Click(object sender, EventArgs e)
		{
			RazorEnhanced.SpellGrid.Close();
		}

		private void gridlock_CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (gridlock_CheckBox.Focused)
			{
				SpellGrid.LockUnlock();
				Settings.General.WriteBool("LockGridCheckBox", gridlock_CheckBox.Checked);
			}
		}

		private void gridopenlogin_CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (gridopenlogin_CheckBox.Focused)
				Settings.General.WriteBool("GridOpenLoginCheckBox", gridopenlogin_CheckBox.Checked);
		}

		private void gridslot_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = gridslot_ComboBox.SelectedIndex;
			SpellGrid.SpellGridItem item = Settings.SpellGrid.ReadSelectedItem(index);
			gridgroup_ComboBox.SelectedIndex = gridgroup_ComboBox.Items.IndexOf(item.Group);
			if (item.Group != "Empty")
			{
				gridspell_ComboBox.SelectedIndex = gridspell_ComboBox.Items.IndexOf(item.Spell);
				gridborder_ComboBox.SelectedIndex = gridborder_ComboBox.Items.IndexOf(item.Color.Name);
				gridspell_ComboBox.Enabled = true;
				gridborder_ComboBox.Enabled = true;
			}
			else
			{
				Settings.SpellGrid.UpdateItem(gridslot_ComboBox.SelectedIndex, gridgroup_ComboBox.Text, gridspell_ComboBox.Text, System.Drawing.Color.Transparent);
				gridspell_ComboBox.SelectedIndex = -1;
				gridborder_ComboBox.SelectedIndex = -1;
				gridspell_ComboBox.Enabled = false;
				gridborder_ComboBox.Enabled = false;
			}

			if (gridslot_ComboBox.Focused)
				SpellGrid.Open();
		}

		private void gridgroup_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (gridgroup_ComboBox.Text)
			{
				case "Empty":
					{
						gridspell_ComboBox.Items.Clear();
						gridspell_ComboBox.Enabled = gridborder_ComboBox.Enabled = false;
						gridspell_ComboBox.SelectedIndex = gridborder_ComboBox.SelectedIndex = -1;
						if (gridgroup_ComboBox.Focused)
							SpellGrid.Close();
						break;
					}
				case "Magery":
					{
						gridspell_ComboBox.Items.Clear();
						foreach (string spell in SpellGrid.SpellIconMagery.Keys)
							gridspell_ComboBox.Items.Add(spell);
						gridspell_ComboBox.Enabled = gridborder_ComboBox.Enabled = true;
						gridspell_ComboBox.SelectedIndex = gridborder_ComboBox.SelectedIndex = 0;
						break;
					}
				case "Abilities":
					{
						gridspell_ComboBox.Items.Clear();
						foreach (string spell in SpellGrid.SpellIconAbilities.Keys)
							gridspell_ComboBox.Items.Add(spell);
						gridspell_ComboBox.Enabled = gridborder_ComboBox.Enabled = true;
						gridspell_ComboBox.SelectedIndex = gridborder_ComboBox.SelectedIndex = 0;
						break;
					}
				case "Mastery":
					{
						gridspell_ComboBox.Items.Clear();
						foreach (string spell in SpellGrid.SpellIconMastery.Keys)
							gridspell_ComboBox.Items.Add(spell);
						gridspell_ComboBox.Enabled = gridborder_ComboBox.Enabled = true;
						gridspell_ComboBox.SelectedIndex = gridborder_ComboBox.SelectedIndex = 0;
						break;
					}
				case "Bushido":
					{
						gridspell_ComboBox.Items.Clear();
						foreach (string spell in SpellGrid.SpellIconBushido.Keys)
							gridspell_ComboBox.Items.Add(spell);
						gridspell_ComboBox.Enabled = gridborder_ComboBox.Enabled = true;
						gridspell_ComboBox.SelectedIndex = gridborder_ComboBox.SelectedIndex = 0;
						break;
					}
				case "Chivalry":
					{
						gridspell_ComboBox.Items.Clear();
						foreach (string spell in SpellGrid.SpellIconChivalry.Keys)
							gridspell_ComboBox.Items.Add(spell);
						gridspell_ComboBox.Enabled = gridborder_ComboBox.Enabled = true;
						gridspell_ComboBox.SelectedIndex = gridborder_ComboBox.SelectedIndex = 0;
						break;
					}
				case "Necromancy":
					{
						gridspell_ComboBox.Items.Clear();
						foreach (string spell in SpellGrid.SpellIconNecromancy.Keys)
							gridspell_ComboBox.Items.Add(spell);
						gridspell_ComboBox.Enabled = gridborder_ComboBox.Enabled = true;
						gridspell_ComboBox.SelectedIndex = gridborder_ComboBox.SelectedIndex = 0;
						break;
					}
				case "Ninjitsu":
					{
						gridspell_ComboBox.Items.Clear();
						foreach (string spell in SpellGrid.SpellIconNinjitsu.Keys)
							gridspell_ComboBox.Items.Add(spell);
						gridspell_ComboBox.Enabled = gridborder_ComboBox.Enabled = true;
						gridspell_ComboBox.SelectedIndex = gridborder_ComboBox.SelectedIndex = 0;
						break;
					}
				case "Mysticism":
					{
						gridspell_ComboBox.Items.Clear();
						foreach (string spell in SpellGrid.SpellIconMysticism.Keys)
							gridspell_ComboBox.Items.Add(spell);
						gridspell_ComboBox.Enabled = gridborder_ComboBox.Enabled = true;
						gridspell_ComboBox.SelectedIndex = gridborder_ComboBox.SelectedIndex = 0;
						break;
					}
				case "Spellweaving":
					{
						gridspell_ComboBox.Items.Clear();
						foreach (string spell in SpellGrid.SpellIconSpellweaving.Keys)
							gridspell_ComboBox.Items.Add(spell);
						gridspell_ComboBox.Enabled = gridborder_ComboBox.Enabled = true;
						gridspell_ComboBox.SelectedIndex = gridborder_ComboBox.SelectedIndex = 0;
						break;
					}
				default:
					break;
			}
			if (gridgroup_ComboBox.Focused)
			{
				Settings.SpellGrid.UpdateItem(gridslot_ComboBox.SelectedIndex, gridgroup_ComboBox.Text, gridspell_ComboBox.Text, System.Drawing.Color.Transparent);
				SpellGrid.Open();
			}
		}

		private void gridspell_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (gridspell_ComboBox.Focused)
			{
				gridborder_ComboBox.SelectedIndex = 0;
				Settings.SpellGrid.UpdateItem(gridslot_ComboBox.SelectedIndex, gridgroup_ComboBox.Text, gridspell_ComboBox.Text, System.Drawing.Color.Transparent);
				SpellGrid.Open();
			}
		}

		private void gridborder_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (gridborder_ComboBox.Focused)
			{
				Settings.SpellGrid.UpdateItem(gridslot_ComboBox.SelectedIndex, gridgroup_ComboBox.Text, gridspell_ComboBox.Text, System.Drawing.Color.FromName(gridborder_ComboBox.SelectedItem.ToString()));
				SpellGrid.Open();
			}
		}

		private void gridvslotadd_button_Click(object sender, EventArgs e)
		{
			if (SpellGrid.VSlot + SpellGrid.HSlot == 99)
				return;

			int slot = RazorEnhanced.Settings.General.ReadInt("GridVSlot");
			slot += 1;

			RazorEnhanced.Settings.General.WriteInt("GridVSlot", slot);
			RazorEnhanced.SpellGrid.VSlot = slot;
			gridvslot_textbox.Text = slot.ToString();
			RazorEnhanced.SpellGrid.UpdateBox();
			RazorEnhanced.SpellGrid.Close();
			RazorEnhanced.SpellGrid.Open();
		}

		private void gridvslotremove_button_Click(object sender, EventArgs e)
		{
			int slot = RazorEnhanced.Settings.General.ReadInt("GridVSlot");
			if (slot - 1 > 0)
			{
				slot -= 1;
				RazorEnhanced.Settings.General.WriteInt("GridVSlot", slot);
				RazorEnhanced.SpellGrid.VSlot = slot;
				gridvslot_textbox.Text = slot.ToString();
				RazorEnhanced.SpellGrid.UpdateBox();
				RazorEnhanced.SpellGrid.Close();
				RazorEnhanced.SpellGrid.Open();
			}
		}

		private void gridhslotadd_button_Click(object sender, EventArgs e)
		{
			if (SpellGrid.VSlot + SpellGrid.HSlot == 99)
				return;

			int slot = RazorEnhanced.Settings.General.ReadInt("GridHSlot");
			slot += 1;

			RazorEnhanced.Settings.General.WriteInt("GridHSlot", slot);
			RazorEnhanced.SpellGrid.HSlot = slot;
			gridhslot_textbox.Text = slot.ToString();
			RazorEnhanced.SpellGrid.UpdateBox();
			RazorEnhanced.SpellGrid.Close();
			RazorEnhanced.SpellGrid.Open();
		}

		private void gridhslotremove_button_Click(object sender, EventArgs e)
		{
			int slot = RazorEnhanced.Settings.General.ReadInt("GridHSlot");
			if (slot - 1 > 0)
			{
				slot -= 1;
				RazorEnhanced.Settings.General.WriteInt("GridHSlot", slot);
				RazorEnhanced.SpellGrid.HSlot = slot;
				gridhslot_textbox.Text = slot.ToString();
				RazorEnhanced.SpellGrid.UpdateBox();
				RazorEnhanced.SpellGrid.Close();
				RazorEnhanced.SpellGrid.Open();
			}
		}

		private void spellgrid_trackBar_Scroll(object sender, EventArgs e)
		{
			int o = spellgrid_trackBar.Value;

			if (spellgrid_trackBar.Focused)
			{
				RazorEnhanced.Settings.General.WriteInt("GridOpacity", o);
				if (RazorEnhanced.SpellGrid.SpellGridForm != null)
				{
					RazorEnhanced.SpellGrid.SpellGridForm.Opacity = ((double)o) / 100.0;
					RazorEnhanced.SpellGrid.SpellGridForm.Show();
				}
			}

			spellgrid_opacity_label.Text = String.Format("{0}%", o);
		}

		// ----------------- GRID END -------------------

		// ----------------- UO MOD START -------------------
		private void uomodFPSCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (uomodFPSCheckBox.Focused)
			{
				if (uomodFPSCheckBox.Checked)
					UoMod.EnableDisable(true, (int)UoMod.PATCH_TYPE.PT_FPS);
				else
					UoMod.EnableDisable(false, (int)UoMod.PATCH_TYPE.PT_FPS);

				RazorEnhanced.Settings.General.WriteBool("UoModFPS", uomodFPSCheckBox.Checked);
			}
		}

		private void uomodpaperdoolCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (uomodpaperdoolCheckBox.Focused)
			{
				if (uomodpaperdoolCheckBox.Checked)
					UoMod.EnableDisable(true, (int)UoMod.PATCH_TYPE.PT_PAPERDOLL_SLOTS);
				else
					UoMod.EnableDisable(false, (int)UoMod.PATCH_TYPE.PT_PAPERDOLL_SLOTS);

				RazorEnhanced.Settings.General.WriteBool("UoModPaperdool", uomodpaperdoolCheckBox.Checked);
			}
		}

		private void uomodglobalsoundCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (uomodglobalsoundCheckBox.Focused)
			{
				if (uomodglobalsoundCheckBox.Checked)
					UoMod.EnableDisable(true, (int)UoMod.PATCH_TYPE.PT_GLOBAL_SOUND);
				else
					UoMod.EnableDisable(false, (int)UoMod.PATCH_TYPE.PT_GLOBAL_SOUND);

				RazorEnhanced.Settings.General.WriteBool("UoModSound", uomodglobalsoundCheckBox.Checked);
			}
		}
		// ----------------- UO MOD END -------------------

		// ----------------- START AGENT GESTIONE MENU TENDINA -------------------

		private static int agentrowindex = 0;
		private static string agenttype = "";

		private void datagridMenuStrip_Click(object sender, EventArgs e)
		{
			switch (agenttype)
			{
				case "autolootdataGridView":
					if (!autolootdataGridView.Rows[agentrowindex].IsNewRow)
					{
						autolootdataGridView.Rows.RemoveAt(agentrowindex);
						RazorEnhanced.AutoLoot.CopyTable();
					}
					break;
				case "scavengerdataGridView":
					if (!scavengerdataGridView.Rows[agentrowindex].IsNewRow)
					{
						scavengerdataGridView.Rows.RemoveAt(agentrowindex);
						RazorEnhanced.Scavenger.CopyTable();
					}
					break;
				case "organizerdataGridView":
					if (!organizerdataGridView.Rows[agentrowindex].IsNewRow)
					{
						organizerdataGridView.Rows.RemoveAt(agentrowindex);
						RazorEnhanced.Organizer.CopyTable();
					}
					break;
				case "vendorbuydataGridView":
					if (!vendorbuydataGridView.Rows[agentrowindex].IsNewRow)
					{
						vendorbuydataGridView.Rows.RemoveAt(agentrowindex);
						RazorEnhanced.BuyAgent.CopyTable();
					}
					break;
				case "vendorsellGridView":
					if (!vendorsellGridView.Rows[agentrowindex].IsNewRow)
					{
						vendorsellGridView.Rows.RemoveAt(agentrowindex);
						RazorEnhanced.SellAgent.CopyTable();
					}
					break;
				case "restockdataGridView":
					if (!restockdataGridView.Rows[agentrowindex].IsNewRow)
					{
						restockdataGridView.Rows.RemoveAt(agentrowindex);
						RazorEnhanced.Restock.CopyTable();
					}
					break;
			}

		}

		// ----------------- END AGENT GESTIONE MENU TENDINA -------------------

		// ----------------- START AGENT GESTIONE DRAG DROP -------------------
		private Rectangle dragBoxFromMouseDown;
		private int rowIndexFromMouseDown;
		private int rowIndexOfItemUnderMouseToDrop;

		private void GridView_MouseMove(object sender, MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				DataGridView grid = (DataGridView)sender;
				if (dragBoxFromMouseDown != Rectangle.Empty &&
					!dragBoxFromMouseDown.Contains(e.X, e.Y))
				{
					DragDropEffects dropEffect = grid.DoDragDrop(
					grid.Rows[rowIndexFromMouseDown],
					DragDropEffects.Move);
				}
			}
		}

		private void GridView_MouseDown(object sender, MouseEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			rowIndexFromMouseDown = grid.HitTest(e.X, e.Y).RowIndex;
			if (rowIndexFromMouseDown != -1)
			{
				Size dragSize = SystemInformation.DragSize;
				dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
															   e.Y - (dragSize.Height / 2)),
									dragSize);
			}
			else
				dragBoxFromMouseDown = Rectangle.Empty;
		}

		private void GridView_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void GridView_DragDrop(object sender, DragEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			Point clientPoint = grid.PointToClient(new Point(e.X, e.Y));

			rowIndexOfItemUnderMouseToDrop = grid.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

			if (rowIndexOfItemUnderMouseToDrop == -1)
				return;

			if (e.Effect == DragDropEffects.Move)
			{
				DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
				grid.Rows.RemoveAt(rowIndexFromMouseDown);
				grid.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
				switch (grid.Name)
				{
					case "autolootdataGridView":
						AutoLoot.CopyTable();
						break;

					case "scavengerdataGridView":
						Scavenger.CopyTable();
						break;

					case "organizerdataGridView":
						Organizer.CopyTable();
						break;

					case "vendorbuydataGridView":
						BuyAgent.CopyTable();
						break;

					case "vendorsellGridView":
						SellAgent.CopyTable();
						break;

					case "restockdataGridView":
						Restock.CopyTable();
						break;
				}
			}

		}
		// ----------------- END AGENT GESTIONE DRAG DROP -------------------

		// ----------------- START AGENT EVENTI COMUNI DATAGRID -------------------

		private void GridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			DataGridView grid = (DataGridView)sender;

			if (!grid.Focused)
				return;

			if (grid.IsCurrentCellDirty)
				grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}

		private void GridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			e.ThrowException = false;
			e.Cancel = false;
		}

		private void GridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (e.RowIndex != -1)
				{
					DataGridView grid = (DataGridView)sender;

					grid.Rows[e.RowIndex].Selected = true;
					agentrowindex = e.RowIndex;
					agenttype = grid.Name;
					grid.CurrentCell = grid.Rows[e.RowIndex].Cells[1];
					datagridMenuStrip.Show(grid, e.Location);
					datagridMenuStrip.Show(Cursor.Position);
				}
			}

		}

		private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			if (!grid.Focused)
				return;

			if (e.ColumnIndex == 0) // Checkbox cambiate di stato genera save
			{
				switch (grid.Name)
				{
					case "autolootdataGridView":
						AutoLoot.CopyTable();
						break;

					case "scavengerdataGridView":
						Scavenger.CopyTable();
						break;

					case "organizerdataGridView":
						Organizer.CopyTable();
						break;

					case "vendorbuydataGridView":
						BuyAgent.CopyTable();
						break;

					case "vendorsellGridView":
						SellAgent.CopyTable();
						break;

					case "restockdataGridView":
						Restock.CopyTable();
						break;
				}
			}
		}

		private void scavengerRange_TextChanged(object sender, EventArgs e)
		{
			if (scavengerRange.Focused)
			{
				Settings.Scavenger.ListUpdate(scavengerListSelect.Text, Scavenger.ScavengerDelay, Scavenger.ScavengerBag, true, Scavenger.MaxRange);
				Scavenger.RefreshLists();
			}
		}
		// ----------------- END AGENT EVENTI COMUNI DATAGRID -------------------

		// ----------------- START VIDEO RECORDER -------------------
		private void videoFPSTextBox_TextChanged(object sender, EventArgs e)
		{
			if (videoFPSTextBox.Focused)
			{
				int fps = 25;

				if (!Int32.TryParse(videoFPSTextBox.Text, out fps))
					videoFPSTextBox.Text = "25";

				Settings.General.WriteInt("VideoFPS", fps);
			}
		}

		private void videoPathButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folder = new FolderBrowserDialog();
			folder.Description = "Select a folder to store Razor video file";
			folder.SelectedPath = RazorEnhanced.Settings.General.ReadString("VideoPath");
			folder.ShowNewFolderButton = true;

			if (folder.ShowDialog(this) == DialogResult.OK)
			{
				RazorEnhanced.Settings.General.WriteString("VideoPath", folder.SelectedPath);
				videoPathTextBox.Text = folder.SelectedPath;
				ReloadVideoList();
			}
		}

		internal void ReloadVideoList()
		{
			CloseCurrentVideoSource();
			VideoCapture.DisplayTo(videolistBox);
		}

		private void videoList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (videolistBox.Focused)
			{
				CloseCurrentVideoSource();

				if (videolistBox.SelectedIndex == -1)
					return;

				string file = Path.Combine(RazorEnhanced.Settings.General.ReadString("VideoPath"), videolistBox.SelectedItem.ToString());
				if (!File.Exists(file))
				{
					MessageBox.Show(this, Language.Format(LocString.FileNotFoundA1, file), "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					videolistBox.Items.RemoveAt(videolistBox.SelectedIndex);
					videolistBox.SelectedIndex = -1;
					return;
				}
				OpenVideoSource(file);
			}
		}

		private void videoList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.Clicks == 1)
			{
				ContextMenu menu = new ContextMenu();
				menu.MenuItems.Add("Delete", new EventHandler(DeleteVideoFile));
				if (videolistBox.SelectedIndex == -1)
					menu.MenuItems[menu.MenuItems.Count - 1].Enabled = false;
				menu.MenuItems.Add("Delete ALL", new EventHandler(ClearVideoDirectory));
				menu.Show(videolistBox, new Point(e.X, e.Y));
			}
		}

		private void DeleteVideoFile(object sender, System.EventArgs e)
		{
			CloseCurrentVideoSource();
			int sel = videolistBox.SelectedIndex;
			if (sel == -1)
				return;

			string file = Path.Combine(RazorEnhanced.Settings.General.ReadString("VideoPath"), (string)videolistBox.SelectedItem);
			if (MessageBox.Show(this, Language.Format(LocString.DelConf, file), "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			videolistBox.SelectedIndex = -1;

			try
			{
				File.Delete(file);
				videolistBox.Items.RemoveAt(sel);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ReloadVideoList();
		}

		private void ClearVideoDirectory(object sender, System.EventArgs e)
		{
			string dir = RazorEnhanced.Settings.General.ReadString("VideoPath");
			if (MessageBox.Show(this, Language.Format(LocString.Confirm, dir), "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			string[] files = Directory.GetFiles(dir, "*.avi");
			StringBuilder sb = new StringBuilder();
			int failed = 0;
			for (int i = 0; i < files.Length; i++)
			{
				try
				{
					File.Delete(files[i]);
				}
				catch
				{
					sb.AppendFormat("{0}\n", files[i]);
					failed++;
				}
			}

			if (failed > 0)
				MessageBox.Show(this, Language.Format(LocString.FileDelError, failed, failed != 1 ? "s" : "", sb.ToString()), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			ReloadVideoList();
		}

		private void videorecbutton_Click(object sender, EventArgs e)
		{
			StartVideoRecorder();
		}

		private void videostopbutton_Click(object sender, EventArgs e)
		{
			StopVideoRecorder();
		}

		internal static void StartVideoRecorder()
		{
			if (VideoCapture.Recording) // already on record
			{
				RazorEnhanced.Misc.SendMessage("Already on Record");
				return;
			}
			RazorEnhanced.Misc.SendMessage("Start Video Record");
			Engine.MainWindow.videoRecStatuslabel.Text = "Recording";
			Engine.MainWindow.videoRecStatuslabel.ForeColor = Color.Red;

			Engine.MainWindow.videosettinggroupBox.Enabled = false;
			int fps = 30;
			if (Settings.General.ReadInt("VideoFPS") < 30)
				fps = Settings.General.ReadInt("VideoFPS");

			VideoCapture.Record(fps, Engine.MainWindow.videoCodecComboBox.SelectedIndex);
		}

		internal static void StopVideoRecorder()
		{
			RazorEnhanced.Misc.SendMessage("Stop Video Record");
			Engine.MainWindow.videoRecStatuslabel.Text = "Idle";
			Engine.MainWindow.videoRecStatuslabel.ForeColor = Color.Green;
			VideoCapture.Stop();
			Engine.MainWindow.ReloadVideoList();
			Engine.MainWindow.videosettinggroupBox.Enabled = true;
		}

		private void videoCodecComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (videoCodecComboBox.Focused)
			{
				Settings.General.WriteInt("VideoFormat", videoCodecComboBox.SelectedIndex);
			}
		}


		private void CloseCurrentVideoSource()
		{
			if (videoSourcePlayer.VideoSource != null)
			{
				videoSourcePlayer.SignalToStop();
				videoSourcePlayer.WaitForStop();
				videoSourcePlayer.VideoSource = null;
			}
		}
		// Open video source
		private void OpenVideoSource(string file)
		{
			FileVideoSource source = new FileVideoSource(file);
			// set busy cursor
			this.Cursor = Cursors.WaitCursor;

			// stop current video source
			CloseCurrentVideoSource();

			// start new video source
			videoSourcePlayer.VideoSource = source;
			videoSourcePlayer.Start();

			this.Cursor = Cursors.Default;
		}
		// ----------------- STOP VIDEO RECORDER -------------------
	}
}
