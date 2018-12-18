using System;

namespace Reflection.Core
{
    [Selector(NickName = "Dick")]
    public class D
    {
    }
    [Selector(NickName = "Cock")]
    public class C
    {
        [Lezem]
        public string Value { get; set; }
    }
}
