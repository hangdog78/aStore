using aStoreServer.Models;
using System.Collections.Generic;

namespace aStoreServer.Contracts
{
    public interface ITrace
    {
        /*
        Модель данных "Маршрут":
       - Идентификатор маршрута
       - Идентификатор Продекта
       - Название маршрута
       - Описание маршрута
       - Дата начала маршрута
       - Дата изменения маршрута
       - Список операций, связанных с маршрутом (ссылка на модель данных "Операция")
       
       */
        int id { get; }
        int idProduct { get; }
        string name { get; }
        string description { get; }
        DateTime createdDate { get; }
        DateTime updatedDate { get; }
        List<Operation> operation { get; }

        //Операции
        ICollection<ITrace> GetTraceByIndex(int index);

      
    }
}
