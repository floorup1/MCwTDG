using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;
using System.Text;
using System.Net;
using HtmlAgilityPack;

namespace MCwTDG.Views
{
    public sealed partial class PageParseTablePage : Page, INotifyPropertyChanged
    {
        public PageParseTablePage()
        {
            InitializeComponent();
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

        private async void ContentArea_TappedAsync(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
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
            string ZavKol = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[3]/td[2]/div").InnerText.Trim();
            string ZavTime = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[3]/td[3]/div").InnerText.Trim();
            string ZasKol = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[4]/td[2]/div").InnerText.Trim();
            string ZasTime = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[4]/td[3]/div").InnerText.Trim();
            string LenKol = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[5]/td[2]/div").InnerText.Trim();
            string LenTime = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[5]/td[3]/div").InnerText.Trim();
            string ZheKol = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[6]/td[2]/div").InnerText.Trim();
            string ZheTime = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[6]/td[3]/div").InnerText.Trim();
            TZavKol.Text = ZavKol;
            TZavTime.Text = ZavTime;
            TZasKol.Text = ZasKol;
            TZasTime.Text = ZasTime;
            TLenKol.Text = LenKol;
            TLenTime.Text = LenTime;
            TZheKol.Text = ZheKol;
            TZheTime.Text = ZheTime;
        }

        private async void ContentArea_DoubleTappedAsync(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
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
                string ZavKol = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[3]/td[2]/div").InnerText.Trim();
                string ZavTime = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[3]/td[3]/div").InnerText.Trim();
                string ZasKol = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[4]/td[2]/div").InnerText.Trim();
                string ZasTime = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[4]/td[3]/div").InnerText.Trim();
                string LenKol = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[5]/td[2]/div").InnerText.Trim();
                string LenTime = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[5]/td[3]/div").InnerText.Trim();
                string ZheKol = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[6]/td[2]/div").InnerText.Trim();
                string ZheTime = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='content rightPart']/div/table/tr[6]/td[3]/div").InnerText.Trim();
                TZavKol.Text = ZavKol;
                TZavTime.Text = ZavTime;
                TZasKol.Text = ZasKol;
                TZasTime.Text = ZasTime;
                TLenKol.Text = LenKol;
                TLenTime.Text = LenTime;
                TZheKol.Text = ZheKol;
                TZheTime.Text = ZheTime;
            }
        }
    }
}
