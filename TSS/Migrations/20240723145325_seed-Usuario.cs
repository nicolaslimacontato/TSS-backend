using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSS.Migrations
{
    /// <inheritdoc />
    public partial class seedUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Usuario (Nome,Email,Senha,Dtnasc,CPF_CNPJ,Telefone,Tipousuario_Id,Plano_Id) VALUES ('Beatriz Laurentino','beatino@gmail.com','meowmeow','2004-07-26','256.894.312-57','(11)98720-5391',1,1), ('Jacinto Pinto ','japinto@gmail.com','broxinha','1984-08-17','144.234.442-52','(11)4002-8922',1,1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
