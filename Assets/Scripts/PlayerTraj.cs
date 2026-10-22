using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTraj : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public BoxCollider2D col;
    [HideInInspector] public Vector3 pos { get { return transform.position; }}
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    public void Sling(Vector2 force)
    {
        rb.AddForce (force, ForceMode2D.Impulse);
    }

    public void ActiveRigidbody()
    {
        rb.isKinematic = false;
    }
    public void DeactiveRigidbody()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
}
