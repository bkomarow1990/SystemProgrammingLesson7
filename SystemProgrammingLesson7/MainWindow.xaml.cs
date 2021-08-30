using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SystemProgrammingLesson7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookDBModel bm = new BookDBModel();
        public MainWindow()
        {
            InitializeComponent();
            authorsComboBox.ItemsSource = bm.Authors.ToList();
            authorsComboBox.SelectedValuePath = nameof(Author.Id);
            
        }
        private Task<List<Book>> GetBooksWithAuthorAsync(int authorId) {
            return Task.Run(()=> {
                return bm.Books.Where((el) => el.AuthorId == authorId).ToListAsync();
            });
        }
        private async void booksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private async void authorsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (authorsComboBox.SelectedItem == null)
            {
                return;
            }
            int id = (int)authorsComboBox.SelectedValue;
            booksListBox.ItemsSource = await bm.Books.Where((el) => el.AuthorId == id).ToListAsync();
        }

        private async void findBtn_Click(object sender, RoutedEventArgs e)
        {
            booksListBox.ItemsSource = await bm.Books.Where((el) => el.Name.Contains(nameTxtBox.Text)).ToListAsync();
        }
    }
}
