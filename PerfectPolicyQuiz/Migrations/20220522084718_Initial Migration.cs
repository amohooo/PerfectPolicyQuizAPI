using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectPolicyQuiz.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizTopic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizCreatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizId);
                    table.ForeignKey(
                        name: "FK_Quizzes_Users_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "Users",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTopic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserInfoId", "Password", "UserName" },
                values: new object[] { 1, "PerfectPolicies!22", "AdminPerfectPolicies" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserInfoId", "Password", "UserName" },
                values: new object[] { 2, "AAA", "Steve" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "CreatingDate", "PassPercentage", "QuizCreatorName", "QuizTitle", "QuizTopic", "UserInfoId" },
                values: new object[] { 1, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "100%", "Steve Jones", "Perfect Quiz Policy", "OHS", 1 });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "CreatingDate", "PassPercentage", "QuizCreatorName", "QuizTitle", "QuizTopic", "UserInfoId" },
                values: new object[] { 2, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "100%", "Steve Jones", "Quiz", "Copyright", 1 });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "CreatingDate", "PassPercentage", "QuizCreatorName", "QuizTitle", "QuizTopic", "UserInfoId" },
                values: new object[] { 3, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "100%", "Steve", "Policy", "Privacy", 2 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionImage", "QuestionText", "QuestionTopic", "QuizId" },
                values: new object[,]
                {
                    { 1, null, "11. When looking to work at height, Ineed to review:", "Working at Heights", 1 },
                    { 4, null, "14. In the event you notice a potential hazard:", "Hazards", 1 },
                    { 6, null, "56. Should you be involved in or be witness to an OHS-related incident, you should:", "Incidents", 1 },
                    { 8, null, "72. When looking to work in a confined space, I need to review:", "Confined Space Work", 1 },
                    { 10, null, "87. In relation to the First Aid Kits in the various departments:", "First Aid Kit", 1 },
                    { 2, null, "12. With copyright material from our client:", "Client Copyright Materials", 2 },
                    { 5, null, "42. When purchasing copyright material from a third party source:", "Purchasing Copyright Material", 2 },
                    { 7, null, "71. With our organisation's copyright material:", "Internal Copyright Materials", 2 },
                    { 3, null, "13. Personal staff details:", "Staff Details", 3 },
                    { 9, null, "82. With Commercial in Confidence Client Details, we are required to:", "Client Details", 3 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "IsCorrect", "OptionLetter", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { 1, true, "a.", "Our Company's SOP - Working at Heights", 1 },
                    { 8, false, "c.", "Obfuscate it so as to make it difficult to interpret", 2 },
                    { 9, false, "d.", "Restrict viewing to only admin staff", 2 },
                    { 10, false, "e.", "Forward to other developers via email", 2 },
                    { 21, true, "a.", "Request copyright ownership where appropriate and feasible to do so", 5 },
                    { 22, false, "b.", "Only purchase material where we can hold the copyright", 5 },
                    { 23, false, "c.", "Only purchase material where our clients can hold the copyright", 5 },
                    { 24, false, "d.", "Retain a copy of the privacy statement attached to the material purchased", 5 },
                    { 25, false, "e.", "Create a new purchasing policy specific to that purchase", 5 },
                    { 31, false, "a.", "Obfuscate it so as to make it difficult to interpret", 7 },
                    { 32, false, "b.", "Restrict viewing to only admin staff", 7 },
                    { 33, false, "c.", "Only store in hard copy in a locked filing cabinet", 7 },
                    { 34, true, "d.", "Store such materials only on our secured network", 7 },
                    { 35, false, "e.", "Forward to other developers via email", 7 },
                    { 11, false, "a.", "Should never be viewed by any staff at any level", 3 },
                    { 12, false, "b.", "Can only be viewed by Human Resourses staff", 3 },
                    { 13, true, "c.", "Need to be managed in our company's secured database system", 3 },
                    { 14, false, "d.", "Should only ever be emailed", 3 },
                    { 15, false, "e.", "Should only be stored in hard copy in locked filing cabinets", 3 },
                    { 41, true, "a.", "Store such details only on our secured network", 9 },
                    { 42, false, "b.", "Only store in hard copy in a locked filing cabinet", 9 },
                    { 43, false, "c.", "Obfuscate it so as to make it difficult to interpret", 9 },
                    { 7, true, "b.", "Store such materials only on our secured network", 2 },
                    { 6, false, "a.", "Only store in hard copy in a locked filing cabinet", 2 },
                    { 50, false, "e.", "Fill out a Safety Data Sheet with each use", 10 },
                    { 49, false, "d.", "Only display appropriate signage when directed to do so", 10 },
                    { 2, false, "b.", "Our Company's Privacy Policy", 1 },
                    { 3, false, "c.", "Our Chemical Safety Data Sheets", 1 },
                    { 4, false, "d.", "Our Company's Copyright Policy", 1 },
                    { 5, false, "e.", "Our Company's Purchasing Policy", 1 },
                    { 16, false, "a.", "Note it for later consideration", 4 },
                    { 17, true, "b.", "Report it immediately to an OHS officer", 4 },
                    { 18, false, "c.", "Fill out a Safety Data Sheet", 4 },
                    { 19, false, "d.", "Add it to our Company's Purchasing Policy", 4 },
                    { 20, false, "e.", "Create a new SOP (Safe Operating Procedure)", 4 },
                    { 26, false, "a.", "Note it for later consideration", 6 },
                    { 44, false, "d.", "Can only be viewed by admin staff", 9 },
                    { 27, false, "b.", "Fill out a Safety Data Sheet", 6 },
                    { 29, true, "d.", "Report it immediately to an OHS or security officer", 6 },
                    { 30, false, "e.", "Our Company's Purchasing Policy", 6 },
                    { 36, false, "a.", "Our company's SOP - Working at Heights", 8 },
                    { 37, false, "b.", "Our company's SOP - Vehicle Parking", 8 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "IsCorrect", "OptionLetter", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { 38, false, "c.", "Our Chemical Safety Data Sheets", 8 },
                    { 39, false, "d.", "Our Company's Copyright Policy", 8 },
                    { 40, true, "e.", "Our company's SOP - Working in a Confined Space", 8 },
                    { 46, false, "a.", "Leave them wherever last used", 10 },
                    { 47, false, "b.", "Place them above the stovetops in the department kitchens", 10 },
                    { 48, true, "c.", "Ensure they are kept appropriately stocked", 10 },
                    { 28, false, "c.", "Add it to our Company's Purchasing Policy", 6 },
                    { 45, false, "e.", "Can be left unsecured", 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_UserInfoId",
                table: "Quizzes",
                column: "UserInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
