using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(MainDiary));

           SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Visible;

            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += TestView_BackRequested;
           
            radioButton1.Background = new SolidColorBrush(Colors.Red);
            radioButton2.Background = new SolidColorBrush(Colors.Transparent);
            radioButton3.Background = new SolidColorBrush(Colors.Transparent);
            radioButton4.Background = new SolidColorBrush(Colors.Transparent);

        }

        private void TestView_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
            {
                e.Handled = true;
                ContentFrame.GoBack();
                if(ContentFrame.Content.ToString() =="App2.MainDiary")
                {
                    radioButton1.IsChecked = true;
                    radioButton1.Background = new SolidColorBrush(Colors.Red);
                    radioButton2.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton3.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton4.Background = new SolidColorBrush(Colors.Transparent);
                }
                if (ContentFrame.Content.ToString() == "App2.MapPage")
                {
                    radioButton3.IsChecked = true;
                    radioButton3.Background = new SolidColorBrush(Colors.Red);
                    radioButton2.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton1.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton4.Background = new SolidColorBrush(Colors.Transparent);
                }
                if (ContentFrame.Content.ToString() == "App2.RoutePage")
                {
                    radioButton4.IsChecked = true;
                    radioButton4.Background = new SolidColorBrush(Colors.Red);
                    radioButton2.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton1.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton3.Background = new SolidColorBrush(Colors.Transparent);
                }
                if (ContentFrame.Content.ToString() == "App2.InvertoryMain")
                {
                    radioButton2.IsChecked = true;
                    radioButton2.Background = new SolidColorBrush(Colors.Red);
                    radioButton4.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton1.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton3.Background = new SolidColorBrush(Colors.Transparent);
                }
                if (ContentFrame.Content.ToString() == "App2.FieldInvertoryItem")
                {
                    radioButton2.IsChecked = true;
                    radioButton2.Background = new SolidColorBrush(Colors.Red);
                    radioButton4.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton1.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton3.Background = new SolidColorBrush(Colors.Transparent);
                }
                if (ContentFrame.Content.ToString() == "App2.CreateInvert")
                {
                    radioButton2.IsChecked = true;
                    radioButton2.Background = new SolidColorBrush(Colors.Red);
                    radioButton4.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton1.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton3.Background = new SolidColorBrush(Colors.Transparent);
                }
                if (ContentFrame.Content.ToString() == "App2.FieldInvert")
                {
                    radioButton2.IsChecked = true;
                    radioButton2.Background = new SolidColorBrush(Colors.Red);
                    radioButton4.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton1.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton3.Background = new SolidColorBrush(Colors.Transparent);
                }
                if (ContentFrame.Content.ToString() == "App2.OpenInvertory")
                {
                    radioButton2.IsChecked = true;
                    radioButton2.Background = new SolidColorBrush(Colors.Red);
                    radioButton4.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton1.Background = new SolidColorBrush(Colors.Transparent);
                    radioButton3.Background = new SolidColorBrush(Colors.Transparent);
                }


            }
        }

        private void radioButton_Click(object sender, RoutedEventArgs e)
        {
            if(MySplit.IsPaneOpen)
            {
                MySplit.IsPaneOpen = false;
            }
            else
            {
                MySplit.IsPaneOpen = true;
            }
            radioButton.IsChecked = false;
        }

        private void radioButton1_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(MainDiary));


            radioButton1.IsChecked = true;
            radioButton1.Background = new SolidColorBrush(Colors.Red);
            radioButton2.Background  = new SolidColorBrush(Colors.Transparent);
            radioButton3.Background = new SolidColorBrush(Colors.Transparent);
            radioButton4.Background = new SolidColorBrush(Colors.Transparent);

        }

        private void radioButton2_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(InvertoryMain));
            radioButton2.IsChecked = true;
            radioButton2.Background = new SolidColorBrush(Colors.Red);
            radioButton1.Background = new SolidColorBrush(Colors.Transparent);
            radioButton3.Background = new SolidColorBrush(Colors.Transparent);
            radioButton4.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void radioButton3_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(MapPage));
            radioButton3.IsChecked = true;
            radioButton3.Background = new SolidColorBrush(Colors.Red);
            radioButton2.Background = new SolidColorBrush(Colors.Transparent);
            radioButton1.Background = new SolidColorBrush(Colors.Transparent);
            radioButton4.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void radioButton4_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(RoutePage));
            radioButton4.IsChecked = true;
            radioButton4.Background = new SolidColorBrush(Colors.Red);
            radioButton2.Background = new SolidColorBrush(Colors.Transparent);
            radioButton3.Background = new SolidColorBrush(Colors.Transparent);
            radioButton1.Background = new SolidColorBrush(Colors.Transparent);
        }
    }
}
