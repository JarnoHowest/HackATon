using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackATon.PathB.Cons.Hard
{
    public class MayanMathCalculator : IChallengeClearer
    {

        private readonly HackTheFutureClient _hackTheFutureClient;
        public MayanMathCalculator(HackTheFutureClient hackTheFutureClient)
        {
            _hackTheFutureClient = hackTheFutureClient;
        }
        public async Task<string> StartChallenge()
        {
            var result = await _hackTheFutureClient.GetAsync("/api/path/b/hard/start");
            if (!result.IsSuccessStatusCode)
            {
                return "Challenge not started";
            }
            return "Challenge started";
        }
        public async Task<string> ClearChallenge()
        {
            try
            {
                return "hi";
            }
            catch (Exception ex)
            {
                return Constants.FailedPuzzle;
            }

        }
    }
}
