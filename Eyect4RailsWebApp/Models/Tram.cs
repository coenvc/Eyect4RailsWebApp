using System.ComponentModel;
using Eyect4RailsWebApp.Enums;
using Eyect4RailsWebApp.Interfaces;

namespace Eyect4RailsWebApp.Models
{
    public class Tram : ICruddable
    {
        #region Properties
        [DisplayName("TramID")]
        public int Id { get; set; }
        public int RemiseId { get; set; }
        public TramType Tramtype { get; set; }
        public int TramNumber { get; set; }
        public int Length { get; set; }
        public bool Filthy { get; set; }
        public bool Defective { get; set; }
        public bool ConductorQualified { get; set; }
        public bool Available { get; set; }
        #endregion

        public Tram()
        {
        }

        public Tram(int remiseId, TramType tramtype, int tramNumber, int length, bool filthy, bool defective, bool conductorQualified, bool available)
        {
            RemiseId = remiseId;
            Tramtype = tramtype;
            TramNumber = tramNumber;
            Length = length;
            Filthy = filthy;
            Defective = defective;
            ConductorQualified = conductorQualified;
            Available = available;
        }

        public Tram(int id, int remiseId, TramType tramtype, int tramNumber, int length, bool filthy, bool defective, bool conductorQualified, bool available)
        {
            Id = id;
            RemiseId = remiseId;
            Tramtype = tramtype;
            TramNumber = tramNumber;
            Length = length;
            Filthy = filthy;
            Defective = defective;
            ConductorQualified = conductorQualified;
            Available = available;
        }

        public override string ToString()
        {
            return $"Tramtype: {Tramtype} Defect: {Defective} Vies: {Filthy}";
        }
    }
}
