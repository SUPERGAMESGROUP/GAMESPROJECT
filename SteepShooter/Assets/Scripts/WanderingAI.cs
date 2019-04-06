using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour //скрипт для искусственного интеллекта врага
{
    public float speed = 3.0f;//значение скорости движения врага
    public float obstacleRange = 5.0f;
    private bool _alive;//булевая переменная для слежения за жизнью врага

    public GameObject fireballPrefab;//будем хранить префаб
    private GameObject _fireball;

    // Use this for initialization
    void Start()
    {
        _alive = true; //делаем ее в начале истинной
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {//если враг жив то:
            transform.Translate(0, 0, speed * Time.deltaTime);//непрерывно движемся вперед в каждом кадре
            Ray ray = new Ray(transform.position, transform.forward);//луч в том же положении и направлении, что и враг
            RaycastHit hit;//переменная для получения информации с луча
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {//бросаем луч с описанной окружностью
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {//распознаем игрока, так же как и мишень RayShooter
                    if (_fireball == null)
                    { //пустой игровой объект
                        _fireball = Instantiate(fireballPrefab) as GameObject;//тот же метод как в SceneController
                        //поместим огненый шар перед врагом и нацелим в направлении его движения
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }else if (hit.distance < obstacleRange)
                {//если нашли препятствие
                    float angle = Random.Range(-110, 110);//Поворот с наполовину случайным значение от -110 до 110 грудусов
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {//открывает метод,который из вне позволяет воздействовать на переменную (менять жизнь)
        _alive = alive;
    }

}
