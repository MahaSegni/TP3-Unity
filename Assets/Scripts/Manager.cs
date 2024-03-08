using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;
using Image = UnityEngine.UIElements.Image;

public class Manager : MonoBehaviour
{
    public TMP_Text ClicksTotalText;

    public bool hasUpgraded;
    public float TotalClicks;
    public int autoClicksPerSecond;
    public int minimumClicksToUnlockUpgrade;
    public float Money;
    public TMP_Text Moneytext;
    public float TotalMoney;
    public Enemies enemiesPrefab;
    public Enemies currentEnemy;
    public TMP_Text levelText;
    private int levelIncrement;
    public Transform spawnPosition;
    public bool IsDead => currentEnemy.health <= 0;

    private void Start()
    {
        
    }

    public void AddClicks(){

        TotalClicks++;
        TotalMoney++;
        ClicksTotalText.text = $"Clicks:  {TotalClicks}";

        Money += 20f;
        Moneytext.text = $"Argent: {Money}";

    }
    
    public void OnBackgroundClicked()
    {
        if (currentEnemy != null)
        {
            currentEnemy.TakeDamage(10);
            if (currentEnemy.IsDead)
            {
                levelIncrement++;
                Money += 20f;
                Debug.Log("money on dead" + Money);
                levelText.text = $"Niveau: {levelIncrement}";
                spawnEnemy();
            }
        }
    }

    void spawnEnemy()
    {
        Vector3 specificPosition = new Vector3(1f, 2f, 3f);
        currentEnemy = Instantiate(enemiesPrefab, spawnPosition.position, Quaternion.identity);
        currentEnemy.transform.localScale = specificPosition;
        currentEnemy.Init(30);
        currentEnemy.GetComponents<Image>();
    }

    public void AutoClickUpdate(){
        if(!hasUpgraded && TotalClicks >= minimumClicksToUnlockUpgrade){
            TotalClicks = minimumClicksToUnlockUpgrade;
            TotalMoney = minimumClicksToUnlockUpgrade;
            hasUpgraded = true;
        } 
    }    

    private void Update(){

        if(Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        ClicksTotalText.text = $"Clicks: " + TotalClicks.ToString();
        Moneytext.text = $"Argent: " + Money.ToString();
        levelText.text = $"Niveau: {levelIncrement}";

        if(hasUpgraded){
            TotalClicks += autoClicksPerSecond * Time.deltaTime;
            TotalMoney+= autoClicksPerSecond * Time.deltaTime;
            ClicksTotalText.text = TotalClicks.ToString("0");
            Moneytext.text = TotalMoney.ToString("0");
            currentEnemy.TakeDamage(30);
            
        }
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