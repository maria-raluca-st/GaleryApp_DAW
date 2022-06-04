using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_proiect.BLL.Interfaces;
using WebApplication_proiect.DAL;
using WebApplication_proiect.DAL.Entities;
using WebApplication_proiect.DAL.Interfaces;

namespace WebApplication_proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhibitionsController : ControllerBase
    {
       
        private readonly IExhibitionManager _exhibitionManager;

        public ExhibitionsController(IExhibitionManager exhibitionManager)
        {
            
            _exhibitionManager = exhibitionManager;
        }

        [HttpGet("get-modify")]
        public async Task<IActionResult> GetModify()
        {
            var list = await _exhibitionManager.ModifyExhibition();
            return Ok(list);
        }

    }
}
