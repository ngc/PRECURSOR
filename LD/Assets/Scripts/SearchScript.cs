using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private char[] letters = new char[5] { 'L', '4', 'T', '9', '6'};
    private GameObject[] blades = new GameObject[9];
    public GameObject battleCont;

    private float lastTimeSaw;
    private int selector = 0;

    // Start is called before the first frame update
    void Start()
    {
        battleCont.SetActive(false);
        for(int i = 0; i < 9; i++)
        {
            blades[i] = transform.GetChild(i).gameObject;
            blades[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (spawningNow)
        {

            if (Time.time > lastTimeSaw)
            {
                blades[selector].GetComponent<sawBlade>().Activated = false;
                blades[selector].GetComponent<AudioSource>().Stop();
                selector = Random.Range(0, 9);
                blades[selector].GetComponent<AudioSource>().Play();
                blades[selector].GetComponent<sawBlade>().Activated = true;
                lastTimeSaw = Time.time + 11;
            }

            if (Time.time > lastTime)
            {
                lastTime = Time.time + spawnRate;
                for (int i = 0; i < spawnNum; i++) { 
                    Instantiate(Attacker, new Vector3(10, Random.Range(-5, 5), 0), Quaternion.identity);
                    Instantiate(Attacker, new Vector3(-10, Random.Range(-5, 5), 0), Quaternion.identity);
                    Instantiate(Attacker, new Vector3(Random.Range(-10, 10), 6, 0), Quaternion.identity);
                    Instantiate(Attacker, new Vector3(Random.Range(-10, 10), -6, 0), Quaternion.identity);
                }
                if (index % 2 == 0 && index < 11)
                {
                    lettersDisplay.text += letters[index / 2];
                }
                index++;
                
            }
        }
    }

    void search(string input)
    {
        if(input == "L4T96")
        {
            SceneManager.LoadScene("end", LoadSceneMode.Single);
        }
        else
        {
            if (!firstWrong)
            {
                battleCont.SetActive(true);
                for(int i = 0; i < 9; i++)
                {
                    blades[i].SetActive(true);
                }
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
