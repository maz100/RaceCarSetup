using System;
using NUnit.Framework;
using RaceCarSetup;

namespace Test.RaceCarSetup
{
	[TestFixture]
	public class CarConfigurationTests
	{
		private CarConfiguration carConfiguration;
		private RaceTrack raceTrack;

		[SetUp]
		public void SetUp ()
		{
			raceTrack = new RaceTrack { LapDistance = 57 };

			carConfiguration = new CarConfiguration (raceTrack) {
				AverageSpeed = 213,
				FuelConsumptionPerKm = 0.25F,
				FuelCapacity = 100F
			};
		}


		[Test]
		public void TestGetLapTIme ()
		{
			var expectedLapTime = raceTrack.LapDistance / carConfiguration.AverageSpeed;

			var actualLapTime = carConfiguration.LapTime;

			Assert.AreEqual (expectedLapTime, actualLapTime);
		}

		[Test]
		public void TestGetFuelConsumptionPerLap ()
		{
			var expectedFuelConsumptionPerLap = raceTrack.LapDistance * carConfiguration.FuelConsumptionPerKm;

			var actualFuelConsumptionPerLap = carConfiguration.FuelConsumptionPerLap;

			Assert.AreEqual (expectedFuelConsumptionPerLap, actualFuelConsumptionPerLap);
		}

		[Test]
		public void TestRemainingFuel_init_same_as_fuel_capacity ()
		{
			Assert.AreEqual (carConfiguration.FuelCapacity, carConfiguration.RemainingFuel);
		}

	}
}

