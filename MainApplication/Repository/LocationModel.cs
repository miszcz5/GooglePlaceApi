using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MainApplication.Repository {
    [DataContract]
    public class LocationModel {
        [DataMember]
        public int draw { get; set; }
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public IEnumerable<Location> data { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
    }
}