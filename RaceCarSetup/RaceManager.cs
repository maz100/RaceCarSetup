namespace RaceCarSetup
{
	public class RaceManager : IRaceManager
	{
		private ICarConfigurationSorter _carConfigurationSorter;

		public RaceManager (ICarConfigurationSorter carConfigurationSorter)
		{
			_carConfigurationSorter = carConfigurationSorter;	
		}

		#region IRaceApplication implementation

		public CarConfiguration[] Race (RaceTrack raceTrack, params CarConfiguration[] cars)
		{
			var carsCopy = (CarConfiguration[])cars.Clone ();

			for (int i = 0; i < raceTrack.TotalLaps; i++) {
				foreach (var car in cars) {
					if (!car.HasSufficientFuel) {
						car.MakePitstop ();
					}
					car.CompleteLap ();
				}	
			}

			var result = _carConfigurationSorter.Sort (carsCopy);

			return result;
		}

		#endregion
	}
}