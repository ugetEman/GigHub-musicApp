using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {

        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }


        //asp.net web api by default doesn't look for a scalar parameter like integer
        // in the request body. It expects to be in the URL. So we need to decorate it by FromBody
        //[HttpPost]
        //public IHttpActionResult Attend([FromBody] int gigId)
        //{
        //    var userId = User.Identity.GetUserId();

        //    var exists = _context.Attendances
        //        .Any(a => a.AttendeeId ==userId  && a.GigId == gigId);

        //    if (exists)
        //        return BadRequest("The attendance already exists.");

        //    var attendance = new Attendance
        //    {
        //        GigId = gigId,
        //        AttendeeId = userId
        //    };

        //    _context.Attendances.Add(attendance);
        //    _context.SaveChanges();

        //    return Ok();
        //}


        //Dto stands for data transfer object
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Attendances
                .Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);

            if (exists)
                return BadRequest("The attendance already exists.");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
