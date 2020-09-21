using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject spriteBlock = null;

    float width, height;
    const float horizontalGap = 0.05f;
    const float verticalGap = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmpBlock = Instantiate(spriteBlock);
        width = 2 * tmpBlock.GetComponent<BoxCollider2D>().size.x;
        height = 0.5f * tmpBlock.GetComponent<BoxCollider2D>().size.y;
        Destroy(tmpBlock);

        for (int j = 0; j < 9; j++) 
        {
            float y = 0;
            y = j * (height + verticalGap);

            for (int i = 0; i < 4; i++)
            {
                GameObject go;
                float x = 0;                
                
                x = (i + 0.5f) * (width + horizontalGap);
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
