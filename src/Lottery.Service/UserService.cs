using Lottery.Core;
using Lottery.EntityFrameworkCore;
using Lottery.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Service
{
    public class UserService
    {
        private readonly OnLineDbContext context = new OnLineDbContext();

        public User GetUserByAccount(string account)
        {
            var user = context.User.SingleOrDefault(x => x.Account == account);

            return user;
        }

        public User Login(string account, string password)
        {
            var user = GetUserByAccount(account);

            if (user == null) return null;

            return HashHelper.Hash(password, user.Salt) == user.Password ? user : null;
        }

        public async Task<bool> Register(User user)
        {
            user.Password = HashHelper.Hash(user.Password, user.Salt);
            user.CardPassword = HashHelper.Hash(user.CardPassword, user.CardSalt);

            await context.User.AddAsync(user);

            return await context.SaveChangesAsync() > 0;
        }
    }
}
