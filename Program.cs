using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordPressPCL;
using WordPressPCL.Models;

namespace TyporaWordPressImageUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Invalid arguments.");
                Environment.Exit(-1);
            }

            var link = args[0];

            if (!link.EndsWith("/"))
            {
                link += "/";
            }

            Console.WriteLine($"WordPress link: {link}");

            AuthMethod Method;

            if (!Enum.TryParse(args[1], true, out Method))
            {
                Console.WriteLine($"Unknown auth method {args[1]}, only Basic and Bearer allowed.");
                Environment.Exit(-1);
            }

            var client = new WordPressClient(link)
            {
                AuthMethod = Method
            };

            string[] images;

            switch (Method)
            {
                case AuthMethod.Basic:
                    HandleBasicAuth(args, ref client, out images);
                    break;
                case AuthMethod.Bearer:
                    HandleBearerAuth(args, ref client, out images);
                    break;
                default:
                    return;
            }

            Console.WriteLine($"Attempt to upload {images.Length} image(s)...");

            PrintImageSource(CreateImageAsync(client, images)).Wait();
        }

        private static async IAsyncEnumerable<MediaItem> CreateImageAsync(WordPressClient client, string[] images)
        {
            foreach (var image in images)
            {
                yield return await client.Media.CreateAsync(image, System.IO.Path.GetFileName(image));
            }
        }

        private static async Task PrintImageSource(IAsyncEnumerable<MediaItem> item)
        {
            await foreach (var image in item)
            {
                Console.WriteLine(image.SourceUrl);
            }
        }

        private static void HandleBearerAuth(string[] args, ref WordPressClient client, out string[] images)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Invalid arguments.");
                Environment.Exit(-1);
            }

            var token = args[2];

            client.Auth.SetJWToken(token);

            Console.WriteLine($"Entered token: {token}");

            if (!client.Auth.IsValidJWTokenAsync().Result)
            {
                Console.WriteLine("Invalid token.");
                Environment.Exit(-999);
            }

            images = args[3..args.Length];
        }

        private static void HandleBasicAuth(string[] args, ref WordPressClient client, out string[] images)
        {
            if (args.Length < 5)
            {
                Console.WriteLine("Invalid arguments.");
                Environment.Exit(-1);
            }

            var username = args[2];
            var password = args[3];

            client.Auth.SetApplicationPassword(password);

            Console.WriteLine($"Entered username: {username}");

            if (!client.Auth.IsValidJWTokenAsync().Result)
            {
                Console.WriteLine("Invalid username or password.");
                Environment.Exit(-999);
            }

            images = args[4..args.Length];
        }
    }
}