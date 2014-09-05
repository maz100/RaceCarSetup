namespace RaceCarSetup
{
	public class RaceApplication : IRaceApplication
	{
		private IRaceService _raceService;

		public RaceApplication ()
		{
		}

		public RaceApplication (IRaceService raceService)
		{
			_raceService = raceService;	
		}

		#region IRaceApplication implementation

		public void Race (RaceTrack raceTrack, params IRaceable[] cars)
		{
			for (int i = 0; i < raceTrack.TotalLaps; i++) {
				foreach (var car in cars) {
					if (!car.HasSufficientFuel) {
						car.MakePitstop ();
					}
					car.CompleteLap ();
				}	
			}
		}

		#endregion
	}
}

