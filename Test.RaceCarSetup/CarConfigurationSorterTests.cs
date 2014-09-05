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
			var carConfigurations = TestData.GetCarConfigurations ();

			var expected = carConfigurations.OrderBy (x => x.ElapsedTime).Select (x => x.ElapsedTime).ToArray ();

			var actual = _carConfirgurationSorter.Sort (carConfigurations.ToArray (), 0, carConfigurations.Length - 1)
				.Select (x => x.ElapsedTime).ToArray ();

			Assert.True (actual.SequenceEqual (expected));
		}
	}
}

