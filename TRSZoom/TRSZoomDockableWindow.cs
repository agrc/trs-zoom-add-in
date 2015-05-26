using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;

namespace TRSZoom
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class TRSZoomDockableWindow : UserControl
    {
        string meridian = "SL";
        string township;
        string range;
        string section;

        const string apiKey = "AGRC-PLSSAddIn";
        const string rangeUrl = "http://api.mapserv.utah.gov/api/v1/search/SGID10.CADASTRE.PLSS_TR_Lookup/" +
            "PairsWith?predicate=TorRNAME=\'{0}\'&apikey={1}";
        const string sectionUrl = "http://api.mapserv.utah.gov/api/v1/search/SGID10.CADASTRE.PLSS_Sec_Lookup/" +
            "PairsWith?predicate=TRNAME=\'{0}\'&apikey={1}";
        const string envelopeUrl = "http://api.mapserv.utah.gov/api/v1/search/{0}/shape@?predicate={1}&apikey={2}";
        const string choose = "Choose an option";

        HttpClient client;

        string[] allSLTownships = {choose, "1N", "2N", "3N", "4N", "5N", "6N", "7N", "8N", "9N", "10N", "10.5N", "11N", "12N", "13N", "14N", "15N", "1S", "1.5S", "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "11S", "11.5S", "12S", "13S", "14S", "15S", "15.5S", "16S", "17S", "18S", "19S", "19.5S", "20S", "20.5S", "21S", "22S", "23S", "24S", "25S", "26S", "27S", "28S", "28.5S", "29S", "29.5S", "30S", "30.5S", "31S", "32S", "32.5S", "33S", "34S", "35S", "35.5S", "36S", "37S", "37.5S", "38S", "38.5S", "39S", "40S", "40.5S", "41S", "42S", "42.5S", "43S", "44S" };
        string[] allUBTownships = {choose, "1N", "2N", "3N", "4N", "5N", "1S", "2S", "3S", "4S", "5S", "6S", "7S"};

        public TRSZoomDockableWindow(object hook)
        {
            client = new HttpClient();

            InitializeComponent();
            this.Hook = hook;

            populateTddl();
        }

        /// <summary>
        /// Host object of the dockable window
        /// </summary>
        private object Hook
        {
            get;
            set;
        }

        /// <summary>
        /// Implementation class of the dockable window add-in. It is responsible for 
        /// creating and disposing the user interface class of the dockable window.
        /// </summary>
        public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
        {
            private TRSZoomDockableWindow m_windowUI;

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new TRSZoomDockableWindow(this.Hook);
                return m_windowUI.Handle;
            }

            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }

        }

        private void populateTddl()
        {
            if (this.UB.Checked)
            {
                cbo_Township.Items.Clear();
                cbo_Township.Items.AddRange(allUBTownships);
            }
            else
            {
                cbo_Township.Items.Clear();
                cbo_Township.Items.AddRange(allSLTownships);
            }

            cbo_Township.SelectedIndex = 0;
            cbo_Township.Refresh();
        }

        private async void cbo_Township_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_Range.Items.Clear();
            range = null;

            if ((cbo_Township.SelectedItem != null) && (cbo_Township.SelectedItem != choose))
            {
                township = cbo_Township.SelectedItem.ToString();
                var items = await populateDropDown("range");
                cbo_Range.Items.AddRange(items);
                cbo_Range.SelectedIndex = 0;
                cbo_Range.Refresh();
            }
            else
            {
                township = null;
                cbo_Range.Text = "";
                cbo_Section.Items.Clear();
                cbo_Section.Text = "";
            }
        }

        private async void cbo_Range_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_Section.Items.Clear();
            section = null;

            if ((cbo_Range.SelectedItem != null) && (cbo_Range.SelectedItem != choose))
            {
                range = cbo_Range.SelectedItem.ToString();
                var items = await populateDropDown("section");
                cbo_Section.Items.AddRange(items);
                cbo_Section.SelectedIndex = 0;
                cbo_Section.Refresh();
            }
            else
            {
                range = null;
                cbo_Section.Text = "";
            }
        }

        private void cbo_Section_SelectedIndexChanged(object sender, EventArgs e)
        {
            section = cbo_Section.SelectedItem.ToString();
        }

        private async Task<object[]> populateDropDown(string prop)
        {
            var url = buildUrlFor(prop);
            var response = await client.GetAsync(url);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                this.messageBox.Text = "Request failed";
                this.messageBox.Refresh();
                return new object[0];
            }
            var resultContainer = await response.Content.ReadAsAsync<ResultContainer<List<AttributeFeature>>>();
            if (resultContainer.Status != (int)HttpStatusCode.OK || resultContainer.Result.Count == 0)
            {
                this.messageBox.Text = "Not Found";
                this.messageBox.Refresh();
                return new object[0];
            }

            var items = resultContainer.Result[0].Attributes["pairswith"].Split('|').Select(x => x.Replace("R", "")).ToList();
            items.Insert(0, choose);
            return items.ToArray();
        }

        private string buildUrlFor(string prop)
        {
            string url;
            if (prop == "range")
            {
                url = rangeUrl;
            }
            else
            {
                url = sectionUrl;
            }

            return string.Format(url, buildTrsLabel(prop), apiKey);
        }

        private string buildTrsLabel(string prop)
        {
            if (string.IsNullOrEmpty(meridian)) {
                return "";
            }

            var label = meridian;

            if (string.IsNullOrEmpty(township))
            {
                return label;
            }

            label += 'T' + township;

            if (string.IsNullOrEmpty(range) || prop == "range") {
                return label;
            }

            label += 'R' + range;

            return label;
        }

        private void SL_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SL.Checked)
            {
                this.meridian = "SL";
            }
            else
            {
                this.meridian = "UB";
            }

            populateTddl();
        }

        private async void zoomToTRS_Click(object sender, EventArgs e)
        {
            if (cbo_Township.SelectedItem == choose || cbo_Township.Text == "" ||
                cbo_Range.SelectedItem == choose || cbo_Range.Text == "")
            {
                this.messageBox.Text = "Select Township AND Range";
                return;
            }

            try
            {
                bool querySection = cbo_Section.SelectedItem != choose;
                string queryFCName;

                if (querySection)
                {
                    queryFCName = "SGID10.CADASTRE.PLSSSections_GCDB";
                }
                else
                {
                    queryFCName = "SGID10.CADASTRE.PLSSTownships_GCDB";
                }
                const string UrlTemplate = "http://api.mapserv.utah.gov/api/v1/search/{0}/shape@envelope";
                var url = string.Format(UrlTemplate, queryFCName);

                var options = new Dictionary<string, object>();
                options.Add("apiKey", "AGRC-PLSSAddIn");
                options.Add("predicate", GetQuery(querySection));

                url += "?" + string.Join("&", options.Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(x.Value.ToString()))));

                var request = new HttpClient();

                var response = await request.GetAsync(url);

                var resultContainer = await response.Content.ReadAsAsync<ResultContainer<Feature[]>>();

                if (response.StatusCode != HttpStatusCode.OK || resultContainer.Status != (int)HttpStatusCode.OK || resultContainer.Result.Length == 0)
                {
                    this.messageBox.Text = "Not Found";
                    this.messageBox.Refresh();
                    return;
                }

                var feat = resultContainer.Result[0];
                IEnvelope extentEnvelope = feat.Geometry.Polygon.Envelope;
                extentEnvelope.Expand(1.1, 1.1, true);

                IMxDocument doc = (IMxDocument)ArcMap.Application.Document;
                IActiveView activeView = doc.ActiveView;

                //check to make sure map has spatial reference. If not, quit.
                if (activeView.FocusMap.SpatialReference == null)
                {
                    this.messageBox.Text = "Spatial ref not set";
                    return;
                }

                if (activeView.FocusMap.SpatialReference.FactoryCode != 26912)
                {
                    projectEnvelope(extentEnvelope, activeView);
                }

                activeView.Extent = extentEnvelope as IEnvelope;
                activeView.Refresh();
                this.messageBox.Text = "";
                this.messageBox.Refresh();
            }
            catch
            {
                this.messageBox.Text = "Error querying PLSS data!";
                this.messageBox.Refresh();
            }
        }

        private string GetQuery(bool querySection)
        {
            var sectionQuery = "";
            if (querySection) 
            {
                if (section.Length == 1)
                {
                    section = "0" + section;
                }
                sectionQuery = string.Format("AND SECTION = '{0}'", section);
            }

            return string.Format("LABEL = 'T{0} R{1}' {2} AND BASEMERIDIAN = '{3}'", township, range, sectionQuery, meridianId());
        }

        private void projectEnvelope(IEnvelope inEnv, IActiveView activeView)
        {
            ISpatialReference viewSpatRef = activeView.FocusMap.SpatialReference;
            inEnv.Project(viewSpatRef);
        }

        private string meridianId()
        {
            if (meridian == "SL")
            {
                return "26";
            }
            else
            {
                return "30";
            }
        }
    }
}
