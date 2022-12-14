using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using YG;

public class CheckConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;
    private TextMeshProUGUI scoreBest;
    [SerializeField] private TextMeshProUGUI userStatus;
    [SerializeField] private TextMeshProUGUI achivmentList;
    void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            CheckSDK();
        }
    }

    public void CheckSDK()
    {
        if (YandexGame.auth == true)
        {
            userStatus.text = "Online";
            Debug.Log("User authorization ok");
        }
        else
        {
            Debug.Log("User not authorization");
            YandexGame.AuthDialog();
        }
        YandexGame.RewVideoShow(0);
        GameObject scoreBO = GameObject.Find("BestScore");
        scoreBest = scoreBO.GetComponent<TextMeshProUGUI>();
        scoreBest.text = "Best Score: " + YandexGame.savesData.bestScore.ToString();
        if ((YandexGame.savesData.achivMent)[0] == null & !GameObject.Find("ListAchiv"))
        {

        }
        else
        {
            foreach (string value in YandexGame.savesData.achivMent)
            {
                Debug.Log(value + " Cool!!!");
                GameObject listAchiv = GameObject.Find("ListAchiv");
                achivmentList.text = value.ToString() + "\n";
                // GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text = value;
                // GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text = GameObject.Find("ListAchiv").GetComponent<TextMeshProUGUI>().text + value.ToString() + "\n";
            }
        }
    }
}
