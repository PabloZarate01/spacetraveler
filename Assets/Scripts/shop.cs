using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    int prefsCoins;
    public Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        prefsCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        coinsText.text = prefsCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
