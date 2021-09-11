using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWebhook.NET
{
    public class WebHook : IDisposable
    {
        public string WebHookURL;
        private bool Disposed = false;
        private SafeHandle Handle = new SafeFileHandle(IntPtr.Zero, true);

        public WebHook(string WebHookURL) => this.WebHookURL = WebHookURL;

        public async Task DeleteAsync()
        {
            using (var Client = new HttpClient { BaseAddress = new Uri(WebHookURL) })
                await Client.DeleteAsync(WebHookURL);
        }

        public async Task<bool> ExistsAsync()
        {
            using (var Client = new HttpClient())
            using (var Response = await Client.GetAsync(WebHookURL))
                return Response.IsSuccessStatusCode;
        }

        public async Task SendAsync(string Message, string Username = "", string ProfilePicture = "")
        {
            if (!await ExistsAsync())
                return;

            var Client = (HttpWebRequest)WebRequest.Create(WebHookURL);
            var Data = $"{{\"username\":\"{Username}\",\"content\":\"{Message}\",\"avatar_url\":\"{ProfilePicture}\"}}";

            Client.ContentLength = Data.Length;
            Client.ContentType = "application/json";
            Client.Method = "POST";

            using (var Stream = Client.GetRequestStream())
                Stream.Write(Encoding.UTF8.GetBytes(Data), 0, Data.Length);

            Client.GetResponse();
        }

        #region Disposing

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposed && Disposing)
                Handle.Dispose();

            Disposed = true;
        }

        #endregion
    }
}
