using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicAttack : MonoBehaviour
{
    private List<GameObject> enemiesInRange = new List<GameObject>();
    public float radius;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RangeAttack();
            Debug.Log("Attack performed with radius: " + radius);
        }
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
                hit.GetComponent<EnemyHealth>().TakeDamage(10);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radius);
    }
}
