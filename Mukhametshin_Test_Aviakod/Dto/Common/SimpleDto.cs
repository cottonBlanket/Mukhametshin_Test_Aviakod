using System.Text.Json.Serialization;

namespace Mukhametshin_Test_Aviakod.Dto.Common;

public class SimpleDto<T>
{
    [JsonPropertyName("data")]
    public T Data { get; init; }

    public SimpleDto(T data)
    {
        Data = data;
    }
}