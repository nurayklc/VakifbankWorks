﻿namespace NLayeredAPI.Base.Response
{
    public class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public List<string> Message { get; private set; }
        public T Response { get; private set; }

        public BaseResponse(bool isSuccess)
        {
            Response = default;
            Success = isSuccess;
            Message = isSuccess ? new List<string>() { "Success" } : new List<string>() { "Fault" };
        }

        public BaseResponse(T resource)
        {
            Success = true;
            Message = new List<string>() { "Success" };
            Response = resource;
        }

        public BaseResponse(string message)
        {
            Response = default;
            Success = false;
            if (!string.IsNullOrEmpty(message))
            {
                Message = new List<string>() { message };
            }
        }

        public BaseResponse(List<string> messages)
        {
            Success = false;
            Response = default;
            Message = messages ?? new List<string>() { "Fault" };
        }
    }
}
