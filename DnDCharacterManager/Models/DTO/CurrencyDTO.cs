using DnDCharacterManager.Models.Wrapper;
using Newtonsoft.Json;

namespace DnDCharacterManager.Models.DTO
{
    public class CurrencyDTO
    {
        public int Id { get; set; }
        [JsonProperty("cp")]
        public int Copper { get; set; }
        [JsonProperty("sp")]
        public int Silver { get; set; }
        [JsonProperty("gp")]
        public int Gold { get; set; }
        [JsonProperty("ep")]
        public int Electrum { get; set; }
        [JsonProperty("pp")]
        public int Platin { get; set; }

    }
}
