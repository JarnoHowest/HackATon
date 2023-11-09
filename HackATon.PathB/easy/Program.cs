// See https://aka.ms/new-console-template for more information
using HackATon.PathB.easy;

MayanCalander mayan = new MayanCalander();
var start = await mayan.StartChallenge();
Console.WriteLine(start);

Console.WriteLine(await mayan.ClearChallenge());
