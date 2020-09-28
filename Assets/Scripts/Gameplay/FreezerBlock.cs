using UnityEngine;
using UnityEngine.Events;

public class FreezerBlock : StandardBlock
{
    float duration;
    FreezerEffectActivated freezerEvent = new FreezerEffectActivated();

    // Start is called before the first frame update
    protected override void  Start()
    {
        duration = ConfigurationUtils.FreezeDuration;
        EventManager.AddFreezerInvoker(this);
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        Effect();
        base.OnCollisionEnter2D(collision);
    }

    public void AddFreezerEffectListener(UnityAction<float> listener) {
        freezerEvent.AddListener(listener);
    }

    protected override void Effect() {
        freezerEvent.Invoke(duration);
    }
}
