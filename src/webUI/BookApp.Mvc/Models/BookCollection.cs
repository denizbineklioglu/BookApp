using BookApp.DataTransferObjects.Responses;

namespace BookApp.Mvc.Models
{
    public class BookCollection
    {
        public List<BookItem> BookItems { get; set; } = new List<BookItem>();

        public void ClearAll() => BookItems.Clear();
        public decimal TotalBookPrice() => BookItems.Sum(b => b.Quantity);

        public void AddNewBook(BookItem bookItem)
        {
            var exist = BookItems.FirstOrDefault(b => b.Book.BookId == bookItem.Book.BookId);
            if (exist != null)
            {
                exist.Quantity += bookItem.Quantity;
            }
            else
            {
                BookItems.Add(bookItem);
            }
        }
    }

    public class BookItem
    {
        public BookDisplayResponse Book { get; set; }
        public int Quantity { get; set; }
    }
}
