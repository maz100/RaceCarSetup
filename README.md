RaceCarSetup
============

<img src="https://ci.appveyor.com/api/projects/status/e9ildc67bte7ae62">

Technical test / Kata

The purpose of the software is to be able to rank a given set of car configurations for a particular race track based on the race completion time.

The RaceCarSetup class library provides the class RaceManager.  The Race method of that class takes a RaceTrack and an array of CarConfigurations.  Each CarConfiguration in the array should be initialised with the same RaceTrack.  The method returns a copy of the CarConfigurations array ranked by the ElapsedTime property.

The class library was developed test first and the tests in the test assembly Test.RaceCarSetup are a mixture of classic and mockist/interaction tests.

The test assembly subclasses CarConfiguration with DiagnosticCarConfiguration.  This adds console logging which was useful during development in addition to the automated tests.

The test TestRace_inject_real_implementation_log_results_to_console is marked with the category 'Demo'.  This demos the code with RaceManager having a quicksort implementation of the ICarConfigurationSorter interface used to sort the car configurations.  The results of the race are written to the console.

As requested the class library contains no references even to System.  The test assembly references the class library, Nunit, Moq and NBuilder.  When using VS2013 nuget packages will be automatically downloaded.  Older versions of Visual Studio may need to be enabled to restore nuget packages.  In order to run the Nunit tests visual studio should have a test runner enabled which is compatible with Nunit such as Resharper or the Nunit test adapter for visual studio.  
