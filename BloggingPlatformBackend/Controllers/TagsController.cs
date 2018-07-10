using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingPlatformBackend.Models;
using BloggingPlatformBackend.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly BloggingPlatformDB db;

        public TagsController(BloggingPlatformDB _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<TagView> Get()
        {
            TagView tagList = new TagView { Tags = db.Tags.Select(t => t.TagName) };
            return tagList;
        }
    }
}