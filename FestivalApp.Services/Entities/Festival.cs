namespace FestivalApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Festival")]
    public partial class Festival
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Festival()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string StartDate { get; set; }

        [Required]
        [StringLength(50)]
        public string EndDate { get; set; }

        [Required]
        [StringLength(200)]
        public string LocationLatitude { get; set; }

        [Required]
        [StringLength(200)]
        public string LocationLongitude { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string TimeStart { get; set; }

        public string Description { get; set; }

        [StringLength(20)]
        public string Rating { get; set; }

        public int? NumberOfRates { get; set; }

        public string Image { get; set; }

        public int FestivalTypeId { get; set; }

        public virtual FestivalType FestivalType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<User> UserRated { get; set; }
    }
}
