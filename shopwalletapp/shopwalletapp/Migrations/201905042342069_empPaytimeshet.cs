namespace shopwalletapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empPaytimeshet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payrolls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        PayrollDate = c.DateTime(nullable: false),
                        PayAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Timesheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ManagerId = c.Int(),
                        Date = c.DateTime(nullable: false),
                        Hours = c.Double(nullable: false),
                        HourlyRate = c.Double(nullable: false),
                        TaskDescId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ManagerId)
                .ForeignKey("dbo.TaskDescs", t => t.TaskDescId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ManagerId)
                .Index(t => t.TaskDescId);
            
            CreateTable(
                "dbo.TaskDescs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timesheets", "TaskDescId", "dbo.TaskDescs");
            DropForeignKey("dbo.Timesheets", "ManagerId", "dbo.Employees");
            DropForeignKey("dbo.Timesheets", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Payrolls", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Timesheets", new[] { "TaskDescId" });
            DropIndex("dbo.Timesheets", new[] { "ManagerId" });
            DropIndex("dbo.Timesheets", new[] { "EmployeeId" });
            DropIndex("dbo.Payrolls", new[] { "EmployeeId" });
            DropTable("dbo.TaskDescs");
            DropTable("dbo.Timesheets");
            DropTable("dbo.Payrolls");
            DropTable("dbo.Employees");
        }
    }
}
