using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using HtmlAgilityPack;
using Windows.Management.Deployment;

namespace MCwTDG.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            UpdateSoftware();
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

        private async void UpdateSoftware()
        {
            ParseClass parseClass = new ParseClass();
            if (parseClass.ConnectionAvailable("https://floorup4.ru") == true)
            {
                try
                {
                    HtmlDocument html = await parseClass.TableParserAsync(@"https://floorup4.ru/update_kiosk");
                    string software_version_website = parseClass.TextParser(html, "/html/body/div[2]/div[7]/div[1]/div[2]");
                    string update_link = html.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/a[3]").GetAttributeValue("href", "");
                    if (software_version_website != parseClass.GetAppVersion())
                    {
                        PackageManager packageManager = new PackageManager();
                        await packageManager.UpdatePackageAsync(new Uri(update_link), null, DeploymentOptions.ForceApplicationShutdown);
                    }
                }
                catch
                {

                }
                finally
                {

                }
            }
        }
    }
}
