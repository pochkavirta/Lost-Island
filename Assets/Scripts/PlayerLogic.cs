using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public GameObject magicAttack;
    public PlayerMagicAttack playerMagicAttack;
    public float spellDuration;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ActivateWithDelay());
        }
    }

    IEnumerator ActivateWithDelay()
    {
        // Активируем атаку
        magicAttack.SetActive(true);
        // Ждём 5 секунд
        yield return new WaitForSeconds(spellDuration);
        // Деактивируем
        magicAttack.SetActive(false);
    }
}
