using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agenzilla.Data;
using Agenzilla.Models;
using Microsoft.EntityFrameworkCore;
using static Agenzilla.Models.AddUserRequest;
using System.Net;
using System.Xml.Linq;

namespace Agenzilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WebApiDbContext dbContext;

        public UserController(WebApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
           
            return Ok(dbContext.user.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await dbContext.user.FindAsync(id);

            if (user == null)
            {
                return NotFound();

            }

            return Ok(user);

        }


            [HttpPost]

        public async Task<IActionResult>AddUser(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                userID = Guid.NewGuid(),
                address = addUserRequest.address,
                email = addUserRequest.email,
                fName = addUserRequest.fName,
                Lname = addUserRequest.Lname,
                nic = addUserRequest.nic,
                phoneNo = addUserRequest.phoneNo,
                userName = addUserRequest.userName,
                userType = addUserRequest.userType

            };

            await dbContext.user.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest updateUserRequest)
        {
            var user = await dbContext.user.FindAsync(id);

            if (user != null) 
            {
                user.address = updateUserRequest.address;
                user.email = updateUserRequest.email;
                user.fName = updateUserRequest.fName;
                user.Lname = updateUserRequest.Lname;
                user.nic = updateUserRequest.nic;
                user.phoneNo = updateUserRequest.phoneNo;
                user.userName = updateUserRequest.userName;
                user.userType = updateUserRequest.userType;

                await dbContext.SaveChangesAsync();

                return Ok(user);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var user = await dbContext.user.FindAsync(id);
            if (user != null)
            { 
            
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);

            }

            return NotFound();
        }
    }
}
