using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long? Nit { get; set; }
        public long Gln { get; set; }

        // Relación inversa
        public ICollection<Code> Codes { get; set; } = new List<Code>();
    }
}
