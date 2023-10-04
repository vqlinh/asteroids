using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Asteroid : MonoBehaviour {
    public Sprite[] sprites;

    public float Size;
    public float MinSize;
    public float MaxSize;
    private SpriteRenderer sp;
    private Rigidbody2D rb;
    public float Speed ;
    public float MaxLifeTime ;
    public GameObject SOCLO;
    private bool ItemsCreated = false;


    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        sp.sprite = sprites[Random.Range(0, sprites.Length)];
        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        this.transform.localScale = Vector3.one * this.Size;
        rb.mass = this.Size*3.0f;
    }
    public void SetTrajectory(Vector2 direction)
    {
        rb.AddForce(direction * this.Speed);
        Destroy(this.gameObject, this.MaxLifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Bullet")
        {
            if ((this.Size ) > 2f)
            {
                if (!ItemsCreated) // Kiểm tra xem hàm đã được gọi hay chưa
                {
                    CreateItems();
                    ItemsCreated = true; // Đánh dấu là đã gọi hàm
                }
            }
            else if(this.Size >=1f)
            {
                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<Manage>().AsteroidDestroyed(this);

            Destroy(this.gameObject);
        }
    }
    private void CreateSplit()
    {
        Vector2 position= this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Asteroid half = Instantiate(this,position,this.transform.rotation);
        half.Size = this.Size*0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized* this.Speed*0.2f);
    }
    private void CreateItems()
    {
        // Khởi tạo vật phẩm mong muốn
        GameObject Gun = Instantiate(SOCLO, transform.position, Quaternion.identity);


        // Phá hủy hành tinh
        Vector2 direction = Random.insideUnitCircle.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Gun.GetComponent<Rigidbody2D>().velocity = direction * this.Speed * 0.01f;
        Destroy(gameObject);
    }
}
