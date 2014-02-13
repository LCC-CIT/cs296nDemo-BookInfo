using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookInfo.Domain.Entities;

namespace BookInfo.WebUI.Models
{
    public class FrontPageViewModel
    {
        public StatisticsViewModel Stats { get; set; }
        public Book TheBook { get; set; }
    }
}