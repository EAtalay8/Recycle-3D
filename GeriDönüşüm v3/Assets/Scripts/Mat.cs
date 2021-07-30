using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class Mat : MonoBehaviour
{
    public static Mat mat;

    public int objectCount = 0;

    private string reqCountStr;

    public Text text1;

    public bool spin = false;
    public bool isFinish = false;

    public GameObject smoke;
    public GameObject product;
    public GameObject vcam2;

    [SerializeField] Ease easeType = Ease.OutBounce;

    private void Awake()
    {
        mat = this;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Cube")
        {
            objectCount++;
            Debug.Log(objectCount);
            other.gameObject.tag = "Disappear";
        }

        else if(other.gameObject.tag == "Untagged")
        {
            other.transform.DOMove(new Vector3(0, 7, 6), 1).SetEase(easeType);
        }

        if (objectCount == GameManager.instance.requiredCount && isFinish == false)
        {
            isFinish = true;
            Debug.Log("effect");
            StartCoroutine("Eff");
        }

        if (isFinish)
        {
            GameObject[] destroyObject;
            destroyObject = GameObject.FindGameObjectsWithTag("Disappear");
            foreach (GameObject oneObject in destroyObject)
                Destroy(oneObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spin)
        {
            GameObject.FindGameObjectWithTag("Production").transform.Rotate(0, 100 * Time.deltaTime, 0);
            GameObject.FindGameObjectWithTag("Production1").transform.Rotate(0, 100 * Time.deltaTime, 0);
        }

        reqCountStr = GameManager.instance.requiredCount.ToString();

        text1.text = objectCount.ToString() + "/" + reqCountStr;
    }
    IEnumerator Eff()
    {
        smoke.SetActive(true);

        yield return new WaitForSeconds(1f); // 

        product.SetActive(true);

        spin = true;

        yield return new WaitForSeconds(2f);
       //cubee.GetComponent<MeshRenderer>().material.DOFade(0, 2f);
       
        //vcam2.GetComponent<CinemachineVirtualCamera>().Priority = 11;

        yield return new WaitForSeconds(3f);

        GameManager.instance.LevelComplete();
    }

   

}
