using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider slide;
    public Text coinText;
    public Text timeText;
    float timer = 0;
    float countdown = 90;

    // Start is called before the first frame update
    void Start()
    {
        Data.coin = 0;
        timeText.text = "01:30";
    }

    // Update is called once per frame
    void Update()
    {
        if(Data.coin < 800)
        {
            Data.coin += 50 * Time.deltaTime;
            slide.value = Data.coin;
            coinText.text = Data.coin.ToString("000");
        }
        timer += Time.deltaTime;
        if(timer > 1f)
        {
            timer = 0;
            if (countdown > 0)
            {
                countdown--;
                string minutes = Mathf.Floor(countdown / 60).ToString("00");
                string seconds = Mathf.Floor(countdown % 60).ToString("00");

                timeText.text = minutes + " : " + seconds;
            }
            else
            {
                Data.isGameOver = true;
                Data.isComplete = false;
            }
        }
    }
}
