using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using GpsEmulatorClient;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Controls.Maps.ConfigService;
using System.Runtime.Serialization;
using System.ServiceModel;
using Microsoft.Phone.Reactive;
using System.Collections.ObjectModel;


namespace DisasSurvivApp
{

    public enum DistanceIn { Miles, Kilometers };

    public static class Haversine
    {

        public static double Between(this DistanceIn @in, GeoPosition<GeoCoordinate> here, GeoPosition<GeoCoordinate> there)
        {
            var r = (@in == DistanceIn.Miles) ? 3960 : 6371;
            var dLat = (there.Location.Latitude - here.Location.Latitude).ToRadian();
            var dLon = (there.Location.Longitude - here.Location.Longitude).ToRadian();
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(here.Location.Latitude.ToRadian()) * Math.Cos(there.Location.Latitude.ToRadian()) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            var d = r * c;
            return d;
        }

        private static double ToRadian(this double val)
        {
            return (Math.PI / 180) * val;
        }
    } 

    public static class LocationHelpers
    {
        public static IObservable<GeoPositionChangedEventArgs<GeoCoordinate>> GetPositionChangedEventStream(this GpsEmulatorClient.GeoCoordinateWatcher watcher)
        {
            return (DisasSurvivApp.IObservable<GeoPositionChangedEventArgs<GeoCoordinate>>)Observable.Create<GeoPositionChangedEventArgs<GeoCoordinate>>(observable =>
            {
                EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>> handler = (s, e) =>
                {
                    observable.OnNext(e);
                };
                watcher.PositionChanged += handler;
                return () => { watcher.PositionChanged -= handler; };
            }
            );
        }
    }
}