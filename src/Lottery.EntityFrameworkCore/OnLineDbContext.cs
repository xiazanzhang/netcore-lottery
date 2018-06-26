using Lottery.Model;
using Microsoft.EntityFrameworkCore;

namespace Lottery.EntityFrameworkCore
{
    public class OnLineDbContext : DbContext
    {
        //打开 PMC：
        //“工具”–>“NuGet 包管理器”–>“包管理器控制台”
        //运行 Add-Migration InitialCreate 来为迁移搭建基架，从而为模型创建一组初始表。 如果收到错误，指出 The term 'add-migration' is not recognized as the name of a cmdlet，请关闭并重新打开 Visual Studio。
        //运行 Update-Database 以将新迁移应用到数据库。 在应用迁移之前，此命令可创建数据库。

        public DbSet<User> User { get; set; }

        public DbSet<Visitors> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Data Source=120.78.143.42;Initial Catalog=lottery_db;User ID=sa;Password=Xzz306556182");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Account)
                .HasName("AlternateKey_Account");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Account)
                .HasName("Index_Account");
        }

    }
}
