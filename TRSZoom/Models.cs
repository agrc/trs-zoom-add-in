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
    public class ResultContainer<T> where T : class
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }
    }

    public class Feature
    {
        private IEnvelope _envelope;
        public string Geometry
        {
            set
            {
                JSONReader reader = new JSONReader();
                reader.ReadFromString(value);
                JSONDeserializerGdb ds = new JSONDeserializerGdb();
                ds.InitDeserializer(reader, null);
                IExternalDeserializerGdb ex = ds as IExternalDeserializerGdb;
                _envelope = ex.ReadGeometry(esriGeometryType.esriGeometryEnvelope) as IEnvelope;
                _envelope.SpatialReference = ex.ReadSpatialReference();
            }
        }
        public IEnvelope Envelope
        {
            get
            {
                return _envelope;
            }
        }
    }

    public class AttributeFeature
    {
        public Dictionary<string, string> Attributes { get; set; }
    }
}
