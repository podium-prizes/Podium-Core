using Podium.Models.DbModels;

namespace Podium.Models.EndpointModels.UserManagement
{
    public class GetUserEndpointModel
    {
        public class RequestModel
        {
            public int TargetUserId { get; set; }
            public string Token { get; set; }
        }

        public class ResponseModel
        {
            public UserDbModel RequestedUserDetails { get; set; }
            
            public string Message { get; set; }
            public bool Status { get; set; }
        }
    }
}