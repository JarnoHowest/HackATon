using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PathA
{
    public class Challenge1
    {
        public async void Run(HackTheFutureClient hackTheFutureClient)
        {
            //Get string
            Console.WriteLine("Challenge A1:");
            await hackTheFutureClient.GetAsync("api/path/a/easy/start");
            var response = await hackTheFutureClient.GetAsync("api/path/a/easy/puzzle");
            var contents = await response.Content.ReadAsStringAsync();

            //Call decoder
            MayaDecoder decoder = new MayaDecoder();
            var decodeResult = decoder.Decode(contents.ToString());
            Console.WriteLine(decodeResult);

            //Post response
            response = await hackTheFutureClient.PostAsJsonAsync("api/path/a/easy/puzzle", decodeResult);
            contents = await response.Content.ReadAsStringAsync();
            Console.WriteLine(contents);
        }
    }
}
