using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "subscriptiontype",
                columns: table => new
                {
                    SubscriptionTypeID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubscriptionTypeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duration = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptiontype", x => x.SubscriptionTypeID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<short>(type: "smallint", nullable: false),
                    Balance = table.Column<short>(type: "smallint", nullable: false),
                    IsPaid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SubscriptionFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    SubscriptionTo = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastAttend = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usersubscription",
                columns: table => new
                {
                    UserSubscriptionID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubscriptionTypeID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubscriptionFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubscriptionTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersubscription", x => x.UserSubscriptionID);
                    table.ForeignKey(
                        name: "FK_usersubscription_subscriptiontype_SubscriptionTypeID",
                        column: x => x.SubscriptionTypeID,
                        principalTable: "subscriptiontype",
                        principalColumn: "SubscriptionTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usersubscription_user_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usersubscriptionhistory",
                columns: table => new
                {
                    UserSubscriptionHistoryID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubscriptionTypeID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SubscriptionFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    SubscriptionTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersubscriptionhistory", x => x.UserSubscriptionHistoryID);
                    table.ForeignKey(
                        name: "FK_usersubscriptionhistory_subscriptiontype_SubscriptionTypeID",
                        column: x => x.SubscriptionTypeID,
                        principalTable: "subscriptiontype",
                        principalColumn: "SubscriptionTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usersubscriptionhistory_user_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_usersubscription_SubscriptionTypeID",
                table: "usersubscription",
                column: "SubscriptionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_usersubscription_UserID",
                table: "usersubscription",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usersubscriptionhistory_SubscriptionTypeID",
                table: "usersubscriptionhistory",
                column: "SubscriptionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_usersubscriptionhistory_UserID",
                table: "usersubscriptionhistory",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usersubscription");

            migrationBuilder.DropTable(
                name: "usersubscriptionhistory");

            migrationBuilder.DropTable(
                name: "subscriptiontype");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
