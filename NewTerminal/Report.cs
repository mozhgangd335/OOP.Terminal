using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTerminal
{
    internal class Report
    {
        public Report(int travelId, ReportTYpe reportTYpe, double incoming, double outcoming)
        {
            TravelId = travelId;
            ReportTYpe = reportTYpe;
            Incoming = incoming;
            this.outcoming = outcoming;
        }

        public int TravelId { get; set; }
        public ReportTYpe ReportTYpe { get; set; }
        public double Incoming { get; set; }
        public double outcoming { get; set; }

    }
   
}public enum ReportTYpe
{
    reserve=1,
    boughth,
    viptravelcancel,
    normaltravelcancel

}
