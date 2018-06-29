using Lottery.Core;
using Lottery.EntityFrameworkCore;
using Lottery.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Service
{
    public class AdministratorsService
    {
        private readonly OnLineDbContext context = new OnLineDbContext();

        public Administrators GetUserByAccount(string account)
        {
            var admin = context.Administrators.SingleOrDefault(x => x.Account == account);

            return admin;
        }

        public Administrators Login(string account, string password)
        {
            var user = GetUserByAccount(account);

            if (user == null) return null;

            return HashHelper.Hash(password, user.Salt) == user.Password ? user : null;
        }

        public async Task<bool> Register(Administrators admin)
        {
            admin.Password = HashHelper.Hash(admin.Password, admin.Salt);

            await context.Administrators.AddAsync(admin);

            return await context.SaveChangesAsync() > 0;
        }
    }
}
