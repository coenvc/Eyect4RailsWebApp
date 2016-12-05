using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eyect4rails.Classes
{
    public class Tram
    {
        private static int TramCounter = 0;

        public int Id;
        public string TramType { get; private set; }
        public string Status { get;  set; }
        public int Sectors;
        public bool IsParked;

        public Tram(int id, string tramType, string status, int sectors)
        {
            Id = id;
            TramType = tramType;
            Status = status;
            Sectors = sectors;
            IsParked = false;
        }

        public Tram(string tramType, string status, int sectors)
        {
            Id = TramCounter;
            TramType = tramType;
            Status = status;
            Sectors = sectors;
            IsParked = false;

            TramCounter++;
        }

        public bool SetTramType(string type)
        {
            if (type == "Combino" || type == "Dubbelkop Combino" || type == "11G" || type == "12G" || type == "Opleidingstrein")
            {
                this.TramType = type;
                return true;
            }
            return false;
        }

        public bool SetTramStatus(string status)
        {
            if (status == "Defect" || status == "Schoonmaak" || status == "Dienst" || status == "Remise" || status == "Onderhoud")
            {
                this.Status = status;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Tramtype: {TramType} Status: {Status}";
        }
    }
}
