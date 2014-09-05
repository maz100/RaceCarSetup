namespace RaceCarSetup
{
	public class CarConfigurationSorter : ICarConfigurationSorter
	{
		public CarConfigurationSorter ()
		{
		}

		#region ICarConfigurationSorter implementation

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

			// Recursive calls
			if (left < j) {
				Sort (cars, left, j);
			}

			if (i < right) {
				Sort (cars, i, right);
			}

			return cars;
		}


		#endregion
	}
}

