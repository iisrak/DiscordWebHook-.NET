# DiscordWebHook-.NET
API for using discord WebHooks in C#

# Usage
```cs
using DiscordWebhook.NET;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string WebhookLink = "WEBHOOK_LINK";    
        
            using (var Hook = new WebHook(WebhookLink))
            {
                Console.WriteLine(await Hook.ExistsAsync() ? "Exists" : "Doesn't exist"); // Exists
                await Hook.SendAsync("Hello there!");
                await Hook.DeleteAsync();
                Console.WriteLine(await Hook.ExistsAsync() ? "Exists" : "Doesn't exist"); // Doesn't exist
            }

            Console.ReadLine();
        }
    }
}
```
