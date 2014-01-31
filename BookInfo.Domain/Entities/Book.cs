using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInfo.Domain.Entities
{
    public class Book
    {
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public DateTime Year { get; set; }
    }
}
