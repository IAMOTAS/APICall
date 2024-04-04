using System;
using System.ComponentModel.DataAnnotations;

namespace APICall.Models
{
    public class Translation
    {
        public int Id { get; set; }

        [Required]
        public string OriginalText { get; set; }

        [Required]
        public string TranslatedText { get; set; }

        [Required]
        public DateTime TranslationDate { get; set; }
    }
}
