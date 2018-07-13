using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace learnapp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    House = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTag_Projects_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AddressId", "Department", "FirstName", "Function", "LastName" },
                values: new object[] { new Guid("fafa34af-1325-4310-bf83-8c1379f0019d"), null, "Estonian", "Vaidas", "Developer", "Brazionis" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AddressId", "Department", "FirstName", "Function", "LastName" },
                values: new object[] { new Guid("287a58ad-aa56-4eb8-a18c-4dae14cfee72"), null, "Design", "Jonas", "Manager", "Paulauskas" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AddressId", "Department", "FirstName", "Function", "LastName" },
                values: new object[] { new Guid("45f60630-4255-4153-9079-98e8323c4034"), null, "Design", "Domas", "Web designer", "Zemaitis" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AddressId", "Department", "FirstName", "Function", "LastName" },
                values: new object[] { new Guid("b434ecd3-3b13-4fd6-afcd-fc49ed1eb44f"), null, "Sales", "Sima", "Manager", "Siniavskaja" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AddressId", "Department", "FirstName", "Function", "LastName" },
                values: new object[] { new Guid("552740d6-05f6-481e-9e3d-76bb938aa21b"), null, "Sales", "Algimantas", "Sales support", "Jonauskas" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AddressId", "Department", "FirstName", "Function", "LastName" },
                values: new object[] { new Guid("a3b1906d-7bdf-41f2-8132-35b56ef3f8b3"), null, "Lithuanian", "Algis", "Developer", "Ramanauskas" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ProjectId", "Title" },
                values: new object[] { new Guid("9583be43-a77d-4301-bf2c-e5856d6ab678"), "001", "Resmap dev" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ProjectId", "Title" },
                values: new object[] { new Guid("9c61b8dd-9dfd-4ac1-93c0-93147283a053"), "002", "Web design" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ProjectId", "Title" },
                values: new object[] { new Guid("eb98ea74-1971-4275-8d64-3a95f476a0dc"), "003", "Azure impl" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Title" },
                values: new object[] { new Guid("c22e3f0b-ff39-481f-8f69-354d0282042a"), "Web" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Title" },
                values: new object[] { new Guid("644a70dc-565d-4942-8c5b-dc4e04a77c98"), "Front-end" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Title" },
                values: new object[] { new Guid("bcd6801a-3aaf-47ad-8700-4bb24630ce18"), "Back-end" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Title" },
                values: new object[] { new Guid("375e3f64-34dc-484d-b066-be1139156745"), "Design" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Title" },
                values: new object[] { new Guid("c7dc2b71-ae9e-477a-867b-745eaa676824"), "C#" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Title" },
                values: new object[] { new Guid("968bc481-63c9-43c9-ba4a-fe94b4869726"), "JavaScript" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Title" },
                values: new object[] { new Guid("420e0f74-7602-4e61-975c-9f9146301469"), "Java" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTag_ResourceId",
                table: "ProjectTag",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTag_TagId",
                table: "ProjectTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProjectTag");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
