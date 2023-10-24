using IdentityServer.Models;

namespace IdentityServer.Data
{
    public class DbInitializer
    {
        public static void Initialize(AuthDbContext context)
        {
            context.Database.EnsureCreated();

            //context.Users.Add(new AppUser
            //{
            //    UserName = "gorohov",
            //    Email = "gorohov@mail.ru",
            //    D
            //})
        }
    }
}
