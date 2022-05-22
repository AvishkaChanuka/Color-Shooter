using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    protected GameObject player;
    protected GameObject gameManager;
    private Rigidbody enemyRB;
    private Vector3 lookDirection;

    protected int health = 1;

    public enum color { Blue, Red, Yellow, Green, Orange, Purple };
    [SerializeField]protected color enemyColor;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        enemyRB = GetComponent<Rigidbody>();
        lookDirection = (new Vector3(player.transform.position.x,0,player.transform.position.z)- new Vector3(transform.position.x, 0,transform.position.z)).normalized;
        
    }

    protected virtual void Update()
    {
        DieEnemy();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        //enemyRB.velocity = lookDirection * speed;
        transform.Translate(lookDirection * speed * Time.fixedDeltaTime);
    }
    

     protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            if (other.gameObject.GetComponent<bullet>().bulletColor.ToString() == enemyColor.ToString())
            {
                health -= 1;
                gameManager.GetComponent<GameManager>().IncreseScore(5);
                Destroy(other.gameObject);
            }
            else
            {
                player.GetComponent<Player>().Health(-health);
                Destroy(other.gameObject);
            }

        }
        
    }

    protected void DieEnemy()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Player Place")
        {
            player.GetComponent<Player>().Health(-health);
            Destroy(gameObject);
        }
    }
}
