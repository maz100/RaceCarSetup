namespace RaceCarSetup
{
    public class RaceTrack
    {
        public RaceTrack()
        {
        }

        /// <summary>
        /// Gets or sets the lap distance.
        /// </summary>
        /// <value>The lap distance in kilometers.</value>
        public double LapDistance { get; set; }

        /// <summary>
        /// Gets or sets the total laps.
        /// </summary>
        /// <value>The total laps.</value>
        public int TotalLaps { get; set; }

        /// <summary>
        /// Gets or sets the pit stop time.
        /// </summary>
        /// <value>The pit stop time in milliseconds.</value>
        public double PitStopTime { get; set; }

        public override string ToString()
        {
            return string.Format("[RaceTrack: LapDistance={0}, TotalLaps={1}, PitStopTime={2}]", LapDistance, TotalLaps, PitStopTime);
        }
    }
}

