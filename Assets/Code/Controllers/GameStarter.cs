using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Code.MVC.Delegates;
using System;

namespace Code.MVC
{
    public class GameStarter : MonoBehaviour
    {
    
        public Action action;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private InputData _inputData;
        [SerializeField] private EnemyData _enemyata;
        [SerializeField] private InputType inputType;
        Controllers _controllers;


        // Start is called before the first frame update
        void Start()
        {        
            _controllers = new Controllers();
            new GameInitialisation(_playerData, _controllers, inputType, _inputData, _enemyata,ref  action);                    
            InvokeRepeating("some", 1, 1);
            var testAction = FindObjectOfType<OnTriggerExit>();
            testAction.OntriggerEnterAction += OntriggerAction;
        }

       

        // Update is called once per frame
        void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

     
        void some()
        {
              action?.Invoke();
        }

        public void OntriggerAction()
        {
            Debug.Log("Do Action");
        }

        ~GameStarter()
        {
            StopAllCoroutines();
            _ = Delegate.RemoveAll(action, action);
        }
    }
}
