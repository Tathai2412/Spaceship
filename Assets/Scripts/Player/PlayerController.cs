using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float min_Y, max_Y;

    [SerializeField] private GameObject player_Laser;
    
    [SerializeField] private Transform attack_Point;

    public float attack_Timer = 0.35f;
    private float current_attack_Timer;
    private bool canAttack;
    
    void Start()
    {
        current_attack_Timer = attack_Timer;
    }

    void Update()
    {
        MovePlayer();
        AttackEnemy();
    }

    void MovePlayer()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > max_Y)
                temp.y = max_Y;
            
            transform.position = temp;

        } else if (Input.GetAxisRaw("Vertical") < 0f) {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < min_Y)
                temp.y = min_Y;

            transform.position = temp;
        }
    }

    void AttackEnemy()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_attack_Timer)
        {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (canAttack)
            {
                canAttack = false;
                attack_Timer = 0f;
                
                Instantiate(player_Laser, attack_Point.position, Quaternion.identity);
            }
        }
    }
    
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy")) 
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
