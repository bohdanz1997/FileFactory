using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileObmen.Mappers
{
    public interface IMapper
    {
        object Map(object source, object destination);
    }

}
