using System.Collections.Generic;
using UnityEngine;

public class FullClearArrowMaze : MonoBehaviour
{
    [Header("Dimensiuni Labirint")]
    public int width = 5;
    public int height = 5;
    public float spacing = 2.0f;

    [Header("Prefab")]
    public GameObject arrowPrefab;

    private int[,] gridDirections;
    private bool[,] visited;

    // Ordinea direcțiilor: 0=Sus, 1=Dreapta, 2=Jos, 3=Stânga
    private Vector2Int[] directions = new Vector2Int[]
    {
        new Vector2Int(0, 1),  // Sus
        new Vector2Int(1, 0),  // Dreapta
        new Vector2Int(0, -1), // Jos
        new Vector2Int(-1, 0)  // Stânga
    };

    void Start()
    {
        GenerateSolvableMaze();
    }

    void GenerateSolvableMaze()
    {
        gridDirections = new int[width, height];
        visited = new bool[width, height];

        // Alegem un punct de start (poți să îl faci random dacă vrei)
        Vector2Int startPos = new Vector2Int(0, 0);
        visited[startPos.x, startPos.y] = true;

        // Începem algoritmul de Backtracking
        if (FindHamiltonianPath(startPos, 1))
        {
            InstantiateMaze();
        }
        else
        {
            Debug.LogError("Nu s-a putut genera un drum care să acopere toată grila. Încearcă alte dimensiuni.");
        }
    }

    // Algoritm recursiv pentru a găsi un drum care trece prin TOATE celulele
    bool FindHamiltonianPath(Vector2Int current, int depth)
    {
        // Dacă am făcut un număr de pași egal cu numărul total de celule, am câștigat!
        if (depth == width * height)
            return true;

        // Creăm o listă cu cele 4 direcții posibile și o amestecăm
        // Asta face ca labirintul să fie diferit la fiecare rulare
        List<int> dirIndices = new List<int> { 0, 1, 2, 3 };
        Shuffle(dirIndices);

        foreach (int i in dirIndices)
        {
            Vector2Int nextPos = current + directions[i];

            // Verificăm dacă următoarea celulă este validă și nevizitată
            if (IsValid(nextPos))
            {
                visited[nextPos.x, nextPos.y] = true;
                gridDirections[current.x, current.y] = i; // Săgeata curentă va arăta spre nextPos

                // Mergem mai adânc
                if (FindHamiltonianPath(nextPos, depth + 1))
                    return true;

                // BACKTRACKING: Dacă drumul ales s-a blocat, anulăm vizita și încercăm altă direcție
                visited[nextPos.x, nextPos.y] = false;
            }
        }

        return false;
    }

    bool IsValid(Vector2Int pos)
    {
        // Ne asigurăm că nu ieșim din grilă și că nu am mai fost deja pe această celulă
        return pos.x >= 0 && pos.x < width &&
               pos.y >= 0 && pos.y < height &&
               !visited[pos.x, pos.y];
    }

    void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void InstantiateMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x * spacing, 0, y * spacing);
                int dir = gridDirections[x, y];

                // Rotim săgeata pe axa Y în funcție de direcția salvată (0, 90, 180, 270)
                float yRotation = dir * 90f;
                Quaternion rotation = Quaternion.Euler(0, yRotation, 0);

                GameObject arrow = Instantiate(arrowPrefab, position, rotation, transform);
                arrow.name = $"Arrow [{x},{y}]";

                // Opțional: Ultima săgeată din drum nu are neapărat o direcție "corectă", 
                // fiind ieșirea, o poți colora diferit sau o poți elimina.
            }
        }
    }
}