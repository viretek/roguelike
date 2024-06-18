using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public Vector2 floorSize = new Vector2(1, 1); // Размер одного блока пола
    public Vector2 wallSize = new Vector2(1, 1);  // Размер одного блока стены
    public int minRooms = 5;
    public int maxRooms = 10;

    private List<Vector2> roomPositions = new List<Vector2>();
    private List<Vector2> doorPositions = new List<Vector2>();

    void Start()
    {
        int roomCount = Random.Range(minRooms, maxRooms + 1);
        Vector2 firstRoomPosition = Vector2.zero;
        roomPositions.Add(firstRoomPosition);
        GenerateRoom(firstRoomPosition);

        for (int i = 1; i < roomCount; i++)
        {
            Vector2 newRoomPosition = GenerateAdjacentPosition();
            roomPositions.Add(newRoomPosition);
            GenerateRoom(newRoomPosition);
        }
    }

    Vector2 GenerateAdjacentPosition()
    {
        Vector2 lastRoomPosition = roomPositions[roomPositions.Count - 1];
        Vector2 roomSize = new Vector2(50 * floorSize.x, 50 * floorSize.y); // Увеличиваем размер комнаты

        List<Vector2> potentialPositions = new List<Vector2>
        {
            lastRoomPosition + new Vector2(roomSize.x, 0), // справа
            lastRoomPosition + new Vector2(-roomSize.x, 0), // слева
            lastRoomPosition + new Vector2(0, roomSize.y), // сверху
            lastRoomPosition + new Vector2(0, -roomSize.y) // снизу
        };

        potentialPositions.RemoveAll(pos => roomPositions.Contains(pos));
        return potentialPositions[Random.Range(0, potentialPositions.Count)];
    }

    void GenerateRoom(Vector2 roomPosition)
    {
        Vector2 roomDimensions = new Vector2(50, 50); // Увеличиваем размер комнаты в блоках
        
        // Создание пола
        for (int x = 0; x < roomDimensions.x; x++)
        {
            for (int y = 0; y < roomDimensions.y; y++)
            {
                Vector2 floorPosition = new Vector2(roomPosition.x + x * floorSize.x, roomPosition.y + y * floorSize.y);
                Instantiate(floorPrefab, floorPosition, Quaternion.identity);
            }
        }

        // Создание стен
        for (int x = 0; x < roomDimensions.x; x++)
        {
            Vector2 topWallPosition = new Vector2(roomPosition.x + x * floorSize.x, roomPosition.y + roomDimensions.y * floorSize.y);
            Vector2 bottomWallPosition = new Vector2(roomPosition.x + x * floorSize.x, roomPosition.y - wallSize.y);
            if (!doorPositions.Contains(topWallPosition))
                Instantiate(wallPrefab, topWallPosition, Quaternion.identity);
            if (!doorPositions.Contains(bottomWallPosition))
                Instantiate(wallPrefab, bottomWallPosition, Quaternion.identity);
        }

        for (int y = 0; y < roomDimensions.y; y++)
        {
            Vector2 leftWallPosition = new Vector2(roomPosition.x - wallSize.x, roomPosition.y + y * floorSize.y);
            Vector2 rightWallPosition = new Vector2(roomPosition.x + roomDimensions.x * floorSize.x, roomPosition.y + y * floorSize.y);
            if (!doorPositions.Contains(leftWallPosition))
                Instantiate(wallPrefab, leftWallPosition, Quaternion.identity);
            if (!doorPositions.Contains(rightWallPosition))
                Instantiate(wallPrefab, rightWallPosition, Quaternion.identity);
        }

        CreateDoor(roomPosition);
    }

    Vector2 GetRandomDoorPosition(Vector2 roomPosition)
    {
     Vector2 roomDimensions = new Vector2(50, 50);
     List<Vector2> possiblePositions = new List<Vector2>();

     for (int x = 1; x < roomDimensions.x - 1; x++)
     {
         possiblePositions.Add(new Vector2(roomPosition.x + x * floorSize.x, roomPosition.y));
            possiblePositions.Add(new Vector2(roomPosition.x + x * floorSize.x, roomPosition.y + (roomDimensions.y - 1) * floorSize.y));
        }

        for (int y = 1; y < roomDimensions.y - 1; y++)
        {
            possiblePositions.Add(new Vector2(roomPosition.x, roomPosition.y + y * floorSize.y));
            possiblePositions.Add(new Vector2(roomPosition.x + (roomDimensions.x - 1) * floorSize.x, roomPosition.y + y * floorSize.y));
        }

        return possiblePositions[Random.Range(0, possiblePositions.Count)];
    }

    void CreateDoor(Vector2 roomPosition)
    {
        if (roomPositions.Count > 1)
        {
            Vector2 doorPosition1 = GetRandomDoorPosition(roomPosition);
            Vector2 doorPosition2 = Vector2.zero;

            Vector2 previousRoomPosition = roomPositions[roomPositions.Count - 2];
            Vector2 direction = roomPosition - previousRoomPosition;

            if (direction.x > 0) // Новая комната справа от предыдущей
            {
                doorPosition2 = new Vector2(previousRoomPosition.x + 50 * floorSize.x, doorPosition1.y);
            }
            else if (direction.x < 0) // Новая комната слева от предыдущей
            {
                doorPosition2 = new Vector2(previousRoomPosition.x - 2 * floorSize.x, doorPosition1.y);
            }
            else if (direction.y > 0) // Новая комната выше предыдущей
            {
                doorPosition2 = new Vector2(doorPosition1.x, previousRoomPosition.y + 50 * floorSize.y);
            }
            else if (direction.y < 0) // Новая комната ниже предыдущей
            {
                doorPosition2 = new Vector2(doorPosition1.x, previousRoomPosition.y - 2 * floorSize.y);
            }

            // Создание дверей
            Instantiate(floorPrefab, doorPosition1, Quaternion.identity);
            Instantiate(floorPrefab, doorPosition1 + new Vector2(floorSize.x, 0), Quaternion.identity);
            Instantiate(floorPrefab, doorPosition1 + new Vector2(2 * floorSize.x, 0), Quaternion.identity);
            Instantiate(floorPrefab, doorPosition2, Quaternion.identity);
            doorPositions.Add(doorPosition1);
            doorPositions.Add(doorPosition2);
        }
    }
}