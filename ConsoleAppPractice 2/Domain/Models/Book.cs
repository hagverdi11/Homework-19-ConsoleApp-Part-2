using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Book: BaseEntity
    {

        public string Name { get; set; }
        public string Author { get; set; }
        public Library Library { get; set; }

    }
}
