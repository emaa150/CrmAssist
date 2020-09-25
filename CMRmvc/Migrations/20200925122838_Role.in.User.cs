using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMRmvc.Migrations
{
    public partial class RoleinUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreCompleto",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dni",
                table: "AspNetUsers",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RoleID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<long>(nullable: false),
            //        RoleId = table.Column<long>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "MenuItemPadre",
                columns: table => new
                {
                    IdMenuPadre = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: true),
                    Icono = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MenuItem__2C1D57B55FAE039B", x => x.IdMenuPadre);
                });

            migrationBuilder.CreateTable(
                name: "ParametrosTipo",
                columns: table => new
                {
                    idParametroTipo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipNombre = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    tipDescripcion = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    tipVisible = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    tipAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Parametr__A8D83328843AB2AC", x => x.idParametroTipo);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemHijo",
                columns: table => new
                {
                    IdMenuHijo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMenuPadre = table.Column<long>(nullable: false),
                    Nombr = table.Column<string>(nullable: true),
                    Controlador = table.Column<string>(nullable: true),
                    Accion = table.Column<string>(nullable: true),
                    Icono = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MenuItem__E5A0389D88729454", x => x.IdMenuHijo);
                    table.ForeignKey(
                        name: "MenuPadre_MenuHijo_FK",
                        column: x => x.IdMenuPadre,
                        principalTable: "MenuItemPadre",
                        principalColumn: "IdMenuPadre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    idParametro = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idParametroTipo = table.Column<long>(nullable: false),
                    parClave = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    parNombre = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    parValor = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    parTipo = table.Column<short>(nullable: false),
                    parAdmin = table.Column<short>(nullable: false),
                    FecINS = table.Column<DateTime>(type: "datetime", nullable: true),
                    FecUPD = table.Column<DateTime>(type: "datetime", nullable: true),
                    FecDEL = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsrINS = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UsrUPD = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UsrDEL = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Parametr__9C816E5F89DA85D0", x => x.idParametro);
                    table.ForeignKey(
                        name: "Parametros_ParametroTipo_FK",
                        column: x => x.idParametroTipo,
                        principalTable: "ParametrosTipo",
                        principalColumn: "idParametroTipo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuHijoAcciones",
                columns: table => new
                {
                    IdMenuHijoAccion = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMenuHijo = table.Column<long>(nullable: false),
                    mhaKey = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    mhaIcono = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    mhaTooltip = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    mhaClase = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    mhaOrden = table.Column<int>(nullable: true),
                    mhaNewTab = table.Column<bool>(nullable: true),
                    mhaURL = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    mhaTexto = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MenuHijo__CB9BC911C217FB02", x => x.IdMenuHijoAccion);
                    table.ForeignKey(
                        name: "MenuAcciones_MenuHijo_FK",
                        column: x => x.IdMenuHijo,
                        principalTable: "MenuItemHijo",
                        principalColumn: "IdMenuHijo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerfilMenuHijo",
                columns: table => new
                {
                    IdPerfilMenuHijo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<long>(nullable: false),
                    IdMenuHijo = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PerfilMe__9043AF82B0D81B66", x => x.IdPerfilMenuHijo);
                    table.ForeignKey(
                        name: "MenuItemHijo_PerfilMenuHijo_FK",
                        column: x => x.IdMenuHijo,
                        principalTable: "MenuItemHijo",
                        principalColumn: "IdMenuHijo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolesAcciones",
                columns: table => new
                {
                    IdPerfilAccion = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<long>(nullable: false),
                    IdMenuHijoAccion = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RolesAcc__56ADAC70D8C3C5BA", x => x.IdPerfilAccion);
                    table.ForeignKey(
                        name: "MenuAcciones_RolesAcciones_FK",
                        column: x => x.IdMenuHijoAccion,
                        principalTable: "MenuHijoAcciones",
                        principalColumn: "IdMenuHijoAccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleID",
                table: "AspNetUsers",
                column: "RoleID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuHijoAcciones_IdMenuHijo",
                table: "MenuHijoAcciones",
                column: "IdMenuHijo");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemHijo_IdMenuPadre",
                table: "MenuItemHijo",
                column: "IdMenuPadre");

            migrationBuilder.CreateIndex(
                name: "IX_Parametros_idParametroTipo",
                table: "Parametros",
                column: "idParametroTipo");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilMenuHijo_IdMenuHijo",
                table: "PerfilMenuHijo",
                column: "IdMenuHijo");

            migrationBuilder.CreateIndex(
                name: "IX_RolesAcciones_IdMenuHijoAccion",
                table: "RolesAcciones",
                column: "IdMenuHijoAccion");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleID",
                table: "AspNetUsers",
                column: "RoleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleID",
                table: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "PerfilMenuHijo");

            migrationBuilder.DropTable(
                name: "RolesAcciones");

            migrationBuilder.DropTable(
                name: "ParametrosTipo");

            migrationBuilder.DropTable(
                name: "MenuHijoAcciones");

            migrationBuilder.DropTable(
                name: "MenuItemHijo");

            migrationBuilder.DropTable(
                name: "MenuItemPadre");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "NombreCompleto",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Dni",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "Activo",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);
        }
    }
}
