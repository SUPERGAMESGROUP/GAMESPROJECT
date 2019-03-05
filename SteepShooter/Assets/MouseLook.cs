using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivityHor = 9.0f; // переменная для скорости вращения


    public enum RotationAxes //Структура данных, сопоставление имен с параметрами
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY; //объявляем переменную

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {// Это поворот в горизонтальной плоскости
            transform.Rotate(0, sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {//Это поворот в вертикальной плоскости

        }
        else
        {//Это комбинированный поворот

        }
    }
}
