using Code.MVC.Delegates;
using System;

namespace Code.MVC
{
   public class GameInitialisation
    {
      
        public GameInitialisation(PlayerData playerData, Controllers controllers,InputType inputType, InputData inputData,EnemyData enemyData,ref Action action,
            BonusData bonusData)
        {
            IPlayerFabric fabric = new PlayerFabric(playerData);
            IEnemyFabrik enemyfabric = new EnemyFabric(enemyData);
            IGameOverFabric gameOver = new GameOverFabric();
            IBonusFabric bonusFabric = new BonusFabric(bonusData);

            var playerInitialisation =new  PlayerInitialisation(fabric);
            var clickController = new ClickController(inputType, inputData);
            var spawnEnemyController = new EnemySpawnController(enemyfabric,enemyData,ref action);
            var gameOverController = new GameOverController(gameOver);
            var bonusController = new BonusSpawnController(bonusFabric);


            controllers.Add(playerInitialisation);
            controllers.Add(clickController);
            controllers.Add(spawnEnemyController);
            controllers.Add(bonusController);

        }
    }
}
