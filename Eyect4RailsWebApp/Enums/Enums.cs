using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    /// <summary>
    /// Tasks is REQUIRED to be 1:1 identical to the Task table in the database
    /// if this is not the case the tasks WILL be messed up and will no longer sync
    /// sadly an enum is not variable by definition and therefor we cannot load it from the DB
    /// If anything odd happens to this enum please check if the IDs match with the DB
    /// </summary>
    public enum Tasks
    {
        [Description("Grote Schoonmaak")]
        GroteSchoonmaak = 0,
        [Description("Kleine Schoonmaak")]
        KleineSchoonmaak = 1,
        [Description("Grote Reparatie")]
        GroteReparatie = 2,
        [Description("Kleine Reparatie")]
        KleineReparatie = 3
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