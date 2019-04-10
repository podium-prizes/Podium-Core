using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Podium.Models.EndpointModels.UserManagement;

namespace Podium.Endpoints.UserManagement
{
    public class DeleteUserEndpoint
    {
        public static DeleteUserEndpointModels.ResponseModel EndpointMethod(PodiumContext db,
            DeleteUserEndpointModels.RequestModel req)
        {
            var res = new DeleteUserEndpointModels.ResponseModel();

            try
            {
                if (!CommonTooling.CommonAuthenticationTools.CheckAdmin(db, req.Token))
                {
                    throw new Exception("Requester is not admin");
                }
                else if (!CommonTooling.CommonAuthenticationTools.CheckToken(db, req.Token))
                {
                    throw new Exception("Token is invalid");
                }
                else if (db.UserSessions.Include(x => x.UserDetails).Where(x => x.UserId == req.TargetUserId).ToList()
                        .Count != 0)
                {
                    throw new Exception("You can't delete yourself");
                }
                else
                {
                    db.Users.Remove(db.Users.Single(x => x.UserId == req.TargetUserId));
                    db.SaveChanges();

                    res.Status = true;
                    res.Message = "Successfully deleted user " + req.TargetUserId.ToString();
                }
            }
            catch (Exception e)
            {
                res = new DeleteUserEndpointModels.ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }

            return res;
        }
    }
}