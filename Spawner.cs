using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> targetPrefabs;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] public bool gameOver = false;
    [SerializeField] Button restartButton;
    [SerializeField] GameObject titleScreen;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        titleScreen = GameObject.Find("TitleScreen");
    }
    // Update is called once per frame
    void Update()
    {
        GameObject lowOff = GameObject.FindWithTag("LowOff");
        if(lowOff.transform.position.y < -8)
        {
            gameOver=true;
        }
        if (gameOver == true)
        {
            GameOver();
        }
    }
    
    public void Score(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score >= 0)
        {
            scoreText.text = "Score:" + score;
        }
        else if(score <= -1)
        {
            scoreText.text = "Score:" + 0;
            gameOver = true;
            GameOver();
        }
    }
    void GameOver()
    {
        Debug.Log("GAMEOVER");
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("NOV1");
    }
    public void StartGame(float givenSec)
    {
        StartCoroutine(TargetInstantiate(givenSec));
        titleScreen.SetActive(false);
    }
    IEnumerator TargetInstantiate(float seconds)
    {
        while (true && gameOver == false)
        {
            yield return new WaitForSeconds(seconds);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }
}
