using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMRmvc.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.CreateTable(
                name: "ParametrosTipo",
                columns: table => new
                {
                    idParametroTipo = table.Column<long>(nullable: false),
                    tipNombre = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    tipDescripcion = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    tipVisible = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    tipAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Parametr__A8D8332887A3D0C6", x => x.idParametroTipo);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    idParametro = table.Column<long>(nullable: false),
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
                    table.PrimaryKey("PK__Parametr__9C816E5F97F4BCBF", x => x.idParametro);
                    table.ForeignKey(
                        name: "Parametros_ParametroTipo_FK",
                        column: x => x.idParametroTipo,
                        principalTable: "ParametrosTipo",
                        principalColumn: "idParametroTipo",
                        onDelete: ReferentialAction.Restrict);
                });
        }
    }
}
