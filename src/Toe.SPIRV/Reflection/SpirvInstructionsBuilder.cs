﻿using System;
using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvInstructionsBuilder
    {
        private Dictionary<object, Instruction> _instructionMap = new Dictionary<object, Instruction>();
        private List<InstructionWithId> _results = new List<InstructionWithId>();
        private List<IdRef> _interface = new List<IdRef>();
        private List<Instruction> _debugInfo = new List<Instruction>();
        private List<Instruction> _annotations = new List<Instruction>();
        private List<Instruction> _declarations = new List<Instruction>();
        private List<List<Instruction>> _functions = new List<List<Instruction>>();

        private InstructionRegistry _instructionRegistry = new InstructionRegistry();

        public Shader Build(ShaderReflection shaderReflection)
        {
            var shader = new Shader();

            _results.Add(null);
            var opExtInstImport = new OpExtInstImport() { Name = "GLSL.std.450" };
            AddInstructionResult(opExtInstImport);

            Visit(shaderReflection.EntryFunction);
            shader.Bound = (uint)_results.Count;
            shader.Instructions.Add(new OpCapability() { Capability = new Capability.Shader() });
            shader.Instructions.Add( opExtInstImport);
            shader.Instructions.Add(new OpMemoryModel() { MemoryModel = new MemoryModel.GLSL450(), AddressingModel = new AddressingModel.Logical() });
            shader.Instructions.Add(new OpEntryPoint() { ExecutionModel = shaderReflection.ExecutionModel, Interface = _interface, EntryPoint = IdRef(shaderReflection.EntryFunction), Name = shaderReflection.EntryFunction.Name ?? "main" });
            AddInstructions(_debugInfo, shader);
            AddInstructions(_annotations, shader);
            AddInstructions(_declarations, shader);
            foreach (var function in _functions)
            {
                AddInstructions(function, shader);
            }
            return shader;
        }

        private static void AddInstructions(List<Instruction> declarations, Shader shader)
        {
            foreach (var instruction in declarations)
            {
                shader.Instructions.Add(instruction);
            }
        }

        private IdRef IdRef(ReflectedInstruction reflectedInstruction)
        {
            if (_instructionMap.TryGetValue(reflectedInstruction, out var instruction))
            {
                if (instruction.TryGetResultId(out var id))
                {
                    return new IdRef(id, _instructionRegistry);
                }
            }

            return null;
        }

        private bool AddInstructionResult(InstructionWithId instructionWithId, string name = null)
        {
            if (instructionWithId != null)
            {
                instructionWithId.IdResult = (uint) _results.Count;
                _instructionRegistry.Add(instructionWithId);
                _results.Add(instructionWithId);

                if (name != null)
                {
                    _debugInfo.Add(new OpName() { Name = name, Target = new IdRef(instructionWithId) });
                }

                return true;
            }
            return false;
        }


        private void Visit(ReflectedInstruction reflectedInstruction)
        {
            if (reflectedInstruction == null)
                return;
            if (_instructionMap.ContainsKey(reflectedInstruction))
                return;
            var instruction = InstructionFactory.Create(reflectedInstruction.OpCode);
            _instructionMap.Add(reflectedInstruction, instruction);

            AddInstructionResult(instruction as InstructionWithId, reflectedInstruction.Name);

            switch (reflectedInstruction.OpCode)
            {
                case Op.OpVariable:
                    VisitVariable((Variable) reflectedInstruction, (OpVariable) instruction);
                    break;
                case Op.OpLabel:
                    VisitLabel((Label)reflectedInstruction, (OpLabel)instruction);
                    break;
            }
        }

        private void VisitLabel(Label reflectedInstruction, OpLabel instruction)
        {
        }

        private void VisitVariable(Variable reflectedInstruction, OpVariable instruction)
        {
            
        }
    }
}