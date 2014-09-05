namespace RaceCarSetup
{
	public interface IRaceManager
	{
		/// <summary>
		/// Race the specified raceTrack and cars.
		/// </summary>
		/// <param name="raceTrack">Race track.</param>
		/// <param name="cars">Cars.</param>
		CarConfiguration[] Race (RaceTrack raceTrack, CarConfiguration[] cars);
	}
}

