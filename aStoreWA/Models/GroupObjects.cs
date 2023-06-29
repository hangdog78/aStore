using aStoreServer.Contracts;

namespace aStoreServer.Models
{
    public class GroupObject
    {
        public int id { get; }
        public string nameGroup { get; }
        public int number { get; set; } //количество объектов в группе
        public List<AccountingObject> accountingObjects {get; set;} //тут должен быть лист объектов         

    }
}