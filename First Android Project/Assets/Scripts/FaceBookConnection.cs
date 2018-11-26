using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using Assets.Scripts;

public class FaceBookConnection : MonoBehaviour {

    private string highScore;
    int score;
    LevelManager manager;

    void Start()
    {
        manager = new LevelManager();
        score = HighScoreCalculation.getHighScore(Levels.Level_6);
       
    }


    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                }
                else
                {
                    Debug.Log("Couldn't Initialize Facebook");
                }
            },
            isGameShown =>
            {
                if (isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;

            });
        }
        else
            FB.ActivateApp();
    }

    public void FaceBookLogin()
    {
        
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(permissions);
    }

    public void FaceBookLogOut()
    {
        FB.LogOut();
    }

    public void Share()
    {
        FB.ShareLink(new System.Uri("https://github.com/garyconnelly1/MobileAppsYear3"),
            "High Score!",
            "I have a high score of " + score + " in the endless Runner Level on Mango's Big Adventure. Give it a try!",
            new System.Uri("https://github.com/garyconnelly1/MobileAppsYear3/blob/master/DesignImages/MBA.PNG"));
    }

    public void MainMenu()
    {
        manager.ChangeLevel(Levels.Main_menu);
    }
}
