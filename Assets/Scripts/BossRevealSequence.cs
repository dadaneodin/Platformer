using UnityEngine;
using Cinemachine;
using System.Collections;

public class BossRevealSequence : MonoBehaviour
{
    [Header("Настройки камеры")]
    public CinemachineVirtualCamera bossCam; // Камера, которая смотрит на босса
    public float revealDuration = 2.5f;      // Сколько секунд смотрим на босса

    private bool hasRevealed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasRevealed)
        {
            hasRevealed = true;
            StartCoroutine(ShowBoss());
        }
    }

    private IEnumerator ShowBoss()
    {
        // [Опционально] Отключить управление игроком, чтобы он не ушел во время катсцены
        PlayerInput.instance.canMove = false;
        
        // Переключаем камеру на босса
        if (bossCam != null)
        {
            bossCam.Priority = 20; 
        }

        // Ждем нужное время
        yield return new WaitForSeconds(revealDuration);

        // Возвращаем камеру игроку
        if (bossCam != null)
        {
            bossCam.Priority = 0; 
        }

        // [Опционально] Включить управление обратно
        PlayerInput.instance.canMove = true;
    }
}