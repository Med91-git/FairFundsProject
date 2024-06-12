namespace FairFunds.Models
{
    public class Expenditure
    {
        public int ExpenditureID { get; set; }
        public string Title { get; set; }
        public DateOnly Date { get; set; }

        public int Amount {  get; set; } 

        public int CategoryID { get; set; } 
    }
}
