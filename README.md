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
            using (var Hook = new WebHook("https://discord.com/api/webhooks/886172264880566283/XUt4sxsuVuCeKsIRJ8LEBnU2zf0k5Te3stl1uH4MMv53xavfX8KLK2AAYcLJfn3nEGwr"))
            {
                Console.WriteLine(await Hook.ExistsAsync() ? "Exists" : "Doesn't exist");
                await Hook.SendAsync("Hello there!");
                await Hook.DeleteAsync();
                Console.WriteLine(await Hook.ExistsAsync() ? "Exists" : "Doesn't exist");
            }

            Console.ReadLine();
            
            /*
              Output:
              
              Exists
              Doesn't Exist
            */
        }
    }
}```
