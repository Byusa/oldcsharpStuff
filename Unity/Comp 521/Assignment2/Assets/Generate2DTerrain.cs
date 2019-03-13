using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class Generate2DTerrain : MonoBehaviour
{
    public GameObject block;
    public int height = 10;
    public int width = 40;
    public float scale = 5f;
    public float offset = 10;
    public float seed;

    private List<GameObject> blocks;

    // Use this for initialization
    void Start()
    {
        seed = Random.value * 100;
        blocks = new List<GameObject>();
        RandWorldGen();
    }

    void RandWorldGen()
    {
        for (int x = -width; x < width; x++)
        {
            float thisRand = Mathf.Floor((Mathf.PerlinNoise(x * scale * 0.01f + offset, seed) - 0.5f) * height * 2);
            //float thisRand = Mathf.Floor((Mathf.PerlinNoise(Random.value * x * 100, Random.value * x * 100) - 0.5f) * height * 2);

            blocks.Add(Instantiate(block, new Vector3(x, thisRand, 0), Quaternion.identity) as GameObject);

            for (float y = thisRand - 1; y >= -height; y--)
            {
                blocks.Add(Instantiate(block, new Vector3(x, y, 0), Quaternion.identity) as GameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject go in blocks)
            {
                Destroy(go);
            }
            blocks.Clear();

            RandWorldGen();
        }
    }

    void OnValidate()
    {
        if (!Application.isPlaying || blocks == null) return;

        foreach (GameObject go in blocks)
        {
            Destroy(go);
        }
        blocks.Clear();

        RandWorldGen();
    }
}