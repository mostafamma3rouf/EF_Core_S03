using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Core_S03.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Description", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Programming", "All programming courses.", null },
                    { 6, "Design", null, null }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Email", "FullName", "JoinedDate", "ShortBio" },
                values: new object[,]
                {
                    { 1, "ahmed.hassan@example.com", "Ahmed Hassan", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backend developer with 10 years of experience in C# and ASP.NET." },
                    { 2, "sara.mostafa@example.com", "Sara Mostafa", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "mahmoud.fathy@example.com", "Mahmoud Fathy", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "UI/UX designer and software architect." }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Description", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Backend", "Server-side development.", 1 },
                    { 4, "Databases", "Relational and SQL databases.", 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Price", "PublishedDate", "Title", "level" },
                values: new object[,]
                {
                    { 1, 1, "Learn the basics of C# from scratch.", 1, true, 49.99m, new DateTime(2026, 1, 10, 9, 0, 0, 0, DateTimeKind.Utc), "C# Fundamentals", 0 },
                    { 5, 6, "Design clean and usable interfaces.", 3, true, 59.99m, new DateTime(2026, 3, 5, 9, 0, 0, 0, DateTimeKind.Utc), "UI/UX Principles", 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Description", "ParentCategoryId" },
                values: new object[,]
                {
                    { 3, "ASP.NET", null, 2 },
                    { 5, "SQL Server", "Microsoft SQL Server.", 4 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Price", "PublishedDate", "Title", "level" },
                values: new object[,]
                {
                    { 4, 4, "Performance, migrations and advanced mapping.", 2, false, 99.99m, null, "Advanced EF Core", 2 },
                    { 6, 2, "Design and split systems into services.", 3, false, 119.99m, null, "Microservices Architecture", 2 },
                    { 2, 3, "Build REST APIs with ASP.NET Core and EF Core.", 1, true, 79.99m, new DateTime(2026, 2, 1, 9, 0, 0, 0, DateTimeKind.Utc), "ASP.NET Core Web API", 1 },
                    { 3, 5, null, 2, true, 39.99m, new DateTime(2026, 2, 15, 9, 0, 0, 0, DateTimeKind.Utc), "SQL Server Essentials", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
