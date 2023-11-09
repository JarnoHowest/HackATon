// See https://aka.ms/new-console-template for more information
using Common;
using PathA;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

HackTheFutureClient hackTheFutureClient = new HackTheFutureClient();
await hackTheFutureClient.Login("*", "ETmpRH6seu");

/*
//A1
Challenge1 challenge1 = new Challenge1();
challenge1.Run(hackTheFutureClient);



//A2
Challenge2 challenge2 = new Challenge2();
challenge2.Run(hackTheFutureClient);
*/

//A3
Challenge3 challenge3 = new Challenge3();
challenge3.Run(hackTheFutureClient);

Console.ReadLine();