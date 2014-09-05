using NUnit.Framework;
using FizzWare.NBuilder;
using RaceCarSetup;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Test.RaceCarSetup
{

	public static class TestData
	{
		public static CarConfiguration[] GetCarConfigurations ()
		{
			var carConfigurations = new List<CarConfiguration> ();

			var random = new Random ();

			for (int i = 0; i < 10; i++) {
				carConfigurations.Add (GetCarConfiguration (random));
			}

			return carConfigurations.ToArray ();
		}

		public static CarConfiguration GetCarConfiguration (Random random)
		{
			var raceTrack = Builder<RaceTrack>.CreateNew ().Build ();
			var carConfiguration = new CarConfiguration (raceTrack, random.NextDouble (), random.NextDouble (), random.Next ());

			carConfiguration.CompleteLap ();

			return carConfiguration;
		}
	}
}
