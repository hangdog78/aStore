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

        [HttpGet(nameof(id))]
        [ActionName(nameof(GetQRById))]
        public async Task<IActionResult> GetQRById([FromRoute] int id)
        {
            var entity = await _context.QR.FindAsync(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<QR>> Post(QR value)
        {
            var entity = await _context.QR.AddAsync(value);
            await _context.SaveChangesAsync();
            var qrCode = QRCodeWriter.CreateQrCode(value.QrInfo, 300);
            qrCode.AddBarcodeValueTextBelowBarcode();
            qrCode.AddAnnotationTextAboveBarcode(entity.ToString());
            qrCode.SaveAsPng(@"D:\tor\Qr.png");


            return CreatedAtAction("GetQRById", new { id = entity.Entity.Id }, entity.Entity);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.QR.ToList());
        }

    }
}
