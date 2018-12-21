using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DI.Models
{

    public class TaskViewModel
    {
        /// <summary>
        /// The name of the task
        /// </summary>
        [JsonRequired]
        
        public string Name { get; set; }
    }
}
