using System;
using System.Collections.Generic;

namespace Aufgabe_1.DTOs;

public record TicketInfoDto(int TicketId, decimal Preis, string PassagierName);
public record CustomerRevenueDto(string PassengerName, decimal Umsatz);
public record AirlineTopCustomersDto(string AirlineName, List<CustomerRevenueDto> TopCustomers);