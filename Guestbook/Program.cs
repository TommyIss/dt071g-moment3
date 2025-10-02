using System;

namespace Guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            GuestbookFile guestbook = new GuestbookFile();

            while(true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("G U E S T B O O K");

                Console.WriteLine("======================\n\n");

                Console.WriteLine("1. Lägg till post");

                Console.WriteLine("2. Ta bort post\n");

                Console.WriteLine("0. Avsluta\n");

                // Loopa igenom alla inlägg och skriv ut dem i konsolen
                foreach(GuestbookPost post in guestbook.GetPosts())
                {
                    Console.WriteLine($"[{Array.IndexOf(guestbook.GetPosts().ToArray(), post) + 1}] - Ägare: {post.Owner} - Skrev: {post.Post}");
                }

                // Välj ett tangent
                int choice = (int)Console.ReadKey(true).Key;

                // Switch-sats för att hantera olika val
                switch(choice)
                {
                    // Tangent '1' för att lägga till inlägg
                    case '1':
                        Console.CursorVisible = true; // Gör markören synlig
                        Console.WriteLine("\nSkriv både ditt namn och post");
                        Console.WriteLine("\nÄgare: ");

                        string ? owner = Console.ReadLine();

                        // Kolla så att fältet inte är tomt
                        if (String.IsNullOrEmpty(owner))
                        {
                            Console.WriteLine("Du får inte lämna tomt fält");
                            owner = Console.ReadLine();
                        }
                        Console.WriteLine("\nInlägg: ");
                        string? post = Console.ReadLine();

                        // Kolla så att fältet inte är tomt
                        if (String.IsNullOrEmpty(post))
                        {
                            Console.WriteLine("Du får inte lämna tomt fält");
                            post = Console.ReadLine();
                        }
                        // If-sats för att kolla så att varken ägare eller inlägg är tomma
                        if (!String.IsNullOrEmpty(owner) && !String.IsNullOrEmpty(post))
                        {
                            // Lägg till inlägget i gästboken
                            guestbook.addPost(owner, post);
                        } 
                        break;

                    // Tangent 2 för att ta bort ett befintlig inlägg
                    case '2':
                        Console.CursorVisible = true;
                        Console.WriteLine("\nAnge nummer på inlägg för att ta bort!");

                 
                        string input = Console.ReadLine();

                        // If-sats för att kontrollera om index finns och är ett heltal
                        if(int.TryParse(input, out int index) && index > 0 && !String.IsNullOrEmpty(input))
                            try
                            {
                                // Radera post med angivet index
                                guestbook.deletePost(index - 1);
                            }
                            catch(Exception) // Om något annat inträffar
                            {
                                Console.WriteLine("Index finns inte\nTryck på valfri tangent för att återgå");
                                Console.ReadKey();
                            }
                        break;
                    
                    // Avsluta applikationen
                    case '0':
                        Environment.Exit(0);
                        break;

                    // Övriga val
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        Console.WriteLine("Tryck på valfri tangent för att återgå");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}