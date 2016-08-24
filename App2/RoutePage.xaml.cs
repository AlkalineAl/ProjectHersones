using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls.Maps;
using System.Collections;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class RoutePage : Page
    {
        private Geolocator geolocator = new Geolocator();
        MapPolygon mapPolygon = new MapPolygon();
        ArrayList objectList = new ArrayList();



        public RoutePage()
        {
            this.InitializeComponent();

        }



        private async void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {


            geolocator.DesiredAccuracyInMeters = 150;
            // получаем позицию
            var position = await geolocator.GetGeopositionAsync();
            // установка этой позиции на карте
            // Specify a known location.
            PageInfo pi = new PageInfo { latit = position.Coordinate.Point.Position.Latitude.ToString(), longit = position.Coordinate.Point.Position.Longitude.ToString() };
            this.Frame.Navigate(typeof(RoutePointPage), pi);

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



                mapIcon2.Title = e.Parameter.ToString();
                mapIcon2.ZIndex = 0;
                objectList.Add(mapIcon2);
                // Add the MapIcon to the map.
                foreach (MapIcon o in objectList)
                {
                    map.MapElements.Add(o);
                }



            }





            try
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
            catch
            {
                MessageDialog msgbox = new MessageDialog("Невозможно получить данные местоположения", "Ошибка");
                await msgbox.ShowAsync();
            }
        }





    }

    class PageInfo
    {
        public string latit { get; set; }
        public string longit { get; set; }
    }
    class Name_im
    {
        public int image_of_point { get; set; }
        public string name_of_point { get; set; }

    }
}

