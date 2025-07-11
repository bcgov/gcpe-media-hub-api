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

        public static void SeedWrittenLanguages(Gcpe.MediaHub.API.Data.GcpeMediaHubAPIContext context)
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

            var tcNetwork = new MediaOutlet
            {
                OutletName = "Times Colonist",
                IsMajorMedia = true,
                Website = "http://www.timescolonist.com/",
                Email = "localnews@timescolonist.com",
            };

            tcNetwork.Addresses.Add(new Address
            {
                Street = "655 Tyee Road",
                City = "Victoria",
                Province = "BC",
                Country = "Canada",
                PostalCode = "V9A 6X5",
                MediaOutletId = tcNetwork.Id
            });

            tcNetwork.MediaTypes.Add(context.MediaTypes.FirstOrDefault(x => x.Name == "Newspaper")!);
            tcNetwork.MediaTypes.Add(context.MediaTypes.FirstOrDefault(x => x.Name == "Web")!);
            tcNetwork.WrittenLanguages.Add(context.WrittenLanguages.FirstOrDefault()!);

            var socialLinkx = context.SocialMediaCompanies.FirstOrDefault(x => x.Name == "X");

            tcNetwork.SocialMedias.Add(
                new SocialMedia
                {
                    SocialMediaCompanyId = socialLinkx.Id,
                    SocialProfileUrl = "http://x.com/@timescolonist",
                    MediaOutletId = tcNetwork.Id
                });

            var phoneTypeGeneral = context.MediaOutletPhoneTypes.FirstOrDefault(x => x.Name == "General");

            tcNetwork.MediaOutletPhoneNumbers.Add(
                        new MediaOutletPhoneNumber
                        {
                            MediaOutletId = tcNetwork.Id,
                            MediaOutletPhoneType = phoneTypeGeneral,
                            PhoneNumber = "+1250-380-5333"
                        });

            context.MediaOutlets.Add(tcNetwork);
            context.SaveChanges();

            var vancouverSunNetwork = new MediaOutlet
            {
                OutletName = "Vancouver Sun",
                IsMajorMedia = true,
                Website = "https://vancouversun.com/",
                Email = " sunwebfile@vancouversun.com",
            };

            vancouverSunNetwork.Addresses.Add(new Address
            {
                Street = "1 - 200 Granville Street",
                City = "Vancouver",
                Province = "BC",
                Country = "Canada",
                PostalCode = "V6C 1S4",
                MediaOutletId = vancouverSunNetwork.Id
            });

            vancouverSunNetwork.MediaTypes.Add(context.MediaTypes.FirstOrDefault(x => x.Name == "Newspaper")!);
            vancouverSunNetwork.MediaTypes.Add(context.MediaTypes.FirstOrDefault(x => x.Name == "Web")!);
            vancouverSunNetwork.WrittenLanguages.Add(context.WrittenLanguages.FirstOrDefault()!);

            var socialLinkinstagram = context.SocialMediaCompanies.FirstOrDefault(x => x.Name == "Instagram");

            vancouverSunNetwork.SocialMedias.Add(
                new SocialMedia
                {
                    SocialMediaCompanyId = socialLinkx.Id,
                    SocialProfileUrl = "https://x.com/VancouverSun",
                    MediaOutletId = vancouverSunNetwork.Id
                });
            vancouverSunNetwork.SocialMedias.Add(
                new SocialMedia
                {
                    SocialMediaCompanyId = socialLinkinstagram.Id,
                    SocialProfileUrl = "https://www.instagram.com/thevancouversun/",
                    MediaOutletId = vancouverSunNetwork.Id
                });

            phoneTypeGeneral = context.MediaOutletPhoneTypes.FirstOrDefault(x => x.Name == "General");
            var phoneTypeNewsDesk = context.MediaOutletPhoneTypes.FirstOrDefault(x => x.Name == "News Desk");

            vancouverSunNetwork.MediaOutletPhoneNumbers.Add(
                        new MediaOutletPhoneNumber
                        {
                            MediaOutletId = vancouverSunNetwork.Id,
                            MediaOutletPhoneType = phoneTypeGeneral,
                            PhoneNumber = "604-605-2185"
                        });
            vancouverSunNetwork.MediaOutletPhoneNumbers.Add(
                        new MediaOutletPhoneNumber
                        {
                            MediaOutletId = vancouverSunNetwork.Id,
                            MediaOutletPhoneType = phoneTypeNewsDesk,
                            PhoneNumber = "604-605-2445"
                        });

            context.MediaOutlets.Add(vancouverSunNetwork);
            context.SaveChanges();

            var pressGallery = new MediaOutlet
            {
                OutletName = "Press Gallery",
                IsMajorMedia = true,
                Website = "",
                Email = "",
            };

            pressGallery.Addresses.Add(new Address
            {
                Street = "501 Belleville Street",
                City = "Victoria",
                Province = "BC",
                Country = "Canada",
                PostalCode = "V8V 1X4",
                MediaOutletId = pressGallery.Id
            });

            pressGallery.MediaTypes.Add(context.MediaTypes.FirstOrDefault(x => x.Name == "TV")!);
            pressGallery.WrittenLanguages.Add(context.WrittenLanguages.FirstOrDefault()!);

            pressGallery.SocialMedias.Add(
                new SocialMedia
                {
                    SocialMediaCompanyId = socialLink.Id,
                    SocialProfileUrl = "http://social.com/@cbcvancouver",
                    MediaOutletId = pressGallery.Id
                });


            pressGallery.MediaOutletPhoneNumbers.Add(
                        new MediaOutletPhoneNumber
                        {
                            MediaOutletId = pressGallery.Id,
                            MediaOutletPhoneType = phoneType,
                            PhoneNumber = "+1555-5555"
                        });


            context.MediaOutlets.AddRange(pressGallery);
            context.SaveChanges();

            var globeandMail = new MediaOutlet
            {
                OutletName = "Globe and Mail - BC Bureau",
                IsMajorMedia = true,
                Website = "http://www.theglobeandmail.com/news/british-columbia/",
                Email = "newsroom@globeandmail.com",
            };

            globeandMail.Addresses.Add(new Address
            {
                Street = "444 Front Street West",
                City = "Vancouver",
                Province = "BC",
                Country = "Canada",
                PostalCode = "V8V 1L4",
                MediaOutletId = globeandMail.Id
            });

            globeandMail.MediaTypes.Add(context.MediaTypes.FirstOrDefault()!);
            globeandMail.WrittenLanguages.Add(context.WrittenLanguages.FirstOrDefault()!);

            globeandMail.SocialMedias.Add(
                new SocialMedia
                {
                    SocialMediaCompanyId = socialLink.Id,
                    SocialProfileUrl = "http://social.com/@GlobeBC",
                    MediaOutletId = globeandMail.Id
                });


            globeandMail.MediaOutletPhoneNumbers.Add(
                        new MediaOutletPhoneNumber
                        {
                            MediaOutletId = globeandMail.Id,
                            MediaOutletPhoneType = phoneType,
                            PhoneNumber = "416-585-5000"
                        });


            context.MediaOutlets.AddRange(globeandMail);
            context.SaveChanges();

            var checkTVVictoria = new MediaOutlet
            {
                OutletName = "CHEK TV - Victoria",
                IsMajorMedia = true,
                Website = "http://www.cheknews.ca/",
                Email = "tips@cheknews.ca",
            };

            checkTVVictoria.Addresses.Add(new Address
            {
                Street = "780 Kings Road",
                City = "Victoria",
                Province = "BC",
                Country = "Canada",
                PostalCode = "V8T 5A2",
                MediaOutletId = checkTVVictoria.Id
            });

            checkTVVictoria.MediaTypes.Add(context.MediaTypes.FirstOrDefault(x => x.Name == "TV")!);
            checkTVVictoria.WrittenLanguages.Add(context.WrittenLanguages.FirstOrDefault(x => x.Name == "English")!);

            checkTVVictoria.SocialMedias.Add(
                new SocialMedia
                {
                    SocialMediaCompanyId = socialLink.Id,
                    SocialProfileUrl = "http://social.com/@CHEK_News",
                    MediaOutletId = checkTVVictoria.Id
                });


            checkTVVictoria.MediaOutletPhoneNumbers.Add(
                        new MediaOutletPhoneNumber
                        {
                            MediaOutletId = checkTVVictoria.Id,
                            MediaOutletPhoneType = phoneType,
                            PhoneNumber = "250-480-3700"
                        });


            context.MediaOutlets.AddRange(checkTVVictoria);
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
                var outlets = context.MediaOutlets.ToList();
                var jobTitles = context.JobTitles.ToList();
                var socialCompanies = context.SocialMediaCompanies.ToList();
                var contactPhoneTypes = context.MediaContactPhoneTypes.ToList();
                if (!outlets.Any())
                    throw new Exception("Cannot seed contacts: No MediaOutlet found. Please seed MediaOutlets first.");
                if (!jobTitles.Any())
                    throw new Exception("Cannot seed contacts: No JobTitle found. Please seed JobTitles first.");
                if (!socialCompanies.Any())
                    throw new Exception("Cannot seed contacts: No SocialMediaCompany found. Please seed SocialMediaCompanies first.");
                if (!contactPhoneTypes.Any())
                    throw new Exception("Cannot seed contacts: No MediaContactPhoneType found. Please seed MediaContactPhoneTypes first.");

                // Read contacts from CSV
                var csvPath = "./Data/contact.csv";
                var allLines = File.ReadAllLines(csvPath).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
                if (allLines.Count < 2) return;
                var header = allLines[0].Split(',').Select(h => h.Trim()).ToList();
                var col = new Dictionary<string, int>();
                for (int i = 0; i < header.Count; i++) col[header[i]] = i;
                foreach (var line in allLines.Skip(1))
                {
                    var fields = line.Split(',');
                    string Get(string name) => col.ContainsKey(name) && fields.Length > col[name] ? fields[col[name]].Trim() : string.Empty;
                    var firstName = Get("Contact_First_Name");
                    var lastName = Get("Contact_Last Name");
                    var isPressGallery = Get("Is_Press_Gallery").ToLower() == "yes";
                    var jobTitleName = Get("Contact_Job_Title");
                    var outletName = Get("Contact_Outlet_Name");
                    var email = Get("Contact_Email");
                    var phonePrimary = Get("Contact_Phone_Number_Primary");
                    var phoneMobile = Get("Contact_Phone_Number_Mobile");
                    var phoneStudio = Get("Contact_Phone_Number_Studio_Call-in");
                    var socialX = Get("Contact_SocialMedia_X");
                    var socialInstagram = Get("Contact_Social Media_Instagram");
                    var location = Get("Contact_Location");

                    var jobTitle = jobTitles.FirstOrDefault(j => j.Name == jobTitleName) ?? jobTitles.First();
                    var outlet = outlets.FirstOrDefault(o => o.OutletName == outletName) ?? outlets.First();
                    var socialCompany = socialCompanies.First();
                    var contactPhoneType = contactPhoneTypes.First();

                    var contact = new MediaContact
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        IsActive = true,
                        IsPressGallery = isPressGallery,
                        JobTitleId = jobTitle.Id,
                        PersonalWebsite = string.Empty, // Ensure NOT NULL for PersonalWebsite
                        Location = location // Also set Location if required by schema
                    };
                    context.MediaContacts.Add(contact);
                    context.SaveChanges(); // assign ID

                    // Social Media (X)
                    if (!string.IsNullOrWhiteSpace(socialX) && socialX != "null")
                    {
                        contact.SocialMedias.Add(new SocialMedia
                        {
                            Company = "X",
                            MediaContactId = contact.Id,
                            SocialMediaCompanyId = socialCompany.Id,
                            SocialProfileUrl = socialX
                        });
                    }
                    // Social Media (Instagram)
                    if (!string.IsNullOrWhiteSpace(socialInstagram) && socialInstagram != "null")
                    {
                        contact.SocialMedias.Add(new SocialMedia
                        {
                            Company = "Instagram",
                            MediaContactId = contact.Id,
                            SocialMediaCompanyId = socialCompany.Id,
                            SocialProfileUrl = socialInstagram
                        });
                    }
                    context.SaveChanges();

                    // Outlet relationship
                    var outletRel = new MediaOutletContactRelationship { MediaContactId = contact.Id, MediaOutletId = outlet.Id };
                    context.MediaOutletContactRelationship.Add(outletRel);
                    context.SaveChanges();

                    // Phones
                    if (!string.IsNullOrWhiteSpace(phonePrimary) && phonePrimary != "null")
                    {
                        context.MediaContactPhone.Add(new MediaContactPhone
                        {
                            OutletContactRelationshipId = outletRel.Id,
                            PhoneNumber = phonePrimary,
                            Extension = null,
                            PhoneTypeId = contactPhoneType.Id,
                            IsActive = true,
                        });
                    }
                    if (!string.IsNullOrWhiteSpace(phoneMobile) && phoneMobile != "null")
                    {
                        context.MediaContactPhone.Add(new MediaContactPhone
                        {
                            OutletContactRelationshipId = outletRel.Id,
                            PhoneNumber = phoneMobile,
                            Extension = null,
                            PhoneTypeId = contactPhoneType.Id,
                            IsActive = true,
                        });
                    }
                    if (!string.IsNullOrWhiteSpace(phoneStudio) && phoneStudio != "null")
                    {
                        context.MediaContactPhone.Add(new MediaContactPhone
                        {
                            OutletContactRelationshipId = outletRel.Id,
                            PhoneNumber = phoneStudio,
                            Extension = null,
                            PhoneTypeId = contactPhoneType.Id,
                            IsActive = true,
                        });
                    }
                    // Email
                    if (!string.IsNullOrWhiteSpace(email) && email != "null")
                    {
                        context.MediaContactEmails.Add(new MediaContactEmail
                        {
                            OutletContactRelationshipId = outletRel.Id,
                            EmailAddress = email,
                            IsActive = true,
                        });
                    }
                    context.SaveChanges();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error seeding contacts: {ex.Message}", ex);
            }
        }

        public static void SeedContactsDefault(GcpeMediaHubAPIContext context)
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
                throw new Exception($"Error seeding contacts: {ex.Message}", ex);
            }
        }

        public static void SeedMediaOutletsFromCsv(GcpeMediaHubAPIContext context)
        {
            if (context.MediaOutlets.Any())
            {
                context.MediaOutlets.RemoveRange(context.MediaOutlets);
                context.SaveChanges();
            }

            var csvPath = "./Data/outlet.csv";
            if (!File.Exists(csvPath))
                return;
            var allLines = File.ReadAllLines(csvPath).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            if (allLines.Count < 2) return;
            var header = allLines[0].Split(',').Select(h => h.Trim()).ToList();
            var col = new Dictionary<string, int>();
            for (int i = 0; i < header.Count; i++) col[header[i]] = i;
            foreach (var line in allLines.Skip(1))
            {
                var fields = line.Split(',');
                string Get(string name) => col.ContainsKey(name) && fields.Length > col[name] ? fields[col[name]].Trim() : string.Empty;
                var outletName = Get("Outlet_Name");
                var mediaTypes = Get("Outlet_Media_Types");
                var language = Get("Outlet_Language");
                var isMajorMedia = Get("Is_Major_Media").ToLower() == "true";
                var email = Get("Outlet_email");
                var website = Get("Outlet_Website");
                var phonePrimary = Get("Outlet_Phone_Number_Primary");
                var phoneNewsDesk = Get("Outlet_Phone_Number_News_Desk");
                var socialX = Get("Outlet_Social_Media_X");
                var socialInstagram = Get("Contact_Social_Media_Instagram");
                var address = Get("Outlet_Address");
                var location = Get("Outlet_Location");
                var postalCode = Get("Postal Code");

                var outlet = new MediaOutlet
                {
                    OutletName = outletName,
                    IsMajorMedia = isMajorMedia,
                    Website = website,
                    Email = email,
                };

                // Address
                outlet.Addresses.Add(new Address
                {
                    Street = address,
                    City = location,
                    Province = "BC",
                    Country = "Canada",
                    PostalCode = postalCode,
                    MediaOutletId = outlet.Id
                });

                // Media Types (assume already seeded)
                if (!string.IsNullOrWhiteSpace(mediaTypes))
                {
                    var typeNames = mediaTypes.Split(";").SelectMany(t => t.Split("|")).Select(t => t.Trim()).Where(t => !string.IsNullOrEmpty(t));
                    foreach (var typeName in typeNames)
                    {
                        var mt = context.MediaTypes.FirstOrDefault(x => x.Name == typeName);
                        if (mt != null) outlet.MediaTypes.Add(mt);
                    }
                }

                // Written Language (assume already seeded)
                if (!string.IsNullOrWhiteSpace(language))
                {
                    var lang = context.WrittenLanguages.FirstOrDefault(x => x.Name == language);
                    if (lang != null) outlet.WrittenLanguages.Add(lang);
                }

                // Social Media (X)
                var socialCompanyX = context.SocialMediaCompanies.FirstOrDefault(x => x.Name == "X");
                if (!string.IsNullOrWhiteSpace(socialX) && socialX != "null" && socialCompanyX != null)
                {
                    outlet.SocialMedias.Add(new SocialMedia
                    {
                        SocialMediaCompanyId = socialCompanyX.Id,
                        SocialProfileUrl = socialX,
                        MediaOutletId = outlet.Id
                    });
                }
                // Social Media (Instagram)
                var socialCompanyInstagram = context.SocialMediaCompanies.FirstOrDefault(x => x.Name == "Instagram");
                if (!string.IsNullOrWhiteSpace(socialInstagram) && socialInstagram != "null" && socialCompanyInstagram != null)
                {
                    outlet.SocialMedias.Add(new SocialMedia
                    {
                        SocialMediaCompanyId = socialCompanyInstagram.Id,
                        SocialProfileUrl = socialInstagram,
                        MediaOutletId = outlet.Id
                    });
                }

                // Phone Numbers (assume already seeded)
                var phoneTypeGeneral = context.MediaOutletPhoneTypes.FirstOrDefault(x => x.Name == "General");
                var phoneTypeNewsDesk = context.MediaOutletPhoneTypes.FirstOrDefault(x => x.Name == "News Desk");
                if (!string.IsNullOrWhiteSpace(phonePrimary) && phonePrimary != "null" && phoneTypeGeneral != null)
                {
                    outlet.MediaOutletPhoneNumbers.Add(new MediaOutletPhoneNumber
                    {
                        MediaOutletId = outlet.Id,
                        MediaOutletPhoneType = phoneTypeGeneral,
                        PhoneNumber = phonePrimary
                    });
                }
                if (!string.IsNullOrWhiteSpace(phoneNewsDesk) && phoneNewsDesk != "null" && phoneTypeNewsDesk != null)
                {
                    outlet.MediaOutletPhoneNumbers.Add(new MediaOutletPhoneNumber
                    {
                        MediaOutletId = outlet.Id,
                        MediaOutletPhoneType = phoneTypeNewsDesk,
                        PhoneNumber = phoneNewsDesk
                    });
                }

                context.MediaOutlets.Add(outlet);
                context.SaveChanges();
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
            var statusInProgress = context.RequestStatuses.FirstOrDefault(x => x.Name == "In Progress");
            var user = context.Users.FirstOrDefault();
            var ministry = context.Ministries.FirstOrDefault();
            var ministryHealth = context.Ministries.FirstOrDefault(x => x.Acronym == "HLTH");
            var requestType = context.RequestTypes.FirstOrDefault();
            var requestTypeBackgroundInformation = context.RequestTypes.FirstOrDefault(x => x.Name == "Background Information");
            var contact = context.MediaContacts.FirstOrDefault();
            var outlet = context.MediaOutlets.FirstOrDefault();

            // Only add requests if a valid contact exists (avoid NOT NULL constraint error)
            var requests = new List<MediaRequest>();
            if (contact != null)
            {
                requests.Add(new MediaRequest
                {
                    RequestStatusId = status?.Id,
                    RequestTitle = "Opposition Response Inquiry",
                    AssignedUserId = user?.Id,
                    LeadMinistryId = ministry?.Id,
                    Deadline = DateTimeOffset.UtcNow.AddDays(2),
                    RequestDetails = "Requesting comment on recent legislative proposal.",
                    ReceivedOn = DateTimeOffset.UtcNow.AddHours(-4),
                    RequestTypeId = requestType?.Id,
                    RequestorContactId = contact.Id,
                    RequestorOutletId = outlet?.Id,
                    RequestNo = 124,
                    FYIContactUserId = user?.Id,
                });
                requests.Add(new MediaRequest
                {
                    RequestStatusId = status?.Id,
                    RequestTitle = "Budget Breakdown Request",
                    AssignedUserId = user?.Id,
                    LeadMinistryId = ministry?.Id,
                    Deadline = DateTimeOffset.UtcNow.AddDays(5),
                    RequestDetails = "Requesting detailed breakdown of the 2025 budget for education.",
                    ReceivedOn = DateTimeOffset.UtcNow.AddDays(-1),
                    RequestTypeId = requestType?.Id,
                    RequestorContactId = contact.Id,
                    RequestorOutletId = outlet?.Id,
                    RequestNo = 125,
                    FYIContactUserId = user?.Id,
                });
                requests.Add(new MediaRequest
                {
                    RequestStatusId = status?.Id,
                    RequestTitle = "Emergency Press Statement",
                    AssignedUserId = user?.Id,
                    LeadMinistryId = ministry?.Id,
                    Deadline = DateTimeOffset.UtcNow.AddHours(6),
                    RequestDetails = "Urgent request for official statement on recent wildfire response.",
                    ReceivedOn = DateTimeOffset.UtcNow.AddMinutes(-45),
                    RequestTypeId = requestType?.Id,
                    RequestorContactId = contact.Id,
                    RequestorOutletId = outlet?.Id,
                    RequestNo = 126,
                    FYIContactUserId = user?.Id,
                });
            }
            var vaughnContact = context.MediaContacts.FirstOrDefault(x => x.FirstName == "Vaughn" && x.LastName == "Palmer");
            if (vaughnContact != null)
            {
                requests.Add(new MediaRequest
                {
                    RequestStatusId = statusInProgress?.Id,
                    RequestTitle = "Tragic incident at Lapu Lapu festival",
                    AssignedUserId = user?.Id,
                    LeadMinistryId = ministryHealth?.Id,
                    Deadline = DateTimeOffset.UtcNow.AddHours(6),
                    RequestDetails = "Lori Ipsom cat Lori Ipsom dog Lori Ipsom lady bug",
                    ReceivedOn = DateTimeOffset.UtcNow.AddMinutes(-45),
                    RequestTypeId = requestTypeBackgroundInformation?.Id,
                    RequestorContactId = vaughnContact.Id,
                    RequestorOutletId = outlet?.Id,
                    RequestNo = 242,
                    FYIContactUserId = user?.Id,
                });
            }
            if (requests.Count > 0)
            {
                context.MediaRequests.AddRange(requests);
                context.SaveChanges();
            }
        }

        public static void SeedAll(GcpeMediaHubAPIContext context, bool seedFromCsv = false)
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
            if (seedFromCsv)
            {
                SeedMediaOutletsFromCsv(context);
                SeedContacts(context);
                SeedUsersFromCsv(context);
                SeedMediaRequestsFromCsv(context);
            }
            else
            {
                SeedMediaOutlets(context);
                SeedContactsDefault(context);
                SeedUsers(context);
                SeedMediaRequests(context);
            }
            
        }

        public static void SeedUsersFromCsv(GcpeMediaHubAPIContext context)
        {
            if (context.Users.Any())
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
            }

            var csvPath = "./Data/user.csv";
            if (!File.Exists(csvPath))
                return;
            var allLines = File.ReadAllLines(csvPath).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            if (allLines.Count < 2) return;
            var header = allLines[0].Split(',').Select(h => h.Trim()).ToList();
            var col = new Dictionary<string, int>();
            for (int i = 0; i < header.Count; i++) col[header[i]] = i;
            foreach (var line in allLines.Skip(1))
            {
                var fields = line.Split(',');
                string Get(string name) => col.ContainsKey(name) && fields.Length > col[name] ? fields[col[name]].Trim() : string.Empty;
                var idir = Get("IDIR");
                var fullName = Get("FullName");

                if (string.IsNullOrEmpty(idir) && string.IsNullOrEmpty(fullName)) continue;

                var user = new User
                {
                    IDIR = idir,
                    FullName = fullName
                };

                context.Users.Add(user);
            }
            context.SaveChanges();
        }

        public static void SeedMediaRequestsFromCsv(GcpeMediaHubAPIContext context)
        {
            if (context.MediaRequests.Any())
            {
                context.MediaRequests.RemoveRange(context.MediaRequests);
                context.SaveChanges();
            }

            var csvPath = "./Data/request.csv";
            if (!File.Exists(csvPath))
                return;
            var allLines = File.ReadAllLines(csvPath).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            if (allLines.Count < 2) return;
            var header = allLines[0].Split(',').Select(h => h.Trim()).ToList();
            var col = new Dictionary<string, int>();
            for (int i = 0; i < header.Count; i++) col[header[i]] = i;
            // Generate unique RequestNo starting from max existing or 1
            int nextRequestNo = 1;
            if (context.MediaRequests.Any())
            {
                nextRequestNo = context.MediaRequests.Max(r => r.RequestNo) + 1;
            }
            foreach (var line in allLines.Skip(1))
            {
                var fields = line.Split(',');
                string Get(string name) => col.ContainsKey(name) && fields.Length > col[name] ? fields[col[name]].Trim() : string.Empty;
                var requestTitle = Get("Request_Title");
                var requestStatusName = Get("Request_Status");
                var requestTypeName = Get("Request_Type");
                var requestorContactFullName = Get("Request_RequestorContact");
                var requestorOutletName = Get("Request_RequestorOutlet");
                DateTimeOffset.TryParse(Get("Request_ReceivedOn"), out var receivedOn);
                DateTimeOffset.TryParse(Get("Request_Deadline"), out var deadline);
                var leadMinistryAbbr = Get("Request_LeadMinistry");
                var assignedToIDIR = Get("Request_AssignedTo");
                // Ignore Request_No from CSV, always generate

                var leadMinistry = context.Ministries.FirstOrDefault(m => m.Acronym == leadMinistryAbbr) ?? context.Ministries.FirstOrDefault();

                // Split full name into first and last name (assume last word is last name, rest is first name)
                string contactFirstName = null;
                string contactLastName = null;
                if (!string.IsNullOrWhiteSpace(requestorContactFullName))
                {
                    var nameParts = requestorContactFullName.Trim().Split(' ');
                    if (nameParts.Length >= 2)
                    {
                        contactFirstName = string.Join(" ", nameParts.Take(nameParts.Length - 1)).Trim();
                        contactLastName = nameParts.Last().Trim();
                    }
                    else if (nameParts.Length == 1)
                    {
                        contactFirstName = nameParts[0].Trim();
                        contactLastName = string.Empty;
                    }
                }

                // Case-insensitive, trimmed match
                var requestorContact = context.MediaContacts.FirstOrDefault(c =>
                    (!string.IsNullOrEmpty(contactFirstName) && c.FirstName != null && c.FirstName.Trim().ToLower() == contactFirstName.ToLower()) &&
                    (!string.IsNullOrEmpty(contactLastName) && c.LastName != null && c.LastName.Trim().ToLower() == contactLastName.ToLower())
                );

                if (requestorContact == null)
                {
                    // Log and skip, but do NOT add a request with a null RequestorContactId
                    Console.WriteLine($"Skipping request: No contact found for name '{requestorContactFullName}' (parsed as '{contactFirstName} {contactLastName}')");
                    continue;
                }

                var requestorOutlet = context.MediaOutlets.FirstOrDefault(o => o.OutletName == requestorOutletName) ?? context.MediaOutlets.FirstOrDefault();
                var assignedUser = context.Users.FirstOrDefault(u => u.IDIR == assignedToIDIR) ?? context.Users.FirstOrDefault();
                var requestStatus = context.RequestStatuses.FirstOrDefault(s => s.Name == requestStatusName) ?? context.RequestStatuses.FirstOrDefault();
                var requestType = context.RequestTypes.FirstOrDefault(t => t.Name == requestTypeName) ?? context.RequestTypes.FirstOrDefault();

                var request = new MediaRequest
                {
                    RequestTitle = requestTitle,
                    ReceivedOn = receivedOn,
                    Deadline = deadline,
                    LeadMinistryId = leadMinistry?.Id,
                    RequestorContactId = requestorContact.Id,
                    RequestorOutletId = requestorOutlet?.Id,
                    AssignedUserId = assignedUser?.Id,
                    RequestStatusId = requestStatus?.Id,
                    RequestTypeId = requestType?.Id,
                    RequestNo = nextRequestNo++ // Always generate unique integer
                };
                context.MediaRequests.Add(request);
            }
            context.SaveChanges();
        }
    }
}
