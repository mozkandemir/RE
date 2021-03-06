using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistant
{
	internal class ObjectPropertyList
	{
		internal class OPLEntry
		{
			internal int Number = 0;
			internal string Args = null;

			internal OPLEntry(int num)
				: this(num, null)
			{
			}

			internal OPLEntry(int num, string args)
			{
				Number = num;
				Args = args;
			}

			public override string ToString()
			{
				int number = this.Number;
				string args = Assistant.Language.ParseSubCliloc(this.Args);

				string content;
				if (args == null)
					content = Assistant.Language.GetCliloc(number);
				else
					content = Assistant.Language.ClilocFormat(this.Number, args);

				return content;
			}
		}

		private List<int> m_StringNums = new List<int>();

		private int m_Hash = 0;
		private List<OPLEntry> m_Content = new List<OPLEntry>();
		internal List<OPLEntry> Content { get { return m_Content; } }

		private int m_CustomHash = 0;
		private List<OPLEntry> m_CustomContent = new List<OPLEntry>();

		private UOEntity m_Owner = null;

		internal int Hash
		{
			get { return m_Hash ^ m_CustomHash; }
			set { m_Hash = value; }
		}

		internal int ServerHash { get { return m_Hash; } }

		internal bool Customized { get { return m_CustomHash != 0; } }

		internal ObjectPropertyList(UOEntity owner)
		{
			m_Owner = owner;

			m_StringNums.AddRange(m_DefaultStringNums);
		}

		internal void Read(PacketReader p)
		{
			m_Content.Clear();

			p.Seek(5, System.IO.SeekOrigin.Begin); // seek to packet data

			p.ReadUInt32(); // serial
			p.ReadByte(); // 0
			p.ReadByte(); // 0
			m_Hash = p.ReadInt32();

			m_StringNums.Clear();
			m_StringNums.AddRange(m_DefaultStringNums);

			while (p.Position < p.Length)
			{
				int num = p.ReadInt32();
				if (num == 0)
					break;

				m_StringNums.Remove(num);

				short bytes = p.ReadInt16();
				string args = string.Empty;
				if (bytes > 0)
					args = p.ReadUnicodeStringBE(bytes >> 1);

				if (m_Content.Any(e => e.Number == num))
					continue;
				else
					m_Content.Add(new OPLEntry(num, args));
			}

			foreach (OPLEntry ent in m_CustomContent)
			{
				if (m_StringNums.Contains(ent.Number))
				{
					m_StringNums.Remove(ent.Number);
				}
				else
				{
					foreach (int t in m_DefaultStringNums)
					{
						if (ent.Number == t)
						{
							ent.Number = GetStringNumber();
							break;
						}
					}
				}
			}
		}

		private static byte[] m_Buffer = new byte[0];

		internal void AddHash(int val)
		{
			m_CustomHash ^= (val & 0x3FFFFFF);
			m_CustomHash ^= (val >> 26) & 0x3F;
		}

		internal void Add(int number, string arguments)
		{
			if (number == 0)
				return;

			AddHash(number);
			m_CustomContent.Add(new OPLEntry(number, arguments));
		}


		private static int[] m_DefaultStringNums = new int[]
		{
			1042971, // ~1_NOTHING~
			1070722, // ~1_NOTHING~
			1063483, // ~1_MATERIAL~ ~2_ITEMNAME~
			1076228, // ~1_DUMMY~ ~2_DUMMY~
			1060847, // ~1_val~ ~2_val~
			1050039, // ~1_NUMBER~ ~2_ITEMNAME~
			// these are ugly:
			//1062613, // "~1_NAME~" (orange)
			//1049644, // [~1_stuff~]
		};

		private int GetStringNumber()
		{
			if (m_StringNums.Count > 0)
			{
				int num = (int)m_StringNums[0];
				m_StringNums.RemoveAt(0);
				return num;
			}
			else
			{
				return 1049644;
			}
		}

		private const string RazorHTMLFormat = " <CENTER><BASEFONT COLOR=#FF0000>{0}</BASEFONT></CENTER> ";

		internal void Add(string text)
		{
			Add(GetStringNumber(), String.Format(RazorHTMLFormat, text));
		}


		internal bool Remove(string str)
		{
			string htmlStr = String.Format(RazorHTMLFormat, str);

			/*for ( int i = 0; i < m_Content.Count; i++ )
			{
				OPLEntry ent = (OPLEntry)m_Content[i];
				if ( ent == null )
					continue;

				for (int s=0;s<m_DefaultStringNums.Length;s++)
				{
					if ( ent.Number == m_DefaultStringNums[s] && ( ent.Args == htmlStr || ent.Args == str ) )
					{
						m_StringNums.Insert( 0, ent.Number );

						m_Content.RemoveAt( i );

						AddHash( ent.Number );
						if ( ent.Args != null && ent.Args != "" )
							AddHash( ent.Args.GetHashCode() );
						return true;
					}
				}
			}*/

			for (int i = 0; i < m_CustomContent.Count; i++)
			{
				OPLEntry ent = m_CustomContent[i];
				if (ent == null)
					continue;

				if (m_DefaultStringNums.Any(num => ent.Number == num && (ent.Args == htmlStr || ent.Args == str)))
				{
					m_StringNums.Insert(0, ent.Number);

					m_CustomContent.RemoveAt(i);

					AddHash(ent.Number);
					if (!string.IsNullOrEmpty(ent.Args))
						AddHash(ent.Args.GetHashCode());
					return true;
				}
			}

			return false;
		}
	}

	internal class OPLInfo : Packet
	{
		internal OPLInfo(Serial ser, int hash)
			: base(0xDC, 9)
		{
			Write((uint)ser);
			Write((int)hash);
		}
	}
}