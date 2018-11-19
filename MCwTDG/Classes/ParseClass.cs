using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;

namespace MCwTDG
{
    public class ParseClass
    {
        public bool ConnectionAvailable(string strServer)   //проверка доступа к узлу
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(strServer);
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    // Доступ к сайту в сети Интернет имеется 
                    rspFP.Close();
                    return true;
                }
                else
                {
                    // Сервер вернул отрицательный ответ, доступ к сайту отсутствует
                    rspFP.Close();
                    return false;
                }
            }
            catch (WebException)
            {
                // Ошибка, доступ к сайту отсутствует
                return false;
            }
        }

        public string ErrorMessage = "Невозможно получить данные. Отсутствует доступ к сети Интернет.";

        public async Task<HtmlDocument> TableParser(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.OptionReadEncoding = false;
            var request = (HttpWebRequest)WebRequest.Create(html);
            request.Method = "GET";
            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    htmlDoc.Load(stream, Encoding.UTF8);
                }
            }
            return htmlDoc;
        }

        public string TextParser(HtmlDocument htmlDocument, string str)
        {
            return htmlDocument.DocumentNode.SelectSingleNode(str).InnerText.Trim();
        }

    }
}
