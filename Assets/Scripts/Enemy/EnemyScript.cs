using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 3f;

    public Animator enemyAnim;
    
    [SerializeField] private GameObject enemy_Laser;
    
    [SerializeField] private Transform attack_Point;
    
    public float attack_Timer = 1.5f;
    private float current_attack_Timer;
    private bool canAttack;
    
    void Start()
    {
        current_attack_Timer = attack_Timer;
        enemyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
            
        transform.position = temp;
    }
    
    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_attack_Timer)
        {
            canAttack = true;
        }

        if (canAttack)
        {
            canAttack = false;
            attack_Timer = 0f;
                
            Instantiate(enemy_Laser, attack_Point.position, Quaternion.identity);
        }
    }
    
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("Laser")) 
        {
            enemyAnim.Play("Destroy");
            Destroy(col.gameObject);
            Destroy(gameObject, 0.37f);
        }
    }
}
