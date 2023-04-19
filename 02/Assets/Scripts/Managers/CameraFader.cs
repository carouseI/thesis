using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFader : MonoBehaviour
{
    [Range(0, 5)] // create slider between min (l) and max (r) values
    public int pauseBeforeFade;

    [HideInInspector]
    public Texture whiteTexture;
    public Color fadeColor;

    [Range(0, 10)]
    public float fadeTime;

    float currentTime;
    Color colorLerp;

    bool canStartFade;
    bool fadeIsComplete;

    private void Start()
    {
        colorLerp = fadeColor;
        StartCoroutine("StartCameraFade");
    }

    private void Update()
    {
        if (canStartFade)
        {
            currentTime += Time.deltaTime; //delta time = time in seconds between current and previous frame; never rely on delta from GUI method (can be called multiple times per frame)
            colorLerp = Color.Lerp(fadeColor, Color.clear, currentTime / fadeTime);
            //colorLerp = Color.Lerp(Color.clear, fadeColor, currentTime / fadeTime);

            if(currentTime >= fadeTime)
            {
                FadeComplete();
            }
        }
    }

    private void OnGUI()
    {
        GUI.color = colorLerp;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), whiteTexture);
    }

    public void FadeComplete()
    {
        fadeIsComplete = true;
        this.enabled = false;
        this.gameObject.SetActive(false);
    }

    IEnumerator StartCameraFade()
    {
        yield return new WaitForSeconds(pauseBeforeFade);

        canStartFade = true;

        yield return null;
    }
}
