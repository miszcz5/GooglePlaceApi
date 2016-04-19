using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainApplication;

namespace Storage.ReadModels {
    public class LocationBarsEntity {
        public LocationBarsEntity() {
            BarEntities = new List<BarEntity>();
        }
        public int LocationBarsEntityId { get; set; }
        public virtual LocationEntity Location { get; set; }
        public virtual ICollection<BarEntity> BarEntities { get; set; }
    }
}
