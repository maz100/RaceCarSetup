using System;
using RaceCarSetup;
using NUnit.Framework;
using Moq;
using FizzWare.NBuilder;

namespace Test.RaceCarSetup
{
	[TestFixture]
	public class RaceManagerTests
	{
		private RaceManager _raceManager;
		private MockRepository _mocks;
		private Mock<CarConfiguration> _carConfiguration;
		private Mock<ICarConfigurationSorter> _carConfigurationSorter;
		private RaceTrack _raceTrack;
		private CarConfiguration[] _rankedCarConfigurations;

		[SetUp]
		public void SetUp ()
		{
			_mocks = new MockRepository (MockBehavior.Default);
			_carConfiguration = _mocks.Create<CarConfiguration> ();
			_carConfigurationSorter = _mocks.Create<ICarConfigurationSorter> ();

			_raceManager = new RaceManager (_carConfigurationSorter.Object);

			_raceTrack = new RaceTrack ();
			_raceTrack.LapDistance = 5;
			_raceTrack.PitStopTime = 3;
			_raceTrack.TotalLaps = 2;

			//return value for car config sorter - we don't care about the actual values, its just a reference!
			_rankedCarConfigurations = new CarConfiguration[]{ new CarConfiguration () };

			_carConfigurationSorter.Setup (x => x.Sort (It.IsAny<CarConfiguration[]> (), 0, It.IsAny<int> ())).Returns (_rankedCarConfigurations);
		}

		[Test]
		public void TestRace_interaction_verify_number_of_laps ()
		{						
			_carConfiguration.Setup (x => x.HasSufficientFuel).Returns (true);
			_carConfiguration.Setup (x => x.CompleteLap ());

			_raceManager.Race (_raceTrack, _carConfiguration.Object);

			_carConfiguration.Verify (x => x.HasSufficientFuel, Times.Exactly (_raceTrack.TotalLaps));
			_carConfiguration.Verify (x => x.CompleteLap (), Times.Exactly (_raceTrack.TotalLaps));

			_mocks.VerifyAll ();
		}

		[Test]
		public void TestRace_interaction_makes_pitstop_when_necessary ()
		{
			_carConfiguration.SetupSequence (x => x.HasSufficientFuel).Returns (false).Returns (true);
			_carConfiguration.Setup (x => x.MakePitstop ());
			_carConfiguration.Setup (x => x.CompleteLap ());

			_raceManager.Race (_raceTrack, _carConfiguration.Object);

			_carConfiguration.Verify (x => x.HasSufficientFuel, Times.Exactly (_raceTrack.TotalLaps));
			_carConfiguration.Verify (x => x.MakePitstop (), Times.Once);
			_carConfiguration.Verify (x => x.CompleteLap (), Times.Exactly (_raceTrack.TotalLaps));
		}

		[Test]
		public void TestRace_show_diagnostic_messages_on_console ()
		{
			var raceTrack = new RaceTrack ();
			raceTrack.LapDistance = 5;
			raceTrack.PitStopTime = 3.123;
			raceTrack.TotalLaps = 10;

			Console.WriteLine (raceTrack);

			_raceManager.Race (raceTrack, new DiagnosticCarConfiguration (raceTrack,
				averageSpeed: 100,
				fuelCapacity: 10,
				fuelConsumptionPerKm: 0.25F,
				id: 1));
		}

		[Test]
		public void TestRace_returns_sorted_car_configurations ()
		{
			var result = _raceManager.Race (_raceTrack, TestData.GetCarConfigurations ());

			Assert.AreEqual (_rankedCarConfigurations, result);

			_mocks.VerifyAll ();
		}

		[Test]
		public void TestRace_inject_real_implementation_log_results_to_console ()
		{
			//designed for manual testing - examine details logged to console
			var raceManager = new RaceManager (new CarConfigurationSorter ());

			var raceTrack = TestData.GetRaceTrack ();

			var rankedCarConfigurations = raceManager.Race (raceTrack, TestData.GetCarConfigurations2 (raceTrack));

			for (int i = 0; i < rankedCarConfigurations.Length; i++) {
				var car = rankedCarConfigurations [i];
				var raceCompletionTime = TimeSpan.FromMilliseconds (car.ElapsedTime);
				Console.WriteLine (string.Format ("Rank={0}, CarConfig Id={1}, Race Completion Time={2:g}", i + 1, car.Id, raceCompletionTime)); 
			}
		}
	}
}

