using System;
using System.Collections.Generic;

namespace task_2_api.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Descr { get; set; }

    public decimal? Price { get; set; }

    public string? ProductImage { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
