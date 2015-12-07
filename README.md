# RiotCommon
Common tools for interacting with Riot API

Examples:

```c#
using (var summonerClient = new SummonerClient("na", "1.4", apiKey))
{
    var summoner = await summonerClient.GetSummonerByName("doublelift");
    var id = summoner.Id;
    var level = summoner.SummonerLevel;

    var summonerDict = await summonerClient.GetSummonerByName(new List<string> { "c9sneaky", "doublelift" });

    var sneaky = summonerDict["c9sneaky"];
    var sneakyId = sneaky.Id;
    var sneakyLevel = sneaky.SummonerLevel;

    var doublelift = summonerDict["doublelift"];
    var doubleliftId = doublelift.Id;
    var doubleliftLevel = doublelift.SummonerLevel;
}

```

NuGet packages now available.

https://www.nuget.org/packages/CoffeeCat.RiotCommon

https://www.nuget.org/packages/CoffeeCat.RiotClient
