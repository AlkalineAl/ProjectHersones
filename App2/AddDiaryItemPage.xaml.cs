using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
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
    public sealed partial class AddDiaryItemPage : Page
    {
        public AddDiaryItemPage()
        {
            this.InitializeComponent();
        }
        private async void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();
            StorageFile file = await camera.CaptureFileAsync(CameraCaptureUIMode.PhotoOrVideo);
            if (file != null)
            {
                // Open a stream for the selected file.
                Windows.Storage.Streams.IRandomAccessStream fileStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                // Set the image source to the selected bitmap.
                Windows.UI.Xaml.Media.Imaging.BitmapImage bitmapImage =
                    new Windows.UI.Xaml.Media.Imaging.BitmapImage();

                bitmapImage.SetSource(fileStream);
                image.Source = bitmapImage;
                this.DataContext = file;
                // Add picked file to MostRecentlyUsedList.





            }
            else
            {
                MessageDialog msgbox = new MessageDialog("Файл не выбран", "Внимание");
                await msgbox.ShowAsync();
            }





        }


        private async void AddSpeachAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            /* SpeechRecognizer speechRecognizer = null;
             try
             {
                 Windows.Globalization.Language lan = new Windows.Globalization.Language("en-US");
                 speechRecognizer = new SpeechRecognizer(lan);
                 speechRecognizer.UIOptions.IsReadBackEnabled = false; // не нужно повторять распознанное слово
                 speechRecognizer.UIOptions.ShowConfirmation = false; // и подтверждение нам не нужно показывать



                 SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();
                 // если была отмена, то не продолжаем дальше
                 if (speechRecognitionResult.Confidence == SpeechRecognitionConfidence.Rejected)
                 {
                     return;
                 }
                 else
                 {
                     textBox12.Text = speechRecognitionResult.Text;
                 }


             }
             catch
             {
                 // отображаем сообщение и не продолжаем выполнение кода

                 return;
             }*/

            MessageDialog msgbox = new MessageDialog("Голосовой ввод пока не доступен", "Ошибка");
            await msgbox.ShowAsync();

        }

        private async void OpenAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".mp4");
            var file = await openPicker.PickSingleFileAsync();

            // file is null if user cancels the file picker.

            if (file != null)
            {
                // Open a stream for the selected file.
                Windows.Storage.Streams.IRandomAccessStream fileStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                // Set the image source to the selected bitmap.
                Windows.UI.Xaml.Media.Imaging.BitmapImage bitmapImage =
                    new Windows.UI.Xaml.Media.Imaging.BitmapImage();

                bitmapImage.SetSource(fileStream);
                image.Source = bitmapImage;
                this.DataContext = file;
                // Add picked file to MostRecentlyUsedList.





            }
            else
            {
                MessageDialog msgbox = new MessageDialog("Файл не выбран", "Внимание");
                await msgbox.ShowAsync();
            }
        }
    }
}
