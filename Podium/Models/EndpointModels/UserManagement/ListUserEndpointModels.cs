using System.Collections.Generic;
using Podium.Models.DbModels;

namespace Podium.Models.EndpointModels.UserManagement
{
    public class ListUserEndpointModels
    {
        public class RequestModel
        {
            public string Token { get; set; }
        }

        public class ResponseModel
        {
            public List<UserDbModel> UserListing { get; set; }
            
            public string Message { get; set; }
            public bool Status { get; set; }
        }
    }
}