using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput : MonoBehaviour
{
    public AudioManager audio;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Debug.Log("Application Quit");
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("ping");
            audio.Play("ping");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("sus");
            audio.Play("amogus");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Sr Pelo scream");
            audio.Play("peloScream");
        }
    }
}
