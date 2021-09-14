using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.MVC
{
    public sealed class BonusSpawnController : IExecute
    {
        IBonusFabric bonusFabric;

        public BonusSpawnController(IBonusFabric bonusFabric)
        {
            this.bonusFabric = bonusFabric;
            bonusFabric.CreateBonus();
        }

        public void Execute(float time)
        {
          
        }
    }
}
