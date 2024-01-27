using BepInEx;
using BepInEx.Configuration;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilla;

namespace CamRotFix
{
    [BepInDependency("org.legoandmars.gorillatag.utilla")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        Transform lookat,mainCameraTransform;

        ConfigEntry<bool> face;
        void Awake()
        {
            Events.GameInitialized += OnGameInitialized;
            face = Config.Bind("Settings", "Direction", false);
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            mainCameraTransform = Camera.main.transform;
            lookat = mainCameraTransform.Find("Camera Follower");
        }

        void Update()
        {
            lookat.localRotation = Quaternion.Euler(face.Value ? new Vector3(0, 180, 0) : Vector3.zero);
            if (Keyboard.current.slashKey.wasPressedThisFrame)
            {
                face.Value = !face.Value;
            }
        }
    }
}