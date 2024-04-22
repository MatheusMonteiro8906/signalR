// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;

const string dateListenerURL = "http://localhost:5062/date";
await using var connection = new HubConnectionBuilder()
    .WithUrl(dateListenerURL)
    .Build();

await connection.StartAsync();

await foreach (var date in connection
    .StreamAsync<DateTime>("streaming"))
{
    Console.WriteLine(date);
}
