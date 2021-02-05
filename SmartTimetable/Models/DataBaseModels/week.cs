namespace SmartTimetable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("week")]
    public partial class week
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public week()
        {
            timetable = new HashSet<timetable>();
        }

        [Key]
        public int idweek { get; set; }

        [Required]
        [StringLength(45)]
        public string dateFrom { get; set; }

        [Required]
        [StringLength(45)]
        public string dateTo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timetable> timetable { get; set; }
    }
}
