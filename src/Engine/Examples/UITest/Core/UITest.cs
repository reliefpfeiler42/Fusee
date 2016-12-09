#define GUI_SIMPLE

using System;
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

        private Mesh _mesh;
        private Mesh _cubeMesh;
        private Mesh _buttonMesh;
       
        private SceneContainer _cube;
        private SceneContainer _canvas;
        private SceneRenderer _sceneRenderer;
        private SceneRenderer _canvasRenderer;
        private float4x4 _sceneScale;

        private bool _keys;
        
        // Init is called on startup. 
        public override void Init()
        {
            // Set the clear color for the backbuffer to white (100% intentsity in all color channels R, G, B, A).
            RC.ClearColor = new float4(1, 1, 1, 1);
            /*
            _mesh = new Mesh
            {
                Vertices = new[]
                {
                    new float3(-0.8165f, -0.3333f, -0.4714f),   // Vertex 0
                    new float3(0.8165f, -0.3333f, -0.4714f),    // Vertex 1
                    new float3(0, -0.3333f, 0.9428f),           // Vertex 2
                    new float3(0, 1, 0),                        // Vertex 3
                    new float3(-0.8165f, -1.3333f, -0.4714f),   // Vertex 4
                    new float3(0.8165f, -1.3333f, -0.4714f),    // Vertex 5
                    new float3(0, -1.3333f, 0.9428f)            // Vertex 6
                },
                Triangles = new ushort[] 
                {
                    0, 2, 1,  // Triangle 0 "Bottom" facing towards negative y axis
                    0, 1, 3,  // Triangle 1 "Back side" facing towards negative z axis
                    1, 2, 3,  // Triangle 2 "Right side" facing towards positive x axis
                    2, 0, 3,  // Triangle 3 "Left side" facing towrads negative x axis
                    0, 4, 5,
                    1, 0, 5,
                    1, 5, 6,
                    2, 1, 6,
                    4, 0, 2,
                    6, 4, 2,},
            };
            */
            // Load the cube model
            _cubeMesh = LoadMesh("Cube.fus");
            //_cube = AssetStorage.Get<SceneContainer>("Cube.fus");
            //_sceneScale = float4x4.CreateScale(1, 2, 1);
            
            // add Width and Height to the cube
            var rectTrans = new RectTransformComponent {Scale = new float3(1, 1, 1), Width = 20f, Height = 10f};
            _cube.Children[0].AddComponent(rectTrans);
            /*
            var meshComp = new MeshComponent
            {
                Vertices = _mesh.Vertices,
                Triangles = _mesh.Triangles
            };
            _canvas.Children[0].AddComponent(meshComp);
            */
            // Wrap a SceneRenderer around the model.           
            _sceneRenderer = new SceneRenderer(_cube);
            //_canvasRenderer = new SceneRenderer(_canvas);
        }

        public static Mesh LoadMesh(string assetName)
        {
            SceneContainer sc = AssetStorage.Get<SceneContainer>(assetName);
            MeshComponent mc = sc.Children.FindComponents<MeshComponent>(c => true).First();
            return new Mesh
            {
                Vertices = mc.Vertices,
                Normals = mc.Normals,
                Triangles = mc.Triangles
            };
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
                if (_keys)
                {
                    _angleVelHorz = -RotationSpeed * Keyboard.LeftRightAxis * DeltaTime;
                    _angleVelVert = -RotationSpeed * Keyboard.UpDownAxis * DeltaTime;
                }
                else
                {
                    var curDamp = (float)System.Math.Exp(-Damping * DeltaTime);
                    _angleVelHorz *= curDamp;
                    _angleVelVert *= curDamp;
                }
            }

            _angleHorz += _angleVelHorz;
            _angleVert += _angleVelVert;

            // Create the camera matrix and set it as the current ModelView transformation
            var mtxRot = float4x4.CreateRotationX(_angleVert) * float4x4.CreateRotationY(_angleHorz);
            var mtxCam = float4x4.LookAt(0, 5, -5, 0, 0, 0, 0, 1, 0);
            RC.ModelView = mtxCam * mtxRot  /*_sceneScale*/;

            // Render the scene loaded in Init()
            //_sceneRenderer.Render(RC);
            //_sceneRenderer.Traverse();
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