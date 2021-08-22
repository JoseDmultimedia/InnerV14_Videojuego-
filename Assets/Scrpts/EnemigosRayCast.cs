using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;


public class EnemigosRayCast : MonoBehaviour {

    public float visionRadius, attackRadius, speed;
    GameObject player;
    Vector3 initialPosition;
    Rigidbody2D rb2d;
    public GameObject projectile;
    public int vida;
    
    

    private float timeBtShots;
    public float startTimeBtShots;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        timeBtShots = startTimeBtShots;
    }


    void Update()
    {
        Vector3 target = initialPosition;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, visionRadius, 1 << LayerMask.NameToLayer("Default"));

        //debug
        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        //si encuentra al player
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = player.transform.position;
            }
        }

        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        //Rango de ataque
        if (target != initialPosition && distance < attackRadius)
        {
            Debug.Log("Ataca enemigo");
            if (timeBtShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtShots = startTimeBtShots;
            }
            else
            {
                timeBtShots -= Time.deltaTime;
            }
            rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }
        else
        {
            rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
            //Se mueve
        }
        if (target == initialPosition && distance < 0.02f)
        {
            transform.position = initialPosition;
            //idle 
        }

        Debug.DrawLine(transform.position, target, Color.green);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("MargaritaShot"))
        {
            Destroy(other.gameObject);
            vida -= 20;
            if (vida <= 0)
            {
                Destroy(gameObject);
                Score.scoreValu += 1;
            }
        }
    }
}
