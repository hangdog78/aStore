using aStoreServer.Contracts;

namespace aStoreServer.Models
{
    public class GroupObject
    {
        public int id { get; }
        public string nameGroup { get; }
        public int number { get; set; } //���������� �������� � ������
        public List<AccountingObject> accountingObjects {get; set;} //��� ������ ���� ���� ��������         

    }
}