namespace Diary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class appointment
    {
        [Key]
        public int idAppointment { get; set; }

        public DateTime datHour { get; set; }

        public string timeSlotFull
        {
            get
            {
                return string.Format("{0}:{1}:{2}", datHour.Hour.ToString(), datHour.Minute.ToString(), datHour.Second.ToString());
            }
        }

        public string timeSlotHour
        {
            get
            {
                return string.Format(datHour.Hour.ToString());
            }
        }

        public string timeSlotMinute
        {
            get
            {
                return string.Format(datHour.Minute.ToString());
            }
        }

        [Column(TypeName = "text")]
        [Required]
        public string subject { get; set; }

        public int idBroker { get; set; }

        public int idCustomer { get; set; }

        public virtual broker broker { get; set; }

        public virtual customer customer { get; set; }
    }
}
