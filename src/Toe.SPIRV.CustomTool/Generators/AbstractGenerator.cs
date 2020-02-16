using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.CustomTool.Generators
{
    public abstract class AbstractGenerator
    {
        private readonly Shader _shader;
        private readonly string _fileName;

        public AbstractGenerator(Shader shader, string filename)
        {
            _shader = shader;
            _fileName = filename;
        }

        public Shader Shader
        {
            get { return _shader; }
        }

        internal static Project GetActiveProject()
        {
            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            return GetActiveProject(dte);
        }

        internal static Project GetActiveProject(DTE dte)
        {
            Project activeProject = null;

            Array activeSolutionProjects = dte.ActiveSolutionProjects as Array;
            if (activeSolutionProjects != null && activeSolutionProjects.Length > 0)
            {
                activeProject = activeSolutionProjects.GetValue(0) as Project;
            }

            return activeProject;
        }
        public string GetNamespace()
        {
            var project = GetActiveProject();
            var defaultNamespace = project.Properties.Item("DefaultNamespace")?.Value?.ToString();
            var fileNameWithoutExtension = Path.GetFileName(_fileName);
            var extPos = fileNameWithoutExtension.IndexOf('.');
            if (extPos > 0)
                fileNameWithoutExtension = fileNameWithoutExtension.Substring(0, extPos);
           
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(defaultNamespace))
            {
                stringBuilder.Append(defaultNamespace);
                stringBuilder.Append(".");
            }

            var dir = Path.GetDirectoryName(_fileName);
            var projectDir = Path.GetDirectoryName(project.FileName);
            if (dir.StartsWith(projectDir))
            {
                dir = dir.Substring(projectDir.Length).TrimStart(Path.DirectorySeparatorChar);
                if (!string.IsNullOrEmpty(dir))
                {
                    stringBuilder.Append(dir.Replace(Path.DirectorySeparatorChar, '.'));
                    stringBuilder.Append(".");
                }
            }


            stringBuilder.Append(fileNameWithoutExtension);
            return stringBuilder.ToString();
        }

        public virtual string GenerateText()
        {
            return new ReflectionGenerator(_shader, GetNamespace()).GenerateText();
        }
    }
}
