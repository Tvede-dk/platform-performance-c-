using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platformPerformer {
    public interface platformMethod<T, TT> {
        T performMethod(TT input);

         String getName();
    }
}
