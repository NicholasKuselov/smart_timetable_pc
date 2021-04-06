namespace SmartTimetable.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("times")]
    public partial class times
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public times()
        {
            timetable = new HashSet<timetable>();
        }

        [Key]
        public int idtimes { get; set; }

        [Required]
        [StringLength(45)]
        public string timeFrom { get; set; }

        [Required]
        [StringLength(45)]
        public string timeTo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timetable> timetable { get; set; }
    }
}
