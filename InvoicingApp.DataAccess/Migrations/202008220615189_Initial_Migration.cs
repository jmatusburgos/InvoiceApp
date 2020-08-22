namespace InvoicingApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Customer.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Address = c.String(),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Sales.InvoiceDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ProductId = c.Guid(nullable: false),
                        InvoiceId = c.Guid(nullable: false),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Sales.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("Production.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "Sales.Invoices",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CustomerId = c.Guid(nullable: false),
                        Code = c.String(),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Customer.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "Production.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ApplyTax = c.Boolean(nullable: false),
                        Code = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Sales.InvoiceDetails", "ProductId", "Production.Products");
            DropForeignKey("Sales.InvoiceDetails", "InvoiceId", "Sales.Invoices");
            DropForeignKey("Sales.Invoices", "CustomerId", "Customer.Customers");
            DropIndex("Sales.Invoices", new[] { "CustomerId" });
            DropIndex("Sales.InvoiceDetails", new[] { "InvoiceId" });
            DropIndex("Sales.InvoiceDetails", new[] { "ProductId" });
            DropTable("Production.Products");
            DropTable("Sales.Invoices");
            DropTable("Sales.InvoiceDetails");
            DropTable("Customer.Customers");
        }
    }
}
