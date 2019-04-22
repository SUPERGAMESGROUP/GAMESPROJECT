using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneController : MonoBehaviour {

    public const int gridRows = 2;//значения, количество ячеей в сетки и их расстояние друг от друга
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    [SerializeField] private MemoryCard originalCard;//ссылка для карты в сцене
    [SerializeField] private Sprite[] images;//массив ссылок на ресурсы-спрайты

    void Start()
    {
        Vector3 startPos = originalCard.transform.position;//Положение первой карты, остальные от этой точки

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            { // вложенные циклы, задающие как столбцы, так и строки
                MemoryCard card; // Ссылка на контейнер для исходной карты или ее копий.
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }
                int id = Random.Range(0,images.Length); // Получаем идентификаторы из перемешанного 
                card.SetCard(id, images[id]);//вызов открытого метода в MemoryCard
                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);//в 2d смещаемся только по x  и y
            }
        }
    }
}
