namespace FairFunds.Models
{
    public class Expenditure
    {
        public int ExpenditureID { get; set; }
        public string Title { get; set; }
        public DateOnly Date { get; set; }
        public string Debtor { get; set; }
        public List<string> Creditors { get; set; }
        public int Amount {  get; set; }
        public Category? Category { get; set; } 
    }
}
