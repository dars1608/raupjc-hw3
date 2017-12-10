using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zad2.Core
{
    public class IndexViewModel
    {
        public List<TodoViewModel> TodoItems { get; set; }
        public IndexViewModel(List<TodoViewModel> list)
        {
            TodoItems = new List<TodoViewModel>(list);
        }
    }
}
