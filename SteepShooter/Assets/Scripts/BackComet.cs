using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackComet : MonoBehaviour
{

    public float speed = 1.0f;//переменная хранит скорость объекта
    public float maxZ = 16.0f;//точки между которыми будет двигаться объект
    public float minZ = -16.0f;
    private int _direction = 1; //хранит в каком направлении движеться объект в данный момент

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, _direction * speed * Time.deltaTime);
        bool bounced = false;//переменная может хранить только false или true
        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            _direction = -_direction;//меняем на противоположное
            bounced = true;
        }
        if (bounced == true)
        {//делаем дополнительное движение в кадре, если объект поменял направление
            transform.Translate(0, 0, _direction * speed * Time.deltaTime);
        }

    }
}
