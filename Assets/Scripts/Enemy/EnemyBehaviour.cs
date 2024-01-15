using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public bool Head;
    public bool Body;
    [HideInInspector]
    public bool isEnemyAttack;

    Rigidbody2D rb2d;
    public int nextMove;

    [Header("Battle State")]
    public bool isFighting;
    public bool neerPlayer;

    [SerializeField] private enemyHealthManager enemyHealthManager;
    [SerializeField] private playerHealth playerHealth;

    void Awake()
    {
        if (!Body)
            return;
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Think", 2);
    }

    private void Update()
    {
        Dead();
    }

    void FixedUpdate()
    {
        if (!Body)
            return;
        {
            if (!isFighting) //#.AI roaming without falling when it's not in combat
            {
                rb2d.velocity = new Vector2(nextMove, rb2d.velocity.y);

                Vector2 frontVec = new Vector2(rb2d.position.x + nextMove * 0.2f, rb2d.velocity.y + 1f);
                Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
                RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
                if (rayHit.collider == null)
                {
                    nextMove *= -1;
                    CancelInvoke();
                    Invoke("Think", 3);
                }
            }
        }
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(1f, 4f);
        Invoke("Think", nextThinkTime);
    }

    public void OnHeadClick()
    {
        print("Head");

        if (Random.Range(0f, 1f) <= 0.3f)
        {
            enemyHealthManager.TakeHeadDamage(5);
            Invoke(nameof(PlayerHit), 0.3f);
        }

    }

    public void OnBodyClick()
    {
        print("Body");

        if (Random.Range(0f, 1f) <= 0.7f)
        {
            enemyHealthManager.TakeHeadDamage(3);
            Invoke(nameof(PlayerHit), 0.3f);
        }
    }

    public void PlayerHit()
    {
        playerHealth.Damage(Random.Range(1, 3));
        isEnemyAttack = false;
    }

    public void Dead()
    {
        if (enemyHealthManager.currentHealth <= 0)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}