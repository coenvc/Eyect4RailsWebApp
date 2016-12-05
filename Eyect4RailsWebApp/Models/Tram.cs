using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eyect4RailsWebApp.Enums;
using static Eyect4RailsWebApp.Enums.Enums;

namespace eyect4rails.Classes
{
    public class Tram
    {
        private static int TramCounter = 0;
        public int Id { get; set; }
        public int RemiseId { get; set; }
        public TramType Tramtype { get; set; }
        public int TramNumber { get; set; }
        public int Length { get; set; }
        public bool Filthy { get; set; }
        public bool Defective { get; set; }
        public bool ConductorQualified { get; set; }
        public bool Available { get; set; }

        public Tram(int id, int remiseId, Enums.TramType tramtype, int tramnumber, int length,
            bool filthy, bool defective, bool conductorqualified, bool available)
        {
            this.Id = id;
            this.RemiseId = remiseId;
            this.Tramtype = tramtype;
            this.TramNumber = tramnumber;
            this.Length = length;
            this.Filthy = filthy;
            this.Defective = defective;
            this.ConductorQualified = conductorqualified;
            this.Available = available;
        }

        public Tram(int remiseId, Enums.TramType tramtype, int tramnumber, int length,
            bool filthy, bool defective, bool conductorqualified, bool available)
        {
            this.Id = TramCounter;
            this.RemiseId = remiseId;
            this.Tramtype = tramtype;
            this.TramNumber = tramnumber;
            this.Length = length;
            this.Filthy = filthy;
            this.Defective = defective;
            this.ConductorQualified = conductorqualified;
            this.Available = available;
            TramCounter++;
        }
        public override string ToString()
        {
            return $"Tramtype: {Tramtype} Defect: {Defective} Vies: {Filthy}";
        }
    }
}
