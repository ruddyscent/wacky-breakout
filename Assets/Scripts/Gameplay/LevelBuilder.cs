using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    // [SerializeField]
    // GameObject spriteBlock = null;
    [SerializeField]
    GameObject standardBlock = null;
    [SerializeField]
    GameObject bonusBlock = null;
    [SerializeField]
    GameObject speedupBlock = null;
    [SerializeField]
    GameObject freezerBlock = null;
    float width, height;
    const float horizontalGap = 0.05f;
    const float verticalGap = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmpBlock = Instantiate(standardBlock);
        width = 2 * tmpBlock.GetComponent<BoxCollider2D>().size.x;
        height = 0.5f * tmpBlock.GetComponent<BoxCollider2D>().size.y;
        Destroy(tmpBlock);

        for (int j = 0; j < 9; j++) 
        {
            float y = 0;
            y = j * (height + verticalGap);

            for (int i = 0; i < 4; i++)
            {
                float x = 0;
                x = (i + 0.5f) * (width + horizontalGap);
                PlaceBlock(new Vector2(x, y));
                PlaceBlock(new Vector2(-x, y));
            }
        } 
    }

    void PlaceBlock(Vector2 position)
    {
        float r = Random.Range(0f, 1f);
        if (r <= ConfigurationUtils.BonusBlockFrequency)
            Instantiate(bonusBlock, position, Quaternion.identity);
        else if (r <= ConfigurationUtils.BonusBlockFrequency + ConfigurationUtils.SpeedupBlockFrequency)
            Instantiate(speedupBlock, position, Quaternion.identity);
        else if (r <= ConfigurationUtils.BonusBlockFrequency + ConfigurationUtils.SpeedupBlockFrequency + ConfigurationUtils.FreezerBlockFrequency)
            Instantiate(freezerBlock, position, Quaternion.identity);
        else
            Instantiate(standardBlock, position, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }
}
