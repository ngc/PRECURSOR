using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mus : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("Crosser").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
