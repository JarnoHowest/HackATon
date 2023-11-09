// See https://aka.ms/new-console-template for more information
using Common;
using PathA;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

HackTheFutureClient hackTheFutureClient = new HackTheFutureClient();
await hackTheFutureClient.Login("*", "ETmpRH6seu");

//A1
Challenge1 challenge1 = new Challenge1();
challenge1.Run();

//A2


Console.ReadLine();