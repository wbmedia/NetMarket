using System;
namespace WebApi.Errors
{
	public class CodeErrorResponse
	{
		public CodeErrorResponse(int statusCode, string message = null)
		{
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessageStatusCode(statusCode);
		}

		private string GetDefaultMessageStatusCode(int statusCode)
        {
			return statusCode switch
            {
                400 => "Request Send has Errors.",
                401 => "No Authorized Request for this resource. unauthenticated Error.",
				403 => "Forbidden The client does not have access rights to the content",
				404 => "Resource or Item Not Fond.",
				405 => "Method Not Allowed",
                500 => "Server Configuration Erros Found. Internal Server Error",
                _ => throw new NotImplementedException(),
            };
        }

		public int StatusCode { get; set; }
		public string Message { get; set; }
	}
}

