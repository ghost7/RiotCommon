using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Rune
{
    [JsonObject]
    public class RuneDto
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public MetaDataDto Rune { get; set; }
    }
}
