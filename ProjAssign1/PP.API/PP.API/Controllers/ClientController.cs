using Library.Database;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using PP.API.Database;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly FakeDatabase _fakeDatabase; // Add this field to hold an instance of FakeDatabase

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
            _fakeDatabase = new FakeDatabase(); // Create an instance of FakeDatabase
        }

        [HttpGet("GetClients")]
        public IEnumerable<Client> GetClients()
        {
            return _fakeDatabase.Clients; // Return the list of clients from the FakeDatabase
        }

        [HttpPost("AddClient")]
        public IActionResult AddClient([FromBody] Client newClient)
        {
            // Add the new client to the FakeDatabase.Clients list
            _fakeDatabase.Clients.Add(newClient);

            return CreatedAtAction(nameof(GetClients), new { id = newClient.Id }, newClient);
        }

        [HttpPut("UpdateClient/{id}")]
        public IActionResult UpdateClient(int id, [FromBody] Client updatedClient)
        {
            // Find the existing client in the server's FakeDatabase.Clients list
            var existingClient = _fakeDatabase.Clients.FirstOrDefault(c => c.Id == id);
            if (existingClient == null)
            {
                // If the client with the given ID doesn't exist, return HTTP status code 404 (Not Found)
                return NotFound();
            }

            // Update the existing client with the new data
            existingClient.Name = updatedClient.Name;
            existingClient.Notes = updatedClient.Notes;
            existingClient.IsActive = updatedClient.IsActive;

            // Return HTTP status code 204 (No Content) to indicate success
            return NoContent();
        }

        [HttpDelete("DeleteClient/{id}")]
        public IActionResult DeleteClient(int id)
        {
            // Find the client to delete in the server's FakeDatabase.Clients list
            var clientToDelete = _fakeDatabase.Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete == null)
            {
                // If the client with the given ID doesn't exist, return HTTP status code 404 (Not Found)
                return NotFound();
            }

            // Remove the client from the server's FakeDatabase.Clients list
            _fakeDatabase.Clients.Remove(clientToDelete);

            // Return HTTP status code 204 (No Content) to indicate success
            return NoContent();
        }

    }





}

