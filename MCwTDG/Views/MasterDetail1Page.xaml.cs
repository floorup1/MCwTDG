using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using MCwTDG.Models;
using MCwTDG.Services;

using Microsoft.Toolkit.Uwp.UI.Controls;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace MCwTDG.Views
{
    public sealed partial class MasterDetail1Page : Page, INotifyPropertyChanged
    {
        private Information _selected;

        public Information Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<Information> InfoItems { get; private set; } = new ObservableCollection<Information>();

        public MasterDetail1Page()
        {
            InitializeComponent();
            Loaded += MasterDetail1Page_Loaded;
        }

        private async void MasterDetail1Page_Loaded(object sender, RoutedEventArgs e)
        {
            InfoItems.Clear();

            var data = await InfoService.GetInformationDataAsync();

            foreach (var item in data)
            {
                InfoItems.Add(item);
            }

            if (MasterDetailsViewControl.ViewState == MasterDetailsViewState.Both)
            {
                Selected = InfoItems.First();
            }
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
    }
}
