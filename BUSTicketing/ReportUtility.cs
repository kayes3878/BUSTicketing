using BUSTicketing.Reporting.UI;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BUSTicketing
{
    public class ReportUtility
    {
        public static void Display_report(ReportClass rc, object objDataSource, Window parentWindow)
        {
            try
            {
                rc.SetDataSource(objDataSource);
                ReportViewerUI Viewer = new ReportViewerUI();
                Viewer.setReportSource(rc);
                Viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
