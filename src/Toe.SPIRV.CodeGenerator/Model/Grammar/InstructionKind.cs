namespace Toe.SPIRV.CodeGenerator.Model.Grammar
{
    public enum InstructionClass
    {
        Unknown,
        Miscellaneous,
        Debug,
        Extension,
        ModeSetting,
        TypeDeclaration,
        ConstantCreation,
        Function,
        Memory,
        Annotation,
        Composite,
        Image,
        Conversion,
        Arithmetic,
        Relational_and_Logical,
        Bit,
        Derivative,
        Primitive,
        Barrier,
        Atomic,
        ControlFlow,
        Group,
        Pipe,
        DeviceSide_Enqueue,
        NonUniform,
        Reserved,
        @exclude,
    }

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
        Executable
    }
}