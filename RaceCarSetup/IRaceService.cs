using System;

namespace RaceCarSetup
{
	public interface IRaceService
	{
		float GetLapTime (float lapDistance, float averageSpeed);

		float GetFuelConsumptionPerLap (float fuelConsumptionPerKm, float lapLengthKm);
	}
}

