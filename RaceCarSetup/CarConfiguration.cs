namespace RaceCarSetup
{
	public class CarConfiguration : IRaceable
	{
		private RaceTrack _raceTrack;

		public CarConfiguration (RaceTrack raceTrack, double fuelCapacity, double averageSpeed, double fuelConsumptionPerKm, int id = 0)
		{
			_raceTrack = raceTrack;

			Id = id;
			RemainingFuel = fuelCapacity;
			FuelCapacity = fuelCapacity;
			AverageSpeed = averageSpeed;
			FuelConsumptionPerKm = fuelConsumptionPerKm;

			LapTime = ((_raceTrack.LapDistance / AverageSpeed) * 3600000);
			FuelConsumptionPerLap = FuelConsumptionPerKm * _raceTrack.LapDistance;
		}

		public int Id {
			get;
			private set;
		}


		public double FuelCapacity {
			get ;
			private set;
		}

		public double LapTime {
			get;
			private set;
		}

		public double AverageSpeed {
			get;
			private set;
		}


		public double FuelConsumptionPerKm {
			get;
			private set;
		}


		public double FuelConsumptionPerLap {
			get;
			private set;
		}

		public double RemainingFuel {
			get ;
			private set;
		}

		public double ElapsedTime {
			get;
			private set;
		}

		#region IRaceable implementation

		public virtual void CompleteLap ()
		{
			RemainingFuel -= FuelConsumptionPerLap;
			ElapsedTime += LapTime;
		}

		public virtual void MakePitstop ()
		{
			RemainingFuel = FuelCapacity;
			ElapsedTime += _raceTrack.PitStopTime * 1000;
		}

		public virtual bool HasSufficientFuel {
			get {
				return RemainingFuel - FuelConsumptionPerLap > 0;
			}
		}

		#endregion
	}
}

