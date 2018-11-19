using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
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
                HtmlDocument HD = await PC.TableParserAsync(@"http://mfc.ulgov.ru/index1.php?t=zagrujennost");
                TZavKol.Text = PC.TextParser(HD,3,2); 
                TZavTime.Text = PC.TextParser(HD,3,3);
                TZasKol.Text = PC.TextParser(HD,4,2);
                TZasTime.Text = PC.TextParser(HD,4,3);
                TLenKol.Text = PC.TextParser(HD,5,2);
                TLenTime.Text = PC.TextParser(HD,5,3);
                TZheKol.Text = PC.TextParser(HD,6,2);
                TZheTime.Text = PC.TextParser(HD,6,3);
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
