using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int totalArrows;

    int collected = 0;

    public Renderer exitArrowRenderer;
    public Material lockedMaterial;
    public Material unlockedMaterial;

    public Transform teleportTarget;

    bool unlocked = false;

    void Start()
    {
        exitArrowRenderer.material = lockedMaterial;
    }

    public void CollectArrow()
    {
        collected++;

        if (collected >= totalArrows)
        {
            unlocked = true;
            exitArrowRenderer.material = unlockedMaterial;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!unlocked) return;

        if (other.GetComponent<CharacterController>() != null)
        {
            CharacterController cc = other.GetComponent<CharacterController>();

            cc.enabled = false;
            other.transform.position = teleportTarget.position;
            cc.enabled = true;
        }
    }
}