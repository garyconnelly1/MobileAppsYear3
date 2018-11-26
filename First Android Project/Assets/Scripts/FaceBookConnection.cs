using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using Assets.Scripts;

public class FaceBookConnection : MonoBehaviour {

  //  private string highScore;
    int score;
    LevelManager manager;

    void Start()
    {
        manager = new LevelManager();
        score = HighScoreCalculation.getHighScore(Levels.Level_6); // Get a handle on the high score for level 6. 
    }

    /* Adapted from https://www.youtube.com/watch?reload=9&v=QVuVwTwKjxE */

    private void Awake()
    {
        if (!FB.IsInitialized) // If Facebook is not initialized.
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized) // Initialize Facebook.
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
                    Time.timeScale = 0; // Freeze time.
                else
                    Time.timeScale = 1; // Time is normal.

            });
        }
        else
            FB.ActivateApp(); // Activate Facebook.
    }

    public void FaceBookLogin() // If the user clicks LogIn.
    {
        
        var permissions = new List<string>() { "public_profile", "email", "user_friends" }; 
        FB.LogInWithReadPermissions(permissions); // Set the permissions for the App. 
    }

    public void FaceBookLogOut() // If the user clicks LogOut.
    {
        FB.LogOut(); // Log out of the Facebook App. 
    }

    public void Share() // If the user clicks Share.
    {
        FB.ShareLink(new System.Uri("https://github.com/garyconnelly1/MobileAppsYear3"),
            "High Score!",
            "I have a high score of " + score + " in the endless Runner Level on Mango's Big Adventure. Give it a try!", // Share the users high score for level 6 of the game.
            new System.Uri("https://github.com/garyconnelly1/MobileAppsYear3/blob/master/DesignImages/MBA.PNG"));
    }

    public void MainMenu()
    {
        manager.ChangeLevel(Levels.Main_menu); // Provide an option to go straight back to main menu.
    }
}
