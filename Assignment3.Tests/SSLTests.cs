using Assignment3;

namespace Assignment3.Tests
{
    public class SSLTests
    {
        private ILinkedListADT users;

        [SetUp]
        public void Setup()
        {
            // Uncomment the following line
            users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }


        //First Test is to check if the List is empty
        [Test]
        public void Empty()
        {
            Assert.IsFalse(this.users.IsEmpty(), "Confirmed that the list is not empty");
        }

        //Second Test is to check if prepend works
        [Test]
        public void Prepend()
        {
            users.AddFirst(new User(5, "Naice", "Naice@gmail.com", "Naice"));
            //Checking if it got prepended by using the same User value at index 0 because it got added to the beginning
            Assert.AreEqual(new User(5, "Naice", "Naice@gmail.com", "Naice"), users.GetValue(0));
        }

        //Third Test is to check if append works
        [Test]
        public void Append()
        {
            //Checking if it got appended by using the same User value at index 4 because it got added to the end
            users.AddLast(new User(6, "Not Naice", "NNAICE@outlook.com", "NNAICE"));
            Assert.AreEqual(new User(6, "Not Naice", "NNAICE@outlook.com", "NNAICE"), users.GetValue(4));
        }


        //Fourth Test to check if Insert works as spcified value
        [Test]
        public void Insert()
        {
            users.Add(new User(7, "Seven", "Seven@gmail.com", "Seven"), 1);
            //Checking the index 1 changed to the specified User Value
            Assert.AreEqual(new User(7, "Seven", "Seven@gmail.com", "Seven"), users.GetValue(1));
        }

        //Fifth Test to check if Replace works at specified value
        [Test]
        public void Change()
        {
            users.Replace(new User(8, "Eight Now", "Eight@outlook.com", "Eighty"), 1);
            //Checking if index 1 changed to specified value
            Assert.AreEqual(new User(8, "Eight Now", "Eight@outlook.com", "Eighty"), users.GetValue(1));
        }

        //Sixth Test to check if the beginning changed
        [Test]
        public void RemoveBeginning()
        {
            users.RemoveFirst();
            //Checking if index 0 changed due to 0 being the first and confirming it got changed
            Assert.AreEqual(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"), users.GetValue(0));
        }

        //Seventh Test to check if the end changed
        [Test]
        public void RemoveEnd()
        {
            users.RemoveLast();
            //Checking if index 3 exists and should give exception
            Assert.Throws<NullReferenceException>(delegate {users.GetValue(3);});
        }

        //Eighth Test to check if the middle got removed
        [Test]
        public void RemoveMiddle()
        {
            users.Remove(1);
            //Checking if index 1, the middle, got removed
            Assert.AreEqual(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"), users.GetValue(1));
        }

        //Nineth Test to check if the find method works
        [Test]
        public void Find()
        {
            //Checking if the specified User value exists
            Assert.IsTrue(users.Contains(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef")));
        }

        //Tenth Test to check if the Arraytonodes work
        [Test]
        public void ArrayNodes()
        {
            User[] Temp = new User[] {new User(1, "Joe Blow", "jblow@gmail.com", "password"), new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"), new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"), new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999")};
            User[] main = users.NodesToArray();
            //Checking if array is the same
            Assert.AreEqual(Temp, main);
        }
    }
}