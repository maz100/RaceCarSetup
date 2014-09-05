using System;
using RaceCarSetup;
using NUnit.Framework;
using Moq;

namespace Test.RaceCarSetup
{
	[TestFixture]
	public class RaceManagerTests
	{
		private RaceManager _raceManager;
		private Mock<CarConfiguration> _carConfiguration;
		private RaceTrack _raceTrack;

		[SetUp]
		public void SetUp ()
		{
			_raceManager = new RaceManager ();

			_carConfiguration = new Mock<CarConfiguration> ();

			_raceTrack = new RaceTrack ();
			_raceTrack.LapDistance = 5;
			_raceTrack.PitStopTime = 3;
			_raceTrack.TotalLaps = 2;
		}

		[Test]
		public void TestRace_interaction_verify_number_of_laps ()
		{						
			_carConfiguration.Setup (x => x.HasSufficientFuel).Returns (true);
			_carConfiguration.Setup (x => x.CompleteLap ());

			_raceManager.Race (_raceTrack, _carConfiguration.Object);

			_carConfiguration.Verify (x => x.HasSufficientFuel, Times.Exactly (_raceTrack.TotalLaps));
			_carConfiguration.Verify (x => x.CompleteLap (), Times.Exactly (_raceTrack.TotalLaps));
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
	}
}

