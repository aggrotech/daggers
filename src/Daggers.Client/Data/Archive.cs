using System;
using System.Collections.Generic;

namespace Daggers.Client.Data
{
    static class Archive
    {
        static Archive()
        {
            loaders = new Dictionary<Type, IArchiveLoader<IAsset>>();
            cache = new Dictionary<string, IAsset>();
        }

        public static void RegisterLoader<T>(IArchiveLoader<T> loader) where T : IAsset
        {
            loaders[typeof(T)] = (IArchiveLoader<IAsset>)loader;
        }

        public static T Get<T>(string filepath) where T : IAsset
        {
            if (!cache.ContainsKey(filepath))
            {
                cache[filepath] = loaders[typeof (T)].Load(filepath);
            }

            return (T) cache[filepath];
        }

        private static readonly Dictionary<Type, IArchiveLoader<IAsset>> loaders;
        private static readonly Dictionary<string, IAsset> cache;
    }
}
