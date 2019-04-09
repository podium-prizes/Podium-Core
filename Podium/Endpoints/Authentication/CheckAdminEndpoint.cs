using System.Linq;

namespace Podium.Endpoints.Authentication
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Podium.Models.DbModels;
    using Podium.Models.EndpointModels.Authentication;
    
    public class CheckAdminEndpoint
    {
        public static CheckAdminEndpointModels.ResponseModel EndpointMethod(PodiumContext db,
            CheckAdminEndpointModels.RequestModel req)
        {
            var res = new CheckAdminEndpointModels.ResponseModel();

            try
            {
                var findToken = db.UserSessions
                    .Include(x => x.UserDetails).SingleOrDefault(x => x.SessionToken == req.Token && x.IsValid);

                if (findToken == null)
                {
                    throw new Exception("Token not valid");
                }
                else
                {
                    if (findToken.UserDetails.IsAdmin)
                    {
                        res.Message = "User is admin";
                        res.Status = true;
                    }
                    else
                    {
                        res.Message = "User is not admin";
                        res.Status = false;
                    }
                }
            }
            catch (Exception e)
            {
                res = new CheckAdminEndpointModels.ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }

            return res;
        }
    }
}