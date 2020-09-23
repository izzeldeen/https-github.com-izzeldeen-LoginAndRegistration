using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;


namespace Entites
{
    public class ProductsDto
    {
        public string Name { get; set; }

        public string Price { get; set; }

        public IFormFile files { get; set; }

    }
}
