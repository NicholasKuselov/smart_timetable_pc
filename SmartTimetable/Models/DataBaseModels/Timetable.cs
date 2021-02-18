namespace SmartTimetable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("timetable")]
    public partial class timetable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idtimetable { get; set; }

        public int Subject { get; set; }

        [Required]
        [StringLength(45)]
        public string Date { get; set; }

        [Required]
        [StringLength(45)]
        public string Time { get; set; }

        public int Day { get; set; }

        public int Week { get; set; }

        public int Teacher { get; set; }

        public int Group { get; set; }

        public int Course { get; set; }

        public virtual course course1 { get; set; }

        public virtual day day1 { get; set; }

        public virtual group group1 { get; set; }

        public virtual subject subject1 { get; set; }

        public virtual teacher teacher1 { get; set; }

        public virtual week week1 { get; set; }
    }
}
