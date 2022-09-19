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

    [Header("!")]
    [Rename("Cooldown")]
    [SerializeField] private float EXCLAIMcooldown = 2f;
    [Rename("Object")]
    [SerializeField] private GameObject jumpscare;
    [Rename("SFX Event")]
    [SerializeField] private Jumpscare screamEffect;

    [Header("Alpha2")]
    [Rename("SFX")]
    [SerializeField] private string Alpha2 = "ping";

    [Header("E")]
    [Rename("Cooldown")]
    [SerializeField] private float Ecooldown = 2f;
    [Rename("Object")]
    [SerializeField] private GameObject Eobject;
    
    [Header("O")]
    [Rename("Cooldown")]
    [SerializeField] private float Ocooldown = 2.2f;
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

    [Header("R")]
    [Rename("SFX Event")]
    [SerializeField] private RickRoll rickroll;
    [Rename("Sprite")]
    [SerializeField] private GameObject rickImage;

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
        // Delete key
        if (Input.GetKeyDown(KeyCode.Delete) && isActive)
        {
            Debug.Log("Application Quit");
            Application.Quit();
        }
        // ! key(aka 1 and shift)
        if (Input.GetKeyDown(KeyCode.Alpha1) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && timer <= 0f)
        {
            Debug.Log("jumpscare");
            timer = EXCLAIMcooldown;
            jumpscare.SetActive(true);
            StartCoroutine(screamEffect.Scream(EXCLAIMcooldown, jumpscare));
        }
        // 2 key
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("ping");
            audio.Play(Alpha2);
        }
        // E Key
        if (Input.GetKey(KeyCode.E) && timer <= 0f)
        {
            Debug.Log("E");
            timer = Ocooldown;
            StartCoroutine(E());
        }
        // O key
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
        // R key
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(rickroll);
            rickImage.SetActive(!rickImage.activeSelf);
            rickroll.Rickroll();
        }
        // S key
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("sus");
            audio.Play(S);
        }
        // J key
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Sr Pelo scream");
            audio.Play(J);
        }
    }

    private IEnumerator E()
    {
        Eobject.SetActive(true);
        audio.Play("eee");
        yield return new WaitForSeconds(Ecooldown);
        Eobject.SetActive(false);
    }
}
