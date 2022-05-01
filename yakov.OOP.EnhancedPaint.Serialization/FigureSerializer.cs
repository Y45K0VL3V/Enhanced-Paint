using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yakov.OOP.EnhancedPaint.Figures;

namespace yakov.OOP.EnhancedPaint.Serialization
{
    public class FigureSerializer : IFigureSerialize<FigureBase>
    {
        public List<FigureBase> Deserialize(string serializedFigures)
        {
            throw new NotImplementedException();
        }

        public string Serialize(List<FigureBase> figures)
        {
            return JsonConvert.SerializeObject(figures);
        }
    }
}