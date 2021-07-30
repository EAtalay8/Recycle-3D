using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //public float timeValue = 60;
    public Text timerText;

    public static Timer time;

    private void Awake()
    {
        time = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timeValue);
        if (Mat.mat.isFinish == false)
        {

            if (GameManager.instance.timeValue > 0)
            {
                GameManager.instance.timeValue -= Time.deltaTime;
            }

            else
            {
                GameManager.instance.timeValue = 0;
            }
        }

        DisplayTime(GameManager.instance.timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        //float minutes = Mathf.FloorToInt(timeToDisplay / 60);

        float seconds = Mathf.FloorToInt(timeToDisplay);

        timerText.text = string.Format("{0:00}", seconds);

    }
}
