using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Api
{
    public class CreateTagsParserTaskModel : IValidatableObject
    {
        [Required]
        public string Url { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (!Uri.IsWellFormedUriString(this.Url, UriKind.Absolute))
            {
                errors.Add(new ValidationResult("Provide correct url, please"));
            }
            return errors;
        }
    }
}