using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.MVC
{
    class GameOverController : IExecute
    {
        IGameOverFabric _overFabric;

        public GameOverController(IGameOverFabric overFabric)
        {
            _overFabric = overFabric;
            _overFabric.CreateGO();

        }

        void IExecute.Execute(float time)
        {
           
        }
    }
}
