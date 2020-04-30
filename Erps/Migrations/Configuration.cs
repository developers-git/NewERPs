namespace Erps.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Erps.DAO.SBoardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Erps.DAO.SBoardContext context)
        {

            context.Database.ExecuteSqlCommand("DROP PROCEDURE IF EXISTS [dbo].[NewAccounts]");
            context.Database.ExecuteSqlCommand("DROP PROCEDURE IF EXISTS [dbo].[NewAccountsAuth]");
            //context.Database.ExecuteSqlCommand(my.newaccount());
            //context.Database.ExecuteSqlCommand(my.newaccountAuth());

        }

    }

}

