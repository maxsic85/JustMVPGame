using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Code.MVC
{
    public class GameOverFabric : IGameOverFabric
    {
        public GameOverFabric()
        {

        }

        public event Action OntriggerChange;

        public RectTransform CreateGO()
        {
            var _canvas = GameObject.FindObjectOfType<Canvas>();
            var go = new GameObject().GetOrAddComponent<RectTransform>();
            go.localScale = new Vector3(100, 1, 1);
            go.gameObject.GetOrAddComponent<BoxCollider2D>();
            var box = go.GetComponent<BoxCollider2D>();
            box.isTrigger = true;
            box.size = new Vector2(go.localScale.x * 10, go.localScale.y * 10);
            int sizeX = Screen.width / 2;
            int sizey = -100;
            go.transform.position = new Vector3(sizeX, sizey, 0);
            go.gameObject.GetOrAddComponent<OnTriggerExit>();
            go.gameObject.name = "GamoOverCollider";
            return go;
        }
    }
}
