
using UnityEngine;
using UnityEngine.UI;

public static class AddExtenshions
{
    public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
    {
        var component = gameObject.GetOrAddComponent<Image>();
        component.sprite = sprite;
        return gameObject;
    }
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        if (gameObject.GetComponent<T>() == null) gameObject.AddComponent<T>();
        return gameObject.GetComponent<T>();
    }

    public static GameObject AddCircleCollider2D(this GameObject gameObject)
    {
        var component = gameObject.GetOrAddComponent<CircleCollider2D>();
        return gameObject;
    }
    public static GameObject AddTrailRenderer(this GameObject gameObject)
    {
        var component = gameObject.GetOrAddComponent<TrailRenderer>();
        return gameObject;
    }
    public static GameObject AddRigitBody2D(this GameObject gameObject)
    {
        var component = gameObject.GetOrAddComponent<Rigidbody2D>();
        return gameObject;
    }
    public static GameObject AddBoxCollidery2D(this GameObject gameObject)
    {
        var component = gameObject.GetOrAddComponent<BoxCollider2D>();
        return gameObject;
    }

}


