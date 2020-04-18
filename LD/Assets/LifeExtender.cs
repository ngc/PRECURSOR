using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeExtender : MonoBehaviour
{
    public GameObject LifeMGMT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LifeMGMT.transform.SendMessage("GrantLife", 5f);
            Destroy(gameObject);
        }
    }

}
