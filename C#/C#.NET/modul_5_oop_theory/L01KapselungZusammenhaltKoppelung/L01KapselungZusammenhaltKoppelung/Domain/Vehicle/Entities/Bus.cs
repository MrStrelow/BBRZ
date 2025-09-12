using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Bus : TransportationVehicle
{

    decimal CostToOperatePerHour { get; }
    decimal FuelConsumptionPer100km { get; }

    private const decimal fuelPrice = 1.5m;
    private const decimal averageSpeed = 50;

    public Bus(
        int capacity,
        Place currentLocation,
        (int hoehe, int breite, int laenge) dimension,
        Navigation navi,
        decimal costToOperatePerHour,
        decimal fuelConsumptionPer100km
    ) : base(capacity, currentLocation, dimension, navi)
    {
        CostToOperatePerHour = costToOperatePerHour;
        FuelConsumptionPer100km = fuelConsumptionPer100km;
    }

    protected override decimal calculateCost(Place place)
    {
        // TODO: wer will, richtige Distanz berechnen
        var x = Decimal.ToDouble(place.Address.location.longitude - CurrentLocation.Address.location.longitude);
        var y = Decimal.ToDouble(place.Address.location.latitude - CurrentLocation.Address.location.latitude);
        var distance = (decimal) Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

        var duration = distance / averageSpeed;

        return FuelConsumptionPer100km/100 * distance * fuelPrice + CostToOperatePerHour * duration;
    }
}
