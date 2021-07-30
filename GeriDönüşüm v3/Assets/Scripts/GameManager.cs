using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject WinUI;
    public GameObject PlayUI;
    public GameObject RedPanel;
    public GameObject FailPanel;
    

    public Image star1;

    public int requiredCount;

    public bool timeCtrl = true;

    public float timeValue = 60;
    float timePiece = 0;
    float tp1;
    float tp2;
    private int starCount = 0;

    public float size = 1.5f; //object size


    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timePiece = timeValue / 3;
        tp1 = timePiece * 2;
        tp2 = timePiece * 3;

        
    }
    void Update()
    {
        
        if (timeValue == 0)
        {
            Fail();
        }
        else if (timeValue <= 5 && timeCtrl)
        {
            StartCoroutine("redPanelFunc");

            timeCtrl = false;
        }
        
        if (0 <= timeValue && timeValue <= timePiece)
        {
            starCount = 1;
        }
        else if (timePiece <= timeValue && timeValue <= tp1)
        {
            starCount = 2;
        }
        else if (tp1 <= timeValue && timeValue <= tp2)
        {
            starCount = 3;
        }
    }

    IEnumerator redPanelFunc()
    {
        RedPanel.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        RedPanel.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        if(Mat.mat.isFinish == false)
            timeCtrl = true;
    }

    public void LevelComplete()
    {
        WinUI.SetActive(true);
        PlayUI.SetActive(false);
        Invoke("StarFill", 1);
    }
    public void Fail()
    {
        FailPanel.SetActive(true);
        Mat.mat.isFinish = true;
    }
    public void NextLevel() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        Debug.Log("RESTART IS HAPPENINGGG");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ContinueGame();
    }


    void ContinueGame()
    {
        Time.timeScale = 1;
    }

    void StarFill()
    {

        Debug.Log(starCount);

        if (starCount == 1)
        {
            star1.DOFillAmount(0.285f, 1f).SetEase(Ease.Linear);
        }
        else if (starCount == 2)
        {
            star1.DOFillAmount(0.720f, 1f).SetEase(Ease.Linear);
            
        }
        else if (starCount == 3)
        {
            star1.DOFillAmount(1, 1f).SetEase(Ease.Linear);          
        }
    }
}

   
