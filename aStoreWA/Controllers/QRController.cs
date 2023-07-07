using System;
using System.Text;
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
        public class BacrodeQrDto
        {
            public string _fileName { get; set; }
            public string valueToEncode { get; set; }
        } 
        private readonly ApplicationContext _context;
        public QRController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpPost("create")]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status201Created)]
        public async Task<ActionResult> Post([FromBody] BacrodeQrDto barcodeData)
        {
            var filePath = $"qrCodes/{barcodeData._fileName}.png";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            byte[] bytes = encoding.GetBytes(barcodeData.valueToEncode);
            GeneratedBarcode BarCode = BarcodeWriter.CreateBarcode(bytes, BarcodeWriterEncoding.QRCode, 10000, 10000);
            BarCode.SaveAsPng($"qrCodes/{barcodeData._fileName}.png");
 
            return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", $"{barcodeData._fileName}.png");

        }
        [HttpGet("fileName")]
        [ActionName(nameof(GetFile))]
        [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> GetFile(string fileName)
        {
            var filePath = $"qrCodes/{fileName}.png"; 
            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest();
            }
            return File(await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", $"{fileName}.png");
        }
    }
}
