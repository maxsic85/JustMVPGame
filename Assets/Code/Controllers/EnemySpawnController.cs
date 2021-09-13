using Code.MVC.Delegates;
using System;
using System.Collections;
using UnityEngine;

namespace Code.MVC
{
    public class EnemySpawnController : IExecute
    {
        IEnemyFabrik _enemyFabrik;
        EnemyData _enemyData;
       
        public EnemySpawnController(IEnemyFabrik enemyFabrik, EnemyData enemyData,ref Action some)
        {
            this._enemyFabrik = enemyFabrik;
            this._enemyData = enemyData;
          
            some = GenericEnemy;
        }

        private void GenericEnemy()
        {
            _enemyFabrik.CreateEnemy();
        }

        public void Execute(float time)
        {
           
        }
        ~EnemySpawnController()
        {
            
        }
    }
}
