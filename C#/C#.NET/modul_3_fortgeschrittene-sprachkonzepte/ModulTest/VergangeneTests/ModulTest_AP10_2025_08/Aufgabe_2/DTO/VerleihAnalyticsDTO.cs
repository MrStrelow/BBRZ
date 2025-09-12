using System.Collections.Generic;
using System.Linq;

namespace Fahrradverleih.DTOs;

public class VerleihAnalyticsDto
{
    public int BeliebtestesFahrrad { get; set; }
    public Dictionary<string, int> Verkaufszahlen { get; set; } = new();
    public string BeliebtestesPaket => Verkaufszahlen.OrderByDescending(kv => kv.Value).FirstOrDefault().Key ?? "N/A";
    public int KundeMitDenMeistenReservierungenId { get; set; }
}