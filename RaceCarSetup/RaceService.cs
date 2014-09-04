using System;

namespace RaceCarSetup
{
	public class RaceService : IRaceService
	{
		#region IRaceService implementation

		public float GetLapTime (float lapDistance, float averageSpeed)
		{
			var lapTime = lapDistance / averageSpeed;

			return lapTime;
		}


		public float GetFuelConsumptionPerLap (float fuelConsumptionPerKm, float lapLengthKm)
		{
			var result = fuelConsumptionPerKm * lapLengthKm;

			return result;
		}

		#endregion
	}
}

