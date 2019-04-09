namespace Podium.Models.EndpointModels.Authentication
{
    public class CheckTokenEndpointModels
    {
        public class RequestModel
        {
            public string Token { get; set; }
        }

        public class ResponseModel
        {
            public string Message { get; set; }
            public bool Status { get; set; }
        }
    }
}