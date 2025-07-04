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
            // Remove child records before parent records to avoid FK errors
            if (context.MediaOutletPhoneNumbers.Any())
            {
                context.MediaOutletPhoneNumbers.RemoveRange(context.MediaOutletPhoneNumbers);
                context.SaveChanges();
            }
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

            var cbcNetwork = new MediaOutlet
            {
                OutletName = "CBC",
                IsMajorMedia = true,
                Website = "http://www.cbc.ca",
                Email = "admin@cbc.ca",
            };

            cbcNetwork.Addresses.Add(new Address
            {
                Street = "450 Simcoe St.",
                City = "Victoria",
                Province = "BC",
                Country = "Canada",
                PostalCode = "V8V 1L4",
                MediaOutletId = cbcNetwork.Id
            });

            cbcNetwork.MediaTypes.Add(context.MediaTypes.FirstOrDefault()!);
            cbcNetwork.WrittenLanguages.Add(context.WrittenLanguages.FirstOrDefault()!);

            var socialLink = context.SocialMediaCompanies.FirstOrDefault();

            cbcNetwork.SocialMedias.Add(
                new SocialMedia
                {
                    SocialMediaCompanyId = socialLink.Id,
                    SocialProfileUrl = "http://social.com/@cbc",
                    MediaOutletId = cbcNetwork.Id
                });

            var phoneType = context.MediaOutletPhoneTypes.FirstOrDefault();

            cbcNetwork.MediaOutletPhoneNumbers.Add(
                        new MediaOutletPhoneNumber
                        {
                            MediaOutletId = cbcNetwork.Id,
                            MediaOutletPhoneType = phoneType,
                            PhoneNumber = "+1555-5555"
                        });

            context.MediaOutlets.Add(cbcNetwork);
            context.SaveChanges();

            var cbcVancouver = new MediaOutlet
            {
                OutletName = "CBC Vancouver",
                IsMajorMedia = true,
                Website = "http://www.cbc.ca/vancouver",
                Email = "vancouver@cbc.ca",
                ParentOutletId = cbcNetwork.Id
            };

            cbcVancouver.Addresses.Add(new Address
            {
                Street = "450 Simcoe St.",
                City = "Victoria",
                Province = "BC",
                Country = "Canada",
                PostalCode = "V8V 1L4",
                MediaOutletId = cbcNetwork.Id
            });

            cbcVancouver.MediaTypes.Add(context.MediaTypes.FirstOrDefault()!);
            cbcVancouver.WrittenLanguages.Add(context.WrittenLanguages.FirstOrDefault()!);

            cbcVancouver.SocialMedias.Add(
                new SocialMedia
                {
                    SocialMediaCompanyId = socialLink.Id,
                    SocialProfileUrl = "http://social.com/@cbcvancouver",
                    MediaOutletId = cbcNetwork.Id
                });


            cbcVancouver.MediaOutletPhoneNumbers.Add(
                        new MediaOutletPhoneNumber
                        {
                            MediaOutletId = cbcNetwork.Id,
                            MediaOutletPhoneType = phoneType,
                            PhoneNumber = "+1555-5555"
                        });


            context.MediaOutlets.AddRange(cbcVancouver);
            context.SaveChanges();
        }

        public static void SeedContacts(GcpeMediaHubAPIContext context)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                // Remove child records before parent records to avoid FK errors
                if (context.MediaContactEmails.Any())
                    context.MediaContactEmails.RemoveRange(context.MediaContactEmails);
                if (context.MediaContactPhone.Any())
                    context.MediaContactPhone.RemoveRange(context.MediaContactPhone);
                if (context.MediaOutletContactRelationship.Any())
                    context.MediaOutletContactRelationship.RemoveRange(context.MediaOutletContactRelationship);
                if (context.MediaContacts.Any())
                    context.MediaContacts.RemoveRange(context.MediaContacts);
                context.SaveChanges();

                // Check for required parent records
                var outlet = context.MediaOutlets.FirstOrDefault();
                if (outlet == null)
                    throw new Exception("Cannot seed contacts: No MediaOutlet found. Please seed MediaOutlets first.");
                var jobTitle = context.JobTitles.FirstOrDefault();
                if (jobTitle == null)
                    throw new Exception("Cannot seed contacts: No JobTitle found. Please seed JobTitles first.");
                var socialCompany = context.SocialMediaCompanies.FirstOrDefault();
                if (socialCompany == null)
                    throw new Exception("Cannot seed contacts: No SocialMediaCompany found. Please seed SocialMediaCompanies first.");
                var contactPhoneType = context.MediaContactPhoneTypes.FirstOrDefault();
                if (contactPhoneType == null)
                    throw new Exception("Cannot seed contacts: No MediaContactPhoneType found. Please seed MediaContactPhoneTypes first.");

                var bjorn = new MediaContact
                {
                    FirstName = "Björn",
                    LastName = "Patel",
                    Email = "bjorn.patel@gmail.com",
                    IsActive = true,
                    IsPressGallery = true,
                    JobTitleId = jobTitle.Id,
                    PersonalWebsite = "bjornpatel.com"
                };

                var rami = new MediaContact
                {
                    FirstName = "Rami",
                    LastName = "Chen",
                    Email = "rami.chen@gmail.com",
                    IsActive = true,
                    IsPressGallery = true,
                    JobTitleId = jobTitle.Id,
                    PersonalWebsite = "ramichen.com"
                };

                var tariq = new MediaContact
                {
                    FirstName = "Tariq",
                    LastName = "O'Sullivan",
                    Email = "tariq.osullivan@gmail.com",
                    IsActive = true,
                    IsPressGallery = true,
                    JobTitleId = jobTitle.Id,
                    PersonalWebsite = "tariqosullivan.com"
                };

                context.MediaContacts.AddRange(bjorn, rami, tariq);
                context.SaveChanges(); // assign IDs

                bjorn.SocialMedias.Add(new SocialMedia
                {
                    Company = "Xitter",
                    MediaContactId = bjorn.Id,
                    SocialMediaCompanyId = socialCompany.Id,
                    SocialProfileUrl = "@bjornpatel"
                });

                rami.SocialMedias.Add(new SocialMedia
                {
                    Company = "Xitter",
                    MediaContactId = rami.Id,
                    SocialMediaCompanyId = socialCompany.Id,
                    SocialProfileUrl = "@ramich"
                });

                tariq.SocialMedias.Add(new SocialMedia
                {
                    Company = "Xitter",
                    MediaContactId = tariq.Id,
                    SocialMediaCompanyId = socialCompany.Id,
                    SocialProfileUrl = "@tariquo"
                });

                var bjornOutletRel = new MediaOutletContactRelationship { MediaContactId = bjorn.Id, MediaOutletId = outlet.Id };
                var ramiOutletRel = new MediaOutletContactRelationship { MediaContactId = rami.Id, MediaOutletId = outlet.Id };
                var tariqOutletRel = new MediaOutletContactRelationship { MediaContactId = tariq.Id, MediaOutletId = outlet.Id };
                context.MediaOutletContactRelationship.AddRange(bjornOutletRel, ramiOutletRel, tariqOutletRel); // assign IDs
                context.SaveChanges();

                context.MediaContactPhone.AddRange(
                    new MediaContactPhone
                    {
                        OutletContactRelationshipId = bjornOutletRel.Id,
                        PhoneNumber = "555-555-5555",
                        Extension = "555",
                        PhoneTypeId = contactPhoneType.Id,
                        IsActive = true,
                    },
                    new MediaContactPhone
                    {
                        OutletContactRelationshipId = ramiOutletRel.Id,
                        PhoneNumber = "555-555-5555",
                        Extension = "555",
                        PhoneTypeId = contactPhoneType.Id,
                        IsActive = true,
                    },
                    new MediaContactPhone
                    {
                        OutletContactRelationshipId = tariqOutletRel.Id,
                        PhoneNumber = "555-555-5555",
                        Extension = "555",
                        PhoneTypeId = contactPhoneType.Id,
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
                throw new Exception($"Error seeding contacts: {ex.Message}", ex);
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
                FullName = "BCS Test User",
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
                        RequestNo = 124,
                        FYIContactUserId = user?.Id,
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
                        RequestNo = 125,
                        FYIContactUserId = user?.Id,
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
                        RequestNo = 126,
                        FYIContactUserId = user?.Id,
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
