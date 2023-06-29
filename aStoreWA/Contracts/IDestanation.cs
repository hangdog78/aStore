namespace aStoreServer.Contracts
{
    public interface IDestanation
    {
        /*
        Модель данных "Точка учета":
        - ID точки учета (уникальный идентификатор)
        - Название точки учета
        */
        int destId { get; }
        string destName { get; }

    }
}
