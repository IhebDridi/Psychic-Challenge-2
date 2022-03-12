using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Psychic
{
    public interface IPsychic
    {
        int CurrentAttempt { get; }
        int LowerBound { get; }
        int UpperBound { get; }
        bool Complete { get; }
        IEnumerable<int> AttemptHistory { get; }
        int AttemptCount { get; }
        void Higher();
        void Lower();
        void Correct();
    }
}