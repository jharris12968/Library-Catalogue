namespace _16__Library
{
    /*Step 1 - Creates a class titled "Book" which encloses the properties Title, Author, ISBN, and PublishedYear
    This includes a ToString Method that returns a string represnetation of the book information entered*/
    class Book
    {
        //"?'s" are used to create nullable values - voiding any possible issue that would arise converting to a non-nullable
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public int PublishedYear { get; set; }

        public override string ToString()
        {
            return "Title: " + Title + " Author: " + Author + " ISBN: " + ISBN + " Published Year: " + PublishedYear;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Book> catalogue = new List<Book>(); //List created to store and manage the user inputs

            Console.WriteLine("Library Catalogue System");

            /*Step 2 - Implement user interaction 
             * On the front end WriteLine 1-4 are displayed for the user to see the options;
             * The while loop creates a range between 1 and 4, limiting the user input regarding the options;
             * The switch case outlines the options in the order displayed to the user, without directly connecting any functionality to the WriteLines;
             * Option 4 displays "Goodbye" and uses the latter half of the do loop to terminate the program
             */  
            
            int choice;
            do
            {
                //Prompts user will be displayed in the console
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Display All Books");
                Console.WriteLine("3. Search by Title");
                Console.WriteLine("4. Exit");
                Console.Write("Please choose an option: ");

                //Sets the range of user input to 1-4
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    Console.Write("Please choose an option: ");
                }
                Console.WriteLine(); //Adds space in console for clarity

                //Gives "functionality" to the prompts the user will select from
                switch (choice)
                {
                    case 1:
                        AddBook(catalogue);
                        break;
                    case 2:
                        DisplayAllBooks(catalogue);
                        break;
                    case 3:
                        SearchByTitle(catalogue);
                        break;
                    case 4:
                        Console.WriteLine("Goodbye.");
                        break;
                }

            } while (choice != 4); //Terminates program
        }

        //Method to add a new book to the catalogue by calling the infomation input to the list
        static void AddBook(List<Book> catalogue)
        {
            //Inputs for the new book
            Console.Write("Enter book title: ");        //Title
            string ?title = Console.ReadLine();
            Console.Write("Enter author name: ");       //Author
            string ?author = Console.ReadLine();
            Console.Write("Enter ISBN: ");              //ISBN  
            string ?isbn = Console.ReadLine();
            Console.Write("Enter published year: ");    //Year
            int year;
        
            //Defensive Programming preventing an invalid input
            while (!int.TryParse(Console.ReadLine(), out year) || year < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid year.");
                Console.Write("Please enter the year published: ");
            }
            Console.WriteLine(); //Adds space in console for clarity

            //Sets the user inputs equal to the variables set in the Book Class
            Book newBook = new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                PublishedYear = year
            };

            //Adds the inputs to the the catalogue as a new book
            catalogue.Add(newBook);
            Console.WriteLine("Book added successfully!");
        }

        //Method to display all of the books input by the user (references option 2)
        static void DisplayAllBooks(List<Book> catalogue)
        {
            Console.WriteLine("Books in Catalogue:");
            foreach (var book in catalogue) //Displays all "book" variables in the catalogue (list)
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine();
        }
        
        /*Method to search by title (references option 3)
         "book" is set as a variable to be searched in the catalogue;
         where "book" is set to the "Title" string to search the pre-existing inputs within the list;
         all set equal to "searchTitle", which is the string for the user input search - which will either 
         be found or !found.*/
        static void SearchByTitle(List<Book> catalogue)
        {
            Console.Write("Please enter the book title: ");
            string? searchTitle = Console.ReadLine();
            Console.WriteLine(); //Adds space in console for clarity

            bool found = false;
            foreach (var book in catalogue) //Foreach is used to go through the list to locate the string being referenced in the search
            {
                if (book.Title?.ToLower() == searchTitle) //book.Title is = to searchTitle to locate a pre-existing title in the string
                {
                    Console.WriteLine("Book found: ");
                    Console.WriteLine(book.ToString());
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Book not found.");
            }
            Console.WriteLine(); //Adds space in console for clarity
        }
    }
}
