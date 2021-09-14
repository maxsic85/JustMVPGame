

using UnityEngine;

namespace Code.MVC
{
    public sealed class BonusFabric : IBonusFabric
    {
        BonusData _bonusData;
        Canvas _canvas;

        public BonusFabric(BonusData bonusData)
        {
            _bonusData = bonusData;
            _canvas = GameObject.FindObjectOfType<Canvas>();
        }

        public Transform CreateBonus()
        {
            var bonus = new GameObject(_bonusData.BonusType).AddSprite(_bonusData.Sprite)
          .AddRigitBody2D().AddBoxCollidery2D().transform;
            bonus.localScale = Vector3.one;
            bonus.transform.SetParent(_canvas.transform);
            bonus.gameObject.GetOrAddComponent<Bonus>().BonusType=_bonusData.BonusType;
            var box = bonus.gameObject.GetOrAddComponent<BoxCollider2D>();
            box.isTrigger = true;
            box.size = new Vector2(bonus.localScale.x * 10, bonus.localScale.y * 10);
            int sizeX = Random.RandomRange(-(Screen.width / 2), Screen.width / 2);
            sizeX = (int)((sizeX > 0) ? sizeX - bonus.GetComponent<RectTransform>().rect.width / 2 : sizeX + (int)bonus.GetComponent<RectTransform>().rect.width / 2);
            int sizey = Screen.height;
            bonus.localPosition = new Vector3(sizeX, sizey, 0);
            return bonus;
        }
    }
}
