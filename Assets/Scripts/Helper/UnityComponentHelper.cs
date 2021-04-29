using UnityEngine;

public static class UnityComponentHelper
{
    public static T GetComponentInParents<T>(Transform child) where T : class
    {
        if (child.parent == null)
            return null;

        T component = child.parent.GetComponent<T>();

        if (component != null)
            return component;

        return GetComponentInParents<T>(child.parent);
    }
}
