using System;
using UnityEngine;

namespace Code.MVC
{
    public sealed class Enemy : MonoBehaviour, IEnemy
    {
        OnTriggerExit _action;
        public void OnEnable()
        {
            _action = GameObject.FindObjectOfType<OnTriggerExit>();
          //  _action.OntriggerEnterAction += DestroyEvent;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _action.OntriggerEnterAction += DestroyEvent;
        }

        private void DestroyEvent()
        {
            Destroy(this.gameObject, 3);
        }


        public void OnDestroy()
        {
            _action.OntriggerEnterAction -= DestroyEvent;
            //_action.OntriggerEnterAction -= OntriggerChange;
        }
    }
}
