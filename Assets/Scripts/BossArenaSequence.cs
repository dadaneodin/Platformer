using UnityEngine;
using Cinemachine;
using System.Collections;

public class BossArenaSequence : MonoBehaviour
{
    [Header("Настройки стоек")]
    [Tooltip("Перетащи сюда объекты стоек из иерархии")]
    public Transform[] pillars; 
    public float raiseDistance = 5f; // На сколько по Y поднимутся стойки
    public float raiseSpeed = 2f;    // Скорость анимации

    [Header("Настройки Cinemachine")]
    public CinemachineVirtualCamera bossCam; // Ссылка на камеру арены
    public float cameraFocusTime = 2f;       // Сколько секунд смотрим на арену

    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, что вошел игрок и что триггер еще не срабатывал
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(StartBossEvent());
        }
    }

    private IEnumerator StartBossEvent()
    {
        // [Опционально] Здесь можно отключить управление игроком
        // PlayerMovement.instance.DisableInput();

        // 1. Переключаем камеру на босса
        if (bossCam != null)
        {
            // Ставим приоритет выше, чем у камеры игрока (например, 20)
            bossCam.Priority = 20; 
        }

        // Запоминаем начальные и конечные позиции стоек
        Vector3[] startPositions = new Vector3[pillars.Length];
        Vector3[] targetPositions = new Vector3[pillars.Length];
        
        for (int i = 0; i < pillars.Length; i++)
        {
            startPositions[i] = pillars[i].position;
            targetPositions[i] = pillars[i].position + Vector3.up * raiseDistance;
        }

        // 2. Плавно поднимаем стойки
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * raiseSpeed;
            for (int i = 0; i < pillars.Length; i++)
            {
                // Lerp плавно перемещает объект из точки А в точку Б
                pillars[i].position = Vector3.Lerp(startPositions[i], targetPositions[i], t);
            }
            yield return null; // Ждем следующий кадр
        }

        // 3. Даем игроку время осознать, что пути назад нет
        yield return new WaitForSeconds(cameraFocusTime);

        // 4. Возвращаем камеру обратно игроку
        if (bossCam != null)
        {
            bossCam.Priority = 0; // Сбрасываем приоритет
        }

        // [Опционально] Возвращаем управление игроком и запускаем ИИ босса
        // PlayerMovement.instance.EnableInput();
        // BossLogic.instance.StartFight();
    }
}