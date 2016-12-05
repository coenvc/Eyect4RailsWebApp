using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eyect4RailsWebApp.Enums
{
    public enum TramType
    {
        Combino = 1,
        ElevenG,
        DubbelKopCombino,
        TwelveG,
        Opleidingstram,
        NineG,
        TenG
    }

    public enum Rights
    {
        WagensInvoeren = 1,
        StatusVeranderen,
        SporenBlokkeren,
        WagensNaarDeSchoonmaakSturen,
        TijdsindicatieReparatieGeven,
        SchoonmaakLijstOpvragen,
        DatumTijdSchoonmaakInvoeren
    }

    public enum Tasks
    {
        KleineSchoonmaak,
        GroteSchoonmaak,
        KleineReparatie,
        GroteReparatie
    }

    public enum Function
    {
        Beheerder = 1, 
        Wagenparkbeheerder, 
        Bestuurder, 
        Technicus, 
        Schoonmaker
    }
}