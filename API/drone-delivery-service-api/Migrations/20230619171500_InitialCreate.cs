using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace drone_delivery_service_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Drone_DroneID",
                table: "Delivery");

            migrationBuilder.DropIndex(
                name: "IX_Delivery_DroneID",
                table: "Delivery");

            migrationBuilder.DropColumn(
                name: "DroneID",
                table: "Delivery");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DroneID",
                table: "Delivery",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DroneID",
                table: "Delivery",
                column: "DroneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Drone_DroneID",
                table: "Delivery",
                column: "DroneID",
                principalTable: "Drone",
                principalColumn: "ID");
        }
    }
}
