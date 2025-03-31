namespace LibraryManagement.Api.DTO
{
    public class LoanRequestDto
    {
        //this is temp this will be remove once jwt implement
        public string UserId { get; set; }
        public int BookId { get; set; }

        public DateTime EndDate { get; set; }
    }
}
