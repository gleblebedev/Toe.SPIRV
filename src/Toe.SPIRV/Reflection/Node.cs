using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public abstract class Node
    {
        public virtual SpirvTypeBase GetResultType()
        {
            return null;
        }

        public virtual Node GetNext()
        {
            return null;
        }

        public bool IsFunction
        {
            get
            {
                var resType = GetResultType();
                if (resType == null)
                    return false;
                if (resType == SpirvTypeBase.Void)
                    return false;
                return true;
            }
        }

        public virtual IEnumerable<NodePin> EnterPins
        {
            get
            {
                if (!IsFunction) yield return new NodePin(this,"",null);
            }
        }

        public virtual IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                if (!IsFunction) yield return CreateExitPin("", GetNext());
            }
        }

        public virtual IEnumerable<NodePinWithConnection> InputPins
        {
            get { return Enumerable.Empty<NodePinWithConnection>(); }
        }

        public virtual IEnumerable<NodePin> OutputPins
        {
            get
            {
                if (IsFunction) yield return new NodePin(this, "", GetResultType());
            }
        }

        protected NodePinWithConnection CreateInputPin(string name, Node node)
        {
            if (node == null)
                return new NodePinWithConnection(this, name, null, null);
            var output = node.OutputPins.First();
            return new NodePinWithConnection(this, name, output.Type, output);
        }
        protected NodePinWithConnection CreateExitPin(string name, Node node)
        {
            if (node == null)
                return new NodePinWithConnection(this, name, null, null);
            var input = node.EnterPins.First();
            return new NodePinWithConnection(this, name, input.Type, input);
        }
        public static Node Create(Instruction instruction, SpirvInstructionTreeBuilder context)
        {
            switch (instruction.OpCode)
            {
                case Op.OpConstantTrue: return new ConstantTrue();
                case Op.OpConstantFalse: return new ConstantFalse();
                case Op.OpConstant: return new Constant();
                case Op.OpConstantComposite: return new ConstantComposite();
                case Op.OpConstantSampler: return new ConstantSampler();
                case Op.OpConstantNull: return new ConstantNull();
                case Op.OpSpecConstantTrue: return new SpecConstantTrue();
                case Op.OpSpecConstantFalse: return new SpecConstantFalse();
                case Op.OpSpecConstant: return new SpecConstant();
                case Op.OpSpecConstantComposite: return new SpecConstantComposite();
                case Op.OpSpecConstantOp: return new SpecConstantOp();
                case Op.OpFunction: return new Function();
                case Op.OpFunctionParameter: return new FunctionParameter();
                case Op.OpFunctionEnd: return new FunctionEnd();
                case Op.OpFunctionCall: return new FunctionCall();
                case Op.OpVariable: return new Variable();
                case Op.OpImageTexelPointer: return new ImageTexelPointer();
                case Op.OpLoad: return new Load();
                case Op.OpStore: return new Store();
                case Op.OpCopyMemory: return new CopyMemory();
                case Op.OpCopyMemorySized: return new CopyMemorySized();
                case Op.OpAccessChain: return new AccessChain();
                case Op.OpInBoundsAccessChain: return new InBoundsAccessChain();
                case Op.OpPtrAccessChain: return new PtrAccessChain();
                case Op.OpArrayLength: return new ArrayLength();
                case Op.OpGenericPtrMemSemantics: return new GenericPtrMemSemantics();
                case Op.OpInBoundsPtrAccessChain: return new InBoundsPtrAccessChain();
                case Op.OpDecorate: return new Decorate();
                case Op.OpMemberDecorate: return new MemberDecorate();
                case Op.OpDecorationGroup: return new DecorationGroup();
                case Op.OpGroupDecorate: return new GroupDecorate();
                case Op.OpGroupMemberDecorate: return new GroupMemberDecorate();
                case Op.OpVectorExtractDynamic: return new VectorExtractDynamic();
                case Op.OpVectorInsertDynamic: return new VectorInsertDynamic();
                case Op.OpVectorShuffle: return new VectorShuffle();
                case Op.OpCompositeConstruct: return new CompositeConstruct();
                case Op.OpCompositeExtract: return new CompositeExtract();
                case Op.OpCompositeInsert: return new CompositeInsert();
                case Op.OpCopyObject: return new CopyObject();
                case Op.OpTranspose: return new Transpose();
                case Op.OpSampledImage: return new SampledImage();
                case Op.OpImageSampleImplicitLod: return new ImageSampleImplicitLod();
                case Op.OpImageSampleExplicitLod: return new ImageSampleExplicitLod();
                case Op.OpImageSampleDrefImplicitLod: return new ImageSampleDrefImplicitLod();
                case Op.OpImageSampleDrefExplicitLod: return new ImageSampleDrefExplicitLod();
                case Op.OpImageSampleProjImplicitLod: return new ImageSampleProjImplicitLod();
                case Op.OpImageSampleProjExplicitLod: return new ImageSampleProjExplicitLod();
                case Op.OpImageSampleProjDrefImplicitLod: return new ImageSampleProjDrefImplicitLod();
                case Op.OpImageSampleProjDrefExplicitLod: return new ImageSampleProjDrefExplicitLod();
                case Op.OpImageFetch: return new ImageFetch();
                case Op.OpImageGather: return new ImageGather();
                case Op.OpImageDrefGather: return new ImageDrefGather();
                case Op.OpImageRead: return new ImageRead();
                case Op.OpImageWrite: return new ImageWrite();
                case Op.OpImage: return new Image();
                case Op.OpImageQueryFormat: return new ImageQueryFormat();
                case Op.OpImageQueryOrder: return new ImageQueryOrder();
                case Op.OpImageQuerySizeLod: return new ImageQuerySizeLod();
                case Op.OpImageQuerySize: return new ImageQuerySize();
                case Op.OpImageQueryLod: return new ImageQueryLod();
                case Op.OpImageQueryLevels: return new ImageQueryLevels();
                case Op.OpImageQuerySamples: return new ImageQuerySamples();
                case Op.OpConvertFToU: return new ConvertFToU();
                case Op.OpConvertFToS: return new ConvertFToS();
                case Op.OpConvertSToF: return new ConvertSToF();
                case Op.OpConvertUToF: return new ConvertUToF();
                case Op.OpUConvert: return new UConvert();
                case Op.OpSConvert: return new SConvert();
                case Op.OpFConvert: return new FConvert();
                case Op.OpQuantizeToF16: return new QuantizeToF16();
                case Op.OpConvertPtrToU: return new ConvertPtrToU();
                case Op.OpSatConvertSToU: return new SatConvertSToU();
                case Op.OpSatConvertUToS: return new SatConvertUToS();
                case Op.OpConvertUToPtr: return new ConvertUToPtr();
                case Op.OpPtrCastToGeneric: return new PtrCastToGeneric();
                case Op.OpGenericCastToPtr: return new GenericCastToPtr();
                case Op.OpGenericCastToPtrExplicit: return new GenericCastToPtrExplicit();
                case Op.OpBitcast: return new Bitcast();
                case Op.OpSNegate: return new SNegate();
                case Op.OpFNegate: return new FNegate();
                case Op.OpIAdd: return new IAdd();
                case Op.OpFAdd: return new FAdd();
                case Op.OpISub: return new ISub();
                case Op.OpFSub: return new FSub();
                case Op.OpIMul: return new IMul();
                case Op.OpFMul: return new FMul();
                case Op.OpUDiv: return new UDiv();
                case Op.OpSDiv: return new SDiv();
                case Op.OpFDiv: return new FDiv();
                case Op.OpUMod: return new UMod();
                case Op.OpSRem: return new SRem();
                case Op.OpSMod: return new SMod();
                case Op.OpFRem: return new FRem();
                case Op.OpFMod: return new FMod();
                case Op.OpVectorTimesScalar: return new VectorTimesScalar();
                case Op.OpMatrixTimesScalar: return new MatrixTimesScalar();
                case Op.OpVectorTimesMatrix: return new VectorTimesMatrix();
                case Op.OpMatrixTimesVector: return new MatrixTimesVector();
                case Op.OpMatrixTimesMatrix: return new MatrixTimesMatrix();
                case Op.OpOuterProduct: return new OuterProduct();
                case Op.OpDot: return new Dot();
                case Op.OpIAddCarry: return new IAddCarry();
                case Op.OpISubBorrow: return new ISubBorrow();
                case Op.OpUMulExtended: return new UMulExtended();
                case Op.OpSMulExtended: return new SMulExtended();
                case Op.OpAny: return new Any();
                case Op.OpAll: return new All();
                case Op.OpIsNan: return new IsNan();
                case Op.OpIsInf: return new IsInf();
                case Op.OpIsFinite: return new IsFinite();
                case Op.OpIsNormal: return new IsNormal();
                case Op.OpSignBitSet: return new SignBitSet();
                case Op.OpLessOrGreater: return new LessOrGreater();
                case Op.OpOrdered: return new Ordered();
                case Op.OpUnordered: return new Unordered();
                case Op.OpLogicalEqual: return new LogicalEqual();
                case Op.OpLogicalNotEqual: return new LogicalNotEqual();
                case Op.OpLogicalOr: return new LogicalOr();
                case Op.OpLogicalAnd: return new LogicalAnd();
                case Op.OpLogicalNot: return new LogicalNot();
                case Op.OpSelect: return new Select();
                case Op.OpIEqual: return new IEqual();
                case Op.OpINotEqual: return new INotEqual();
                case Op.OpUGreaterThan: return new UGreaterThan();
                case Op.OpSGreaterThan: return new SGreaterThan();
                case Op.OpUGreaterThanEqual: return new UGreaterThanEqual();
                case Op.OpSGreaterThanEqual: return new SGreaterThanEqual();
                case Op.OpULessThan: return new ULessThan();
                case Op.OpSLessThan: return new SLessThan();
                case Op.OpULessThanEqual: return new ULessThanEqual();
                case Op.OpSLessThanEqual: return new SLessThanEqual();
                case Op.OpFOrdEqual: return new FOrdEqual();
                case Op.OpFUnordEqual: return new FUnordEqual();
                case Op.OpFOrdNotEqual: return new FOrdNotEqual();
                case Op.OpFUnordNotEqual: return new FUnordNotEqual();
                case Op.OpFOrdLessThan: return new FOrdLessThan();
                case Op.OpFUnordLessThan: return new FUnordLessThan();
                case Op.OpFOrdGreaterThan: return new FOrdGreaterThan();
                case Op.OpFUnordGreaterThan: return new FUnordGreaterThan();
                case Op.OpFOrdLessThanEqual: return new FOrdLessThanEqual();
                case Op.OpFUnordLessThanEqual: return new FUnordLessThanEqual();
                case Op.OpFOrdGreaterThanEqual: return new FOrdGreaterThanEqual();
                case Op.OpFUnordGreaterThanEqual: return new FUnordGreaterThanEqual();
                case Op.OpShiftRightLogical: return new ShiftRightLogical();
                case Op.OpShiftRightArithmetic: return new ShiftRightArithmetic();
                case Op.OpShiftLeftLogical: return new ShiftLeftLogical();
                case Op.OpBitwiseOr: return new BitwiseOr();
                case Op.OpBitwiseXor: return new BitwiseXor();
                case Op.OpBitwiseAnd: return new BitwiseAnd();
                case Op.OpNot: return new Not();
                case Op.OpBitFieldInsert: return new BitFieldInsert();
                case Op.OpBitFieldSExtract: return new BitFieldSExtract();
                case Op.OpBitFieldUExtract: return new BitFieldUExtract();
                case Op.OpBitReverse: return new BitReverse();
                case Op.OpBitCount: return new BitCount();
                case Op.OpDPdx: return new DPdx();
                case Op.OpDPdy: return new DPdy();
                case Op.OpFwidth: return new Fwidth();
                case Op.OpDPdxFine: return new DPdxFine();
                case Op.OpDPdyFine: return new DPdyFine();
                case Op.OpFwidthFine: return new FwidthFine();
                case Op.OpDPdxCoarse: return new DPdxCoarse();
                case Op.OpDPdyCoarse: return new DPdyCoarse();
                case Op.OpFwidthCoarse: return new FwidthCoarse();
                case Op.OpEmitVertex: return new EmitVertex();
                case Op.OpEndPrimitive: return new EndPrimitive();
                case Op.OpEmitStreamVertex: return new EmitStreamVertex();
                case Op.OpEndStreamPrimitive: return new EndStreamPrimitive();
                case Op.OpControlBarrier: return new ControlBarrier();
                case Op.OpMemoryBarrier: return new MemoryBarrier();
                case Op.OpAtomicLoad: return new AtomicLoad();
                case Op.OpAtomicStore: return new AtomicStore();
                case Op.OpAtomicExchange: return new AtomicExchange();
                case Op.OpAtomicCompareExchange: return new AtomicCompareExchange();
                case Op.OpAtomicCompareExchangeWeak: return new AtomicCompareExchangeWeak();
                case Op.OpAtomicIIncrement: return new AtomicIIncrement();
                case Op.OpAtomicIDecrement: return new AtomicIDecrement();
                case Op.OpAtomicIAdd: return new AtomicIAdd();
                case Op.OpAtomicISub: return new AtomicISub();
                case Op.OpAtomicSMin: return new AtomicSMin();
                case Op.OpAtomicUMin: return new AtomicUMin();
                case Op.OpAtomicSMax: return new AtomicSMax();
                case Op.OpAtomicUMax: return new AtomicUMax();
                case Op.OpAtomicAnd: return new AtomicAnd();
                case Op.OpAtomicOr: return new AtomicOr();
                case Op.OpAtomicXor: return new AtomicXor();
                case Op.OpPhi: return new Phi();
                case Op.OpLoopMerge: return new LoopMerge();
                case Op.OpSelectionMerge: return new SelectionMerge();
                case Op.OpLabel: return new Label();
                case Op.OpBranch: return new Branch();
                case Op.OpBranchConditional: return new BranchConditional();
                case Op.OpSwitch: return new Switch();
                case Op.OpKill: return new Kill();
                case Op.OpReturn: return new Return();
                case Op.OpReturnValue: return new ReturnValue();
                case Op.OpUnreachable: return new Unreachable();
                case Op.OpLifetimeStart: return new LifetimeStart();
                case Op.OpLifetimeStop: return new LifetimeStop();
                case Op.OpGroupAsyncCopy: return new GroupAsyncCopy();
                case Op.OpGroupWaitEvents: return new GroupWaitEvents();
                case Op.OpGroupAll: return new GroupAll();
                case Op.OpGroupAny: return new GroupAny();
                case Op.OpGroupBroadcast: return new GroupBroadcast();
                case Op.OpGroupIAdd: return new GroupIAdd();
                case Op.OpGroupFAdd: return new GroupFAdd();
                case Op.OpGroupFMin: return new GroupFMin();
                case Op.OpGroupUMin: return new GroupUMin();
                case Op.OpGroupSMin: return new GroupSMin();
                case Op.OpGroupFMax: return new GroupFMax();
                case Op.OpGroupUMax: return new GroupUMax();
                case Op.OpGroupSMax: return new GroupSMax();
                case Op.OpReadPipe: return new ReadPipe();
                case Op.OpWritePipe: return new WritePipe();
                case Op.OpReservedReadPipe: return new ReservedReadPipe();
                case Op.OpReservedWritePipe: return new ReservedWritePipe();
                case Op.OpReserveReadPipePackets: return new ReserveReadPipePackets();
                case Op.OpReserveWritePipePackets: return new ReserveWritePipePackets();
                case Op.OpCommitReadPipe: return new CommitReadPipe();
                case Op.OpCommitWritePipe: return new CommitWritePipe();
                case Op.OpIsValidReserveId: return new IsValidReserveId();
                case Op.OpGetNumPipePackets: return new GetNumPipePackets();
                case Op.OpGetMaxPipePackets: return new GetMaxPipePackets();
                case Op.OpGroupReserveReadPipePackets: return new GroupReserveReadPipePackets();
                case Op.OpGroupReserveWritePipePackets: return new GroupReserveWritePipePackets();
                case Op.OpGroupCommitReadPipe: return new GroupCommitReadPipe();
                case Op.OpGroupCommitWritePipe: return new GroupCommitWritePipe();
                case Op.OpEnqueueMarker: return new EnqueueMarker();
                case Op.OpEnqueueKernel: return new EnqueueKernel();
                case Op.OpGetKernelNDrangeSubGroupCount: return new GetKernelNDrangeSubGroupCount();
                case Op.OpGetKernelNDrangeMaxSubGroupSize: return new GetKernelNDrangeMaxSubGroupSize();
                case Op.OpGetKernelWorkGroupSize: return new GetKernelWorkGroupSize();
                case Op.OpGetKernelPreferredWorkGroupSizeMultiple: return new GetKernelPreferredWorkGroupSizeMultiple();
                case Op.OpRetainEvent: return new RetainEvent();
                case Op.OpReleaseEvent: return new ReleaseEvent();
                case Op.OpCreateUserEvent: return new CreateUserEvent();
                case Op.OpIsValidEvent: return new IsValidEvent();
                case Op.OpSetUserEventStatus: return new SetUserEventStatus();
                case Op.OpCaptureEventProfilingInfo: return new CaptureEventProfilingInfo();
                case Op.OpGetDefaultQueue: return new GetDefaultQueue();
                case Op.OpBuildNDRange: return new BuildNDRange();
                case Op.OpImageSparseSampleImplicitLod: return new ImageSparseSampleImplicitLod();
                case Op.OpImageSparseSampleExplicitLod: return new ImageSparseSampleExplicitLod();
                case Op.OpImageSparseSampleDrefImplicitLod: return new ImageSparseSampleDrefImplicitLod();
                case Op.OpImageSparseSampleDrefExplicitLod: return new ImageSparseSampleDrefExplicitLod();
                case Op.OpImageSparseSampleProjImplicitLod: return new ImageSparseSampleProjImplicitLod();
                case Op.OpImageSparseSampleProjExplicitLod: return new ImageSparseSampleProjExplicitLod();
                case Op.OpImageSparseSampleProjDrefImplicitLod: return new ImageSparseSampleProjDrefImplicitLod();
                case Op.OpImageSparseSampleProjDrefExplicitLod: return new ImageSparseSampleProjDrefExplicitLod();
                case Op.OpImageSparseFetch: return new ImageSparseFetch();
                case Op.OpImageSparseGather: return new ImageSparseGather();
                case Op.OpImageSparseDrefGather: return new ImageSparseDrefGather();
                case Op.OpImageSparseTexelsResident: return new ImageSparseTexelsResident();
                case Op.OpNoLine: return new NoLine();
                case Op.OpAtomicFlagTestAndSet: return new AtomicFlagTestAndSet();
                case Op.OpAtomicFlagClear: return new AtomicFlagClear();
                case Op.OpImageSparseRead: return new ImageSparseRead();
                case Op.OpDecorateId: return new DecorateId();
                case Op.OpSubgroupBallotKHR: return new SubgroupBallotKHR();
                case Op.OpSubgroupFirstInvocationKHR: return new SubgroupFirstInvocationKHR();
                case Op.OpSubgroupAllKHR: return new SubgroupAllKHR();
                case Op.OpSubgroupAnyKHR: return new SubgroupAnyKHR();
                case Op.OpSubgroupAllEqualKHR: return new SubgroupAllEqualKHR();
                case Op.OpSubgroupReadInvocationKHR: return new SubgroupReadInvocationKHR();
                case Op.OpGroupIAddNonUniformAMD: return new GroupIAddNonUniformAMD();
                case Op.OpGroupFAddNonUniformAMD: return new GroupFAddNonUniformAMD();
                case Op.OpGroupFMinNonUniformAMD: return new GroupFMinNonUniformAMD();
                case Op.OpGroupUMinNonUniformAMD: return new GroupUMinNonUniformAMD();
                case Op.OpGroupSMinNonUniformAMD: return new GroupSMinNonUniformAMD();
                case Op.OpGroupFMaxNonUniformAMD: return new GroupFMaxNonUniformAMD();
                case Op.OpGroupUMaxNonUniformAMD: return new GroupUMaxNonUniformAMD();
                case Op.OpGroupSMaxNonUniformAMD: return new GroupSMaxNonUniformAMD();
                case Op.OpFragmentMaskFetchAMD: return new FragmentMaskFetchAMD();
                case Op.OpFragmentFetchAMD: return new FragmentFetchAMD();
                case Op.OpSubgroupShuffleINTEL: return new SubgroupShuffleINTEL();
                case Op.OpSubgroupShuffleDownINTEL: return new SubgroupShuffleDownINTEL();
                case Op.OpSubgroupShuffleUpINTEL: return new SubgroupShuffleUpINTEL();
                case Op.OpSubgroupShuffleXorINTEL: return new SubgroupShuffleXorINTEL();
                case Op.OpSubgroupBlockReadINTEL: return new SubgroupBlockReadINTEL();
                case Op.OpSubgroupBlockWriteINTEL: return new SubgroupBlockWriteINTEL();
                case Op.OpSubgroupImageBlockReadINTEL: return new SubgroupImageBlockReadINTEL();
                case Op.OpSubgroupImageBlockWriteINTEL: return new SubgroupImageBlockWriteINTEL();
                case Op.OpDecorateStringGOOGLE: return new DecorateStringGOOGLE();
                case Op.OpMemberDecorateStringGOOGLE: return new MemberDecorateStringGOOGLE();
                case Op.OpLine: return null;
                default:
                    throw new NotImplementedException(instruction + " not implemented");
            }
        }

        public abstract void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder);
    }
}
