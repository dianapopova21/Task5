using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.Models
{
    public class Test
    {
        public int Id { get; set; }

        public List<Question> Questions { get; set; }  

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
