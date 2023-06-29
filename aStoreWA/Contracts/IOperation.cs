using aStoreServer.Models;

namespace aStoreServer.Contracts
{
    public interface IOperation
    {
        /*
        Модель данных "Операция":
        - ID Операции (уникальный идентификатор)
        - Местоположение проводимой операции
        - Название точки учета
        - Время созданной операции
        - Статус операции
        */
        int idOperation { get; }
        Destanation destanationOperation { get; }
        string nameOperation { get; }
        DateTime dateCreation { get; }
        StateOpetation stateOperation { get; }

        //Операции

    }
}
