using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Agricargo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class companyShipsJsonIgnore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1f11bb16-72d5-4032-8a3b-6f125d4ee653"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b94d4613-8450-4fef-bdd2-6edc89a30cf3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d609a32a-91ba-495a-900e-9138e6619ad3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d63af9c3-34de-44ab-9ea7-98866f260bbb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ec61c741-5f6d-487e-959e-450e96b465c5"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone", "TypeUser" },
                values: new object[,]
                {
                    { new Guid("0ca56afa-6870-4ce9-b6ce-3240e0c717a1"), "emi@gmail.com", "Emiliano", "$2a$11$yBGN/WXjHAI0yIOLRxb6WOiTgTrdcmImHZbQN8K04X0U1eUfwi/cq", "1923486", "Client" },
                    { new Guid("4e79be9f-83e2-485f-a6e0-27378bc601c7"), "sys_admin@gmail.com", "web master", "$2a$11$4O7lAj4WbyB3R5cJjquJsOLHX86TKw8ttHOlpJlpn0cYlnSSYMFL2", "1242214", "SuperAdmin" },
                    { new Guid("be9f8905-91e2-4a14-ae77-3071586d0656"), "pablo@gmail.com", "Pablo", "$2a$11$QFyiMCpwRFP6OFIHyGO5oOhhx2j1d7a4Wn2OzFTtaz4t4TQ35RnGi", "19864343", "Client" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyName", "Email", "Name", "Password", "Phone", "TypeUser" },
                values: new object[,]
                {
                    { new Guid("c095f425-3f8b-485d-b609-fd915e3c8b24"), "El Maruco CIA", "mario@gmail.com", "Mario Massonnat", "$2a$11$j8vaujxIZLZ1X7kWRNzh3ODHXZcYPp97J7iFSqHvKQpun/nYONWVe", "153252", "Admin" },
                    { new Guid("e8eb1993-5431-461d-bf8b-0a18c59ab614"), "Pale SRL", "pale@gmail.com", "Francisco Palena", "$2a$11$T5RbJ8AzqFYR.Hw0LbTMIuZ3P7fFZhS979t0fSaTXTkv2Im/UkXJe", "1986", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0ca56afa-6870-4ce9-b6ce-3240e0c717a1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e79be9f-83e2-485f-a6e0-27378bc601c7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be9f8905-91e2-4a14-ae77-3071586d0656"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c095f425-3f8b-485d-b609-fd915e3c8b24"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e8eb1993-5431-461d-bf8b-0a18c59ab614"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyName", "Email", "Name", "Password", "Phone", "TypeUser" },
                values: new object[,]
                {
                    { new Guid("1f11bb16-72d5-4032-8a3b-6f125d4ee653"), "El Maruco CIA", "mario@gmail.com", "Mario Massonnat", "$2a$11$UYYYIX4OOYOPxYkF/QI9vuJIhiYRdDOdrIkiHh0DVH6FKv9JKOigi", "153252", "Admin" },
                    { new Guid("b94d4613-8450-4fef-bdd2-6edc89a30cf3"), "Pale SRL", "pale@gmail.com", "Francisco Palena", "$2a$11$2r2kMNLDl9o2aVg8nuO/Y.etd4ThWIDKHIc8nIxwPd1vQpIa4y6o6", "1986", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone", "TypeUser" },
                values: new object[,]
                {
                    { new Guid("d609a32a-91ba-495a-900e-9138e6619ad3"), "pablo@gmail.com", "Pablo", "$2a$11$ApXY.5ywnPtJ0I1pGb19WOpXuGMQ03MS3HFI2.GWf4rec58VO./se", "19864343", "Client" },
                    { new Guid("d63af9c3-34de-44ab-9ea7-98866f260bbb"), "emi@gmail.com", "Emiliano", "$2a$11$yNyKVoOe/OX71vxfO434Ruhm6L4D0FvbuW/i8LYcKOQ51XveFwez2", "1923486", "Client" },
                    { new Guid("ec61c741-5f6d-487e-959e-450e96b465c5"), "sys_admin@gmail.com", "web master", "$2a$11$p.Jx14COotRbeLuRS3BtUOeWmPJcTYQRjc9vPZVfVddtuvXtCUesm", "1242214", "SuperAdmin" }
                });
        }
    }
}
