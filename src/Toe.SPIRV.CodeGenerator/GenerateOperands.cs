using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandLine;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Views;

namespace Toe.SPIRV.CodeGenerator
{
    public class GenerateOperands
    {
        [Verb("genoperands")]
        public class Options
        {
            [Option('g', "grammar", Required = false, HelpText = "Path to toe.spirv.grammar.json file")]
            public string Grammar { get; set; } = "toe.spirv.grammar.json";


            [Option('o', "output", Required = false, HelpText = "Path to the output folder")]
            public string Output { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Spv");
        }
        private SpirvInstructions _grammar;

        public void Run(Options options)
        {
            _grammar = Utils.LoadGrammar(options.Grammar);
            Directory.CreateDirectory(options.Output);
            foreach (var instruction in _grammar.OperandKinds)
            {
                switch (instruction.Value.Category)
                {
                    case SpirvOperandCategory.BitEnum:
                    {
                        var text = new FlagTemplate(instruction.Value).TransformText();
                        Utils.SaveText(Path.Combine(options.Output, instruction.Value.Name + ".cs"), text);
                        break;
                    }
                    case SpirvOperandCategory.ValueEnum:
                    {
                        var text = new EnumTemplate(instruction.Value).TransformText();
                        Utils.SaveText(Path.Combine(options.Output, instruction.Value.Name + ".cs"), text);
                        break;
                    }
                }
            }

            {
                var text = new NestedInstruction(_grammar.Instructions.Select(_=>_.Value).Where(_=>_nestedInstructions.Contains(_.Name))).TransformText();
                Utils.SaveText(Path.Combine(options.Output, "NestedInstruction.cs"), text);
            }
        }

        static HashSet<string> _nestedInstructions = new HashSet<string>(new string[] {
            "OpAccessChain",
            "OpInBoundsAccessChain",
            "OpBitcast",
            "OpBitwiseOr",
            "OpBitwiseXor",
            "OpBitwiseAnd",
            "OpConvertFToS",
            "OpConvertSToF",
            "OpConvertFToU",
            "OpConvertUToF",
            "OpConvertPtrToU",
            "OpConvertUToPtr",
            "OpFAdd",
            "OpFSub",
            "OpFMul",
            "OpFDiv",
            "OpFNegate",
            "OpFRem",
            "OpFMod",
            "OpGenericCastToPtr",
            "OpPtrCastToGeneric",
            "OpIAdd",
            "OpISub",
            "OpIEqual",
            "OpINotEqual",
            "OpIMul",
            "OpUDiv",
            "OpSDiv",
            "OpUMod",
            "OpSRem",
            "OpSMod",
            "OpLogicalEqual",
            "OpLogicalNotEqual",
            "OpLogicalOr",
            "OpLogicalAnd",
            "OpLogicalNot,",
            "OpPtrAccessChain",
            "OpInBoundsPtrAccessChain",
            "OpQuantizeToF16",
            "OpSConvert",
            "OpFConvert",
            "OpSNegate",
            "OpNot",
            "OpSelect",
            "OpShiftRightLogical",
            "OpShiftRightArithmetic",
            "OpShiftLeftLogical",
            "OpUConvert",
            "OpUGreaterThan",
            "OpSGreaterThan",
            "OpUGreaterThanEqual",
            "OpSGreaterThanEqual",
            "OpULessThan",
            "OpSLessThan",
            "OpULessThanEqual",
            "OpSLessThanEqual",
            "OpVectorShuffle",
            "OpCompositeExtract",
            "OpCompositeInsert"
        });
    }
}