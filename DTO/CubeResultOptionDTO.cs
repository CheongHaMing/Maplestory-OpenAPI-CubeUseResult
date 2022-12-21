using System;
using System.Text.Json.Serialization;

namespace MaplestoryOpenAPI
{
    [Serializable]
    public struct CubeResultOptionDTO
    {
        [JsonInclude] public string value;
        [JsonInclude] public string grade;
    }
}
