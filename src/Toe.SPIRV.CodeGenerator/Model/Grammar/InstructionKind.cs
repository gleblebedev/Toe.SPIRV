namespace Toe.SPIRV.CodeGenerator.Model.Grammar
{
    public enum InstructionKind
    {
        Other,
        /// <summary>
        /// Type Declaration.
        /// </summary>
        Type,
        /// <summary>
        /// An instruction to produce a value without side effects.
        /// </summary>
        Function,
        /// <summary>
        /// An instruction with side effects. Should be part of control chain.
        /// </summary>
        Procedure
    }
}