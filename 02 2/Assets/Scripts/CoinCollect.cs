using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    //public ScoreManager scoreManager;
    private Renderer _renderer;

    public FirstPersonCamera camera;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        //Cursor.visible = true;
    }

    private void OnMouseDown()
    {
        if (camera.canCollect)
        {
            Debug.Log("clicked");
            //_renderer.material.color =
            //_renderer.material.color == Color.red ? Color.blue : Color.red;

            //scoreManager.AddScore += 1;
            Destroy(gameObject);
        }
    }
}
