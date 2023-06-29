using aStoreServer.Models;

namespace aStoreServer.Contracts
{
    public interface IAccountingObject
    {
        /*
         Модель данных Объект
        - ID Объект (уникальный идентификатор)
        - Название объекта
        - Название точки учета
         */

        public int id { get; }
        public string name { get; }
        public Destanation firstPlace { get; }
    }
}
