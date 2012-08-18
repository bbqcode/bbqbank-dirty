namespace bbqbank.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }

        public bool HasAlexisUsed { get; set; }
        public bool HasAudeUsed { get; set; }
        public bool HasMartinUsed { get; set; }

        public bool HasPST { get; set; }
        public bool HasFST { get; set; }

        public int BillId { get; set; }
        public virtual Bill Bill { get; set; }
    }

    public enum Category
    {
        
    }
}