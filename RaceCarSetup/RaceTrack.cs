using System;

namespace RaceCarSetup
{
	public class RaceTrack
	{
		public RaceTrack ()
		{
		}

		public int LapDistance {
			get;
			set;
		}

		public int TotalLaps {
			get;
			set;
		}

		public TimeSpan PitStopTime {
			get;
			set;
		}
	}
}

