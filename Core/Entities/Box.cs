using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Box: BaseEntity
    {
        public string Code { get; set; }
        public string DestructionFlag { get; set; }
        public string Reference { get; set; }
        public DateTimeOffset? DateLeftOffice { get; set; }
        public string Comments { get; set; }
        public ICollection<Policy> Policies { get; set; }
    }
}