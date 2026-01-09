using FruehstuecksBestellungMVC.Models.Enums;
using FruehstuecksBestellungMVC.ViewModels;

namespace FruehstuecksBestellungMVC.DTOs;

public class OrderDto
{
    public OrderType Type { get; set; }
    public int CustomerId { get; set; }
    public int? TableId { get; set; }

    // Delivery Details
    public string? DeliveryAddress { get; set; }
    public string? DeliveryEmail { get; set; }
    public string? DeliveryPhone { get; set; }
    public DateTime? ExpectedDeliveryDate { get; set; }

    public List<int> SelectedMenuIds { get; set; } = new();
    public List<int> SelectedDishIds { get; set; } = new();

    public OrderDto(OrderViewModel viewModel)
    {
        Type = viewModel.Type;
        CustomerId = viewModel.CustomerId ?? 0;
        TableId = viewModel.TableId;

        DeliveryAddress = viewModel.DeliveryAddress;
        DeliveryEmail = viewModel.DeliveryEmail;
        DeliveryPhone = viewModel.DeliveryPhone;
        ExpectedDeliveryDate = viewModel.ExpectedDeliveryDate;

        SelectedDishIds = viewModel.SelectedDishIds;
        SelectedMenuIds = viewModel.SelectedMenuIds;
    }
}