namespace FairFunds.Models
{
    public class Depense
    {
        public int DepenseID { get; set; }
        public string Titre { get; set; }
        public DateOnly Date { get; set; }

        public int Montant {  get; set; } 

        public int CategorieID { get; set; }
    }
}
