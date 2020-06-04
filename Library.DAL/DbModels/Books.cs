namespace Library.DAL.DbModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            Authors = new HashSet<Authors>();
        }

        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(128)]
        public string BookName { get; set; }

        public int PublishYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Authors> Authors { get; set; }
    }
}
