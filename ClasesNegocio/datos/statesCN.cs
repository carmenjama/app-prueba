using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClasesNegocio.datos
{
    [DataContract]
    public  class statesCN
    {
        [DataMember]
        public string date { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string positive { get; set; }
        [DataMember]
        public string probableCases { get; set; }
        [DataMember]
        public string negative { get; set; }
        [DataMember]
        public string pending { get; set; }
        [DataMember]
        public string totalTestResultsSource { get; set; }
        [DataMember]
        public string totalTestResults { get; set; }
        [DataMember]
        public string hospitalizedCurrently { get; set; }
        [DataMember]
        public string hospitalizedCumulative { get; set; }
        [DataMember]
        public string inIcuCurrently { get; set; }
        [DataMember]
        public string inIcuCumulative { get; set; }
        [DataMember]
        public string onVentilatorCurrently { get; set; }
        [DataMember]
        public string onVentilatorCumulative { get; set; }
        [DataMember]
        public string recovered { get; set; }
        [DataMember]
        public string lastUpdateEt { get; set; }
        [DataMember]
        public string dateModified { get; set; }
        [DataMember]
        public string checkTimeEt { get; set; }
        [DataMember]
        public string death { get; set; }
        [DataMember]
        public string hospitalized { get; set; }
        [DataMember]
        public string hospitalizedDischarged { get; set; }
        [DataMember]
        public string dateChecked { get; set; }
        [DataMember]
        public string totalTestsViral { get; set; }
        [DataMember]
        public string positiveTestsViral { get; set; }
        [DataMember]
        public string negativeTestsViral { get; set; }
        [DataMember]
        public string positiveCasesViral { get; set; }
        [DataMember]
        public string deathConfirmed { get; set; }
        [DataMember]
        public string deathProbable { get; set; }
        [DataMember]
        public string totalTestEncountersViral { get; set; }
        [DataMember]
        public string totalTestsPeopleViral { get; set; }
        [DataMember]
        public string totalTestsAntibody { get; set; }
        [DataMember]
        public string positiveTestsAntibody { get; set; }
        [DataMember]
        public string negativeTestsAntibody { get; set; }
        [DataMember]
        public string totalTestsPeopleAntibody { get; set; }
        [DataMember]
        public string positiveTestsPeopleAntibody { get; set; }
        [DataMember]
        public string negativeTestsPeopleAntibody { get; set; }
        [DataMember]
        public String totalTestsPeopleAntigen { get; set; }
        [DataMember]
        public String positiveTestsPeopleAntigen { get; set; }
        [DataMember]
        public String totalTestsAntigen { get; set; }
        [DataMember]
        public String positiveTestsAntigen { get; set; }
        [DataMember]
        public string fips { get; set; }
        [DataMember]
        public string positiveIncrease { get; set; }
        [DataMember]
        public string negativeIncrease { get; set; }
        [DataMember]
        public string total { get; set; }
        [DataMember]
        public string totalTestResultsIncrease { get; set; }
        [DataMember]
        public string posNeg { get; set; }
        [DataMember]
        public String dataQualityGrade { get; set; }
        [DataMember]
        public string deathIncrease { get; set; }
        [DataMember]
        public string hospitalizedIncrease { get; set; }
        [DataMember]
        public string hash { get; set; }
        [DataMember]
        public string commercialScore { get; set; }
        [DataMember]
        public string negativeRegularScore { get; set; }
        [DataMember]
        public string negativeScore { get; set; }
        [DataMember]
        public string positiveScore { get; set; }
        public string score { get; set; }
        [DataMember]
        public string grade { get; set; }
        

        public statesCN()
        {
            this.date = String.Empty;
            this.state = String.Empty;
            this.positive = String.Empty;
            this.probableCases = String.Empty;
            this.negative = String.Empty;
            this.pending = String.Empty;
            this.totalTestResultsSource = String.Empty;
            this.totalTestResults = String.Empty;
            this.hospitalizedCurrently = String.Empty;
            this.hospitalizedCumulative = String.Empty;
            this.inIcuCurrently = String.Empty;
            this.inIcuCumulative = String.Empty;
            this.onVentilatorCurrently = String.Empty;
            this.onVentilatorCumulative = String.Empty;
            this.recovered = String.Empty;
            this.lastUpdateEt = String.Empty;
            this.dateModified = String.Empty;
            this.checkTimeEt = String.Empty;
            this.death = String.Empty;
            this.hospitalized = String.Empty;
            this.hospitalizedDischarged = String.Empty;
            this.dateChecked = String.Empty;
            this.totalTestsViral = String.Empty;
            this.positiveTestsViral = String.Empty;
            this.negativeTestsViral = String.Empty;
            this.positiveCasesViral = String.Empty;
            this.deathConfirmed = String.Empty;
            this.deathProbable = String.Empty;
            this.totalTestEncountersViral = String.Empty;
            this.totalTestsPeopleViral = String.Empty;
            this.totalTestsAntibody = String.Empty;
            this.positiveTestsAntibody = String.Empty;
            this.negativeTestsAntibody = String.Empty;
            this.totalTestsPeopleAntibody = String.Empty;
            this.positiveTestsPeopleAntibody = String.Empty;
            this.negativeTestsPeopleAntibody = String.Empty;
            this.totalTestsPeopleAntigen = String.Empty;
            this.positiveTestsPeopleAntigen = String.Empty;
            this.totalTestsAntigen = String.Empty;
            this.positiveTestsAntigen = String.Empty;
            this.fips = String.Empty;
            this.positiveIncrease = String.Empty;
            this.negativeIncrease = String.Empty;
            this.total = String.Empty;
            this.totalTestResultsIncrease = String.Empty;
            this.posNeg = String.Empty;
            this.dataQualityGrade = String.Empty;
            this.deathIncrease = String.Empty;
            this.hospitalizedIncrease = String.Empty;
            this.hash = String.Empty;
            this.commercialScore = String.Empty;
            this.negativeRegularScore = String.Empty;
            this.negativeScore = String.Empty;
            this.positiveScore = String.Empty;
            this.score = String.Empty;
            this.grade = String.Empty;
        }
    }
}
