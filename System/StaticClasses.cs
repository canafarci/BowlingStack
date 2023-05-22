using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class FindInterfaces
{
    public static List<T> Find<T>()
    {
        List<T> interfaces = new List<T>();
        GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var rootGameObject in rootGameObjects)
        {
            T[] childrenInterfaces = rootGameObject.GetComponentsInChildren<T>();
            foreach (var childInterface in childrenInterfaces)
            {
                interfaces.Add(childInterface);
            }
        }
        return interfaces;
    }
}


public static class AnimationManager
{
    public static float GetAnimationLength(string name, Animator animator)
    {
        for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            if (animator.runtimeAnimatorController.animationClips[i].name == name)
                return animator.runtimeAnimatorController.animationClips[i].length;
        }

        Debug.LogError("Animation clip: " + name + " not found");
        return 0;
    }
}
