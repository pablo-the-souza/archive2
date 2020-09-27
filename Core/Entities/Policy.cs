using System;

namespace Core.Entities
{
    public class Policy: BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string PolicyType { get; set; }
        public string PolicyNumber { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset? DateEnd { get; set; }
        public string Comments { get; set; }
        public int BoxId { get; set; }
        public Box Box { get; set; }
    }
}