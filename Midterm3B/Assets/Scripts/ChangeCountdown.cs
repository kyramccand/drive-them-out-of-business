using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeCountdown : MonoBehaviour
{

    public TMP_Text changeCountText;

    void Start()
    {
        
    }

    public void Number(string number){
        Image uiImage = GetComponent<Image>();
        if (uiImage != null){
            uiImage.color = new Color32(255,5,0,83);
        }

        changeCountText.text = number;
    }

    public void Go(){
        Image uiImage = GetComponent<Image>();
        if (uiImage != null){
            uiImage.color = new Color32(0,229,13,150);
        }

        changeCountText.text = "GO";
        StartCoroutine(deactivateDelay());
    }

    IEnumerator deactivateDelay(){
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }

}