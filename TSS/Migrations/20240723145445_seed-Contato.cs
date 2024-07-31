using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSS.Migrations
{
    /// <inheritdoc />
    public partial class seedContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Contato] ([Nome], [Email], [Telefone], [Tipocontato_Id], [Mensagem], [Usuario_Id]) VALUES ('Jasinto', 'jasinto@example.com', '(11)98765-4321', 1, 'Olá, preciso de ajuda com meu sistema.', 2 );");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
