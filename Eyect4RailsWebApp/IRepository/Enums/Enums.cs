using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eyect4RailsWebApp.Enums
{
    public class Enums
    {
        public enum TramType
        {
            Combino = 1,
            ElevenG,
            DubbelkopCombino,
            TwelveG,
            OpleidingsTram,
            NineG,
            TenG
        };

        public enum Tasks
        {
            KleineSchoonmaak,
            GroteSchoonmaak,
            KleineReparatie,
            GroteReparatie
        };

        public enum Rights
        {
            WagensInvoeren = 1,
            StatusVeranderen,
            SporenBlokkeren,
            WagensNaarDeSchoonmaakSturen,
            TijdsindicatieReparatieGeven,
            SchoonmaakLijstOpvragen,
            DatumTijdSchoonmaakInvoeren
        };
    }
}