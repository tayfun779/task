using task.Models;
using Microsoft.EntityFrameworkCore;

namespace task.viewModel;

public class HomeViewModel
{
    public List<Shipping> Shippings { get; set; }
}