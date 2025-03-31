namespace LibraryManagement.Api.DTO
{
    public class LoanResponseDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }

        public string AuthorName { get; set; }

    }
}
