namespace RaceCarSetup
{
	/// <summary>
	/// Interface used to sort car configurations
	/// </summary>
	public interface ICarConfigurationSorter
	{
		/// <summary>
		/// Sort the specified cars by elapsed race time.
		/// </summary>
		/// <param name="cars">Cars.</param>
		CarConfiguration[] Sort (CarConfiguration[] cars);
	}
}

