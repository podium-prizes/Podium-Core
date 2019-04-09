namespace Podium.Models.EndpointModels.UserManagement
{
    public class DeleteUserEndpointModels
    {
        public class RequestModel
        {
            public int TargetUserId { get; set; }
            public string Token { get; set; }
        }

        public class ResponseModel
        {
            public string Message { get; set; }
            public bool Status { get; set; }
        }
    }
}