using UnityEngine;

namespace Code.MVC
{
    public class PlayerFabric : IPlayerFabric
    {
        PlayerData _playerData;

        public PlayerFabric(PlayerData playerData)
        {
            this._playerData = playerData;
        }



        public Transform CreatePlayer()
        {
          var _canvas = GameObject.FindObjectOfType<Canvas>();
            var a= new GameObject(_playerData.Name).AddSprite(_playerData.Sprite).
                AddCircleCollider2D().AddTrailRenderer().transform;
            a.localScale = Vector3.one;
            int sizeX = Screen.width / 2;
            int sizey = Screen.height / 4;
            a.position = new Vector3(sizeX, sizey, 0);
            a.transform.SetParent(_canvas.transform);
            return a;
        }
    }
}
