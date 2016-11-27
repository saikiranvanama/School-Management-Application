using System;
using System.Linq;
using System.Windows;

namespace LabAssignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Query1_Click(object sender, RoutedEventArgs e)
        {
            //Get a list of all the titles and the authors who wrote them.
            //Sort the result by title.
            LabAssignment_4 dc = new LabAssignment_4();
            var authorsAndISBNs = from author in dc.Authors
                                  from book in author.Titles
                                  orderby book.Title1
                                  select new { book.Title1, author.FirstName, author.LastName };
            DisplayBox.Text = "Get a list of all the titles and the authors who wrote them.\n";
            foreach (var element in authorsAndISBNs)
            {
                DisplayBox.AppendText(String.Format("{0,-10} {1,-10} {2}\n", element.Title1, element.FirstName, element.LastName));
            }
        }

        private void Query2_Click(object sender, RoutedEventArgs e)
        {
            //Get a list of all the titles and the authors who wrote them. 
            //Sort the result by title. For each title sort the authors alphabetically 
            //by last name, then first name.
            LabAssignment_4 dc = new LabAssignment_4();
            var authorTitles = from author in dc.Authors
                               from book in author.Titles
                               orderby book.Title1, author.LastName, author.FirstName
                               select new { book.Title1, author.LastName, author.FirstName };

            DisplayBox.Text = "Get a list of all the titles and the authors who wrote them.\n";
            foreach (var element in authorTitles)
            {
                DisplayBox.AppendText(String.Format("{0,-10} {1,-10} {2}\n", element.Title1, element.FirstName, element.LastName));
            }
        }

        private void Query3_Click(object sender, RoutedEventArgs e)
        {
            //Get a list of all the authors grouped by title, sorted by title;
            //for a given title sort the author names alphabetically by last name first then first name.
            LabAssignment_4 dc = new LabAssignment_4();
            var titlesByAuthor = from books in dc.Titles
                                 orderby books.Title1
                                 select new
                                 {
                                     Title = books.Title1,
                                     Authors = from authors in books.Authors
                                               orderby authors.LastName, authors.FirstName
                                               select new
                                               {
                                                   authors.LastName,
                                                   authors.FirstName
                                               }
                                 };




            DisplayBox.Text = "Get a list of all the titles and group by authors who wrote them.\n";
            // display titles written by each author, grouped by author
            foreach (var title in titlesByAuthor)
            {
                // display titles written by that author
                DisplayBox.AppendText("\r\n\t" + title.Title + ":");

                // display author's name
                foreach (var names in title.Authors)
                {
                    DisplayBox.AppendText("\r\n\t\t" + names.FirstName + " " + names.LastName);
                }
            }
        }
    }
}
