using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.MVC
{
    public sealed class Enemy : MonoBehaviour, IEnemy
    {
        OnTriggerExit _action;
        IBonus _bonus;
      
        public void OnEnable()
        {
            _action = GameObject.FindObjectOfType<OnTriggerExit>();
            _bonus = GameObject.FindObjectOfType<Bonus>();
         
            _bonus.ExecuteBonus += ExecuteBonus;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _action.OntriggerEnterGameOverAction += DestroyCurrentEnemy;
        }

        private void ExecuteBonus()
        {
            BonusMethod(_bonus.BonusType);
        }
        private Dictionary<string, Action> _actions;
        public void BonusMethod(string value)
        {
            _actions = new Dictionary<string, Action>
            {
                ["Move"] = BonusEvent,
                ["Attack"] = DestroyCurrentEnemy,
            };
            _actions[value]?.Invoke();
        }


        private void BonusEvent()
        {
            Debug.Log("Bonus");
        }

        private void DestroyCurrentEnemy()
        {
            Destroy(this.gameObject, 2);
        }


        public void OnDestroy()
        {
            _bonus.ExecuteBonus -= ExecuteBonus;

            _bonus.ExecuteBonus -= BonusEvent;
            _bonus.ExecuteBonus -= DestroyCurrentEnemy;
            _action.OntriggerEnterGameOverAction -= DestroyCurrentEnemy;
        }
    }
}
