using System;
using System.ComponentModel.DataAnnotations;

namespace Project_2353.Entity.Entities
{
    public class _BaseEntity
    {
        [Key] public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}