using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expirence : MonoBehaviour
{
    [SerializeField]
    private int Value;
    private Transform target;
    private const int Range = 20;

    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
        levelManager = GameObject.FindGameObjectWithTag("Exp Bar").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) > Range)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            levelManager.LevelUp(Value);
        }
    }
}
