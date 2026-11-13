using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;
    // Start is called before the first frame update
    public void Open()
    {
        this.GetComponent<SpriteRenderer>().sprite = openSprite;
    }
    public void Close()
    {
        this.GetComponent<SpriteRenderer>().sprite = closedSprite;
    }
}
