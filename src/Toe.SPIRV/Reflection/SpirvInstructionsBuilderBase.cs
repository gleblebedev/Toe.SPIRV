using System;
using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvInstructionsBuilderBase
    {
        protected readonly List<InstructionWithId> _results = new List<InstructionWithId>();

        protected readonly Dictionary<ReflectedInstruction, Instruction> _instructionMap =
            new Dictionary<ReflectedInstruction, Instruction>();

        protected virtual Instruction Visit(ReflectedInstruction node)
        {
            if (_instructionMap.TryGetValue(node, out var instruction)) return instruction;
            switch (node.OpCode)
            {
                case Op.OpNop: return VisitNop(node);
                case Op.OpUndef: return VisitUndef((Undef)node);
                case Op.OpSourceContinued: return VisitSourceContinued(node);
                case Op.OpSource: return VisitSource(node);
                case Op.OpSourceExtension: return VisitSourceExtension(node);
                case Op.OpName: return VisitName(node);
                case Op.OpMemberName: return VisitMemberName(node);
                case Op.OpString: return VisitString(node);
                case Op.OpLine: return VisitLine(node);
                case Op.OpExtension: return VisitExtension(node);
                case Op.OpExtInstImport: return VisitExtInstImport(node);
                case Op.OpExtInst: return VisitExtInst((ExtInst)node);
                case Op.OpMemoryModel: return VisitMemoryModel(node);
                case Op.OpEntryPoint: return VisitEntryPoint(node);
                case Op.OpExecutionMode: return VisitExecutionMode(node);
                case Op.OpCapability: return VisitCapability(node);
                case Op.OpTypeVoid: return VisitTypeVoid(node);
                case Op.OpTypeBool: return VisitTypeBool(node);
                case Op.OpTypeInt: return VisitTypeInt(node);
                case Op.OpTypeFloat: return VisitTypeFloat(node);
                case Op.OpTypeVector: return VisitTypeVector(node);
                case Op.OpTypeMatrix: return VisitTypeMatrix(node);
                case Op.OpTypeImage: return VisitTypeImage(node);
                case Op.OpTypeSampler: return VisitTypeSampler(node);
                case Op.OpTypeSampledImage: return VisitTypeSampledImage(node);
                case Op.OpTypeArray: return VisitTypeArray(node);
                case Op.OpTypeRuntimeArray: return VisitTypeRuntimeArray(node);
                case Op.OpTypeStruct: return VisitTypeStruct(node);
                case Op.OpTypeOpaque: return VisitTypeOpaque(node);
                case Op.OpTypePointer: return VisitTypePointer(node);
                case Op.OpTypeFunction: return VisitTypeFunction(node);
                case Op.OpTypeEvent: return VisitTypeEvent(node);
                case Op.OpTypeDeviceEvent: return VisitTypeDeviceEvent(node);
                case Op.OpTypeReserveId: return VisitTypeReserveId(node);
                case Op.OpTypeQueue: return VisitTypeQueue(node);
                case Op.OpTypePipe: return VisitTypePipe(node);
                case Op.OpTypeForwardPointer: return VisitTypeForwardPointer(node);
                case Op.OpConstantTrue: return VisitConstantTrue((ConstantTrue)node);
                case Op.OpConstantFalse: return VisitConstantFalse((ConstantFalse)node);
                case Op.OpConstant: return VisitConstant((Constant)node);
                case Op.OpConstantComposite: return VisitConstantComposite((ConstantComposite)node);
                case Op.OpConstantSampler: return VisitConstantSampler((ConstantSampler)node);
                case Op.OpConstantNull: return VisitConstantNull((ConstantNull)node);
                case Op.OpSpecConstantTrue: return VisitSpecConstantTrue((SpecConstantTrue)node);
                case Op.OpSpecConstantFalse: return VisitSpecConstantFalse((SpecConstantFalse)node);
                case Op.OpSpecConstant: return VisitSpecConstant((SpecConstant)node);
                case Op.OpSpecConstantComposite: return VisitSpecConstantComposite((SpecConstantComposite)node);
                case Op.OpSpecConstantOp: return VisitSpecConstantOp((SpecConstantOp)node);
                case Op.OpFunction: return VisitFunction((Function)node);
                case Op.OpFunctionParameter: return VisitFunctionParameter((FunctionParameter)node);
                case Op.OpFunctionEnd: return VisitFunctionEnd((FunctionEnd)node);
                case Op.OpFunctionCall: return VisitFunctionCall((FunctionCall)node);
                case Op.OpVariable: return VisitVariable((Variable)node);
                case Op.OpImageTexelPointer: return VisitImageTexelPointer((ImageTexelPointer)node);
                case Op.OpLoad: return VisitLoad((Load)node);
                case Op.OpStore: return VisitStore((Store)node);
                case Op.OpCopyMemory: return VisitCopyMemory((CopyMemory)node);
                case Op.OpCopyMemorySized: return VisitCopyMemorySized((CopyMemorySized)node);
                case Op.OpAccessChain: return VisitAccessChain((AccessChain)node);
                case Op.OpInBoundsAccessChain: return VisitInBoundsAccessChain((InBoundsAccessChain)node);
                case Op.OpPtrAccessChain: return VisitPtrAccessChain((PtrAccessChain)node);
                case Op.OpArrayLength: return VisitArrayLength((ArrayLength)node);
                case Op.OpGenericPtrMemSemantics: return VisitGenericPtrMemSemantics((GenericPtrMemSemantics)node);
                case Op.OpInBoundsPtrAccessChain: return VisitInBoundsPtrAccessChain((InBoundsPtrAccessChain)node);
                case Op.OpDecorate: return VisitDecorate((Decorate)node);
                case Op.OpMemberDecorate: return VisitMemberDecorate((MemberDecorate)node);
                case Op.OpDecorationGroup: return VisitDecorationGroup((DecorationGroup)node);
                case Op.OpGroupDecorate: return VisitGroupDecorate((GroupDecorate)node);
                case Op.OpGroupMemberDecorate: return VisitGroupMemberDecorate((GroupMemberDecorate)node);
                case Op.OpVectorExtractDynamic: return VisitVectorExtractDynamic((VectorExtractDynamic)node);
                case Op.OpVectorInsertDynamic: return VisitVectorInsertDynamic((VectorInsertDynamic)node);
                case Op.OpVectorShuffle: return VisitVectorShuffle((VectorShuffle)node);
                case Op.OpCompositeConstruct: return VisitCompositeConstruct((CompositeConstruct)node);
                case Op.OpCompositeExtract: return VisitCompositeExtract((CompositeExtract)node);
                case Op.OpCompositeInsert: return VisitCompositeInsert((CompositeInsert)node);
                case Op.OpCopyObject: return VisitCopyObject((CopyObject)node);
                case Op.OpTranspose: return VisitTranspose((Transpose)node);
                case Op.OpSampledImage: return VisitSampledImage((SampledImage)node);
                case Op.OpImageSampleImplicitLod: return VisitImageSampleImplicitLod((ImageSampleImplicitLod)node);
                case Op.OpImageSampleExplicitLod: return VisitImageSampleExplicitLod((ImageSampleExplicitLod)node);
                case Op.OpImageSampleDrefImplicitLod: return VisitImageSampleDrefImplicitLod((ImageSampleDrefImplicitLod)node);
                case Op.OpImageSampleDrefExplicitLod: return VisitImageSampleDrefExplicitLod((ImageSampleDrefExplicitLod)node);
                case Op.OpImageSampleProjImplicitLod: return VisitImageSampleProjImplicitLod((ImageSampleProjImplicitLod)node);
                case Op.OpImageSampleProjExplicitLod: return VisitImageSampleProjExplicitLod((ImageSampleProjExplicitLod)node);
                case Op.OpImageSampleProjDrefImplicitLod: return VisitImageSampleProjDrefImplicitLod((ImageSampleProjDrefImplicitLod)node);
                case Op.OpImageSampleProjDrefExplicitLod: return VisitImageSampleProjDrefExplicitLod((ImageSampleProjDrefExplicitLod)node);
                case Op.OpImageFetch: return VisitImageFetch((ImageFetch)node);
                case Op.OpImageGather: return VisitImageGather((ImageGather)node);
                case Op.OpImageDrefGather: return VisitImageDrefGather((ImageDrefGather)node);
                case Op.OpImageRead: return VisitImageRead((ImageRead)node);
                case Op.OpImageWrite: return VisitImageWrite((ImageWrite)node);
                case Op.OpImage: return VisitImage((Image)node);
                case Op.OpImageQueryFormat: return VisitImageQueryFormat((ImageQueryFormat)node);
                case Op.OpImageQueryOrder: return VisitImageQueryOrder((ImageQueryOrder)node);
                case Op.OpImageQuerySizeLod: return VisitImageQuerySizeLod((ImageQuerySizeLod)node);
                case Op.OpImageQuerySize: return VisitImageQuerySize((ImageQuerySize)node);
                case Op.OpImageQueryLod: return VisitImageQueryLod((ImageQueryLod)node);
                case Op.OpImageQueryLevels: return VisitImageQueryLevels((ImageQueryLevels)node);
                case Op.OpImageQuerySamples: return VisitImageQuerySamples((ImageQuerySamples)node);
                case Op.OpConvertFToU: return VisitConvertFToU((ConvertFToU)node);
                case Op.OpConvertFToS: return VisitConvertFToS((ConvertFToS)node);
                case Op.OpConvertSToF: return VisitConvertSToF((ConvertSToF)node);
                case Op.OpConvertUToF: return VisitConvertUToF((ConvertUToF)node);
                case Op.OpUConvert: return VisitUConvert((UConvert)node);
                case Op.OpSConvert: return VisitSConvert((SConvert)node);
                case Op.OpFConvert: return VisitFConvert((FConvert)node);
                case Op.OpQuantizeToF16: return VisitQuantizeToF16((QuantizeToF16)node);
                case Op.OpConvertPtrToU: return VisitConvertPtrToU((ConvertPtrToU)node);
                case Op.OpSatConvertSToU: return VisitSatConvertSToU((SatConvertSToU)node);
                case Op.OpSatConvertUToS: return VisitSatConvertUToS((SatConvertUToS)node);
                case Op.OpConvertUToPtr: return VisitConvertUToPtr((ConvertUToPtr)node);
                case Op.OpPtrCastToGeneric: return VisitPtrCastToGeneric((PtrCastToGeneric)node);
                case Op.OpGenericCastToPtr: return VisitGenericCastToPtr((GenericCastToPtr)node);
                case Op.OpGenericCastToPtrExplicit: return VisitGenericCastToPtrExplicit((GenericCastToPtrExplicit)node);
                case Op.OpBitcast: return VisitBitcast((Bitcast)node);
                case Op.OpSNegate: return VisitSNegate((SNegate)node);
                case Op.OpFNegate: return VisitFNegate((FNegate)node);
                case Op.OpIAdd: return VisitIAdd((IAdd)node);
                case Op.OpFAdd: return VisitFAdd((FAdd)node);
                case Op.OpISub: return VisitISub((ISub)node);
                case Op.OpFSub: return VisitFSub((FSub)node);
                case Op.OpIMul: return VisitIMul((IMul)node);
                case Op.OpFMul: return VisitFMul((FMul)node);
                case Op.OpUDiv: return VisitUDiv((UDiv)node);
                case Op.OpSDiv: return VisitSDiv((SDiv)node);
                case Op.OpFDiv: return VisitFDiv((FDiv)node);
                case Op.OpUMod: return VisitUMod((UMod)node);
                case Op.OpSRem: return VisitSRem((SRem)node);
                case Op.OpSMod: return VisitSMod((SMod)node);
                case Op.OpFRem: return VisitFRem((FRem)node);
                case Op.OpFMod: return VisitFMod((FMod)node);
                case Op.OpVectorTimesScalar: return VisitVectorTimesScalar((VectorTimesScalar)node);
                case Op.OpMatrixTimesScalar: return VisitMatrixTimesScalar((MatrixTimesScalar)node);
                case Op.OpVectorTimesMatrix: return VisitVectorTimesMatrix((VectorTimesMatrix)node);
                case Op.OpMatrixTimesVector: return VisitMatrixTimesVector((MatrixTimesVector)node);
                case Op.OpMatrixTimesMatrix: return VisitMatrixTimesMatrix((MatrixTimesMatrix)node);
                case Op.OpOuterProduct: return VisitOuterProduct((OuterProduct)node);
                case Op.OpDot: return VisitDot((Dot)node);
                case Op.OpIAddCarry: return VisitIAddCarry((IAddCarry)node);
                case Op.OpISubBorrow: return VisitISubBorrow((ISubBorrow)node);
                case Op.OpUMulExtended: return VisitUMulExtended((UMulExtended)node);
                case Op.OpSMulExtended: return VisitSMulExtended((SMulExtended)node);
                case Op.OpAny: return VisitAny((Any)node);
                case Op.OpAll: return VisitAll((All)node);
                case Op.OpIsNan: return VisitIsNan((IsNan)node);
                case Op.OpIsInf: return VisitIsInf((IsInf)node);
                case Op.OpIsFinite: return VisitIsFinite((IsFinite)node);
                case Op.OpIsNormal: return VisitIsNormal((IsNormal)node);
                case Op.OpSignBitSet: return VisitSignBitSet((SignBitSet)node);
                case Op.OpLessOrGreater: return VisitLessOrGreater((LessOrGreater)node);
                case Op.OpOrdered: return VisitOrdered((Ordered)node);
                case Op.OpUnordered: return VisitUnordered((Unordered)node);
                case Op.OpLogicalEqual: return VisitLogicalEqual((LogicalEqual)node);
                case Op.OpLogicalNotEqual: return VisitLogicalNotEqual((LogicalNotEqual)node);
                case Op.OpLogicalOr: return VisitLogicalOr((LogicalOr)node);
                case Op.OpLogicalAnd: return VisitLogicalAnd((LogicalAnd)node);
                case Op.OpLogicalNot: return VisitLogicalNot((LogicalNot)node);
                case Op.OpSelect: return VisitSelect((Select)node);
                case Op.OpIEqual: return VisitIEqual((IEqual)node);
                case Op.OpINotEqual: return VisitINotEqual((INotEqual)node);
                case Op.OpUGreaterThan: return VisitUGreaterThan((UGreaterThan)node);
                case Op.OpSGreaterThan: return VisitSGreaterThan((SGreaterThan)node);
                case Op.OpUGreaterThanEqual: return VisitUGreaterThanEqual((UGreaterThanEqual)node);
                case Op.OpSGreaterThanEqual: return VisitSGreaterThanEqual((SGreaterThanEqual)node);
                case Op.OpULessThan: return VisitULessThan((ULessThan)node);
                case Op.OpSLessThan: return VisitSLessThan((SLessThan)node);
                case Op.OpULessThanEqual: return VisitULessThanEqual((ULessThanEqual)node);
                case Op.OpSLessThanEqual: return VisitSLessThanEqual((SLessThanEqual)node);
                case Op.OpFOrdEqual: return VisitFOrdEqual((FOrdEqual)node);
                case Op.OpFUnordEqual: return VisitFUnordEqual((FUnordEqual)node);
                case Op.OpFOrdNotEqual: return VisitFOrdNotEqual((FOrdNotEqual)node);
                case Op.OpFUnordNotEqual: return VisitFUnordNotEqual((FUnordNotEqual)node);
                case Op.OpFOrdLessThan: return VisitFOrdLessThan((FOrdLessThan)node);
                case Op.OpFUnordLessThan: return VisitFUnordLessThan((FUnordLessThan)node);
                case Op.OpFOrdGreaterThan: return VisitFOrdGreaterThan((FOrdGreaterThan)node);
                case Op.OpFUnordGreaterThan: return VisitFUnordGreaterThan((FUnordGreaterThan)node);
                case Op.OpFOrdLessThanEqual: return VisitFOrdLessThanEqual((FOrdLessThanEqual)node);
                case Op.OpFUnordLessThanEqual: return VisitFUnordLessThanEqual((FUnordLessThanEqual)node);
                case Op.OpFOrdGreaterThanEqual: return VisitFOrdGreaterThanEqual((FOrdGreaterThanEqual)node);
                case Op.OpFUnordGreaterThanEqual: return VisitFUnordGreaterThanEqual((FUnordGreaterThanEqual)node);
                case Op.OpShiftRightLogical: return VisitShiftRightLogical((ShiftRightLogical)node);
                case Op.OpShiftRightArithmetic: return VisitShiftRightArithmetic((ShiftRightArithmetic)node);
                case Op.OpShiftLeftLogical: return VisitShiftLeftLogical((ShiftLeftLogical)node);
                case Op.OpBitwiseOr: return VisitBitwiseOr((BitwiseOr)node);
                case Op.OpBitwiseXor: return VisitBitwiseXor((BitwiseXor)node);
                case Op.OpBitwiseAnd: return VisitBitwiseAnd((BitwiseAnd)node);
                case Op.OpNot: return VisitNot((Not)node);
                case Op.OpBitFieldInsert: return VisitBitFieldInsert((BitFieldInsert)node);
                case Op.OpBitFieldSExtract: return VisitBitFieldSExtract((BitFieldSExtract)node);
                case Op.OpBitFieldUExtract: return VisitBitFieldUExtract((BitFieldUExtract)node);
                case Op.OpBitReverse: return VisitBitReverse((BitReverse)node);
                case Op.OpBitCount: return VisitBitCount((BitCount)node);
                case Op.OpDPdx: return VisitDPdx((DPdx)node);
                case Op.OpDPdy: return VisitDPdy((DPdy)node);
                case Op.OpFwidth: return VisitFwidth((Fwidth)node);
                case Op.OpDPdxFine: return VisitDPdxFine((DPdxFine)node);
                case Op.OpDPdyFine: return VisitDPdyFine((DPdyFine)node);
                case Op.OpFwidthFine: return VisitFwidthFine((FwidthFine)node);
                case Op.OpDPdxCoarse: return VisitDPdxCoarse((DPdxCoarse)node);
                case Op.OpDPdyCoarse: return VisitDPdyCoarse((DPdyCoarse)node);
                case Op.OpFwidthCoarse: return VisitFwidthCoarse((FwidthCoarse)node);
                case Op.OpEmitVertex: return VisitEmitVertex((EmitVertex)node);
                case Op.OpEndPrimitive: return VisitEndPrimitive((EndPrimitive)node);
                case Op.OpEmitStreamVertex: return VisitEmitStreamVertex((EmitStreamVertex)node);
                case Op.OpEndStreamPrimitive: return VisitEndStreamPrimitive((EndStreamPrimitive)node);
                case Op.OpControlBarrier: return VisitControlBarrier((ControlBarrier)node);
                case Op.OpMemoryBarrier: return VisitMemoryBarrier((MemoryBarrier)node);
                case Op.OpAtomicLoad: return VisitAtomicLoad((AtomicLoad)node);
                case Op.OpAtomicStore: return VisitAtomicStore((AtomicStore)node);
                case Op.OpAtomicExchange: return VisitAtomicExchange((AtomicExchange)node);
                case Op.OpAtomicCompareExchange: return VisitAtomicCompareExchange((AtomicCompareExchange)node);
                case Op.OpAtomicCompareExchangeWeak: return VisitAtomicCompareExchangeWeak((AtomicCompareExchangeWeak)node);
                case Op.OpAtomicIIncrement: return VisitAtomicIIncrement((AtomicIIncrement)node);
                case Op.OpAtomicIDecrement: return VisitAtomicIDecrement((AtomicIDecrement)node);
                case Op.OpAtomicIAdd: return VisitAtomicIAdd((AtomicIAdd)node);
                case Op.OpAtomicISub: return VisitAtomicISub((AtomicISub)node);
                case Op.OpAtomicSMin: return VisitAtomicSMin((AtomicSMin)node);
                case Op.OpAtomicUMin: return VisitAtomicUMin((AtomicUMin)node);
                case Op.OpAtomicSMax: return VisitAtomicSMax((AtomicSMax)node);
                case Op.OpAtomicUMax: return VisitAtomicUMax((AtomicUMax)node);
                case Op.OpAtomicAnd: return VisitAtomicAnd((AtomicAnd)node);
                case Op.OpAtomicOr: return VisitAtomicOr((AtomicOr)node);
                case Op.OpAtomicXor: return VisitAtomicXor((AtomicXor)node);
                case Op.OpPhi: return VisitPhi((Phi)node);
                case Op.OpLoopMerge: return VisitLoopMerge((LoopMerge)node);
                case Op.OpSelectionMerge: return VisitSelectionMerge((SelectionMerge)node);
                case Op.OpLabel: return VisitLabel((Label)node);
                case Op.OpBranch: return VisitBranch((Branch)node);
                case Op.OpBranchConditional: return VisitBranchConditional((BranchConditional)node);
                case Op.OpSwitch: return VisitSwitch((Switch)node);
                case Op.OpKill: return VisitKill((Kill)node);
                case Op.OpReturn: return VisitReturn((Return)node);
                case Op.OpReturnValue: return VisitReturnValue((ReturnValue)node);
                case Op.OpUnreachable: return VisitUnreachable((Unreachable)node);
                case Op.OpLifetimeStart: return VisitLifetimeStart((LifetimeStart)node);
                case Op.OpLifetimeStop: return VisitLifetimeStop((LifetimeStop)node);
                case Op.OpGroupAsyncCopy: return VisitGroupAsyncCopy((GroupAsyncCopy)node);
                case Op.OpGroupWaitEvents: return VisitGroupWaitEvents((GroupWaitEvents)node);
                case Op.OpGroupAll: return VisitGroupAll((GroupAll)node);
                case Op.OpGroupAny: return VisitGroupAny((GroupAny)node);
                case Op.OpGroupBroadcast: return VisitGroupBroadcast((GroupBroadcast)node);
                case Op.OpGroupIAdd: return VisitGroupIAdd((GroupIAdd)node);
                case Op.OpGroupFAdd: return VisitGroupFAdd((GroupFAdd)node);
                case Op.OpGroupFMin: return VisitGroupFMin((GroupFMin)node);
                case Op.OpGroupUMin: return VisitGroupUMin((GroupUMin)node);
                case Op.OpGroupSMin: return VisitGroupSMin((GroupSMin)node);
                case Op.OpGroupFMax: return VisitGroupFMax((GroupFMax)node);
                case Op.OpGroupUMax: return VisitGroupUMax((GroupUMax)node);
                case Op.OpGroupSMax: return VisitGroupSMax((GroupSMax)node);
                case Op.OpReadPipe: return VisitReadPipe((ReadPipe)node);
                case Op.OpWritePipe: return VisitWritePipe((WritePipe)node);
                case Op.OpReservedReadPipe: return VisitReservedReadPipe((ReservedReadPipe)node);
                case Op.OpReservedWritePipe: return VisitReservedWritePipe((ReservedWritePipe)node);
                case Op.OpReserveReadPipePackets: return VisitReserveReadPipePackets((ReserveReadPipePackets)node);
                case Op.OpReserveWritePipePackets: return VisitReserveWritePipePackets((ReserveWritePipePackets)node);
                case Op.OpCommitReadPipe: return VisitCommitReadPipe((CommitReadPipe)node);
                case Op.OpCommitWritePipe: return VisitCommitWritePipe((CommitWritePipe)node);
                case Op.OpIsValidReserveId: return VisitIsValidReserveId((IsValidReserveId)node);
                case Op.OpGetNumPipePackets: return VisitGetNumPipePackets((GetNumPipePackets)node);
                case Op.OpGetMaxPipePackets: return VisitGetMaxPipePackets((GetMaxPipePackets)node);
                case Op.OpGroupReserveReadPipePackets: return VisitGroupReserveReadPipePackets((GroupReserveReadPipePackets)node);
                case Op.OpGroupReserveWritePipePackets: return VisitGroupReserveWritePipePackets((GroupReserveWritePipePackets)node);
                case Op.OpGroupCommitReadPipe: return VisitGroupCommitReadPipe((GroupCommitReadPipe)node);
                case Op.OpGroupCommitWritePipe: return VisitGroupCommitWritePipe((GroupCommitWritePipe)node);
                case Op.OpEnqueueMarker: return VisitEnqueueMarker((EnqueueMarker)node);
                case Op.OpEnqueueKernel: return VisitEnqueueKernel((EnqueueKernel)node);
                case Op.OpGetKernelNDrangeSubGroupCount: return VisitGetKernelNDrangeSubGroupCount((GetKernelNDrangeSubGroupCount)node);
                case Op.OpGetKernelNDrangeMaxSubGroupSize: return VisitGetKernelNDrangeMaxSubGroupSize((GetKernelNDrangeMaxSubGroupSize)node);
                case Op.OpGetKernelWorkGroupSize: return VisitGetKernelWorkGroupSize((GetKernelWorkGroupSize)node);
                case Op.OpGetKernelPreferredWorkGroupSizeMultiple: return VisitGetKernelPreferredWorkGroupSizeMultiple((GetKernelPreferredWorkGroupSizeMultiple)node);
                case Op.OpRetainEvent: return VisitRetainEvent((RetainEvent)node);
                case Op.OpReleaseEvent: return VisitReleaseEvent((ReleaseEvent)node);
                case Op.OpCreateUserEvent: return VisitCreateUserEvent((CreateUserEvent)node);
                case Op.OpIsValidEvent: return VisitIsValidEvent((IsValidEvent)node);
                case Op.OpSetUserEventStatus: return VisitSetUserEventStatus((SetUserEventStatus)node);
                case Op.OpCaptureEventProfilingInfo: return VisitCaptureEventProfilingInfo((CaptureEventProfilingInfo)node);
                case Op.OpGetDefaultQueue: return VisitGetDefaultQueue((GetDefaultQueue)node);
                case Op.OpBuildNDRange: return VisitBuildNDRange((BuildNDRange)node);
                case Op.OpImageSparseSampleImplicitLod: return VisitImageSparseSampleImplicitLod((ImageSparseSampleImplicitLod)node);
                case Op.OpImageSparseSampleExplicitLod: return VisitImageSparseSampleExplicitLod((ImageSparseSampleExplicitLod)node);
                case Op.OpImageSparseSampleDrefImplicitLod: return VisitImageSparseSampleDrefImplicitLod((ImageSparseSampleDrefImplicitLod)node);
                case Op.OpImageSparseSampleDrefExplicitLod: return VisitImageSparseSampleDrefExplicitLod((ImageSparseSampleDrefExplicitLod)node);
                case Op.OpImageSparseSampleProjImplicitLod: return VisitImageSparseSampleProjImplicitLod((ImageSparseSampleProjImplicitLod)node);
                case Op.OpImageSparseSampleProjExplicitLod: return VisitImageSparseSampleProjExplicitLod((ImageSparseSampleProjExplicitLod)node);
                case Op.OpImageSparseSampleProjDrefImplicitLod: return VisitImageSparseSampleProjDrefImplicitLod((ImageSparseSampleProjDrefImplicitLod)node);
                case Op.OpImageSparseSampleProjDrefExplicitLod: return VisitImageSparseSampleProjDrefExplicitLod((ImageSparseSampleProjDrefExplicitLod)node);
                case Op.OpImageSparseFetch: return VisitImageSparseFetch((ImageSparseFetch)node);
                case Op.OpImageSparseGather: return VisitImageSparseGather((ImageSparseGather)node);
                case Op.OpImageSparseDrefGather: return VisitImageSparseDrefGather((ImageSparseDrefGather)node);
                case Op.OpImageSparseTexelsResident: return VisitImageSparseTexelsResident((ImageSparseTexelsResident)node);
                case Op.OpNoLine: return VisitNoLine((NoLine)node);
                case Op.OpAtomicFlagTestAndSet: return VisitAtomicFlagTestAndSet((AtomicFlagTestAndSet)node);
                case Op.OpAtomicFlagClear: return VisitAtomicFlagClear((AtomicFlagClear)node);
                case Op.OpImageSparseRead: return VisitImageSparseRead((ImageSparseRead)node);
                case Op.OpDecorateId: return VisitDecorateId((DecorateId)node);
                case Op.OpSubgroupBallotKHR: return VisitSubgroupBallotKHR((SubgroupBallotKHR)node);
                case Op.OpSubgroupFirstInvocationKHR: return VisitSubgroupFirstInvocationKHR((SubgroupFirstInvocationKHR)node);
                case Op.OpSubgroupAllKHR: return VisitSubgroupAllKHR((SubgroupAllKHR)node);
                case Op.OpSubgroupAnyKHR: return VisitSubgroupAnyKHR((SubgroupAnyKHR)node);
                case Op.OpSubgroupAllEqualKHR: return VisitSubgroupAllEqualKHR((SubgroupAllEqualKHR)node);
                case Op.OpSubgroupReadInvocationKHR: return VisitSubgroupReadInvocationKHR((SubgroupReadInvocationKHR)node);
                case Op.OpGroupIAddNonUniformAMD: return VisitGroupIAddNonUniformAMD((GroupIAddNonUniformAMD)node);
                case Op.OpGroupFAddNonUniformAMD: return VisitGroupFAddNonUniformAMD((GroupFAddNonUniformAMD)node);
                case Op.OpGroupFMinNonUniformAMD: return VisitGroupFMinNonUniformAMD((GroupFMinNonUniformAMD)node);
                case Op.OpGroupUMinNonUniformAMD: return VisitGroupUMinNonUniformAMD((GroupUMinNonUniformAMD)node);
                case Op.OpGroupSMinNonUniformAMD: return VisitGroupSMinNonUniformAMD((GroupSMinNonUniformAMD)node);
                case Op.OpGroupFMaxNonUniformAMD: return VisitGroupFMaxNonUniformAMD((GroupFMaxNonUniformAMD)node);
                case Op.OpGroupUMaxNonUniformAMD: return VisitGroupUMaxNonUniformAMD((GroupUMaxNonUniformAMD)node);
                case Op.OpGroupSMaxNonUniformAMD: return VisitGroupSMaxNonUniformAMD((GroupSMaxNonUniformAMD)node);
                case Op.OpFragmentMaskFetchAMD: return VisitFragmentMaskFetchAMD((FragmentMaskFetchAMD)node);
                case Op.OpFragmentFetchAMD: return VisitFragmentFetchAMD((FragmentFetchAMD)node);
                case Op.OpSubgroupShuffleINTEL: return VisitSubgroupShuffleINTEL((SubgroupShuffleINTEL)node);
                case Op.OpSubgroupShuffleDownINTEL: return VisitSubgroupShuffleDownINTEL((SubgroupShuffleDownINTEL)node);
                case Op.OpSubgroupShuffleUpINTEL: return VisitSubgroupShuffleUpINTEL((SubgroupShuffleUpINTEL)node);
                case Op.OpSubgroupShuffleXorINTEL: return VisitSubgroupShuffleXorINTEL((SubgroupShuffleXorINTEL)node);
                case Op.OpSubgroupBlockReadINTEL: return VisitSubgroupBlockReadINTEL((SubgroupBlockReadINTEL)node);
                case Op.OpSubgroupBlockWriteINTEL: return VisitSubgroupBlockWriteINTEL((SubgroupBlockWriteINTEL)node);
                case Op.OpSubgroupImageBlockReadINTEL: return VisitSubgroupImageBlockReadINTEL((SubgroupImageBlockReadINTEL)node);
                case Op.OpSubgroupImageBlockWriteINTEL: return VisitSubgroupImageBlockWriteINTEL((SubgroupImageBlockWriteINTEL)node);
                case Op.OpDecorateStringGOOGLE: return VisitDecorateStringGOOGLE((DecorateStringGOOGLE)node);
                case Op.OpMemberDecorateStringGOOGLE: return VisitMemberDecorateStringGOOGLE((MemberDecorateStringGOOGLE)node);
            }

            throw new NotImplementedException(node.OpCode + " not implemented yet.");
        }
        protected virtual OpNop VisitNop(ReflectedInstruction node)
        {
            var instruction = new OpNop();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpUndef VisitUndef(Undef node)
        {
            var instruction = new OpUndef();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSourceContinued VisitSourceContinued(ReflectedInstruction node)
        {
            var instruction = new OpSourceContinued();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpSource VisitSource(ReflectedInstruction node)
        {
            var instruction = new OpSource();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpSourceExtension VisitSourceExtension(ReflectedInstruction node)
        {
            var instruction = new OpSourceExtension();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpName VisitName(ReflectedInstruction node)
        {
            var instruction = new OpName();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpMemberName VisitMemberName(ReflectedInstruction node)
        {
            var instruction = new OpMemberName();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpString VisitString(ReflectedInstruction node)
        {
            var instruction = new OpString();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpLine VisitLine(ReflectedInstruction node)
        {
            var instruction = new OpLine();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpExtension VisitExtension(ReflectedInstruction node)
        {
            var instruction = new OpExtension();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpExtInstImport VisitExtInstImport(ReflectedInstruction node)
        {
            var instruction = new OpExtInstImport();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpExtInst VisitExtInst(ExtInst node)
        {
            var instruction = new OpExtInst();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpMemoryModel VisitMemoryModel(ReflectedInstruction node)
        {
            var instruction = new OpMemoryModel();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpEntryPoint VisitEntryPoint(ReflectedInstruction node)
        {
            var instruction = new OpEntryPoint();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpExecutionMode VisitExecutionMode(ReflectedInstruction node)
        {
            var instruction = new OpExecutionMode();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpCapability VisitCapability(ReflectedInstruction node)
        {
            var instruction = new OpCapability();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeVoid VisitTypeVoid(ReflectedInstruction node)
        {
            var instruction = new OpTypeVoid();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeBool VisitTypeBool(ReflectedInstruction node)
        {
            var instruction = new OpTypeBool();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeInt VisitTypeInt(ReflectedInstruction node)
        {
            var instruction = new OpTypeInt();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeFloat VisitTypeFloat(ReflectedInstruction node)
        {
            var instruction = new OpTypeFloat();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeVector VisitTypeVector(ReflectedInstruction node)
        {
            var instruction = new OpTypeVector();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeMatrix VisitTypeMatrix(ReflectedInstruction node)
        {
            var instruction = new OpTypeMatrix();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeImage VisitTypeImage(ReflectedInstruction node)
        {
            var instruction = new OpTypeImage();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeSampler VisitTypeSampler(ReflectedInstruction node)
        {
            var instruction = new OpTypeSampler();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeSampledImage VisitTypeSampledImage(ReflectedInstruction node)
        {
            var instruction = new OpTypeSampledImage();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeArray VisitTypeArray(ReflectedInstruction node)
        {
            var instruction = new OpTypeArray();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeRuntimeArray VisitTypeRuntimeArray(ReflectedInstruction node)
        {
            var instruction = new OpTypeRuntimeArray();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeStruct VisitTypeStruct(ReflectedInstruction node)
        {
            var instruction = new OpTypeStruct();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeOpaque VisitTypeOpaque(ReflectedInstruction node)
        {
            var instruction = new OpTypeOpaque();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypePointer VisitTypePointer(ReflectedInstruction node)
        {
            var instruction = new OpTypePointer();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeFunction VisitTypeFunction(ReflectedInstruction node)
        {
            var instruction = new OpTypeFunction();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeEvent VisitTypeEvent(ReflectedInstruction node)
        {
            var instruction = new OpTypeEvent();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeDeviceEvent VisitTypeDeviceEvent(ReflectedInstruction node)
        {
            var instruction = new OpTypeDeviceEvent();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeReserveId VisitTypeReserveId(ReflectedInstruction node)
        {
            var instruction = new OpTypeReserveId();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeQueue VisitTypeQueue(ReflectedInstruction node)
        {
            var instruction = new OpTypeQueue();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypePipe VisitTypePipe(ReflectedInstruction node)
        {
            var instruction = new OpTypePipe();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpTypeForwardPointer VisitTypeForwardPointer(ReflectedInstruction node)
        {
            var instruction = new OpTypeForwardPointer();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpConstantTrue VisitConstantTrue(ConstantTrue node)
        {
            var instruction = new OpConstantTrue();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConstantFalse VisitConstantFalse(ConstantFalse node)
        {
            var instruction = new OpConstantFalse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConstant VisitConstant(Constant node)
        {
            var instruction = new OpConstant();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConstantComposite VisitConstantComposite(ConstantComposite node)
        {
            var instruction = new OpConstantComposite();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConstantSampler VisitConstantSampler(ConstantSampler node)
        {
            var instruction = new OpConstantSampler();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConstantNull VisitConstantNull(ConstantNull node)
        {
            var instruction = new OpConstantNull();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSpecConstantTrue VisitSpecConstantTrue(SpecConstantTrue node)
        {
            var instruction = new OpSpecConstantTrue();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSpecConstantFalse VisitSpecConstantFalse(SpecConstantFalse node)
        {
            var instruction = new OpSpecConstantFalse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSpecConstant VisitSpecConstant(SpecConstant node)
        {
            var instruction = new OpSpecConstant();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSpecConstantComposite VisitSpecConstantComposite(SpecConstantComposite node)
        {
            var instruction = new OpSpecConstantComposite();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSpecConstantOp VisitSpecConstantOp(SpecConstantOp node)
        {
            var instruction = new OpSpecConstantOp();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFunction VisitFunction(Function node)
        {
            var instruction = new OpFunction();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpFunctionParameter VisitFunctionParameter(FunctionParameter node)
        {
            var instruction = new OpFunctionParameter();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFunctionEnd VisitFunctionEnd(FunctionEnd node)
        {
            var instruction = new OpFunctionEnd();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpFunctionCall VisitFunctionCall(FunctionCall node)
        {
            var instruction = new OpFunctionCall();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpVariable VisitVariable(Variable node)
        {
            var instruction = new OpVariable();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageTexelPointer VisitImageTexelPointer(ImageTexelPointer node)
        {
            var instruction = new OpImageTexelPointer();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpLoad VisitLoad(Load node)
        {
            var instruction = new OpLoad();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpStore VisitStore(Store node)
        {
            var instruction = new OpStore();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpCopyMemory VisitCopyMemory(CopyMemory node)
        {
            var instruction = new OpCopyMemory();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpCopyMemorySized VisitCopyMemorySized(CopyMemorySized node)
        {
            var instruction = new OpCopyMemorySized();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpAccessChain VisitAccessChain(AccessChain node)
        {
            var instruction = new OpAccessChain();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpInBoundsAccessChain VisitInBoundsAccessChain(InBoundsAccessChain node)
        {
            var instruction = new OpInBoundsAccessChain();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpPtrAccessChain VisitPtrAccessChain(PtrAccessChain node)
        {
            var instruction = new OpPtrAccessChain();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpArrayLength VisitArrayLength(ArrayLength node)
        {
            var instruction = new OpArrayLength();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGenericPtrMemSemantics VisitGenericPtrMemSemantics(GenericPtrMemSemantics node)
        {
            var instruction = new OpGenericPtrMemSemantics();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpInBoundsPtrAccessChain VisitInBoundsPtrAccessChain(InBoundsPtrAccessChain node)
        {
            var instruction = new OpInBoundsPtrAccessChain();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpDecorate VisitDecorate(Decorate node)
        {
            var instruction = new OpDecorate();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpMemberDecorate VisitMemberDecorate(MemberDecorate node)
        {
            var instruction = new OpMemberDecorate();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpDecorationGroup VisitDecorationGroup(DecorationGroup node)
        {
            var instruction = new OpDecorationGroup();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGroupDecorate VisitGroupDecorate(GroupDecorate node)
        {
            var instruction = new OpGroupDecorate();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGroupMemberDecorate VisitGroupMemberDecorate(GroupMemberDecorate node)
        {
            var instruction = new OpGroupMemberDecorate();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpVectorExtractDynamic VisitVectorExtractDynamic(VectorExtractDynamic node)
        {
            var instruction = new OpVectorExtractDynamic();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpVectorInsertDynamic VisitVectorInsertDynamic(VectorInsertDynamic node)
        {
            var instruction = new OpVectorInsertDynamic();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpVectorShuffle VisitVectorShuffle(VectorShuffle node)
        {
            var instruction = new OpVectorShuffle();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpCompositeConstruct VisitCompositeConstruct(CompositeConstruct node)
        {
            var instruction = new OpCompositeConstruct();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpCompositeExtract VisitCompositeExtract(CompositeExtract node)
        {
            var instruction = new OpCompositeExtract();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpCompositeInsert VisitCompositeInsert(CompositeInsert node)
        {
            var instruction = new OpCompositeInsert();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpCopyObject VisitCopyObject(CopyObject node)
        {
            var instruction = new OpCopyObject();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpTranspose VisitTranspose(Transpose node)
        {
            var instruction = new OpTranspose();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSampledImage VisitSampledImage(SampledImage node)
        {
            var instruction = new OpSampledImage();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSampleImplicitLod VisitImageSampleImplicitLod(ImageSampleImplicitLod node)
        {
            var instruction = new OpImageSampleImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSampleExplicitLod VisitImageSampleExplicitLod(ImageSampleExplicitLod node)
        {
            var instruction = new OpImageSampleExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSampleDrefImplicitLod VisitImageSampleDrefImplicitLod(ImageSampleDrefImplicitLod node)
        {
            var instruction = new OpImageSampleDrefImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSampleDrefExplicitLod VisitImageSampleDrefExplicitLod(ImageSampleDrefExplicitLod node)
        {
            var instruction = new OpImageSampleDrefExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSampleProjImplicitLod VisitImageSampleProjImplicitLod(ImageSampleProjImplicitLod node)
        {
            var instruction = new OpImageSampleProjImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSampleProjExplicitLod VisitImageSampleProjExplicitLod(ImageSampleProjExplicitLod node)
        {
            var instruction = new OpImageSampleProjExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSampleProjDrefImplicitLod VisitImageSampleProjDrefImplicitLod(ImageSampleProjDrefImplicitLod node)
        {
            var instruction = new OpImageSampleProjDrefImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSampleProjDrefExplicitLod VisitImageSampleProjDrefExplicitLod(ImageSampleProjDrefExplicitLod node)
        {
            var instruction = new OpImageSampleProjDrefExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageFetch VisitImageFetch(ImageFetch node)
        {
            var instruction = new OpImageFetch();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageGather VisitImageGather(ImageGather node)
        {
            var instruction = new OpImageGather();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageDrefGather VisitImageDrefGather(ImageDrefGather node)
        {
            var instruction = new OpImageDrefGather();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageRead VisitImageRead(ImageRead node)
        {
            var instruction = new OpImageRead();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageWrite VisitImageWrite(ImageWrite node)
        {
            var instruction = new OpImageWrite();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpImage VisitImage(Image node)
        {
            var instruction = new OpImage();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageQueryFormat VisitImageQueryFormat(ImageQueryFormat node)
        {
            var instruction = new OpImageQueryFormat();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageQueryOrder VisitImageQueryOrder(ImageQueryOrder node)
        {
            var instruction = new OpImageQueryOrder();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageQuerySizeLod VisitImageQuerySizeLod(ImageQuerySizeLod node)
        {
            var instruction = new OpImageQuerySizeLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageQuerySize VisitImageQuerySize(ImageQuerySize node)
        {
            var instruction = new OpImageQuerySize();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageQueryLod VisitImageQueryLod(ImageQueryLod node)
        {
            var instruction = new OpImageQueryLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageQueryLevels VisitImageQueryLevels(ImageQueryLevels node)
        {
            var instruction = new OpImageQueryLevels();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageQuerySamples VisitImageQuerySamples(ImageQuerySamples node)
        {
            var instruction = new OpImageQuerySamples();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConvertFToU VisitConvertFToU(ConvertFToU node)
        {
            var instruction = new OpConvertFToU();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConvertFToS VisitConvertFToS(ConvertFToS node)
        {
            var instruction = new OpConvertFToS();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConvertSToF VisitConvertSToF(ConvertSToF node)
        {
            var instruction = new OpConvertSToF();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConvertUToF VisitConvertUToF(ConvertUToF node)
        {
            var instruction = new OpConvertUToF();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpUConvert VisitUConvert(UConvert node)
        {
            var instruction = new OpUConvert();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSConvert VisitSConvert(SConvert node)
        {
            var instruction = new OpSConvert();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFConvert VisitFConvert(FConvert node)
        {
            var instruction = new OpFConvert();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpQuantizeToF16 VisitQuantizeToF16(QuantizeToF16 node)
        {
            var instruction = new OpQuantizeToF16();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConvertPtrToU VisitConvertPtrToU(ConvertPtrToU node)
        {
            var instruction = new OpConvertPtrToU();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSatConvertSToU VisitSatConvertSToU(SatConvertSToU node)
        {
            var instruction = new OpSatConvertSToU();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSatConvertUToS VisitSatConvertUToS(SatConvertUToS node)
        {
            var instruction = new OpSatConvertUToS();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpConvertUToPtr VisitConvertUToPtr(ConvertUToPtr node)
        {
            var instruction = new OpConvertUToPtr();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpPtrCastToGeneric VisitPtrCastToGeneric(PtrCastToGeneric node)
        {
            var instruction = new OpPtrCastToGeneric();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGenericCastToPtr VisitGenericCastToPtr(GenericCastToPtr node)
        {
            var instruction = new OpGenericCastToPtr();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGenericCastToPtrExplicit VisitGenericCastToPtrExplicit(GenericCastToPtrExplicit node)
        {
            var instruction = new OpGenericCastToPtrExplicit();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpBitcast VisitBitcast(Bitcast node)
        {
            var instruction = new OpBitcast();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSNegate VisitSNegate(SNegate node)
        {
            var instruction = new OpSNegate();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFNegate VisitFNegate(FNegate node)
        {
            var instruction = new OpFNegate();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpIAdd VisitIAdd(IAdd node)
        {
            var instruction = new OpIAdd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFAdd VisitFAdd(FAdd node)
        {
            var instruction = new OpFAdd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpISub VisitISub(ISub node)
        {
            var instruction = new OpISub();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFSub VisitFSub(FSub node)
        {
            var instruction = new OpFSub();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpIMul VisitIMul(IMul node)
        {
            var instruction = new OpIMul();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFMul VisitFMul(FMul node)
        {
            var instruction = new OpFMul();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpUDiv VisitUDiv(UDiv node)
        {
            var instruction = new OpUDiv();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSDiv VisitSDiv(SDiv node)
        {
            var instruction = new OpSDiv();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFDiv VisitFDiv(FDiv node)
        {
            var instruction = new OpFDiv();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpUMod VisitUMod(UMod node)
        {
            var instruction = new OpUMod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSRem VisitSRem(SRem node)
        {
            var instruction = new OpSRem();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSMod VisitSMod(SMod node)
        {
            var instruction = new OpSMod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFRem VisitFRem(FRem node)
        {
            var instruction = new OpFRem();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFMod VisitFMod(FMod node)
        {
            var instruction = new OpFMod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpVectorTimesScalar VisitVectorTimesScalar(VectorTimesScalar node)
        {
            var instruction = new OpVectorTimesScalar();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpMatrixTimesScalar VisitMatrixTimesScalar(MatrixTimesScalar node)
        {
            var instruction = new OpMatrixTimesScalar();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpVectorTimesMatrix VisitVectorTimesMatrix(VectorTimesMatrix node)
        {
            var instruction = new OpVectorTimesMatrix();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpMatrixTimesVector VisitMatrixTimesVector(MatrixTimesVector node)
        {
            var instruction = new OpMatrixTimesVector();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpMatrixTimesMatrix VisitMatrixTimesMatrix(MatrixTimesMatrix node)
        {
            var instruction = new OpMatrixTimesMatrix();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpOuterProduct VisitOuterProduct(OuterProduct node)
        {
            var instruction = new OpOuterProduct();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpDot VisitDot(Dot node)
        {
            var instruction = new OpDot();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpIAddCarry VisitIAddCarry(IAddCarry node)
        {
            var instruction = new OpIAddCarry();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpISubBorrow VisitISubBorrow(ISubBorrow node)
        {
            var instruction = new OpISubBorrow();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpUMulExtended VisitUMulExtended(UMulExtended node)
        {
            var instruction = new OpUMulExtended();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSMulExtended VisitSMulExtended(SMulExtended node)
        {
            var instruction = new OpSMulExtended();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAny VisitAny(Any node)
        {
            var instruction = new OpAny();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAll VisitAll(All node)
        {
            var instruction = new OpAll();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpIsNan VisitIsNan(IsNan node)
        {
            var instruction = new OpIsNan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpIsInf VisitIsInf(IsInf node)
        {
            var instruction = new OpIsInf();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpIsFinite VisitIsFinite(IsFinite node)
        {
            var instruction = new OpIsFinite();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpIsNormal VisitIsNormal(IsNormal node)
        {
            var instruction = new OpIsNormal();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSignBitSet VisitSignBitSet(SignBitSet node)
        {
            var instruction = new OpSignBitSet();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpLessOrGreater VisitLessOrGreater(LessOrGreater node)
        {
            var instruction = new OpLessOrGreater();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpOrdered VisitOrdered(Ordered node)
        {
            var instruction = new OpOrdered();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpUnordered VisitUnordered(Unordered node)
        {
            var instruction = new OpUnordered();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpLogicalEqual VisitLogicalEqual(LogicalEqual node)
        {
            var instruction = new OpLogicalEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpLogicalNotEqual VisitLogicalNotEqual(LogicalNotEqual node)
        {
            var instruction = new OpLogicalNotEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpLogicalOr VisitLogicalOr(LogicalOr node)
        {
            var instruction = new OpLogicalOr();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpLogicalAnd VisitLogicalAnd(LogicalAnd node)
        {
            var instruction = new OpLogicalAnd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpLogicalNot VisitLogicalNot(LogicalNot node)
        {
            var instruction = new OpLogicalNot();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSelect VisitSelect(Select node)
        {
            var instruction = new OpSelect();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpIEqual VisitIEqual(IEqual node)
        {
            var instruction = new OpIEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpINotEqual VisitINotEqual(INotEqual node)
        {
            var instruction = new OpINotEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpUGreaterThan VisitUGreaterThan(UGreaterThan node)
        {
            var instruction = new OpUGreaterThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSGreaterThan VisitSGreaterThan(SGreaterThan node)
        {
            var instruction = new OpSGreaterThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpUGreaterThanEqual VisitUGreaterThanEqual(UGreaterThanEqual node)
        {
            var instruction = new OpUGreaterThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSGreaterThanEqual VisitSGreaterThanEqual(SGreaterThanEqual node)
        {
            var instruction = new OpSGreaterThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpULessThan VisitULessThan(ULessThan node)
        {
            var instruction = new OpULessThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSLessThan VisitSLessThan(SLessThan node)
        {
            var instruction = new OpSLessThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpULessThanEqual VisitULessThanEqual(ULessThanEqual node)
        {
            var instruction = new OpULessThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSLessThanEqual VisitSLessThanEqual(SLessThanEqual node)
        {
            var instruction = new OpSLessThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFOrdEqual VisitFOrdEqual(FOrdEqual node)
        {
            var instruction = new OpFOrdEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFUnordEqual VisitFUnordEqual(FUnordEqual node)
        {
            var instruction = new OpFUnordEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFOrdNotEqual VisitFOrdNotEqual(FOrdNotEqual node)
        {
            var instruction = new OpFOrdNotEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFUnordNotEqual VisitFUnordNotEqual(FUnordNotEqual node)
        {
            var instruction = new OpFUnordNotEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFOrdLessThan VisitFOrdLessThan(FOrdLessThan node)
        {
            var instruction = new OpFOrdLessThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFUnordLessThan VisitFUnordLessThan(FUnordLessThan node)
        {
            var instruction = new OpFUnordLessThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFOrdGreaterThan VisitFOrdGreaterThan(FOrdGreaterThan node)
        {
            var instruction = new OpFOrdGreaterThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFUnordGreaterThan VisitFUnordGreaterThan(FUnordGreaterThan node)
        {
            var instruction = new OpFUnordGreaterThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFOrdLessThanEqual VisitFOrdLessThanEqual(FOrdLessThanEqual node)
        {
            var instruction = new OpFOrdLessThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFUnordLessThanEqual VisitFUnordLessThanEqual(FUnordLessThanEqual node)
        {
            var instruction = new OpFUnordLessThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFOrdGreaterThanEqual VisitFOrdGreaterThanEqual(FOrdGreaterThanEqual node)
        {
            var instruction = new OpFOrdGreaterThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFUnordGreaterThanEqual VisitFUnordGreaterThanEqual(FUnordGreaterThanEqual node)
        {
            var instruction = new OpFUnordGreaterThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpShiftRightLogical VisitShiftRightLogical(ShiftRightLogical node)
        {
            var instruction = new OpShiftRightLogical();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpShiftRightArithmetic VisitShiftRightArithmetic(ShiftRightArithmetic node)
        {
            var instruction = new OpShiftRightArithmetic();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpShiftLeftLogical VisitShiftLeftLogical(ShiftLeftLogical node)
        {
            var instruction = new OpShiftLeftLogical();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpBitwiseOr VisitBitwiseOr(BitwiseOr node)
        {
            var instruction = new OpBitwiseOr();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpBitwiseXor VisitBitwiseXor(BitwiseXor node)
        {
            var instruction = new OpBitwiseXor();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpBitwiseAnd VisitBitwiseAnd(BitwiseAnd node)
        {
            var instruction = new OpBitwiseAnd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpNot VisitNot(Not node)
        {
            var instruction = new OpNot();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpBitFieldInsert VisitBitFieldInsert(BitFieldInsert node)
        {
            var instruction = new OpBitFieldInsert();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpBitFieldSExtract VisitBitFieldSExtract(BitFieldSExtract node)
        {
            var instruction = new OpBitFieldSExtract();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpBitFieldUExtract VisitBitFieldUExtract(BitFieldUExtract node)
        {
            var instruction = new OpBitFieldUExtract();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpBitReverse VisitBitReverse(BitReverse node)
        {
            var instruction = new OpBitReverse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpBitCount VisitBitCount(BitCount node)
        {
            var instruction = new OpBitCount();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpDPdx VisitDPdx(DPdx node)
        {
            var instruction = new OpDPdx();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpDPdy VisitDPdy(DPdy node)
        {
            var instruction = new OpDPdy();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFwidth VisitFwidth(Fwidth node)
        {
            var instruction = new OpFwidth();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpDPdxFine VisitDPdxFine(DPdxFine node)
        {
            var instruction = new OpDPdxFine();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpDPdyFine VisitDPdyFine(DPdyFine node)
        {
            var instruction = new OpDPdyFine();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFwidthFine VisitFwidthFine(FwidthFine node)
        {
            var instruction = new OpFwidthFine();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpDPdxCoarse VisitDPdxCoarse(DPdxCoarse node)
        {
            var instruction = new OpDPdxCoarse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpDPdyCoarse VisitDPdyCoarse(DPdyCoarse node)
        {
            var instruction = new OpDPdyCoarse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFwidthCoarse VisitFwidthCoarse(FwidthCoarse node)
        {
            var instruction = new OpFwidthCoarse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpEmitVertex VisitEmitVertex(EmitVertex node)
        {
            var instruction = new OpEmitVertex();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpEndPrimitive VisitEndPrimitive(EndPrimitive node)
        {
            var instruction = new OpEndPrimitive();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpEmitStreamVertex VisitEmitStreamVertex(EmitStreamVertex node)
        {
            var instruction = new OpEmitStreamVertex();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpEndStreamPrimitive VisitEndStreamPrimitive(EndStreamPrimitive node)
        {
            var instruction = new OpEndStreamPrimitive();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpControlBarrier VisitControlBarrier(ControlBarrier node)
        {
            var instruction = new OpControlBarrier();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpMemoryBarrier VisitMemoryBarrier(MemoryBarrier node)
        {
            var instruction = new OpMemoryBarrier();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpAtomicLoad VisitAtomicLoad(AtomicLoad node)
        {
            var instruction = new OpAtomicLoad();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicStore VisitAtomicStore(AtomicStore node)
        {
            var instruction = new OpAtomicStore();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpAtomicExchange VisitAtomicExchange(AtomicExchange node)
        {
            var instruction = new OpAtomicExchange();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicCompareExchange VisitAtomicCompareExchange(AtomicCompareExchange node)
        {
            var instruction = new OpAtomicCompareExchange();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicCompareExchangeWeak VisitAtomicCompareExchangeWeak(AtomicCompareExchangeWeak node)
        {
            var instruction = new OpAtomicCompareExchangeWeak();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicIIncrement VisitAtomicIIncrement(AtomicIIncrement node)
        {
            var instruction = new OpAtomicIIncrement();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicIDecrement VisitAtomicIDecrement(AtomicIDecrement node)
        {
            var instruction = new OpAtomicIDecrement();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicIAdd VisitAtomicIAdd(AtomicIAdd node)
        {
            var instruction = new OpAtomicIAdd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicISub VisitAtomicISub(AtomicISub node)
        {
            var instruction = new OpAtomicISub();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicSMin VisitAtomicSMin(AtomicSMin node)
        {
            var instruction = new OpAtomicSMin();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicUMin VisitAtomicUMin(AtomicUMin node)
        {
            var instruction = new OpAtomicUMin();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicSMax VisitAtomicSMax(AtomicSMax node)
        {
            var instruction = new OpAtomicSMax();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicUMax VisitAtomicUMax(AtomicUMax node)
        {
            var instruction = new OpAtomicUMax();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicAnd VisitAtomicAnd(AtomicAnd node)
        {
            var instruction = new OpAtomicAnd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicOr VisitAtomicOr(AtomicOr node)
        {
            var instruction = new OpAtomicOr();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicXor VisitAtomicXor(AtomicXor node)
        {
            var instruction = new OpAtomicXor();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpPhi VisitPhi(Phi node)
        {
            var instruction = new OpPhi();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpLoopMerge VisitLoopMerge(LoopMerge node)
        {
            var instruction = new OpLoopMerge();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpSelectionMerge VisitSelectionMerge(SelectionMerge node)
        {
            var instruction = new OpSelectionMerge();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpLabel VisitLabel(Label node)
        {
            var instruction = new OpLabel();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpBranch VisitBranch(Branch node)
        {
            var instruction = new OpBranch();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpBranchConditional VisitBranchConditional(BranchConditional node)
        {
            var instruction = new OpBranchConditional();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpSwitch VisitSwitch(Switch node)
        {
            var instruction = new OpSwitch();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpKill VisitKill(Kill node)
        {
            var instruction = new OpKill();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpReturn VisitReturn(Return node)
        {
            var instruction = new OpReturn();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpReturnValue VisitReturnValue(ReturnValue node)
        {
            var instruction = new OpReturnValue();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpUnreachable VisitUnreachable(Unreachable node)
        {
            var instruction = new OpUnreachable();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpLifetimeStart VisitLifetimeStart(LifetimeStart node)
        {
            var instruction = new OpLifetimeStart();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpLifetimeStop VisitLifetimeStop(LifetimeStop node)
        {
            var instruction = new OpLifetimeStop();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGroupAsyncCopy VisitGroupAsyncCopy(GroupAsyncCopy node)
        {
            var instruction = new OpGroupAsyncCopy();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupWaitEvents VisitGroupWaitEvents(GroupWaitEvents node)
        {
            var instruction = new OpGroupWaitEvents();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGroupAll VisitGroupAll(GroupAll node)
        {
            var instruction = new OpGroupAll();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupAny VisitGroupAny(GroupAny node)
        {
            var instruction = new OpGroupAny();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupBroadcast VisitGroupBroadcast(GroupBroadcast node)
        {
            var instruction = new OpGroupBroadcast();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupIAdd VisitGroupIAdd(GroupIAdd node)
        {
            var instruction = new OpGroupIAdd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupFAdd VisitGroupFAdd(GroupFAdd node)
        {
            var instruction = new OpGroupFAdd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupFMin VisitGroupFMin(GroupFMin node)
        {
            var instruction = new OpGroupFMin();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupUMin VisitGroupUMin(GroupUMin node)
        {
            var instruction = new OpGroupUMin();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupSMin VisitGroupSMin(GroupSMin node)
        {
            var instruction = new OpGroupSMin();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupFMax VisitGroupFMax(GroupFMax node)
        {
            var instruction = new OpGroupFMax();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupUMax VisitGroupUMax(GroupUMax node)
        {
            var instruction = new OpGroupUMax();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupSMax VisitGroupSMax(GroupSMax node)
        {
            var instruction = new OpGroupSMax();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpReadPipe VisitReadPipe(ReadPipe node)
        {
            var instruction = new OpReadPipe();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpWritePipe VisitWritePipe(WritePipe node)
        {
            var instruction = new OpWritePipe();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpReservedReadPipe VisitReservedReadPipe(ReservedReadPipe node)
        {
            var instruction = new OpReservedReadPipe();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpReservedWritePipe VisitReservedWritePipe(ReservedWritePipe node)
        {
            var instruction = new OpReservedWritePipe();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpReserveReadPipePackets VisitReserveReadPipePackets(ReserveReadPipePackets node)
        {
            var instruction = new OpReserveReadPipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpReserveWritePipePackets VisitReserveWritePipePackets(ReserveWritePipePackets node)
        {
            var instruction = new OpReserveWritePipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpCommitReadPipe VisitCommitReadPipe(CommitReadPipe node)
        {
            var instruction = new OpCommitReadPipe();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpCommitWritePipe VisitCommitWritePipe(CommitWritePipe node)
        {
            var instruction = new OpCommitWritePipe();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpIsValidReserveId VisitIsValidReserveId(IsValidReserveId node)
        {
            var instruction = new OpIsValidReserveId();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGetNumPipePackets VisitGetNumPipePackets(GetNumPipePackets node)
        {
            var instruction = new OpGetNumPipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGetMaxPipePackets VisitGetMaxPipePackets(GetMaxPipePackets node)
        {
            var instruction = new OpGetMaxPipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupReserveReadPipePackets VisitGroupReserveReadPipePackets(GroupReserveReadPipePackets node)
        {
            var instruction = new OpGroupReserveReadPipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupReserveWritePipePackets VisitGroupReserveWritePipePackets(GroupReserveWritePipePackets node)
        {
            var instruction = new OpGroupReserveWritePipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupCommitReadPipe VisitGroupCommitReadPipe(GroupCommitReadPipe node)
        {
            var instruction = new OpGroupCommitReadPipe();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGroupCommitWritePipe VisitGroupCommitWritePipe(GroupCommitWritePipe node)
        {
            var instruction = new OpGroupCommitWritePipe();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpEnqueueMarker VisitEnqueueMarker(EnqueueMarker node)
        {
            var instruction = new OpEnqueueMarker();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpEnqueueKernel VisitEnqueueKernel(EnqueueKernel node)
        {
            var instruction = new OpEnqueueKernel();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGetKernelNDrangeSubGroupCount VisitGetKernelNDrangeSubGroupCount(GetKernelNDrangeSubGroupCount node)
        {
            var instruction = new OpGetKernelNDrangeSubGroupCount();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGetKernelNDrangeMaxSubGroupSize VisitGetKernelNDrangeMaxSubGroupSize(GetKernelNDrangeMaxSubGroupSize node)
        {
            var instruction = new OpGetKernelNDrangeMaxSubGroupSize();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGetKernelWorkGroupSize VisitGetKernelWorkGroupSize(GetKernelWorkGroupSize node)
        {
            var instruction = new OpGetKernelWorkGroupSize();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGetKernelPreferredWorkGroupSizeMultiple VisitGetKernelPreferredWorkGroupSizeMultiple(GetKernelPreferredWorkGroupSizeMultiple node)
        {
            var instruction = new OpGetKernelPreferredWorkGroupSizeMultiple();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpRetainEvent VisitRetainEvent(RetainEvent node)
        {
            var instruction = new OpRetainEvent();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpReleaseEvent VisitReleaseEvent(ReleaseEvent node)
        {
            var instruction = new OpReleaseEvent();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpCreateUserEvent VisitCreateUserEvent(CreateUserEvent node)
        {
            var instruction = new OpCreateUserEvent();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpIsValidEvent VisitIsValidEvent(IsValidEvent node)
        {
            var instruction = new OpIsValidEvent();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSetUserEventStatus VisitSetUserEventStatus(SetUserEventStatus node)
        {
            var instruction = new OpSetUserEventStatus();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpCaptureEventProfilingInfo VisitCaptureEventProfilingInfo(CaptureEventProfilingInfo node)
        {
            var instruction = new OpCaptureEventProfilingInfo();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGetDefaultQueue VisitGetDefaultQueue(GetDefaultQueue node)
        {
            var instruction = new OpGetDefaultQueue();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpBuildNDRange VisitBuildNDRange(BuildNDRange node)
        {
            var instruction = new OpBuildNDRange();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseSampleImplicitLod VisitImageSparseSampleImplicitLod(ImageSparseSampleImplicitLod node)
        {
            var instruction = new OpImageSparseSampleImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseSampleExplicitLod VisitImageSparseSampleExplicitLod(ImageSparseSampleExplicitLod node)
        {
            var instruction = new OpImageSparseSampleExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseSampleDrefImplicitLod VisitImageSparseSampleDrefImplicitLod(ImageSparseSampleDrefImplicitLod node)
        {
            var instruction = new OpImageSparseSampleDrefImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseSampleDrefExplicitLod VisitImageSparseSampleDrefExplicitLod(ImageSparseSampleDrefExplicitLod node)
        {
            var instruction = new OpImageSparseSampleDrefExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseSampleProjImplicitLod VisitImageSparseSampleProjImplicitLod(ImageSparseSampleProjImplicitLod node)
        {
            var instruction = new OpImageSparseSampleProjImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseSampleProjExplicitLod VisitImageSparseSampleProjExplicitLod(ImageSparseSampleProjExplicitLod node)
        {
            var instruction = new OpImageSparseSampleProjExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseSampleProjDrefImplicitLod VisitImageSparseSampleProjDrefImplicitLod(ImageSparseSampleProjDrefImplicitLod node)
        {
            var instruction = new OpImageSparseSampleProjDrefImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseSampleProjDrefExplicitLod VisitImageSparseSampleProjDrefExplicitLod(ImageSparseSampleProjDrefExplicitLod node)
        {
            var instruction = new OpImageSparseSampleProjDrefExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseFetch VisitImageSparseFetch(ImageSparseFetch node)
        {
            var instruction = new OpImageSparseFetch();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseGather VisitImageSparseGather(ImageSparseGather node)
        {
            var instruction = new OpImageSparseGather();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseDrefGather VisitImageSparseDrefGather(ImageSparseDrefGather node)
        {
            var instruction = new OpImageSparseDrefGather();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpImageSparseTexelsResident VisitImageSparseTexelsResident(ImageSparseTexelsResident node)
        {
            var instruction = new OpImageSparseTexelsResident();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpNoLine VisitNoLine(NoLine node)
        {
            var instruction = new OpNoLine();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpAtomicFlagTestAndSet VisitAtomicFlagTestAndSet(AtomicFlagTestAndSet node)
        {
            var instruction = new OpAtomicFlagTestAndSet();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpAtomicFlagClear VisitAtomicFlagClear(AtomicFlagClear node)
        {
            var instruction = new OpAtomicFlagClear();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpImageSparseRead VisitImageSparseRead(ImageSparseRead node)
        {
            var instruction = new OpImageSparseRead();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpDecorateId VisitDecorateId(DecorateId node)
        {
            var instruction = new OpDecorateId();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpSubgroupBallotKHR VisitSubgroupBallotKHR(SubgroupBallotKHR node)
        {
            var instruction = new OpSubgroupBallotKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupFirstInvocationKHR VisitSubgroupFirstInvocationKHR(SubgroupFirstInvocationKHR node)
        {
            var instruction = new OpSubgroupFirstInvocationKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupAllKHR VisitSubgroupAllKHR(SubgroupAllKHR node)
        {
            var instruction = new OpSubgroupAllKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupAnyKHR VisitSubgroupAnyKHR(SubgroupAnyKHR node)
        {
            var instruction = new OpSubgroupAnyKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupAllEqualKHR VisitSubgroupAllEqualKHR(SubgroupAllEqualKHR node)
        {
            var instruction = new OpSubgroupAllEqualKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupReadInvocationKHR VisitSubgroupReadInvocationKHR(SubgroupReadInvocationKHR node)
        {
            var instruction = new OpSubgroupReadInvocationKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupIAddNonUniformAMD VisitGroupIAddNonUniformAMD(GroupIAddNonUniformAMD node)
        {
            var instruction = new OpGroupIAddNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupFAddNonUniformAMD VisitGroupFAddNonUniformAMD(GroupFAddNonUniformAMD node)
        {
            var instruction = new OpGroupFAddNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupFMinNonUniformAMD VisitGroupFMinNonUniformAMD(GroupFMinNonUniformAMD node)
        {
            var instruction = new OpGroupFMinNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupUMinNonUniformAMD VisitGroupUMinNonUniformAMD(GroupUMinNonUniformAMD node)
        {
            var instruction = new OpGroupUMinNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupSMinNonUniformAMD VisitGroupSMinNonUniformAMD(GroupSMinNonUniformAMD node)
        {
            var instruction = new OpGroupSMinNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupFMaxNonUniformAMD VisitGroupFMaxNonUniformAMD(GroupFMaxNonUniformAMD node)
        {
            var instruction = new OpGroupFMaxNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupUMaxNonUniformAMD VisitGroupUMaxNonUniformAMD(GroupUMaxNonUniformAMD node)
        {
            var instruction = new OpGroupUMaxNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpGroupSMaxNonUniformAMD VisitGroupSMaxNonUniformAMD(GroupSMaxNonUniformAMD node)
        {
            var instruction = new OpGroupSMaxNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFragmentMaskFetchAMD VisitFragmentMaskFetchAMD(FragmentMaskFetchAMD node)
        {
            var instruction = new OpFragmentMaskFetchAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpFragmentFetchAMD VisitFragmentFetchAMD(FragmentFetchAMD node)
        {
            var instruction = new OpFragmentFetchAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupShuffleINTEL VisitSubgroupShuffleINTEL(SubgroupShuffleINTEL node)
        {
            var instruction = new OpSubgroupShuffleINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupShuffleDownINTEL VisitSubgroupShuffleDownINTEL(SubgroupShuffleDownINTEL node)
        {
            var instruction = new OpSubgroupShuffleDownINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupShuffleUpINTEL VisitSubgroupShuffleUpINTEL(SubgroupShuffleUpINTEL node)
        {
            var instruction = new OpSubgroupShuffleUpINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupShuffleXorINTEL VisitSubgroupShuffleXorINTEL(SubgroupShuffleXorINTEL node)
        {
            var instruction = new OpSubgroupShuffleXorINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupBlockReadINTEL VisitSubgroupBlockReadINTEL(SubgroupBlockReadINTEL node)
        {
            var instruction = new OpSubgroupBlockReadINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupBlockWriteINTEL VisitSubgroupBlockWriteINTEL(SubgroupBlockWriteINTEL node)
        {
            var instruction = new OpSubgroupBlockWriteINTEL();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpSubgroupImageBlockReadINTEL VisitSubgroupImageBlockReadINTEL(SubgroupImageBlockReadINTEL node)
        {
            var instruction = new OpSubgroupImageBlockReadINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            Visit(node.ResultType);
            return instruction;
        }
        protected virtual OpSubgroupImageBlockWriteINTEL VisitSubgroupImageBlockWriteINTEL(SubgroupImageBlockWriteINTEL node)
        {
            var instruction = new OpSubgroupImageBlockWriteINTEL();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpDecorateStringGOOGLE VisitDecorateStringGOOGLE(DecorateStringGOOGLE node)
        {
            var instruction = new OpDecorateStringGOOGLE();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpMemberDecorateStringGOOGLE VisitMemberDecorateStringGOOGLE(MemberDecorateStringGOOGLE node)
        {
            var instruction = new OpMemberDecorateStringGOOGLE();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
    }
}
