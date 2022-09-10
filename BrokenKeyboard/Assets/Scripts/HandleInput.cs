using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput : MonoBehaviour
{
    [Header("Properties")]

    [SerializeField] private AudioManager audio;
    [SerializeField] private Vector2 minRange;
    [SerializeField] private Vector2 maxRange;
    private float timer = 2f;

    [Space]

    [Header("Keybinds")]

    [Header("Delete")]
    [Rename("Activated?")]
    [SerializeField] private bool isActive = true;

    [Header("Alpha2")]
    [Rename("SFX")]
    [SerializeField] private string Alpha2 = "ping";

    [Header("O")]
    [Rename("Cooldown")]
    [SerializeField] private float Ocooldown = 2f;
    [Rename("Location 1")]
    [SerializeField] private GameObject Olocal1;
    [Rename("Location 2")]
    [SerializeField] private GameObject Olocal2;
    [Rename("Location 3")]
    [SerializeField] private GameObject Olocal3;
    [Rename("Location 4")]
    [SerializeField] private GameObject Olocal4;
    [Rename("Location 5")]
    [SerializeField] private GameObject Olocal5;
    [Rename("Location 6")]
    [SerializeField] private GameObject Olocal6;
    [Rename("Prefab")]
    [SerializeField] private GameObject Osymbol;

    [Header("S")]
    [Rename("SFX")]
    [SerializeField] private string S = "amogus";

    [Header("J")]
    [Rename("SFX")]
    [SerializeField] private string J = "peloScream";

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Delete) && isActive)
        {
            Debug.Log("Application Quit");
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("ping");
            audio.Play(Alpha2);
        }
        if (Input.GetKey(KeyCode.O) && timer <= 0f)
        {
            Debug.Log("spam symbol");
            timer = Ocooldown;
            
            Olocal1.transform.position = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
            Olocal2.transform.position = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
            Olocal3.transform.position = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
            Olocal4.transform.position = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
            Olocal5.transform.position = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
            Olocal6.transform.position = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
            
            Instantiate(Osymbol, Olocal1.transform.position, Quaternion.identity);
            Instantiate(Osymbol, Olocal2.transform.position, Quaternion.identity);
            Instantiate(Osymbol, Olocal3.transform.position, Quaternion.identity);
            Instantiate(Osymbol, Olocal4.transform.position, Quaternion.identity);
            Instantiate(Osymbol, Olocal5.transform.position, Quaternion.identity);
            Instantiate(Osymbol, Olocal6.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("sus");
            audio.Play(S);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Sr Pelo scream");
            audio.Play(J);
        }
    }
}
