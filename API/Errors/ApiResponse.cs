using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }


        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad Request, you have made",
                401 => "Authorized, you are not",
                403 => "Forbidden Access",
                404 => "Resource found, it was not",
                500 => "Erro are the path to the dark side. Errror lead to angger. Anger leads to hate. Hate leads to career change",
                _ => null
            };
        }


    }
}