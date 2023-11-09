using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HackATon.PathB.Cons.Medium
{
    public class MatchingHieroglyphs
    {
        private readonly HackTheFutureClient _hackTheFutureClient;
        public MatchingHieroglyphs(HackTheFutureClient hackTheFutureClient)
        {
            _hackTheFutureClient = hackTheFutureClient;
        }

        public async Task<string> StartChallenge()
        {
            var result = await _hackTheFutureClient.GetAsync("/api/path/b/medium/start");
            if (!result.IsSuccessStatusCode)
            {
                return "Challenge not started";
            }
            return "Challenge started";
        }
        //glyphs that show up in all is what you send
        public async Task<string> ClearChallenge()
        {
            try
            {
                var result = await GetChallengeInfo();
                var stringOfFilteredGlyphs = FilterHieroglyphs(result);
                await SendAnswerOfChallenge(stringOfFilteredGlyphs);
                return "The glyphs have been filtered correctly";
            }
            catch(Exception ex)
            {
                return Constants.FailedPuzzle;
            }
        }
        private async Task<string[]> GetChallengeInfo()
        {
            var result = await _hackTheFutureClient.GetAsync("/api/path/b/medium/puzzle");
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            var content = await result.Content.ReadAsStringAsync();
            var challengeInfo = JsonConvert.DeserializeObject<string[]>(content);
            return challengeInfo;
        }
        private string FilterHieroglyphs(string[] glyphs)
        {
            string result="";
            foreach(var glyph in glyphs)
            {
                foreach(char glyphChar in glyph)
                {
                    if (glyphs.All(g=> g.Contains(glyphChar)))
                    {
                        if (!result.Contains(glyphChar))
                        {
                            result += glyphChar;
                        }
                    }
                }
            }
            return result;
        }
        private async Task SendAnswerOfChallenge(string answer)
        {
            var result = await _hackTheFutureClient.PostAsJsonAsync<string>($"/api/path/b/medium/puzzle", answer);
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception();
            }
        }
    }
}
