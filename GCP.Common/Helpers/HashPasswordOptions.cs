using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCP.Common.Helpers
{
    public static class HashPasswordOptions
    {
        public const int NUM_BYTES_REQUESTED = 256 / 8;
        public const int ITERATION_COUNT = 10000;
    }
}
