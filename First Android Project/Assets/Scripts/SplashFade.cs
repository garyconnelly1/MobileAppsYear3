using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class SplashFade : MonoBehaviour {

    public Image splashImage; // Splash Image was created at https://editor.freelogodesign.org/.

    LevelManager manager;

    IEnumerator Start() // Use IEnumerator so we can use a co routine.
    {
        manager = new LevelManager();

        splashImage.canvasRenderer.SetAlpha(0.0f); // When the scene starts, make the image invisible.

        FadeIn(); // Wall fade in.

        yield return new WaitForSeconds(3.5f); // Wait 3.5 seconds.

        FadeOut(); // Call fade out.

        yield return new WaitForSeconds(2.5f); // Wait 2.5 seconds.

        manager.ChangeLevel(Levels.Main_menu); // Then load the main menu scene.
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false); // Fade into full alpha in 1.5 seconds.
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false); // Fade to 0 alpha in 2.5 seconds.
    }
}
