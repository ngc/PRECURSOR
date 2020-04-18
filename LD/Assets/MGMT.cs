using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MGMT : MonoBehaviour
{
    public GameObject messageMGMT;
    public int INDEX = -1;
    public string[] dialog = new string[] { "YOU WILL BE TESTED", "MAKE IT TO THE OTHER SIDE" };
    public bool writing = false;
    public float timeAtEnd = 0f;
    // Start is called before the first frame update
  
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
        SceneManager.LoadScene("new", LoadSceneMode.Single);
    }

    void Portaled(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

}
