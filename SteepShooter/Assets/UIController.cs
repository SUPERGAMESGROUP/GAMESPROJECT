using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//импорт инфраструктуры для работы с кодом UI

public class UIController : MonoBehaviour
{
   public Text scoreLabel;//объект сцены Reference Text, предназначенный для задания свойства Text

    void Update () {
        scoreLabel.text = Time.realtimeSinceStartup.ToString ();
    }
    public void OnOpenSettings(){//метод, вызываемый кнопкой настроек
        Debug.Log("open settings");
    }

}
