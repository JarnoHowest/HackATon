// See https://aka.ms/new-console-template for more information
using Common;
using HackATon.PathB.Cons.Hard;
using HackATon.PathB.Cons.Medium;
using HackATon.PathB.easy;

HackTheFutureClient hackTheFutureClient = new HackTheFutureClient();

MayanCalander mayan = new MayanCalander(hackTheFutureClient);
var start = await mayan.StartChallenge();
Console.WriteLine(start);

Console.WriteLine(await mayan.ClearChallenge());
Console.WriteLine("-------------------------------------");
Console.WriteLine("Next challenge");

MatchingHieroglyphs matchingHieroglyphs = new MatchingHieroglyphs(hackTheFutureClient);
Console.WriteLine(await matchingHieroglyphs.StartChallenge());
start = await matchingHieroglyphs.StartChallenge();
Console.WriteLine(await matchingHieroglyphs.ClearChallenge());
Console.WriteLine("-------------------------------------");
Console.WriteLine("Next challenge");
MayanMathCalculator mayanMathCalculator = new MayanMathCalculator(hackTheFutureClient);
Console.WriteLine(await mayanMathCalculator.StartChallenge());
Console.WriteLine(await mayanMathCalculator.ClearChallenge());