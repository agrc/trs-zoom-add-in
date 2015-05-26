using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TRSZoom
{
    public class ResultContainer<T> where T : class
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }
    }

    public class AttributeFeature
    {
        public Dictionary<string, string> Attributes { get; set; }
    }

    public class Feature
    {
        public Geometry Geometry { get; set; }
        public FeatureAttributes Attributes { get; set; }
    }

    public class FeatureAttributes
    {
        public Dictionary<string, string> Attributes { get; set; }
    }

    public class Geometry
    {
        public List<List<List<double>>> Rings { get; set; }
        public string Type { get; set; }
        public SpatialReference SpatialReference { get; set; }
        [JsonIgnore]
        public IGeometry Polygon
        {
            get
            {
                JSONReader reader = new JSONReader();
                reader.ReadFromString(JsonConvert.SerializeObject(this));
                JSONDeserializerGdb ds = new JSONDeserializerGdb();
                ds.InitDeserializer(reader, null);
                IExternalDeserializerGdb ex = ds as IExternalDeserializerGdb;
                var poly = ex.ReadGeometry(esriGeometryType.esriGeometryPolygon);

                return poly;
            }
        }
    }

    public class SpatialReference
    {
        public int Wkid { get; set; }
    }
}
