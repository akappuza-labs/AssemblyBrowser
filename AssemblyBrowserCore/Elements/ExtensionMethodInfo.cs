﻿using System.Collections.ObjectModel;
using System.Text;

namespace AssemblyBrowserCore.Elements;

public class ExtensionMethodInfo : IElementInfo
{
    public string Name { get; }
    public ObservableCollection<IElementInfo> Elements { get; }
    
    public ExtensionMethodInfo(System.Reflection.MethodInfo methodInfo)
    {
        Name = GetMethodSignature(methodInfo);
        Elements = new ObservableCollection<IElementInfo>();
    }

    private static string GetMethodSignature(System.Reflection.MethodInfo methodInfo)
    {
        var signature = new StringBuilder();

        signature.Append($"EXTENSION METHOD: {methodInfo.ReturnParameter.ParameterType.Name} {methodInfo.Name}(");
        
        var methodParams = methodInfo.GetParameters();
        
        foreach (var methodParam in methodParams)
        {
            signature.Append($"{methodParam.ParameterType.Name}, ");
        }

        if (methodParams.Length > 0)
            signature.Remove(signature.Length - 2, 2);
            
        signature.Append(')');
        
        return signature.ToString();
    }
}