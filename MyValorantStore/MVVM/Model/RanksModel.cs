using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyValorantStore.MVVM.Model
{
    public partial class RanksModel
    {
        [JsonProperty("actId")]
        public Guid ActId { get; set; }

        [JsonProperty("players")]
        public Player[] Players { get; set; }

        [JsonProperty("totalPlayers")]
        public long TotalPlayers { get; set; }

        [JsonProperty("immortalStartingPage")]
        public long ImmortalStartingPage { get; set; }

        [JsonProperty("immortalStartingIndex")]
        public long ImmortalStartingIndex { get; set; }

        [JsonProperty("topTierRRThreshold")]
        public long TopTierRrThreshold { get; set; }

        [JsonProperty("tierDetails")]
        public Dictionary<string, TierDetail> TierDetails { get; set; }

        [JsonProperty("startIndex")]
        public long StartIndex { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("shard")]
        public string Shard { get; set; }
    }

    public partial class Player
    {
        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("tagLine")]
        public string TagLine { get; set; }

        [JsonProperty("leaderboardRank")]
        public long LeaderboardRank { get; set; }

        [JsonProperty("rankedRating")]
        public long RankedRating { get; set; }

        [JsonProperty("numberOfWins")]
        public long NumberOfWins { get; set; }

        [JsonProperty("competitiveTier")]
        public long CompetitiveTier { get; set; }
    }

    public partial class TierDetail
    {
        [JsonProperty("rankedRatingThreshold")]
        public long RankedRatingThreshold { get; set; }

        [JsonProperty("startingPage")]
        public long StartingPage { get; set; }

        [JsonProperty("startingIndex")]
        public long StartingIndex { get; set; }
    }
}
