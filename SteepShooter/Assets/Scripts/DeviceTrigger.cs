using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour
{
    public GameObject[] targets;//список целевых объектов, на которых будет реагировать триггер
    void OnTriggerEnter(Collider other)
    {//метод OnTriggerEnter() вызывается при попадании объекта в зону
        foreach (GameObject target in targets)
        {
            target.SendMessage("Activate");//передаем сообщение
        }
    }

    void OnTriggerExit(Collider other)
    {//метод OnTriggerExit() вызывается при выходе из зоны
        foreach (GameObject target in targets)
        {
            target.SendMessage("Deactivate");//передаем сообщение
        }

    }
}
