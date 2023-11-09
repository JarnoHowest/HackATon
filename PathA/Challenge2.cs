using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PathA
{
    public class Challenge2
    {
        public async void Run(HackTheFutureClient hackTheFutureClient)
        {
            //Get json
            Console.WriteLine("Challenge A2:");
            await hackTheFutureClient.GetAsync("api/path/a/medium/start");
            var response = await hackTheFutureClient.GetAsync("api/path/a/medium/puzzle");
            var contents = await response.Content.ReadAsStringAsync();
            
            //Deserialize json
            VineNavigationChallengeDto? myDeserializedClass = JsonConvert.DeserializeObject<VineNavigationChallengeDto>(contents);

            //Print data
            Console.WriteLine("amount of vines: " + myDeserializedClass.AmountOfVines);
            Console.WriteLine("start: " + myDeserializedClass.Start);
            Console.WriteLine("directions:");

            //Set variables
            int size = ((int)Math.Sqrt(myDeserializedClass.AmountOfVines) -1);
            var startList = myDeserializedClass.Start.Split(",");
            int x = int.Parse(startList[0]);
            var y = int.Parse(startList[1]);

            //Run over directions
            foreach( var direction in myDeserializedClass.Directions)
            {
                Console.WriteLine(direction.ToString());
                switch (direction)
                {
                    case "U":
                        if (y < size)
                            y += 1;
                        break;
                    case "D":
                        if (y > 0)
                            y -= 1;
                        break;
                    case "L":
                        if (x > 0)
                            x -= 1;
                        break;
                    case "R":
                        if (x < size)
                            x += 1;
                        break;
                    case "UR":
                        if (x < size && y < size)
                        {
                            x += 1;
                            y += 1;
                        }
                        break;
                    case "UL":
                        if (x > 0 && y < size)
                        {
                            x -= 1;
                            y += 1;
                        }
                        break;
                    case "DR":
                        if (x < size && y > 0)
                        {
                            x += 1;
                            y -= 1;
                        }
                        break;
                    case "DL":
                        if (x > 0 && y > 0)
                        {
                            x -= 1;
                            y -= 1;
                        }
                        break;
                }
                Console.WriteLine("x: " + x + " y:" + y);
            }

            //Create result
            string result = x.ToString() + " ," + y.ToString();
            Console.WriteLine(result);

            //Post result
            response = await hackTheFutureClient.PostAsJsonAsync("api/path/a/medium/puzzle", result);
            contents = await response.Content.ReadAsStringAsync();
            Console.WriteLine(contents);
        }
    }
}