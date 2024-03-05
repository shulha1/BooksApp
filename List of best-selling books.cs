using Microsoft.Data.SqlClient;
using System.Data;
using System.DirectoryServices;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;

namespace BooksApp2
{
    public partial class BooksApp : Form
    {
        private BookAppDbContext _context;
        public BooksApp()
        {
            InitializeComponent();
            _context = new BookAppDbContext();

            CreatingDatabase.CreatingDatabaseMethod();
            FillinUpWithSimpleData.FillingData();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var books = _context.Books.ToList();

            dgv1.DataSource = books;

            dgv1.Columns[dgv1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ChangingTheColumnsName();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var books = _context.Books.ToList();

            var searchResult = textBox1.Text.ToLower();

            if (string.IsNullOrEmpty(searchResult))
            {
                ErrorHandler();
            }
            else
            {
                foreach (var book in books)
                {
                    if (book.BookName.ToLower().Contains(searchResult))
                        SearchByName(searchResult);

                    if (book.BookGenre.ToLower().Contains(searchResult))
                        SearchByGenre(searchResult);

                    if (book.YearPublished.ToString().Contains(searchResult))
                        SearchByYear(searchResult);

                    if (book.ApproximateSales.ToLower().Contains(searchResult))
                        SearchBySales(searchResult);

                    if (book.OriginalLanguage.ToLower().Contains(searchResult))
                        SearchByLanguage(searchResult);

                    if (book.Author.ToLower().Contains(searchResult))
                        SearchByAuthor(searchResult);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToString();

        }

        public void ChangingTheColumnsName()
        {
            dgv1.Columns["BookId"].HeaderText = "Book Id";
            dgv1.Columns["BookName"].HeaderText = "Book Name";
            dgv1.Columns["BookGenre"].HeaderText = "Book Genre";
            dgv1.Columns["ApproximateSales"].HeaderText = "Approximate Sales(In millions of copies)";
            dgv1.Columns["Author"].HeaderText = "Author(s)";
            dgv1.Columns["OriginalLanguage"].HeaderText = "Original Language";
            dgv1.Columns["YearPublished"].HeaderText = "Year Published";
        }

        private void ErrorHandler()
        {
            string searchResult = textBox1.Text.ToLower();

            errorProvider1.Clear();

            if (string.IsNullOrEmpty(searchResult))
            {
                errorProvider1.SetError(textBox1, "Please enter a search term.");

                return;
            }
        }

        public void SearchByName(string searchResult)
        {
            var books = _context.Books.ToList();

            var results = books.Where(books => books.BookName.ToLower().Contains(searchResult)).ToList();

            dgv1.DataSource = results;

            ChangingTheColumnsName();
        }

        private void SearchByGenre(string searchResult)
        {
            var books = _context.Books.ToList();

            var results = books.Where(books => books.BookGenre.ToLower().Contains(searchResult)).ToList();

            dgv1.DataSource = results;

            ChangingTheColumnsName();
        }

        private void SearchByYear(string searchResult)
        {
            var books = _context.Books.ToList();

            var results = books.Where(books => books.YearPublished.ToString().Contains(searchResult)).ToList();

            dgv1.DataSource = results;

            ChangingTheColumnsName();

        }

        private void SearchBySales(string searchResult)
        {
            var books = _context.Books.ToList();

            var results = books.Where(books => books.ApproximateSales.ToLower().Contains(searchResult)).ToList();

            dgv1.DataSource = results;

            ChangingTheColumnsName();

        }

        private void SearchByLanguage(string searchResult)
        {
            var books = _context.Books.ToList();

            var results = books.Where(books => books.OriginalLanguage.ToLower().Contains(searchResult)).ToList();

            dgv1.DataSource = results;

            ChangingTheColumnsName();
        }

        private void SearchByAuthor(string searchResult)
        {
            var books = _context.Books.ToList();

            var results = books.Where(books => books.Author.ToLower().Contains(searchResult)).ToList();

            dgv1.DataSource = results;

            ChangingTheColumnsName();
        }
    }
}
