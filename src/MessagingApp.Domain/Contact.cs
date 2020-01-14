namespace MessagingApp.Domain
{
    public struct Contact
    {
        private readonly string firstName;

        public Contact(string firstName)
        {
            this.firstName = firstName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
        }
    }
}
