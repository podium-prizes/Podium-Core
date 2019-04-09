using Microsoft.AspNetCore.Mvc;
using Podium.Endpoints.Authentication;
using Podium.Models.EndpointModels.Authentication;

namespace Podium.Controllers
{
    [Route("/api/authentication")]
    [ApiController]
    //[ProducesResponseType("application/json")]
    public class AuthenticationController : ControllerBase
    {
        PodiumContext _context;

        public AuthenticationController(PodiumContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginEndpointModels.ResponseModel> Login(LoginEndpointModels.RequestModel req)
        {
            return LoginEndpoint.EndpointMethod(_context, req);
        }

        [HttpPost]
        [Route("Logout")]
        public ActionResult<LogoutEndpointModels.ResponseModel> Logout(LogoutEndpointModels.RequestModel req)
        {
            return LogoutEndpoint.EndpointMethod(_context, req);
        }

        [HttpPost]
        [Route("CheckToken")]
        public ActionResult<CheckTokenEndpointModels.ResponseModel> CheckToken(
            CheckTokenEndpointModels.RequestModel req)
        {
            return CheckTokenEndpoint.EndpointMethod(_context, req);
        }

        [HttpPost]
        [Route("CheckAdmin")]
        public ActionResult<CheckAdminEndpointModels.ResponseModel> CheckAdmin(
            CheckAdminEndpointModels.RequestModel req)
        {
            return CheckAdminEndpoint.EndpointMethod(_context, req);
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult<RegisterEndpointModels.ResponseModel> Register(RegisterEndpointModels.RequestModel req)
        {
            return RegisterEndpoint.EndpointMethod(_context, req);
        }
    }
}