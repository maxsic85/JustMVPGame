using UnityEngine;

namespace Code.MVC
{
    [CreateAssetMenu(fileName = "BonusData", menuName = "Bonus")]
    public class BonusData:ScriptableObject
    {
        public Sprite Sprite;
        [SerializeField] string _bonusType;

        public string BonusType => _bonusType;

    }
}
