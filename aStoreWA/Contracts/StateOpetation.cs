namespace aStoreServer.Contracts
{
    public interface StateOpetation
    {
        /*
        Модель данных "Статусы операции":
       - Идентификатор статуса операции
       - Название Операции
       */
        int id { get; }
        string name { get; }
    }
}
