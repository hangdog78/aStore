using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using aStoreServer.Contracts;

namespace aStoreServer.Models
{
    public class Operation : IOperation
    {
        public int idOperation { get; }

        public Destanation destanationOperation { get; }

        public DateTime dateCreation { get; }

        public StateOpetation stateOperation { get; }

        public string nameOperation { get; }

        
    }

}
