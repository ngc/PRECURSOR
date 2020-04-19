using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine.UI;



public class MGMT : MonoBehaviour
{
    public GameObject messageMGMT;
    public int INDEX = -1;
    public string[] dialog = new string[] { "YOU WILL BE TESTED", "MAKE IT TO THE OTHER SIDE" };
    public bool writing = false;
    public float timeAtEnd = 0f;
    public string startLevel = "new";
    public bool differentStart = false;
    public bool isPortalSpawner = false;
    public float portalTime = 5f;
    public Text portalText;
    public GameObject portal;
    private float displayValue;

    void NextMessage()
    {
        writing = true;
        INDEX++;
        Debug.Log(dialog[INDEX]);
        messageMGMT.transform.SendMessage("write", dialog[INDEX]);
        
    }

    void Start()
    {
        if (isPortalSpawner)
        {
            portal = GameObject.Find("Portal");
            portal.SetActive(false);
        }
        NextMessage();
    }

    // Update is called once per frame
    void Update()
    {

        if (isPortalSpawner)
        {
            displayValue = portalTime - Time.timeSinceLevelLoad;
            portalText.text = "EXIT:" + (Mathf.Clamp(displayValue, 0, Mathf.Infinity)).ToString();
            if((portalTime - Time.timeSinceLevelLoad) <= 0)
            {
                Debug.Log("asdfasdfs");
                portal.SetActive(true);
            }
        }

        if(INDEX == 0 && writing == false && Time.timeSinceLevelLoad - timeAtEnd >= 1.5f)
        {
            NextMessage();
        }
    }
    
    void done()
    {
        writing = false;
        timeAtEnd = Time.timeSinceLevelLoad;
    }

    void died()
    {
        SceneManager.LoadScene(startLevel, LoadSceneMode.Single);
    }

    void Portaled(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

}
