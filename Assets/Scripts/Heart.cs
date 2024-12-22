using UnityEngine;

public class Heart : MonoBehaviour
{
    public Sprite onHeart;
    public Sprite offHeart;
    public SpriteRenderer renderer;
    public int lifeNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Life >= lifeNum)
        {
            renderer.sprite = onHeart;
        }
        else
        {
            renderer.sprite = offHeart;
        }
    }
}
