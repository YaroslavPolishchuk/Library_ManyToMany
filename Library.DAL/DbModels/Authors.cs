namespace Library.DAL.DbModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Authors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Authors()
        {
            Books = new HashSet<Books>();
        }

        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(128)]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(128)]
        public string AuthorLastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Books> Books { get; set; }
    }
}
