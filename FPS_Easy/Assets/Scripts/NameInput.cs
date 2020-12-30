using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameInput : MonoBehaviour
{
    public Text name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void NameSet()
    {
        if (name.text != null)
        {
            PlayerPrefs.SetString("nowPlayerName", name.text);
            SceneManager.LoadScene(3);
        }
    }
}
