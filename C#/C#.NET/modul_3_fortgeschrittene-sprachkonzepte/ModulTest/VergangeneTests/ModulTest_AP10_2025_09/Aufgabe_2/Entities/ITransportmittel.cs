using System.Text.Json.Serialization;
using Ticketverkauf.Entities;

namespace Ticketverkauf.Entities;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(Bus), typeDiscriminator: "bus")]
[JsonDerivedType(typeof(Zug), typeDiscriminator: "zug")]
public interface ITransportmittel
{
    public int Id { get; set; }
    public decimal TicketPreis { get; set; }
}