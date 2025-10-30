using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuickRespawn;

[BepInPlugin("org.hlxii.plugin.quickrespawn", "Quick Respawn", "0.0.0")]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        Logger.LogInfo($"Quick Respawn: Plugin loaded");

        SceneManager.sceneLoaded += OnSceneLoaded;

        var harmony = new Harmony("org.hlxii.plugin.quickrespawn");
        harmony.PatchAll();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "PilgrimsRestScene")
        {
            Logger.LogInfo($"Quick Respawn: Loaded Pilgrims Rest scene");

            var player = GameObject.Find("Player");
            if (player != null)
            {
                Logger.LogInfo($"Quick Respawn: Player found, moving position");
                player.transform.position = new Vector3(-230, 740, 96);
            }
            else
            {
                Logger.LogWarning($"Could not find Player GameObject");
            }
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}