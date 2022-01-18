using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CodeBridgeTestTask.Core.Entities
{
    public class Dog
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [DefaultValue("Scooby")]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [DefaultValue("orange")]
        public string Color { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [JsonPropertyName("tail_length")]
        [DefaultValue(1)]
        public int TailLength { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [DefaultValue(1)]
        public int Weight { get; set; }
    }
}
