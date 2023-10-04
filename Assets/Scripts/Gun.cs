using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{

    private Rigidbody2D rb;
    public Transform FirePos;
    public GameObject Bullet;
    public float TimeBtwFire = 0.2f;
    public float BulletForce;
    private float timeBtwFire;
    public GameObject Muzzle;
    //public GameObject FireEffect;



    void Update()
    {
        RotateGun();
        timeBtwFire -= Time.deltaTime;
        if (Mouse.current.leftButton.isPressed && timeBtwFire < 0)
        {
            FireBullet();
        }
    }

    private void RotateGun()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); // sử dụng Mouse.current.position.ReadValue() để lấy giá trị vị trí con chuột

        Vector3 LooDir = MousePos - transform.position;
        float angle = Mathf.Atan2(LooDir.y, LooDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;
        GameObject BulletTmp = Instantiate(Bullet, FirePos.position, Quaternion.identity);
        Instantiate(Muzzle, FirePos.position, transform.rotation,transform);
        Rigidbody2D rb = BulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * BulletForce, ForceMode2D.Impulse);


    }
   
}

