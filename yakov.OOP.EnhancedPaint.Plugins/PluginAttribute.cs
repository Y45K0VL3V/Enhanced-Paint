using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakov.OOP.EnhancedPaint.Plugins
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PluginAttribute: Attribute
    {
        public PluginAttribute(PluginType T) { Type = T; }
        public PluginType Type { get; }
    }
}
