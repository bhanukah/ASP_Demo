namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemTypeValues : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (2, 30, 10, 1)");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (3, 90, 15, 3)");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (4, 300, 20, 12)");
        }

        public override void Down()
        {
        }
    }
}
