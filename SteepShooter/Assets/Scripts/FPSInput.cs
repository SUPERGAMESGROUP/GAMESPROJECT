using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {
   
    public float speed = 0.25f; // скорость движения персонажа
	
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed; // зайди в Unity: Edit->Project Settings->Input ; в Inspector появится вкладка, где можно понять откуда я брал обозначения "Horizontal", "Vertical", "Mouse X","Mouse Y".
        float deltaZ = Input.GetAxis("Vertical") * speed;
        transform.Translate(deltaX, 0, deltaZ); // Translate - метод для перемещения персонажа. В данном случае в плоскости X0Z.
	}
}
