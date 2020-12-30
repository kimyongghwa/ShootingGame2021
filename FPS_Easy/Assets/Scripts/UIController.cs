using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public PlayerController pc;
    public Image hpBar;
    public Image expBar;
    public Text levelText;
    public Text scoreText;
    public string frontScoreText = "000000";
    string front = "000000";

    // Update is called once per frame
    void Update()
    {
        if (pc != null)
        {
            hpBar.fillAmount = pc.hp/ (float)pc.maxHp ;
            expBar.fillAmount = pc.exp /(float)pc.needExp[pc.level];
            levelText.text = pc.level + "LV";
            int j = 0;
            for(int i=1; i<=100000; i *= 10)
            {
                if (pc.score / i == 0)
                {
                   front = frontScoreText.Substring(0, frontScoreText.Length-j);
                    break;
                }
                j++;
            }
            if(pc.score != 0)
                scoreText.text = front + pc.score;
        }
    }
}
