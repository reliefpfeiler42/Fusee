﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using FuseeProjectGenerator;

namespace FuseeAuthoringTools.tools
{
    /// <summary>
    /// Handles all the different work with the project. Saving, opening, creating. All this.
    /// </summary>
    public class FuseeProjectManager
    {
        private ProjectGenerator _projectGenerator;
        private EngineProject _engineProject;
        private FuseeFileManager _fileManager;

        /// <summary>
        /// Constructor.
        /// </summary>
        public FuseeProjectManager()
        {
           
        }

        /// <summary>
        /// Creates a new fusee project, names it, inits the basics etc.
        /// </summary>
        /// <param name="pname"></param>
        /// <returns>ToolState enum state value</returns>
        public ToolState CreateProject(String slnName, String pName, String pPath)
        {
            // Check if project already exists?
            if (DoesProjectExist(pName, pPath))
            {
                // If yes open it.
                OpenProject(pName, pPath);
            }
            else
            {
                // If not create it.
                _engineProject.ProjectState = ProjectState.Dirty;
                _projectGenerator = new ProjectGenerator(pName, pPath);

                if (_projectGenerator == null)
                    return ToolState.ERROR;

                _engineProject.ProjectState = ProjectState.Clean;
                
                _engineProject = new EngineProject
                {
                    PathToSolutionFolder = pPath,
                    PathToProjectFolder = GlobalValues.PROJECTFOLDER + "/" + pName,
                    NameofCsProject = pName,
                    PathToCsProjectFile = pPath + GlobalValues.PROJECTFOLDER + "/" + pName + "/" + GenerateCsProjName(pName),
                    ProjectState = ProjectState.Clean,
                    SolutionName = slnName
                };
                
                // Save it to XML.    
                SaveProject();
            }
            // Create a file manager so we can actually work with files ;)
            _fileManager = new FuseeFileManager(this);

            return ToolState.OK;
        }

        /// <summary>
        /// Saves a project to an XML file. So it can be loaded again if needed.
        /// </summary>
        /// <returns>ToolState enum state value</returns>
        public ToolState SaveProject()
        {
            if (_engineProject.ProjectState != ProjectState.Dirty || _engineProject.ProjectState != ProjectState.Corrupt)
            {
                SerializeToXML(_engineProject);
                return ToolState.OK;
            }
            // Cannot save because project is not clean.
            return ToolState.ERROR;
        }

        /// <summary>
        /// Opens a project and returns some handle? So the user can use it.
        /// </summary>
        /// <param name="pname"></param>
        /// /// <param name="pathToProject"></param>
        /// <returns>ToolState enum state value.</returns>
        public ToolState OpenProject(String pName, String pPath)
        {
            _engineProject = DeserializeFromXML(pName, pPath);

            return ToolState.OK;
        }

        public ToolState BuildProject(EngineProject ep)
        {
            ToolState res = FuseeBuildManager.BuildSolution(ep);

            return ToolState.OK;
        }

        public ToolState CreateClass(String className)
        {
            _fileManager.CreateCSharpClass(className, _engineProject.NameofCsProject);
            return ToolState.OK;
        }

        public ToolState AddCodeComponent(String pathToCode)
        {
            // TODO: Create struct with relation between asset id and path to code
            // TODO: Serialize struct
            // TODO: Insert the relation in the csproj of the engine project.

            return ToolState.OK;
        }

        public ToolState ExportSceneToFus()
        {
            // TODO: Export the scene to fus somehow.
            return ToolState.OK;
        }

        private ToolState SerializeToXML(EngineProject p)
        {
            XmlSerializer ser = new XmlSerializer(typeof(EngineProject));
            TextWriter tw = new StreamWriter(p.PathToSolutionFolder + p.PathToProjectFolder + "/" + p.NameofCsProject + ".xml");
            ser.Serialize(tw, p);
            tw.Close();

            return ToolState.OK;
        }

        private EngineProject DeserializeFromXML(String pName, String pathToXML)
        {
            if (_engineProject.NameofCsProject !=  null)
                return _engineProject;

            XmlSerializer des = new XmlSerializer(typeof(EngineProject));
            TextReader tr = new StreamReader(pathToXML + "/projects/" + pName + "/" + pName + ".xml"); // path to xml.
            var ep = (EngineProject)des.Deserialize(tr);
            tr.Close();

            return ep;
        }

        private Boolean DoesProjectExist(String pName, String pPath)
        {
            if (File.Exists(pPath + GlobalValues.PROJECTFOLDER + "/" + pName + "/" + pName + ".csproj"))
                return true;

            return false;
        }

        private String GenerateCsProjName(String pName)
        {
            return pName + ".csproj";
        }

        public EngineProject FuseeEngineProject
        {
            get { return _engineProject; }
            set { _engineProject = value; }
        }

        public void SetProjectDirty()
        {
            _engineProject.ProjectState = ProjectState.Dirty;
        }

        public void SetProjectClean()
        {
            _engineProject.ProjectState = ProjectState.Clean;
        }

    }
}