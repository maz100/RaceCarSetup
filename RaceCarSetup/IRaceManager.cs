namespace RaceCarSetup
{
	/// <summary>
	/// Interface for racing car configurations.
	/// </summary>
	public interface IRaceManager
	{
		/// <summary>
		/// Race the specified raceTrack and cars.
		/// </summary>
		/// <param name="raceTrack">Race track.</param>
		/// <param name="cars">Cars.</param>
		/// <returns>A copy of the car configurations, sorted by elapsed race time.</returns>
		CarConfiguration[] Race (RaceTrack raceTrack, CarConfiguration[] cars);
	}
}

