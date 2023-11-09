using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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
            return "Mayan math challenge started";
        }
        public async Task<string> ClearChallenge()
        {
            try
            {
                var mayanNumbers = await GetChallengeInfo();
                var totalResult = CalculateArrayInToNumbers(mayanNumbers);
                var MayanResult = ConvertDecimalToVigesimal(totalResult);
                await SendAnswerOfChallenge(MayanResult);
                return "You have done mayan math correctly";
            }
            catch (Exception ex)
            {
                return Constants.FailedPuzzle;
            }

        }
        private async Task SendAnswerOfChallenge(string answer)
        {
            var result = await _hackTheFutureClient.PostAsJsonAsync<string>($"/api/path/b/hard/puzzle", answer);
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception();
            }
        }

        private string ConvertDecimalToVigesimal(double result)
        {
            string calc = "";
            string vigesimal = "";
            do
            {
                var temp = result % 20;
                calc = $"{temp} {calc}";
                result = result - temp;
                result = result/20;
            }while (result > 0);
            calc = calc.Remove(calc.Length - 1);
            var splitParts = calc.Split(" ");
            foreach(var part in splitParts)
            {
                if(part == "0")
                {
                    vigesimal += " Ⱄ ";
                }
                else
                {
                    int partNumber = int.Parse(part);
                    do
                    {
                        if (partNumber >= 5)
                        {
                            vigesimal += "|";
                            partNumber = partNumber - 5;
                        }
                        else
                        {
                            vigesimal+= "·";
                            partNumber--;
                        }
                    } while (partNumber != 0);
                    vigesimal += " ";
                }
            }
            return vigesimal;
        }

        private double CalculateArrayInToNumbers(string[] mayanNumbers)
        {
            double total = 0;
            foreach (var number in mayanNumbers)
            {
                string[] splitNumbers;
                if(number.Contains(" "))
                {
                    splitNumbers = number.Split(' ');
                    splitNumbers = splitNumbers.Reverse().ToArray();
                }
                else
                {
                    splitNumbers = new[] { number };
                }
                for (int  i = 0;  i < splitNumbers.Length;  i++)
                {
                    total += CalculateMayanToNumber(i, splitNumbers[i]);
                } 
            }
            return total;
        }

        private async Task<string[]> GetChallengeInfo()
        {
            var result = await _hackTheFutureClient.GetAsync("/api/path/b/hard/puzzle");
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string[]>(content);
        }

        private double CalculateMayanToNumber(int index, string splitNumber)
        {
            double total = 0;
            double multiplier = 1;
            if(index != 0)
            {
                multiplier = Math.Pow(20, index);
            }
            foreach(var pieceOfNumber in splitNumber)
            {
                var tempNumber = pieceOfNumber.ToString();
                if (tempNumber == "·")
                {
                    total += 1 * multiplier;
                }
                else if(tempNumber == "|")
                {
                    total += 5 * multiplier;
                }
                else
                {
                    total = 0;
                }
            }
            return total;
        }
    }
}
