using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSS.Migrations
{
    /// <inheritdoc />
    public partial class seedPlano : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Plano (Nome,Descricao,Preco,Tipoplano_Id) VALUES ('Null','Null','Null',1), ('Basic','Inclui diagnóstico, reparo e manutenção de hardware e software em computadores.','R$200.00',2),('Standard','Inclui diagnóstico, reparo e manutenção de hardware, software em computadores e servidores.','R$400.00',3),('Premium','Inclui diagnóstico, reparo e manutenção de hardware, software em computadores, servidores e web','R$800.00',4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
