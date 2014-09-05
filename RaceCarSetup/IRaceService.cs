using System;

namespace RaceCarSetup
{
	public interface IRaceService
	{
		float GetLapTime (float lapDistance, float averageSpeed);

		float GetFuelConsumptionPerLap (float fuelConsumptionPerKm, float lapLengthKm);

		float GetRemainingFuel (int lap, float fuelConsumptionPerLap, float fuelCapacity);

		void MakePitstop (CarConfiguration carConfiguration);
	}
}

