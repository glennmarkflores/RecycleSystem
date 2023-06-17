using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RecycleSystem.DAL;
using System.ComponentModel;

namespace RecycleSystem.Models
{
    public class TypeModel : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Index("Ix_Type", Order = 1, IsUnique = true)]
        public string Type { get; set; }

        public decimal Rate { get; set; }

        [DisplayName("Minimum Kg")]
        public decimal MinKg { get; set; }

        [DisplayName("Maximum Kg")]

        public decimal MaxKg { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var validateName = db.Types.FirstOrDefault
            (x => x.Type == Type && x.Id != Id);
            if (validateName != null)
            {
                ValidationResult errorMessage = new ValidationResult
                ("Type name already exists.", new[] { "Type" });
                yield return errorMessage;
            }
            else
            {
                yield return ValidationResult.Success;
            }
        }
    }
}