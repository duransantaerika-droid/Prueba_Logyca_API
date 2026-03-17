using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Code
    {
        public int Id { get; set; }

        // Representa el ID de la empresa (Foreign Key)
        public int Owner { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Mapeo explícito a la propiedad Owner
        [ForeignKey("Owner")]
        public Enterprise? Enterprise { get; set; }
    }
}
