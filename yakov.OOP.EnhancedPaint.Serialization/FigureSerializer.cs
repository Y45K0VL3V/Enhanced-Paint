using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yakov.OOP.EnhancedPaint.Figures;

namespace yakov.OOP.EnhancedPaint.Serialization
{
    public class FigureSerializer<T> : IFigureSerializer<T> where T : class
    {
        public List<T> Deserialize(string serializedFigures)
        {
            return JsonConvert.DeserializeObject<List<T>>(serializedFigures);
        }

        public string Serialize(List<T> figures)
        {
            return JsonConvert.SerializeObject(figures);
        }
    }
}