﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Context;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
