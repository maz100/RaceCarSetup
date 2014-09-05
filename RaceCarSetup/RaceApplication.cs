using System;

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

		public RaceResults Race (RaceTrack raceTrack, CarConfiguration[] cars)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

