using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotsPrefab;
    [SerializeField] float dotsSpacing;

    Vector2 pos;
    float timeStamp;
    Transform[] dotsList;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        PrepareDots();
    }
    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        for (int i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotsPrefab,null).transform;
            dotsList[i].parent = dotsParent.transform;
        }
    }
    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        timeStamp = dotsSpacing;
        for (int i = 0; i < dotsNumber; i++)
        {
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            // TO DO TOMORROW
        }
    }
    public void Show()
    {
        dotsParent.SetActive(true);
    }
    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
