using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaplestoryOpenAPI
{
    [Serializable]
    public struct CubeHistoryDTO
    {
        [JsonInclude] public string id;
        [JsonInclude] public string character_name;
        [JsonInclude] public string create_date;
        [JsonInclude] public string cube_type;
        [JsonInclude] public string item_upgrade_result;
        [JsonInclude] public string miracle_time_flag;
        [JsonInclude] public string item_equip_part;
        [JsonInclude] public int item_level;
        [JsonInclude] public string target_item;
        [JsonInclude] public string potential_option_grade;
        [JsonInclude] public string additional_potential_option_grade;
        [JsonInclude] public List<CubeResultOptionDTO> before_potential_options;
        [JsonInclude] public List<CubeResultOptionDTO> before_additional_potential_options;
        [JsonInclude] public List<CubeResultOptionDTO> after_potential_options;
        [JsonInclude] public List<CubeResultOptionDTO> after_additional_potential_options;
    }
}
