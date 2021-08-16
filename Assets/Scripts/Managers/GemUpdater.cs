using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemUpdater : MonoBehaviour
{
    public GameObject scoreDisplay;
    public static int gemCount;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("TotalGem",100); After a game finishes add gemcount as a totalGem to player prefs
        gemCount = PlayerPrefs.GetInt("TotalGem",0);
        scoreDisplay.GetComponent<Text>().text = gemCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.GetComponent<Text>().text = gemCount.ToString();
    }
}
