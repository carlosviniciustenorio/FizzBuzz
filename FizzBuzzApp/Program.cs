using TwistedFizzBuzz;

var fizzBuzz = new FizzBuzzGenerator();
string apiUrl = "https://pie-healthy-swift.glitch.me/word";

bool success = await fizzBuzz.LoadRulesFromApiAsync(apiUrl);
if (!success)
    Console.WriteLine("Failed to load tokens from API. Using default rules.");

var result = fizzBuzz.GetFizzBuzzRange(1, 100);

foreach (var output in result)
    Console.WriteLine(output);
