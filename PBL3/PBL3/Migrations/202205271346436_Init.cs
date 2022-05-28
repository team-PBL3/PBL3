namespace PBL3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Roles",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    value = c.String(unicode: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.People",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(unicode: false),
                    sex = c.String(unicode: false),
                    phone = c.Int(nullable: false),
                    address = c.String(unicode: false),
                    email = c.String(unicode: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(unicode: false),
                    partofbody = c.String(unicode: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.TradeMarks",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(unicode: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, unicode: false),
                        sex = c.String(nullable: false, unicode: false),
                        phone = c.String(nullable: false, unicode: false),
                        address = c.String(nullable: false, unicode: false),
                        username = c.String(nullable: false, unicode: false),
                        email = c.String(nullable: false, unicode: false),
                        password = c.String(nullable: false, unicode: false),
                        status = c.String(unicode: false),
                        roleid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Roles", t => t.roleid, cascadeDelete: true)
                .Index(t => t.roleid, anonymousArguments: new { Type = "BTrees" });

            CreateTable(
                "dbo.Carts",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    quantityBuy = c.Int(nullable: false),
                    user_id = c.Int(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => t.user_id, anonymousArguments: new { Type = "BTrees" });

            CreateTable(
                "dbo.Orderrs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        status = c.String(unicode: false),
                        userid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid, anonymousArguments: new { Type = "BTrees" });
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        categoryid = c.Int(nullable: false),
                        trademarkid = c.Int(nullable: false),
                        description = c.String(unicode: false),
                        price = c.Double(nullable: false),
                        status = c.String(unicode: false),
                        infoproduct = c.String(unicode: false),
                        quantityremain = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.categoryid, cascadeDelete: true)
                .ForeignKey("dbo.TradeMarks", t => t.trademarkid, cascadeDelete: true)
                .Index(t => t.categoryid, anonymousArguments: new { Type = "BTrees" })
                .Index(t => t.trademarkid, anonymousArguments: new { Type = "BTrees" });

            CreateTable(
                "dbo.Orderdetails",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(unicode: false),
                    price = c.Double(nullable: false),
                    quantity = c.Int(nullable: false),
                    orderid = c.Int(nullable: false),
                    productid = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orderrs", t => t.orderid, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productid, cascadeDelete: true)
                .Index(t => t.orderid, anonymousArguments: new { Type = "BTrees" })
                .Index(t => t.productid, anonymousArguments: new { Type = "BTrees" });

            CreateTable(
                "dbo.CartDetails",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    cartid = c.Int(nullable: false),
                    productid = c.Int(nullable: false),
                    quantitybuy = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Carts", t => t.cartid, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productid, cascadeDelete: true)
                .Index(t => t.cartid, anonymousArguments: new { Type = "BTrees" })
                .Index(t => t.productid, anonymousArguments: new { Type = "BTrees" });

            CreateTable(
                "dbo.Images",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        productid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.productid, cascadeDelete: true)
                .Index(t => t.productid, anonymousArguments: new { Type = "BTrees" });
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        paymentdate = c.DateTime(nullable: false, precision: 0),
                        amount = c.Int(nullable: false),
                        totalPrice = c.Double(nullable: false),
                        orderid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orderrs", t => t.orderid, cascadeDelete: true)
                .Index(t => t.orderid, anonymousArguments: new { Type = "BTrees" });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "roleid", "dbo.Roles");
            DropForeignKey("dbo.Orderrs", "userid", "dbo.Users");
            DropForeignKey("dbo.Payments", "orderid", "dbo.Orderrs");
            DropForeignKey("dbo.Products", "trademarkid", "dbo.TradeMarks");
            DropForeignKey("dbo.Orderdetails", "productid", "dbo.Products");
            DropForeignKey("dbo.Images", "productid", "dbo.Products");
            DropForeignKey("dbo.Products", "categoryid", "dbo.Categories");
            DropForeignKey("dbo.CartDetails", "productid", "dbo.Products");
            DropForeignKey("dbo.Orderdetails", "orderid", "dbo.Orderrs");
            DropForeignKey("dbo.Carts", "user_id", "dbo.Users");
            DropForeignKey("dbo.CartDetails", "cartid", "dbo.Carts");
            DropIndex("dbo.Payments", new[] { "orderid" });
            DropIndex("dbo.Images", new[] { "productid" });
            DropIndex("dbo.Products", new[] { "trademarkid" });
            DropIndex("dbo.Products", new[] { "categoryid" });
            DropIndex("dbo.Orderdetails", new[] { "productid" });
            DropIndex("dbo.Orderdetails", new[] { "orderid" });
            DropIndex("dbo.Orderrs", new[] { "userid" });
            DropIndex("dbo.Users", new[] { "roleid" });
            DropIndex("dbo.Carts", new[] { "user_id" });
            DropIndex("dbo.CartDetails", new[] { "productid" });
            DropIndex("dbo.CartDetails", new[] { "cartid" });
            DropTable("dbo.People");
            DropTable("dbo.Roles");
            DropTable("dbo.Payments");
            DropTable("dbo.TradeMarks");
            DropTable("dbo.Images");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Orderdetails");
            DropTable("dbo.Orderrs");
            DropTable("dbo.Users");
            DropTable("dbo.Carts");
            DropTable("dbo.CartDetails");
        }
    }
}
