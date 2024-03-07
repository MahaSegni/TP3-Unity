using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public float Money;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
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
        text.text = $"money = {Money}";
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Money", Money);
    }

    private void Load()
    {
        Money = PlayerPrefs.GetFloat("Money", 0);
        
    }
    
}
