using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcpe.MediaHub.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaContactPhoneTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContactPhoneTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaOutletPhoneTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaOutletPhoneTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ministries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Acronym = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PhoneType = table.Column<string>(type: "TEXT", nullable: false),
                    CountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneLineNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneExtension = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestResolutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestResolutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IDIR = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WrittenLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrittenLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsPressGallery = table.Column<bool>(type: "INTEGER", nullable: false),
                    PersonalWebsite = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    JobTitleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaContacts_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaOutlets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OutletName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    IsMajorMedia = table.Column<bool>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Website = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumberId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaOutlets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaOutlets_PhoneNumbers_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RuralRoute = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Municipality = table.Column<string>(type: "TEXT", nullable: false),
                    StateProvince = table.Column<string>(type: "TEXT", nullable: false),
                    MediaOutletId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_MediaOutlets_MediaOutletId",
                        column: x => x.MediaOutletId,
                        principalTable: "MediaOutlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaOutletContactRelationship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MediaOutletId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MediaContactId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaOutletContactRelationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaOutletContactRelationship_MediaContacts_MediaContactId",
                        column: x => x.MediaContactId,
                        principalTable: "MediaContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaOutletContactRelationship_MediaOutlets_MediaOutletId",
                        column: x => x.MediaOutletId,
                        principalTable: "MediaOutlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaOutletMediaType",
                columns: table => new
                {
                    MediaOutletsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MediaTypesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaOutletMediaType", x => new { x.MediaOutletsId, x.MediaTypesId });
                    table.ForeignKey(
                        name: "FK_MediaOutletMediaType_MediaOutlets_MediaOutletsId",
                        column: x => x.MediaOutletsId,
                        principalTable: "MediaOutlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaOutletMediaType_MediaTypes_MediaTypesId",
                        column: x => x.MediaTypesId,
                        principalTable: "MediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaOutletWrittenLanguage",
                columns: table => new
                {
                    MediaOutletsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WrittenLanguagesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaOutletWrittenLanguage", x => new { x.MediaOutletsId, x.WrittenLanguagesId });
                    table.ForeignKey(
                        name: "FK_MediaOutletWrittenLanguage_MediaOutlets_MediaOutletsId",
                        column: x => x.MediaOutletsId,
                        principalTable: "MediaOutlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaOutletWrittenLanguage_WrittenLanguages_WrittenLanguagesId",
                        column: x => x.WrittenLanguagesId,
                        principalTable: "WrittenLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RequestStatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestTitle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RequestTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestDetails = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    RequestorContactId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RequestorOutletId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RequestResolutionId = table.Column<int>(type: "INTEGER", nullable: true),
                    LeadMinistryId = table.Column<int>(type: "INTEGER", nullable: true),
                    AssignedUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Response = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    RequestNo = table.Column<int>(type: "INTEGER", nullable: false),
                    ReceivedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Deadline = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaRequests_MediaContacts_RequestorContactId",
                        column: x => x.RequestorContactId,
                        principalTable: "MediaContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaRequests_MediaOutlets_RequestorOutletId",
                        column: x => x.RequestorOutletId,
                        principalTable: "MediaOutlets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaRequests_Ministries_LeadMinistryId",
                        column: x => x.LeadMinistryId,
                        principalTable: "Ministries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaRequests_RequestResolutions_RequestResolutionId",
                        column: x => x.RequestResolutionId,
                        principalTable: "RequestResolutions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaRequests_RequestStatuses_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RequestStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaRequests_RequestTypes_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaRequests_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Company = table.Column<string>(type: "TEXT", nullable: false),
                    SocialProfileUrl = table.Column<string>(type: "TEXT", nullable: false),
                    SocialMediaCompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaOutletId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MediaContactId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_MediaContacts_MediaContactId",
                        column: x => x.MediaContactId,
                        principalTable: "MediaContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialMedias_MediaOutlets_MediaOutletId",
                        column: x => x.MediaOutletId,
                        principalTable: "MediaOutlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialMedias_SocialMediaCompanies_SocialMediaCompanyId",
                        column: x => x.SocialMediaCompanyId,
                        principalTable: "SocialMediaCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaContactEmails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OutletContactRelationshipId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    IsPrimary = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContactEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaContactEmails_MediaOutletContactRelationship_OutletContactRelationshipId",
                        column: x => x.OutletContactRelationshipId,
                        principalTable: "MediaOutletContactRelationship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaContactPhone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OutletContactRelationshipId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Extension = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContactPhone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaContactPhone_MediaContactPhoneTypes_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "MediaContactPhoneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaContactPhone_MediaOutletContactRelationship_OutletContactRelationshipId",
                        column: x => x.OutletContactRelationshipId,
                        principalTable: "MediaOutletContactRelationship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaRequestAdditionalMinistries",
                columns: table => new
                {
                    AdditionalMediaRequestsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AdditionalMinistriesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaRequestAdditionalMinistries", x => new { x.AdditionalMediaRequestsId, x.AdditionalMinistriesId });
                    table.ForeignKey(
                        name: "FK_MediaRequestAdditionalMinistries_MediaRequests_AdditionalMediaRequestsId",
                        column: x => x.AdditionalMediaRequestsId,
                        principalTable: "MediaRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaRequestAdditionalMinistries_Ministries_AdditionalMinistriesId",
                        column: x => x.AdditionalMinistriesId,
                        principalTable: "Ministries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MediaOutletId",
                table: "Addresses",
                column: "MediaOutletId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContactEmails_OutletContactRelationshipId",
                table: "MediaContactEmails",
                column: "OutletContactRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContactPhone_OutletContactRelationshipId",
                table: "MediaContactPhone",
                column: "OutletContactRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContactPhone_PhoneTypeId",
                table: "MediaContactPhone",
                column: "PhoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContacts_JobTitleId",
                table: "MediaContacts",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaOutletContactRelationship_MediaContactId",
                table: "MediaOutletContactRelationship",
                column: "MediaContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaOutletContactRelationship_MediaOutletId",
                table: "MediaOutletContactRelationship",
                column: "MediaOutletId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaOutletMediaType_MediaTypesId",
                table: "MediaOutletMediaType",
                column: "MediaTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaOutlets_PhoneNumberId",
                table: "MediaOutlets",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaOutletWrittenLanguage_WrittenLanguagesId",
                table: "MediaOutletWrittenLanguage",
                column: "WrittenLanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaRequestAdditionalMinistries_AdditionalMinistriesId",
                table: "MediaRequestAdditionalMinistries",
                column: "AdditionalMinistriesId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaRequests_AssignedUserId",
                table: "MediaRequests",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaRequests_LeadMinistryId",
                table: "MediaRequests",
                column: "LeadMinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaRequests_RequestorContactId",
                table: "MediaRequests",
                column: "RequestorContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaRequests_RequestorOutletId",
                table: "MediaRequests",
                column: "RequestorOutletId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaRequests_RequestResolutionId",
                table: "MediaRequests",
                column: "RequestResolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaRequests_RequestStatusId",
                table: "MediaRequests",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaRequests_RequestTypeId",
                table: "MediaRequests",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_MediaContactId",
                table: "SocialMedias",
                column: "MediaContactId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_MediaOutletId",
                table: "SocialMedias",
                column: "MediaOutletId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_SocialMediaCompanyId",
                table: "SocialMedias",
                column: "SocialMediaCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "MediaContactEmails");

            migrationBuilder.DropTable(
                name: "MediaContactPhone");

            migrationBuilder.DropTable(
                name: "MediaOutletMediaType");

            migrationBuilder.DropTable(
                name: "MediaOutletPhoneTypes");

            migrationBuilder.DropTable(
                name: "MediaOutletWrittenLanguage");

            migrationBuilder.DropTable(
                name: "MediaRequestAdditionalMinistries");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "SpokenLanguages");

            migrationBuilder.DropTable(
                name: "MediaContactPhoneTypes");

            migrationBuilder.DropTable(
                name: "MediaOutletContactRelationship");

            migrationBuilder.DropTable(
                name: "MediaTypes");

            migrationBuilder.DropTable(
                name: "WrittenLanguages");

            migrationBuilder.DropTable(
                name: "MediaRequests");

            migrationBuilder.DropTable(
                name: "SocialMediaCompanies");

            migrationBuilder.DropTable(
                name: "MediaContacts");

            migrationBuilder.DropTable(
                name: "MediaOutlets");

            migrationBuilder.DropTable(
                name: "Ministries");

            migrationBuilder.DropTable(
                name: "RequestResolutions");

            migrationBuilder.DropTable(
                name: "RequestStatuses");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");
        }
    }
}
