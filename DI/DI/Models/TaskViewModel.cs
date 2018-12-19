using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DI.Models
{
    public class TaskViewModel
    {
        [JsonRequired]
        public string Name { get; set; }
    }
}
