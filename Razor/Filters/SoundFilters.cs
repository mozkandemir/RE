using System.Linq;

namespace Assistant.Filters
{
	internal class SoundFilter : Filter
	{
		public static void Initialize()
		{
			Filter.Register(new SoundFilter(LocString.BardMusic, 0x38, 0x39, 0x43, 0x44, 0x45, 0x46, 0x4C, 0x4D, 0x52, 0x53, 0x17F, 0x182, 0x503, 0x504)); 
            Filter.Register(new SoundFilter(LocString.DogSounds, GetRange(0x85, 0x89)));
			Filter.Register(new SoundFilter(LocString.CatSounds, GetRange(0x69, 0x6D)));
			Filter.Register(new SoundFilter(LocString.HorseSounds, GetRange(0xA8, 0xAC)));
			Filter.Register(new SoundFilter(LocString.SheepSounds, GetRange(0xD6, 0xDA)));
			Filter.Register(new SoundFilter(LocString.SS_Sound, 0x24A));
			Filter.Register(new SoundFilter(LocString.FizzleSound, 0x5C));
			Filter.Register(new SoundFilter(LocString.PackSound, 0x48));
		}

		internal static ushort[] GetRange(ushort min, ushort max)
		{
			if (max < min)
				return new ushort[0];

			ushort[] range = new ushort[max - min + 1];
			for (ushort i = min; i <= max; i++)
				range[i - min] = i;
			return range;
		}

		private LocString m_Name;
		private ushort[] m_Sounds;

		private SoundFilter(LocString name, params ushort[] blockSounds)
		{
			m_Name = name;
			m_Sounds = blockSounds;
		}

		internal override byte[] PacketIDs { get { return new byte[] { 0x54 }; } }
		internal override LocString Name { get { return m_Name; } }

		internal override void OnFilter(PacketReader p, PacketHandlerEventArgs args)
		{
			p.ReadByte(); // flags

			ushort sound = p.ReadUInt16();
			if (m_Sounds.Any(t => t == sound))
			{
				args.Block = true;
				return;
			}
		}
	}
}