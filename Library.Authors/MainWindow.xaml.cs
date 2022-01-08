using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.Data;
using System.Windows;
using System.Linq;
using System.Data;
using Library.Models;


namespace Library.Authors
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BooksDbContext _context;
        public MainWindow()
        {
            _context = new BooksDbContext();
            InitializeComponent();
            GetAuthors();
        }

        private void GetAuthors()
        {
            AuthorsDataGrid.ItemsSource = _context.Authors.ToList();
        }
        private void AddAuthor()
        {
            var window = new EditAuthorWindow(new Author());
            if (window.ShowDialog() == true)
            {
                _context.Authors.Add(window.Author);
                _context.SaveChanges();
            }
        }
        private void ModifyAuthor(Author author)
        {
            var window = new EditAuthorWindow(author);
            if (window.ShowDialog() == true)
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
            }
        }
        private void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        private void NewAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            AddAuthor();
            GetAuthors();
        }

        private void ModifyAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            Author author = (Author)AuthorsDataGrid.SelectedItem;
            if (author != null)
            {
                ModifyAuthor(author);
                GetAuthors();
            }
        }

        private void DeleteAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            Author author = (Author)AuthorsDataGrid.SelectedItem;
            if (author != null)
            {
                DeleteAuthor(author);
                GetAuthors();
            }
        }
    }
}
