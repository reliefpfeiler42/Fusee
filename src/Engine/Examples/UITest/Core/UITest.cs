#define GUI_SIMPLE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;

namespace Fusee.Engine.Examples.UITest.Core
{

    [FuseeApplication(Name = "UI Test", Description = "Testing UI Elements")]
    public class UITest : RenderCanvas
    {
        // angle variables
        private static float _angleHorz = MathHelper.PiOver4, _angleVert, _angleVelHorz, _angleVelVert;

        private const float RotationSpeed = 7;
        private const float Damping = 0.8f;

        private Cube _canvasCube;
        private Cube _buttonCube;
        private Cube _textCube;

        private TransformComponent _canvasTC;
        private RectTransformComponent _canvasRtC;
        private MaterialComponent _canvasMatC;
        private MeshComponent _canvasMeshC;

        private TransformComponent _buttonTC;
        private RectTransformComponent _buttonRtC;
        private MaterialComponent _buttonMatC;
        private MeshComponent _buttonMeshC;

        private TransformComponent _textTC;
        private RectTransformComponent _textRtC;
        private MaterialComponent _textMatC;
        private MeshComponent _textMeshC;

        private SceneContainer _canvas;
        //private SceneNodeContainer _myCubeNodeContainer;
        private SceneRenderer _canvasRenderer;

        private bool _keys;
        
        // Init is called on startup. 
        public override void Init()
        {
            // Set the clear color for the backbuffer.
            RC.ClearColor = new float4(0.3f, 0.3f, 0.3f, 1);

            var scale = new float3(1, 1, 0.01f);
            var trans = new float3(0, 0, -0.5f);

            // TransformComponent Canvas
            _canvasTC = new TransformComponent
            {
                Scale = scale,
                Rotation = float3.Zero,
                Translation = float3.Zero
            };

            // RectTransformComponent Canvas
            _canvasRtC = new RectTransformComponent
            {
                AnchorMinX = 0,
                AnchorMaxX = 10,
                AnchorMinY = 0,
                AnchorMaxY = 5                
            };

            // MaterialComponent Canvas
            _canvasMatC = new MaterialComponent
            {
                Diffuse = new MatChannelContainer
                {
                    Color = new float3(1.0f, 0.3f, 0.3f),
                },
                Specular = new SpecularChannelContainer
                {
                    Color = float3.One,
                    Shininess = 0.5f,
                    Intensity = 0.8f
                }
            };

            // MeshComponent Canvas
            _canvasCube = new Cube();           
            _canvasMeshC = new MeshComponent
            {
                Vertices = _canvasCube.Vertices,
                Triangles = _canvasCube.Triangles,
                Normals = _canvasCube.Normals
            };

            _buttonTC = new TransformComponent
            {
                Scale = float3.One,
                Rotation = float3.Zero,
                Translation = trans
            };

            // RectTransformComponent Button
            _buttonRtC = new RectTransformComponent()
            {
                // AnchorPoints
                AnchorMinX = 0.1f,
                AnchorMaxX = 0.9f,
                AnchorMinY = 0.4f,
                AnchorMaxY = 0.8f,
                // Offsets
                Left = 3,
                Right = 2,
                Bottom = 0,
                Top = 0
            };

            // MaterialComponent Button
            _buttonMatC = new MaterialComponent()
            {
                Diffuse = new MatChannelContainer
                {
                    Color = new float3(0, 1, 0),
                },
                Specular = new SpecularChannelContainer
                {
                    Color = float3.One,
                    Shininess = 0.5f,
                    Intensity = 0.5f
                }
            };

            // MeshComponent Button
            _buttonCube = new Cube();
            _buttonMeshC = new MeshComponent()
            {
                Vertices = _buttonCube.Vertices,
                Triangles = _buttonCube.Triangles,
                Normals = _buttonCube.Normals
            };

            _textTC = new TransformComponent
            {
                Scale = float3.One,
                Rotation = float3.Zero,
                Translation = trans
            };

            // RectTransformComponent Text
            _textRtC = new RectTransformComponent()
            {
                // AnchorPoints
                AnchorMinX = 0.5f,
                AnchorMaxX = 0.5f,
                AnchorMinY = 0.5f,
                AnchorMaxY = 0.5f,
                // Offsets
                Left = 0.8f,
                Right = 0.8f,
                Bottom = 0.3f,
                Top = 0.3f
            };

            // MaterialComponent Text
            _textMatC = new MaterialComponent()
            {
                Diffuse = new MatChannelContainer
                {
                    Color = new float3(1, 0, 0),
                },
                Specular = new SpecularChannelContainer
                {
                    Color = float3.One,
                    Shininess = 0.5f,
                    Intensity = 0.5f
                }
            };

            // MeshComponent Text
            _textCube = new Cube();
            _textMeshC = new MeshComponent()
            {
                Vertices = _textCube.Vertices,
                Triangles = _textCube.Triangles,
                Normals = _textCube.Normals
            };


            // add all components
            // _canvas as root
            _canvas = new SceneContainer 
            {
                // Canvas node container
                Children = new List<SceneNodeContainer> 
                {
                    new SceneNodeContainer
                    {
                        // Button node container
                        Children = new List<SceneNodeContainer>()                   
                        {
                            new SceneNodeContainer()
                            {
                                Children = new List<SceneNodeContainer>()
                                {
                                    new SceneNodeContainer()
                                    {
                                        // ("Text" - Children, zZ null) 
                                        Children = new List<SceneNodeContainer>(),
                                        Components = new List<SceneComponentContainer>()
                                        {
                                            _textTC,
                                            _textRtC,
                                            _textMatC,
                                            _textMeshC
                                        }
                                    }
                                }, 
                                Components = new List<SceneComponentContainer>()
                                {
                                    _buttonTC,
                                    _buttonRtC,
                                    _buttonMatC,
                                    _buttonMeshC
                                }
                            }
                        },
                        Components = new List<SceneComponentContainer>
                        {
                            _canvasTC,
                            _canvasRtC,
                            _canvasMatC,
                            _canvasMeshC
                        }
                    }
                },
                Header = new SceneHeader
                {
                    CreatedBy = "Patrick",
                    CreationDate = "10.12.2016"
                }
            };

            
            // Wrap a SceneRenderer around the model.           
            _canvasRenderer = new SceneRenderer(_canvas); 
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {

            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            // Mouse and keyboard movement
            if (Keyboard.LeftRightAxis != 0 || Keyboard.UpDownAxis != 0)
            {
                _keys = true;
            }

            if (Mouse.LeftButton)
            {
                _keys = false;
                _angleVelHorz = -RotationSpeed * Mouse.XVel * DeltaTime * 0.0005f;
                _angleVelVert = -RotationSpeed * Mouse.YVel * DeltaTime * 0.0005f;
            }
            else if (Touch.GetTouchActive(TouchPoints.Touchpoint_0))
            {
                _keys = false;
                var touchVel = Touch.GetVelocity(TouchPoints.Touchpoint_0);
                _angleVelHorz = -RotationSpeed * touchVel.x * DeltaTime * 0.0005f;
                _angleVelVert = -RotationSpeed * touchVel.y * DeltaTime * 0.0005f;
            }
            else
            {
                var curDamp = (float)System.Math.Exp(-Damping * DeltaTime);
                _angleVelHorz *= curDamp;
                _angleVelVert *= curDamp;
            }

            _angleHorz += _angleVelHorz;
            _angleVert += _angleVelVert;

            if (Keyboard.GetKey(KeyCodes.Left))
                _canvasRtC.AnchorMaxX -= 0.1f;               
            
            if (Keyboard.GetKey(KeyCodes.Right))
                _canvasRtC.AnchorMaxX += 0.1f;

            if (Keyboard.GetKey(KeyCodes.Up))
                _canvasRtC.AnchorMaxY += 0.1f;

            if (Keyboard.GetKey(KeyCodes.Down))
                _canvasRtC.AnchorMaxY -= 0.1f;          


            // Create the camera matrix and set it as the current ModelView transformation
            var mtxRot = float4x4.CreateRotationX(_angleVert) * float4x4.CreateRotationY(_angleHorz);
            var mtxCam = float4x4.LookAt(0, 7, -15, 5, 0, 0, 0, 1, 0);
            RC.ModelView = mtxCam * mtxRot  /*_sceneScale*/;

            // Render the scene loaded in Init()            
            _canvasRenderer.Render(RC);
            

            // Swap buffers: Show the contents of the backbuffer (containing the currently rerndered farame) on the front buffer.
            Present();
        }

        private InputDevice Creator(IInputDeviceImp device)
        {
            throw new NotImplementedException();
        }

        // Is called when the window was resized
        public override void Resize()
        {
            // Set the new rendering area to the entire new windows size
            RC.Viewport(0, 0, Width, Height);

            // Create a new projection matrix generating undistorted images on the new aspect ratio.
            var aspectRatio = Width/(float) Height;

            // 0.25*PI Rad -> 45° Opening angle along the vertical direction. Horizontal opening angle is calculated based on the aspect ratio
            // Front clipping happens at 1 (Objects nearer than 1 world unit get clipped)
            // Back clipping happens at 2000 (Anything further away from the camera than 2000 world units gets clipped, polygons will be cut)
            var projection = float4x4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 1, 20000);
            RC.Projection = projection;            
        }       
    }
}