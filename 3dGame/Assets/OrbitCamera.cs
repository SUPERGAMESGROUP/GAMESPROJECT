using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target; //Переменная хранит ссылку на объект, вокруг производиться облет
    public float rotSpeed = 1.5f;
    private float _rotY;
    private Vector3 _offset;
    public Vector3 loockPoint;//переменная которая будет хранить добавлние к высоте
    private Vector3 targetLoock;//будет точкой для слежения

    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position; //сохранние начального смещения между камерой и целью

    }
    private void LateUpdate()
    {
        targetLoock = target.position + loockPoint;//установка значения вектора для точки слежения 

        float horInput = Input.GetAxis("Horizontal");
        if (horInput != 0)//медленный поворот камеры при помощи клавиш со стрелками
        {
            _rotY += horInput * rotSpeed;
        }
        else
        {
            _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;//или быстрый поворот с помощью мыши
        }
        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = targetLoock - (rotation * _offset);//поддерживаем начальное, сдвигаемое в соответствии с поворотом камеры.

        transform.LookAt(targetLoock); //камера всегда направлена на цель, где бы относительно этой цели она ни располагалась
    }
}
