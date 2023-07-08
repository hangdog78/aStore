using System;
using System.Text;
using aStoreServer.Controllers.Dto;
using aStoreServer.Models;
using IronBarCode;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aStoreServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class QRController : Controller
    {
        private readonly ApplicationContext _context;
        public QRController(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить Qrcode по id объекта
        /// </summary>
        [HttpGet("id")]
        [ActionName(nameof(GetQrCode))]
        public async Task<ActionResult> GetQrCode(int id)
        {
            var entity = await _context.Qr.FirstAsync(val => val.EntityId == id); ;
            if (entity != null)
            {

                if (!System.IO.File.Exists(entity.Path))
                {
                    return BadRequest("File not exist");
                }

                return File(await System.IO.File.ReadAllBytesAsync(entity.Path), "application/octet-stream", $"{entity.Description + entity.Name}.png");
            }
            else
            {
                return NotFound();
            }
        }
    }

}
