using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.MVC
{
    public class PlayerInitialisation : IInitialisation
    {
        

        public PlayerInitialisation( IPlayerFabric fabric)
        {
            fabric.CreatePlayer();
        }

      
        public void Initialisation()
        {
          
        }
    }
}
