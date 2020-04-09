using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridolinMovement : MonoBehaviour
{
    float eingabeFaktor = 10;
    public Animator animator;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xEingabe = Input.GetAxis("Horizontal");
        float yEingabe = Input.GetAxis("Vertical");

        animator.SetFloat("walking", Mathf.Abs(xEingabe));

        float xNeu = transform.position.x + xEingabe * eingabeFaktor * Time.deltaTime / 1.3f;
        float yNeu = transform.position.y + yEingabe * eingabeFaktor * Time.deltaTime * 1.5f;
        transform.position = new Vector3(xNeu, yNeu, 0);
        if (yEingabe < 0)
        {
            return;
        }
        if (xNeu > 8.3f)
        {
            xNeu = 8.3f;
        }
        if (yNeu < -8.3f)
        {
            yNeu = -8.3f;
        }


    }
}