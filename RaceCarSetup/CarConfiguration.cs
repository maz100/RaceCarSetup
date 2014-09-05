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

		/// <summary>
		/// Gets the fuel capacity.
		/// </summary>
		/// <value>The fuel capacity in kilograms.</value>
		public double FuelCapacity {
			get ;
			private set;
		}

		/// <summary>
		/// Gets the lap time.
		/// </summary>
		/// <value>The lap time in milliseconds.</value>
		public double LapTime {
			get;
			private set;
		}

		/// <summary>
		/// Gets the average speed.
		/// </summary>
		/// <value>The average speed in kilometers per hour.</value>
		public double AverageSpeed {
			get;
			private set;
		}

		/// <summary>
		/// Gets the fuel consumption per km.
		/// </summary>
		/// <value>The fuel consumption per km.</value>
		public double FuelConsumptionPerKm {
			get;
			private set;
		}

		/// <summary>
		/// Gets the fuel consumption per lap.
		/// </summary>
		/// <value>The fuel consumption per lap.</value>
		public double FuelConsumptionPerLap {
			get;
			private set;
		}

		/// <summary>
		/// Gets the remaining fuel.
		/// </summary>
		/// <value>The remaining fuel in kilograms.</value>
		public double RemainingFuel {
			get ;
			private set;
		}

		/// <summary>
		/// Gets the elapsed time.
		/// </summary>
		/// <value>The elapsed time in milliseconds.</value>
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

