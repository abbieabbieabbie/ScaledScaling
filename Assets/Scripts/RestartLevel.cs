using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    public KillPlayer restartScript;
    public GoldenBug goldenBug;

    // Start is called before the first frame update
    public void Restart()
    {   
        restartScript.Death();

    }
    public void LevelSelect()
    {

    }
    public void NextLevel()
    {
        
    }
}
