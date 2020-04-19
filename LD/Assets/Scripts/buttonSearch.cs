using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonSearch : MonoBehaviour
{
    public GameObject sMGMT;
    public InputField searchbar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void search()
    {
        sMGMT.transform.SendMessage("search", searchbar.text);
    }
}
