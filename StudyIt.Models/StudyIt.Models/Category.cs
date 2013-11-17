using System;
using System.Collections.Generic;

namespace StudyIt.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Subcategories = new List<Subcategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
