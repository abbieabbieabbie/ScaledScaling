using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layersToCheck;
    public Collider2D killCollider;
    void Update()
    {
        DetectTouch();
    }
    void DetectTouch()
    {
        if (killCollider.IsTouchingLayers(layersToCheck))
        {
            Debug.Log("game over!");
            transform.position = new Vector3(0,0,0);
        }
    }
}
