using aStoreServer.Contracts;

namespace aStoreServer.Models
{
    public class AccountingObject: IAccountingObject
    {
        public int id { get;}
        public string name { get; }
        public Destanation firstPlace { get; set; } // тип данных точка маршрута

    }
}
