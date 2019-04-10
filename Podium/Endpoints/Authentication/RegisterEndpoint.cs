using System;
using System.Linq;
using Podium.Models.DbModels;
using Podium.Models.EndpointModels.Authentication;
using BCrypt.Net;

namespace Podium.Endpoints.Authentication
{
    public class RegisterEndpoint
    {
        public static RegisterEndpointModels.ResponseModel EndpointMethod(PodiumContext db,
            RegisterEndpointModels.RequestModel req)
        {
            var res = new RegisterEndpointModels.ResponseModel();

            try
            {
                if (req.Firstname == "" || req.Lastname == "" || req.Username == "" || req.Email == "")
                {
                    throw new Exception("Registration failed: Some required data is missing");
                }
                else if (db.Users.Where(x => x.Username == req.Username).ToList().Count != 0)
                {
                    throw new Exception("Registration failed: Username is already in use");
                }
                else if (db.Users.Where(x => x.Email == req.Email).ToList().Count != 0)
                {
                    throw new Exception("Registration failed: Email is already in use");
                }
                // TODO: Use regex to ensure the email is actually an email
                // TODO: Password constr
                else
                {
                    db.Users.Add(new UserDbModel()
                    {
                        Firstname = req.Firstname,
                        Lastname = req.Lastname,
                        Username = req.Username,
                        Email = req.Email,
                        Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
                        CanLogin = true,
                        EmailIsVerified = false,
                        IsAdmin = false,
                        DateTimeCreated = DateTime.Now
                    });

                    // TODO: Send out the email verification email
                    
                    db.SaveChanges();

                    res.Status = true;
                    res.Message = "Registration successful for user " + req.Username;
                }
            }
            catch (Exception e)
            {
                res = new RegisterEndpointModels.ResponseModel()
                {
                    Message = e.Message,
                    Status = false
                };
            }

            return res;
        }
    }
}