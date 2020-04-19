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
    public GameObject gameMGMT;
    int counter = 0;
    public AudioSource speaker;
    
    void write(string t)
    {
        message.text = "";
        current = "";
        StartCoroutine(TypeWrite(t, message));
        counter = 0;
    }

    private IEnumerator TypeWrite(string text, Text body)
    {

        foreach (char character in text.ToCharArray())
        {
            if (counter == text.Length - 1)
            {
                gameMGMT.transform.SendMessage("done");
            }
            current += character;
            body.text = current;
            if (character != ' ') { 
            speaker.Play();
        }
            yield return new WaitForSeconds(gap);
            counter++;

        }

    }

}
