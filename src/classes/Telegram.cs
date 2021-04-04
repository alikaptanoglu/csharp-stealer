using System;
using System.Net;

namespace Telegram
{
	class telegram
	{
		private string token;
		private string id;

		public telegram(string token, string id)
		{
			this.token = token;
			this.id = id;
		}

		public bool SendMessage(string text)
		{
			try
			{
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				using (WebClient c = new WebClient())
				{
					string response = c.DownloadString(
						"https://api.telegram.org/bot" + token + "/sendMessage" +
						"?chat_id=" + id +
						"&text=" + text +
						"&parse_mode=html" +
						"&disable_web_page_preview=True"
					);
					return !response.StartsWith("{\"ok\":false");
				}
			}
			catch (Exception e) {
				Console.WriteLine(e);
				return false;
			}
		}
	}
}