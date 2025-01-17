using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgManager : MonoBehaviour
{

    //public int dinnerNum = DinnerManager.instance.dinner;
    public GameObject dinnerTime, diet, starving;

    // Start is called before the first frame update
    void Start()
    {

        int dinnerNum = PlayerPrefs.GetInt("newDinnerNum", 0);

        Debug.Log("DinnerNum: " + dinnerNum);
        if (dinnerNum == 0)
        {
            starving.SetActive(true);
            diet.SetActive(false);
            dinnerTime.SetActive(false);

        } else if (dinnerNum == 5)
        {
            starving.SetActive(false);
            diet.SetActive(false);
            dinnerTime.SetActive(true);

        } else
        {
            starving.SetActive(false);
            diet.SetActive(true);
            dinnerTime.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
