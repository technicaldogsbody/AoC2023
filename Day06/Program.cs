using Day06;

long[] sampleRaceTimes = { 7, 15, 30 };
long[] sampleRecordDistances = { 9, 40, 200 };
long[] raceTimes = { 54, 70, 82, 75 };
long[] recordDistances = { 239, 1142, 1295, 1253 };
var calculator = new RaceCalculator();

var sample = calculator.GetMarginOfError(sampleRaceTimes, sampleRecordDistances);
var full = calculator.GetMarginOfError(raceTimes, recordDistances);

Console.WriteLine(sample);
Console.WriteLine(full);

long[] sampleRaceTimes2 = { 71530 };
long[] sampleRecordDistances2 = { 940200 };
long[] raceTimes2 = { 54708275 };
long[] recordDistances2 = { 239114212951253 };

sample = calculator.GetMarginOfError(sampleRaceTimes2, sampleRecordDistances2);
full = calculator.GetMarginOfError(raceTimes2, recordDistances2);

Console.WriteLine(sample);
Console.WriteLine(full);
