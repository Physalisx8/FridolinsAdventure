using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
    
{   private PlatformEffector2D effector;
    float waittime;
    
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waittime = 0.1f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (waittime <= 0)
            {
                effector.rotationalOffset = 180f;
                waittime = 0.1f;
            }
            else { waittime -= Time.deltaTime; }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector.rotationalOffset = 0;
        }
    }
}
