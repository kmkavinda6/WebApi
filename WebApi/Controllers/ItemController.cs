using Agenzilla.Data;
using Agenzilla.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Xml.Linq;

namespace Agenzilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly WebApiDbContext dbContext;

        public ItemController(WebApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {

            return Ok(dbContext.item.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetItem([FromRoute] Guid id)
        {
            var item = await dbContext.item.FindAsync(id);

            if (item == null)
            {
                return NotFound();

            }

            return Ok(item);

        }


        [HttpPost]

        public async Task<IActionResult> AddItem(Item addItemRequest)
        {
            var item = new Item()
            {
                itemID = Guid.NewGuid(),
                batchID = addItemRequest.batchID,
                expDate = addItemRequest.expDate,
                name = addItemRequest.name,
                price = addItemRequest.price,
                qty = addItemRequest.qty
                
            };

            await dbContext.item.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return Ok(item);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateItem([FromRoute] Guid id, Item updateItemRequest)
        {
            var item = await dbContext.item.FindAsync(id);

            if (item != null)
            {
                
                item.batchID = updateItemRequest.batchID;
                item.expDate = updateItemRequest.expDate;
                item.name = updateItemRequest.name;
                item.price = updateItemRequest.price;
                item.qty = updateItemRequest.qty;

                await dbContext.SaveChangesAsync();

                return Ok(item);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteItem([FromRoute] Guid id)
        {
            var item = await dbContext.item.FindAsync(id);
            if (item != null)
            {

                dbContext.Remove(item);
                await dbContext.SaveChangesAsync();
                return Ok(item);

            }

            return NotFound();
        }
    }
}
