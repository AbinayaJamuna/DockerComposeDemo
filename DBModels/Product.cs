using System;
using System.Collections.Generic;

namespace DockerComposeDemo.DBModels
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? ImageFile { get; set; }
        public string? Price { get; set; }
    }
}
