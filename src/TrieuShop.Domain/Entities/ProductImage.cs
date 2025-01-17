﻿namespace TrieuShop.Domain.Entities;

public class ProductImage
{
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Product Product { get; set; } = null!;
}
