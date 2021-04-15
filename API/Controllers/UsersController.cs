using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        //Task for async
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUser(){
            // IEnumerable itu mirip dengan List tetapi Lebih propriate pake List juga bisa kok
            
            return await _dataContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id){
            return await _dataContext.Users.FindAsync(id);   
        }
    }
}