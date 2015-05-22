using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TRSZoom
{
    public class TRSZoomButton : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public TRSZoomButton()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            ArcMap.Application.CurrentTool = null;
            var window = GetDockableWindow(ThisAddIn.IDs.TRSZoomDockableWindow);
            window.Show(true);
        }
        internal static ESRI.ArcGIS.Framework.IDockableWindow GetDockableWindow(string id)
        {
            // Use GetDockableWindow directly intead of FromID as we want the client IDockableWindow not the internal class
            ESRI.ArcGIS.esriSystem.UID dockWinID = new ESRI.ArcGIS.esriSystem.UIDClass();
            dockWinID.Value = id;
            return ArcMap.DockableWindowManager.GetDockableWindow(dockWinID);
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
