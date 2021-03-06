﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Dto.StaticData.Champion
{
    [JsonObject]
    public class SpellVarsDto
    {
        [JsonProperty]
        public List<double> Coeff { get; set; }

        [JsonProperty]
        public string Dyn { get; set; }

        [JsonProperty]
        public string Key { get; set; }

        [JsonProperty]
        public string Link { get; set; }

        [JsonProperty]
        public string RanksWith { get; set; }
    }
}
