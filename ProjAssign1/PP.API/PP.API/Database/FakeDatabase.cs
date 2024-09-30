using Library.Models;

namespace PP.API.Database
{
    public class FakeDatabase
    {
        public List<Client> Clients = new List<Client>
        {
            new Client { Id = 1, Name = "Tony Stark", Notes = "Genius billionaire playboy philanthropist", IsActive = true },
            new Client { Id = 2, Name = "Walter White", Notes = "High school chemistry teacher turned methamphetamine manufacturer", IsActive = true },
            new Client { Id = 3, Name = "Quentin Tarantino", Notes = "Acclaimed filmmaker known for his unique style", IsActive = true },
            new Client { Id = 4, Name = "Bruce Wayne", Notes = "Billionaire vigilante fighting crime as Batman", IsActive = true },
            new Client { Id = 5, Name = "Daenerys Targaryen", Notes = "Mother of Dragons and rightful heir to the Iron Throne", IsActive = true },
            new Client { Id = 6, Name = "Albert Einstein", Notes = "Renowned physicist and creator of the theory of relativity", IsActive = true },
            new Client { Id = 7, Name = "Sherlock Holmes", Notes = "Brilliant detective with unparalleled deductive reasoning", IsActive = true },
            new Client { Id = 8, Name = "Cleopatra", Notes = "Egyptian queen and one of history's most iconic female rulers", IsActive = true },
            new Client { Id = 9, Name = "Leonardo da Vinci", Notes = "Renaissance polymath and artist of the Mona Lisa", IsActive = true },
            new Client { Id = 10, Name = "Michael Jordan", Notes = "Legendary basketball player and NBA Hall of Famer", IsActive = true },
            new Client { Id = 11, Name = "Coco Chanel", Notes = "Fashion designer and founder of the Chanel brand", IsActive = true },
            new Client { Id = 12, Name = "Marilyn Monroe", Notes = "Iconic actress and model from the golden age of Hollywood", IsActive = true },
            new Client { Id = 13, Name = "Nelson Mandela", Notes = "South African anti-apartheid revolutionary and president", IsActive = true },
            new Client { Id = 14, Name = "Vincent van Gogh", Notes = "Dutch painter known for his post-impressionist masterpieces", IsActive = true },
            new Client { Id = 15, Name = "Amelia Earhart", Notes = "Pioneering aviator and the first woman to fly solo across the Atlantic", IsActive = true },
            new Client { Id = 16, Name = "Marie Curie", Notes = "Nobel Prize-winning scientist for her groundbreaking work in physics and chemistry", IsActive = true },
            new Client { Id = 17, Name = "Frida Kahlo", Notes = "Mexican painter known for her self-portraits and activism", IsActive = true },
            new Client { Id = 18, Name = "Nikola Tesla", Notes = "Inventor and engineer with numerous revolutionary contributions", IsActive = true },
            new Client { Id = 19, Name = "Jane Austen", Notes = "Renowned novelist and author of Pride and Prejudice", IsActive = true },
            new Client { Id = 20, Name = "LeBron James", Notes = "NBA superstar and four-time NBA champion", IsActive = true },
        };

    }
}
