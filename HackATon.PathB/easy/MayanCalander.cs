using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common;
using HackATon.PathB.Cons;
using Newtonsoft.Json;

namespace HackATon.PathB.easy
{
    public class MayanCalander : IChallengeClearer
    {
        private readonly HackTheFutureClient _hackTheFutureClient;
        public MayanCalander(HackTheFutureClient hackTheFutureClient)
        {
            _hackTheFutureClient = hackTheFutureClient;
        }
        public async Task<string> StartChallenge()
        {
            await _hackTheFutureClient.Login(Constants.UserName, Constants.Password);
            var result = await _hackTheFutureClient.GetAsync("/api/path/b/easy/start");
            if (!result.IsSuccessStatusCode)
            {
                return "Challenge not started";
            }
            return "Challenge started";
        }
        private async Task<MayanCalendarChallengeDto> GetChallengeInfo()
        {
            var result = await _hackTheFutureClient.GetAsync("/api/path/b/easy/puzzle");
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            var content = await result.Content.ReadAsStringAsync();
            var mayanCalanderDto = JsonConvert.DeserializeObject<MayanCalendarChallengeDto>(content);
            return mayanCalanderDto;
        }
        public async Task<string> ClearChallenge()
        {
            try
            {
                var challengeInfo = await GetChallengeInfo();
                var answer = GetAmountOfDay(challengeInfo);
                await SendAnswerOfChallenge(answer);
                return $"The answer is {answer}";
            }
            catch(Exception ex)
            {
                return Constants.FailedPuzzle;
            }
            
        }

        private async Task SendAnswerOfChallenge(int answer)
        {
            var result = await _hackTheFutureClient.PostAsJsonAsync<int>($"/api/path/b/easy/puzzle", answer);
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception();
            }
        }

        private int GetAmountOfDay(MayanCalendarChallengeDto mayanChallenge)
        {
            var amountOfDays = 0;
            if(mayanChallenge.StartDate.DayOfWeek.ToString() == mayanChallenge.Day)
            {
                amountOfDays++;
            }
            var date = mayanChallenge.StartDate;
            do
            {
                date = date.AddDays(1);
                if(date.DayOfWeek.ToString() == mayanChallenge.Day)
                {
                    amountOfDays++;
                }

            } while (date != mayanChallenge.EndDate);

            return amountOfDays;
        }

    }
}
