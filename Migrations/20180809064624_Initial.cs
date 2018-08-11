using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BLRI.Mvc.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                         .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardholderName = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false),
                    CreditCardNumber = table.Column<string>(nullable: false),
                    DateOfRegistration = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MembershipAutoRenew = table.Column<bool>(nullable: false),
                    Offers = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    SecurityCode = table.Column<string>(nullable: false),
                    SubscriptionType = table.Column<int>(nullable: false),
                    TermsOfService = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionTypeLookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                                                 .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    RegistrationModelId = table.Column<int>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionTypeLookup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionTypeLookup_Registration_RegistrationModelId",
                        column: x => x.RegistrationModelId,
                        principalTable: "Registration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionTypeLookup_RegistrationModelId",
                table: "SubscriptionTypeLookup",
                column: "RegistrationModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionTypeLookup");

            migrationBuilder.DropTable(
                name: "Registration");
        }
    }
}
