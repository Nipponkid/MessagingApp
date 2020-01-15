namespace MessagingApp.Domain
{
    public struct Contact
    {
        private readonly string firstName;
        private readonly string lastName;

        public Contact(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
        }
    }
}
