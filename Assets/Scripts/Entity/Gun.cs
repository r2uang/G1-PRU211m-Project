using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    private Transform bulletPoint;

    [SerializeField]
    private GameObject Bullet;

    private void Start()
    {

    }

    private void Update()
    {
    }


    public void Shoot(Vector2 Direction, float Force)
    {

        GameObject BulletIns = Instantiate(Bullet, bulletPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
}
