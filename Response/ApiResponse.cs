﻿namespace chatgpt4api.Response
{

    public class ApiResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
    public class ApiResponse<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
    }
}
