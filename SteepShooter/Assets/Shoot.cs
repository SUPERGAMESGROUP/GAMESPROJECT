using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Camera _camera; //Экземпляр класса тип Camera
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();//Доступ к компонентам
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { //реакция на нажатие кнопки мыши
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0); //середина экрана, половина ширины и высоты
            Ray ray = _camera.ScreenPointToRay(point);//Создание луча методом.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {//луч заполняет информацией переменную
                Debug.Log("Hit " + hit.point);//загружаем координаты точки, в которую луч попал
            }
        }
    }
}
