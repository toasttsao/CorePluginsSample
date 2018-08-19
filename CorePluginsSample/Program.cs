using System;
using System.IO;
using System.Linq;
using Abstractions;
using McMaster.NETCore.Plugins;

namespace CorePluginsSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var pluginsDirs = Directory.GetFiles(AppContext.BaseDirectory, "plugin.config", SearchOption.AllDirectories);
            string configPath = pluginsDirs.FirstOrDefault();
            //設定讀取DLL或是設定檔
            var loader = PluginLoader.CreateFromConfigFile(configPath, sharedTypes: new[]
                                                                  {
                                                                            typeof(Ijsonstr),
                                                                 });
            //從PluginLoader取出剛註冊的類別
            var type = loader.LoadDefaultAssembly()
                             .GetTypes()
                             .FirstOrDefault(w => typeof(Ijsonstr).IsAssignableFrom(w));

            var jsonObj = new { name = "Toast", address = "Taipei" };

            var dlls = (Ijsonstr)Activator.CreateInstance(type);

            string result = dlls.JsonToStr(jsonObj);

            Console.WriteLine($"Class Name:{type.Name}{Environment.NewLine}Response Json String :{result}");

            Console.ReadLine();
        }
    }
}