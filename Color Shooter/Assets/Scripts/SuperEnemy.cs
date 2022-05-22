using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SuperEnemy : Enemy
{
    Dictionary<string, List<string>> superColors = new Dictionary<string, List<string>>() {
        {"Green", new List<string>(){"Blue","Yellow"} },
        {"Purple", new List<string>(){"Blue","Red"} },
        {"Orange", new List<string>(){"Red","Yellow"} }
    };

    List<string> superEnemyColor;
    // Start is called before the first frame update
    protected override void Start()
    {
        health = 2;
        superEnemyColor = superColors[enemyColor.ToString()];
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            foreach(var supercolor in superEnemyColor.ToList())
            {
                if (other.gameObject.GetComponent<bullet>().bulletColor.ToString() == supercolor)
                {
                    health -= 1;
                    gameManager.GetComponent<GameManager>().IncreseScore(5);
                    Destroy(other.gameObject);
                    superEnemyColor.Remove(supercolor);
                    Debug.Log(supercolor);
                }
                else
                {
                    if (superEnemyColor.Count > 1)
                    {
                        if(other.gameObject.GetComponent<bullet>().bulletColor.ToString() != superEnemyColor[1])
                        {
                            player.GetComponent<Player>().Health(-1);
                            Destroy(other.gameObject);
                        }
                    }
                    else
                    {
                        player.GetComponent<Player>().Health(-1);
                        Destroy(other.gameObject);
                    }
                    
                }
            }
            

        }
    }
}
