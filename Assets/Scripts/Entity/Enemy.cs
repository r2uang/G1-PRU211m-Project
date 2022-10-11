using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy :  MonoBehaviour,IBaseEntity
{
    public BaseData.EnemyDataManager enemyData;
    private Rigidbody2D _body;
    private Transform target;

    public float BaseSpeed { get; set; } = 10;
    public float SmoothTime { get; set; } = 0.04f;


    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position,transform.position) <= enemyData.maxRange || Vector3.Distance(target.position, transform.position)  >= enemyData.minRange)
        {
            Movement();
        }
        
    }

    public void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position,target.position, enemyData.Speed * Time.deltaTime);
    }
}
