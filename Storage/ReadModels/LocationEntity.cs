using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MainApplication;

namespace Storage.ReadModels {
    public class LocationEntity : Location {
        [Key, ForeignKey("LocationBarsEntity")]
        public int LocationBarsEntityId { get; set; }
        public virtual LocationBarsEntity LocationBarsEntity { get; set; }
    }
}