using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Entities
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        public string AccountHolderName { get; set; }
        public long AccountNumber{get;set;}
        public string AccountType { get; set; }
         public string BranchName { get; set; }
        public int IfscCode { get; set; }
        public long Balance { get; set; }
    }
}