using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject spriteBlock;

    float width, height;
    const float horizontalGap = 0.05f;
    const float verticalGap = 0.05f;

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
            
            if (i == 0)
            {
                go = Instantiate(spriteBlock, new Vector2(x, y), Quaternion.identity);
                go.GetComponent<Renderer>().material.color = Random.ColorHSV();
            }
            else
            {
                x = i * (width + horizontalGap);
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
