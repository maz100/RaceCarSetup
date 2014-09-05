namespace RaceCarSetup
{
	public interface IRaceable
	{
		bool HasSufficientFuel { get; }

		void CompleteLap ();

		void MakePitstop ();
	}
}

