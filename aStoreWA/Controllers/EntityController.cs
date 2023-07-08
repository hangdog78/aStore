
using System.Text;
using aStoreServer.Controllers.Dto;
using aStoreServer.Models;
using IronBarCode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aStoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public EntityController(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Создать объект и qr-code
        /// </summary>
        [HttpPost("create")]
        [ActionName("UpdateOrInsert")]
        public async Task<ActionResult> UpdateOrInsert([FromBody] Entity value)
        {
            var entity = (await _context.Entity.AddAsync(value)).Entity;

            await _context.SaveChangesAsync();


            var filePath = $"qrCodes/{entity.Id + entity.Name + entity.Description}.png";
            var Qr = new QR
            {
                Name = entity.Name,
                Description = entity.Description,
                EntityId = entity.Id,
                Path = filePath
            };
            var DataToEncode = new QrDto
            {
                Name = entity.Name,
                Description = entity.Description,
                EntityId = entity.Id
            };
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            byte[] bytes = encoding.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(DataToEncode));
            GeneratedBarcode BarCode = BarcodeWriter.CreateBarcode(bytes, BarcodeWriterEncoding.QRCode);
            BarCode.SaveAsPng(filePath);
            return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", $"{entity.Id + entity.Name + entity.Description}.png");


        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entity>> Delete(int id)
        {
            var entity = await _context.Entity.FindAsync(id);
            if (entity != null)
            {
                var listQr = _context.Qr.Select(r => r.Entity.Id);
                List<QR> roles = _context.Qr.Where(r => listQr.Contains(r.Entity.Id)).ToList();
                roles?.ForEach(val => _context.Qr.Remove(val));
                _context.Entity.Remove(entity);
                _context.SaveChanges();
                return Ok(entity);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
