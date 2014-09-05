using System;
using NUnit.Framework;
using RaceCarSetup;

namespace Test.RaceCarSetup
{
	[TestFixture]
	public class RaceServiceTests
	{
		private RaceService raceService;
		private CarConfiguration carConfiguration;
		private RaceTrack raceTrack;

		[SetUp]
		public void SetUp ()
		{
			raceService = new RaceService ();

			raceTrack = new RaceTrack { LapDistance = 57 };

			carConfiguration = new CarConfiguration (raceTrack){ AverageSpeed = 213 };
		}

		[Test]
		public void TestGetLapTIme ()
		{
			var expectedLapTime = raceTrack.LapDistance / carConfiguration.AverageSpeed;

			var actualLapTime = raceService.GetLapTime (raceTrack.LapDistance, carConfiguration.AverageSpeed);

			Assert.AreEqual (expectedLapTime, actualLapTime);
		}

		[Test]
		public void TestGetFuelConsumptionPerLap ()
		{
			var expectedFuelConsumptionPerLap = raceTrack.LapDistance * carConfiguration.FuelConsumptionPerKm;

			var actualFuelConsumptionPerLap = raceService.GetFuelConsumptionPerLap (carConfiguration.FuelConsumptionPerKm, raceTrack.LapDistance);

			Assert.AreEqual (expectedFuelConsumptionPerLap, actualFuelConsumptionPerLap);
		}

		[Test]
		public void TestGetRemainingFuel ()
		{
			var lap = 3;
			var fuelConsumptionPerLap = 0.25F;
			var fuelCapacity = 100;

			var expectedRemainingFuel = fuelCapacity - (fuelConsumptionPerLap * lap);

			var actualRemainingFuel = raceService.GetRemainingFuel (lap, fuelConsumptionPerLap, fuelCapacity);

			Assert.AreEqual (expectedRemainingFuel, actualRemainingFuel);
		}
	}
}

