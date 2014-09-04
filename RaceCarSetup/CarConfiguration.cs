using System;

namespace RaceCarSetup
{
	public class CarConfiguration
	{
		public int FuelCapacity {
			get;
			set;
		}

		//not sure these belong at car config level
		public TimeSpan LapTime {
			get;
			set;
		}

		public int FuelConsumptionPerLap {
			get;
			set;
		}

		//defined by me to get Lap time
		public int AverageSpeed {
			get;
			set;
		}

		public float FuelConsumptionPerKm {
			get;
			set;
		}
	}
}

