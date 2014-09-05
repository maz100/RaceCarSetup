﻿using System;
using RaceCarSetup;

namespace Test.RaceCarSetup
{
	public class DiagnosticCarConfiguration : CarConfiguration
	{
		public DiagnosticCarConfiguration (RaceTrack raceTrack, double fuelCapacity, double averageSpeed, double fuelConsumptionPerKm, int id = 0) : base (raceTrack, fuelCapacity, averageSpeed, fuelConsumptionPerKm, id)
		{
			
		}

		public override void CompleteLap ()
		{
			Console.WriteLine ("CompleteLap: " + ToString ());
			base.CompleteLap ();
		}

		public override void MakePitstop ()
		{
			Console.WriteLine ("MakePitstop: " + ToString ());
			base.MakePitstop ();
		}

		//public override string ToString ()
		//{
		//	return string.Format ("[CarConfiguration: Id={0} RemainingFuel={1}, ElapsedTime={2}, HasSufficientFuel={3}]", Id, RemainingFuel, TimeSpan.FromHours (ElapsedTime), base.HasSufficientFuel);
		//}

		public override string ToString ()
		{
			return string.Format ("[CarConfiguration: Id={0}, FuelCapacity={1}, AverageSpeed={2}, FuelConsumptionPerKm={3}, LapTime={4}, FuelConsumptionPerLap={5}, RemainingFuel={6}, ElapsedTime={7}, HasSufficientFuel={8}]", Id, FuelCapacity, AverageSpeed, FuelConsumptionPerKm, TimeSpan.FromMilliseconds (LapTime), FuelConsumptionPerLap, RemainingFuel, TimeSpan.FromMilliseconds (ElapsedTime), HasSufficientFuel);
		}

	}
}
