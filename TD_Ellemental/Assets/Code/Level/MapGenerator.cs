using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    //public bool m_isGenerate;
    [SerializeField] MapGeneratorItem[] m_items;
    [SerializeField] Texture2D m_testMap;
    [SerializeField] NavMeshSurface m_surface;
    [SerializeField] GameObject m_fillPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (StaticDataHandler.LoadedLevel)
        {
            LoadMap(StaticDataHandler.LoadedLevel);
        }
        else
        {
            LoadMap(m_testMap);
        }
        m_surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateMap()
    {
        LoadMap(m_testMap);
        m_surface.BuildNavMesh();
    }


    private void LoadMap(Texture2D a_map)
    {
        for (int i = 0; i < a_map.width; ++i)
        {
            for (int j = 0; j < a_map.height; ++j)
            {
                Color testColor = a_map.GetPixel(i, j);
                Vector3 position = new Vector3(i, 0, j);
                var fillTile = Instantiate(m_fillPrefab, position, Quaternion.identity, transform);
                var renderer = fillTile.GetComponent<Renderer>();
                if ( renderer )
                {
                    position.y = renderer.bounds.max.y;
                }
                LoadMapTile(i, j, a_map.GetPixel(i, j), position);
            }
        }
    }

    private void LoadMapTile(int a_posX, int a_posZ, Color a_color, Vector3 a_position)
    {
        for (int i = 0; i < m_items.Length; ++i)
        {
            if (m_items[i].Color.Equals(a_color))
            {
                var mapTile = Instantiate(m_items[i].Prefab, a_position, Quaternion.identity, transform);
                var renderer = mapTile.GetComponent<Renderer>();
                if (renderer)
                {
                    a_position.y += a_position.y - renderer.bounds.min.y;
                    mapTile.transform.position = a_position;
                }
                break;
            }
        }
    }

    private void SaveMap()
    {

    }
}