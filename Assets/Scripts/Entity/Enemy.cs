using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy :  MonoBehaviour,IBaseEntity
{
    [SerializeField]
    private GameObject expPrefab;
    public BaseData.EnemyDataManager enemyData;
    private Rigidbody2D _body;
    private Transform target;

    public float BaseSpeed { get; set; } = 10;
    public float SmoothTime { get; set; } = 0.04f;

    private const float PlayerRange = 30;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(target.position, transform.position) > PlayerRange)
        //{
        //    Destroy(gameObject);
        //}
        if (Vector3.Distance(target.position,transform.position) <= enemyData.range)
        {
            Movement();
        }
        
        
    }

    public void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position,target.position, enemyData.Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
            Instantiate(expPrefab , transform.position, Quaternion.identity);
        }
    }

}
