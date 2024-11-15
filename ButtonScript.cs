using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private Button button;
    private Spawner spawnerScript;
    private void Awake()
    {
        button = GetComponent<Button>();
        spawnerScript = GameObject.Find("GameManager").GetComponent<Spawner>();
        button.onClick.AddListener(Difficulty);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Difficulty()
    {
       
        //givenSec to pass seconds speed to the coroutine ;
        if(button.gameObject.name=="Easy")
        {
            spawnerScript.StartGame(1.5f);
            Debug.Log(button.gameObject.name + "was Clicked.");
        }
        else if (button.gameObject.name == "Medium")
        {
            spawnerScript.StartGame(1.0f);
            Debug.Log(button.gameObject.name + "was Clicked.");  
        }
        else
        {
            spawnerScript.StartGame(0.5f);
            Debug.Log(button.gameObject.name + "was Clicked.");
        }
    }
}
