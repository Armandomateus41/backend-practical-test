namespace BackendPracticalTest.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}
