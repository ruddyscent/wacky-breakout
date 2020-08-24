using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject spriteBlock0, spriteBlock1, spriteBlock2, spriteBlock3;
    float width, height;
    const float horizontalGap = 0.1f, verticalGap = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmpBlock = Instantiate(spriteBlock0);
        width = tmpBlock.GetComponent<BoxCollider2D>().size.x;
        height = tmpBlock.GetComponent<BoxCollider2D>().size.y;
        Destroy(tmpBlock);

        float x = ScreenUtils.ScreenLeft + horizontalGap + width / 2;
        float y = 0;
        while (x < ScreenUtils.ScreenRight - horizontalGap)
        {
            int selection = Random.Range(0, 4);
            GameObject block;
            switch (selection)
            {
                case 0:
                    block = Instantiate(spriteBlock0, new Vector2(x, y), Quaternion.identity);
                    break;
                case 1:
                    block = Instantiate(spriteBlock1, new Vector2(x, y), Quaternion.identity);
                    break;
                case 2:
                    block = Instantiate(spriteBlock2, new Vector2(x, y), Quaternion.identity);
                    break;
                case 3:
                    block = Instantiate(spriteBlock3, new Vector2(x, y), Quaternion.identity);
                    break;
            }
            x += 2 * width + horizontalGap;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
