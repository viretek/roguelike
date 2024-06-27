using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPrefab; // Префаб комнаты
    public GameObject firstRoomPrefab; // Префаб начальной комнаты
    public GameObject bossRoomPrefab; // Префаб комнаты босса
    public int maxRooms = 2; // Максимальное количество комнат
    private RoomController DoorData;
    private const int roomWidth = 105; // Ширина комнаты
    private const int roomHeight = 105; // Высота комнаты

    private GameObject[,] roomMatrix;

    void Start()
    {
        roomMatrix = new GameObject[100, 100];
        GenerateRooms();
    }

    void GenerateRooms()
    {
        // Создание начальной комнаты
        int startX = maxRooms / 2;
        int startY = maxRooms / 2;
        roomMatrix[startX, startY] = Instantiate(firstRoomPrefab, new Vector2(0, 0), Quaternion.identity);

        // Создание остальных комнат
        int currentX = startX;
        int currentY = startY;
        int createdRooms = 1;

        while (createdRooms < maxRooms)
        {
            int direction = Random.Range(0, 4);
            bool validPlacement = false;

            while (!validPlacement)
            {
                switch (direction)
                {
                    case 0: // Вверх
                        currentY += 1;
                        break;
                    case 1: // Вниз
                        currentY -= 1;
                        break;
                    case 2: // Влево
                        currentX -= 1;
                        break;
                    case 3: // Вправо
                        currentX += 1;
                        break;
                }

                // Проверка на границы и занятость места
                if (currentX >= 0 && currentX < maxRooms && currentY >= 0 && currentY < maxRooms && roomMatrix[currentX, currentY] == null)
                {
                    validPlacement = true;
                }
                else
                {
                    // Выбор нового направления, если текущее не подходит
                    direction = Random.Range(0, 4);
                }
            }

            // Создание комнаты
            roomMatrix[currentX, currentY] = Instantiate(roomPrefab, new Vector2((currentX - startX) * roomWidth, (currentY - startY) * roomHeight), Quaternion.identity);
            createdRooms++;
            int lastroomX = currentX;
            int lastroomY = currentY;
        }

        // Создание комнаты босса
        int bossX = currentX;
        int bossY = currentY;
        bool validPlacementBoss = false;
        while (!validPlacementBoss)
        {
            while (roomMatrix[bossX, bossY] != null)
            {
                int direction = Random.Range(0, 4);
                switch (direction)
                {
                    case 0: // Вверх
                        bossY += 1;
                        break;
                    case 1: // Вниз
                        bossY -= 1;
                        break;
                    case 2: // Влево
                        bossX -= 1;
                        break;
                    case 3: // Вправо
                        bossX += 1;
                        break;
                }
                if (currentX >= 0 && bossX < maxRooms && bossY >= 0 && bossY < maxRooms && roomMatrix[bossX, bossY] == null)
                {
                    validPlacementBoss = true;
                }

                else 
                {
                direction = Random.Range(0, 4);
                }
            }
        }
        roomMatrix[bossX, bossY] = Instantiate(bossRoomPrefab, new Vector2((bossX - startX) * roomWidth, (bossY - startY) * roomHeight), Quaternion.identity);

        bool LeftDoor = false;
        bool UpDoor = false;
        bool DownDoor = false;
        bool RightDoor = false;

        for (int i = 1; i <= 99; i++)
        {
            for (int j = 1; j <= 99; j++)
            {
                if (roomMatrix[i, j] != null)
                {
                    DoorData = roomMatrix[i, j].GetComponent<RoomController>();
                    if (roomMatrix[i+1, j] != null)
                    {
                        DoorData.RightDoor = true;
                    }
                    if (roomMatrix[i-1, j] != null)
                    {
                        DoorData.LeftDoor = true;
                    }
                    if (roomMatrix[i, j+1] != null)
                    {
                        DoorData.UpDoor = true;
                    }
                    if (roomMatrix[i, j-1] != null)
                    {
                        DoorData.DownDoor = true;
                    }
                }
            }
        }
    }
}