using UnityEngine;


namespace Code.MVC
{
    public class EnemyFabric : IEnemyFabrik
    {
        EnemyData _enemyData;
        Canvas _canvas;
        public EnemyFabric(EnemyData enemyData)
        {
            _enemyData = enemyData;
            _canvas = GameObject.FindObjectOfType<Canvas>();
        }

        public Transform CreateEnemy()
        {
            var enemy = new GameObject(_enemyData.Name).AddSprite(_enemyData.Sprite)
           .AddRigitBody2D().AddBoxCollidery2D().transform;
            enemy.localScale = Vector3.one;
            enemy.transform.SetParent(_canvas.transform);
            enemy.gameObject.GetOrAddComponent<Enemy>();
            int sizeX = Random.RandomRange(-(Screen.width / 2), Screen.width/2);
            sizeX = (int)((sizeX > 0) ? sizeX - enemy.GetComponent<RectTransform>().rect.width / 2 : sizeX + (int)enemy.GetComponent<RectTransform>().rect.width/2);
            int sizey = Screen.height;
            enemy.localPosition = new Vector3(sizeX, sizey, 0);
            return enemy;
        }
    }
}
