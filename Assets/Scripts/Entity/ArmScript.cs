using UnityEngine;

public class ArmScript : MonoBehaviour
{
    // Start is called before the first frame update
    public FloatingJoystick joystick;
    public float angle;
    void Start()
    {
        joystick = GameObject.FindGameObjectWithTag("InputControl").GetComponent<FloatingJoystick>();
    }
    // Update is called once per frame
    void Update()
    {

        RotateWeapon();
    }

    void RotateWeapon()
    {
        if (joystick == null) return;
        angle = Mathf.Atan2(joystick.Direction.y, joystick.Direction.x) * Mathf.Rad2Deg;
        var lookRotation = Quaternion.Euler(angle * Vector3.forward);
        transform.rotation = lookRotation;
        transform.localScale = joystick.Horizontal > 0 ? Vector3.one : new Vector3(1, -1, -1);
    }
}
