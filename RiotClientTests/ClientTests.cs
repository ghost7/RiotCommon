using CoffeeCat.RiotClient.Clients;
using CoffeeCat.RiotCommon.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotClientTests
{
    [TestClass]
    public class ClientTests
    {
        private static string ApiKeyVariableName = "API_KEY";
        private static string Region = "na";
        private string apiKey;

        [TestInitialize]
        public void Setup()
        {
            apiKey = Environment.GetEnvironmentVariable(ApiKeyVariableName);
        }

        [TestMethod]
        public async Task TestSummonerClient_ByName()
        {
            var version = "1.4";
            var summonerName = "doublelift";
            var summonerName2 = "c9sneaky";
            var summonerClient = new SummonerClient(Region, version, this.apiKey);

            var summoner = await summonerClient.GetSummonerByName(summonerName);
            Assert.IsNotNull(summoner);

            var summonerDict = await summonerClient.GetSummonerByName(new List<string> { summonerName, summonerName2 });
            Assert.IsNotNull(summonerDict);
            Assert.IsTrue(summonerDict.ContainsKey(summonerName));
            Assert.IsTrue(summonerDict.ContainsKey(summonerName2));
        }

        [TestMethod]
        public async Task TestSummonerClient_ById()
        {
            var version = "1.4";
            var summonerId = "20132258";
            var summonerId2 = "51405";
            var summonerClient = new SummonerClient(Region, version, this.apiKey);

            var summoner = await summonerClient.GetSummonerById(summonerId);
            Assert.IsNotNull(summoner);

            var summonerDict = await summonerClient.GetSummonerById(new List<string> { summonerId, summonerId2 });
            Assert.IsNotNull(summonerDict);
            Assert.IsTrue(summonerDict.ContainsKey(summonerId));
            Assert.IsTrue(summonerDict.ContainsKey(summonerId2));
        }

        [TestMethod]
        public async Task TestSummonerClient_SummonerMasteries()
        {
            var version = "1.4";
            var summonerId = "20132258";
            var summonerId2 = "51405";
            var summonerClient = new SummonerClient(Region, version, this.apiKey);

            var masteries = await summonerClient.GetSummonerMasteries(summonerId);
            Assert.IsNotNull(masteries);

            var masteriesDict = await summonerClient.GetSummonerMasteries(new List<string> { summonerId, summonerId2 });
            Assert.IsNotNull(masteriesDict);
            Assert.IsTrue(masteriesDict.ContainsKey(summonerId));
            Assert.IsTrue(masteriesDict.ContainsKey(summonerId2));
        }

        [TestMethod]
        public async Task TestSummonerClient_SummonerRunes()
        {
            var version = "1.4";
            var summonerId = "20132258";
            var summonerId2 = "51405";
            var summonerClient = new SummonerClient(Region, version, this.apiKey);

            var runes = await summonerClient.GetSummonerRunes(summonerId);
            Assert.IsNotNull(runes);

            var runesDict = await summonerClient.GetSummonerMasteries(new List<string> { summonerId, summonerId2 });
            Assert.IsNotNull(runesDict);
            Assert.IsTrue(runesDict.ContainsKey(summonerId));
            Assert.IsTrue(runesDict.ContainsKey(summonerId2));
        }

        [TestMethod]
        public async Task TestStaticDataClient()
        {
            var version = "1.2";
            var staticDataClient = new StaticDataClient(Region, version, this.apiKey);

            var masteries = await staticDataClient.GetMasteries();
            Assert.IsNotNull(masteries);

            var runes = await staticDataClient.GetRunes();
            Assert.IsNotNull(runes);
        }

        [TestMethod]
        public async Task TestMatchListClient()
        {
            var version = "2.2";
            var summonerId = "20132258";
            var client = new MatchListClient(Region, version, this.apiKey);

            var matchList = await client.GetMatchList(summonerId);
            Assert.IsNotNull(matchList);

            // Only get matches in the last week
            var beginTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(7));
            var endTime = DateTime.UtcNow;

            matchList = await client.GetMatchList(summonerId, beginTime, endTime);
            Assert.IsNotNull(matchList);

            foreach (var match in matchList.Matches)
            {
                // Check that all matches returned are less than 1 week old
                var matchDateTime = DateTimeUtils.FromUnixTimestamp(match.Timestamp.ToString());
                Assert.IsTrue(DateTime.UtcNow.Subtract(matchDateTime) < TimeSpan.FromDays(7));
            }
        }
    }
}
