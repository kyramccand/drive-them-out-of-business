using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class EndScreenController : MonoBehaviour
{

    public TMP_Text timerText;
    public TMP_Text bonusCherriesText;
    public TMP_Text hitPedestriansText;
    public TMP_Text hitCarsText;
    public TMP_Text hitBuildingsText;
    public TMP_Text totalText;


    void Start()
    {
        timerText.text = "TIME: ";
        bonusCherriesText.text = "Bonus Cherries: ";
        hitPedestriansText.text = "Hit Pedestrians: ";
        hitCarsText.text = "Hit Cars: ";
        hitBuildingsText.text = "Hit Trees/Buildings: ";
        
        totalText.text = "TOTAL:";

        StartCoroutine(endDisplay());
    }


    IEnumerator endDisplay(){
        int noDecimal = GameHandler.timer / 10;
        int yesDecimal = GameHandler.timer % 10;
        yield return new WaitForSeconds(1f);
        timerText.text = "TIME: " + (noDecimal - GameHandler.bonusConesGot*(-1) - GameHandler.peopleHit*(10) - GameHandler.carsHit*(10) - GameHandler.buildingsHit*(5)) + "." + yesDecimal;
        yield return new WaitForSeconds(1f);
        bonusCherriesText.text = "Bonus Cherries: " + GameHandler.bonusConesGot + "   x  -1.0 = -" + GameHandler.bonusConesGot*(1) + ".0";
        yield return new WaitForSeconds(1f);
        hitPedestriansText.text = "Hit Pedestrians: " + GameHandler.peopleHit + "   x  +10.0 = +" + GameHandler.peopleHit*(10)+ ".0";
        yield return new WaitForSeconds(1f);
        hitCarsText.text = "Hit Cars: " + GameHandler.carsHit + "   x  +10.0 = +" + GameHandler.carsHit*(10)+ ".0";
        yield return new WaitForSeconds(1f);
        hitBuildingsText.text = "Hit Trees/Buildings: " + GameHandler.buildingsHit + "   x  +5.0 = +" + GameHandler.buildingsHit*(5)+ ".0";
        yield return new WaitForSeconds(1f);
        totalText.text = "TOTAL: " + noDecimal + "." + yesDecimal;
    }
}
