using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;



public class MGMT : MonoBehaviour
{
    public GameObject messageMGMT;
    public int INDEX = -1;
    public string[] dialog = new string[] { "YOU WILL BE TESTED", "MAKE IT TO THE OTHER SIDE" };
    public bool writing = false;
    public float timeAtEnd = 0f;
    public string startLevel = "new";
    public bool differentStart = false;

    void NextMessage()
    {
        writing = true;
        INDEX++;
        Debug.Log(dialog[INDEX]);
        messageMGMT.transform.SendMessage("write", dialog[INDEX]);
        
    }

    void Start()
    {
        NextMessage();
    }

    // Update is called once per frame
    void Update()
    {
        if(INDEX == 0 && writing == false && Time.time - timeAtEnd >= 1.5f)
        {
            NextMessage();
        }
    }
    
    void done()
    {
        writing = false;
        timeAtEnd = Time.time;
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
