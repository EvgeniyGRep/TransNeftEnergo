using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransNeftEnergo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentMeters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    MeterType = table.Column<string>(nullable: true),
                    InspectionDate = table.Column<DateTime>(nullable: false),
                    InspectionPeriod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    CurrentTransformerType = table.Column<string>(nullable: true),
                    InspectionDate = table.Column<DateTime>(nullable: false),
                    InspectionPeriod = table.Column<int>(nullable: false),
                    TransformationCoefficient = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTransformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoltageTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    VoltageTransformerType = table.Column<string>(nullable: true),
                    InspectionDate = table.Column<DateTime>(nullable: false),
                    InspectionPeriod = table.Column<int>(nullable: false),
                    TransformationCoefficient = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoltageTransformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildOrganizations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ChildOrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumptionObjects_ChildOrganizations_ChildOrganizationId",
                        column: x => x.ChildOrganizationId,
                        principalTable: "ChildOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerMeasuringPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ConsumptionObjectId = table.Column<int>(nullable: false),
                    CurrentMeterId = table.Column<int>(nullable: true),
                    CurrentTransformerId = table.Column<int>(nullable: true),
                    VoltageTransformerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerMeasuringPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerMeasuringPoints_ConsumptionObjects_ConsumptionObjectId",
                        column: x => x.ConsumptionObjectId,
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PowerMeasuringPoints_CurrentMeters_CurrentMeterId",
                        column: x => x.CurrentMeterId,
                        principalTable: "CurrentMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PowerMeasuringPoints_CurrentTransformers_CurrentTransformerId",
                        column: x => x.CurrentTransformerId,
                        principalTable: "CurrentTransformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PowerMeasuringPoints_VoltageTransformers_VoltageTransformerId",
                        column: x => x.VoltageTransformerId,
                        principalTable: "VoltageTransformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupplyPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MaximumPower = table.Column<double>(nullable: false),
                    ConsumptionObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupplyPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerSupplyPoints_ConsumptionObjects_ConsumptionObjectId",
                        column: x => x.ConsumptionObjectId,
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalculatingMeters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PowerSupplyPointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatingMeters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculatingMeters_PowerSupplyPoints_PowerSupplyPointId",
                        column: x => x.PowerSupplyPointId,
                        principalTable: "PowerSupplyPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerMeasuringPointToCalculatingMeter",
                columns: table => new
                {
                    PowerMeasuringPointId = table.Column<int>(nullable: false),
                    CalculatingMeterId = table.Column<int>(nullable: false),
                    FromTime = table.Column<DateTime>(nullable: false),
                    ToTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerMeasuringPointToCalculatingMeter", x => new { x.PowerMeasuringPointId, x.CalculatingMeterId });
                    table.ForeignKey(
                        name: "FK_PowerMeasuringPointToCalculatingMeter_CalculatingMeters_CalculatingMeterId",
                        column: x => x.CalculatingMeterId,
                        principalTable: "CalculatingMeters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PowerMeasuringPointToCalculatingMeter_PowerMeasuringPoints_PowerMeasuringPointId",
                        column: x => x.PowerMeasuringPointId,
                        principalTable: "PowerMeasuringPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculatingMeters_PowerSupplyPointId",
                table: "CalculatingMeters",
                column: "PowerSupplyPointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChildOrganizations_OrganizationId",
                table: "ChildOrganizations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionObjects_ChildOrganizationId",
                table: "ConsumptionObjects",
                column: "ChildOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerMeasuringPoints_ConsumptionObjectId",
                table: "PowerMeasuringPoints",
                column: "ConsumptionObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerMeasuringPoints_CurrentMeterId",
                table: "PowerMeasuringPoints",
                column: "CurrentMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerMeasuringPoints_CurrentTransformerId",
                table: "PowerMeasuringPoints",
                column: "CurrentTransformerId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerMeasuringPoints_VoltageTransformerId",
                table: "PowerMeasuringPoints",
                column: "VoltageTransformerId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerMeasuringPointToCalculatingMeter_CalculatingMeterId",
                table: "PowerMeasuringPointToCalculatingMeter",
                column: "CalculatingMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupplyPoints_ConsumptionObjectId",
                table: "PowerSupplyPoints",
                column: "ConsumptionObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PowerMeasuringPointToCalculatingMeter");

            migrationBuilder.DropTable(
                name: "CalculatingMeters");

            migrationBuilder.DropTable(
                name: "PowerMeasuringPoints");

            migrationBuilder.DropTable(
                name: "PowerSupplyPoints");

            migrationBuilder.DropTable(
                name: "CurrentMeters");

            migrationBuilder.DropTable(
                name: "CurrentTransformers");

            migrationBuilder.DropTable(
                name: "VoltageTransformers");

            migrationBuilder.DropTable(
                name: "ConsumptionObjects");

            migrationBuilder.DropTable(
                name: "ChildOrganizations");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
