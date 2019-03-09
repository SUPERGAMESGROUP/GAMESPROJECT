using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
       public enum RotationAxes // Обозначаем структуру данных
       {
           MouseXAndY = 0, //Элементы структуры
           MouseX = 1,
           MouseY = 2
       }

       public RotationAxes axes = RotationAxes.MouseXAndY; // Обозначаем переменную структуры (данная переменная будет отображаться в Inspector)
       public float sensitivityHor = 9.0f; // Переменная скорости по горизонтали
       public float sensitivityVert = 9.0f; // Переменная скорости по вертикали

       public float minimumVert = -45.0f; // Переменная, которая будет ограничивать вертикальный угол нашего героя (угол взгляда вниз)
       public float maximumVert = 45.0f; // Переменная, которая будет ограничивать вертикальный угол нашего героя (угол взгляда вверх)

       public float _rotationX = 0;//Закрытая переменная для сохраннеия угла поворота вертикали.


       void Update () {
           if(axes == RotationAxes.MouseX){ // если мы выберем MouseX в инспекторе

            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0); //Метод GetAxis - выдает нам число (1 или -1 в зависимости от направления движения), класс Input - обрабатывает сигнал с устройства ввода (в данном случае мышь), мы поворачиваемся вокруг оси Y в плоскости X.

           } else if(axes == RotationAxes.MouseY){ // если мы выберем MouseY в инспекторе

               _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert; // обрабатываем сигнал по вертикали и записываем полученное значение в _rotationX
               _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); // метод Clamp - позволяет сделать нам ограничение (шаг с которым мы движемся, минимальная граница, максимальная граница)
               float rotationY = transform.localEulerAngles.y; // в плоскости Y идет перемещение по Углам Эйлера - углы предназначены для изменения положения твердого тела (нашего героя) в пространстве
               transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); // создаем новый трехмерный вектор (новую позицию взгляда нашего героя)

           } else { // если мы выберем MouseXAndY в инспекторе
           
               _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert; //первые две строки, то же самое, что и выше
               _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
               float delta = Input.GetAxis("Mouse X") * sensitivityHor; //теперь для совместного поворота нам нужно двигать взглядом не только в плоскости Y , но и X. Величина дельта добавляет значение перемещение в плоскости X.
               float rotationY = transform.localEulerAngles.y + delta;// та же строка, что и выше, только прибавляется "+delta" - то есть помимо движения по вертикали мы можем и перемещаться по горизонтали на величину delta
               transform.localEulerAngles = new Vector3(_rotationX,rotationY,0); // создаем новый трехмерный вектор (новую позицию взгляда нашего героя)
            //если вы прочитали до конца, то напишите мне в личку "I know MouseLook" , чтобы я понимал, что вы посмотрели данный код:)
        }
    }
}
