using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    public class AccountDetail
    {
        public int Id { get; set; }
        public string AccountHolderName { get; set; }
        public long AccountNumber{get;set;}
        public string AccountType { get; set; }
        public string BranchName { get; set; }
        public int IfscCode { get; set; }
        public long Balance { get; set; }
    }
}
