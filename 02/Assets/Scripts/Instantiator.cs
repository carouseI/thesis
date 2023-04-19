using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private GameObject[] profileCards;

    public Transform parent;

    public Button button01;
    public Button button02;

    private void Start()
    {
        button01.GetComponent<Button>();
        button01.onClick.AddListener(GenerateProfile);

        button02.GetComponent<Button>();
        button02.onClick.AddListener(GenerateProfile);
    }

    public void GenerateProfile()
    {
        GameObject prefab = profileCards[Random.Range(0, profileCards.Length)];

        Instantiate(prefab, transform.position, Quaternion.identity, parent);
        Debug.Log("instantiated");

        prefab.name = "profile";

        //Vector3 spawnPos = new Vector3(Random.Range(-50, 50), 24, Random.Range(-50, 50));

        //Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}