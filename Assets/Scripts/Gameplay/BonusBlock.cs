using UnityEngine;

public class BonusBlock : Block
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        points = ConfigurationUtils.BonusBlockPoint;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
