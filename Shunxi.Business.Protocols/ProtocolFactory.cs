﻿using Shunxi.Business.Protocols.Enums;
using System.Reflection;
using System;

namespace Shunxi.Business.Protocols
{
    public class ProtocolFactory
    {

        public static IProtocol Create(ProtocolVersion version)
        {
            VersionListAttribute attrList = typeof(IProtocol).GetTypeInfo().GetCustomAttribute<VersionListAttribute>();
            foreach (var t in attrList.VersionTypeList)
            {
                VersionAttribute verAttr = t.GetTypeInfo().GetCustomAttribute<VersionAttribute>();
                if (verAttr.Version == version)
                {
                    // || ==> Assembly.GetExecutingAssembly(),Assembly.CreateInstance
                    // || ==> Attribute.GetCustomAttribute uwp下统统不支持了。。。
                    // || ==> Activator.CreateInstance(t.GetType()) as IProtocol; 这样居然说uwp平台不支持，也是醉了
                    // || ==> 呵呵，下面倒是支持
                    // || ==> Activator.CreateInstance(Type.GetType(t.GetTypeInfo().FullName)) as IProtocol;
                    
                    return Type.GetType(t.GetTypeInfo().FullName).GetConstructor(Type.EmptyTypes).Invoke(new object[0]) as IProtocol;
                }
            }

            return null;
        }

    }
}
