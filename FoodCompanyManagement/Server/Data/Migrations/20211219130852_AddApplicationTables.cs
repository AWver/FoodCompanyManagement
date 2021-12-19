using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodCompanyManagement.Server.Data.Migrations
{
    public partial class AddApplicationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DietPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DietWeek = table.Column<int>(type: "int", nullable: false),
                    DietReccFoods = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DietRestriction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_DietPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DietEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diet_Id = table.Column<int>(type: "int", nullable: false),
                    DietPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_DietPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_DietPlans_DietPlans_DietPlanId",
                        column: x => x.DietPlanId,
                        principalTable: "DietPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserDiet_Id = table.Column<int>(type: "int", nullable: false),
                    User_DietPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyMeals_User_DietPlans_User_DietPlanId",
                        column: x => x.User_DietPlanId,
                        principalTable: "User_DietPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isStaff = table.Column<bool>(type: "bit", nullable: false),
                    MembershipStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserDiet_Id = table.Column<int>(type: "int", nullable: false),
                    User_DietPlanId = table.Column<int>(type: "int", nullable: true),
                    Profile_Id = table.Column<int>(type: "int", nullable: false),
                    ProfileDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_ProfileDatas_ProfileDataId",
                        column: x => x.ProfileDataId,
                        principalTable: "ProfileDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_DietPlans_User_DietPlanId",
                        column: x => x.User_DietPlanId,
                        principalTable: "User_DietPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsMembership = table.Column<bool>(type: "bit", nullable: false),
                    TopicDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Users_Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Topic_Id = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyMeals_User_DietPlanId",
                table: "DailyMeals",
                column: "User_DietPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileDataId",
                table: "User",
                column: "ProfileDataId");

            migrationBuilder.CreateIndex(
                name: "IX_User_User_DietPlanId",
                table: "User",
                column: "User_DietPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DietPlans_DietPlanId",
                table: "User_DietPlans",
                column: "DietPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMeals");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ProfileDatas");

            migrationBuilder.DropTable(
                name: "User_DietPlans");

            migrationBuilder.DropTable(
                name: "DietPlans");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
