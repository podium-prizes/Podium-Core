namespace Podium.Models.EndpointModels.Authentication
{
    public class RegisterEndpointModels
    {
        public class RequestModel
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class ResponseModel
        {
            public string Message { get; set; }
            public bool Status { get; set; }
        }
    }
}