using System.Linq;

namespace Assistant.Filters
{
	internal class AsciiMessageFilter : Filter
	{
		private LocString m_Name;
		private string[] m_Strings;
		private MessageType m_Type;

		private AsciiMessageFilter(LocString name, MessageType type, string[] msgs)
		{
			m_Name = name;
			m_Strings = msgs;
			m_Type = type;
		}

		internal override byte[] PacketIDs { get { return new byte[] { 0x1C }; } }
		internal override LocString Name { get { return m_Name; } }

		internal override void OnFilter(PacketReader p, PacketHandlerEventArgs args)
		{
			if (args.Block)
				return;

			// 0, 1, 2
			Serial serial = p.ReadUInt32(); // 3, 4, 5, 6
			ushort body = p.ReadUInt16(); // 7, 8
			MessageType type = (MessageType)p.ReadByte(); // 9

			if (type != m_Type)
				return;

			ushort hue = p.ReadUInt16(); // 10, 11
			ushort font = p.ReadUInt16();
			string name = p.ReadStringSafe(30);
			string text = p.ReadStringSafe();

			if (m_Strings.Any(t => text.IndexOf(t) != -1))
			{
				args.Block = true;
				return;
			}
		}
	}

	internal class LocMessageFilter : Filter
	{
		public static void Initialize()
		{
		}

		private LocString m_Name;
		private int[] m_Nums;
		private MessageType m_Type;

		private LocMessageFilter(LocString name, MessageType type, int[] msgs)
		{
			m_Name = name;
			m_Nums = msgs;
			m_Type = type;
		}

		internal override byte[] PacketIDs { get { return new byte[] { 0xC1 }; } }
		internal override LocString Name { get { return m_Name; } }

		internal override void OnFilter(PacketReader p, PacketHandlerEventArgs args)
		{
			if (args.Block)
				return;

			Serial serial = p.ReadUInt32();
			ushort body = p.ReadUInt16();
			MessageType type = (MessageType)p.ReadByte();
			ushort hue = p.ReadUInt16();
			ushort font = p.ReadUInt16();
			int num = p.ReadInt32();

			// paladin spells
			if (num >= 1060718 && num <= 1060727)
				type = MessageType.Spell;
			if (type != m_Type)
				return;

			if (m_Nums.Any(t => num == t))
			{
				args.Block = true;
				return;
			}
		}
	}
}