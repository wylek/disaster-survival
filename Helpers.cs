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
using System.Collections.ObjectModel;
using Microsoft.Phone.Reactive;

namespace DisasSurvivApp
{
    public static class Helpers
    {
        public static IObservable<ReverseGeocodeCompletedEventArgs> GetGeocodeCompletedEventStream(this GeocodeServiceClient gcss)
        {
            return (DisasSurvivApp.IObservable<ReverseGeocodeCompletedEventArgs>)Observable.Create<ReverseGeocodeCompletedEventArgs>(observable =>
            {
                EventHandler<ReverseGeocodeCompletedEventArgs> handler = (s, e) =>
                {
                    observable.OnNext(e);
                };
                gcss.ReverseGeocodeCompleted += handler;
                return () => { gcss.ReverseGeocodeCompleted -= handler; };
            });
        }




    }
}
