using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {


    [SerializeField]
    private float speed;
    private Vector2 direction;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
    public GameObject teleportInner;
    public GameObject player;
    public int vida;
    

    
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        vida = 500;
	}
	
	// Update is called once per frame
	void Update () {

        GetInput();
        Move();
        vidaUi.vida = vida;
	}

    public void Move()
    {
        playerMoving = false;
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f || Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
            transform.Translate(direction * speed * Time.deltaTime);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }


        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("Moving", playerMoving);
        anim.SetFloat("LastMoveX",lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

    }

    private void GetInput()
    {

        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;                
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;           
        }

        if (Input.GetKey(KeyCode.F))
        {
           player.transform.position = new Vector2(teleportInner.transform.position.x, teleportInner.transform.position.y);

        }
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("enemigo") || other.CompareTag("shotsEnemi"))
        {
            vida -= 20;
            if (vida <= 0)
            {
                //Destroy(gameObject);
                //SceneManager.LoadScene("Primera_Pantalla");
                Over.show();
            }
        }
        if (other.CompareTag("salvavidas"))
        {
            vida = 500;
        }
    }



}


