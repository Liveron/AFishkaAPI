using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFishka.Domain
{
    public class Event
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}
