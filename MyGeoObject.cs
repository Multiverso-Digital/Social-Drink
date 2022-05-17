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
using PushpinClusterer;
using System.Device.Location;

namespace Social_Drink
{
    public class MyGeoObject : IClusteredGeoObject
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public GeoCoordinate Coordinate  { get; set; }      
    }
}
