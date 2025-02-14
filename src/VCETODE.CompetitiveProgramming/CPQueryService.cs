using System;
using System.Net.Http;
using System.Threading.Tasks;
using VCETODE.Core;

namespace VCETODE.CompetitiveProgramming
{
    /// <summary>
    /// Service to query competitive programming solutions from external APIs.
    /// Replace the sample endpoints with actual APIs and authentication as needed.
    /// </summary>
    public class CPQueryService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<string> GetSolutionAsync(string questionNumber, string platform, string language)
        {
            try
            {
                string queryUrl = BuildQueryUrl(questionNumber, platform, language);
                HttpResponseMessage response = await httpClient.GetAsync(queryUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    string errorMsg = $"API error: {response.StatusCode}";
                    Logger.LogError(errorMsg);
                    return errorMsg;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error fetching competitive programming solution", ex);
                return $"Exception: {ex.Message}";
            }
        }

        /// <summary>
        /// Constructs the query URL based on the platform and parameters.
        /// </summary>
        private string BuildQueryUrl(string questionNumber, string platform, string language)
        {
            // Sample endpoints; update these with real API URLs and parameters.
            return platform.ToLower() switch
            {
                "leetcode"    => $"https://api.cp-solver.com/leetcode/solution?question={questionNumber}&lang={language}",
                "hackerrank"  => $"https://api.cp-solver.com/hackerrank/solution?question={questionNumber}&lang={language}",
                "codeforces"  => $"https://api.cp-solver.com/codeforces/solution?question={questionNumber}&lang={language}",
                _             => throw new ArgumentException("Unsupported platform")
            };
        }
    }
}
