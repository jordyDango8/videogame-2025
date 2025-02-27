using UnityEngine;
using System;

public class EnumManager : MonoBehaviour
{
    public static EnumManager enumManager;

    public enum Tags
    {
        Player,
        Planet,
        Cloud,
        Boss,
        Tower,
        AllyMinion,
        EnemyMinion,
        DeadZone,
    }

    public enum Audio
    {
        level1EndlessRunner,
        playerJump,
        starCollect,
        unstitch,
        level1TowerDefenseOpening,
        level1TowerDefenseLoop,
        loseBossFight,
        loseEndless,
        winBossFight,
        winEndless,
        rescue,
    }

    public enum floatType
    {
        volume,
    }

    public enum Scenes
    {
        EndlessRunnerLevel1,
        TowerDefenseLevel1,
    }

    public enum AnimalsNames
    {
        Fox,
        OrangeCat,
        WhiteCat,
    }

    public enum Animations
    {
        orangeCatBeRescued,
        whiteCatBeRescued,
    }

    public enum BossActions
    {
        move,
        attack,
        spawnMinions,
    }

    public enum enemyMinionStates
    {
        orbiting,
        attacking,
        dead,
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

    public T GetRandomEnumValue<T>() where T : Enum
    {
        Array values = Enum.GetValues(typeof(T));
        int randomIndex = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(randomIndex);
    }

}