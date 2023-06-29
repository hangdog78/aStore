using System.ComponentModel.DataAnnotations;
using aStoreServer.Contracts;

namespace aStoreServer.Models
{
    public class Trace : ITrace
    {
        public int id { get;}
        public int idProduct { get;}
        public string name { get; }
        public string description { get; }
        public DateTime createdDate { get; }
        public DateTime updatedDate { get; }
        public List<Operation> operation { get; }

        ICollection<ITrace> ITrace.GetTraceByIndex(int index)
        {
            throw new NotImplementedException();
        }
    }
}
