using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zad2.Core
{
    public class TodoViewModel
    {
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public int DaysUntil { get; set;  }

        public TodoViewModel (string Text, DateTime DateCreated)
        {
            this.Text = Text;
            this.DateCreated = DateCreated;
            this.DaysUntil = (int) (DateTime.Now - DateCreated).TotalDays;
        }


    }
}
