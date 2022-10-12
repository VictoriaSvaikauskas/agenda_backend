using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaAPI.Migrations
{
    public partial class One : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CelularNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    TelephoneNumber = table.Column<long>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 1, "anabraconi@gmail.com", "Braconi", "Ana", "Pa$$word", "anita" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 2, "ceciliatorres@gmail.com", "Tosto", "Cecilia", "contraseñadificil", "ceciT" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CelularNumber", "Description", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 1, 3412347689L, "Amiga", "Emilia", null, 1 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CelularNumber", "Description", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 2, 3412347665L, "Hermano", "Juan Cruz", null, 2 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CelularNumber", "Description", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 3, 3410847665L, "Papa", "Gustavo", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
