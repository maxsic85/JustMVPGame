using System;
using UnityEngine;


namespace Code.MVC
{
    public sealed class Bonus : MonoBehaviour, IBonus
    {
        public event Action ExecuteBonus;
        Vector3 startPosition;
        public string BonusType { get;  set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ExecuteBonus?.Invoke();
            this.gameObject.transform.localPosition = startPosition;
          ///  Destroy(gameObject, 0.1f);
        }

        void Start()
        {

            startPosition = this.gameObject.transform.position;
            Debug.Log(startPosition);
        }

        public void OnDestroy()
        {
           
        }

        public void OnEnable()
        {
        
        }

        private void UpdatePosition()
        { 
        
        }
    }
}
