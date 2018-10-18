using System;

using MCwTDG.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MCwTDG.Views
{
    public sealed partial class MasterDetail02DetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(MasterDetail02DetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public MasterDetail02DetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MasterDetail02DetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
