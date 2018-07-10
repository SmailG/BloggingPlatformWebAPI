using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingPlatformBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly BloggingPlatformDB db;

        public CommentController(BloggingPlatformDB _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tag>> Get()
        {
            return db.Tags.ToList();
        }
    }
}