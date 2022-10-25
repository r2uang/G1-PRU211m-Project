using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expirence : MonoBehaviour
{
    private Transform target;
    private const int Range = 30;

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
            gameObject.SetActive(false);
        }
    }
}
