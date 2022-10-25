using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expirence : MonoBehaviour
{
    [SerializeField]
    private int Value;
    private Transform target;
    private const int Range = 35;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) > Range)
        {
            Debug.Log("Exp disappearrrrrrrrrr");
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            LevelManager.LevelUp(Value);
        }
    }
}
