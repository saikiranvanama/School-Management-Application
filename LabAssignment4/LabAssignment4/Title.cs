namespace LabAssignment4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Title
    {
        public Title()
        {
            Authors = new HashSet<Author>();
        }

        [Key]
        [StringLength(20)]
        public string ISBN { get; set; }

        [Column("Title")]
        [Required]
        [StringLength(100)]
        public string Title1 { get; set; }

        public int EditionNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string Copyright { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
