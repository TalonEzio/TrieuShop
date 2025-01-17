﻿namespace TrieuShop.Domain.Entities;

public class Size
{
    public int SizeId { get; set; }

    public string? SizeName { get; set; }

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = [];
}
