using Gcpe.MediaHub.API.Models;
using System.Text.Json;

namespace Gcpe.MediaHub.API.Data
{
    public static class DbInitializer
    {
        public static void SeedMediaTypes(GcpeMediaHubAPIContext context)
        {
            if (context.MediaTypes.Any())
            {
                context.MediaTypes.RemoveRange(context.MediaTypes);
                context.SaveChanges();
            }

            var mediaTypesData = File.ReadAllText("./Data/MediaTypesSeedData.json");
            var mediaTypes = JsonSerializer.Deserialize<List<MediaType>>(mediaTypesData);
            context.MediaTypes.AddRange(mediaTypes!);
            context.SaveChanges();
        }

        public static void SeedSpokenLanguages(GcpeMediaHubAPIContext context)
        {
            if (context.SpokenLanguages.Any())
            {
                context.SpokenLanguages.RemoveRange(context.SpokenLanguages);
                context.SaveChanges();
            }

            var spokenLanguagesSeedData = File.ReadAllText("./Data/SpokenLanguagesSeedData.json");
            var spokenLanguages = JsonSerializer.Deserialize<List<SpokenLanguage>>(spokenLanguagesSeedData);
            context.SpokenLanguages.AddRange(spokenLanguages!);
            context.SaveChanges();
        }

        public static void SeedWrittenLanguages(GcpeMediaHubAPIContext context)
        {
            if (context.WrittenLanguages.Any())
            {
                context.WrittenLanguages.RemoveRange(context.WrittenLanguages);
                context.SaveChanges();
            }

            var writtenLanguagesSeedData = File.ReadAllText("./Data/WrittenLanguagesSeedData.json");
            var writtenLanguages = JsonSerializer.Deserialize<List<WrittenLanguage>>(writtenLanguagesSeedData);
            context.WrittenLanguages.AddRange(writtenLanguages!);
            context.SaveChanges();
        }

        public static void SeedJobTitles(GcpeMediaHubAPIContext context)
        {
            if (context.JobTitles.Any())
            {
                context.JobTitles.RemoveRange(context.JobTitles);
                context.SaveChanges();
            }

            var jobTitlesSeedData = File.ReadAllText("./Data/JobTitlesSeedData.json");
            var jobTitles = JsonSerializer.Deserialize<List<JobTitle>>(jobTitlesSeedData);
            context.JobTitles.AddRange(jobTitles!);
            context.SaveChanges();
        }

        public static void SeedOutletPhoneTypes(GcpeMediaHubAPIContext context)
        {
            if (context.MediaOutletPhoneTypes.Any())
            {
                context.MediaOutletPhoneTypes.RemoveRange(context.MediaOutletPhoneTypes);
                context.SaveChanges();
            }

            var outletPhoneTypesSeedData = File.ReadAllText("./Data/OutletPhoneTypesSeedData.json");
            var outletPhoneTypes = JsonSerializer.Deserialize<List<MediaOutletPhoneType>>(outletPhoneTypesSeedData);
            context.MediaOutletPhoneTypes.AddRange(outletPhoneTypes!);
            context.SaveChanges();
        }

        public static void SeedContactPhoneTypes(GcpeMediaHubAPIContext context)
        {
            if (context.MediaContactPhoneTypes.Any())
            {
                context.MediaContactPhoneTypes.RemoveRange(context.MediaContactPhoneTypes);
                context.SaveChanges();
            }

            var contactPhoneTypesSeedData = File.ReadAllText("./Data/ContactPhoneTypesSeedData.json");
            var contactPhoneTypes = JsonSerializer.Deserialize<List<MediaContactPhoneType>>(contactPhoneTypesSeedData);
            context.MediaContactPhoneTypes.AddRange(contactPhoneTypes!);
            context.SaveChanges();
        }

        public static void SeedSocialMediaCompanies(GcpeMediaHubAPIContext context)
        {
            if (context.SocialMediaCompanies.Any())
            {
                context.SocialMediaCompanies.RemoveRange(context.SocialMediaCompanies);
                context.SaveChanges();
            }

            var socialMediaCompaniesSeedData = File.ReadAllText("./Data/SocialMediaCompaniesSeedData.json");
            var socialMediaCompanies = JsonSerializer.Deserialize<List<SocialMediaCompany>>(socialMediaCompaniesSeedData);
            context.SocialMediaCompanies.AddRange(socialMediaCompanies!);
            context.SaveChanges();
        }

        public static void SeedRequestStatuses(GcpeMediaHubAPIContext context)
        {
            if (context.RequestStatuses.Any())
            {
                context.RequestStatuses.RemoveRange(context.RequestStatuses);
                context.SaveChanges();
            }

            var requestStatusesSeedData = File.ReadAllText("./Data/RequestStatusesSeedData.json");
            var requestStatuses = JsonSerializer.Deserialize<List<RequestStatus>>(requestStatusesSeedData);
            context.RequestStatuses.AddRange(requestStatuses!);
            context.SaveChanges();
        }

        public static void SeedRequestTypes(GcpeMediaHubAPIContext context)
        {
            if (context.RequestTypes.Any())
            {
                context.RequestTypes.RemoveRange(context.RequestTypes);
                context.SaveChanges();
            }

            var requestTypesSeedData = File.ReadAllText("./Data/RequestTypesSeedData.json");
            var requestTypes = JsonSerializer.Deserialize<List<RequestType>>(requestTypesSeedData);
            context.RequestTypes.AddRange(requestTypes!);
            context.SaveChanges();
        }


        public static void SeedRequestResolutions(GcpeMediaHubAPIContext context)
        {
            if (context.RequestResolutions.Any())
            {
                context.RequestResolutions.RemoveRange(context.RequestResolutions);
                context.SaveChanges();
            }

            var requestResolutionsSeedData = File.ReadAllText("./Data/RequestResolutionsSeedData.json");
            var requestResolutions = JsonSerializer.Deserialize<List<RequestResolution>>(requestResolutionsSeedData);
            context.RequestResolutions.AddRange(requestResolutions!);
            context.SaveChanges();
        }

        public static void SeedMinistries(GcpeMediaHubAPIContext context)
        {
            if (context.Ministries.Any())
            {
                context.Ministries.RemoveRange(context.Ministries);
                context.SaveChanges();
            }

            var ministryData = File.ReadAllText("./Data/MinistriesSeedData.json");
            var ministries = JsonSerializer.Deserialize<List<Ministry>>(ministryData);
            context.Ministries.AddRange(ministries!);
            context.SaveChanges();
        }
        public static void SeedMediaOutlets(GcpeMediaHubAPIContext context)
        {
            if (context.MediaOutlets.Any())
            {
                context.MediaOutlets.RemoveRange(context.MediaOutlets);
                context.SaveChanges();
            }

            context.MediaOutlets.AddRange(new List<MediaOutlet>
            {
                new MediaOutlet
                {
                    OutletName = "Maple Current",
                    IsMajorMedia = true,
                    Website = "http://www.maplecurrent.ca",
                    Email = "admin@maplecurrent.ca"
                },
                new MediaOutlet
                {
                    OutletName = "Voix du Nord",
                    IsMajorMedia = true,
                    Website = "http://www.voixdunord.ca",
                    Email = "admin@voixdunord.ca"
                },
                new MediaOutlet
                {
                    OutletName = "True North Pulse Media",
                    IsMajorMedia = true,
                    Website = "http://www.truenorthpulsemedia.ca",
                    Email = "admin@truenorthpulsemedia.ca"
                },
            }

            );
            context.SaveChanges();
        }

        public static void SeedContacts(GcpeMediaHubAPIContext context)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                if (context.MediaContacts.Any())
                {
                    context.MediaContacts.RemoveRange(context.MediaContacts);
                    context.MediaOutletContactRelationship.RemoveRange(context.MediaOutletContactRelationship);
                    context.SaveChanges();
                }

                var outlet = context.MediaOutlets.FirstOrDefault();
                var jobTitleId = context.JobTitles.FirstOrDefault()?.Id ?? 0;
                var socialCompanyId = context.SocialMediaCompanies.FirstOrDefault()?.Id ?? 0;
                var contactPhoneTypeId = context.MediaContactPhoneTypes.FirstOrDefault()?.Id ?? 0;

                var bjorn = new MediaContact
                {
                    FirstName = "Björn",
                    LastName = "Patel",
                    Email = "bjorn.patel@gmail.com",
                    IsActive = true,
                    IsPressGallery = true,
                    JobTitleId = jobTitleId,
                    PersonalWebsite = "bjornpatel.com"
                };

                var rami = new MediaContact
                {
                    FirstName = "Rami",
                    LastName = "Chen",
                    Email = "rami.chen@gmail.com",
                    IsActive = true,
                    IsPressGallery = true,
                    JobTitleId = jobTitleId,
                    PersonalWebsite = "ramichen.com"
                };

                var tariq = new MediaContact
                {
                    FirstName = "Tariq",
                    LastName = "O'Sullivan",
                    Email = "tariq.osullivan@gmail.com",
                    IsActive = true,
                    IsPressGallery = true,
                    JobTitleId = jobTitleId,
                    PersonalWebsite = "tariqosullivan.com"
                };

                context.MediaContacts.AddRange(bjorn, rami, tariq);
                context.SaveChanges(); // assign IDs

                bjorn.SocialMedias.Add(new SocialMedia
                {
                    Company = "Xitter",
                    MediaContactId = bjorn.Id,
                    SocialMediaCompanyId = socialCompanyId,
                    SocialProfileUrl = "@bjornpatel"
                });

                rami.SocialMedias.Add(new SocialMedia
                {
                    Company = "Xitter",
                    MediaContactId = rami.Id,
                    SocialMediaCompanyId = socialCompanyId,
                    SocialProfileUrl = "@ramich"
                });

                tariq.SocialMedias.Add(new SocialMedia
                {
                    Company = "Xitter",
                    MediaContactId = tariq.Id,
                    SocialMediaCompanyId = socialCompanyId,
                    SocialProfileUrl = "@tariquo"
                });

                var bjornOutletRel = new MediaOutletContactRelationship { MediaContactId = bjorn.Id, MediaOutletId = outlet!.Id };
                var ramiOutletRel = new MediaOutletContactRelationship { MediaContactId = rami.Id, MediaOutletId = outlet!.Id };
                var tariqOutletRel = new MediaOutletContactRelationship { MediaContactId = tariq.Id, MediaOutletId = outlet!.Id };
                context.MediaOutletContactRelationship.AddRange(bjornOutletRel, ramiOutletRel, tariqOutletRel); // assign IDs

                context.MediaContactPhone.AddRange(
                    new MediaContactPhone
                    {
                        OutletContactRelationshipId = bjornOutletRel.Id,
                        PhoneNumber = "555-555-5555",
                        Extension = "555",
                        PhoneTypeId = contactPhoneTypeId,
                        IsActive = true,
                    },
                    new MediaContactPhone
                    {
                        OutletContactRelationshipId = ramiOutletRel.Id,
                        PhoneNumber = "555-555-5555",
                        Extension = "555",
                        PhoneTypeId = contactPhoneTypeId,
                        IsActive = true,
                    },
                    new MediaContactPhone
                    {
                        OutletContactRelationshipId = tariqOutletRel.Id,
                        PhoneNumber = "555-555-5555",
                        Extension = "555",
                        PhoneTypeId = contactPhoneTypeId,
                        IsActive = true,
                    }
                );

                context.MediaContactEmails.AddRange(
                    new MediaContactEmail
                    {
                        OutletContactRelationshipId = bjornOutletRel.Id,
                        EmailAddress = "test+1@example.org",
                        IsActive = true,
                    },
                    new MediaContactEmail
                    {
                        OutletContactRelationshipId = ramiOutletRel.Id,
                        EmailAddress = "test+2@example.org",
                        IsActive = true,
                    },
                    new MediaContactEmail
                    {
                        OutletContactRelationshipId = tariqOutletRel.Id,
                        EmailAddress = "test+3@example.org",
                        IsActive = true,
                    }
                );

                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        private static void SeedUsers(GcpeMediaHubAPIContext context)
        {
            if (context.Users.Any())
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
            }

            var user = new User
            {
                IDIR = "BCSTEST",
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        private static void SeedMediaRequests(GcpeMediaHubAPIContext context)
        {
            if (context.MediaRequests.Any())
            {
                context.MediaRequests.RemoveRange(context.MediaRequests);
                context.SaveChanges();
            }

            var status = context.RequestStatuses.FirstOrDefault();
            var user = context.Users.FirstOrDefault();
            var ministry = context.Ministries.FirstOrDefault();
            var requestType = context.RequestTypes.FirstOrDefault();
            var contact = context.MediaContacts.FirstOrDefault();
            var outlet = context.MediaOutlets.FirstOrDefault();

            context.MediaRequests.AddRange(
                new List<MediaRequest>
                {
                    new MediaRequest
                    {
                        RequestStatusId = status?.Id,
                        RequestTitle = "Opposition Response Inquiry",
                        AssignedUserId = user?.Id,
                        LeadMinistryId = ministry?.Id,
                        Deadline = DateTimeOffset.UtcNow.AddDays(2),
                        RequestDetails = "Requesting comment on recent legislative proposal.",
                        ReceivedOn = DateTimeOffset.UtcNow.AddHours(-4),
                        RequestTypeId = requestType?.Id,
                        RequestorContactId = contact?.Id,
                        RequestorOutletId = outlet?.Id,
                        RequestNo = 124
                    },
                    new MediaRequest
                    {
                        RequestStatusId = status?.Id,
                        RequestTitle = "Budget Breakdown Request",
                        AssignedUserId = user?.Id,
                        LeadMinistryId = ministry?.Id,
                        Deadline = DateTimeOffset.UtcNow.AddDays(5),
                        RequestDetails = "Requesting detailed breakdown of the 2025 budget for education.",
                        ReceivedOn = DateTimeOffset.UtcNow.AddDays(-1),
                        RequestTypeId = requestType?.Id,
                        RequestorContactId = contact?.Id,
                        RequestorOutletId = outlet?.Id,
                        RequestNo = 125
                    },
                    new MediaRequest
                    {
                        RequestStatusId = status?.Id,
                        RequestTitle = "Emergency Press Statement",
                        AssignedUserId = user?.Id,
                        LeadMinistryId = ministry?.Id,
                        Deadline = DateTimeOffset.UtcNow.AddHours(6),
                        RequestDetails = "Urgent request for official statement on recent wildfire response.",
                        ReceivedOn = DateTimeOffset.UtcNow.AddMinutes(-45),
                        RequestTypeId = requestType?.Id,
                        RequestorContactId = contact?.Id,
                        RequestorOutletId = outlet?.Id,
                        RequestNo = 126
                    }
                }
            );
            context.SaveChanges();
        }

        public static void SeedAll(GcpeMediaHubAPIContext context)
        {
            SeedMediaTypes(context);
            SeedSpokenLanguages(context);
            SeedWrittenLanguages(context);
            SeedJobTitles(context);
            SeedContactPhoneTypes(context);
            SeedOutletPhoneTypes(context);
            SeedSocialMediaCompanies(context);
            SeedRequestStatuses(context);
            SeedRequestResolutions(context);
            SeedRequestTypes(context);
            SeedMinistries(context);
            SeedMediaOutlets(context);
            SeedContacts(context);
            SeedUsers(context);
            SeedMediaRequests(context);
        }
    }
}
