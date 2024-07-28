using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreCounter;
    [SerializeField] TextMeshProUGUI Score;
    
    // Update is called once per frame
    void Update()
    {
        Score.text = ScoreCounter.text;
    }
}
