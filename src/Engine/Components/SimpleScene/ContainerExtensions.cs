﻿using System;
using System.Collections.Generic;
using Fusee.Math;
using Fusee.Serialization;

namespace Fusee.Engine.SimpleScene
{
    static public class ContainerExtensions
    {
        public static float4x4 Matrix(this TransformComponent tcThis)
        {
            return float4x4.CreateTranslation(tcThis.Translation) * float4x4.CreateRotationY(tcThis.Rotation.y) *
                   float4x4.CreateRotationX(tcThis.Rotation.x) * float4x4.CreateRotationZ(tcThis.Rotation.z) *
                   float4x4.CreateScale(tcThis.Scale);
        }

        public static SceneComponentContainer GetComponent(this SceneNodeContainer sncThis, Type type, int inx = 0)
        {
            if (sncThis == null || sncThis.Components == null || type == null)
                return null;

            foreach (var cont in sncThis.Components)
            {
                int inxC = 0;
                if (cont.GetType().IsAssignableFrom(type))
                {
                    if (inxC == inx)
                        return cont;
                    inxC++;
                }
            }
            return null;
        }

        public static SceneComponentContainer GetComponent<TComp>(this SceneNodeContainer sncThis, int inx = 0)
            where TComp : SceneComponentContainer
        {
            return GetComponent(sncThis, typeof (TComp), inx);
        }

        public static MeshComponent GetMesh(this SceneNodeContainer sncThis, int inx = 0)
        {
            return (MeshComponent) GetComponent<MeshComponent>(sncThis, inx);
        }

        public static MaterialComponent GetMaterial(this SceneNodeContainer sncThis, int inx = 0)
        {
            return (MaterialComponent)GetComponent<MaterialComponent>(sncThis, inx);
        }

        public static LightComponent GetLight(this SceneNodeContainer sncThis, int inx = 0)
        {
            return (LightComponent)GetComponent<LightComponent>(sncThis, inx);
        }

        public static void AddComponent(this SceneNodeContainer sncThis, SceneComponentContainer scc)
        {
            if (scc == null || sncThis == null)
                return;

            if (sncThis.Components == null)
            {
                sncThis.Components = new List<SceneComponentContainer>();
            }
            sncThis.Components.Add(scc);
        }
    }
}
