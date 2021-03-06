using System.Collections.Generic;
using System.IO;

namespace Assistant
{
	internal class UOEntity
	{
		private Serial m_Serial;
		private Point3D m_Pos;
		private ushort m_Hue;
		private bool m_Deleted;
		private Dictionary<ushort, int> m_ContextMenu = new Dictionary<ushort, int>();
		protected ObjectPropertyList m_ObjPropList = null;

		internal ObjectPropertyList ObjPropList { get { return m_ObjPropList; } }

		internal virtual void AfterLoad()
		{
		}

		internal UOEntity(Serial ser)
		{
			m_ObjPropList = new ObjectPropertyList(this);

			m_Serial = ser;
			m_Deleted = false;
		}

		internal Serial Serial { get { return m_Serial; } }

		internal virtual Point3D Position
		{
			get { return m_Pos; }
			set
			{
				if (value != m_Pos)
				{
					OnPositionChanging(value);
					m_Pos = value;
				}
			}
		}

		internal bool Deleted
		{
			get
			{
				return m_Deleted;
			}
		}

		internal Dictionary<ushort, int> ContextMenu
		{
			get { return m_ContextMenu; }
		}

		internal virtual ushort Hue
		{
			get { return m_Hue; }
			set { m_Hue = value; }
		}

		internal virtual void Remove()
		{
			m_Deleted = true;
		}

		internal virtual void OnPositionChanging(Point3D newPos)
		{
		}

		public override int GetHashCode()
		{
			return m_Serial.GetHashCode();
		}

		internal int OPLHash
		{
			get
			{
				if (m_ObjPropList != null)
					return m_ObjPropList.Hash;
				else
					return 0;
			}
			set
			{
				if (m_ObjPropList != null)
					m_ObjPropList.Hash = value;
			}
		}

		internal bool ModifiedOPL { get { return m_ObjPropList.Customized; } }

		internal void ReadPropertyList(PacketReader p)
		{
			m_ObjPropList.Read(p);
		}

		/*public Packet BuildOPLPacket()
		{
			return m_ObjPropList.BuildPacket();
		}*/

		internal void OPLChanged()
		{
			//ClientCommunication.SendToClient( m_ObjPropList.BuildPacket() );
			ClientCommunication.SendToClient(new OPLInfo(Serial, OPLHash));
		}
	}
}