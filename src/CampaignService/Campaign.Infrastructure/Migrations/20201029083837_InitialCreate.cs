using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Campaign.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Approver",
                columns: table => new
                {
                    approver_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    approver_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approver", x => x.approver_id);
                });

            migrationBuilder.CreateTable(
                name: "ECUType",
                columns: table => new
                {
                    ecu_type_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ecu_type_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECUType", x => x.ecu_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Firmware",
                columns: table => new
                {
                    firmware_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    firmware_Name = table.Column<string>(nullable: true),
                    current_firmware_version = table.Column<string>(nullable: true),
                    current_firmware_link = table.Column<string>(nullable: true),
                    previous_firmware_version = table.Column<string>(nullable: true),
                    previous_firmware_link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmware", x => x.firmware_id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleECU",
                columns: table => new
                {
                    vehicle_ecu_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ecu_id = table.Column<long>(nullable: false),
                    vehicle_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleECU", x => x.vehicle_ecu_id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleGroup",
                columns: table => new
                {
                    vehiclegroup_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    VehicleGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleGroup", x => x.vehiclegroup_id);
                });

            migrationBuilder.CreateTable(
                name: "ECU",
                columns: table => new
                {
                    ecu_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ecu_model = table.Column<string>(nullable: true),
                    ecu_type_id = table.Column<long>(nullable: false),
                    ECUTypeecu_type_id = table.Column<long>(nullable: true),
                    blocks = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECU", x => x.ecu_id);
                    table.ForeignKey(
                        name: "FK_ECU_ECUType_ECUTypeecu_type_id",
                        column: x => x.ECUTypeecu_type_id,
                        principalTable: "ECUType",
                        principalColumn: "ecu_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    campaign_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    campaign_name = table.Column<string>(nullable: true),
                    campaign_desc = table.Column<string>(nullable: true),
                    approver_id = table.Column<int>(nullable: false),
                    approver_id1 = table.Column<long>(nullable: true),
                    vehiclegroup_id = table.Column<long>(nullable: true),
                    firmware_id = table.Column<long>(nullable: true),
                    ecu_id = table.Column<long>(nullable: true),
                    campaign_start_date = table.Column<DateTime>(nullable: false),
                    campaign_end_date = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<short>(nullable: true),
                    approval_date = table.Column<DateTime>(nullable: false),
                    approval_status = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.campaign_id);
                    table.ForeignKey(
                        name: "FK_Campaign_Approver_approver_id1",
                        column: x => x.approver_id1,
                        principalTable: "Approver",
                        principalColumn: "approver_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaign_ECU_ecu_id",
                        column: x => x.ecu_id,
                        principalTable: "ECU",
                        principalColumn: "ecu_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaign_Firmware_firmware_id",
                        column: x => x.firmware_id,
                        principalTable: "Firmware",
                        principalColumn: "firmware_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaign_VehicleGroup_vehiclegroup_id",
                        column: x => x.vehiclegroup_id,
                        principalTable: "VehicleGroup",
                        principalColumn: "vehiclegroup_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    vehicle_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<long>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    vehicle_model = table.Column<string>(nullable: true),
                    vehicle_year = table.Column<long>(nullable: false),
                    vehicle_registration_number = table.Column<string>(nullable: true),
                    data_origin = table.Column<string>(nullable: true),
                    ecu_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.vehicle_id);
                    table.ForeignKey(
                        name: "FK_Vehicle_ECU_ecu_id",
                        column: x => x.ecu_id,
                        principalTable: "ECU",
                        principalColumn: "ecu_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_approver_id1",
                table: "Campaign",
                column: "approver_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_ecu_id",
                table: "Campaign",
                column: "ecu_id");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_firmware_id",
                table: "Campaign",
                column: "firmware_id");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_vehiclegroup_id",
                table: "Campaign",
                column: "vehiclegroup_id");

            migrationBuilder.CreateIndex(
                name: "IX_ECU_ECUTypeecu_type_id",
                table: "ECU",
                column: "ECUTypeecu_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ecu_id",
                table: "Vehicle",
                column: "ecu_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleECU");

            migrationBuilder.DropTable(
                name: "Approver");

            migrationBuilder.DropTable(
                name: "Firmware");

            migrationBuilder.DropTable(
                name: "VehicleGroup");

            migrationBuilder.DropTable(
                name: "ECU");

            migrationBuilder.DropTable(
                name: "ECUType");
        }
    }
}
