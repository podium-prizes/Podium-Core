using System.Linq;

namespace Podium.Endpoints.Authentication
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Podium.Models.DbModels;
    using Podium.Models.EndpointModels.Authentication;
    public class CheckTokenEndpoint
    {
        public static CheckTokenEndpointModels.ResponseModel EndpointMethod(PodiumContext db,
            CheckTokenEndpointModels.RequestModel req)
        {
            var res = new CheckTokenEndpointModels.ResponseModel();

            try
            {
                var findToken = db.UserSessions.Include(x => x.UserDetails)
                    .SingleOrDefault(x => x.SessionToken == req.Token && x.IsValid);

                if (findToken == null)
                {
                    throw new Exception("Unable to find token");
                }
                else
                {
                    if (findToken.IsValid)
                    {
                        res.Message = "Token is valid";
                        res.Status = true;
                    }
                    else
                    {
                        res.Message = "Token is invalid";
                        res.Status = false;
                    }
                }
            }
            catch (Exception e)
            {
                res = new CheckTokenEndpointModels.ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }

            return res;
        }
    }
}