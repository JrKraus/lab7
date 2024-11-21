using Blazor_Lab_Starter_Code;

namespace testproject4
{
    [TestClass]
    public class BookTests
    {
        [TestInitialize]
        public void InitializeBooksList()
        {
            // Initialize books list before each test
            MainCode.books = new List<Book>();
        }

        [TestMethod]
        public void VerifyBookAddition()
        {
            // Arrange
            int initialBookCount = MainCode.books.Count;
            var programmingBook = new Book
            {
                Id = 101,
                Title = "Python Programming",
                Author = "Sam Johnson",
                ISBN = "1111111111"
            };

            // Act
            MainCode.books.Add(programmingBook);

            // Assert
            Assert.IsTrue(MainCode.books.Count == initialBookCount + 1);
            Assert.AreEqual("Python Programming", MainCode.books[0].Title);
            Assert.AreEqual("Sam Johnson", MainCode.books[0].Author);
            Assert.AreEqual("1111111111", MainCode.books[0].ISBN);
        }

        [TestMethod]
        public void TestBookListing()
        {
            // Arrange
            MainCode.books.Add(new Book
            {
                Id = 102,
                Title = "JavaScript Programming",
                Author = "Emily Davis",
                ISBN = "2222222222"
            });
            MainCode.books.Add(new Book
            {
                Id = 103,
                Title = "Ruby Programming",
                Author = "David Lee",
                ISBN = "4444444444"
            });

            // Act
            var allBooks = MainCode.books;

            // Assert
            Assert.AreEqual(2, allBooks.Count);
            Assert.IsTrue(allBooks.Any(b => b.Title.Contains("JavaScript")));
            Assert.IsTrue(allBooks.Any(b => b.Title.Contains("Ruby")));
        }

        [TestMethod]
        public void ValidateBookUpdate()
        {
            // Arrange
            var swiftBook = new Book
            {
                Id = 104,
                Title = "Swift Programming",
                Author = "Sarah Taylor",
                ISBN = "5555555555"
            };
            MainCode.books.Add(swiftBook);

            // Act
            swiftBook.Title = "Advanced Swift Programming";
            swiftBook.Author = "James White";
            swiftBook.ISBN = "6666666666";

            // Assert
            var updatedBook = MainCode.books.FirstOrDefault(b => b.Id == 104);
            Assert.IsNotNull(updatedBook);
            Assert.IsTrue(updatedBook.Title.StartsWith("Advanced"));
            Assert.AreEqual("James White", updatedBook.Author);
            Assert.AreEqual("6666666666", updatedBook.ISBN);
        }

        [TestMethod]
        public void ConfirmBookDeletion()
        {
            // Arrange
            var kotlinBook = new Book
            {
                Id = 105,
                Title = "Kotlin Programming",
                Author = "Michael Brown",
                ISBN = "7777777777"
            };
            MainCode.books.Add(kotlinBook);

            // Act
            MainCode.books.Remove(kotlinBook);

            // Assert
            Assert.AreEqual(0, MainCode.books.Count);
        }
    }

    [TestClass]
    public class UserTests
    {
        [TestInitialize]
        public void InitializeUsersList()
        {
            // Initialize users list before each test
            MainCode.users = new List<User>();
        }

        [TestMethod]
        public void VerifyUserAddition()
        {
            // Arrange
            int initialUserCount = MainCode.users.Count;

            // Act
            MainCode.users.Add(new User { Id = 201, Name = "Olivia Martin", Email = "olivia@example.com" });

            // Assert
            Assert.IsTrue(MainCode.users.Count == initialUserCount + 1);
            Assert.AreEqual("Olivia Martin", MainCode.users[0].Name);
            Assert.AreEqual("olivia@example.com", MainCode.users[0].Email);
        }

        [TestMethod]
        public void TestUserListing()
        {
            // Arrange
            MainCode.users.Add(new User { Id = 202, Name = "William Harris", Email = "william@example.com" });
            MainCode.users.Add(new User { Id = 203, Name = "Isabella Jackson", Email = "isabella@example.com" });

            // Act
            var allUsers = MainCode.users;

            // Assert
            Assert.AreEqual(2, allUsers.Count);
            Assert.IsTrue(allUsers.Any(u => u.Name.Contains("William")));
            Assert.IsTrue(allUsers.Any(u => u.Name.Contains("Isabella")));
        }

        [TestMethod]
        public void ValidateUserUpdate()
        {
            // Arrange
            var masonUser = new User { Id = 204, Name = "Mason Davis", Email = "mason@example.com" };
            MainCode.users.Add(masonUser);

            // Act
            masonUser.Name = "Ava Thompson";
            masonUser.Email = "ava@example.com";

            // Assert
            var updatedUser = MainCode.users.FirstOrDefault(u => u.Id == 204);
            Assert.IsNotNull(updatedUser);
            Assert.IsTrue(updatedUser.Name.StartsWith("Ava"));
            Assert.AreEqual("ava@example.com", updatedUser.Email);
        }

        [TestMethod]
        public void ConfirmUserDeletion()
        {
            // Arrange
            var sophiaUser = new User { Id = 205, Name = "Sophia Miller", Email = "sophia@example.com" };
            MainCode.users.Add(sophiaUser);

            // Act
            MainCode.users.Remove(sophiaUser);

            // Assert
            Assert.AreEqual(0, MainCode.users.Count);
        }
    }
}

