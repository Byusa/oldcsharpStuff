using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject dirtPrefab;
    public GameObject grassPrefab;

    int minX = -16;
    int maxX = 16;
    int minY = -10;
    int maxY = 10;

    PerlinNoise noise;

	// Use this for initialization
	void Start () {
        noise = new PerlinNoise(Random.Range(1000000,1000000));
        Regenerate();
	}
	
    private void Regenerate(){

        float width = dirtPrefab.transform.lossyScale.x; //width component of the scalling
        float height = dirtPrefab.transform.lossyScale.y;

        for (int i = minX; i < maxX; i++)
        {//x values
            int columnHeight = 2 + noise.getNoise(i - minX, maxY - minY - 2);
            print(columnHeight);
            for (int j = minY; j < minY + columnHeight; j++)
            {//y values
                GameObject block = (j == minY + columnHeight - 1) ? grassPrefab : dirtPrefab;
                //Instantiate(dirtPrefab, new Vector2(i * width, j * height), Quaternion.identity);
                Instantiate(dirtPrefab, new Vector2(i * width, j * height), Quaternion.identity);
            }
        }
    }
}
