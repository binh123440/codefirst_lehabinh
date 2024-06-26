﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace codefirst_lehabinh.data_access.migrations
{
    /// <inheritdoc />
    public partial class codefirstlehabinh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    KhoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.KhoaId);
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    LopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.LopId);
                    table.ForeignKey(
                        name: "FK_Lop_Khoa_KhoaId",
                        column: x => x.KhoaId,
                        principalTable: "Khoa",
                        principalColumn: "KhoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    SinhVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    LopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.SinhVienId);
                    table.ForeignKey(
                        name: "FK_SinhVien_Lop_LopId",
                        column: x => x.LopId,
                        principalTable: "Lop",
                        principalColumn: "LopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Khoa",
                columns: new[] { "KhoaId", "TenKhoa" },
                values: new object[,]
                {
                    { 1, "Cong nghe so" },
                    { 2, "Dien - Dien tu" },
                    { 3, "Xay dung" }
                });

            migrationBuilder.InsertData(
                table: "Lop",
                columns: new[] { "LopId", "KhoaId", "TenLop" },
                values: new object[,]
                {
                    { 1, 1, "LTC01" },
                    { 2, 3, "VKT01" },
                    { 3, 2, "KTĐ01" }
                });

            migrationBuilder.InsertData(
                table: "SinhVien",
                columns: new[] { "SinhVienId", "LopId", "Ten", "Tuoi" },
                values: new object[,]
                {
                    { 1, 1, "Le Ha Binh", 19 },
                    { 2, 1, "Le Ha Binh 2", 20 },
                    { 3, 1, "Le Ha Binh 3", 28 },
                    { 4, 1, "Le Ha Binh 4", 22 },
                    { 5, 1, "Le Ha Binh 5", 18 },
                    { 6, 1, "Le Ha Binh 6", 19 },
                    { 7, 1, "Le Ha Binh 7", 20 },
                    { 8, 2, "Le Ha Binh 8", 20 },
                    { 9, 3, "Le Ha Binh 3", 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lop_KhoaId",
                table: "Lop",
                column: "KhoaId");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_LopId",
                table: "SinhVien",
                column: "LopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
