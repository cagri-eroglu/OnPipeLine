using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject GameOver_panel;
    [SerializeField]
    private TMP_Text distance_value;
    [SerializeField]
    private RectTransform health_bar;

    [SerializeField]
    private TMP_Text highscore_text;

    public static UIManager ui_m;

    private void Awake()
    {

        ui_m = this;
        
    }

    public void setPlayerHealth(float health)
    {
        health_bar.localScale = new Vector3(health/10, 1.0f);

    }

   
    public void OpenGameOverUI()
    {
        if (GameOver_panel!=null)
        {
            GameOver_panel.SetActive(true);
        }
        
    }

    public void setDistanceValue(float distance)
    {
        distance_value.text = distance.ToString("F0");
    }
    public void Sethighscoretext()
    {
        highscore_text.text = PlayerPrefs.GetFloat("Highscore").ToString("F1");
    }
}
 