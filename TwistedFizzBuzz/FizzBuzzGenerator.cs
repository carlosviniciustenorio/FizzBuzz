using System.Net.Http.Headers;
using System.Text.Json;
using TwistedFizzBuzz.Client.Responses;

namespace TwistedFizzBuzz;

public class FizzBuzzGenerator
{
    private readonly Dictionary<int, string> _rules;
    private readonly HttpClient _httpClient = new(){DefaultRequestHeaders = { UserAgent = { new ("FizzBuzzClient", "1.0") }}};
    public FizzBuzzGenerator(Dictionary<int, string>? customRules = null)
    {
        _rules = customRules ?? new Dictionary<int, string>
        {
            { 3, "Fizz" },
            { 5, "Buzz" }
        };
    }

    /// <summary>
    /// Loads FizzBuzz rules from an FizzBuzz external API.
    /// </summary>
    public async Task<bool> LoadRulesFromApiAsync(string apiUrl)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            using var response = await _httpClient.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error loading tokens from API. Status: {response.StatusCode}");
                return false;
            }

            var json = await response.Content.ReadAsStringAsync();
            var apiRule = JsonSerializer.Deserialize<FizzBuzzApiResponse>(json);

            if (apiRule == null)
                return false;

            _rules[apiRule.Number] = apiRule.Word;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tokens from API: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Generates FizzBuzz output for a range of numbers.
    /// </summary>
    public List<string> GetFizzBuzzRange(int start, int end)
    {
        return GetFizzBuzzRange(Enumerable.Range(start, end - start + 1));
    }

    /// <summary>
    /// Generates FizzBuzz output for a custom list of numbers.
    /// </summary>
    public List<string> GetFizzBuzzRange(IEnumerable<int> numbers)
    {
        return numbers.Select(GenerateFizzBuzz).ToList();
    }

    private string GenerateFizzBuzz(int number)
    {
        string result = string.Concat(_rules.Where(rule => number % rule.Key == 0).Select(rule => rule.Value));

        return string.IsNullOrEmpty(result) ? number.ToString() : result;
    }
}