using FruehstuecksBestellungMVC.ViewModels;

namespace FruehstuecksBestellungMVC.DTOs;

public class OrderDto
{
    public int CustomerId { get; set; } // null nicht mehr möglich! Eine kleine Änderung, jedoch können wir uns auch größere vorstellen.
    public int TableId { get; set; } // null nicht mehr möglich! Eine kleine Änderung, jedoch können wir uns auch größere vorstellen.

    public List<int> SelectedMenuIds { get; set; } = new();

    public List<int> SelectedDishIds { get; set; } = new();

    public OrderDto(OrderViewModel viewModel)
    {
        CustomerId = viewModel.CustomerId.Value; // null nicht möglich
        TableId = viewModel.TableId.Value; // null nicht möglich
        SelectedDishIds = viewModel.SelectedDishIds;
        SelectedMenuIds = viewModel.SelectedMenuIds;
    }
}
