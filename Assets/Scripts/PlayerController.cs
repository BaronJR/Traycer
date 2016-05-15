using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
    public int count;
    public Text countText;
	public Text winText;
    public float jump;
    public float jumpTime;
    public float bulletSpeed;
    
	private Rigidbody2D rb2d;
	private Vector2 position;
    private bool jumpCD;
    private float jumpTimer;
    private GameObject prefab;

    void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		winText.text = "";
        jumpCD = true;
        jumpTimer = 0;
		SetCountText ();

        prefab = Resources.Load("bullet") as GameObject;
    }

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
    }

    void Update()
    {
        //Tracer dash mechanic
        if (Input.GetKeyDown("space"))
        {
            if (jumpCD)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");
                Vector3 flash = new Vector3(moveHorizontal, moveVertical, 0);
                transform.position += (flash * jump);
                jumpCD = false;
                jumpTimer = jumpTime;
            }
        }

        //Fire bullets
        if (Input.GetMouseButtonDown(0))
        {
            PlayerGun();
        }

        //Tracer Dash mechanic CD
        if (!(jumpCD))
        {
            if (jumpTimer > 0)
            {
                jumpTimer -= Time.deltaTime;
            }
            else
            {
                jumpCD = true;
            }
        }
    }

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
	}

    //Fire bullets
    void PlayerGun ()
    {
        Vector3 mouseAim = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        mouseAim -= transform.position;
        mouseAim.Normalize();

        GameObject bullet = Instantiate(prefab) as GameObject;

        bullet.transform.position = transform.position + mouseAim;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = mouseAim * bulletSpeed;
    }

    //Pick up collectibles
	public void SetCountText ()
	{
		countText.text = "Bubble Teas: " + count.ToString ();

		if (count >= 6) {
			winText.text = "You win!";
		}
	}
}