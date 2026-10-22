using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion

    Camera cam;
    public PlayerTraj ball;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    void Start()
    {
        cam = Camera.main;
        ball.DeactiveRigidbody();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }
        if (isDragging)
        {
            OnDrag();
        }
    }

    void OnDragStart()
    {
        ball.DeactiveRigidbody();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint,endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * direction * pushForce;

        Debug.DrawLine(startPoint,endPoint);
    }
    void OnDragEnd()
    {
        ball.ActiveRigidbody();
        ball.Sling(force);
    }
}
