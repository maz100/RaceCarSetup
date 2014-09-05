using System;
using RaceCarSetup;
using NUnit.Framework;
using Moq;

namespace Test.RaceCarSetup
{
	[TestFixture]
	public class RaceApplicationTests
	{
		private RaceApplication _raceApplication;
		private Mock<IRaceable> _raceable;
		private RaceTrack _raceTrack;

		[SetUp]
		public void SetUp ()
		{
			_raceApplication = new RaceApplication ();

			_raceable = new Mock<IRaceable> ();

			_raceTrack = new RaceTrack ();
			_raceTrack.LapDistance = 5;
			_raceTrack.PitStopTime = 3;
			_raceTrack.TotalLaps = 2;
		}

		[Test]
		public void TestRace_interaction_with_raceable_correct_number_of_laps ()
		{						
			_raceable.Setup (x => x.HasSufficientFuel).Returns (true);
			_raceable.Setup (x => x.CompleteLap ());

			_raceApplication.Race (_raceTrack, _raceable.Object);

			_raceable.Verify (x => x.HasSufficientFuel, Times.Exactly (_raceTrack.TotalLaps));
			_raceable.Verify (x => x.CompleteLap (), Times.Exactly (_raceTrack.TotalLaps));
		}

		[Test]
		public void TestRace_interaction_with_raceable_makes_pitstop_when_necessary ()
		{
			_raceable.SetupSequence (x => x.HasSufficientFuel).Returns (false).Returns (true);
			_raceable.Setup (x => x.MakePitstop ());
			_raceable.Setup (x => x.CompleteLap ());

			_raceApplication.Race (_raceTrack, _raceable.Object);

			_raceable.Verify (x => x.HasSufficientFuel, Times.Exactly (_raceTrack.TotalLaps));
			_raceable.Verify (x => x.MakePitstop (), Times.Once);
			_raceable.Verify (x => x.CompleteLap (), Times.Exactly (_raceTrack.TotalLaps));
		}

		[Test]
		public void TestRace_show_diagnostic_messages_on_console ()
		{
			var raceTrack = new RaceTrack ();
			raceTrack.LapDistance = 5;
			raceTrack.PitStopTime = 3.123;
			raceTrack.TotalLaps = 10;

			Console.WriteLine (raceTrack);

			_raceApplication.Race (raceTrack, new DiagnosticCarConfiguration (raceTrack,
				averageSpeed: 100,
				fuelCapacity: 10,
				fuelConsumptionPerKm: 0.25F,
				id: 1));
		}
	}
}

