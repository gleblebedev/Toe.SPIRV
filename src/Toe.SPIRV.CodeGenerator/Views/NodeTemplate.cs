﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Toe.SPIRV.CodeGenerator.Views
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Toe.SPIRV.CodeGenerator.Model.Grammar;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class NodeTemplate : NodeTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System.Collections.Generic;\r\nusing Toe.SPIRV.Instructions;\r\nusing Toe.SPIRV" +
                    ".Spv;\r\n\r\nnamespace Toe.SPIRV.Reflection.Nodes\r\n{\r\n    public partial class ");
            
            #line 13 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write(" : ");
            
            #line 13 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(baseClass));
            
            #line default
            #line hidden
            
            #line 13 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_instruction.HasDefaultExit?", INodeWithNext":""));
            
            #line default
            #line hidden
            this.Write("\r\n    {\r\n        public ");
            
            #line 15 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(name));
            
            #line default
            #line hidden
            this.Write("()\r\n        {\r\n        }\r\n\r\n        public override Op OpCode => Op.");
            
            #line 19 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_instruction.Name));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\n");
            
            #line 21 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
if (_instruction.HasDefaultExit)
{

            
            #line default
            #line hidden
            this.Write("        /// <summary>\r\n        /// Next operation in sequence\r\n        /// </summ" +
                    "ary>\r\n        public ExecutableNode Next { get; set; }\r\n\r\n        public overrid" +
                    "e ExecutableNode GetNext()\r\n        {\r\n            return Next;\r\n        }\r\n");
            
            #line 34 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
}

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 38 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
foreach (var op in _instruction.Operands)
{
    switch (op.Class)
    {
        case SpirvOperandClassification.Type:

            
            #line default
            #line hidden
            this.Write("        public SpirvTypeBase ");
            
            #line 45 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 46 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
            break;
        case SpirvOperandClassification.Exit:
        case SpirvOperandClassification.Input:

            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 51 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetNodeType(op)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 51 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 52 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
            break;
        case SpirvOperandClassification.RepeatedInput:

            
            #line default
            #line hidden
            this.Write("        public IList<Node> ");
            
            #line 56 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 57 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
            break;
        default:

            
            #line default
            #line hidden
            this.Write("        public ");
            
            #line 61 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetPropertyType(op)));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 61 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n");
            
            #line 62 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
            break;
    }
}

if (_instruction.IdResultType != null)
{

            
            #line default
            #line hidden
            this.Write("        public SpirvTypeBase ResultType { get; set; }\r\n\r\n        public override " +
                    "SpirvTypeBase GetResultType()\r\n        {\r\n            return ResultType;\r\n      " +
                    "  }\r\n");
            
            #line 76 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
}

if (_instruction.Operands.Any(op=>op.Class == SpirvOperandClassification.Input || op.Class == SpirvOperandClassification.RepeatedInput))
{

            
            #line default
            #line hidden
            this.Write("        public override IEnumerable<NodePinWithConnection> InputPins\r\n        {\r\n" +
                    "            get\r\n            {\r\n");
            
            #line 86 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
foreach (var op in _instruction.Operands)
{
    if (op.Class == SpirvOperandClassification.Input)
    {

            
            #line default
            #line hidden
            this.Write("                yield return CreateInputPin(nameof(");
            
            #line 92 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write("), ");
            
            #line 92 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 93 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
    }
    else if (op.Class == SpirvOperandClassification.RepeatedInput)
    {

            
            #line default
            #line hidden
            this.Write("                for (var index = 0; index < ");
            
            #line 98 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(".Count; index++)\r\n                {\r\n                    yield return CreateInput" +
                    "Pin(nameof(");
            
            #line 100 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(") + index, ");
            
            #line 100 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write("[index]);\r\n                }\r\n");
            
            #line 102 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
    }
}

            
            #line default
            #line hidden
            this.Write("                yield break;\r\n            }\r\n        }\r\n");
            
            #line 109 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
}

            
            #line default
            #line hidden
            this.Write("\r\n        public override IEnumerable<NodePin> OutputPins\r\n        {\r\n           " +
                    " get\r\n            {\r\n");
            
            #line 117 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
if (_instruction.IdResultType != null)
{

            
            #line default
            #line hidden
            this.Write("                yield return new NodePin(this, \"\", ResultType);\r\n");
            
            #line 122 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
}

            
            #line default
            #line hidden
            this.Write("                yield break;\r\n            }\r\n        }\r\n\r\n");
            
            #line 129 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
if (_instruction.HasDefaultEnter)
{

            
            #line default
            #line hidden
            this.Write("        public override IEnumerable<NodePin> EnterPins\r\n        {\r\n            ge" +
                    "t\r\n            {\r\n                yield return new NodePin(this, \"\", null);\r\n   " +
                    "         }\r\n        }\r\n");
            
            #line 140 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
}

            
            #line default
            #line hidden
            this.Write("\r\n        public override IEnumerable<NodePinWithConnection> ExitPins\r\n        {\r" +
                    "\n            get\r\n            {\r\n");
            
            #line 148 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
if (_instruction.HasDefaultExit)
{

            
            #line default
            #line hidden
            this.Write("                yield return CreateExitPin(\"\", GetNext());\r\n");
            
            #line 153 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
}
foreach (var op in _instruction.Operands)
{
    if (op.Class == SpirvOperandClassification.Exit)
    {

            
            #line default
            #line hidden
            this.Write("                yield return CreateExitPin(nameof(");
            
            #line 160 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write("), ");
            
            #line 160 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 161 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
    }
}

            
            #line default
            #line hidden
            this.Write("                yield break;\r\n            }\r\n        }\r\n        public override v" +
                    "oid SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)\r\n        {\r\n " +
                    "           SetUp((");
            
            #line 170 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(opname));
            
            #line default
            #line hidden
            this.Write(")op, treeBuilder);\r\n        }\r\n\r\n        public void SetUp(");
            
            #line 173 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(opname));
            
            #line default
            #line hidden
            this.Write(" op, SpirvInstructionTreeBuilder treeBuilder)\r\n        {\r\n");
            
            #line 175 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
if (_instruction.IdResultType != null)
{

            
            #line default
            #line hidden
            this.Write("            ResultType = treeBuilder.ResolveType(op.IdResultType);\r\n");
            
            #line 180 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
}

foreach (var op in _instruction.Operands)
{
    switch (op.Class)
    {
        case SpirvOperandClassification.Type:

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 189 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(" = treeBuilder.ResolveType(op.");
            
            #line 189 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 190 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
            break;
        case SpirvOperandClassification.Exit:
        case SpirvOperandClassification.Input:

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 195 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 195 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CastNodeType(op)));
            
            #line default
            #line hidden
            this.Write("treeBuilder.GetNode(op.");
            
            #line 195 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 196 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
            break;
        case SpirvOperandClassification.RepeatedInput:

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 200 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(" = treeBuilder.GetNodes(op.");
            
            #line 200 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 201 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
            break;
        default:

            
            #line default
            #line hidden
            this.Write("            ");
            
            #line 205 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(" = op.");
            
            #line 205 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(op.Name));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 206 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
            break;
    }
}
if (_instruction.IdResult != null)
{

            
            #line default
            #line hidden
            this.Write("            SetUpDecorations(op.Decorations);\r\n");
            
            #line 214 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeTemplate.tt"
 
}

            
            #line default
            #line hidden
            this.Write("        }\r\n        \r\n        partial void SetUpDecorations(IList<OpDecorate> deco" +
                    "rations);\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class NodeTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
