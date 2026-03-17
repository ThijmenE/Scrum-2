using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GridPlacement : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] tiles;
    public List<GameObject> UITiles;

    public int selectedTile = 0;

    public Transform tileGridUI;

    private void Start()
    {
        int i = 0;
        foreach (Tile tile in tiles)
        {
            GameObject UITile = new GameObject("UI Tile");
            UITile.transform.parent = tileGridUI;
            UITile.transform.localScale = new Vector3(1f, 1f, 1f);

            Image UIImage = UITile.AddComponent<Image>();
            UIImage.sprite = tile.sprite;

            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if (i == selectedTile)
            {
                tileColor.a = 1f;
            }

            UIImage.color = tileColor;
            UITiles.Add(UITile);

            i++;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedTile = 0;
            RenderUITiles();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedTile = 1;
            RenderUITiles();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedTile = 2;
            RenderUITiles();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedTile = 3;
            RenderUITiles();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedTile = 4;
            RenderUITiles();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectedTile = 5;
            RenderUITiles();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selectedTile = 6;
            RenderUITiles();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            selectedTile = 7;
            RenderUITiles();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            selectedTile = 8;
            RenderUITiles();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), tiles[selectedTile]);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), null);
        }
    }

    void RenderUITiles()
    {
        int i = 0;
        foreach (GameObject tile in UITiles)
        {
            Image UIImage = tile.GetComponent<Image>();
            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if (i == selectedTile)
            {
                tileColor.a = 1f;
            }

            UIImage.color = tileColor;

            i++;
        }
    }
}
