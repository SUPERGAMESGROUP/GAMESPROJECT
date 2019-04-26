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
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 }; //объявляем параметры индентификторов 4-х спрайтов
        numbers = ShuffleArray(numbers); // Вызов функции, перемешивающей элементы массива.

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
                int index = j * gridCols + i;
                int id = numbers[index]; // Получаем идентификаторы из перемешанного списка, а не из случайных чисел.
                card.SetCard(id, images[id]);//вызов открытого метода в MemoryCard
                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);//в 2d смещаемся только по x  и y
            }
        }
    }
    private int[] ShuffleArray(int[] numbers)
    { // Реализация алгоритма тасования Кнута.
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

}
