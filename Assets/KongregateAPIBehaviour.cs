using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KongregateAPIBehaviour : MonoBehaviour
{
    private static KongregateAPIBehaviour instance;

    public static int BestScore;
    public static bool gameFinished;
    public bool reset;
    void Start()
    {

        if(reset)PlayerPrefs.DeleteAll();

        BestScore = PlayerPrefs.GetInt("Score",0);
        gameFinished = PlayerPrefs.GetInt("Finished",0)==1 ? true:false;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Object.DontDestroyOnLoad(gameObject);
        gameObject.name = "KongregateAPI";

        Application.ExternalEval(
          @"if(typeof(kongregateUnitySupport) != 'undefined'){
        kongregateUnitySupport.initAPI('KongregateAPI', 'OnKongregateAPILoaded');
      };"
        );

        SendScore();
        if(gameFinished){
            SendFinishedGame();
        }

        
    }

    public static void setScore(int score){
        if(score>BestScore)BestScore=score;

        SendScore();
    }
    void OnDestroy()
    {
        PlayerPrefs.SetInt("Score",BestScore);
        if(gameFinished){
            PlayerPrefs.SetInt("Finished",1);
        }else{
            PlayerPrefs.SetInt("Finished",0);
        }
    }
    
    public void OnKongregateAPILoaded(string userInfoString)
    {
        OnKongregateUserInfo(userInfoString);
    }

    public void OnKongregateUserInfo(string userInfoString)
    {
        var info = userInfoString.Split('|');
        var userId = System.Convert.ToInt32(info[0]);
        var username = info[1];
        var gameAuthToken = info[2];
        Debug.Log("Kongregate User Info: " + username + ", userId: " + userId);
    }

    public static void sendInitialized(){
        Application.ExternalCall("kongregate.stats.submit", "Initialized", 1);
    }
    public static void SendScore()
    {
        Application.ExternalCall("kongregate.stats.submit", "Score", BestScore);
    }

    public static void SendFinishedGame(){
        Application.ExternalCall("kongregate.stats.submit", "FinishedGame", 1);
    }

}
