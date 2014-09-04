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

			carConfiguration = new CarConfiguration { AverageSpeed = 213 };
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
	}
}

