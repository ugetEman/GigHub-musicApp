using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    // composite model is used inorder to access directly the attendee
    public class Attendance
    {
        public Gig Gig { get; set; }

        [Key]
        [Column(Order = 1)]
        public int GigId { get; set; }

        public ApplicationUser Attendee { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}