// See https://aka.ms/new-console-template for more information
using Common;
using HackATon.PathB.Cons.Medium;
using HackATon.PathB.easy;

HackTheFutureClient hackTheFutureClient = new HackTheFutureClient();

MayanCalander mayan = new MayanCalander(hackTheFutureClient);
var start = await mayan.StartChallenge();
Console.WriteLine(start);

Console.WriteLine(await mayan.ClearChallenge());

Console.WriteLine("Next challenge");

MatchingHieroglyphs matchingHieroglyphs = new MatchingHieroglyphs(hackTheFutureClient);
start = await matchingHieroglyphs.StartChallenge();
Console.WriteLine(await matchingHieroglyphs.ClearChallenge());