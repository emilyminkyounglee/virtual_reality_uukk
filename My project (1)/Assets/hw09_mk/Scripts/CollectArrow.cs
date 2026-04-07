using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectArrow : MonoBehaviour
{
    public LevelManager levelManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            levelManager.CollectArrow();
            Destroy(gameObject);
        }
    }
}