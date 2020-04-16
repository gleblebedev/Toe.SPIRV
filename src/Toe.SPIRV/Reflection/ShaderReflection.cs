using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Spv;
using Capability = Toe.SPIRV.Reflection.Nodes.Capability;
using ExecutionMode = Toe.SPIRV.Reflection.Nodes.ExecutionMode;
using MemoryModel = Toe.SPIRV.Reflection.Nodes.MemoryModel;

namespace Toe.SPIRV.Reflection
{
    public class ShaderReflection
    {
        public ShaderReflection(Shader shader)
        {
            var context = new SpirvInstructionTreeBuilder();
            context.BuildTree(shader);
            
            Structures = context.TypeInstructions.Where(_=>_.TypeCategory == SpirvTypeCategory.Struct).Select(_=>(SpirvStruct)_).ToList();
            AddInstruction(context.CapabilityInstructions, CapabilityInstructions);
            AddInstruction(context.ExtensionInstructions, ExtensionInstructions);
            AddInstruction(context.ExtInstImportInstructions, ExtInstImportInstructions);
            MemoryModel = context.MemoryModel;
            AddInstruction(context.EntryPointInstructions, EntryPointInstructions);
            AddInstruction(context.ExecutionModeInstructions, ExecutionModeInstructions);
        }

        private static void AddInstruction<T>(List<T> source, List<T> dst)
        {
            foreach (var entryFunction in source)
            {
                dst.Add(entryFunction);
            }
        }

        public IReadOnlyList<SpirvStruct> Structures { get; private set; }

        /// <summary>
        /// All OpCapability instructions. 
        /// </summary>
        public List<Capability> CapabilityInstructions { get; } = new List<Capability>();
        /// <summary>
        /// Optional OpExtension instructions (extensions to SPIR-V).
        /// </summary>
        public List<Extension> ExtensionInstructions { get; } = new List<Extension>();
        /// <summary>
        /// Optional OpExtInstImport instructions.
        /// </summary>
        public List<ExtInstImport> ExtInstImportInstructions { get; } = new List<ExtInstImport>();
        /// <summary>
        /// The single required OpMemoryModel instruction.
        /// </summary>
        public MemoryModel MemoryModel { get; set; }
        /// <summary>
        /// All entry point declarations, using OpEntryPoint.
        /// </summary>
        public List<EntryPoint> EntryPointInstructions = new List<EntryPoint>();
        /// <summary>
        /// All entry point declarations, using OpEntryPoint.
        /// </summary>
        public List<ExecutionMode> ExecutionModeInstructions = new List<ExecutionMode>();

        public Shader Build()
        {
            var context = new SpirvInstructionsBuilder();
            return context.Build(this);
        }
    }
}