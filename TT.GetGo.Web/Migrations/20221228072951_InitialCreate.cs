using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TT.GetGo.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarName = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Color = table.Column<string>(type: "TEXT", unicode: false, maxLength: 250, nullable: false),
                    NoPlate = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: false),
                    Rate = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedUTCDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedIP = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedUTCDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedIP = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortMessage = table.Column<string>(type: "TEXT", maxLength: 3000, nullable: false),
                    FullMessage = table.Column<string>(type: "TEXT", nullable: true),
                    LogLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PageUrl = table.Column<string>(type: "TEXT", unicode: false, maxLength: 3000, nullable: false),
                    ReferrerUrl = table.Column<string>(type: "TEXT", unicode: false, maxLength: 3000, nullable: false),
                    CreatedUTCDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false),
                    GeoX = table.Column<int>(type: "INTEGER", nullable: false),
                    GeoY = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedUTCDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedIP = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedUTCDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedIP = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GeoX = table.Column<int>(type: "INTEGER", nullable: false),
                    GeoY = table.Column<int>(type: "INTEGER", nullable: false),
                    isComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rate = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Hour = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedUTCDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedIP = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedUTCDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedIP = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "Brand", "CarName", "Color", "CreatedBy", "CreatedIP", "CreatedUTCDate", "Deleted", "Model", "NoPlate", "Rate", "Status", "UpdatedBy", "UpdatedIP", "UpdatedUTCDate" },
                values: new object[,]
                {
                    { 1, "ASTON MARTIN", "CarA", "Silver", 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(1012), false, "Cygnet Hatchback 2013", "ABC 1234", 1.2m, 1, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(1013) },
                    { 2, "Audi", "CarB", "Black", 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(1033), false, "Acura ILX Premium Sedan 2022", "DEF 8517", 1.7m, 1, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(1033) },
                    { 3, "BMW", "CarC", "Black", 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(1038), false, "BMW 2 Series Coupe 2022", "HIJ 1235", 1.9m, 1, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(1038) },
                    { 4, "BMW", "CarD", "Red", 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(1043), false, "BMW 2 Series M240i Coupe 2022", "KLM 3435", 2m, 1, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(1044) },
                    { 5, "LEXUS", "CarF", "White", 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(1047), false, "Lexus IS 300 Sedan 2022", "ZZZ 9999", 1.2m, 1, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(1048) }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "CarId", "CreatedBy", "CreatedIP", "CreatedUTCDate", "Deleted", "GeoX", "GeoY", "UpdatedBy", "UpdatedIP", "UpdatedUTCDate" },
                values: new object[,]
                {
                    { 1, 1, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(2892), false, 2, 3, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(2894) },
                    { 2, 2, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(2906), false, 1, 2, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(2906) },
                    { 3, 3, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(2910), false, 4, 5, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(2910) },
                    { 4, 4, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(2913), false, 5, 6, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(2914) },
                    { 5, 5, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(2916), false, 6, 7, 1, "127.0.0.1", new DateTime(2022, 12, 28, 7, 29, 51, 619, DateTimeKind.Utc).AddTicks(2917) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_CarId",
                table: "Location",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_CarId",
                table: "Records",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
