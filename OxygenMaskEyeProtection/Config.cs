using Newtonsoft.Json;
using PeterHan.PLib.Options;
using System;

namespace ONI_Mod_Oxygen_Mask
{
    [JsonObject(MemberSerialization.OptIn)]
    [RestartRequired]
    public class Config : SingletonOptions<Config>
    {
        [Option("StoreCO2")]
        [JsonProperty]
        public bool StoreCO2 { get; set; }
        
        public Config()
        {
            StoreCO2 = true;
        }

    }
}