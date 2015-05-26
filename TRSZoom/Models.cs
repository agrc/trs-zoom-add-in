using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRSZoom
{
     public class ResultContainer<T> where T : class {
            public int Status { get; set; }
            public string Message { get; set; }
            public T Result { get; set; }
    }

    public class Feature {
            public Geometry Geometry { get; set; }
            public FeatureAttributes Attributes { get; set; }
    }

    public class FeatureAttributes {
        public Dictionary<string, string> Attributes { get; set; }
    }

    public class Geometry {
        public List<List<List<double>>> Rings { get; set; }
        public string Type { get; set; }
        public SpatialReference SpatialReference { get; set; }
        [JsonIgnore]
        public IEnvelope Geometry
        {
            get
            {
                JSONReader reader = new JSONReader();
                reader.ReadFromString(Rings);
                JSONDeserializerGdb ds = new JSONDeserializerGdb();
                ds.InitDeserializer(reader, null);
                IExternalDeserializerGdb ex = ds as IExternalDeserializerGdb;
                _envelope = ex.ReadGeometry(esriGeometryType.esriGeometryEnvelope) as IEnvelope;
                _envelope.SpatialReference = ex.ReadSpatialReference();
                
                return _envelope;
            }
        }
    }

    public class SpatialReference {
        public int Wkid { get; set; }
    }
}
