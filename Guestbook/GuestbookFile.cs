using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Guestbook
{
    internal class GuestbookFile
    {
        // Json-fil för att spara gästboksinlägg
        private string fileName = @"guestbook.json";

        // Lista av post-objekt
        private List<GuestbookPost> posts = new List<GuestbookPost>();

        // Konstruktor
        public GuestbookFile()
        {
            if (File.Exists(fileName) == true) // Om filen finns
            {
                   // Läs in data från filen
                string jsonData = File.ReadAllText(fileName);
                // Konvertera json-data till lista av objekt
                posts = JsonSerializer.Deserialize<List<GuestbookPost>>(jsonData);
            }
        }

        // Lägg till ett nytt inlägg
        public GuestbookPost addPost(string owner, string post)
        {
            GuestbookPost newPost = new GuestbookPost();
            newPost.Owner = owner;
            newPost.Post = post;
            posts.Add(newPost);// Lägg till nya posten i listan
            marshal();
            return newPost;
        }

        // Radera utvalt inlägg
        public int deletePost(int index)
        {
            posts.RemoveAt(index);// Radera posten med angivet index
            marshal(); // Uppdatera filen
            return index;
        }

        // Hämta alla inlägg
        public List<GuestbookPost> GetPosts()
        {
            return posts;
        }

        // Funktion för att serialisera och spara data
        private void marshal()
        {
            // Serialisera objekt till json
            var jsonData = JsonSerializer.Serialize(posts);
            // Spara json-data till filen
            File.WriteAllText(fileName, jsonData);
        }
    }
}
