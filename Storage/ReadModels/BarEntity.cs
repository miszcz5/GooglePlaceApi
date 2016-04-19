using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MainApplication;

namespace Storage.ReadModels {
    public class BarEntity {
        public int BarEntityId { get; set; }
        public string Name { get; set; }
        public int LocationBarsEntityId { get; set; }
        public virtual LocationBarsEntity LocationBarsEntity { get; set; }
    }
}