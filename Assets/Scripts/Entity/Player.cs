using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Player : MonoBehaviour, IBaseEntity
{
    public BaseData.PlayerDataManager playerData;

    private Rigidbody2D _body;
    
    public float BaseSpeed { get; set; } = 5;
    public float SmoothTime { get; set; } = 0.04f;

    private Vector3 velocitySmoothing;

    public FloatingJoystick joystick;
    private State PlayerState { get; set; } = State.IDLE;

    private Vector3 moveDir;

    private float Range;

    private Transform Target;

    private bool Detected = false;

    private Vector2 Direction;

    //[SerializeField]
    //private GameObject Gun;

    public float FireRate;

    public float nextTimeToFire;

    public float Force;

    Gun[] guns;

    public float timeToFireBulletHell;
    
    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
        Target = transform;
        Range = playerData.shootingRange;
        _body = GetComponent<Rigidbody2D>();
        joystick = GameObject.FindGameObjectWithTag("InputControl").GetComponent<FloatingJoystick>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        switch (PlayerState)
        {
            case State.MOVEMENT:
                break;
            case State.IDLE:
                Idle();
                break;
        }
    }

    private void FixedUpdate()
    {
        Target = GetClosestEnemy(GetTransformEnemies());
        if(Target != null)
        {
            RaycastPosition();
        }
        
    }

    private List<Transform> GetTransformEnemies()
    {
        GameObject[] bigEnemies = GameObject.FindGameObjectsWithTag("Big Enemy");
        GameObject[] smallEnemies = GameObject.FindGameObjectsWithTag("Small Enemy");
        List<Transform> result = new List<Transform>();
        foreach(var bigEnermy in bigEnemies)
        {
            result.Add(bigEnermy.transform);
        }
        foreach(var smallEnermy in smallEnemies)
        {
            result.Add(smallEnermy.transform);
        }
        return result;
    }

    private Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;

    }

    private void RaycastPosition()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                
                if (!Detected)
                {
                    Detected = true;

                }
                else
                {
                    Detected = false;
                }
            }
        }

        if (Detected)
        {
            //Gun.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        //GameObject BulletIns = Instantiate(Bullet, bulletPoint.position, Quaternion.identity);
        //BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        

        timeToFireBulletHell -= Time.deltaTime;
        guns[0].Shoot(Direction,Force);
        if(timeToFireBulletHell <= 0 && guns.Length != 0)
        {
            for (int i = 1;i < guns.Length; i++)
            {
                guns[i].Shoot(Direction,Force);
            }
            timeToFireBulletHell = 0.1f;
        }

    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    public void Movement()
    {
        bool isMoving = false;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            isMoving = true;
            _body.velocity = Vector3.SmoothDamp(_body.velocity, Vector3.left * BaseSpeed, ref velocitySmoothing, SmoothTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            isMoving = true;
            _body.velocity = Vector3.SmoothDamp(_body.velocity, Vector3.right * BaseSpeed, ref velocitySmoothing, SmoothTime);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            isMoving = true;
            _body.velocity = Vector3.SmoothDamp(_body.velocity, Vector3.up * BaseSpeed, ref velocitySmoothing, SmoothTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            isMoving = true;
            _body.velocity = Vector3.SmoothDamp(_body.velocity, Vector3.down * BaseSpeed, ref velocitySmoothing, SmoothTime);
        }

        if (joystick && joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            isMoving = true;
            moveDir = new Vector2(joystick.Horizontal, joystick.Vertical);
            _body.velocity = Vector3.SmoothDamp(_body.velocity, moveDir * BaseSpeed, ref velocitySmoothing, SmoothTime);
        }
        if (isMoving)
        {
            PlayerState = State.MOVEMENT;
        } else
        {
            PlayerState = State.IDLE;
        }
    }

    public void Idle()
    {
        _body.velocity = Vector3.zero;
    }
    enum State
    {
        IDLE = 0,
        MOVEMENT = 1,
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
}
