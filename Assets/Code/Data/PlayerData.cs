using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.MVC
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/Player")]
    public class PlayerData : ScriptableObject
    {
        public Sprite Sprite;
        [SerializeField] private string _name;
        [SerializeField, Range(0, 100)] private int _hp;
        [SerializeField, Range(0, 100)] private int _stamina;

        [SerializeField] private Vector2Int _position;
        public string Name => _name;
        public int HP => _hp;
        public int Stamina => _stamina;
    }
}
