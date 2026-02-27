using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenuHandler : MonoBehaviour {

        public GameHandler gameHandlerObj;

        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public AudioMixer mixer;
        public static float volumeLevel = 1.0f;
        private Slider sliderVolumeCtrl;

        void Awake(){
                SetLevel (volumeLevel);
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
            if(GameObject.FindWithTag("GameHandler") != null){
                gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            }
        }

        void Start(){
                pauseMenuUI.SetActive(false);
                GameisPaused = false;
        }

        void Update(){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){ Resume(); }
                        else{ Pause(); }
                }
        }

        public void Pause(){
                if (!GameisPaused){
                        pauseMenuUI.SetActive(true);
                        Time.timeScale = 0f;
                        GameisPaused = true;}
             else { Resume (); }
             //NOTE: This function is for the pause button
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void SetLevel (float sliderValue){
                mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                volumeLevel = sliderValue;
        }

        public void RestartGame(){
                gameHandlerObj.StopTimer();
                Time.timeScale = 1f;
                GameHandler.timer = 0;
                GameHandler.newGame = true;
                GameHandler.gameGo = false;
                SceneManager.LoadScene("MainMenu");
                // Please also reset all static variables here, for new games!
        }

        public void QuitGame(){
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
        }
}