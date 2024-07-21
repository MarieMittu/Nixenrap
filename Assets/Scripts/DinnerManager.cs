using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinnerManager : MonoBehaviour
{

    public static DinnerManager instance;

    public Text dinnerText;

    public int dinner = 0;
    public int newDinner = 0;

    public GameObject sunTimer;

    public float morningDuration = 90f;
    float secondTimer = 0f;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dinner = 0;
        newDinner = PlayerPrefs.GetInt("newDinnerNum", dinner);
        dinnerText.text = dinner.ToString() + "/5";
        
    }

    



    public void AddDinner()
    {
        dinner++;
        dinnerText.text = dinner.ToString() + "/5";
        PlayerPrefs.SetInt("newDinnerNum", dinner);
    }

    // Update is called once per frame
    void Update()
    {
        secondTimer = secondTimer + Time.deltaTime;
        if (secondTimer >= 1f)
        {
            morningDuration--;
            secondTimer = secondTimer - 1f;
        }
           
        

        if(dinner == 5 || morningDuration <= 0)
        {
            
            Invoke("FinishGame", 1.0f);
        }
    }

    void FinishGame()
    {
        PlayerPrefs.SetInt("newDinnerNum", dinner);
        PlayerPrefs.Save();
        Debug.Log("dinnergmeend" + dinner);
        FindObjectOfType<GameManager>().EndGame();
    }
}
