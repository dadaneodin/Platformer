using UnityEngine;
using System.Collections;

public class ArenaLockSequence : MonoBehaviour
{
    [Header("Настройки стоек (дверей)")]
    public Transform[] pillars; 
    public float raiseDistance = 5f; 
    public float raiseSpeed = 3f;    

    [Header("Объекты для удаления")]
    [Tooltip("Перетащи сюда первый объект, который нужно удалить")]
    public GameObject firstObjectToDelete;
    [Tooltip("Перетащи сюда второй объект, который нужно удалить")]
    public GameObject secondObjectToDelete;

    private bool isLocked = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isLocked)
        {
            isLocked = true;
            StartCoroutine(LockArena());
        }
    }

    private IEnumerator LockArena()
    {
        // Запоминаем начальные и конечные позиции
        Vector3[] startPositions = new Vector3[pillars.Length];
        Vector3[] targetPositions = new Vector3[pillars.Length];
        
        for (int i = 0; i < pillars.Length; i++)
        {
            startPositions[i] = pillars[i].position;
            targetPositions[i] = pillars[i].position + Vector3.up * raiseDistance;
        }

        // Плавно поднимаем стойки
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * raiseSpeed;
            for (int i = 0; i < pillars.Length; i++)
            {
                pillars[i].position = Vector3.Lerp(startPositions[i], targetPositions[i], t);
            }
            yield return null; 
        }

        // Проверяем, перетащил ли ты первый объект, и удаляем его
        if (firstObjectToDelete != null)
        {
            Destroy(firstObjectToDelete);
        }

        // Проверяем и удаляем второй объект
        if (secondObjectToDelete != null)
        {
            Destroy(secondObjectToDelete);
        }

        // Двери закрылись! Здесь запускаем логику самого босса
        Debug.Log("Арена закрыта! Начало боя!");
        // FindObjectOfType<BossController>().StartFight();
    }
}