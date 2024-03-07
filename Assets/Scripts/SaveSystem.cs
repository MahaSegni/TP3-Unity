using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    public float Money;
    public TMP_Text textMoney;
    public TMP_Text ClicksTotalText;
    public float TotalClicks;

    public Button clicker;

    public Manager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        clicker.onClick.AddListener((() =>
        {
            
            gameManager.OnBackgroundClicked();
        }));
    }
    
    public void AddClicks(){

        TotalClicks++;
   
        ClicksTotalText.text = $"Clicks: " + TotalClicks.ToString();

        Money += 20f;
        textMoney.text = $"Argent: " + Money.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Money += 20f;
        }
        textMoney.text = $"argent: {Money}";
        ClicksTotalText.text = $"Clicks: {TotalClicks}";
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Money", Money);
        PlayerPrefs.SetFloat("TotalClicks", TotalClicks);
    }

    private void Load()
    {
        Money = PlayerPrefs.GetFloat("Money", 0);
        TotalClicks = PlayerPrefs.GetFloat("TotalClicks", 0);
        
    }
}