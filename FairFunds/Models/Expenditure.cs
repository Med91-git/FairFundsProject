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

        [ForeignKey("CategoryID")]

        public Category Category { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("customuserId")]
        public CustomUser CustomUser { get; set; }

        public string customuserId { get; set; }


    }
}
