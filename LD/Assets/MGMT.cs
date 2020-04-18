using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGMT : MonoBehaviour
{
    public GameObject messageMGMT;
    public int INDEX = -1;
    public string[] dialog = new string[] { "YOU WILL BE TESTED", "MAKE IT TO THE OTHER SIDE" };
    public bool writing = false;
    // Start is called before the first frame update
  
    void NextMessage()
    {
        INDEX++;
        Debug.Log(dialog[INDEX]);
        messageMGMT.transform.SendMessage("write", dialog[INDEX]);
        writing = true;
    }

    void Start()
    {
        NextMessage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void done()
    {
        writing = false;
    }
}
