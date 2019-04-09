using System.Linq;

namespace Podium.Endpoints.Authentication
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Podium.Models.DbModels;
    using Podium.Models.EndpointModels.Authentication;
    using BCrypt.Net;
 
    public class LoginEndpoint
    {
        public static LoginEndpointModels.ResponseModel EndpointMethod(PodiumContext db,
            LoginEndpointModels.RequestModel req)
        {
            var res = new LoginEndpointModels.ResponseModel();

            try
            {
                var findUser = db.Users.Include(x => x.UserSessionList).SingleOrDefault(x =>
                    x.Username == req.Username && BCrypt.Verify(req.Password, x.Password) && x.CanLogin);

                if (findUser == null)
                {
                    throw new Exception("Login failed");
                }
                else
                {
                    res.Token = Guid.NewGuid().ToString().Replace("-", "");
                    
                    findUser.UserSessionList.Add(new UserSessionDbModel()
                    {
                        SessionToken = res.Token,
                        IsValid = true,
                        LoginDateTime = DateTime.Now,
                        HasExpiry = false,
                        HasExpired = false
                    });

                    db.SaveChanges();

                    res.Message = "Login successful for user " + findUser.Username;
                    res.Status = true;
                }
            }
            catch (Exception e)
            {
                res = new LoginEndpointModels.ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }

            return res;
        }
    }
}