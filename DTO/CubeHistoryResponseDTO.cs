using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaplestoryOpenAPI
{
    [Serializable]
    public struct CubeHistoryResponseDTO
    {
        [JsonInclude] public int count;
        [JsonInclude] public List<CubeHistoryDTO> cube_histories;
        [JsonInclude] public string next_cursor;
    }
}
