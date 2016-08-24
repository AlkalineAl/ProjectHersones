using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class MapPage : Page
    {
        private Geolocator geolocator = new Geolocator();
        MapPolygon mapPolygon = new MapPolygon();
        ArrayList objectList = new ArrayList();
        public MapPage()
        {
            this.InitializeComponent();
            geolocator.DesiredAccuracyInMeters = 150;
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private async void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            
            // получаем позицию
            var position = await geolocator.GetGeopositionAsync();
            // установка этой позиции на карте
            // Specify a known location.
            PageInfo pi = new PageInfo { latit = position.Coordinate.Point.Position.Latitude.ToString(), longit = position.Coordinate.Point.Position.ToString() };
            this.Frame.Navigate(typeof(MapItemPage), pi);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RoutePointPage));
        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {


            if (e.Parameter != null)
            {
                geolocator.DesiredAccuracyInMeters = 150;
                // получаем позицию
                var position = await geolocator.GetGeopositionAsync();
                // установка этой позиции на карте
                // Specify a known location.
                BasicGeoposition snPosition = new BasicGeoposition() { Latitude = position.Coordinate.Point.Position.Latitude, Longitude = position.Coordinate.Point.Position.Longitude };
                Geopoint snPoint = new Geopoint(snPosition);

                // Create a MapIcon.
                MapIcon mapIcon2 = new MapIcon();
                mapIcon2.Location = snPoint;
                mapIcon2.NormalizedAnchorPoint = new Point(0.5, 1.0);
                Name_im top = (Name_im)e.Parameter;
                mapIcon2.Title = top.name_of_point.ToString();
                if(top.image_of_point == 0)
                {
                    mapIcon2.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/0.png"));
                }
                if (top.image_of_point == 1)
                {
                    mapIcon2.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/1.png"));
                }
                if (top.image_of_point == 2)
                {
                    mapIcon2.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/2.png"));
                }
                if (top.image_of_point == 3)
                {
                    mapIcon2.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/3.png"));
                }
                if (top.image_of_point == 4)
                {
                    mapIcon2.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/4.png"));
                }
                mapIcon2.ZIndex = 0;
                objectList.Add(mapIcon2);
                // Add the MapIcon to the map.
                foreach (MapIcon o in objectList)
                {
                    map.MapElements.Add(o);
                }
                map.Center = snPoint;
                map.ZoomLevel = 14;


            }

            else
            {
                try
                {

                    MessageDialog msd = new MessageDialog("Приложение пытается определить ваше местоположение", "Внимание");

                    msd.Commands.Add(new UICommand("Разрешить") { Id = 0 });
                    msd.Commands.Add(new UICommand("Запретить") { Id = 1 });
                    msd.DefaultCommandIndex = 0;
                    msd.CancelCommandIndex = 1;

                    var result = await msd.ShowAsync();
                    if (result == null && result.Label == "Разрешить")
                    {

                        map.MapServiceToken = "mapToken";
                        // получаем инструмент геолокации

                        //точность геолокации до 150 метров
                        geolocator.DesiredAccuracyInMeters = 150;
                        // получаем позицию
                        var position = await geolocator.GetGeopositionAsync();
                        // установка этой позиции на карте
                        // Specify a known location.
                        BasicGeoposition snPosition = new BasicGeoposition() { Latitude = position.Coordinate.Point.Position.Latitude, Longitude = position.Coordinate.Point.Position.Longitude };
                        Geopoint snPoint = new Geopoint(snPosition);

                        // Create a MapIcon.
                        MapIcon mapIcon1 = new MapIcon();
                        mapIcon1.Location = snPoint;
                        mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                        mapIcon1.Title = "Вы";
                        mapIcon1.ZIndex = 0;

                        // Add the MapIcon to the map.
                        map.MapElements.Add(mapIcon1);

                        // Center the map over the POI.
                        map.Center = snPoint;
                        map.ZoomLevel = 14;
                    }








                }
                catch
                {
                    MessageDialog msgbox = new MessageDialog("Невозможно получить данные местоположения", "Ошибка");
                    await msgbox.ShowAsync();
                }
            }



           
        }


    }
}
