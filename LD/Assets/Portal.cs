using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MGMT;
    public string SceneToLoad = "";
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MGMT.transform.SendMessage("Portaled", SceneToLoad);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
