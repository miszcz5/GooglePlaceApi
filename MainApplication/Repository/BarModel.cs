using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MainApplication.Repository {
    [DataContract]
    public class BarModel {
        [DataMember]
        public int draw { get; set; }
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public IEnumerable<Bar> data { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
    }
}