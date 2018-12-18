using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.Core
{
  public class SelectorAttribute : Attribute
    {
        public string NickName { get; set; }

    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false,  Inherited = true)]
    public class LezemAttribute : Attribute
    {
 

    }
}
