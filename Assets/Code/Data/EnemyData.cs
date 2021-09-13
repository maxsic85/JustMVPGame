using UnityEngine;

namespace Code.MVC
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy")]
    public class EnemyData : ScriptableObject
    {
        public Sprite Sprite;
        [SerializeField] private string _name;
        [SerializeField, Range(0, 10)] private int _hp;
        [SerializeField, Range(0, 10)] private int _speed;

        [SerializeField] private Vector2Int _position;
        public string Name => _name;
        public int HP => _hp;
        public int Stamina => _speed;
    }
}
