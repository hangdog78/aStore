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
        private readonly ApplicationContext _context;
        public QRController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpPost("create")]
        public async Task<ActionResult> Post(string _fileName, string valueToEncode)
        {
            var filePath = $"qrCodes/{_fileName}";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            byte[] bytes = encoding.GetBytes(valueToEncode);
            GeneratedBarcode BarCode = BarcodeWriter.CreateBarcode(bytes, BarcodeWriterEncoding.QRCode);
            BarCode.SaveAsPng($"qrCodes/{_fileName}.png");
 
            return CreatedAtAction("GetFile", new { fileName = _fileName }, _fileName);

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
