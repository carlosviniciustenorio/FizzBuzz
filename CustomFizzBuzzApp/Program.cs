using TwistedFizzBuzz;

var customRules = new Dictionary<int, string>
{
    { 5, "Fizz" },
    { 9, "Buzz" },
    { 27, "Bar" }
};

var fizzBuzz = new FizzBuzzGenerator(customRules);
var result = fizzBuzz.GetFizzBuzzRange(-20, 127);

foreach (var output in result)
{
    Console.WriteLine(output);
}