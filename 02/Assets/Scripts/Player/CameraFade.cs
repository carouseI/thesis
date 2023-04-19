using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public float speed = 1f;
    public Color fadeColor = Color.black;

    public AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1),
                                  new Keyframe(0.5f, 0.5f, -1.5f, -1.5f),
                                  new Keyframe(1, 0));

    private float alpha = 0f;
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;

    bool isTired = false;
    public bool startFade = false;

    // Start is called before the first frame update
    void Start()
    {
        if (startFade)
        {
            alpha = 1f;
        }
        else
        {
            alpha = 0f;
        }

        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTired)
        {
            if(alpha >= 1f)
            {
                alpha = 1f;
                time = 0f;
                direction = 1;
            }
        }
        if (!isTired)
        {
            alpha = 0f;
            time = 1f;
            direction = -1;
        }
    }

    public void OnGUI()
    {
        if(alpha > 0f)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }
        if (isTired) //???
        {
            time += direction * Time.deltaTime * speed;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
        }
    }
}
