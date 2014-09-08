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
        private const double AVERAGE_SPEED = 213;
        private const double FUEL_CONSUMPTION_PER_KM = 0.25;
        private const double FUEL_CAPACITY = 100;

        [SetUp]
        public void SetUp()
        {
            raceTrack = new RaceTrack { LapDistance = 5, PitStopTime = 3 };

            carConfiguration = new CarConfiguration(raceTrack,
                FUEL_CAPACITY,
                AVERAGE_SPEED,
                FUEL_CONSUMPTION_PER_KM);
        }


        [Test]
        public void TestGetLapTIme()
        {
            var expectedLapTime = TimeSpan.FromMilliseconds((raceTrack.LapDistance / AVERAGE_SPEED) * 3600000);

            var actualLapTime = TimeSpan.FromMilliseconds(carConfiguration.LapTime);

            Assert.AreEqual(expectedLapTime, actualLapTime);
        }

        [Test]
        public void TestGetFuelConsumptionPerLap()
        {
            var expectedFuelConsumptionPerLap = raceTrack.LapDistance * FUEL_CONSUMPTION_PER_KM;

            var actualFuelConsumptionPerLap = carConfiguration.FuelConsumptionPerLap;

            Assert.AreEqual(expectedFuelConsumptionPerLap, actualFuelConsumptionPerLap);
        }

        [Test]
        public void TestRemainingFuel_init_same_as_fuel_capacity()
        {
            Assert.AreEqual(carConfiguration.FuelCapacity, carConfiguration.RemainingFuel);
        }

        [Test]
        public void TestHasSufficientFuel_when_created()
        {
            Assert.True(carConfiguration.HasSufficientFuel);
        }

        [Test]
        public void TestCompleteLap_remaining_fuel_decreased()
        {
            var remainingFuel = carConfiguration.RemainingFuel;

            carConfiguration.CompleteLap();

            Assert.That(carConfiguration.RemainingFuel == remainingFuel - carConfiguration.FuelConsumptionPerLap);
        }

        [Test]
        public void TestHasSufficientFuel_false_when_insufficient_fuel_for_lap()
        {
            //this config is set so that 1km will use all of the fuel
            //the racetrack lap distance is greater than 1km
            //so the car config should know that it does not have sufficient
            //fuel to complete a lap
            var carConfiguration2 = new CarConfiguration(raceTrack,
                               FUEL_CAPACITY,
                               averageSpeed: 200,
                               fuelConsumptionPerKm: FUEL_CAPACITY);

            Assert.False(carConfiguration2.HasSufficientFuel);
        }

        [Test]
        public void TestMakePitstop_refuels_car_config_to_capacity()
        {
            var startsWithFullTank = carConfiguration.RemainingFuel == carConfiguration.FuelCapacity;

            carConfiguration.CompleteLap();
            var usesFuelToCompleteTank = carConfiguration.RemainingFuel < carConfiguration.FuelCapacity;

            carConfiguration.MakePitstop();
            var refuelsSuccessfullyAtPitstop = carConfiguration.RemainingFuel == carConfiguration.FuelCapacity;

            Assert.True(startsWithFullTank && usesFuelToCompleteTank && refuelsSuccessfullyAtPitstop);
        }

        [Test]
        public void TestCompleteLap_increments_elapsed_time_by_lap_time()
        {
            carConfiguration.CompleteLap();

            Assert.True(carConfiguration.ElapsedTime == carConfiguration.LapTime);
        }

        [Test]
        public void TestMakePitstop_increases_elapsed_time_by_pitstop_time()
        {
            var expected = TimeSpan.FromSeconds(raceTrack.PitStopTime);

            carConfiguration.MakePitstop();

            var actual = TimeSpan.FromMilliseconds(carConfiguration.ElapsedTime);

            Assert.AreEqual(expected, actual);
        }
    }
}

