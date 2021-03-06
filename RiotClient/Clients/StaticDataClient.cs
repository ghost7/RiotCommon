﻿using CoffeeCat.RiotCommon.Dto.StaticData.Champion;
using CoffeeCat.RiotCommon.Dto.StaticData.Mastery;
using CoffeeCat.RiotCommon.Dto.StaticData.Rune;
using CoffeeCat.RiotCommon.Utils;
using System.Threading.Tasks;

namespace CoffeeCat.RiotClient.Clients
{
    public class StaticDataClient : BaseClient
    {
        public string Version { get; private set; }

        public StaticDataClient(string region, string version, string apiKey)
          : base(region, apiKey)
        {
            Validation.ValidateNotNull(version, nameof(version));
            this.Version = version;
        }

        public Task<MasteryListDto> GetMasteries()
        {
            var uri = this.EndpointFactory.GetMasteriesUri(this.Version);
            return this.DownloadRiotData<MasteryListDto>(uri);
        }

        public Task<RuneListDto> GetRunes()
        {
            var uri = this.EndpointFactory.GetRunesUri(this.Version);
            return this.DownloadRiotData<RuneListDto>(uri);
        }

        public Task<ChampionListDto> GetChampions()
        {
            var uri = this.EndpointFactory.GetChampionsUri(this.Version);
            return this.DownloadRiotData<ChampionListDto>(uri);
        }
    }
}
