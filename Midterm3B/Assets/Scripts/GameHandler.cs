using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameHandler : MonoBehaviour {

    public static int timer = 0;
    public static bool timerLive = false;
    public static bool newGame = true;

    private float theTimer = 0f;
    public TMP_Text timerText;

    public GameObject changeTimeBG;
    public GameObject countdown;


    void Start(){
        if(newGame == true){
            timer = 0;
        }
        StartCoroutine(startCountdown());
        UpdateTimer();
    }

    void FixedUpdate(){
        if(timerLive == true){
            theTimer += 0.02f;
            if(theTimer >= 0.1f){
                timer += 1;
                theTimer = 0;
                UpdateTimer();
            }
        }
    }

    public void UpdateTimer(){
        int noDecimal = timer / 10;
        int yesDecimal = timer % 10;
        timerText.text = "TIME: " + noDecimal + "." + yesDecimal;
    }

    public void AddTime(int points){
        if(timerLive == true){
            timer += points;
            UpdateTimer();

            changeTimeBG.SetActive(true);
            changeTimeBG.GetComponent<ChangeTimer>().Add(points);
        }
    }

    public void SubtractTime(int points){
        if(timerLive == true){
            timer -= points;
            UpdateTimer();

            changeTimeBG.SetActive(true);
            changeTimeBG.GetComponent<ChangeTimer>().Subtract(points);
        }
    }

    public void StopTimer(){
        timerLive = false;
    }

    public void WinGame(){
        StopTimer();
        newGame = false;
        StartCoroutine(endScene());
    }

    public void StartGame() {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame() {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        timer = 0;
        newGame = true;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator startCountdown(){
        countdown.SetActive(true);
        countdown.GetComponent<ChangeCountdown>().Number("3");
        yield return new WaitForSeconds(1f);
        countdown.GetComponent<ChangeCountdown>().Number("2");
        yield return new WaitForSeconds(1f);
        countdown.GetComponent<ChangeCountdown>().Number("1");
        yield return new WaitForSeconds(1f);
        countdown.GetComponent<ChangeCountdown>().Go();
        yield return new WaitForSeconds(0.5f);
        
        if(newGame == true){
            timerLive = true;
        }
    }

    IEnumerator endScene(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("EndWin");
    }
}