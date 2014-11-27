using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platformPerformer {
    class inbuildSort : platformMethod<int[], int[]>{

        public int[] performMethod(int[] input) {

            Array.Sort( input );

            return input;


        }
        public String getName() {
            return "inbuild sort c#"; 
        }


    }
}
