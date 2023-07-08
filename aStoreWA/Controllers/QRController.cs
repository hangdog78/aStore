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
        [HttpPost("generate")]
        public async Task<ActionResult> CreateQr(int EntityId)
        {
            var entity = await _context.Entity.FirstAsync(val => val.Id == EntityId);

            if (entity == null)
            {
                return BadRequest("Сущность не найдена");
            }
            else
            {
                var filePath = $"qrCodes/{entity.Id + entity.Name + entity.Description}.png";

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
        }
    }

}
