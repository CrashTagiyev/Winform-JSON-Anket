namespace Winform_JSON_Homework2
{
    public class Person
    {
        public Person(string? surname, string? name, string? fathername, string? country, string? city, string? phonenumber, DateTime birthDay)
        {
            Surname = surname;
            Name = name;
            Fathername = fathername;
            Country = country;
            City = city;
            Phonenumber = phonenumber;
            BirthDay = birthDay.ToShortDateString();
        }

        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Fathername { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Phonenumber { get; set; }
        public string? BirthDay { get; set; }
        public string? Gender { get; set; }
    }
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}