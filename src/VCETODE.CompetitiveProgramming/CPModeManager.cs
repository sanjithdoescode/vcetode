using System.Threading.Tasks;

namespace VCETODE.CompetitiveProgramming
{
    /// <summary>
    /// Manages actions specific to the Competitive Programming mode.
    /// </summary>
    public class CPModeManager
    {
        public CPModeManager() { }

        public async Task<string> GetSolutionAsync(string questionNumber, string platform, string language)
        {
            CPQueryService queryService = new CPQueryService();
            return await queryService.GetSolutionAsync(questionNumber, platform, language);
        }
    }
}
