namespace Podium.Models.EndpointModels.Authentication
{
    public class LoginEndpointModels
    {
        public class RequestModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class ResponseModel
        {
            public string Token { get; set; }
            
            public string Message { get; set; }
            public bool Status { get; set; }
        }
    }
}