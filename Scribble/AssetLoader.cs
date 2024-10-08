﻿using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace Scribble
{
    public class AssetLoader : IDisposable
    {
        private AssetBundle _assetBundle;

        public bool Load()
        {
            Stream stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("Scribble.Resources.scribbleassets");
            if (stream == null)
            {
                Debug.LogError("Couldn't load AssetBundle from Stream");
                return false;
            }
            _assetBundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return true;
        }

        public T LoadAsset<T>(string name) where T : UnityEngine.Object
        {
            LoadIfNotLoaded();
            return _assetBundle.LoadAsset<T>(name);
        }

        public void Dispose()
        {
            if (_assetBundle)
            {
                _assetBundle.Unload(true);
            }
        }
        
        private void LoadIfNotLoaded()
        {
            if (!_assetBundle)
            {
                Load();
            }
        }
    }
}
