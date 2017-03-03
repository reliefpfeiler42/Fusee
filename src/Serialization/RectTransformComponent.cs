using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusee.Math.Core;
using ProtoBuf;

namespace Fusee.Serialization
{
    /// <summary>
    /// Transformation (position, orientation and size) of the node.
    /// </summary>
    [ProtoContract]
    public class RectTransformComponent : SceneComponentContainer
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(6)]
        public float AnchorMinX;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(6)]
        public float AnchorMaxX;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(6)]
        public float AnchorMinY;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(7)]
        public float AnchorMaxY;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(8)]
        public float Left;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(9)]
        public float Right;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(10)]
        public float Top;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(11)]
        public float Bottom;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(12)]
        public float PosZ;
    }
}
