//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class DestroyInteractable : MonoBehaviour
//{
//    //[SerializeField] private GameObject[] dead;
//    public Button button;

//    public ScoreInteractable score;
//    public ScoreInteractable rejected;

//    // Start is called before the first frame update
//    private void Start()
//    {
//        button.GetComponent<Button>();
//        button.onClick.AddListener(Destroy);
//    }

//    // Update is called once per frame
//    public void Destroy()
//    {
//        //GameObject prefab = dead[Random.Range(0, dead.Length)];

//        //Destroy(prefab);
//        //Debug.Log(prefab.name);

//        score.SubtractScore();
//        rejected.AddScore(100);
//    }
//}
