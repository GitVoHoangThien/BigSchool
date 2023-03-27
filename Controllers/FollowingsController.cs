using BigSchool.DTOs;
using BigSchool.Models;
using Microsoft.Owin;
using Microsoft.VisualBasic.ApplicationServices;
using Owin;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(BigSchool.Controllers.FollowingsController))]

namespace BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDTOs followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FollowerId == followingDto.FollowerId))
                return BadRequest("Following already axists");
            var folowing = new Following
            {
                FollowerId = userId,
                FollowerId = followingDto.FollowerId
            };

            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();

            return Ok();
        }

        private IHttpActionResult Ok()
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}
