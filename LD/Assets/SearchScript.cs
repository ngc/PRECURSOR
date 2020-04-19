using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{

    public bool firstWrong = false;
    public GameObject Attacker;
    private float lastTime = 3f;
    public Text lettersDisplay;
    public int spawnRate = 8;
    public bool spawningNow = false;
    public int spawnNum = 3;
    private int index = 0;
    private char[] letters = new char[7] { 'L', '4', 'T', '9', '6', 'Z', 'B' };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawningNow)
        {
            if (Time.time > lastTime)
            {
                lastTime = Time.time + spawnRate;
                for (int i = 0; i < spawnNum; i++) { 
                    Instantiate(Attacker, new Vector3(10, Random.Range(-5, 5), 0), Quaternion.identity);
                    Instantiate(Attacker, new Vector3(-10, Random.Range(-5, 5), 0), Quaternion.identity);
                    Instantiate(Attacker, new Vector3(Random.Range(-10, 10), 6, 0), Quaternion.identity);
                    Instantiate(Attacker, new Vector3(Random.Range(-10, 10), -6, 0), Quaternion.identity);
                }
                if (index % 2 == 0)
                {
                    lettersDisplay.text += letters[index / 2];
                }
                index++;
                
            }
        }
    }

    void search(string input)
    {
        if(input == "L4T96ZB")
        {
            Debug.Log("WON");
        }
        else
        {
            if (!firstWrong)
            {
                spawnEvent();
                firstWrong = true;
            }
        }
    }

    void spawnEvent()
    {
        spawningNow = true;
        Instantiate(Attacker, new Vector3(Random.Range(10, 15), Random.Range(6, 10), 0), Quaternion.identity); 
    }

}
