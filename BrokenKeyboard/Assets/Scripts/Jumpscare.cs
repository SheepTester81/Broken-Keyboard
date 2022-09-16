using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    [SerializeField] private AudioSource audio;

    public IEnumerator Scream(float duration, GameObject objects)
    {
        audio.Play();
        yield return new WaitForSeconds(duration);
        objects.SetActive(false);
    }
}
