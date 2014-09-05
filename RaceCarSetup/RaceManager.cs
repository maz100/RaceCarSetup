namespace RaceCarSetup
{
	public class RaceManager : IRaceManager
	{
		#region IRaceApplication implementation

		public void Race (RaceTrack raceTrack, params CarConfiguration[] cars)
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

