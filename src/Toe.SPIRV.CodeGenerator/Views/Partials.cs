using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toe.SPIRV.CodeGenerator.Model.Grammar;

namespace Toe.SPIRV.CodeGenerator.Views
{
    public partial class NodeTemplate
    {
        private readonly SpirvInstruction _instruction;
        private readonly string opname;
        private readonly string name;
        private readonly string baseClass;
        private readonly IList<SpirvOperand> IdRefOperands;

        public NodeTemplate(SpirvInstruction instruction)
        {
            _instruction = instruction;
            opname = _instruction.Name;
            name = _instruction.Name.Substring(2);
            switch (_instruction.Kind)
            {
                case InstructionKind.Function:
                    baseClass = "FunctionNode";
                    break;
                default:
                    baseClass = "SequentialOperationNode";
                    break;
            }
            IdRefOperands = _instruction.Operands.Where(_=>_.Kind == SpirvOperandKind.IdRef).ToList();
        }
    }
}
