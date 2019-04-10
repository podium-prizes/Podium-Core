using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Podium.CommonTooling
{
    public class CommonAuthenticationTools
    {
        public static bool CheckToken(PodiumContext db, string token)
        {
            var findToken = db.UserSessions.SingleOrDefault(x => x.SessionToken == token && x.IsValid);

            return findToken != null;
        }

        public static bool CheckAdmin(PodiumContext db, string token)
        {
            var findToken = db.UserSessions.Include(x => x.UserDetails)
                .SingleOrDefault(x => x.SessionToken == token && x.IsValid && x.UserDetails.IsAdmin);

            return findToken != null;
        }
    }
}