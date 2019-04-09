using Podium.Models.DbModels;

namespace Podium.Models.EndpointModels.UserManagement
{
    public class UpdateUserEndpointModels
    {
        public class RequestModel
        {
            public UserDbModel UpdatedUser { get; set; }
            
            public string Token { get; set; }
        }

        public class ResponseModel
        {
            public string Message { get; set; }
            public bool Status { get; set; }
        }
    }
}