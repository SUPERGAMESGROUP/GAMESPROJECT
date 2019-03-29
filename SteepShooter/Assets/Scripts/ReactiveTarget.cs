using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour //скрипт для смерти врага
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToHit()
    {//метод, вызванный сценарием стрельбы
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {//проверяем, есть ли сценарий WanderingAI
            behavior.SetAlive(false);//вызываем метод SetAlive и меняем жизнь врага на false
        }
        StartCoroutine(Die());//вызываем сопрограмму смерти врага

    }

    private IEnumerator Die()
    {//Опрокидываем врага, ждем 1,5 секунды и уничтожаем его
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);//уничтожаем объект, на который применен этот скрипт
    }

}
