using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMagicAttack : MonoBehaviour
{
    private List<GameObject> enemiesInRange = new List<GameObject>();
    public float radius;
    public float ticksPerSecond;
    public int dmgPerTick;
    private float nextAttackTime;

    private void Start()
    {
        RangeAttack();
        CalculateNextAttackTime();
    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            RangeAttack();
            CalculateNextAttackTime();
        }
    }

    private void CalculateNextAttackTime()
    {
        nextAttackTime = Time.time + (1f / ticksPerSecond);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInRange.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collision.gameObject);
        }
    }

    public void RangeAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.GetComponent<EnemyHealth>().TakeDamage(dmgPerTick);
            }
        }

        Debug.Log("Attack performed with radius: " + radius + ". Attack performed at: " + Time.time);
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radius);
    }*/
}
