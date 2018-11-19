using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using System.Net;
using HtmlAgilityPack;

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

        public async void Parser()     //парсинг таблицы 
        {
            ParseClass PC = new ParseClass();
            if (PC.ConnectionAvailable("http://mfc.ulgov.ru") == true)
            {
                HtmlDocument HD = await PC.TableParser(@"http://mfc.ulgov.ru/index1.php?t=zagrujennost");
                TZavKol.Text = PC.TextParser(HD,"//div[@class='content rightPart']/div/table/tr[3]/td[2]/div"); 
                TZavTime.Text = PC.TextParser(HD,"//div[@class='content rightPart']/div/table/tr[3]/td[3]/div");
                TZasKol.Text = PC.TextParser(HD,"//div[@class='content rightPart']/div/table/tr[4]/td[2]/div");
                TZasTime.Text = PC.TextParser(HD,"//div[@class='content rightPart']/div/table/tr[4]/td[3]/div");
                TLenKol.Text = PC.TextParser(HD,"//div[@class='content rightPart']/div/table/tr[5]/td[2]/div");
                TLenTime.Text = PC.TextParser(HD,"//div[@class='content rightPart']/div/table/tr[5]/td[3]/div");
                TZheKol.Text = PC.TextParser(HD,"//div[@class='content rightPart']/div/table/tr[6]/td[2]/div");
                TZheTime.Text = PC.TextParser(HD,"//div[@class='content rightPart']/div/table/tr[6]/td[3]/div");
            }
            else
            {
                TZavKol.Text = PC.ErrorMessage;
                TZavTime.Text = PC.ErrorMessage;
                TZasKol.Text = PC.ErrorMessage;
                TZasTime.Text = PC.ErrorMessage;
                TLenKol.Text = PC.ErrorMessage;
                TLenTime.Text = PC.ErrorMessage;
                TZheKol.Text = PC.ErrorMessage;
                TZheTime.Text = PC.ErrorMessage;
            }
        }

        private void ContentArea_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Parser();
        }

    }
}
