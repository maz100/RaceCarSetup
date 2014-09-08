namespace RaceCarSetup
{
	public class CarConfigurationSorter : ICarConfigurationSorter
	{
		public CarConfigurationSorter ()
		{
		}

		#region ICarConfigurationSorter implementation

		/// <summary>
		/// Sort the specified cars by elapsed time.
		/// </summary>
		/// <param name="cars">Cars.</param>
		public CarConfiguration[] Sort (CarConfiguration[] cars)
		{
			//interface defines sort method which does not expose details about the sort algorithm used
			//i.e. that quicksort needs left/right.  Makes it easy to change algorithm.
			return Sort (cars, 0, cars.Length);
		}

		#endregion

		/// <summary>
		/// Sort the specified cars using quicksort algorithm.
		/// </summary>
		/// <param name="cars">Cars to sort.</param>
		/// <param name="left">The lowest index of the array to include in sort.</param>
		/// <param name="right">The highest index of the array to include in sort.</param>
		public CarConfiguration[] Sort (CarConfiguration[] cars, int left, int right)
		{
			int i = left, j = right;
			CarConfiguration pivot = cars [(left + right) / 2];

			while (i <= j) {
				while (cars [i].ElapsedTime < pivot.ElapsedTime) {
					i++;
				}

				while (cars [j].ElapsedTime > pivot.ElapsedTime) {
					j--;
				}

				if (i <= j) {
					// Swap
					CarConfiguration tmp = cars [i];
					cars [i] = cars [j];
					cars [j] = tmp;

					i++;
					j--;
				}
			}

			// now recusrively sort the remaining portions of the cars array
			if (left < j) {
				Sort (cars, left, j);
			}

			if (i < right) {
				Sort (cars, i, right);
			}

			return cars;
		}
	}
}

