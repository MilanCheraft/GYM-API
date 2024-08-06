using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.PE.Milan_Cheraft.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MuscleGroupId = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_MuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    MuscleGroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workouts_MuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseWorkout",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    WorkoutsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseWorkout", x => new { x.ExercisesId, x.WorkoutsId });
                    table.ForeignKey(
                        name: "FK_ExerciseWorkout_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseWorkout_Workouts_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "Length", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "1", 0, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "967e1eb0-b4b3-42f7-9644-6bfede7d51b8", "John Doe", "john.doe@example.com", true, "John", "Doe", 180.0, false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAEHVxjzNFEwHtjRB9hQZnbwMFzdgtEz8K7N6RETgzfWLWgkMtNenkG9ZWNfnoY4qMFA==", null, false, "36b7a546-c0ba-467a-ab7d-5271d74d09ad", false, "john.doe@example.com", 75.0 },
                    { "10", 0, new DateTime(1993, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "c0d85d19-0aa6-4a92-85cc-061c748f606a", "AmandaClark", "amanda.clark@example.com", true, "Amanda", "Clark", 155.0, false, null, "AMANDA.CLARK@EXAMPLE.COM", "AMANDA.CLARK@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAEKQKpBbY9gXNBlI0mZAsF3Pq1i0De8JuRNOOjDm+JKHDpiQ0QUeqCkRpEKKBUxuNQQ==", null, false, "918926d0-437c-4965-a1b1-9747ca3bd096", false, "amanda.clark@example.com", 50.0 },
                    { "2", 0, new DateTime(1985, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "830bef93-6fb7-456b-aacd-80988b72ba87", "Jane Smith", "jane.smith@example.com", true, "Jane", "Smith", 165.0, false, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAEFn6nkH0JNmYKxUfw8/DFh+vqPTCpOV8slVk/Zfdd/9eOBitGcO9fEnKrKlPsmX8Ew==", null, false, "eed49ce7-ae9b-4582-91f3-0c6ba446ac2d", false, "JANESMITH", 60.0 },
                    { "3", 0, new DateTime(1995, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "53177d01-98b7-44f2-83c1-1c8667bc9f92", "Mike Johnson", "mike.johnson@example.com", true, "Mike", "Johnson", 175.0, false, null, "MIKE.JOHNSON@EXAMPLE.COM", "MIKE.JOHNSON@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAEDNF7CUklCruWmAT0srB/rPRelM79bBxEvR+yZvFJNRvhju++XdR8278mTVFWrTtJQ==", null, false, "2fcda9c7-5ebc-4f97-8354-041039083cd1", false, "mike.johnson@example.com", 80.0 },
                    { "4", 0, new DateTime(1988, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "d89cd6bb-8390-4a1c-915a-9cf326cd4069", "Emily Brown", "emily.brown@example.com", true, "Emily", "Brown", 170.0, false, null, "EMILY.BROWN@EXAMPLE.COM", "EMILY.BROWN@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAEHhtHq7Sf0jqSYAvuKKudYdl4QIac1uUi/RIhtXefmVKRSA2dmkYgV8cMRkVyozvGQ==", null, false, "c15c2c12-21d1-476f-8eb2-3c488ac9b0aa", false, "emily.brown@example.com", 65.0 },
                    { "5", 0, new DateTime(1992, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "4d1caf2f-5c09-41f3-b87c-9ab0e9b6f8e6", "Chris Williams", "chris.williams@example.com", true, "Chris", "Williams", 185.0, false, null, "CHRIS.WILLIAMS@EXAMPLE.COM", "CHRIS.WILLIAMS@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAEKc9psg3bU0h/L9/nqT6y08dynF31+yaeHkBGeuRDrLQMSEybL7FJy9LfdKWu1dAZg==", null, false, "7fb2eb6b-3577-4309-b37e-98845ca7e0e6", false, "chris.williams@example.com", 90.0 },
                    { "6", 0, new DateTime(1983, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "d943da9b-aad2-40d9-a11e-902974173cb5", "Sarah Taylor", "sarah.taylor@example.com", true, "Sarah", "Taylor", 160.0, false, null, "SARAH.TAYLOR@EXAMPLE.COM", "SARAH.TAYLOR@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAEJlRSWAkaNnG0iaGfSkCxR7qXfQ+WNFUGv82A2maLm59fnFVlkpq3RKkLmEobrzcJw==", null, false, "be5ec186-072d-4b2a-a30e-7f878a99c773", false, "sarah.taylor@example.com", 55.0 },
                    { "7", 0, new DateTime(1998, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "157da908-1758-4b56-9af7-694a40db3fb5", "Kevin Miller", "kevin.miller@example.com", true, "Kevin", "Miller", 190.0, false, null, "KEVIN.MILLER@EXAMPLE.COM", "KEVIN.MILLER@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAECA4P1xs8mRS8nQrmtJPF5al8d8GV/ulojTczdZBQyGrL+26811YRurB4Vd1ZHjvbA==", null, false, "7febfe43-c1b1-401d-abc2-79528c1a571e", false, "kevin.miller@example.com", 85.0 },
                    { "8", 0, new DateTime(1991, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "5f044eab-db4a-484f-87b1-985da24fb34d", "JessicaWilson", "jessica.wilson@example.com", true, "Jessica", "Wilson", 170.0, false, null, "JESSICA.WILSON@EXAMPLE.COM", "JESSICA.WILSON@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAEGyI+COThVMl3uaFDioZXrLNpgDxNkR07ivyayxt/KFE6Ol70ALBzfxb2KlL5Z5f/g==", null, false, "d1f4e2ae-327e-47c7-ad90-f191c5afa914", false, "jessica.wilson@example.com", 70.0 },
                    { "9", 0, new DateTime(1987, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "99439933-12fb-4d61-8f45-f76d1daac101", "David Anderson", "david.anderson@example.com", true, "David", "Anderson", 180.0, false, null, "DAVID.ANDERSON@EXAMPLE.COM", "DAVID.ANDERSON@EXAMPLE.COM", null, "AQAAAAEAACcQAAAAEP9jOHwkE/oedPaYKIK6szOXPJU34BhXgAZzOEqZAoT8Z2b0PpyxGsTfzNlHmhk3Lw==", null, false, "f08483d9-1612-4921-acea-122d611d5e6e", false, "david.anderson@example.com", 75.0 }
                });

            migrationBuilder.InsertData(
                table: "MuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chest" },
                    { 2, "Back" },
                    { 3, "Legs" },
                    { 4, "Shoulders" },
                    { 5, "Arms" },
                    { 6, "Abs" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Trainer", "1" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Trainer", "2" },
                    { 3, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Client", "3" },
                    { 4, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Client", "4" },
                    { 5, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Client", "5" },
                    { 6, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Client", "6" },
                    { 7, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Client", "7" },
                    { 8, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Client", "8" },
                    { 9, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Client", "9" },
                    { 10, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Client", "10" },
                    { 11, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "15/05/1990 0:00:00", "1" },
                    { 12, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "20/08/1985 0:00:00", "2" },
                    { 13, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "10/03/1995 0:00:00", "3" },
                    { 14, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "25/11/1988 0:00:00", "4" },
                    { 15, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "5/07/1992 0:00:00", "5" },
                    { 16, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "18/09/1983 0:00:00", "6" },
                    { 17, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "30/12/1998 0:00:00", "7" },
                    { 18, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "8/04/1991 0:00:00", "8" },
                    { 19, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "14/02/1987 0:00:00", "9" },
                    { 20, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "29/06/1993 0:00:00", "10" },
                    { 21, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "john.doe@example.com", "1" },
                    { 22, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "JANESMITH", "2" },
                    { 23, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "mike.johnson@example.com", "3" },
                    { 24, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "emily.brown@example.com", "4" },
                    { 25, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "chris.williams@example.com", "5" },
                    { 26, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "sarah.taylor@example.com", "6" },
                    { 27, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "kevin.miller@example.com", "7" },
                    { 28, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "jessica.wilson@example.com", "8" },
                    { 29, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "david.anderson@example.com", "9" },
                    { 30, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "amanda.clark@example.com", "10" },
                    { 31, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1", "1" },
                    { 32, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "2", "2" },
                    { 33, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "3", "3" },
                    { 34, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "4", "4" },
                    { 35, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "5", "5" },
                    { 36, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "6", "6" },
                    { 37, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "7", "7" },
                    { 38, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "8", "8" },
                    { 39, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "9", "9" },
                    { 40, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "10", "10" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "MuscleGroupId", "Name", "Reps", "Sets", "Weight" },
                values: new object[,]
                {
                    { 1, "Lie on a bench with a barbell and lower it to your chest, then press it back up.", 1, "Bench Press", 12, 4, 60.0 },
                    { 2, "Similar to bench press, but performed on an inclined bench, targeting upper chest.", 1, "Incline Bench Press", 10, 4, 55.0 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "MuscleGroupId", "Name", "Reps", "Sets", "Weight" },
                values: new object[,]
                {
                    { 3, "Hold dumbbells above your chest, then lower them out to the sides, and bring them back up.", 1, "Dumbbell Flyes", 12, 3, 20.0 },
                    { 4, "Start in a plank position, lower your body until your chest almost touches the ground, then push back up.", 1, "Push-ups", 15, 3, 0.0 },
                    { 5, "Hang from a bar with palms facing away, then pull yourself up until your chin passes the bar.", 2, "Pull-ups", 10, 4, 0.0 },
                    { 6, "Stand with feet hip-width apart, bend at hips and knees to grip the bar, then lift it by extending hips and knees.", 2, "Deadlifts", 8, 4, 135.0 },
                    { 7, "Bend at the hips, holding a barbell, then pull the barbell up to your lower chest while keeping your back straight.", 2, "Bent-over Rows", 10, 4, 75.0 },
                    { 8, "Stand with feet shoulder-width apart, lower your body as if sitting back into a chair, then return to standing.", 3, "Squats", 12, 4, 95.0 },
                    { 9, "Sit on a leg press machine and press the weight up by extending your legs, then lower it back down.", 3, "Leg Press", 12, 4, 180.0 },
                    { 10, "Step forward with one leg and lower your hips until both knees are bent at about a 90-degree angle, then return to standing.", 3, "Lunges", 10, 4, 25.0 },
                    { 11, "Sit on a bench with back support, hold dumbbells at shoulder height, then press them up above your head.", 4, "Shoulder Press", 12, 4, 30.0 },
                    { 12, "Stand with dumbbells at your sides, then lift them out to the sides until arms are parallel to the ground.", 4, "Lateral Raises", 12, 4, 12.0 },
                    { 13, "Hold dumbbells in front of thighs with palms facing down, then lift them up to shoulder height.", 4, "Front Raises", 12, 4, 15.0 },
                    { 14, "Stand with dumbbells at your sides, then curl them up towards your shoulders, keeping elbows close to your body.", 5, "Bicep Curls", 12, 4, 20.0 },
                    { 15, "Sit on a bench with hands next to hips, fingers facing forward, then lift yourself off the bench and lower your body by bending your elbows.", 5, "Tricep Dips", 12, 4, 0.0 },
                    { 16, "Stand with dumbbells at your sides, then curl them up towards your shoulders with palms facing each other.", 5, "Hammer Curls", 12, 4, 20.0 },
                    { 17, "Lie on your back with knees bent and feet flat on the ground, then lift your shoulders towards your knees, keeping lower back on the ground.", 6, "Crunches", 20, 3, 0.0 },
                    { 18, "Get into a push-up position but with elbows on the ground, and hold that position, keeping your body straight from head to heels.", 6, "Planks", 60, 3, 0.0 },
                    { 19, "Sit on the ground with knees bent and feet lifted, then twist your torso from side to side, touching the ground beside you with each twist.", 6, "Russian Twists", 20, 3, 0.0 },
                    { 20, "Lie on your back with legs straight, then lift them up towards the ceiling, keeping them straight, then lower them back down without touching the ground.", 6, "Leg Raises", 15, 3, 0.0 },
                    { 21, "Sit on the chest fly machine with your back flat against the pad. Grasp the handles and bring them together in front of you, keeping your arms slightly bent.", 1, "Chest Fly Machine", 12, 4, 65.0 },
                    { 22, "Sit down at a lat pulldown machine and grab the bar with palms facing away from you. Pull the bar down to your chest, then slowly return it to the starting position.", 2, "Lat Pulldown", 12, 4, 90.0 },
                    { 23, "Lie face down on the leg curl machine and hook your heels under the padded lever. Curl your legs up towards your buttocks, then slowly lower them back down.", 3, "Leg Curl Machine", 12, 4, 70.0 },
                    { 24, "Sit on a military press machine with your back flat against the pad. Grab the handles and press them up overhead, then lower them back down to shoulder height.", 4, "Military Press", 10, 4, 40.0 },
                    { 25, "Lie face down on a hamstring curl machine and position your ankles under the padded lever. Curl your heels up towards your buttocks, then slowly lower them back down.", 3, "Hamstring Curls", 12, 4, 50.0 }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Description", "Duration", "MuscleGroupId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "This workout targets the chest muscles.", 60, 1, "Chest workout", "1" },
                    { 2, "This workout targets the back muscles.", 45, 2, "Back workout", "2" },
                    { 3, "This workout targets the leg muscles.", 55, 3, "Legs workout", "3" },
                    { 4, "This workout targets the shoulder muscles.", 50, 4, "Shoulders workout", "4" },
                    { 5, "This workout targets the arm muscles.", 40, 5, "Arms workout", "5" },
                    { 6, "This workout targets the abdominal muscles.", 30, 6, "Abs workout", "6" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseWorkout",
                columns: new[] { "ExercisesId", "WorkoutsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 3 },
                    { 11, 4 },
                    { 12, 4 },
                    { 13, 4 },
                    { 14, 5 },
                    { 15, 5 },
                    { 16, 5 },
                    { 17, 6 },
                    { 18, 6 },
                    { 19, 6 },
                    { 20, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_MuscleGroupId",
                table: "Exercises",
                column: "MuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkout_WorkoutsId",
                table: "ExerciseWorkout",
                column: "WorkoutsId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_MuscleGroupId",
                table: "Workouts",
                column: "MuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ExerciseWorkout");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MuscleGroups");
        }
    }
}
