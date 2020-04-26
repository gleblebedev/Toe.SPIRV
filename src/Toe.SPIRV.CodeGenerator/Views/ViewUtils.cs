using System;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Model.Spv;

namespace Toe.SPIRV.CodeGenerator.Views
{
    public class ViewUtils
    {
        public static string ToVarName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name;
            name = name.Substring(0, 1).ToLowerInvariant() + name.Substring(1);
            switch (name)
            {
                case "interface":
                case "event":
                case "base":
                case "object":
                case "default":
                    return "@" + name;
            }
            return name;
        }
        public static bool IsBuildInType(string opcode)
        {
            switch (opcode)
            {
                case "OpTypeBool":
                case "OpTypeFloat":
                case "OpTypeInt":
                case "OpTypeMatrix":
                case "OpTypeVector":
                case "OpTypeVoid":
                    return true;
            }

            return false;
        }
        public static bool IsCustomType(string opcode)
        {
            if (IsBuildInType(opcode))
                return true;
            switch (opcode)
            {
                case "OpTypeFunction":
                case "OpTypeArray":
                case "OpTypeStruct":
                    return true;
            }

            return false;
        }
        public static string GetTypeName(SpirvOperandKind kind)
        {
            if (kind == SpirvOperandKind.IdResultType)
                return "Spv.IdRef";
            if (kind == SpirvOperandKind.IdRef)
                return "Spv.IdRef";
            if (IsId(kind))
                return "uint";
            switch (kind)
            {
                case SpirvOperandKind.LiteralExtInstInteger:
                case SpirvOperandKind.LiteralInteger:
                    return "uint";
                case SpirvOperandKind.LiteralSpecConstantOpInteger:
                    return "Spv.NestedInstruction";
                case SpirvOperandKind.LiteralString:
                    return "string";
                default:
                    return "Spv." + kind;

            }
        }
        public static string GetOperandParser(SpirvOperand operand)
        {
            if (operand.Kind == SpirvOperandKind.LiteralContextDependentNumber)
            {
                return "Spv." + operand.Kind + ".ParseOptional(reader, end-reader.Position, IdResultType.Instruction)";
            }
            if (operand.Quantifier == SpirvOperandQuantifier.Optional)
                return "Spv." + operand.Kind + ".ParseOptional(reader, end-reader.Position)";
            if (operand.Quantifier == SpirvOperandQuantifier.Repeated)
                return "Spv." + operand.Kind + ".ParseCollection(reader, end-reader.Position)";
            return "Spv." + operand.Kind + ".Parse(reader, end-reader.Position)";
        }

        public static string GetOperandType(SpirvOperand operand)
        {
            var type = ViewUtils.GetTypeName(operand.Kind);
            if (operand.Quantifier == SpirvOperandQuantifier.Optional)
            {
                if (type == "uint")
                    return "uint?";
                return type;
            }
            if (operand.Quantifier == SpirvOperandQuantifier.Repeated)
            {
                return "IList<" + type + ">";
            }

            return type;
        }
        public static bool IsId(SpirvOperandKind kind)
        {
            switch (kind)
            {
                case SpirvOperandKind.IdResultType:
                case SpirvOperandKind.IdResult:
                case SpirvOperandKind.IdMemorySemantics:
                case SpirvOperandKind.IdScope:
                case SpirvOperandKind.IdRef:
                    return true;
            }
            return false;
        }

        public static string GetParameterName(string enumerant, Parameter parameter)
        {
            var res = GetParameterName(parameter);
            if (res == enumerant)
                return res + "Value";
            return res;
        }

        public static string GetParameterName(Parameter parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter.name))
                return parameter.kind;
            return GetPropertyName(parameter.name);
        }

        public static string GetParameterId(SpirvOperandDescription operand, string id)
        {
            if (char.IsDigit(id[0]))
                return operand.Name + id;
            return id;
        }

        public static string GetPropertyName(string name)
        {
            name = name.Trim('\'').Trim('.');
            name = name.Replace(" ", "");
            name = name.Replace("<<Invocation,invocations>>", "Invocations");
            name = name.Replace("-", "");
            name = name.Replace(",", "");
            name = name.Replace("~ref~", "_ref");

            {
                var collectionIndex = name.IndexOf("0\'");
                if (collectionIndex > 0)
                {
                    name = name.Substring(0, collectionIndex) + "s";
                }
            }
            {
                var collectionIndex = name.IndexOf("1\'");
                if (collectionIndex > 0)
                {
                    name = name.Substring(0, collectionIndex) + "s";
                }
            }
            {
                var collectionIndex = name.IndexOf("0Type\'", StringComparison.InvariantCultureIgnoreCase);
                if (collectionIndex > 0)
                {
                    name = name.Substring(0, collectionIndex) + "Types";
                }
            }
            return name;
        }
    }
}