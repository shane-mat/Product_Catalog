using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public Product()
        {
            Id = new Guid();
        }

        //public void AddEditProductOption(ProductOption productOption)
        //{
        //    var optionFound = _productOptions.FirstOrDefault(r => r.Id == productOption.Id);
        //    if(optionFound == null)
        //    {
        //        _productOptions.Add(productOption);
        //    }
        //    else
        //    {
        //        optionFound = productOption;
        //    }
        //}

        //public void DeleteProductOption(Guid id)
        //{
        //    var option = _productOptions.FirstOrDefault(r => r.Id == id);
        //    _productOptions.Remove(option);
        //}
    }
}