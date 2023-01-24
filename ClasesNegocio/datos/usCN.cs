using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClasesNegocio.datos
{
    [DataContract]
    public class usCN
    {
        [DataMember]
        public String date { get; set; }
        [DataMember]
        public String states { get; set; }
        [DataMember]
        public String positive { get; set; }
        [DataMember]
        public String negative { get; set; }
        [DataMember]
        public String pending { get; set; }
        [DataMember]
        public String hospitalizedCurrently { get; set; }
        [DataMember]
        public String hospitalizedCumulative { get; set; }
        [DataMember]
        public String inIcuCurrently { get; set; }
        [DataMember]
        public String inIcuCumulative { get; set; }
        [DataMember]
        public String onVentilatorCurrently { get; set; }
        [DataMember]
        public String onVentilatorCumulative { get; set; }
        [DataMember]
        public String dateChecked { get; set; }
        [DataMember]
        public String death { get; set; }
        [DataMember]
        public String hospitalized { get; set; }
        [DataMember]
        public String totalTestResults { get; set; }
        [DataMember]
        public String lastModified { get; set; }
        [DataMember]
        public String recovered { get; set; }
        [DataMember]
        public String total { get; set; }
        [DataMember]
        public String posNeg { get; set; }
        [DataMember]
        public String deathIncrease { get; set; }
        [DataMember]
        public String hospitalizedIncrease { get; set; }
        [DataMember]
        public String negativeIncrease { get; set; }
        [DataMember]
        public String positiveIncrease { get; set; }
        [DataMember]
        public String totalTestResultsIncrease { get; set; }
        [DataMember]
        public string hash { get; set; }
        public usCN() {
            this.date = String.Empty;
            this.states = String.Empty;
            this.positive = String.Empty;
            this.negative = String.Empty;
            this.pending = String.Empty;
            this.hospitalizedCurrently = String.Empty;
            this.hospitalizedCumulative = String.Empty;
            this.inIcuCurrently = String.Empty;
            this.inIcuCumulative = String.Empty;
            this.onVentilatorCurrently = String.Empty;
            this.onVentilatorCumulative = String.Empty;
            this.dateChecked = String.Empty;
            this.death = String.Empty;
            this.hospitalized = String.Empty;
            this.totalTestResults = String.Empty;
            this.lastModified = String.Empty;
            this.recovered = String.Empty;
            this.total = String.Empty;
            this.posNeg = String.Empty;
            this.deathIncrease = String.Empty;
            this.hospitalizedIncrease = String.Empty;
            this.negativeIncrease = String.Empty;
            this.positiveIncrease = String.Empty;
            this.totalTestResultsIncrease = String.Empty;
            this.hash = String.Empty;
        }
    }
}
