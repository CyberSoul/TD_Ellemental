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
    [SerializeField] GameObject m_groundPrefab;
    [SerializeField] bool m_isGroundScale = true;

    List<GameObject> m_grounds = new List<GameObject>();

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


    private void RemoveGrounds()
    {
        foreach (var ground in m_grounds)
        {
            Destroy(ground);
        }
        m_grounds.Clear();
    }

    private void LoadMap(Texture2D a_map)
    {
        RemoveGrounds();
        float offsetY = 0;
        GameObject groundTile;
        if (m_groundPrefab)
        {
            groundTile = Instantiate(m_groundPrefab, Vector3.zero, Quaternion.identity, transform);
            var renderer = groundTile.GetComponent<Renderer>();
            if (renderer)
            {
                offsetY = renderer.bounds.max.y;
                if (m_isGroundScale)
                {
                    float scaleX = a_map.width / renderer.bounds.size.x;
                    float scaleZ = a_map.height / renderer.bounds.size.z;
                    groundTile.transform.localScale = new Vector3(scaleX, 1, scaleZ);
                    groundTile.transform.position = new Vector3(renderer.bounds.size.x/2, 0, renderer.bounds.size.z / 2);
                    m_grounds.Add(groundTile);
                    Debug.Log($"ScaleX = {scaleX}; ScaleZ = {scaleZ}");
                }
                else
                {
                    int amountX = Mathf.RoundToInt(a_map.width / renderer.bounds.size.x );
                    int amountZ = Mathf.RoundToInt( a_map.height / renderer.bounds.size.z );

                    float scaleX = a_map.width / amountX / renderer.bounds.size.x;
                    float scaleZ = a_map.height / amountZ / renderer.bounds.size.z;

                    Debug.Log($"amountX = {amountX};\t amountZ = {amountZ};\t ScaleX = {scaleX};\t ScaleZ = {scaleZ}");

                    float[] scales = { scaleX, scaleZ };
                    float sumAmountRound = float.MaxValue;
                    float resultScale = 1;
                    foreach ( float scale in scales )
                    {
                        float amountfX = a_map.width / renderer.bounds.size.x / scale;
                        float amountfZ = a_map.height / renderer.bounds.size.z / scale;

                        float roundSum = Mathf.Abs(amountfX - Mathf.Round(amountfX)) + Mathf.Abs(amountfZ - Mathf.Round(amountfZ));
                        if (roundSum < sumAmountRound)
                        {
                            sumAmountRound = roundSum;
                            resultScale = scale;
                        }
                    }

                    amountX = Mathf.RoundToInt(a_map.width / renderer.bounds.size.x / resultScale);
                    amountZ = Mathf.RoundToInt(a_map.height / renderer.bounds.size.z / resultScale);

                    scaleX = a_map.width / amountX / renderer.bounds.size.x;
                    scaleZ = a_map.height / amountZ / renderer.bounds.size.z;

                    Debug.Log($"PART2: amountX = {amountX};\t amountZ = {amountZ};\t ScaleX = {scaleX};\t ScaleZ = {scaleZ}");

                    groundTile.transform.localScale = new Vector3(scaleX, 1, scaleZ);

                    float stepX = scaleX * renderer.bounds.size.x;
                    float stepZ = scaleZ * renderer.bounds.size.z;

                    Destroy(groundTile);
                    //groundTile.transform.position = new Vector3(stepX/2, 0, stepZ / 2);
                    //m_grounds.Add(groundTile);

                    for ( float x = stepX / 2; x < a_map.width; x+= stepX)
                    {
                        for (float z = stepZ/2; z < a_map.height; z += stepZ)
                        {
                            Vector3 position = new Vector3(x, 0, z);
                            groundTile = Instantiate(m_groundPrefab, position, Quaternion.identity, transform);
                            groundTile.transform.localScale = new Vector3(scaleX, 1, scaleZ);
                            m_grounds.Add(groundTile);
                        }
                    }
                }
            }

        }


        for (int i = 0; i < a_map.width; ++i)
        {
            for (int j = 0; j < a_map.height; ++j)
            {
                Color testColor = a_map.GetPixel(i, j);
                Vector3 position = new Vector3(i, offsetY, j);
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