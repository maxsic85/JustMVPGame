using System;
using UnityEngine;


public sealed class OnTriggerExit : MonoBehaviour
{
    public event Action OntriggerEnterGameOverAction;

   

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OntriggerEnterGameOverAction?.Invoke();
        Debug.Log(collision.gameObject);
        Debug.Log(OntriggerEnterGameOverAction.GetInvocationList().Length);

    }
}

