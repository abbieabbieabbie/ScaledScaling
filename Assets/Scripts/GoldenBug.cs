using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBug : MonoBehaviour
{
    [HideInInspector] public bool hasTriggered;
    public DoorBehaviour door;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            gameObject.SetActive(false);
            door.Open();
        }
    }
    public void Respawn()
    {
        hasTriggered = false;
        gameObject.SetActive(true);
        door.Close();
    }
}
