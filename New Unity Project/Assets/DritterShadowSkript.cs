using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DritterShadowSkript : MonoBehaviour
{
    float yNeu;
    float xNeu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yNeu = transform.position.y + 70 * Time.deltaTime;
        xNeu = transform.position.x - 1.5f;
        transform.position = new Vector3(xNeu, yNeu, 0);
        if (yNeu > 200.2f)
        {
            transform.position = new Vector3(162.7f, 10.4f, 0);
        }

    }
}

