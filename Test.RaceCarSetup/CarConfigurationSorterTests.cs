using NUnit.Framework;
using FizzWare.NBuilder;
using RaceCarSetup;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Test.RaceCarSetup
{
	[TestFixture]
	public class CarConfigurationSorterTests
	{
		private CarConfigurationSorter _carConfirgurationSorter;

		[SetUp]
		public void SetUp ()
		{
			_carConfirgurationSorter = new CarConfigurationSorter ();
		}

		[Test]
		public void TestSort_sorts_array_by_elapsed_time ()
		{
			var carConfigurations = GetCarConfigurations ();

			var expected = carConfigurations.OrderBy (x => x.ElapsedTime).ToArray ();

			var actual = _carConfirgurationSorter.Sort (carConfigurations.ToArray (), 0, carConfigurations.Length - 1);

			var expectedElapsedTimes = expected.Select (x => x.ElapsedTime).ToList ();

			var actualElapsedTimes = actual.Select (x => x.ElapsedTime).ToList ();

			Assert.True (actual.SequenceEqual (expected));
		}

		private CarConfiguration[] GetCarConfigurations ()
		{
			var carConfigurations = new List<CarConfiguration> ();

			var random = new Random ();

			for (int i = 0; i < 10; i++) {
				carConfigurations.Add (GetCarConfiguration (random));
			}

			return carConfigurations.ToArray ();
		}

		private CarConfiguration GetCarConfiguration (Random random)
		{
			var raceTrack = Builder<RaceTrack>.CreateNew ().Build ();
			var carConfiguration = new CarConfiguration (raceTrack, random.NextDouble (), random.NextDouble (), random.Next ());

			carConfiguration.CompleteLap ();

			return carConfiguration;
		}

		


	}
}

