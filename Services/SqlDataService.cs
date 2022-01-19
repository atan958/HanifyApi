using System;
using System.Collections.Generic;
using apis.Models;
using Microsoft.Data.SqlClient;

namespace apis.Services
{
    public class SqlDataService : IDataService
    {
        private readonly string ConnectionString = @"Data Source=ANGELO\SQLEXPRESS;Initial Catalog=TryingAgain;Integrated Security=True; TrustServerCertificate=True";

        public SpotifyGroup Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpotifyGroup> GetAll()
        {
            var spotifyGroups = new List<SpotifyGroup>();

            var queryString = "SELECT *\n" +
                                 "FROM SpotifyGroup";
            try
            {
                using SqlConnection con = new(ConnectionString);
                SqlCommand cmd = new(queryString, con);

                con.Open();
                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var group = new SpotifyGroup() 
                    {
                        Id = new Guid(Convert.ToString(rdr[0])),
                        Name = Convert.ToString(rdr[1]),
                    };
                    spotifyGroups.Add(group);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAll error occurred: {ex.Message}");
            }
            return spotifyGroups;
        }

        public void Post(SpotifyGroup group)
        {
            var queryString = $"INSERT INTO SpotifyGroup (id, name) VALUES(N\'{group.Id}\',N\'{group.Name}\')";

            try
            {
                using SqlConnection con = new(ConnectionString);
                SqlCommand cmd = new(queryString, con);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Post error occurred: {ex.Message}");
            }
        }
    }
}