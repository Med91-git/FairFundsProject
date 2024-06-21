using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FairFunds.Models
{
    public class Expenditure
    {
        public int ExpenditureID { get; set; }

        public string Title { get; set; }
        public DateOnly Date { get; set; } 
        public int Amount {  get; set; }

        [ForeignKey("Category")] 
        public int CategoryID { get; set; }

        public Category Category { get; set; }


        [ForeignKey("CustomUser")]
        public string customuserId { get; set; }

        public CustomUser CustomUser { get; set; }



    }
}
