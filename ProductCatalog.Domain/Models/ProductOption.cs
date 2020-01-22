﻿using System;

namespace ProductCatalog.Domain.Models
{
    public class ProductOption
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ProductOption()
        {
            Id = Guid.NewGuid();
        }
    }
}