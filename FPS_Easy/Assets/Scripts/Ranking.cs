using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public List<Text> text = new List<Text>();
    public List<string> name = new List<string>();
    public List<int> score = new List<int>();
    public List<Rank> rank = new List<Rank>();
    Dictionary<string, int> dict = new Dictionary<string, int>();
    string yourName;
    int yourScore;

    public struct Rank
    {
        public Rank(int score, string name)
        {
            this.score = score;
            this.name = name;
        }
        public int score;
        public string name;
    };
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            rank.Add(new Rank(PlayerPrefs.GetInt("RankingScore" + i), PlayerPrefs.GetString("RankingName" + i)));
            score.Add(PlayerPrefs.GetInt("RankingScore" + i));
        }
        yourName = PlayerPrefs.GetString("nowPlayerName");
        yourScore = PlayerPrefs.GetInt("nowPlayerScore");
        rank.Add(new Rank(yourScore, yourName));
        score.Add(yourScore);
        score.Sort();
        score.Reverse();
        score.RemoveAt(5);
        foreach (var b in score)
        {
            foreach (var a in rank)
            {
                if (a.score == b)
                {
                    name.Add(a.name);
                    rank.Remove(a);
                    break;
                }
            }

        }
        for (int i = 0; i < 5; i++)
        {
            text[i].text = name[i] + "   " + score[i];
            PlayerPrefs.SetString("RankingName" + i, name[i]);
            PlayerPrefs.SetInt("RankingScore" + i, score[i]);
        }
    }
}
