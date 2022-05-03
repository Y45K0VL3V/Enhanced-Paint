﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using yakov.OOP.EnhancedPaint.Plugins.Interfaces;

namespace yakov.OOP.EnhancedPaint.Plugins
{
    public static class PluginLoader
    {
        static PluginLoader()
        {
            foreach (var pluginPath in LoadingPlugins.Paths)
            {
                SetPlugin(pluginPath);
            }
        }

        public static Dictionary<PluginType, List<IPlugin>> Plugins = new Dictionary<PluginType, List<IPlugin>>();

        public static void SetPlugin(string pluginPath)
        {
            Assembly plugin;
            PluginType pluginType = PluginType.Unknown;
            System.Type pluginClass = null;

            if (!File.Exists(pluginPath))
                return;
            
            plugin = Assembly.LoadFile(pluginPath);

            if (plugin != null)
            {
                foreach (System.Type currType in plugin.GetTypes())
                {
                    if (currType.IsAbstract) 
                        continue;

                    object[] attrs = currType.GetCustomAttributes(typeof(PluginAttribute), true);
                    if (attrs.Length > 0)
                    {
                        foreach (PluginAttribute attr in attrs)
                        {
                            pluginType = attr.Type;
                        }
                        pluginClass = currType;
                    
                        if (pluginType == PluginType.Unknown)
                        {
                            return;
                        }

                        IPlugin newPlugin = Activator.CreateInstance(pluginClass) as IPlugin;
                        try
                        {
                            Plugins[pluginType].Add(newPlugin);
                        }
                        catch (KeyNotFoundException)
                        {
                            Plugins.Add(pluginType, new List<IPlugin>() { newPlugin });
                        }
                        catch { }
                        
                        return;
                    }
                    return;
                }
            }
        }
    }
}