using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSS.Migrations
{
    /// <inheritdoc />
    public partial class seedServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Servico (Dtini, Dtfim, Descricao, Usuario_Id, Tiposervico_Id, Status_Id) VALUES ('2023-07-22', '2004-07-26', 'Manutenção de servidor', 2, 1, 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
