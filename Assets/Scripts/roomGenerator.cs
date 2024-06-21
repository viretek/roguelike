using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPrefab; // Префаб комнаты
    public int numRows = 20; // Количество рядов комнат
    public int numCols = 20; // Количество столбцов комнат
    public float roomWidth = 105f; // Ширина комнаты
    public float roomHeight = 105f; // Высота комнаты
    public int id = 0;
    private GameObject[,] roomMatrix; // Двумерный массив для хранения комнат
    private GameObject newRoom;

    void Start()
    {
        Debug.Log("Initializing room matrix...");
        InitializeRoomMatrix();
        Debug.Log("Generating rooms...");
        GenerateRooms();
        Debug.Log("Rooms generated successfully.");
    }

    void InitializeRoomMatrix()
    {
        roomMatrix = new GameObject[numRows, numCols];
        int centerX = numCols / 2;
        int centerY = numRows / 2;

        // Размещаем начальную комнату в центре
        roomMatrix[centerX, centerY] = Instantiate(roomPrefab, new Vector2(0, 0), Quaternion.identity);
    }

    void GenerateRooms()
    {
        int centerX = numCols / 2;
        int centerY = numRows / 2;
        int currentX = centerX;
        int currentY = centerY;

        for (int step = 0; step < 8; step++)
        {
            // Выбираем случайное направление
            int direction = Random.Range(0, 4);

            switch (direction)
            {
                case 0: // Вверх
                    currentY = Mathf.Clamp(currentY + 1, 0, numRows - 1);
                    break;
                case 1: // Вниз
                    currentY = Mathf.Clamp(currentY - 1, 0, numRows - 1);
                    break;
                case 2: // Влево
                    currentX = Mathf.Clamp(currentX - 1, 0, numCols - 1);
                    break;
                case 3: // Вправо
                    currentX = Mathf.Clamp(currentX + 1, 0, numCols - 1);
                    break;
            }

            // Размещаем комнату, если ячейка свободна
            if (roomMatrix[currentX, currentY] == null)
            {
                id += 1;
                newRoom = Instantiate(roomPrefab, new Vector2((currentX - centerX) * roomWidth, (currentY - centerY) * roomHeight), Quaternion.identity);
                roomMatrix[currentX, currentY] = newRoom;
                newRoom.tag = $"Room{id}";
            }
        }
    }
}
