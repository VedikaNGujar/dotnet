﻿namespace Mango.Services.ProductAPI.Models.Dto
{
    public class ResponseDto
    {
        //public T? Result { get; set; }
        public object Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
