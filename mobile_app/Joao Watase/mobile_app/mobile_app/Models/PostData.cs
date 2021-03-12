namespace mobile_app.Models
{
    class PostData
    {
        public PostData(string Name, string Age, string Surname = null)
        {
            name = Name;
            age = Age;
            surname = Surname;
        }
        public string name { get; set; }
        public string age { get; set; }
        public string surname { get; set; }
    }
}
