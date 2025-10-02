using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;


    /*[SerializeField] Text text;*/


    void Awake ()
    {
        score = 0;
    }


    // Will be dealt with by UI script
    /*void Update ()
    {
        text.text = "Score: " + score;
    }*/
}
