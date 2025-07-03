using Microsoft.EntityFrameworkCore;
using Gcpe.MediaHub.API.Models;

namespace Gcpe.MediaHub.API.Data
{
    public class GcpeMediaHubAPIContext : DbContext
    {
        public GcpeMediaHubAPIContext(DbContextOptions<GcpeMediaHubAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MediaContact> MediaContacts { get; set; } = default!;
        public DbSet<MediaOutlet> MediaOutlets { get; set; } = default!;
        public DbSet<MediaOutletPhoneNumber> MediaOutletPhoneNumbers { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<MediaContactEmail> MediaContactEmails { get; set; } = default!;
        public DbSet<MediaContactPhone> MediaContactPhone { get; set; } = default!;
        public DbSet<MediaType> MediaTypes { get; set; } = default!;
        public DbSet<MediaOutletPhoneType> MediaOutletPhoneTypes { get; set; } = default!;
        public DbSet<MediaContactPhoneType> MediaContactPhoneTypes { get; set; } = default!;
        public DbSet<PhoneNumber> PhoneNumbers { get; set; } = default!;
        public DbSet<WrittenLanguage> WrittenLanguages { get; set; } = default!;
        public DbSet<SpokenLanguage> SpokenLanguages { get; set; } = default!;
        public DbSet<JobTitle> JobTitles { get; set; } = default!;
        public DbSet<SocialMedia> SocialMedias { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<MediaRequest> MediaRequests { get; set; } = default!;
        public DbSet<RequestStatus> RequestStatuses { get; set; } = default!;
        public DbSet<RequestType> RequestTypes { get; set; } = default!;
        public DbSet<RequestResolution> RequestResolutions { get; set; } = default!;
        public DbSet<Ministry> Ministries { get; set; } = default!;
        public DbSet<SocialMediaCompany> SocialMediaCompanies { get; set; } = default!;
        public DbSet<MediaOutletContactRelationship> MediaOutletContactRelationship { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MediaRequest>()
                .HasOne(mr => mr.LeadMinistry)
                .WithMany(m => m.LeadMediaRequests)
                .HasForeignKey(mr => mr.LeadMinistryId);

            modelBuilder.Entity<MediaRequest>()
                .HasMany(mr => mr.AdditionalMinistries)
                .WithMany(m => m.AdditionalMediaRequests)
                .UsingEntity(j => j.ToTable("MediaRequestAdditionalMinistries"));

            modelBuilder.Entity<MediaRequest>()
                .HasOne(m => m.FYIContactUser)
                .WithMany()
                .HasForeignKey(m => m.FYIContactUserId);

            modelBuilder.Entity<SocialMedia>()
                .HasOne(sm => sm.MediaOutlet)
                .WithMany(o => o.SocialMedias)
                .HasForeignKey(sm => sm.MediaOutletId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MediaOutletPhoneNumber>()
                .HasOne(ph => ph.MediaOutlet)
                .WithMany(o => o.MediaOutletPhoneNumbers)
                .HasForeignKey(ph => ph.MediaOutletId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SocialMedia>()
                .HasOne(sm => sm.MediaContact)
                .WithMany(c => c.SocialMedias)
                .HasForeignKey(sm => sm.MediaContactId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MediaContactPhone>()
                .HasOne(p => p.OutletContactRelationship)
                .WithMany(rel => rel.PhoneNumbers)
                .HasForeignKey(p => p.OutletContactRelationshipId);

            modelBuilder.Entity<MediaContactEmail>()
                .HasOne(p => p.OutletContactRelationship)
                .WithMany(rel => rel.Emails)
                .HasForeignKey(p => p.OutletContactRelationshipId);

            modelBuilder.Entity<MediaOutlet>()
                .HasOne(m => m.ParentOutlet)
                .WithMany(m => m.ChildOutlets)
                .HasForeignKey(m => m.ParentOutletId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
