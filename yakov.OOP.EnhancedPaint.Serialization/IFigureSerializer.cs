using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakov.OOP.EnhancedPaint.Serialization
{
    public interface IFigureSerializer<T>
    {
        string Serialize(List<T> figures);
        List<T> Deserialize(string serializedFigures);

    }
}
