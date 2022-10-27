using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public bool isPlayer = true;
    private bool isDefend = false;
    public int defense = 300;
    [HideInInspector]
    public int underAttack;
    private float timer = 0;
    private string nameTagLawan;

    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
            nameTagLawan = "Enemy";
        }
        else
        {
            nameTagLawan = "Player";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefend)
        {
            timer += Time.deltaTime;
            if (timer > 0.6f)
            {
                defense -= underAttack;
                timer = 0f;
            }
        }

        if (defense <= 0)
        {
            Destroy(gameObject);
        }
        /*if (transform.position.x > 9 || transform.position.x < 9)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == nameTagLawan)
        {
            isDefend = true;
            Attacker enemyAttacker = collision.gameObject.GetComponent<Attacker>();

            if (enemyAttacker != null)
            {
                enemyAttacker.underAttack = 0;
            }

            Defender enemyDefender = collision.gameObject.GetComponent<Defender>();

            if (enemyDefender != null)
            {
                enemyDefender.underAttack = 0;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isDefend = false;
    }
}
