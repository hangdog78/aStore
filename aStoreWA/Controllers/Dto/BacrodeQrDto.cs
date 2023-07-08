namespace aStoreServer.Controllers.Dto
{
    public interface BarcodeQrDto
    {
        public string FileName { get; set; }
        public string ValueToEncode { get; set; }
    }
}
