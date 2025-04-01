namespace LibraryManagement.Api.DTO
{
    public class BookRequestDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public decimal Price { get; set; }
    }
}
