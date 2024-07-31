using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSS.Migrations
{
    /// <inheritdoc />
    public partial class seedTipoServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Tiposervico (Nome) VALUES ('Remoto'), ('Técnico'), ('Plano'), ('Outros') ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
