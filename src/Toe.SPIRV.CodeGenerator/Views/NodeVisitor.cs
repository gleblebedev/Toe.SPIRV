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
    
    #line 1 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class NodeVisitor : NodeVisitorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public abstract class SpirvInstructionsBuilderBase
    {
        protected readonly List<InstructionWithId> _results = new List<InstructionWithId>();

        protected readonly Dictionary<Node, Instruction> _instructionMap = new Dictionary<Node, Instruction>();

        protected virtual Instruction Visit(Node node)
        {
            if (node == null) return null;
            if (_instructionMap.TryGetValue(node, out var instruction)) return instruction;
            switch (node.OpCode)
            {
");
            
            #line 29 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

foreach (var codeAndInstruction in _grammar.Instructions)
{
    var instruction = codeAndInstruction.Value;
    switch (instruction.Kind)
    {
        case InstructionKind.Other:
        {

            
            #line default
            #line hidden
            this.Write("                case Op.");
            
            #line 38 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name));
            
            #line default
            #line hidden
            this.Write(": return Visit");
            
            #line 38 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write("((Nodes.");
            
            #line 38 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write(") node);\r\n");
            
            #line 39 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

            break;
        }
        case InstructionKind.Type:
        {

            
            #line default
            #line hidden
            this.Write("                case Op.");
            
            #line 45 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name));
            
            #line default
            #line hidden
            this.Write(": return Visit");
            
            #line 45 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write("((Types.");
            
            #line 45 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write(")node);\r\n");
            
            #line 46 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

            break;
        }
        case InstructionKind.Function:
        case InstructionKind.Executable:
        {

            
            #line default
            #line hidden
            this.Write("                case Op.");
            
            #line 53 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name));
            
            #line default
            #line hidden
            this.Write(": return Visit");
            
            #line 53 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write("((");
            
            #line 53 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write(") node);\r\n");
            
            #line 54 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

            break;
        }
    }
}

            
            #line default
            #line hidden
            this.Write(@"            }

            throw new NotImplementedException(node.OpCode + "" not implemented yet."");
        }
        
        protected void VisitDecorations(Node node)
        {
            foreach (var decoration in node.BuildDecorations())
            {
                Visit(decoration);
            }
        }

        protected virtual string Visit(string instruction)
        {
            return instruction;
        }

        protected virtual uint Visit(uint instruction)
        {
            return instruction;
        }

        protected virtual IList<uint> Visit(IList<uint> instructions)
        {
            return instructions;
        }

        protected virtual LiteralContextDependentNumber Visit(LiteralContextDependentNumber instruction)
        {
            return instruction;
        }

        protected virtual IList<IdRef> Visit(IList<Node> instructions)
        {
            if (instructions == null)
                return null;
            return instructions.Select(_ => (IdRef)Visit(_)).ToList();
        }

");
            
            #line 100 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

foreach (var codeAndOperand in _grammar.OperandKinds)
{
    switch (codeAndOperand.Value.Category)
    {
        case SpirvOperandCategory.Id:
        case SpirvOperandCategory.Literal:
            break;
        case SpirvOperandCategory.Composite:
        {

            
            #line default
            #line hidden
            this.Write("        protected virtual IList<Spv.");
            
            #line 111 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(codeAndOperand.Value.Kind));
            
            #line default
            #line hidden
            this.Write("> Visit(IList<Spv.");
            
            #line 111 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(codeAndOperand.Value.Kind));
            
            #line default
            #line hidden
            this.Write("> operand)\r\n        {\r\n            return operand;\r\n        }\r\n");
            
            #line 115 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

            break;
        }
        default:
        {

            
            #line default
            #line hidden
            this.Write("        protected virtual Spv.");
            
            #line 121 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(codeAndOperand.Value.Kind));
            
            #line default
            #line hidden
            this.Write(" Visit(Spv.");
            
            #line 121 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(codeAndOperand.Value.Kind));
            
            #line default
            #line hidden
            this.Write(" operand)\r\n        {\r\n            return operand;\r\n        }\r\n");
            
            #line 125 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

            break;
        }
    }
}
foreach (var codeAndInstruction in _grammar.Instructions)
{
    var instruction = codeAndInstruction.Value;
    switch (instruction.Kind)
    {
        case InstructionKind.Type:
        {

            
            #line default
            #line hidden
            this.Write("        protected virtual ");
            
            #line 138 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name));
            
            #line default
            #line hidden
            this.Write(" Visit");
            
            #line 138 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write("(Types.");
            
            #line 138 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write(" node)\r\n        {\r\n            var instruction = new ");
            
            #line 140 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name));
            
            #line default
            #line hidden
            this.Write("();\r\n            _instructionMap.Add(node, instruction);\r\n");
            
            #line 142 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

    if (instruction.IdResult != null)
    {

            
            #line default
            #line hidden
            this.Write("            instruction.IdResult = (uint)_results.Count;\r\n            _results.Ad" +
                    "d(instruction);\r\n            VisitDecorations(node);\r\n");
            
            #line 149 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

    }
    if (!ViewUtils.IsCustomType(instruction.Name))
    {
        foreach (var operand in instruction.Operands)
        {

            
            #line default
            #line hidden
            this.Write("            instruction.");
            
            #line 156 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operand.Name));
            
            #line default
            #line hidden
            this.Write(" = Visit(node.");
            
            #line 156 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operand.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 157 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

        }
    }
    else
    {

            
            #line default
            #line hidden
            this.Write("            //This type should be handled manually. See SpirvInstructionsBuilder." +
                    "Visit");
            
            #line 163 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write(" for details.\r\n");
            
            #line 164 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

    }

            
            #line default
            #line hidden
            this.Write("            return instruction;\r\n        }\r\n");
            
            #line 169 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

            break;
        }
        case InstructionKind.Function:
        case InstructionKind.Executable:
        case InstructionKind.Other:
        {

            
            #line default
            #line hidden
            this.Write("        protected virtual ");
            
            #line 177 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name));
            
            #line default
            #line hidden
            this.Write(" Visit");
            
            #line 177 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write("(Nodes.");
            
            #line 177 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name.Substring(2)));
            
            #line default
            #line hidden
            this.Write(" node)\r\n        {\r\n            var instruction = new ");
            
            #line 179 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(instruction.Name));
            
            #line default
            #line hidden
            this.Write("();\r\n            _instructionMap.Add(node, instruction);\r\n\r\n");
            
            #line 182 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

    if (instruction.IdResult != null)
    {

            
            #line default
            #line hidden
            this.Write("            instruction.IdResult = (uint)_results.Count;\r\n            _results.Ad" +
                    "d(instruction);\r\n            VisitDecorations(node);\r\n");
            
            #line 189 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

    }
    if (instruction.IdResultType != null)
    {

            
            #line default
            #line hidden
            this.Write("            instruction.IdResultType = Visit(node.ResultType);\r\n\r\n");
            
            #line 196 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

    }
    foreach (var operand in instruction.Operands)
    {

            
            #line default
            #line hidden
            this.Write("            instruction.");
            
            #line 201 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operand.Name));
            
            #line default
            #line hidden
            this.Write(" = Visit(node.");
            
            #line 201 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operand.Name));
            
            #line default
            #line hidden
            this.Write(");\r\n");
            
            #line 202 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

    }
    if (instruction.HasDefaultExit)
    {

            
            #line default
            #line hidden
            this.Write("            Visit(node.Next);\r\n\r\n");
            
            #line 209 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

    }

            
            #line default
            #line hidden
            this.Write("            return instruction;\r\n        }\r\n");
            
            #line 214 "C:\github\Toe.SPIRV\src\Toe.SPIRV.CodeGenerator\Views\NodeVisitor.tt"

            break;
        }
    }
}

            
            #line default
            #line hidden
            this.Write("    }\r\n}");
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
    public class NodeVisitorBase
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
