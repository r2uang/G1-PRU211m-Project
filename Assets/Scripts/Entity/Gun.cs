using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    Vector2 direction;
    [SerializeField]
    private Transform bulletPoint;

    [SerializeField]
    private GameObject Bullet;

    private void Start()
    {
        
    }

    private void Update()
    {  
        direction = (bulletPoint.localRotation * Vector2.right).normalized;  
    }


    public void Shoot(Vector2 Direction,float Force)
    {
        GameObject BulletIns = Instantiate(Bullet, bulletPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
}
