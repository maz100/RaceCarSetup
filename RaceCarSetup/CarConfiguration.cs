namespace RaceCarSetup
{
	public class CarConfiguration : IRaceable
	{
		private RaceTrack _raceTrack;
		private float? lapTime;
		private float? fuelConsumptionPerLap;
		private float remainingFuel;
		private float fuelCapacity;

		public CarConfiguration (RaceTrack raceTrack)
		{
			_raceTrack = raceTrack;
		}


		public float FuelCapacity {
			get {
				return fuelCapacity;
			}
			set {
				fuelCapacity = value;
				remainingFuel = value;
			}
		}

		public float AverageSpeed { get; set; }

		public float FuelConsumptionPerKm {	get; set; }

		public float? LapTime {
			get {

				return lapTime ?? (lapTime = _raceTrack.LapDistance / AverageSpeed);
			}
		}

		public float? FuelConsumptionPerLap {
			get {
				return fuelConsumptionPerLap ?? (fuelConsumptionPerLap = FuelConsumptionPerKm * _raceTrack.LapDistance);
			}
		}

		public float RemainingFuel {
			get {
				return remainingFuel;
			}
		}

		#region IRaceable implementation

		public void CompleteLap ()
		{
			remainingFuel -= FuelConsumptionPerLap.Value;
		}

		public void MakePitstop ()
		{
			remainingFuel = FuelCapacity;
		}

		public bool HasSufficientFuel {
			get {
				return remainingFuel - FuelConsumptionPerLap > 0;
			}
		}

		#endregion
	}
}

