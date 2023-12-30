using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorecounter : MonoBehaviour
{
    int score = 0;
    public Image score_02,score_01,score_00;
    public Sprite[] numberSprites;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scoreadd(int s)
    {
        score+=s;
        int a = score / 100;
        int b = (score - a * 100) / 10;
        int c = score - a * 100 - b * 10;
        score_02.sprite = numberSprites[a];
        score_01.sprite = numberSprites[b];
        score_00.sprite = numberSprites[c];        
    }
}
