using UnityEngine;
using System;

public class EnumManager : MonoBehaviour
{
    internal static EnumManager enumManager;

    internal enum Tags
    {
        Player,
        Planet,
        Cloud,
        Boss,
        Tower,
        AllyMinion,
        EnemyMinion,
    }

    internal enum Audio
    {
        level1EndlessRunner,
        playerJump,
        starCollect,
        unstitch,
    }

    internal enum floatType
    {
        volume,
    }

    internal enum Scenes
    {
        EndlessRunnerLevel1,
        TowerDefenseLevel1,
    }

    internal enum AnimalsNames
    {
        Fox,
        OrangeCat,
        WhiteCat,
    }

    internal enum Animations
    {
        orangeCatBeRescued,
        whiteCatBeRescued,
    }

    internal enum BossActions
    {
        move,
        attack,
    }

    internal enum enemyMinionStates
    {
        orbiting,
        attacking,
    }

    void Awake()
    {
        if (enumManager == null)
        {
            enumManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //MyEnum randomEnumValue = GetRandomEnumValue<MyEnum>();
        //Debug.Log("Valor aleatorio: " + randomEnumValue);
    }

    internal T GetRandomEnumValue<T>() where T : Enum
    {
        Array values = Enum.GetValues(typeof(T));
        int randomIndex = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(randomIndex);
    }

}