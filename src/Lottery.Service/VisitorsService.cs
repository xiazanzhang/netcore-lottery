using Lottery.EntityFrameworkCore;
using Lottery.Model;
using System;
using System.Threading.Tasks;

namespace Lottery.Service
{
    public class VisitorsService
    {
        private readonly OnLineDbContext context = new OnLineDbContext();

        public async Task<bool> Created()
        {
            var model = new Visitors
            {
                Uid = Guid.NewGuid()
            };

            await context.Visitors.AddAsync(model);

            return await context.SaveChangesAsync() > 1;
        }
    }
}
