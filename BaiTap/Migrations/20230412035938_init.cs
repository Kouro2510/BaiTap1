using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTap.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sach_tbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TacGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTien = table.Column<double>(type: "float", nullable: false),
                    NhaXuatBan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach_tbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien_tbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSinhVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MSSV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien_tbl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SinhVienSach_tbl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSach = table.Column<int>(type: "int", nullable: false),
                    IDSinhVien = table.Column<int>(type: "int", nullable: false),
                    NgayMuonSach = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVienSach_tbl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SinhVienSach_tbl_Sach_tbl_IDSach",
                        column: x => x.IDSach,
                        principalTable: "Sach_tbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SinhVienSach_tbl_SinhVien_tbl_IDSinhVien",
                        column: x => x.IDSinhVien,
                        principalTable: "SinhVien_tbl",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienSach_tbl_IDSach",
                table: "SinhVienSach_tbl",
                column: "IDSach");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVienSach_tbl_IDSinhVien",
                table: "SinhVienSach_tbl",
                column: "IDSinhVien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhVienSach_tbl");

            migrationBuilder.DropTable(
                name: "Sach_tbl");

            migrationBuilder.DropTable(
                name: "SinhVien_tbl");
        }
    }
}
