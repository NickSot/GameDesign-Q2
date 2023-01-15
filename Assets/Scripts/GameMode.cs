using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameMode : MonoBehaviour
{
    public Mutex testMutex = new Mutex();
    public Mutex outputMutex = new Mutex();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
