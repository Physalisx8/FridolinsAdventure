using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tonskript : MonoBehaviour
{
    public static AudioClip walking, bumping, jumping, landing;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        walking = Resources.Load<AudioClip>("walking");
        bumping = Resources.Load<AudioClip>("soundbump");
       jumping = Resources.Load<AudioClip>("soundjump");
        landing = Resources.Load<AudioClip>("soundlanden");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip){
    
        switch (clip)
        {
            case "walking":
                audioSrc.PlayOneShot(walking);
                break;
            case "bumping":
                audioSrc.PlayOneShot(bumping);
                break;
            case "jumping":
                audioSrc.PlayOneShot(jumping);
                break;
            case "landing":
                audioSrc.PlayOneShot(landing);
                break;
        }
    }
}
