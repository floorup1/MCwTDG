using System;

using MCwTDG.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MCwTDG.Views
{
    public sealed partial class MasterDetail1DetailControl : UserControl
    {
        public Information MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Information; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(Information), typeof(MasterDetail1DetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public MasterDetail1DetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MasterDetail1DetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
