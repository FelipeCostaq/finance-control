﻿using System.Text.Json.Serialization;

namespace finance.Core.Responses;

public class Response<TData>
{
    private int _code = Configuration.DefaultStatusCode;
    
    [JsonConstructor]
    public Response()
        => _code = Configuration.DefaultStatusCode;

    public Response(TData data, int code = Configuration.DefaultStatusCode, string? message = null)
    {
        Data = data;
        _code = code;
        Message = message;
    }
    
    public TData? Data { get; set; }
    public string? Message { get; set; }
    
    [JsonIgnore]
    public bool IsSucess => _code is >= 200 and <= 299;
}