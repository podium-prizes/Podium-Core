using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Podium.Models.DbModels;
using Podium.Models.EndpointModels.UserManagement;

namespace Podium.Endpoints.UserManagement
{
    public class AddUserEndpoint
    {
        public static AddUserEndpointModels.ResponseModel EndpointMethod(PodiumContext db,
            AddUserEndpointModels.RequestModel req)
        {
            var res = new AddUserEndpointModels.ResponseModel();

            try
            {
                if (!CommonTooling.CommonAuthenticationTools.CheckToken(db, req.Token))
                {
                    throw new Exception("Token is invalid");
                }
                else if (!CommonTooling.CommonAuthenticationTools.CheckAdmin(db, req.Token))
                {
                    throw new Exception("Request is not admin");
                }
                else if (db.Users.Where(x => x.Username == req.NewUserDetails.Username).ToList().Count != 0)
                {
                    throw new Exception("Username is already in use");
                }
                else if (db.Users.Where(x => x.Email == req.NewUserDetails.Email).ToList().Count != 0)
                {
                    throw new Exception("Email is already in use");
                }
                else
                {
                    db.Users.Add(new UserDbModel()
                    {
                        Firstname = req.NewUserDetails.Firstname == "" ? throw new Exception("Firstname is missing") : req.NewUserDetails.Firstname,
                        Lastname = req.NewUserDetails.Lastname == "" ? throw new Exception("Lastname is missing") : req.NewUserDetails.Lastname,
                        // TODO: Add regex to check email is actually an email
                        Email = req.NewUserDetails.Email == "" ? throw new Exception("Email is missing") : req.NewUserDetails.Email,
                        Username = req.NewUserDetails.Username == "" ? throw new Exception("Username is missing") : req.NewUserDetails.Username,
                        // TODO: add regex check to ensure password meets requirements
                        Password = req.NewUserDetails.Password == "" ? throw new Exception("Password is missing") : BCrypt.Net.BCrypt.HashPassword(req.NewUserDetails.Password),
                        IsAdmin = req.NewUserDetails.IsAdmin,
                        CanLogin = req.NewUserDetails.CanLogin,
                        DateTimeCreated = DateTime.Now,
                        EmailIsVerified = false
                    });

                    db.SaveChanges();

                    res.Status = true;
                    res.Message = "Successfully added new user " + req.NewUserDetails.Username;
                }
            }
            catch (Exception e)
            {
                res = new AddUserEndpointModels.ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }

            return res;
        }
    }
}