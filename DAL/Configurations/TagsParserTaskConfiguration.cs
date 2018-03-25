using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models.Domain;

namespace DAL.Configurations
{
    public class TagsCounterTaskConfiguration : EntityTypeConfiguration<TagsCounterTask>
    {
        public TagsCounterTaskConfiguration()
        {
            HasKey(f => f.Id);
            Property(f => f.TrackingCode).IsRequired().HasMaxLength(450).HasColumnAnnotation(
        "Index",
        new IndexAnnotation(new IndexAttribute("TrackingCode") { IsUnique = true }));
        }
    }
}
