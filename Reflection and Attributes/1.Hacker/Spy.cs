using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string StealFieldInfo(string className, params string[] names)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(className);

        var fileds = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        var hacker = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        foreach (var fieldInfo in fileds.Where(x => names.Contains(x.Name)))
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(hacker)}");
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        var classType = Type.GetType(className);

        var instance = Activator.CreateInstance(classType, new object[] { });

        var fields = classType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic |
                                         BindingFlags.Instance);

        foreach (var fieldInfo in fields)
        {
            if (fieldInfo.IsPublic)
            {
                sb.AppendLine($"{fieldInfo.Name} must be private!");
            }
        }

        var getters = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var methodInfo in getters.Where(x => x.Name.StartsWith("get")))
        {
            if (methodInfo.IsPrivate)
            {
                sb.AppendLine($"{methodInfo.Name} have to be public!");
            }
        }

        var setters = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        foreach (var methodInfo in setters.Where(x => x.Name.StartsWith("set")))
        {
            if (methodInfo.IsPublic)
            {
                sb.AppendLine($"{methodInfo.Name} have to be private!");
            }
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();

        var classType = Type.GetType(className);

        var privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        var baseType = classType.BaseType;

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {baseType.Name}");

        foreach (var privateMethod in privateMethods)
        {
            sb.AppendLine(privateMethod.Name);
        }

        return sb.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();

        var classType = Type.GetType(className);

        var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        foreach (var methodInfo in methods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
        }

        foreach (var methodInfo in methods.Where(x => x.Name.StartsWith("set")))
        {
            var parameterType = methodInfo.GetParameters().First().ParameterType;

            sb.AppendLine($"{methodInfo.Name} will set field of {parameterType}");
        }

        return sb.ToString().TrimEnd();
    }
}

