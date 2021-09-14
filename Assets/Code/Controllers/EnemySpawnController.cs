using Code.MVC.Delegates;
using System;
using System.Collections;
using UnityEngine;

namespace Code.MVC
{
    public sealed class EnemySpawnController : IExecute
    {
        IEnemyFabrik _enemyFabrik;
        EnemyData _enemyData;
       
        public EnemySpawnController(IEnemyFabrik enemyFabrik, EnemyData enemyData,ref Action genericEnemy)
        {
            this._enemyFabrik = enemyFabrik;
            this._enemyData = enemyData;
          
            genericEnemy = GenericEnemy;
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
