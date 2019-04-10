using System;
using System.Linq;
using Podium.Models.DbModels;
using Podium.Models.EndpointModels.UserManagement;

namespace Podium.Endpoints.UserManagement
{
    public class ListUserEndpoint
    {
        public static ListUserEndpointModels.ResponseModel EndpointMethod(PodiumContext db, ListUserEndpointModels.RequestModel req)
        {
            var res = new ListUserEndpointModels.ResponseModel();

            try
            {
                if (!CommonTooling.CommonAuthenticationTools.CheckToken(db, req.Token))
                {
                    throw new Exception("token is invalid");
                }
                else if (!CommonTooling.CommonAuthenticationTools.CheckAdmin(db, req.Token))
                {
                    throw new Exception("Requester is not admin");
                }
                else
                {
                    res.UserListing = db.Users.ToList();

                    foreach (var x in res.UserListing)
                    {
                        // blank out the password
                        x.Password = string.Empty;
                    }

                    res.Status = true;
                    res.Message = "Successfully got list of users";
                }
            }
            catch (Exception e)
            {
                res = new ListUserEndpointModels.ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }

            return res;
        }
    }
}