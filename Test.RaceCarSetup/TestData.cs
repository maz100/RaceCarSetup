using FizzWare.NBuilder;
using RaceCarSetup;
using System;
using System.Collections.Generic;

namespace Test.RaceCarSetup
{
    public static class TestData
    {
        public static CarConfiguration[] GetCarConfigurations(RaceTrack raceTrack = null)
        {
            var carConfigurations = new List<CarConfiguration>();

            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                carConfigurations.Add(GetCarConfiguration(random, raceTrack, i));
            }

            return carConfigurations.ToArray();
        }

        public static CarConfiguration[] GetCarConfigurations2(RaceTrack raceTrack = null)
        {
            var carConfigurations = new List<CarConfiguration>();

            carConfigurations.Add(new DiagnosticCarConfiguration(raceTrack, 100, 200, 0.25, 1));
            carConfigurations.Add(new DiagnosticCarConfiguration(raceTrack, 99, 207, 0.3, 2));
            carConfigurations.Add(new DiagnosticCarConfiguration(raceTrack, 80, 213, 0.75, 3));
            carConfigurations.Add(new DiagnosticCarConfiguration(raceTrack, 89, 198, 0.65, 4));
            carConfigurations.Add(new DiagnosticCarConfiguration(raceTrack, 95, 201, 0.66, 5));
            carConfigurations.Add(new DiagnosticCarConfiguration(raceTrack, 93, 203, 0.43, 6));
            carConfigurations.Add(new DiagnosticCarConfiguration(raceTrack, 94, 199, 0.31, 7));
            carConfigurations.Add(new DiagnosticCarConfiguration(raceTrack, 91, 192, 0.22, 8));
            carConfigurations.Add(new DiagnosticCarConfiguration(raceTrack, 100, 208, 0.24, 9));
            carConfigurations.Add(new DiagnosticCarConfiguration(raceTrack, 99, 209, 0.27, 10));


            return carConfigurations.ToArray();
        }

        public static CarConfiguration GetCarConfiguration(Random random, RaceTrack raceTrack = null, int id = 0)
        {
            if (raceTrack == null)
            {
                raceTrack = Builder<RaceTrack>.CreateNew().Build();
            }

            var carConfiguration = new DiagnosticCarConfiguration(raceTrack, random.NextDouble(), random.NextDouble(), random.Next(), id);

            carConfiguration.CompleteLap();

            return carConfiguration;
        }

        public static RaceTrack GetRaceTrack()
        {
            var result = new RaceTrack();
            result.LapDistance = 5.5;
            result.PitStopTime = 3.5;
            result.TotalLaps = 68;

            return result;
        }
    }
}
