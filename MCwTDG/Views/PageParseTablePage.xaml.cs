using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;
using System.Text;
using System.Net;
using HtmlAgilityPack;
using Windows.UI.Xaml.Navigation;

namespace MCwTDG.Views
{
    public sealed partial class PageParseTablePage : Page, INotifyPropertyChanged
    {
        public PageParseTablePage()
        {
            InitializeComponent();
            Parser();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool ConnectionAvailable(string strServer)
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(strServer);

                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    // HTTP = 200 - Интернет безусловно есть! 
                    rspFP.Close();
                    return true;
                }
                else
                {
                    // сервер вернул отрицательный ответ, инета нет
                    rspFP.Close();
                    return false;
                }
            }
            catch (WebException)
            {
                // Ошибка, интернета у нас нет.
                return false;
            }
        }
        
        private async void Parser()
        {
        if (ConnectionAvailable("http://mfc.ulgov.ru") == true)
            {
                string html = @"http://mfc.ulgov.ru/index1.php?t=zagrujennost";
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
                TZavKol.Text = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[3]/td[2]/div").InnerText.Trim();
                TZavTime.Text = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[3]/td[3]/div").InnerText.Trim();
                TZasKol.Text = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[4]/td[2]/div").InnerText.Trim();
                TZasTime.Text = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[4]/td[3]/div").InnerText.Trim();
                TLenKol.Text = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[5]/td[2]/div").InnerText.Trim();
                TLenTime.Text = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[5]/td[3]/div").InnerText.Trim();
                TZheKol.Text = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[6]/td[2]/div").InnerText.Trim();
                TZheTime.Text = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[6]/td[3]/div").InnerText.Trim();
            }
        else
            {
                TZavKol.Text = "Невозможно получить данные. Отсутствует доступ к сети Интернет.";
                TZavTime.Text = "Невозможно получить данные. Отсутствует доступ к сети Интернет.";
                TZasKol.Text = "Невозможно получить данные. Отсутствует доступ к сети Интернет.";
                TZasTime.Text = "Невозможно получить данные. Отсутствует доступ к сети Интернет.";
                TLenKol.Text = "Невозможно получить данные. Отсутствует доступ к сети Интернет.";
                TLenTime.Text = "Невозможно получить данные. Отсутствует доступ к сети Интернет.";
                TZheKol.Text = "Невозможно получить данные. Отсутствует доступ к сети Интернет.";
                TZheTime.Text = "Невозможно получить данные. Отсутствует доступ к сети Интернет.";
            }
        }

        private void ContentArea_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Parser();
        }

        }
    }
