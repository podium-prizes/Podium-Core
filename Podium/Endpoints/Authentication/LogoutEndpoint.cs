using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Podium.Models.EndpointModels.Authentication;

namespace Podium.Endpoints.Authentication
{
    public class LogoutEndpoint
    {
        public static LogoutEndpointModels.ResponseModel EndpointMethod(PodiumContext db,
            LogoutEndpointModels.RequestModel req)
        {
            var res = new LogoutEndpointModels.ResponseModel();

            try
            {
                var findToken = db.UserSessions.Include(x => x.UserDetails)
                    .SingleOrDefault(x => x.SessionToken == req.Token && x.IsValid);

                if (findToken == null)
                {
                    throw new Exception("Token not found or is invalid");
                }
                else
                {
                    findToken.IsValid = false;
                    findToken.LogoutDateTime = DateTime.Now;

                    db.SaveChanges();

                    res.Status = true;
                    res.Message = "Logout successful for user " + findToken.UserDetails.Username;
                }
            }
            catch (Exception e)
            {
                res = new LogoutEndpointModels.ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }

            return res;
        }
    }
}