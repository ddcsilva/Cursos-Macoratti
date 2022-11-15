using System.Data.Entity.Migrations;

namespace WebApiContatos.Migrations
{
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contatos",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Email = c.String(maxLength: 150),
                        Telefone = c.String(maxLength: 40),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContatoId)
                .ForeignKey("dbo.Enderecos", t => t.EnderecoId, cascadeDelete: true)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Local = c.String(maxLength: 150),
                        Cidade = c.String(maxLength: 100),
                        Estado = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contatos", "EnderecoId", "dbo.Enderecos");
            DropIndex("dbo.Contatos", new[] { "EnderecoId" });
            DropTable("dbo.Enderecos");
            DropTable("dbo.Contatos");
        }
    }
}
