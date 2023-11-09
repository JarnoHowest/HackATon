using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackATon.PathB.Cons
{
    public interface IChallengeClearer 
    {
        public Task<string> ClearChallenge();
        public Task<string> StartChallenge();
    }
}
