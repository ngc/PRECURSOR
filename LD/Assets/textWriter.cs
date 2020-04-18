using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class textWriter : MonoBehaviour
{
    public float gap = 0.2f;
    public Text message;
    public string current = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void write(string t)
    {
        StartCoroutine(TypeWrite(t, message));
    }

    private IEnumerator TypeWrite(string text, Text body)
    {
        foreach(char character in text.ToCharArray())
        {
            current += character;
            body.text = current;
            yield return new WaitForSeconds(gap);

        }


    }

}
