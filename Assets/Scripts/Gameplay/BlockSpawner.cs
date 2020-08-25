using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject spriteBlock;

    float width, height;
    const float horizontalGap = 0.5f;
    const float verticalGap = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmpBlock = Instantiate(spriteBlock);
        width = 2 * tmpBlock.GetComponent<BoxCollider2D>().size.x;
        height = tmpBlock.GetComponent<BoxCollider2D>().size.y;
        Destroy(tmpBlock);

        float x = 0;
        float y = verticalGap;
        for (int i = 0; i < 4; i++)
        {
            GameObject go;
            x = i * width + horizontalGap;
            if (i == 0)
            {
                go = Instantiate(spriteBlock, new Vector2(x, y), Quaternion.identity);
                go.GetComponent<Renderer>().material.color = Random.ColorHSV();
            }
            else
            {
                go = Instantiate(spriteBlock, new Vector2(x, y), Quaternion.identity);
                go.GetComponent<Renderer>().material.color = Random.ColorHSV();
                go = Instantiate(spriteBlock, new Vector2(-x, y), Quaternion.identity);
                go.GetComponent<Renderer>().material.color = Random.ColorHSV();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
