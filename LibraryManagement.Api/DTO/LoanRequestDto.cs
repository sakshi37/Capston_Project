namespace LibraryManagement.Api.DTO
{
    public class LoanRequestDto
    {
        public int BookId { get; set; }
        public DateTime EndDate { get; set; }
    }
}
