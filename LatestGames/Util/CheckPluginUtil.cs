using System;
using System.Reflection;

namespace LatestGames.Util
{
    public static class CheckPluginUtil
    {
        public static bool IsAssemblyOfVersionAvailable(string name, Version ver)
        {
            bool result = false;
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly a in assemblies)
            {
                try
                {
                    if (a.GetName().Name == name && a.GetName().Version == ver)
                    {
                        result = true;
                        break;
                    }
                } catch { }
            }
            if (!result)
            {
                try
                {
                    Assembly assembly = Assembly.ReflectionOnlyLoad(name);
                    result = true;
                }
                catch { }
            }
            return result;
        }

        public static bool IsPluginEnabled(string name)
        {
            using (MediaPortal.Profile.Settings xmlreader = new MediaPortal.Profile.MPSettings())
            {
                return xmlreader.GetValueAsBool("plugins", name, false);
            }
        }

    }
}
