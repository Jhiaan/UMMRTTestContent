using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using UMMRTTestContent.Core.Extensions;
using UMMRTTestContent.Core.Utilities;

namespace UMMRTTestContent.Core.Blueprint.Extensions
{
    internal static class GenericExtensions
    {

        /// <remarks>Based on code from <see href="https://github.com/Vek17/TabletopTweaks-Core"/>TabletopTweaks-Core</remarks>
        public static BlueprintScriptableObject InsertComponent(this BlueprintScriptableObject obj, int index, BlueprintComponent component)
        {
            var components = obj.ComponentsArray.ToList();
            components.Insert(index, component);
            return obj.SetComponents(components.ToArray());
        }

        public static BlueprintScriptableObject AddComponent(this BlueprintScriptableObject obj, BlueprintComponent component)
        {
            return obj.SetComponents(obj.ComponentsArray.AppendToArray(component));
        }

        public static BlueprintScriptableObject AddComponent<T>(this BlueprintScriptableObject obj, Action<T> init = null) where T : BlueprintComponent, new()
        {
            return obj.SetComponents(obj.ComponentsArray.AppendToArray(Helpers.Create(init)));
        }

        public static BlueprintScriptableObject AddComponents(this BlueprintScriptableObject obj, IEnumerable<BlueprintComponent> components) => obj.AddComponents(components.ToArray());
        
        public static BlueprintScriptableObject AddComponents(this BlueprintScriptableObject obj, params BlueprintComponent[] components)
        {
            var c = obj.ComponentsArray.ToList();
            c.AddRange(components);
            return obj.SetComponents(c.ToArray());
        }
        
        public static BlueprintScriptableObject RemoveComponent(this BlueprintScriptableObject obj, BlueprintComponent component)
        {
            return obj.SetComponents(obj.ComponentsArray.RemoveFromArray(component));
        }
        
        public static BlueprintScriptableObject RemoveComponents<T>(this BlueprintScriptableObject obj) where T : BlueprintComponent
        {
            var compnents_to_remove = obj.GetComponents<T>().ToArray();
            foreach (var c in compnents_to_remove)
            {
                obj.SetComponents(obj.ComponentsArray.RemoveFromArray(c));
            }
            return obj;
        }
        
        public static BlueprintScriptableObject RemoveComponents<T>(this BlueprintScriptableObject obj, Predicate<T> predicate) where T : BlueprintComponent
        {
            var compnents_to_remove = obj.GetComponents<T>().ToArray();
            foreach (var c in compnents_to_remove)
            {
                if (predicate(c))
                {
                    obj.SetComponents(obj.ComponentsArray.RemoveFromArray(c));
                }
            }
            return obj;
        }
        public static BlueprintScriptableObject RemoveAllComponents(this BlueprintScriptableObject obj)
        {
            obj.SetComponents();

            return obj;
        }

        public static IEnumerable<T> GetComponents<T>(this BlueprintScriptableObject obj, Predicate<T> predicate) where T : BlueprintComponent
        {
            return obj.GetComponents<T>().Where(c => predicate(c)).ToArray();
        }
        
        public static BlueprintScriptableObject ReplaceComponents(this BlueprintScriptableObject blueprint, Predicate<BlueprintComponent> predicate, BlueprintComponent newComponent)
        {
            bool found = false;
            foreach (var component in blueprint.ComponentsArray)
            {
                if (predicate(component))
                {
                    blueprint.RemoveComponent(component);
                    found = true;
                }
            }
            if (found)
            {
                blueprint.AddComponent(newComponent);
            }
            return blueprint;
        }
        
        public static BlueprintScriptableObject ReplaceComponents<T>(this BlueprintScriptableObject blueprint, BlueprintComponent newComponent) where T : BlueprintComponent
        {
            return blueprint.ReplaceComponents<T>(c => true, newComponent);
        }
        
        public static BlueprintScriptableObject ReplaceComponents<T>(this BlueprintScriptableObject blueprint, Predicate<T> predicate, BlueprintComponent newComponent) where T : BlueprintComponent
        {
            var components = blueprint.GetComponents<T>().ToArray();
            bool found = false;
            foreach (var component in components)
            {
                if (predicate(component))
                {
                    blueprint.RemoveComponent(component);
                    found = true;
                }
            }
            if (found)
            {
                blueprint.AddComponent(newComponent);
            }
            return blueprint;
        }
       
        public static BlueprintScriptableObject SetComponents(this BlueprintScriptableObject obj, params BlueprintComponent[] components)
        {
            // Fix names of components. Generally this doesn't matter, but if they have serialization state,
            // then their name needs to be unique.
            var names = new HashSet<string>();
            foreach (var c in components)
            {
                if (string.IsNullOrEmpty(c.name))
                {
                    c.name = $"${c.GetType().Name}";
                    //c.name = $"${c.GetType().Name}${Guid.NewGuid()}";
                }
                if (!names.Add(c.name))
                {
                    string name;
                    for (int i = 0; !names.Add(name = $"{c.name}${i}"); i++) ;
                    c.name = name;
                }
            }
            obj.ComponentsArray = components;
            obj.OnEnable(); // To make sure components are fully initialized
            return obj;
        }
        
        public static BlueprintScriptableObject SetComponents(this BlueprintScriptableObject obj, IEnumerable<BlueprintComponent> components)
        {
            return obj.SetComponents(components.ToArray());
        }

        public static BlueprintScriptableObject Configure(this BlueprintScriptableObject obj)
        {
            obj.OnEnable();
            return obj;
        }
    }
}
