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

		[Test]
		public void TestHasSufficientFuel_when_created ()
		{
			Assert.True (carConfiguration.HasSufficientFuel);
		}

		[Test]
		public void TestCompleteLap_remaining_fuel_decreased ()
		{
			var remainingFuel = carConfiguration.RemainingFuel;

			carConfiguration.CompleteLap ();

			Assert.That (carConfiguration.RemainingFuel == remainingFuel - carConfiguration.FuelConsumptionPerLap);
		}

		[Test]
		public void TestHasSufficientFuel_false_when_insufficient_fuel_for_lap ()
		{
			//this config is set so that 1km will use all of the fuel
			//the racetrack lap distance is greater than 1km
			//so the car config should know that it does not have sufficient
			//fuel to complete a lap
			var carConfiguration2 = new CarConfiguration (raceTrack) {
				AverageSpeed = 200,
				FuelCapacity = 10,
				FuelConsumptionPerKm = 10
			};

			Assert.False (carConfiguration2.HasSufficientFuel);
		}

		[Test]
		public void TestMakePitstop_refuels_car_config_to_capacity ()
		{
			var startsWithFullTank = carConfiguration.RemainingFuel == carConfiguration.FuelCapacity;

			carConfiguration.CompleteLap ();
			var usesFuelToCompleteTank = carConfiguration.RemainingFuel < carConfiguration.FuelCapacity;

			carConfiguration.MakePitstop ();
			var refuelsSuccessfullyAtPitstop = carConfiguration.RemainingFuel == carConfiguration.FuelCapacity;

			Assert.True (startsWithFullTank && usesFuelToCompleteTank && refuelsSuccessfullyAtPitstop);
		}

	}
}

