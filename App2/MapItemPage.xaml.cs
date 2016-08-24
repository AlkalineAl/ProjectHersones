using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MapItemPage : Page
    {
        int text;
        public MapItemPage()
        {
            this.InitializeComponent();
            cb2.Items.Add("монета"); cb2.Items.Add("сооружение"); cb2.Items.Add("посуда"); cb2.Items.Add("захоронение"); cb2.Items.Add("инструмент"); cb2.Items.Add("другое");
            cb2.SelectedItem= ("монета");
            text = cb2.SelectedIndex;
            cb2.SelectionChanged += cb2_SelectedIndexChanged;
        }

        private void cb2_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            text = cb2.SelectedIndex;
        }

        private void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Name_im pi = new Name_im { name_of_point = name_tob.Text.ToString(), image_of_point = text };
            this.Frame.Navigate(typeof(MapPage), pi);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                PageInfo pi = (PageInfo)e.Parameter;
                latit.Text = pi.latit;
                longit.Text = pi.longit;
            }
        }
    }
}
