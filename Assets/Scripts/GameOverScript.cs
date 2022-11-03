using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text recordTimeTxt;
    public void Setup(string time)
    {
        gameObject.SetActive(true);
        recordTimeTxt.text = time;
    }
}
