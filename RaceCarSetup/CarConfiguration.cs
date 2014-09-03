using System;

namespace RaceCarSetup
{
	public class CarConfiguration
	{
		public CarConfiguration ()
		{
		}

		public int FuelCapacity {
			get;
			set;
		}

		public TimeSpan LapTime {
			get;
			set;
		}

		public int FuelConsumptionPerLap {
			get;
			set;
		}
	}
}

