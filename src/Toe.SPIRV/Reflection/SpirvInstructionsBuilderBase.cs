using System;
using System.Collections.Generic;
using System.Linq;
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
            if (node == null) return null;
            if (_instructionMap.TryGetValue(node, out var instruction)) return instruction;
            switch (node.OpCode)
            {
                case Op.OpNop: return VisitNop((Nodes.Nop) node);
                case Op.OpUndef: return VisitUndef((Undef) node);
                case Op.OpSourceContinued: return VisitSourceContinued((Nodes.SourceContinued) node);
                case Op.OpSource: return VisitSource((Nodes.Source) node);
                case Op.OpSourceExtension: return VisitSourceExtension((Nodes.SourceExtension) node);
                case Op.OpName: return VisitName((Nodes.Name) node);
                case Op.OpMemberName: return VisitMemberName((Nodes.MemberName) node);
                case Op.OpString: return VisitString((Nodes.String) node);
                case Op.OpLine: return VisitLine((Nodes.Line) node);
                case Op.OpExtension: return VisitExtension((Nodes.Extension) node);
                case Op.OpExtInstImport: return VisitExtInstImport((Nodes.ExtInstImport) node);
                case Op.OpExtInst: return VisitExtInst((ExtInst) node);
                case Op.OpMemoryModel: return VisitMemoryModel((Nodes.MemoryModel) node);
                case Op.OpEntryPoint: return VisitEntryPoint((Nodes.EntryPoint) node);
                case Op.OpExecutionMode: return VisitExecutionMode((Nodes.ExecutionMode) node);
                case Op.OpCapability: return VisitCapability((Nodes.Capability) node);
                case Op.OpTypeVoid: return VisitTypeVoid((SpirvVoid)node);
                case Op.OpTypeBool: return VisitTypeBool((SpirvBool)node);
                case Op.OpTypeInt: return VisitTypeInt((SpirvInt)node);
                case Op.OpTypeFloat: return VisitTypeFloat((SpirvFloat)node);
                case Op.OpTypeVector: return VisitTypeVector((SpirvVector)node);
                case Op.OpTypeMatrix: return VisitTypeMatrix((SpirvMatrix)node);
                case Op.OpTypeImage: return VisitTypeImage((SpirvImage)node);
                case Op.OpTypeSampler: return VisitTypeSampler((SpirvSampler)node);
                case Op.OpTypeSampledImage: return VisitTypeSampledImage((SpirvSampledImage)node);
                case Op.OpTypeArray: return VisitTypeArray((SpirvArray)node);
                case Op.OpTypeRuntimeArray: return VisitTypeRuntimeArray((SpirvRuntimeArray)node);
                case Op.OpTypeStruct: return VisitTypeStruct((SpirvStruct)node);
                case Op.OpTypeOpaque: return VisitTypeOpaque((SpirvOpaque)node);
                case Op.OpTypePointer: return VisitTypePointer((SpirvPointer)node);
                case Op.OpTypeFunction: return VisitTypeFunction((SpirvFunction)node);
                case Op.OpTypeEvent: return VisitTypeEvent((SpirvEvent)node);
                case Op.OpTypeDeviceEvent: return VisitTypeDeviceEvent((SpirvDeviceEvent)node);
                case Op.OpTypeReserveId: return VisitTypeReserveId((SpirvReserveId)node);
                case Op.OpTypeQueue: return VisitTypeQueue((SpirvQueue)node);
                case Op.OpTypePipe: return VisitTypePipe((SpirvPipe)node);
                case Op.OpTypeForwardPointer: return VisitTypeForwardPointer((SpirvForwardPointer)node);
                case Op.OpConstantTrue: return VisitConstantTrue((ConstantTrue) node);
                case Op.OpConstantFalse: return VisitConstantFalse((ConstantFalse) node);
                case Op.OpConstant: return VisitConstant((Constant) node);
                case Op.OpConstantComposite: return VisitConstantComposite((ConstantComposite) node);
                case Op.OpConstantSampler: return VisitConstantSampler((ConstantSampler) node);
                case Op.OpConstantNull: return VisitConstantNull((ConstantNull) node);
                case Op.OpSpecConstantTrue: return VisitSpecConstantTrue((SpecConstantTrue) node);
                case Op.OpSpecConstantFalse: return VisitSpecConstantFalse((SpecConstantFalse) node);
                case Op.OpSpecConstant: return VisitSpecConstant((SpecConstant) node);
                case Op.OpSpecConstantComposite: return VisitSpecConstantComposite((SpecConstantComposite) node);
                case Op.OpSpecConstantOp: return VisitSpecConstantOp((SpecConstantOp) node);
                case Op.OpFunction: return VisitFunction((Function) node);
                case Op.OpFunctionParameter: return VisitFunctionParameter((FunctionParameter) node);
                case Op.OpFunctionEnd: return VisitFunctionEnd((FunctionEnd) node);
                case Op.OpFunctionCall: return VisitFunctionCall((FunctionCall) node);
                case Op.OpVariable: return VisitVariable((Variable) node);
                case Op.OpImageTexelPointer: return VisitImageTexelPointer((ImageTexelPointer) node);
                case Op.OpLoad: return VisitLoad((Load) node);
                case Op.OpStore: return VisitStore((Store) node);
                case Op.OpCopyMemory: return VisitCopyMemory((CopyMemory) node);
                case Op.OpCopyMemorySized: return VisitCopyMemorySized((CopyMemorySized) node);
                case Op.OpAccessChain: return VisitAccessChain((AccessChain) node);
                case Op.OpInBoundsAccessChain: return VisitInBoundsAccessChain((InBoundsAccessChain) node);
                case Op.OpPtrAccessChain: return VisitPtrAccessChain((PtrAccessChain) node);
                case Op.OpArrayLength: return VisitArrayLength((ArrayLength) node);
                case Op.OpGenericPtrMemSemantics: return VisitGenericPtrMemSemantics((GenericPtrMemSemantics) node);
                case Op.OpInBoundsPtrAccessChain: return VisitInBoundsPtrAccessChain((InBoundsPtrAccessChain) node);
                case Op.OpDecorate: return VisitDecorate((Decorate) node);
                case Op.OpMemberDecorate: return VisitMemberDecorate((MemberDecorate) node);
                case Op.OpDecorationGroup: return VisitDecorationGroup((DecorationGroup) node);
                case Op.OpGroupDecorate: return VisitGroupDecorate((GroupDecorate) node);
                case Op.OpGroupMemberDecorate: return VisitGroupMemberDecorate((GroupMemberDecorate) node);
                case Op.OpVectorExtractDynamic: return VisitVectorExtractDynamic((VectorExtractDynamic) node);
                case Op.OpVectorInsertDynamic: return VisitVectorInsertDynamic((VectorInsertDynamic) node);
                case Op.OpVectorShuffle: return VisitVectorShuffle((VectorShuffle) node);
                case Op.OpCompositeConstruct: return VisitCompositeConstruct((CompositeConstruct) node);
                case Op.OpCompositeExtract: return VisitCompositeExtract((CompositeExtract) node);
                case Op.OpCompositeInsert: return VisitCompositeInsert((CompositeInsert) node);
                case Op.OpCopyObject: return VisitCopyObject((CopyObject) node);
                case Op.OpTranspose: return VisitTranspose((Transpose) node);
                case Op.OpSampledImage: return VisitSampledImage((SampledImage) node);
                case Op.OpImageSampleImplicitLod: return VisitImageSampleImplicitLod((ImageSampleImplicitLod) node);
                case Op.OpImageSampleExplicitLod: return VisitImageSampleExplicitLod((ImageSampleExplicitLod) node);
                case Op.OpImageSampleDrefImplicitLod: return VisitImageSampleDrefImplicitLod((ImageSampleDrefImplicitLod) node);
                case Op.OpImageSampleDrefExplicitLod: return VisitImageSampleDrefExplicitLod((ImageSampleDrefExplicitLod) node);
                case Op.OpImageSampleProjImplicitLod: return VisitImageSampleProjImplicitLod((ImageSampleProjImplicitLod) node);
                case Op.OpImageSampleProjExplicitLod: return VisitImageSampleProjExplicitLod((ImageSampleProjExplicitLod) node);
                case Op.OpImageSampleProjDrefImplicitLod: return VisitImageSampleProjDrefImplicitLod((ImageSampleProjDrefImplicitLod) node);
                case Op.OpImageSampleProjDrefExplicitLod: return VisitImageSampleProjDrefExplicitLod((ImageSampleProjDrefExplicitLod) node);
                case Op.OpImageFetch: return VisitImageFetch((ImageFetch) node);
                case Op.OpImageGather: return VisitImageGather((ImageGather) node);
                case Op.OpImageDrefGather: return VisitImageDrefGather((ImageDrefGather) node);
                case Op.OpImageRead: return VisitImageRead((ImageRead) node);
                case Op.OpImageWrite: return VisitImageWrite((ImageWrite) node);
                case Op.OpImage: return VisitImage((Image) node);
                case Op.OpImageQueryFormat: return VisitImageQueryFormat((ImageQueryFormat) node);
                case Op.OpImageQueryOrder: return VisitImageQueryOrder((ImageQueryOrder) node);
                case Op.OpImageQuerySizeLod: return VisitImageQuerySizeLod((ImageQuerySizeLod) node);
                case Op.OpImageQuerySize: return VisitImageQuerySize((ImageQuerySize) node);
                case Op.OpImageQueryLod: return VisitImageQueryLod((ImageQueryLod) node);
                case Op.OpImageQueryLevels: return VisitImageQueryLevels((ImageQueryLevels) node);
                case Op.OpImageQuerySamples: return VisitImageQuerySamples((ImageQuerySamples) node);
                case Op.OpConvertFToU: return VisitConvertFToU((ConvertFToU) node);
                case Op.OpConvertFToS: return VisitConvertFToS((ConvertFToS) node);
                case Op.OpConvertSToF: return VisitConvertSToF((ConvertSToF) node);
                case Op.OpConvertUToF: return VisitConvertUToF((ConvertUToF) node);
                case Op.OpUConvert: return VisitUConvert((UConvert) node);
                case Op.OpSConvert: return VisitSConvert((SConvert) node);
                case Op.OpFConvert: return VisitFConvert((FConvert) node);
                case Op.OpQuantizeToF16: return VisitQuantizeToF16((QuantizeToF16) node);
                case Op.OpConvertPtrToU: return VisitConvertPtrToU((ConvertPtrToU) node);
                case Op.OpSatConvertSToU: return VisitSatConvertSToU((SatConvertSToU) node);
                case Op.OpSatConvertUToS: return VisitSatConvertUToS((SatConvertUToS) node);
                case Op.OpConvertUToPtr: return VisitConvertUToPtr((ConvertUToPtr) node);
                case Op.OpPtrCastToGeneric: return VisitPtrCastToGeneric((PtrCastToGeneric) node);
                case Op.OpGenericCastToPtr: return VisitGenericCastToPtr((GenericCastToPtr) node);
                case Op.OpGenericCastToPtrExplicit: return VisitGenericCastToPtrExplicit((GenericCastToPtrExplicit) node);
                case Op.OpBitcast: return VisitBitcast((Bitcast) node);
                case Op.OpSNegate: return VisitSNegate((SNegate) node);
                case Op.OpFNegate: return VisitFNegate((FNegate) node);
                case Op.OpIAdd: return VisitIAdd((IAdd) node);
                case Op.OpFAdd: return VisitFAdd((FAdd) node);
                case Op.OpISub: return VisitISub((ISub) node);
                case Op.OpFSub: return VisitFSub((FSub) node);
                case Op.OpIMul: return VisitIMul((IMul) node);
                case Op.OpFMul: return VisitFMul((FMul) node);
                case Op.OpUDiv: return VisitUDiv((UDiv) node);
                case Op.OpSDiv: return VisitSDiv((SDiv) node);
                case Op.OpFDiv: return VisitFDiv((FDiv) node);
                case Op.OpUMod: return VisitUMod((UMod) node);
                case Op.OpSRem: return VisitSRem((SRem) node);
                case Op.OpSMod: return VisitSMod((SMod) node);
                case Op.OpFRem: return VisitFRem((FRem) node);
                case Op.OpFMod: return VisitFMod((FMod) node);
                case Op.OpVectorTimesScalar: return VisitVectorTimesScalar((VectorTimesScalar) node);
                case Op.OpMatrixTimesScalar: return VisitMatrixTimesScalar((MatrixTimesScalar) node);
                case Op.OpVectorTimesMatrix: return VisitVectorTimesMatrix((VectorTimesMatrix) node);
                case Op.OpMatrixTimesVector: return VisitMatrixTimesVector((MatrixTimesVector) node);
                case Op.OpMatrixTimesMatrix: return VisitMatrixTimesMatrix((MatrixTimesMatrix) node);
                case Op.OpOuterProduct: return VisitOuterProduct((OuterProduct) node);
                case Op.OpDot: return VisitDot((Dot) node);
                case Op.OpIAddCarry: return VisitIAddCarry((IAddCarry) node);
                case Op.OpISubBorrow: return VisitISubBorrow((ISubBorrow) node);
                case Op.OpUMulExtended: return VisitUMulExtended((UMulExtended) node);
                case Op.OpSMulExtended: return VisitSMulExtended((SMulExtended) node);
                case Op.OpAny: return VisitAny((Any) node);
                case Op.OpAll: return VisitAll((All) node);
                case Op.OpIsNan: return VisitIsNan((IsNan) node);
                case Op.OpIsInf: return VisitIsInf((IsInf) node);
                case Op.OpIsFinite: return VisitIsFinite((IsFinite) node);
                case Op.OpIsNormal: return VisitIsNormal((IsNormal) node);
                case Op.OpSignBitSet: return VisitSignBitSet((SignBitSet) node);
                case Op.OpLessOrGreater: return VisitLessOrGreater((LessOrGreater) node);
                case Op.OpOrdered: return VisitOrdered((Ordered) node);
                case Op.OpUnordered: return VisitUnordered((Unordered) node);
                case Op.OpLogicalEqual: return VisitLogicalEqual((LogicalEqual) node);
                case Op.OpLogicalNotEqual: return VisitLogicalNotEqual((LogicalNotEqual) node);
                case Op.OpLogicalOr: return VisitLogicalOr((LogicalOr) node);
                case Op.OpLogicalAnd: return VisitLogicalAnd((LogicalAnd) node);
                case Op.OpLogicalNot: return VisitLogicalNot((LogicalNot) node);
                case Op.OpSelect: return VisitSelect((Select) node);
                case Op.OpIEqual: return VisitIEqual((IEqual) node);
                case Op.OpINotEqual: return VisitINotEqual((INotEqual) node);
                case Op.OpUGreaterThan: return VisitUGreaterThan((UGreaterThan) node);
                case Op.OpSGreaterThan: return VisitSGreaterThan((SGreaterThan) node);
                case Op.OpUGreaterThanEqual: return VisitUGreaterThanEqual((UGreaterThanEqual) node);
                case Op.OpSGreaterThanEqual: return VisitSGreaterThanEqual((SGreaterThanEqual) node);
                case Op.OpULessThan: return VisitULessThan((ULessThan) node);
                case Op.OpSLessThan: return VisitSLessThan((SLessThan) node);
                case Op.OpULessThanEqual: return VisitULessThanEqual((ULessThanEqual) node);
                case Op.OpSLessThanEqual: return VisitSLessThanEqual((SLessThanEqual) node);
                case Op.OpFOrdEqual: return VisitFOrdEqual((FOrdEqual) node);
                case Op.OpFUnordEqual: return VisitFUnordEqual((FUnordEqual) node);
                case Op.OpFOrdNotEqual: return VisitFOrdNotEqual((FOrdNotEqual) node);
                case Op.OpFUnordNotEqual: return VisitFUnordNotEqual((FUnordNotEqual) node);
                case Op.OpFOrdLessThan: return VisitFOrdLessThan((FOrdLessThan) node);
                case Op.OpFUnordLessThan: return VisitFUnordLessThan((FUnordLessThan) node);
                case Op.OpFOrdGreaterThan: return VisitFOrdGreaterThan((FOrdGreaterThan) node);
                case Op.OpFUnordGreaterThan: return VisitFUnordGreaterThan((FUnordGreaterThan) node);
                case Op.OpFOrdLessThanEqual: return VisitFOrdLessThanEqual((FOrdLessThanEqual) node);
                case Op.OpFUnordLessThanEqual: return VisitFUnordLessThanEqual((FUnordLessThanEqual) node);
                case Op.OpFOrdGreaterThanEqual: return VisitFOrdGreaterThanEqual((FOrdGreaterThanEqual) node);
                case Op.OpFUnordGreaterThanEqual: return VisitFUnordGreaterThanEqual((FUnordGreaterThanEqual) node);
                case Op.OpShiftRightLogical: return VisitShiftRightLogical((ShiftRightLogical) node);
                case Op.OpShiftRightArithmetic: return VisitShiftRightArithmetic((ShiftRightArithmetic) node);
                case Op.OpShiftLeftLogical: return VisitShiftLeftLogical((ShiftLeftLogical) node);
                case Op.OpBitwiseOr: return VisitBitwiseOr((BitwiseOr) node);
                case Op.OpBitwiseXor: return VisitBitwiseXor((BitwiseXor) node);
                case Op.OpBitwiseAnd: return VisitBitwiseAnd((BitwiseAnd) node);
                case Op.OpNot: return VisitNot((Not) node);
                case Op.OpBitFieldInsert: return VisitBitFieldInsert((BitFieldInsert) node);
                case Op.OpBitFieldSExtract: return VisitBitFieldSExtract((BitFieldSExtract) node);
                case Op.OpBitFieldUExtract: return VisitBitFieldUExtract((BitFieldUExtract) node);
                case Op.OpBitReverse: return VisitBitReverse((BitReverse) node);
                case Op.OpBitCount: return VisitBitCount((BitCount) node);
                case Op.OpDPdx: return VisitDPdx((DPdx) node);
                case Op.OpDPdy: return VisitDPdy((DPdy) node);
                case Op.OpFwidth: return VisitFwidth((Fwidth) node);
                case Op.OpDPdxFine: return VisitDPdxFine((DPdxFine) node);
                case Op.OpDPdyFine: return VisitDPdyFine((DPdyFine) node);
                case Op.OpFwidthFine: return VisitFwidthFine((FwidthFine) node);
                case Op.OpDPdxCoarse: return VisitDPdxCoarse((DPdxCoarse) node);
                case Op.OpDPdyCoarse: return VisitDPdyCoarse((DPdyCoarse) node);
                case Op.OpFwidthCoarse: return VisitFwidthCoarse((FwidthCoarse) node);
                case Op.OpEmitVertex: return VisitEmitVertex((EmitVertex) node);
                case Op.OpEndPrimitive: return VisitEndPrimitive((EndPrimitive) node);
                case Op.OpEmitStreamVertex: return VisitEmitStreamVertex((EmitStreamVertex) node);
                case Op.OpEndStreamPrimitive: return VisitEndStreamPrimitive((EndStreamPrimitive) node);
                case Op.OpControlBarrier: return VisitControlBarrier((ControlBarrier) node);
                case Op.OpMemoryBarrier: return VisitMemoryBarrier((MemoryBarrier) node);
                case Op.OpAtomicLoad: return VisitAtomicLoad((AtomicLoad) node);
                case Op.OpAtomicStore: return VisitAtomicStore((AtomicStore) node);
                case Op.OpAtomicExchange: return VisitAtomicExchange((AtomicExchange) node);
                case Op.OpAtomicCompareExchange: return VisitAtomicCompareExchange((AtomicCompareExchange) node);
                case Op.OpAtomicCompareExchangeWeak: return VisitAtomicCompareExchangeWeak((AtomicCompareExchangeWeak) node);
                case Op.OpAtomicIIncrement: return VisitAtomicIIncrement((AtomicIIncrement) node);
                case Op.OpAtomicIDecrement: return VisitAtomicIDecrement((AtomicIDecrement) node);
                case Op.OpAtomicIAdd: return VisitAtomicIAdd((AtomicIAdd) node);
                case Op.OpAtomicISub: return VisitAtomicISub((AtomicISub) node);
                case Op.OpAtomicSMin: return VisitAtomicSMin((AtomicSMin) node);
                case Op.OpAtomicUMin: return VisitAtomicUMin((AtomicUMin) node);
                case Op.OpAtomicSMax: return VisitAtomicSMax((AtomicSMax) node);
                case Op.OpAtomicUMax: return VisitAtomicUMax((AtomicUMax) node);
                case Op.OpAtomicAnd: return VisitAtomicAnd((AtomicAnd) node);
                case Op.OpAtomicOr: return VisitAtomicOr((AtomicOr) node);
                case Op.OpAtomicXor: return VisitAtomicXor((AtomicXor) node);
                case Op.OpPhi: return VisitPhi((Phi) node);
                case Op.OpLoopMerge: return VisitLoopMerge((LoopMerge) node);
                case Op.OpSelectionMerge: return VisitSelectionMerge((SelectionMerge) node);
                case Op.OpLabel: return VisitLabel((Label) node);
                case Op.OpBranch: return VisitBranch((Branch) node);
                case Op.OpBranchConditional: return VisitBranchConditional((BranchConditional) node);
                case Op.OpSwitch: return VisitSwitch((Switch) node);
                case Op.OpKill: return VisitKill((Kill) node);
                case Op.OpReturn: return VisitReturn((Return) node);
                case Op.OpReturnValue: return VisitReturnValue((ReturnValue) node);
                case Op.OpUnreachable: return VisitUnreachable((Unreachable) node);
                case Op.OpLifetimeStart: return VisitLifetimeStart((LifetimeStart) node);
                case Op.OpLifetimeStop: return VisitLifetimeStop((LifetimeStop) node);
                case Op.OpGroupAsyncCopy: return VisitGroupAsyncCopy((GroupAsyncCopy) node);
                case Op.OpGroupWaitEvents: return VisitGroupWaitEvents((GroupWaitEvents) node);
                case Op.OpGroupAll: return VisitGroupAll((GroupAll) node);
                case Op.OpGroupAny: return VisitGroupAny((GroupAny) node);
                case Op.OpGroupBroadcast: return VisitGroupBroadcast((GroupBroadcast) node);
                case Op.OpGroupIAdd: return VisitGroupIAdd((GroupIAdd) node);
                case Op.OpGroupFAdd: return VisitGroupFAdd((GroupFAdd) node);
                case Op.OpGroupFMin: return VisitGroupFMin((GroupFMin) node);
                case Op.OpGroupUMin: return VisitGroupUMin((GroupUMin) node);
                case Op.OpGroupSMin: return VisitGroupSMin((GroupSMin) node);
                case Op.OpGroupFMax: return VisitGroupFMax((GroupFMax) node);
                case Op.OpGroupUMax: return VisitGroupUMax((GroupUMax) node);
                case Op.OpGroupSMax: return VisitGroupSMax((GroupSMax) node);
                case Op.OpReadPipe: return VisitReadPipe((ReadPipe) node);
                case Op.OpWritePipe: return VisitWritePipe((WritePipe) node);
                case Op.OpReservedReadPipe: return VisitReservedReadPipe((ReservedReadPipe) node);
                case Op.OpReservedWritePipe: return VisitReservedWritePipe((ReservedWritePipe) node);
                case Op.OpReserveReadPipePackets: return VisitReserveReadPipePackets((ReserveReadPipePackets) node);
                case Op.OpReserveWritePipePackets: return VisitReserveWritePipePackets((ReserveWritePipePackets) node);
                case Op.OpCommitReadPipe: return VisitCommitReadPipe((CommitReadPipe) node);
                case Op.OpCommitWritePipe: return VisitCommitWritePipe((CommitWritePipe) node);
                case Op.OpIsValidReserveId: return VisitIsValidReserveId((IsValidReserveId) node);
                case Op.OpGetNumPipePackets: return VisitGetNumPipePackets((GetNumPipePackets) node);
                case Op.OpGetMaxPipePackets: return VisitGetMaxPipePackets((GetMaxPipePackets) node);
                case Op.OpGroupReserveReadPipePackets: return VisitGroupReserveReadPipePackets((GroupReserveReadPipePackets) node);
                case Op.OpGroupReserveWritePipePackets: return VisitGroupReserveWritePipePackets((GroupReserveWritePipePackets) node);
                case Op.OpGroupCommitReadPipe: return VisitGroupCommitReadPipe((GroupCommitReadPipe) node);
                case Op.OpGroupCommitWritePipe: return VisitGroupCommitWritePipe((GroupCommitWritePipe) node);
                case Op.OpEnqueueMarker: return VisitEnqueueMarker((EnqueueMarker) node);
                case Op.OpEnqueueKernel: return VisitEnqueueKernel((EnqueueKernel) node);
                case Op.OpGetKernelNDrangeSubGroupCount: return VisitGetKernelNDrangeSubGroupCount((GetKernelNDrangeSubGroupCount) node);
                case Op.OpGetKernelNDrangeMaxSubGroupSize: return VisitGetKernelNDrangeMaxSubGroupSize((GetKernelNDrangeMaxSubGroupSize) node);
                case Op.OpGetKernelWorkGroupSize: return VisitGetKernelWorkGroupSize((GetKernelWorkGroupSize) node);
                case Op.OpGetKernelPreferredWorkGroupSizeMultiple: return VisitGetKernelPreferredWorkGroupSizeMultiple((GetKernelPreferredWorkGroupSizeMultiple) node);
                case Op.OpRetainEvent: return VisitRetainEvent((RetainEvent) node);
                case Op.OpReleaseEvent: return VisitReleaseEvent((ReleaseEvent) node);
                case Op.OpCreateUserEvent: return VisitCreateUserEvent((CreateUserEvent) node);
                case Op.OpIsValidEvent: return VisitIsValidEvent((IsValidEvent) node);
                case Op.OpSetUserEventStatus: return VisitSetUserEventStatus((SetUserEventStatus) node);
                case Op.OpCaptureEventProfilingInfo: return VisitCaptureEventProfilingInfo((CaptureEventProfilingInfo) node);
                case Op.OpGetDefaultQueue: return VisitGetDefaultQueue((GetDefaultQueue) node);
                case Op.OpBuildNDRange: return VisitBuildNDRange((BuildNDRange) node);
                case Op.OpImageSparseSampleImplicitLod: return VisitImageSparseSampleImplicitLod((ImageSparseSampleImplicitLod) node);
                case Op.OpImageSparseSampleExplicitLod: return VisitImageSparseSampleExplicitLod((ImageSparseSampleExplicitLod) node);
                case Op.OpImageSparseSampleDrefImplicitLod: return VisitImageSparseSampleDrefImplicitLod((ImageSparseSampleDrefImplicitLod) node);
                case Op.OpImageSparseSampleDrefExplicitLod: return VisitImageSparseSampleDrefExplicitLod((ImageSparseSampleDrefExplicitLod) node);
                case Op.OpImageSparseSampleProjImplicitLod: return VisitImageSparseSampleProjImplicitLod((ImageSparseSampleProjImplicitLod) node);
                case Op.OpImageSparseSampleProjExplicitLod: return VisitImageSparseSampleProjExplicitLod((ImageSparseSampleProjExplicitLod) node);
                case Op.OpImageSparseSampleProjDrefImplicitLod: return VisitImageSparseSampleProjDrefImplicitLod((ImageSparseSampleProjDrefImplicitLod) node);
                case Op.OpImageSparseSampleProjDrefExplicitLod: return VisitImageSparseSampleProjDrefExplicitLod((ImageSparseSampleProjDrefExplicitLod) node);
                case Op.OpImageSparseFetch: return VisitImageSparseFetch((ImageSparseFetch) node);
                case Op.OpImageSparseGather: return VisitImageSparseGather((ImageSparseGather) node);
                case Op.OpImageSparseDrefGather: return VisitImageSparseDrefGather((ImageSparseDrefGather) node);
                case Op.OpImageSparseTexelsResident: return VisitImageSparseTexelsResident((ImageSparseTexelsResident) node);
                case Op.OpNoLine: return VisitNoLine((NoLine) node);
                case Op.OpAtomicFlagTestAndSet: return VisitAtomicFlagTestAndSet((AtomicFlagTestAndSet) node);
                case Op.OpAtomicFlagClear: return VisitAtomicFlagClear((AtomicFlagClear) node);
                case Op.OpImageSparseRead: return VisitImageSparseRead((ImageSparseRead) node);
                case Op.OpDecorateId: return VisitDecorateId((DecorateId) node);
                case Op.OpSubgroupBallotKHR: return VisitSubgroupBallotKHR((SubgroupBallotKHR) node);
                case Op.OpSubgroupFirstInvocationKHR: return VisitSubgroupFirstInvocationKHR((SubgroupFirstInvocationKHR) node);
                case Op.OpSubgroupAllKHR: return VisitSubgroupAllKHR((SubgroupAllKHR) node);
                case Op.OpSubgroupAnyKHR: return VisitSubgroupAnyKHR((SubgroupAnyKHR) node);
                case Op.OpSubgroupAllEqualKHR: return VisitSubgroupAllEqualKHR((SubgroupAllEqualKHR) node);
                case Op.OpSubgroupReadInvocationKHR: return VisitSubgroupReadInvocationKHR((SubgroupReadInvocationKHR) node);
                case Op.OpGroupIAddNonUniformAMD: return VisitGroupIAddNonUniformAMD((GroupIAddNonUniformAMD) node);
                case Op.OpGroupFAddNonUniformAMD: return VisitGroupFAddNonUniformAMD((GroupFAddNonUniformAMD) node);
                case Op.OpGroupFMinNonUniformAMD: return VisitGroupFMinNonUniformAMD((GroupFMinNonUniformAMD) node);
                case Op.OpGroupUMinNonUniformAMD: return VisitGroupUMinNonUniformAMD((GroupUMinNonUniformAMD) node);
                case Op.OpGroupSMinNonUniformAMD: return VisitGroupSMinNonUniformAMD((GroupSMinNonUniformAMD) node);
                case Op.OpGroupFMaxNonUniformAMD: return VisitGroupFMaxNonUniformAMD((GroupFMaxNonUniformAMD) node);
                case Op.OpGroupUMaxNonUniformAMD: return VisitGroupUMaxNonUniformAMD((GroupUMaxNonUniformAMD) node);
                case Op.OpGroupSMaxNonUniformAMD: return VisitGroupSMaxNonUniformAMD((GroupSMaxNonUniformAMD) node);
                case Op.OpFragmentMaskFetchAMD: return VisitFragmentMaskFetchAMD((FragmentMaskFetchAMD) node);
                case Op.OpFragmentFetchAMD: return VisitFragmentFetchAMD((FragmentFetchAMD) node);
                case Op.OpSubgroupShuffleINTEL: return VisitSubgroupShuffleINTEL((SubgroupShuffleINTEL) node);
                case Op.OpSubgroupShuffleDownINTEL: return VisitSubgroupShuffleDownINTEL((SubgroupShuffleDownINTEL) node);
                case Op.OpSubgroupShuffleUpINTEL: return VisitSubgroupShuffleUpINTEL((SubgroupShuffleUpINTEL) node);
                case Op.OpSubgroupShuffleXorINTEL: return VisitSubgroupShuffleXorINTEL((SubgroupShuffleXorINTEL) node);
                case Op.OpSubgroupBlockReadINTEL: return VisitSubgroupBlockReadINTEL((SubgroupBlockReadINTEL) node);
                case Op.OpSubgroupBlockWriteINTEL: return VisitSubgroupBlockWriteINTEL((SubgroupBlockWriteINTEL) node);
                case Op.OpSubgroupImageBlockReadINTEL: return VisitSubgroupImageBlockReadINTEL((SubgroupImageBlockReadINTEL) node);
                case Op.OpSubgroupImageBlockWriteINTEL: return VisitSubgroupImageBlockWriteINTEL((SubgroupImageBlockWriteINTEL) node);
                case Op.OpDecorateStringGOOGLE: return VisitDecorateStringGOOGLE((DecorateStringGOOGLE) node);
                case Op.OpMemberDecorateStringGOOGLE: return VisitMemberDecorateStringGOOGLE((MemberDecorateStringGOOGLE) node);
            }

            throw new NotImplementedException(node.OpCode + " not implemented yet.");
        }
        
        protected void VisitDecorations(Node node)
        {
            foreach (var decoration in node.GetDecorations())
            {
                Visit(new Decorate() {Decoration = decoration, Target = node});
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

        protected virtual Spv.ImageOperands Visit(Spv.ImageOperands operand)
        {
            return operand;
        }
        protected virtual Spv.FPFastMathMode Visit(Spv.FPFastMathMode operand)
        {
            return operand;
        }
        protected virtual Spv.SelectionControl Visit(Spv.SelectionControl operand)
        {
            return operand;
        }
        protected virtual Spv.LoopControl Visit(Spv.LoopControl operand)
        {
            return operand;
        }
        protected virtual Spv.FunctionControl Visit(Spv.FunctionControl operand)
        {
            return operand;
        }
        protected virtual Spv.MemorySemantics Visit(Spv.MemorySemantics operand)
        {
            return operand;
        }
        protected virtual Spv.MemoryAccess Visit(Spv.MemoryAccess operand)
        {
            return operand;
        }
        protected virtual Spv.KernelProfilingInfo Visit(Spv.KernelProfilingInfo operand)
        {
            return operand;
        }
        protected virtual Spv.SourceLanguage Visit(Spv.SourceLanguage operand)
        {
            return operand;
        }
        protected virtual Spv.ExecutionModel Visit(Spv.ExecutionModel operand)
        {
            return operand;
        }
        protected virtual Spv.AddressingModel Visit(Spv.AddressingModel operand)
        {
            return operand;
        }
        protected virtual Spv.MemoryModel Visit(Spv.MemoryModel operand)
        {
            return operand;
        }
        protected virtual Spv.ExecutionMode Visit(Spv.ExecutionMode operand)
        {
            return operand;
        }
        protected virtual Spv.StorageClass Visit(Spv.StorageClass operand)
        {
            return operand;
        }
        protected virtual Spv.Dim Visit(Spv.Dim operand)
        {
            return operand;
        }
        protected virtual Spv.SamplerAddressingMode Visit(Spv.SamplerAddressingMode operand)
        {
            return operand;
        }
        protected virtual Spv.SamplerFilterMode Visit(Spv.SamplerFilterMode operand)
        {
            return operand;
        }
        protected virtual Spv.ImageFormat Visit(Spv.ImageFormat operand)
        {
            return operand;
        }
        protected virtual Spv.ImageChannelOrder Visit(Spv.ImageChannelOrder operand)
        {
            return operand;
        }
        protected virtual Spv.ImageChannelDataType Visit(Spv.ImageChannelDataType operand)
        {
            return operand;
        }
        protected virtual Spv.FPRoundingMode Visit(Spv.FPRoundingMode operand)
        {
            return operand;
        }
        protected virtual Spv.LinkageType Visit(Spv.LinkageType operand)
        {
            return operand;
        }
        protected virtual Spv.AccessQualifier Visit(Spv.AccessQualifier operand)
        {
            return operand;
        }
        protected virtual Spv.FunctionParameterAttribute Visit(Spv.FunctionParameterAttribute operand)
        {
            return operand;
        }
        protected virtual Spv.Decoration Visit(Spv.Decoration operand)
        {
            return operand;
        }
        protected virtual Spv.BuiltIn Visit(Spv.BuiltIn operand)
        {
            return operand;
        }
        protected virtual Spv.Scope Visit(Spv.Scope operand)
        {
            return operand;
        }
        protected virtual Spv.GroupOperation Visit(Spv.GroupOperation operand)
        {
            return operand;
        }
        protected virtual Spv.KernelEnqueueFlags Visit(Spv.KernelEnqueueFlags operand)
        {
            return operand;
        }
        protected virtual Spv.Capability Visit(Spv.Capability operand)
        {
            return operand;
        }
        protected virtual IList<Spv.PairLiteralIntegerIdRef> Visit(IList<Spv.PairLiteralIntegerIdRef> operand)
        {
            return operand;
        }
        protected virtual IList<Spv.PairIdRefLiteralInteger> Visit(IList<Spv.PairIdRefLiteralInteger> operand)
        {
            return operand;
        }
        protected virtual IList<Spv.PairIdRefIdRef> Visit(IList<Spv.PairIdRefIdRef> operand)
        {
            return operand;
        }
        protected virtual OpNop VisitNop(Nodes.Nop node)
        {
            var instruction = new OpNop();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpUndef VisitUndef(Nodes.Undef node)
        {
            var instruction = new OpUndef();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            return instruction;
        }
        protected virtual OpSourceContinued VisitSourceContinued(Nodes.SourceContinued node)
        {
            var instruction = new OpSourceContinued();
            _instructionMap.Add(node, instruction);

            instruction.ContinuedSource = Visit(node.ContinuedSource);
            return instruction;
        }
        protected virtual OpSource VisitSource(Nodes.Source node)
        {
            var instruction = new OpSource();
            _instructionMap.Add(node, instruction);

            instruction.SourceLanguage = Visit(node.SourceLanguage);
            instruction.Version = Visit(node.Version);
            instruction.File = Visit(node.File);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpSourceExtension VisitSourceExtension(Nodes.SourceExtension node)
        {
            var instruction = new OpSourceExtension();
            _instructionMap.Add(node, instruction);

            instruction.Extension = Visit(node.Extension);
            return instruction;
        }
        protected virtual OpName VisitName(Nodes.Name node)
        {
            var instruction = new OpName();
            _instructionMap.Add(node, instruction);

            instruction.Target = Visit(node.Target);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpMemberName VisitMemberName(Nodes.MemberName node)
        {
            var instruction = new OpMemberName();
            _instructionMap.Add(node, instruction);

            instruction.Type = Visit(node.Type);
            instruction.Member = Visit(node.Member);
            instruction.Name = Visit(node.Name);
            return instruction;
        }
        protected virtual OpString VisitString(Nodes.String node)
        {
            var instruction = new OpString();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpLine VisitLine(Nodes.Line node)
        {
            var instruction = new OpLine();
            _instructionMap.Add(node, instruction);

            instruction.File = Visit(node.File);
            instruction.Value = Visit(node.Value);
            instruction.Column = Visit(node.Column);
            return instruction;
        }
        protected virtual OpExtension VisitExtension(Nodes.Extension node)
        {
            var instruction = new OpExtension();
            _instructionMap.Add(node, instruction);

            instruction.Name = Visit(node.Name);
            return instruction;
        }
        protected virtual OpExtInstImport VisitExtInstImport(Nodes.ExtInstImport node)
        {
            var instruction = new OpExtInstImport();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.Name = Visit(node.Name);
            return instruction;
        }
        protected virtual OpExtInst VisitExtInst(Nodes.ExtInst node)
        {
            var instruction = new OpExtInst();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Set = Visit(node.Set);
            instruction.Instruction = Visit(node.Instruction);
            instruction.Operands = Visit(node.Operands);
            return instruction;
        }
        protected virtual OpMemoryModel VisitMemoryModel(Nodes.MemoryModel node)
        {
            var instruction = new OpMemoryModel();
            _instructionMap.Add(node, instruction);

            instruction.AddressingModel = Visit(node.AddressingModel);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpEntryPoint VisitEntryPoint(Nodes.EntryPoint node)
        {
            var instruction = new OpEntryPoint();
            _instructionMap.Add(node, instruction);

            instruction.ExecutionModel = Visit(node.ExecutionModel);
            instruction.Value = Visit(node.Value);
            instruction.Name = Visit(node.Name);
            instruction.Interface = Visit(node.Interface);
            return instruction;
        }
        protected virtual OpExecutionMode VisitExecutionMode(Nodes.ExecutionMode node)
        {
            var instruction = new OpExecutionMode();
            _instructionMap.Add(node, instruction);

            instruction.EntryPoint = Visit(node.EntryPoint);
            instruction.Mode = Visit(node.Mode);
            return instruction;
        }
        protected virtual OpCapability VisitCapability(Nodes.Capability node)
        {
            var instruction = new OpCapability();
            _instructionMap.Add(node, instruction);

            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpTypeVoid VisitTypeVoid(SpirvVoid node)
        {
            var instruction = new OpTypeVoid();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeBool VisitTypeBool(SpirvBool node)
        {
            var instruction = new OpTypeBool();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeInt VisitTypeInt(SpirvInt node)
        {
            var instruction = new OpTypeInt();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeFloat VisitTypeFloat(SpirvFloat node)
        {
            var instruction = new OpTypeFloat();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeVector VisitTypeVector(SpirvVector node)
        {
            var instruction = new OpTypeVector();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeMatrix VisitTypeMatrix(SpirvMatrix node)
        {
            var instruction = new OpTypeMatrix();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeImage VisitTypeImage(SpirvImage node)
        {
            var instruction = new OpTypeImage();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeSampler VisitTypeSampler(SpirvSampler node)
        {
            var instruction = new OpTypeSampler();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeSampledImage VisitTypeSampledImage(SpirvSampledImage node)
        {
            var instruction = new OpTypeSampledImage();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeArray VisitTypeArray(SpirvArray node)
        {
            var instruction = new OpTypeArray();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeRuntimeArray VisitTypeRuntimeArray(SpirvRuntimeArray node)
        {
            var instruction = new OpTypeRuntimeArray();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeStruct VisitTypeStruct(SpirvStruct node)
        {
            var instruction = new OpTypeStruct();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeOpaque VisitTypeOpaque(SpirvOpaque node)
        {
            var instruction = new OpTypeOpaque();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypePointer VisitTypePointer(SpirvPointer node)
        {
            var instruction = new OpTypePointer();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeFunction VisitTypeFunction(SpirvFunction node)
        {
            var instruction = new OpTypeFunction();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeEvent VisitTypeEvent(SpirvEvent node)
        {
            var instruction = new OpTypeEvent();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeDeviceEvent VisitTypeDeviceEvent(SpirvDeviceEvent node)
        {
            var instruction = new OpTypeDeviceEvent();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeReserveId VisitTypeReserveId(SpirvReserveId node)
        {
            var instruction = new OpTypeReserveId();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeQueue VisitTypeQueue(SpirvQueue node)
        {
            var instruction = new OpTypeQueue();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypePipe VisitTypePipe(SpirvPipe node)
        {
            var instruction = new OpTypePipe();
            _instructionMap.Add(node, instruction);
            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);

            return instruction;
        }
        protected virtual OpTypeForwardPointer VisitTypeForwardPointer(SpirvForwardPointer node)
        {
            var instruction = new OpTypeForwardPointer();
            _instructionMap.Add(node, instruction);
            return instruction;
        }
        protected virtual OpConstantTrue VisitConstantTrue(Nodes.ConstantTrue node)
        {
            var instruction = new OpConstantTrue();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            return instruction;
        }
        protected virtual OpConstantFalse VisitConstantFalse(Nodes.ConstantFalse node)
        {
            var instruction = new OpConstantFalse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            return instruction;
        }
        protected virtual OpConstant VisitConstant(Nodes.Constant node)
        {
            var instruction = new OpConstant();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpConstantComposite VisitConstantComposite(Nodes.ConstantComposite node)
        {
            var instruction = new OpConstantComposite();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Constituents = Visit(node.Constituents);
            return instruction;
        }
        protected virtual OpConstantSampler VisitConstantSampler(Nodes.ConstantSampler node)
        {
            var instruction = new OpConstantSampler();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SamplerAddressingMode = Visit(node.SamplerAddressingMode);
            instruction.Param = Visit(node.Param);
            instruction.SamplerFilterMode = Visit(node.SamplerFilterMode);
            return instruction;
        }
        protected virtual OpConstantNull VisitConstantNull(Nodes.ConstantNull node)
        {
            var instruction = new OpConstantNull();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            return instruction;
        }
        protected virtual OpSpecConstantTrue VisitSpecConstantTrue(Nodes.SpecConstantTrue node)
        {
            var instruction = new OpSpecConstantTrue();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            return instruction;
        }
        protected virtual OpSpecConstantFalse VisitSpecConstantFalse(Nodes.SpecConstantFalse node)
        {
            var instruction = new OpSpecConstantFalse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            return instruction;
        }
        protected virtual OpSpecConstant VisitSpecConstant(Nodes.SpecConstant node)
        {
            var instruction = new OpSpecConstant();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpSpecConstantComposite VisitSpecConstantComposite(Nodes.SpecConstantComposite node)
        {
            var instruction = new OpSpecConstantComposite();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Constituents = Visit(node.Constituents);
            return instruction;
        }
        protected virtual OpSpecConstantOp VisitSpecConstantOp(Nodes.SpecConstantOp node)
        {
            var instruction = new OpSpecConstantOp();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Opcode = Visit(node.Opcode);
            instruction.Operands = Visit(node.Operands);
            return instruction;
        }
        protected virtual OpFunction VisitFunction(Nodes.Function node)
        {
            var instruction = new OpFunction();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.FunctionControl = Visit(node.FunctionControl);
            instruction.FunctionType = Visit(node.FunctionType);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpFunctionParameter VisitFunctionParameter(Nodes.FunctionParameter node)
        {
            var instruction = new OpFunctionParameter();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            return instruction;
        }
        protected virtual OpFunctionEnd VisitFunctionEnd(Nodes.FunctionEnd node)
        {
            var instruction = new OpFunctionEnd();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpFunctionCall VisitFunctionCall(Nodes.FunctionCall node)
        {
            var instruction = new OpFunctionCall();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Function = Visit(node.Function);
            instruction.Arguments = Visit(node.Arguments);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpVariable VisitVariable(Nodes.Variable node)
        {
            var instruction = new OpVariable();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.StorageClass = Visit(node.StorageClass);
            instruction.Initializer = Visit(node.Initializer);
            return instruction;
        }
        protected virtual OpImageTexelPointer VisitImageTexelPointer(Nodes.ImageTexelPointer node)
        {
            var instruction = new OpImageTexelPointer();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.Sample = Visit(node.Sample);
            return instruction;
        }
        protected virtual OpLoad VisitLoad(Nodes.Load node)
        {
            var instruction = new OpLoad();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.MemoryAccess = Visit(node.MemoryAccess);
            return instruction;
        }
        protected virtual OpStore VisitStore(Nodes.Store node)
        {
            var instruction = new OpStore();
            _instructionMap.Add(node, instruction);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Object = Visit(node.Object);
            instruction.MemoryAccess = Visit(node.MemoryAccess);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpCopyMemory VisitCopyMemory(Nodes.CopyMemory node)
        {
            var instruction = new OpCopyMemory();
            _instructionMap.Add(node, instruction);

            instruction.Target = Visit(node.Target);
            instruction.Source = Visit(node.Source);
            instruction.MemoryAccess = Visit(node.MemoryAccess);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpCopyMemorySized VisitCopyMemorySized(Nodes.CopyMemorySized node)
        {
            var instruction = new OpCopyMemorySized();
            _instructionMap.Add(node, instruction);

            instruction.Target = Visit(node.Target);
            instruction.Source = Visit(node.Source);
            instruction.Size = Visit(node.Size);
            instruction.MemoryAccess = Visit(node.MemoryAccess);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpAccessChain VisitAccessChain(Nodes.AccessChain node)
        {
            var instruction = new OpAccessChain();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            instruction.Indexes = Visit(node.Indexes);
            return instruction;
        }
        protected virtual OpInBoundsAccessChain VisitInBoundsAccessChain(Nodes.InBoundsAccessChain node)
        {
            var instruction = new OpInBoundsAccessChain();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            instruction.Indexes = Visit(node.Indexes);
            return instruction;
        }
        protected virtual OpPtrAccessChain VisitPtrAccessChain(Nodes.PtrAccessChain node)
        {
            var instruction = new OpPtrAccessChain();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            instruction.Element = Visit(node.Element);
            instruction.Indexes = Visit(node.Indexes);
            return instruction;
        }
        protected virtual OpArrayLength VisitArrayLength(Nodes.ArrayLength node)
        {
            var instruction = new OpArrayLength();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Structure = Visit(node.Structure);
            instruction.Arraymember = Visit(node.Arraymember);
            return instruction;
        }
        protected virtual OpGenericPtrMemSemantics VisitGenericPtrMemSemantics(Nodes.GenericPtrMemSemantics node)
        {
            var instruction = new OpGenericPtrMemSemantics();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            return instruction;
        }
        protected virtual OpInBoundsPtrAccessChain VisitInBoundsPtrAccessChain(Nodes.InBoundsPtrAccessChain node)
        {
            var instruction = new OpInBoundsPtrAccessChain();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            instruction.Element = Visit(node.Element);
            instruction.Indexes = Visit(node.Indexes);
            return instruction;
        }
        protected virtual OpDecorate VisitDecorate(Nodes.Decorate node)
        {
            var instruction = new OpDecorate();
            _instructionMap.Add(node, instruction);

            instruction.Target = Visit(node.Target);
            instruction.Decoration = Visit(node.Decoration);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpMemberDecorate VisitMemberDecorate(Nodes.MemberDecorate node)
        {
            var instruction = new OpMemberDecorate();
            _instructionMap.Add(node, instruction);

            instruction.StructureType = Visit(node.StructureType);
            instruction.Member = Visit(node.Member);
            instruction.Decoration = Visit(node.Decoration);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpDecorationGroup VisitDecorationGroup(Nodes.DecorationGroup node)
        {
            var instruction = new OpDecorationGroup();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGroupDecorate VisitGroupDecorate(Nodes.GroupDecorate node)
        {
            var instruction = new OpGroupDecorate();
            _instructionMap.Add(node, instruction);

            instruction.DecorationGroup = Visit(node.DecorationGroup);
            instruction.Targets = Visit(node.Targets);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGroupMemberDecorate VisitGroupMemberDecorate(Nodes.GroupMemberDecorate node)
        {
            var instruction = new OpGroupMemberDecorate();
            _instructionMap.Add(node, instruction);

            instruction.DecorationGroup = Visit(node.DecorationGroup);
            instruction.Targets = Visit(node.Targets);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpVectorExtractDynamic VisitVectorExtractDynamic(Nodes.VectorExtractDynamic node)
        {
            var instruction = new OpVectorExtractDynamic();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Vector = Visit(node.Vector);
            instruction.Index = Visit(node.Index);
            return instruction;
        }
        protected virtual OpVectorInsertDynamic VisitVectorInsertDynamic(Nodes.VectorInsertDynamic node)
        {
            var instruction = new OpVectorInsertDynamic();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Vector = Visit(node.Vector);
            instruction.Component = Visit(node.Component);
            instruction.Index = Visit(node.Index);
            return instruction;
        }
        protected virtual OpVectorShuffle VisitVectorShuffle(Nodes.VectorShuffle node)
        {
            var instruction = new OpVectorShuffle();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Vector1 = Visit(node.Vector1);
            instruction.Vector2 = Visit(node.Vector2);
            instruction.Components = Visit(node.Components);
            return instruction;
        }
        protected virtual OpCompositeConstruct VisitCompositeConstruct(Nodes.CompositeConstruct node)
        {
            var instruction = new OpCompositeConstruct();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Constituents = Visit(node.Constituents);
            return instruction;
        }
        protected virtual OpCompositeExtract VisitCompositeExtract(Nodes.CompositeExtract node)
        {
            var instruction = new OpCompositeExtract();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Composite = Visit(node.Composite);
            instruction.Indexes = Visit(node.Indexes);
            return instruction;
        }
        protected virtual OpCompositeInsert VisitCompositeInsert(Nodes.CompositeInsert node)
        {
            var instruction = new OpCompositeInsert();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Object = Visit(node.Object);
            instruction.Composite = Visit(node.Composite);
            instruction.Indexes = Visit(node.Indexes);
            return instruction;
        }
        protected virtual OpCopyObject VisitCopyObject(Nodes.CopyObject node)
        {
            var instruction = new OpCopyObject();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand = Visit(node.Operand);
            return instruction;
        }
        protected virtual OpTranspose VisitTranspose(Nodes.Transpose node)
        {
            var instruction = new OpTranspose();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Matrix = Visit(node.Matrix);
            return instruction;
        }
        protected virtual OpSampledImage VisitSampledImage(Nodes.SampledImage node)
        {
            var instruction = new OpSampledImage();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            instruction.Sampler = Visit(node.Sampler);
            return instruction;
        }
        protected virtual OpImageSampleImplicitLod VisitImageSampleImplicitLod(Nodes.ImageSampleImplicitLod node)
        {
            var instruction = new OpImageSampleImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSampleExplicitLod VisitImageSampleExplicitLod(Nodes.ImageSampleExplicitLod node)
        {
            var instruction = new OpImageSampleExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSampleDrefImplicitLod VisitImageSampleDrefImplicitLod(Nodes.ImageSampleDrefImplicitLod node)
        {
            var instruction = new OpImageSampleDrefImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.D_ref = Visit(node.D_ref);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSampleDrefExplicitLod VisitImageSampleDrefExplicitLod(Nodes.ImageSampleDrefExplicitLod node)
        {
            var instruction = new OpImageSampleDrefExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.D_ref = Visit(node.D_ref);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSampleProjImplicitLod VisitImageSampleProjImplicitLod(Nodes.ImageSampleProjImplicitLod node)
        {
            var instruction = new OpImageSampleProjImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSampleProjExplicitLod VisitImageSampleProjExplicitLod(Nodes.ImageSampleProjExplicitLod node)
        {
            var instruction = new OpImageSampleProjExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSampleProjDrefImplicitLod VisitImageSampleProjDrefImplicitLod(Nodes.ImageSampleProjDrefImplicitLod node)
        {
            var instruction = new OpImageSampleProjDrefImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.D_ref = Visit(node.D_ref);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSampleProjDrefExplicitLod VisitImageSampleProjDrefExplicitLod(Nodes.ImageSampleProjDrefExplicitLod node)
        {
            var instruction = new OpImageSampleProjDrefExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.D_ref = Visit(node.D_ref);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageFetch VisitImageFetch(Nodes.ImageFetch node)
        {
            var instruction = new OpImageFetch();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageGather VisitImageGather(Nodes.ImageGather node)
        {
            var instruction = new OpImageGather();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.Component = Visit(node.Component);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageDrefGather VisitImageDrefGather(Nodes.ImageDrefGather node)
        {
            var instruction = new OpImageDrefGather();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.D_ref = Visit(node.D_ref);
            instruction.ImageOperands = Visit(node.ImageOperands);
            instruction.Operands = Visit(node.Operands);
            return instruction;
        }
        protected virtual OpImageRead VisitImageRead(Nodes.ImageRead node)
        {
            var instruction = new OpImageRead();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageWrite VisitImageWrite(Nodes.ImageWrite node)
        {
            var instruction = new OpImageWrite();
            _instructionMap.Add(node, instruction);

            instruction.Image = Visit(node.Image);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.Texel = Visit(node.Texel);
            instruction.ImageOperands = Visit(node.ImageOperands);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpImage VisitImage(Nodes.Image node)
        {
            var instruction = new OpImage();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            return instruction;
        }
        protected virtual OpImageQueryFormat VisitImageQueryFormat(Nodes.ImageQueryFormat node)
        {
            var instruction = new OpImageQueryFormat();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            return instruction;
        }
        protected virtual OpImageQueryOrder VisitImageQueryOrder(Nodes.ImageQueryOrder node)
        {
            var instruction = new OpImageQueryOrder();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            return instruction;
        }
        protected virtual OpImageQuerySizeLod VisitImageQuerySizeLod(Nodes.ImageQuerySizeLod node)
        {
            var instruction = new OpImageQuerySizeLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            instruction.LevelofDetail = Visit(node.LevelofDetail);
            return instruction;
        }
        protected virtual OpImageQuerySize VisitImageQuerySize(Nodes.ImageQuerySize node)
        {
            var instruction = new OpImageQuerySize();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            return instruction;
        }
        protected virtual OpImageQueryLod VisitImageQueryLod(Nodes.ImageQueryLod node)
        {
            var instruction = new OpImageQueryLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            return instruction;
        }
        protected virtual OpImageQueryLevels VisitImageQueryLevels(Nodes.ImageQueryLevels node)
        {
            var instruction = new OpImageQueryLevels();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            return instruction;
        }
        protected virtual OpImageQuerySamples VisitImageQuerySamples(Nodes.ImageQuerySamples node)
        {
            var instruction = new OpImageQuerySamples();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            return instruction;
        }
        protected virtual OpConvertFToU VisitConvertFToU(Nodes.ConvertFToU node)
        {
            var instruction = new OpConvertFToU();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.FloatValue = Visit(node.FloatValue);
            return instruction;
        }
        protected virtual OpConvertFToS VisitConvertFToS(Nodes.ConvertFToS node)
        {
            var instruction = new OpConvertFToS();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.FloatValue = Visit(node.FloatValue);
            return instruction;
        }
        protected virtual OpConvertSToF VisitConvertSToF(Nodes.ConvertSToF node)
        {
            var instruction = new OpConvertSToF();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SignedValue = Visit(node.SignedValue);
            return instruction;
        }
        protected virtual OpConvertUToF VisitConvertUToF(Nodes.ConvertUToF node)
        {
            var instruction = new OpConvertUToF();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.UnsignedValue = Visit(node.UnsignedValue);
            return instruction;
        }
        protected virtual OpUConvert VisitUConvert(Nodes.UConvert node)
        {
            var instruction = new OpUConvert();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.UnsignedValue = Visit(node.UnsignedValue);
            return instruction;
        }
        protected virtual OpSConvert VisitSConvert(Nodes.SConvert node)
        {
            var instruction = new OpSConvert();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SignedValue = Visit(node.SignedValue);
            return instruction;
        }
        protected virtual OpFConvert VisitFConvert(Nodes.FConvert node)
        {
            var instruction = new OpFConvert();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.FloatValue = Visit(node.FloatValue);
            return instruction;
        }
        protected virtual OpQuantizeToF16 VisitQuantizeToF16(Nodes.QuantizeToF16 node)
        {
            var instruction = new OpQuantizeToF16();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpConvertPtrToU VisitConvertPtrToU(Nodes.ConvertPtrToU node)
        {
            var instruction = new OpConvertPtrToU();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            return instruction;
        }
        protected virtual OpSatConvertSToU VisitSatConvertSToU(Nodes.SatConvertSToU node)
        {
            var instruction = new OpSatConvertSToU();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SignedValue = Visit(node.SignedValue);
            return instruction;
        }
        protected virtual OpSatConvertUToS VisitSatConvertUToS(Nodes.SatConvertUToS node)
        {
            var instruction = new OpSatConvertUToS();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.UnsignedValue = Visit(node.UnsignedValue);
            return instruction;
        }
        protected virtual OpConvertUToPtr VisitConvertUToPtr(Nodes.ConvertUToPtr node)
        {
            var instruction = new OpConvertUToPtr();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.IntegerValue = Visit(node.IntegerValue);
            return instruction;
        }
        protected virtual OpPtrCastToGeneric VisitPtrCastToGeneric(Nodes.PtrCastToGeneric node)
        {
            var instruction = new OpPtrCastToGeneric();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            return instruction;
        }
        protected virtual OpGenericCastToPtr VisitGenericCastToPtr(Nodes.GenericCastToPtr node)
        {
            var instruction = new OpGenericCastToPtr();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            return instruction;
        }
        protected virtual OpGenericCastToPtrExplicit VisitGenericCastToPtrExplicit(Nodes.GenericCastToPtrExplicit node)
        {
            var instruction = new OpGenericCastToPtrExplicit();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Storage = Visit(node.Storage);
            return instruction;
        }
        protected virtual OpBitcast VisitBitcast(Nodes.Bitcast node)
        {
            var instruction = new OpBitcast();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand = Visit(node.Operand);
            return instruction;
        }
        protected virtual OpSNegate VisitSNegate(Nodes.SNegate node)
        {
            var instruction = new OpSNegate();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand = Visit(node.Operand);
            return instruction;
        }
        protected virtual OpFNegate VisitFNegate(Nodes.FNegate node)
        {
            var instruction = new OpFNegate();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand = Visit(node.Operand);
            return instruction;
        }
        protected virtual OpIAdd VisitIAdd(Nodes.IAdd node)
        {
            var instruction = new OpIAdd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFAdd VisitFAdd(Nodes.FAdd node)
        {
            var instruction = new OpFAdd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpISub VisitISub(Nodes.ISub node)
        {
            var instruction = new OpISub();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFSub VisitFSub(Nodes.FSub node)
        {
            var instruction = new OpFSub();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpIMul VisitIMul(Nodes.IMul node)
        {
            var instruction = new OpIMul();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFMul VisitFMul(Nodes.FMul node)
        {
            var instruction = new OpFMul();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpUDiv VisitUDiv(Nodes.UDiv node)
        {
            var instruction = new OpUDiv();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpSDiv VisitSDiv(Nodes.SDiv node)
        {
            var instruction = new OpSDiv();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFDiv VisitFDiv(Nodes.FDiv node)
        {
            var instruction = new OpFDiv();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpUMod VisitUMod(Nodes.UMod node)
        {
            var instruction = new OpUMod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpSRem VisitSRem(Nodes.SRem node)
        {
            var instruction = new OpSRem();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpSMod VisitSMod(Nodes.SMod node)
        {
            var instruction = new OpSMod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFRem VisitFRem(Nodes.FRem node)
        {
            var instruction = new OpFRem();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFMod VisitFMod(Nodes.FMod node)
        {
            var instruction = new OpFMod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpVectorTimesScalar VisitVectorTimesScalar(Nodes.VectorTimesScalar node)
        {
            var instruction = new OpVectorTimesScalar();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Vector = Visit(node.Vector);
            instruction.Scalar = Visit(node.Scalar);
            return instruction;
        }
        protected virtual OpMatrixTimesScalar VisitMatrixTimesScalar(Nodes.MatrixTimesScalar node)
        {
            var instruction = new OpMatrixTimesScalar();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Matrix = Visit(node.Matrix);
            instruction.Scalar = Visit(node.Scalar);
            return instruction;
        }
        protected virtual OpVectorTimesMatrix VisitVectorTimesMatrix(Nodes.VectorTimesMatrix node)
        {
            var instruction = new OpVectorTimesMatrix();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Vector = Visit(node.Vector);
            instruction.Matrix = Visit(node.Matrix);
            return instruction;
        }
        protected virtual OpMatrixTimesVector VisitMatrixTimesVector(Nodes.MatrixTimesVector node)
        {
            var instruction = new OpMatrixTimesVector();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Matrix = Visit(node.Matrix);
            instruction.Vector = Visit(node.Vector);
            return instruction;
        }
        protected virtual OpMatrixTimesMatrix VisitMatrixTimesMatrix(Nodes.MatrixTimesMatrix node)
        {
            var instruction = new OpMatrixTimesMatrix();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.LeftMatrix = Visit(node.LeftMatrix);
            instruction.RightMatrix = Visit(node.RightMatrix);
            return instruction;
        }
        protected virtual OpOuterProduct VisitOuterProduct(Nodes.OuterProduct node)
        {
            var instruction = new OpOuterProduct();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Vector1 = Visit(node.Vector1);
            instruction.Vector2 = Visit(node.Vector2);
            return instruction;
        }
        protected virtual OpDot VisitDot(Nodes.Dot node)
        {
            var instruction = new OpDot();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Vector1 = Visit(node.Vector1);
            instruction.Vector2 = Visit(node.Vector2);
            return instruction;
        }
        protected virtual OpIAddCarry VisitIAddCarry(Nodes.IAddCarry node)
        {
            var instruction = new OpIAddCarry();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpISubBorrow VisitISubBorrow(Nodes.ISubBorrow node)
        {
            var instruction = new OpISubBorrow();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpUMulExtended VisitUMulExtended(Nodes.UMulExtended node)
        {
            var instruction = new OpUMulExtended();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpSMulExtended VisitSMulExtended(Nodes.SMulExtended node)
        {
            var instruction = new OpSMulExtended();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpAny VisitAny(Nodes.Any node)
        {
            var instruction = new OpAny();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Vector = Visit(node.Vector);
            return instruction;
        }
        protected virtual OpAll VisitAll(Nodes.All node)
        {
            var instruction = new OpAll();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Vector = Visit(node.Vector);
            return instruction;
        }
        protected virtual OpIsNan VisitIsNan(Nodes.IsNan node)
        {
            var instruction = new OpIsNan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.x = Visit(node.x);
            return instruction;
        }
        protected virtual OpIsInf VisitIsInf(Nodes.IsInf node)
        {
            var instruction = new OpIsInf();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.x = Visit(node.x);
            return instruction;
        }
        protected virtual OpIsFinite VisitIsFinite(Nodes.IsFinite node)
        {
            var instruction = new OpIsFinite();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.x = Visit(node.x);
            return instruction;
        }
        protected virtual OpIsNormal VisitIsNormal(Nodes.IsNormal node)
        {
            var instruction = new OpIsNormal();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.x = Visit(node.x);
            return instruction;
        }
        protected virtual OpSignBitSet VisitSignBitSet(Nodes.SignBitSet node)
        {
            var instruction = new OpSignBitSet();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.x = Visit(node.x);
            return instruction;
        }
        protected virtual OpLessOrGreater VisitLessOrGreater(Nodes.LessOrGreater node)
        {
            var instruction = new OpLessOrGreater();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.x = Visit(node.x);
            instruction.y = Visit(node.y);
            return instruction;
        }
        protected virtual OpOrdered VisitOrdered(Nodes.Ordered node)
        {
            var instruction = new OpOrdered();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.x = Visit(node.x);
            instruction.y = Visit(node.y);
            return instruction;
        }
        protected virtual OpUnordered VisitUnordered(Nodes.Unordered node)
        {
            var instruction = new OpUnordered();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.x = Visit(node.x);
            instruction.y = Visit(node.y);
            return instruction;
        }
        protected virtual OpLogicalEqual VisitLogicalEqual(Nodes.LogicalEqual node)
        {
            var instruction = new OpLogicalEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpLogicalNotEqual VisitLogicalNotEqual(Nodes.LogicalNotEqual node)
        {
            var instruction = new OpLogicalNotEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpLogicalOr VisitLogicalOr(Nodes.LogicalOr node)
        {
            var instruction = new OpLogicalOr();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpLogicalAnd VisitLogicalAnd(Nodes.LogicalAnd node)
        {
            var instruction = new OpLogicalAnd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpLogicalNot VisitLogicalNot(Nodes.LogicalNot node)
        {
            var instruction = new OpLogicalNot();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand = Visit(node.Operand);
            return instruction;
        }
        protected virtual OpSelect VisitSelect(Nodes.Select node)
        {
            var instruction = new OpSelect();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Condition = Visit(node.Condition);
            instruction.Object1 = Visit(node.Object1);
            instruction.Object2 = Visit(node.Object2);
            return instruction;
        }
        protected virtual OpIEqual VisitIEqual(Nodes.IEqual node)
        {
            var instruction = new OpIEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpINotEqual VisitINotEqual(Nodes.INotEqual node)
        {
            var instruction = new OpINotEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpUGreaterThan VisitUGreaterThan(Nodes.UGreaterThan node)
        {
            var instruction = new OpUGreaterThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpSGreaterThan VisitSGreaterThan(Nodes.SGreaterThan node)
        {
            var instruction = new OpSGreaterThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpUGreaterThanEqual VisitUGreaterThanEqual(Nodes.UGreaterThanEqual node)
        {
            var instruction = new OpUGreaterThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpSGreaterThanEqual VisitSGreaterThanEqual(Nodes.SGreaterThanEqual node)
        {
            var instruction = new OpSGreaterThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpULessThan VisitULessThan(Nodes.ULessThan node)
        {
            var instruction = new OpULessThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpSLessThan VisitSLessThan(Nodes.SLessThan node)
        {
            var instruction = new OpSLessThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpULessThanEqual VisitULessThanEqual(Nodes.ULessThanEqual node)
        {
            var instruction = new OpULessThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpSLessThanEqual VisitSLessThanEqual(Nodes.SLessThanEqual node)
        {
            var instruction = new OpSLessThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFOrdEqual VisitFOrdEqual(Nodes.FOrdEqual node)
        {
            var instruction = new OpFOrdEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFUnordEqual VisitFUnordEqual(Nodes.FUnordEqual node)
        {
            var instruction = new OpFUnordEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFOrdNotEqual VisitFOrdNotEqual(Nodes.FOrdNotEqual node)
        {
            var instruction = new OpFOrdNotEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFUnordNotEqual VisitFUnordNotEqual(Nodes.FUnordNotEqual node)
        {
            var instruction = new OpFUnordNotEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFOrdLessThan VisitFOrdLessThan(Nodes.FOrdLessThan node)
        {
            var instruction = new OpFOrdLessThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFUnordLessThan VisitFUnordLessThan(Nodes.FUnordLessThan node)
        {
            var instruction = new OpFUnordLessThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFOrdGreaterThan VisitFOrdGreaterThan(Nodes.FOrdGreaterThan node)
        {
            var instruction = new OpFOrdGreaterThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFUnordGreaterThan VisitFUnordGreaterThan(Nodes.FUnordGreaterThan node)
        {
            var instruction = new OpFUnordGreaterThan();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFOrdLessThanEqual VisitFOrdLessThanEqual(Nodes.FOrdLessThanEqual node)
        {
            var instruction = new OpFOrdLessThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFUnordLessThanEqual VisitFUnordLessThanEqual(Nodes.FUnordLessThanEqual node)
        {
            var instruction = new OpFUnordLessThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFOrdGreaterThanEqual VisitFOrdGreaterThanEqual(Nodes.FOrdGreaterThanEqual node)
        {
            var instruction = new OpFOrdGreaterThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpFUnordGreaterThanEqual VisitFUnordGreaterThanEqual(Nodes.FUnordGreaterThanEqual node)
        {
            var instruction = new OpFUnordGreaterThanEqual();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpShiftRightLogical VisitShiftRightLogical(Nodes.ShiftRightLogical node)
        {
            var instruction = new OpShiftRightLogical();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            instruction.Shift = Visit(node.Shift);
            return instruction;
        }
        protected virtual OpShiftRightArithmetic VisitShiftRightArithmetic(Nodes.ShiftRightArithmetic node)
        {
            var instruction = new OpShiftRightArithmetic();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            instruction.Shift = Visit(node.Shift);
            return instruction;
        }
        protected virtual OpShiftLeftLogical VisitShiftLeftLogical(Nodes.ShiftLeftLogical node)
        {
            var instruction = new OpShiftLeftLogical();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            instruction.Shift = Visit(node.Shift);
            return instruction;
        }
        protected virtual OpBitwiseOr VisitBitwiseOr(Nodes.BitwiseOr node)
        {
            var instruction = new OpBitwiseOr();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpBitwiseXor VisitBitwiseXor(Nodes.BitwiseXor node)
        {
            var instruction = new OpBitwiseXor();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpBitwiseAnd VisitBitwiseAnd(Nodes.BitwiseAnd node)
        {
            var instruction = new OpBitwiseAnd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand1 = Visit(node.Operand1);
            instruction.Operand2 = Visit(node.Operand2);
            return instruction;
        }
        protected virtual OpNot VisitNot(Nodes.Not node)
        {
            var instruction = new OpNot();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Operand = Visit(node.Operand);
            return instruction;
        }
        protected virtual OpBitFieldInsert VisitBitFieldInsert(Nodes.BitFieldInsert node)
        {
            var instruction = new OpBitFieldInsert();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            instruction.Insert = Visit(node.Insert);
            instruction.Offset = Visit(node.Offset);
            instruction.Count = Visit(node.Count);
            return instruction;
        }
        protected virtual OpBitFieldSExtract VisitBitFieldSExtract(Nodes.BitFieldSExtract node)
        {
            var instruction = new OpBitFieldSExtract();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            instruction.Offset = Visit(node.Offset);
            instruction.Count = Visit(node.Count);
            return instruction;
        }
        protected virtual OpBitFieldUExtract VisitBitFieldUExtract(Nodes.BitFieldUExtract node)
        {
            var instruction = new OpBitFieldUExtract();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            instruction.Offset = Visit(node.Offset);
            instruction.Count = Visit(node.Count);
            return instruction;
        }
        protected virtual OpBitReverse VisitBitReverse(Nodes.BitReverse node)
        {
            var instruction = new OpBitReverse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            return instruction;
        }
        protected virtual OpBitCount VisitBitCount(Nodes.BitCount node)
        {
            var instruction = new OpBitCount();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Base = Visit(node.Base);
            return instruction;
        }
        protected virtual OpDPdx VisitDPdx(Nodes.DPdx node)
        {
            var instruction = new OpDPdx();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.P = Visit(node.P);
            return instruction;
        }
        protected virtual OpDPdy VisitDPdy(Nodes.DPdy node)
        {
            var instruction = new OpDPdy();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.P = Visit(node.P);
            return instruction;
        }
        protected virtual OpFwidth VisitFwidth(Nodes.Fwidth node)
        {
            var instruction = new OpFwidth();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.P = Visit(node.P);
            return instruction;
        }
        protected virtual OpDPdxFine VisitDPdxFine(Nodes.DPdxFine node)
        {
            var instruction = new OpDPdxFine();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.P = Visit(node.P);
            return instruction;
        }
        protected virtual OpDPdyFine VisitDPdyFine(Nodes.DPdyFine node)
        {
            var instruction = new OpDPdyFine();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.P = Visit(node.P);
            return instruction;
        }
        protected virtual OpFwidthFine VisitFwidthFine(Nodes.FwidthFine node)
        {
            var instruction = new OpFwidthFine();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.P = Visit(node.P);
            return instruction;
        }
        protected virtual OpDPdxCoarse VisitDPdxCoarse(Nodes.DPdxCoarse node)
        {
            var instruction = new OpDPdxCoarse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.P = Visit(node.P);
            return instruction;
        }
        protected virtual OpDPdyCoarse VisitDPdyCoarse(Nodes.DPdyCoarse node)
        {
            var instruction = new OpDPdyCoarse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.P = Visit(node.P);
            return instruction;
        }
        protected virtual OpFwidthCoarse VisitFwidthCoarse(Nodes.FwidthCoarse node)
        {
            var instruction = new OpFwidthCoarse();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.P = Visit(node.P);
            return instruction;
        }
        protected virtual OpEmitVertex VisitEmitVertex(Nodes.EmitVertex node)
        {
            var instruction = new OpEmitVertex();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpEndPrimitive VisitEndPrimitive(Nodes.EndPrimitive node)
        {
            var instruction = new OpEndPrimitive();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpEmitStreamVertex VisitEmitStreamVertex(Nodes.EmitStreamVertex node)
        {
            var instruction = new OpEmitStreamVertex();
            _instructionMap.Add(node, instruction);

            instruction.Stream = Visit(node.Stream);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpEndStreamPrimitive VisitEndStreamPrimitive(Nodes.EndStreamPrimitive node)
        {
            var instruction = new OpEndStreamPrimitive();
            _instructionMap.Add(node, instruction);

            instruction.Stream = Visit(node.Stream);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpControlBarrier VisitControlBarrier(Nodes.ControlBarrier node)
        {
            var instruction = new OpControlBarrier();
            _instructionMap.Add(node, instruction);

            instruction.Execution = Visit(node.Execution);
            instruction.Memory = Visit(node.Memory);
            instruction.Semantics = Visit(node.Semantics);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpMemoryBarrier VisitMemoryBarrier(Nodes.MemoryBarrier node)
        {
            var instruction = new OpMemoryBarrier();
            _instructionMap.Add(node, instruction);

            instruction.Memory = Visit(node.Memory);
            instruction.Semantics = Visit(node.Semantics);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpAtomicLoad VisitAtomicLoad(Nodes.AtomicLoad node)
        {
            var instruction = new OpAtomicLoad();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            return instruction;
        }
        protected virtual OpAtomicStore VisitAtomicStore(Nodes.AtomicStore node)
        {
            var instruction = new OpAtomicStore();
            _instructionMap.Add(node, instruction);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpAtomicExchange VisitAtomicExchange(Nodes.AtomicExchange node)
        {
            var instruction = new OpAtomicExchange();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpAtomicCompareExchange VisitAtomicCompareExchange(Nodes.AtomicCompareExchange node)
        {
            var instruction = new OpAtomicCompareExchange();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Equal = Visit(node.Equal);
            instruction.Unequal = Visit(node.Unequal);
            instruction.Value = Visit(node.Value);
            instruction.Comparator = Visit(node.Comparator);
            return instruction;
        }
        protected virtual OpAtomicCompareExchangeWeak VisitAtomicCompareExchangeWeak(Nodes.AtomicCompareExchangeWeak node)
        {
            var instruction = new OpAtomicCompareExchangeWeak();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Equal = Visit(node.Equal);
            instruction.Unequal = Visit(node.Unequal);
            instruction.Value = Visit(node.Value);
            instruction.Comparator = Visit(node.Comparator);
            return instruction;
        }
        protected virtual OpAtomicIIncrement VisitAtomicIIncrement(Nodes.AtomicIIncrement node)
        {
            var instruction = new OpAtomicIIncrement();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            return instruction;
        }
        protected virtual OpAtomicIDecrement VisitAtomicIDecrement(Nodes.AtomicIDecrement node)
        {
            var instruction = new OpAtomicIDecrement();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            return instruction;
        }
        protected virtual OpAtomicIAdd VisitAtomicIAdd(Nodes.AtomicIAdd node)
        {
            var instruction = new OpAtomicIAdd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpAtomicISub VisitAtomicISub(Nodes.AtomicISub node)
        {
            var instruction = new OpAtomicISub();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpAtomicSMin VisitAtomicSMin(Nodes.AtomicSMin node)
        {
            var instruction = new OpAtomicSMin();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpAtomicUMin VisitAtomicUMin(Nodes.AtomicUMin node)
        {
            var instruction = new OpAtomicUMin();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpAtomicSMax VisitAtomicSMax(Nodes.AtomicSMax node)
        {
            var instruction = new OpAtomicSMax();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpAtomicUMax VisitAtomicUMax(Nodes.AtomicUMax node)
        {
            var instruction = new OpAtomicUMax();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpAtomicAnd VisitAtomicAnd(Nodes.AtomicAnd node)
        {
            var instruction = new OpAtomicAnd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpAtomicOr VisitAtomicOr(Nodes.AtomicOr node)
        {
            var instruction = new OpAtomicOr();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpAtomicXor VisitAtomicXor(Nodes.AtomicXor node)
        {
            var instruction = new OpAtomicXor();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpPhi VisitPhi(Nodes.Phi node)
        {
            var instruction = new OpPhi();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.VariableParent = Visit(node.VariableParent);
            return instruction;
        }
        protected virtual OpLoopMerge VisitLoopMerge(Nodes.LoopMerge node)
        {
            var instruction = new OpLoopMerge();
            _instructionMap.Add(node, instruction);

            instruction.MergeBlock = Visit(node.MergeBlock);
            instruction.ContinueTarget = Visit(node.ContinueTarget);
            instruction.LoopControl = Visit(node.LoopControl);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpSelectionMerge VisitSelectionMerge(Nodes.SelectionMerge node)
        {
            var instruction = new OpSelectionMerge();
            _instructionMap.Add(node, instruction);

            instruction.MergeBlock = Visit(node.MergeBlock);
            instruction.SelectionControl = Visit(node.SelectionControl);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpLabel VisitLabel(Nodes.Label node)
        {
            var instruction = new OpLabel();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpBranch VisitBranch(Nodes.Branch node)
        {
            var instruction = new OpBranch();
            _instructionMap.Add(node, instruction);

            instruction.TargetLabel = Visit(node.TargetLabel);
            return instruction;
        }
        protected virtual OpBranchConditional VisitBranchConditional(Nodes.BranchConditional node)
        {
            var instruction = new OpBranchConditional();
            _instructionMap.Add(node, instruction);

            instruction.Condition = Visit(node.Condition);
            instruction.TrueLabel = Visit(node.TrueLabel);
            instruction.FalseLabel = Visit(node.FalseLabel);
            instruction.Branchweights = Visit(node.Branchweights);
            return instruction;
        }
        protected virtual OpSwitch VisitSwitch(Nodes.Switch node)
        {
            var instruction = new OpSwitch();
            _instructionMap.Add(node, instruction);

            instruction.Selector = Visit(node.Selector);
            instruction.Default = Visit(node.Default);
            instruction.Target = Visit(node.Target);
            return instruction;
        }
        protected virtual OpKill VisitKill(Nodes.Kill node)
        {
            var instruction = new OpKill();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpReturn VisitReturn(Nodes.Return node)
        {
            var instruction = new OpReturn();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpReturnValue VisitReturnValue(Nodes.ReturnValue node)
        {
            var instruction = new OpReturnValue();
            _instructionMap.Add(node, instruction);

            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpUnreachable VisitUnreachable(Nodes.Unreachable node)
        {
            var instruction = new OpUnreachable();
            _instructionMap.Add(node, instruction);

            return instruction;
        }
        protected virtual OpLifetimeStart VisitLifetimeStart(Nodes.LifetimeStart node)
        {
            var instruction = new OpLifetimeStart();
            _instructionMap.Add(node, instruction);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Size = Visit(node.Size);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpLifetimeStop VisitLifetimeStop(Nodes.LifetimeStop node)
        {
            var instruction = new OpLifetimeStop();
            _instructionMap.Add(node, instruction);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Size = Visit(node.Size);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGroupAsyncCopy VisitGroupAsyncCopy(Nodes.GroupAsyncCopy node)
        {
            var instruction = new OpGroupAsyncCopy();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Destination = Visit(node.Destination);
            instruction.Source = Visit(node.Source);
            instruction.NumElements = Visit(node.NumElements);
            instruction.Stride = Visit(node.Stride);
            instruction.Event = Visit(node.Event);
            return instruction;
        }
        protected virtual OpGroupWaitEvents VisitGroupWaitEvents(Nodes.GroupWaitEvents node)
        {
            var instruction = new OpGroupWaitEvents();
            _instructionMap.Add(node, instruction);

            instruction.Execution = Visit(node.Execution);
            instruction.NumEvents = Visit(node.NumEvents);
            instruction.EventsList = Visit(node.EventsList);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGroupAll VisitGroupAll(Nodes.GroupAll node)
        {
            var instruction = new OpGroupAll();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Predicate = Visit(node.Predicate);
            return instruction;
        }
        protected virtual OpGroupAny VisitGroupAny(Nodes.GroupAny node)
        {
            var instruction = new OpGroupAny();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Predicate = Visit(node.Predicate);
            return instruction;
        }
        protected virtual OpGroupBroadcast VisitGroupBroadcast(Nodes.GroupBroadcast node)
        {
            var instruction = new OpGroupBroadcast();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Value = Visit(node.Value);
            instruction.LocalId = Visit(node.LocalId);
            return instruction;
        }
        protected virtual OpGroupIAdd VisitGroupIAdd(Nodes.GroupIAdd node)
        {
            var instruction = new OpGroupIAdd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupFAdd VisitGroupFAdd(Nodes.GroupFAdd node)
        {
            var instruction = new OpGroupFAdd();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupFMin VisitGroupFMin(Nodes.GroupFMin node)
        {
            var instruction = new OpGroupFMin();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupUMin VisitGroupUMin(Nodes.GroupUMin node)
        {
            var instruction = new OpGroupUMin();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupSMin VisitGroupSMin(Nodes.GroupSMin node)
        {
            var instruction = new OpGroupSMin();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupFMax VisitGroupFMax(Nodes.GroupFMax node)
        {
            var instruction = new OpGroupFMax();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupUMax VisitGroupUMax(Nodes.GroupUMax node)
        {
            var instruction = new OpGroupUMax();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupSMax VisitGroupSMax(Nodes.GroupSMax node)
        {
            var instruction = new OpGroupSMax();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpReadPipe VisitReadPipe(Nodes.ReadPipe node)
        {
            var instruction = new OpReadPipe();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pipe = Visit(node.Pipe);
            instruction.Pointer = Visit(node.Pointer);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            return instruction;
        }
        protected virtual OpWritePipe VisitWritePipe(Nodes.WritePipe node)
        {
            var instruction = new OpWritePipe();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pipe = Visit(node.Pipe);
            instruction.Pointer = Visit(node.Pointer);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            return instruction;
        }
        protected virtual OpReservedReadPipe VisitReservedReadPipe(Nodes.ReservedReadPipe node)
        {
            var instruction = new OpReservedReadPipe();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pipe = Visit(node.Pipe);
            instruction.ReserveId = Visit(node.ReserveId);
            instruction.Index = Visit(node.Index);
            instruction.Pointer = Visit(node.Pointer);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            return instruction;
        }
        protected virtual OpReservedWritePipe VisitReservedWritePipe(Nodes.ReservedWritePipe node)
        {
            var instruction = new OpReservedWritePipe();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pipe = Visit(node.Pipe);
            instruction.ReserveId = Visit(node.ReserveId);
            instruction.Index = Visit(node.Index);
            instruction.Pointer = Visit(node.Pointer);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            return instruction;
        }
        protected virtual OpReserveReadPipePackets VisitReserveReadPipePackets(Nodes.ReserveReadPipePackets node)
        {
            var instruction = new OpReserveReadPipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pipe = Visit(node.Pipe);
            instruction.NumPackets = Visit(node.NumPackets);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            return instruction;
        }
        protected virtual OpReserveWritePipePackets VisitReserveWritePipePackets(Nodes.ReserveWritePipePackets node)
        {
            var instruction = new OpReserveWritePipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pipe = Visit(node.Pipe);
            instruction.NumPackets = Visit(node.NumPackets);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            return instruction;
        }
        protected virtual OpCommitReadPipe VisitCommitReadPipe(Nodes.CommitReadPipe node)
        {
            var instruction = new OpCommitReadPipe();
            _instructionMap.Add(node, instruction);

            instruction.Pipe = Visit(node.Pipe);
            instruction.ReserveId = Visit(node.ReserveId);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpCommitWritePipe VisitCommitWritePipe(Nodes.CommitWritePipe node)
        {
            var instruction = new OpCommitWritePipe();
            _instructionMap.Add(node, instruction);

            instruction.Pipe = Visit(node.Pipe);
            instruction.ReserveId = Visit(node.ReserveId);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpIsValidReserveId VisitIsValidReserveId(Nodes.IsValidReserveId node)
        {
            var instruction = new OpIsValidReserveId();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.ReserveId = Visit(node.ReserveId);
            return instruction;
        }
        protected virtual OpGetNumPipePackets VisitGetNumPipePackets(Nodes.GetNumPipePackets node)
        {
            var instruction = new OpGetNumPipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pipe = Visit(node.Pipe);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            return instruction;
        }
        protected virtual OpGetMaxPipePackets VisitGetMaxPipePackets(Nodes.GetMaxPipePackets node)
        {
            var instruction = new OpGetMaxPipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pipe = Visit(node.Pipe);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            return instruction;
        }
        protected virtual OpGroupReserveReadPipePackets VisitGroupReserveReadPipePackets(Nodes.GroupReserveReadPipePackets node)
        {
            var instruction = new OpGroupReserveReadPipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Pipe = Visit(node.Pipe);
            instruction.NumPackets = Visit(node.NumPackets);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            return instruction;
        }
        protected virtual OpGroupReserveWritePipePackets VisitGroupReserveWritePipePackets(Nodes.GroupReserveWritePipePackets node)
        {
            var instruction = new OpGroupReserveWritePipePackets();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Pipe = Visit(node.Pipe);
            instruction.NumPackets = Visit(node.NumPackets);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            return instruction;
        }
        protected virtual OpGroupCommitReadPipe VisitGroupCommitReadPipe(Nodes.GroupCommitReadPipe node)
        {
            var instruction = new OpGroupCommitReadPipe();
            _instructionMap.Add(node, instruction);

            instruction.Execution = Visit(node.Execution);
            instruction.Pipe = Visit(node.Pipe);
            instruction.ReserveId = Visit(node.ReserveId);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGroupCommitWritePipe VisitGroupCommitWritePipe(Nodes.GroupCommitWritePipe node)
        {
            var instruction = new OpGroupCommitWritePipe();
            _instructionMap.Add(node, instruction);

            instruction.Execution = Visit(node.Execution);
            instruction.Pipe = Visit(node.Pipe);
            instruction.ReserveId = Visit(node.ReserveId);
            instruction.PacketSize = Visit(node.PacketSize);
            instruction.PacketAlignment = Visit(node.PacketAlignment);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpEnqueueMarker VisitEnqueueMarker(Nodes.EnqueueMarker node)
        {
            var instruction = new OpEnqueueMarker();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Queue = Visit(node.Queue);
            instruction.NumEvents = Visit(node.NumEvents);
            instruction.WaitEvents = Visit(node.WaitEvents);
            instruction.RetEvent = Visit(node.RetEvent);
            return instruction;
        }
        protected virtual OpEnqueueKernel VisitEnqueueKernel(Nodes.EnqueueKernel node)
        {
            var instruction = new OpEnqueueKernel();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Queue = Visit(node.Queue);
            instruction.Flags = Visit(node.Flags);
            instruction.NDRange = Visit(node.NDRange);
            instruction.NumEvents = Visit(node.NumEvents);
            instruction.WaitEvents = Visit(node.WaitEvents);
            instruction.RetEvent = Visit(node.RetEvent);
            instruction.Invoke = Visit(node.Invoke);
            instruction.Param = Visit(node.Param);
            instruction.ParamSize = Visit(node.ParamSize);
            instruction.ParamAlign = Visit(node.ParamAlign);
            instruction.LocalSize = Visit(node.LocalSize);
            return instruction;
        }
        protected virtual OpGetKernelNDrangeSubGroupCount VisitGetKernelNDrangeSubGroupCount(Nodes.GetKernelNDrangeSubGroupCount node)
        {
            var instruction = new OpGetKernelNDrangeSubGroupCount();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.NDRange = Visit(node.NDRange);
            instruction.Invoke = Visit(node.Invoke);
            instruction.Param = Visit(node.Param);
            instruction.ParamSize = Visit(node.ParamSize);
            instruction.ParamAlign = Visit(node.ParamAlign);
            return instruction;
        }
        protected virtual OpGetKernelNDrangeMaxSubGroupSize VisitGetKernelNDrangeMaxSubGroupSize(Nodes.GetKernelNDrangeMaxSubGroupSize node)
        {
            var instruction = new OpGetKernelNDrangeMaxSubGroupSize();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.NDRange = Visit(node.NDRange);
            instruction.Invoke = Visit(node.Invoke);
            instruction.Param = Visit(node.Param);
            instruction.ParamSize = Visit(node.ParamSize);
            instruction.ParamAlign = Visit(node.ParamAlign);
            return instruction;
        }
        protected virtual OpGetKernelWorkGroupSize VisitGetKernelWorkGroupSize(Nodes.GetKernelWorkGroupSize node)
        {
            var instruction = new OpGetKernelWorkGroupSize();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Invoke = Visit(node.Invoke);
            instruction.Param = Visit(node.Param);
            instruction.ParamSize = Visit(node.ParamSize);
            instruction.ParamAlign = Visit(node.ParamAlign);
            return instruction;
        }
        protected virtual OpGetKernelPreferredWorkGroupSizeMultiple VisitGetKernelPreferredWorkGroupSizeMultiple(Nodes.GetKernelPreferredWorkGroupSizeMultiple node)
        {
            var instruction = new OpGetKernelPreferredWorkGroupSizeMultiple();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Invoke = Visit(node.Invoke);
            instruction.Param = Visit(node.Param);
            instruction.ParamSize = Visit(node.ParamSize);
            instruction.ParamAlign = Visit(node.ParamAlign);
            return instruction;
        }
        protected virtual OpRetainEvent VisitRetainEvent(Nodes.RetainEvent node)
        {
            var instruction = new OpRetainEvent();
            _instructionMap.Add(node, instruction);

            instruction.Event = Visit(node.Event);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpReleaseEvent VisitReleaseEvent(Nodes.ReleaseEvent node)
        {
            var instruction = new OpReleaseEvent();
            _instructionMap.Add(node, instruction);

            instruction.Event = Visit(node.Event);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpCreateUserEvent VisitCreateUserEvent(Nodes.CreateUserEvent node)
        {
            var instruction = new OpCreateUserEvent();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            return instruction;
        }
        protected virtual OpIsValidEvent VisitIsValidEvent(Nodes.IsValidEvent node)
        {
            var instruction = new OpIsValidEvent();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Event = Visit(node.Event);
            return instruction;
        }
        protected virtual OpSetUserEventStatus VisitSetUserEventStatus(Nodes.SetUserEventStatus node)
        {
            var instruction = new OpSetUserEventStatus();
            _instructionMap.Add(node, instruction);

            instruction.Event = Visit(node.Event);
            instruction.Status = Visit(node.Status);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpCaptureEventProfilingInfo VisitCaptureEventProfilingInfo(Nodes.CaptureEventProfilingInfo node)
        {
            var instruction = new OpCaptureEventProfilingInfo();
            _instructionMap.Add(node, instruction);

            instruction.Event = Visit(node.Event);
            instruction.ProfilingInfo = Visit(node.ProfilingInfo);
            instruction.Value = Visit(node.Value);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpGetDefaultQueue VisitGetDefaultQueue(Nodes.GetDefaultQueue node)
        {
            var instruction = new OpGetDefaultQueue();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            return instruction;
        }
        protected virtual OpBuildNDRange VisitBuildNDRange(Nodes.BuildNDRange node)
        {
            var instruction = new OpBuildNDRange();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.GlobalWorkSize = Visit(node.GlobalWorkSize);
            instruction.LocalWorkSize = Visit(node.LocalWorkSize);
            instruction.GlobalWorkOffset = Visit(node.GlobalWorkOffset);
            return instruction;
        }
        protected virtual OpImageSparseSampleImplicitLod VisitImageSparseSampleImplicitLod(Nodes.ImageSparseSampleImplicitLod node)
        {
            var instruction = new OpImageSparseSampleImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseSampleExplicitLod VisitImageSparseSampleExplicitLod(Nodes.ImageSparseSampleExplicitLod node)
        {
            var instruction = new OpImageSparseSampleExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseSampleDrefImplicitLod VisitImageSparseSampleDrefImplicitLod(Nodes.ImageSparseSampleDrefImplicitLod node)
        {
            var instruction = new OpImageSparseSampleDrefImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.D_ref = Visit(node.D_ref);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseSampleDrefExplicitLod VisitImageSparseSampleDrefExplicitLod(Nodes.ImageSparseSampleDrefExplicitLod node)
        {
            var instruction = new OpImageSparseSampleDrefExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.D_ref = Visit(node.D_ref);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseSampleProjImplicitLod VisitImageSparseSampleProjImplicitLod(Nodes.ImageSparseSampleProjImplicitLod node)
        {
            var instruction = new OpImageSparseSampleProjImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseSampleProjExplicitLod VisitImageSparseSampleProjExplicitLod(Nodes.ImageSparseSampleProjExplicitLod node)
        {
            var instruction = new OpImageSparseSampleProjExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseSampleProjDrefImplicitLod VisitImageSparseSampleProjDrefImplicitLod(Nodes.ImageSparseSampleProjDrefImplicitLod node)
        {
            var instruction = new OpImageSparseSampleProjDrefImplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.D_ref = Visit(node.D_ref);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseSampleProjDrefExplicitLod VisitImageSparseSampleProjDrefExplicitLod(Nodes.ImageSparseSampleProjDrefExplicitLod node)
        {
            var instruction = new OpImageSparseSampleProjDrefExplicitLod();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.D_ref = Visit(node.D_ref);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseFetch VisitImageSparseFetch(Nodes.ImageSparseFetch node)
        {
            var instruction = new OpImageSparseFetch();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseGather VisitImageSparseGather(Nodes.ImageSparseGather node)
        {
            var instruction = new OpImageSparseGather();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.Component = Visit(node.Component);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseDrefGather VisitImageSparseDrefGather(Nodes.ImageSparseDrefGather node)
        {
            var instruction = new OpImageSparseDrefGather();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.SampledImage = Visit(node.SampledImage);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.D_ref = Visit(node.D_ref);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpImageSparseTexelsResident VisitImageSparseTexelsResident(Nodes.ImageSparseTexelsResident node)
        {
            var instruction = new OpImageSparseTexelsResident();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.ResidentCode = Visit(node.ResidentCode);
            return instruction;
        }
        protected virtual OpNoLine VisitNoLine(Nodes.NoLine node)
        {
            var instruction = new OpNoLine();
            _instructionMap.Add(node, instruction);

            Visit(node.Next);

            return instruction;
        }
        protected virtual OpAtomicFlagTestAndSet VisitAtomicFlagTestAndSet(Nodes.AtomicFlagTestAndSet node)
        {
            var instruction = new OpAtomicFlagTestAndSet();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            return instruction;
        }
        protected virtual OpAtomicFlagClear VisitAtomicFlagClear(Nodes.AtomicFlagClear node)
        {
            var instruction = new OpAtomicFlagClear();
            _instructionMap.Add(node, instruction);

            instruction.Pointer = Visit(node.Pointer);
            instruction.Scope = Visit(node.Scope);
            instruction.Semantics = Visit(node.Semantics);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpImageSparseRead VisitImageSparseRead(Nodes.ImageSparseRead node)
        {
            var instruction = new OpImageSparseRead();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.ImageOperands = Visit(node.ImageOperands);
            return instruction;
        }
        protected virtual OpDecorateId VisitDecorateId(Nodes.DecorateId node)
        {
            var instruction = new OpDecorateId();
            _instructionMap.Add(node, instruction);

            instruction.Target = Visit(node.Target);
            instruction.Decoration = Visit(node.Decoration);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpSubgroupBallotKHR VisitSubgroupBallotKHR(Nodes.SubgroupBallotKHR node)
        {
            var instruction = new OpSubgroupBallotKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Predicate = Visit(node.Predicate);
            return instruction;
        }
        protected virtual OpSubgroupFirstInvocationKHR VisitSubgroupFirstInvocationKHR(Nodes.SubgroupFirstInvocationKHR node)
        {
            var instruction = new OpSubgroupFirstInvocationKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpSubgroupAllKHR VisitSubgroupAllKHR(Nodes.SubgroupAllKHR node)
        {
            var instruction = new OpSubgroupAllKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Predicate = Visit(node.Predicate);
            return instruction;
        }
        protected virtual OpSubgroupAnyKHR VisitSubgroupAnyKHR(Nodes.SubgroupAnyKHR node)
        {
            var instruction = new OpSubgroupAnyKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Predicate = Visit(node.Predicate);
            return instruction;
        }
        protected virtual OpSubgroupAllEqualKHR VisitSubgroupAllEqualKHR(Nodes.SubgroupAllEqualKHR node)
        {
            var instruction = new OpSubgroupAllEqualKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Predicate = Visit(node.Predicate);
            return instruction;
        }
        protected virtual OpSubgroupReadInvocationKHR VisitSubgroupReadInvocationKHR(Nodes.SubgroupReadInvocationKHR node)
        {
            var instruction = new OpSubgroupReadInvocationKHR();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Value = Visit(node.Value);
            instruction.Index = Visit(node.Index);
            return instruction;
        }
        protected virtual OpGroupIAddNonUniformAMD VisitGroupIAddNonUniformAMD(Nodes.GroupIAddNonUniformAMD node)
        {
            var instruction = new OpGroupIAddNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupFAddNonUniformAMD VisitGroupFAddNonUniformAMD(Nodes.GroupFAddNonUniformAMD node)
        {
            var instruction = new OpGroupFAddNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupFMinNonUniformAMD VisitGroupFMinNonUniformAMD(Nodes.GroupFMinNonUniformAMD node)
        {
            var instruction = new OpGroupFMinNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupUMinNonUniformAMD VisitGroupUMinNonUniformAMD(Nodes.GroupUMinNonUniformAMD node)
        {
            var instruction = new OpGroupUMinNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupSMinNonUniformAMD VisitGroupSMinNonUniformAMD(Nodes.GroupSMinNonUniformAMD node)
        {
            var instruction = new OpGroupSMinNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupFMaxNonUniformAMD VisitGroupFMaxNonUniformAMD(Nodes.GroupFMaxNonUniformAMD node)
        {
            var instruction = new OpGroupFMaxNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupUMaxNonUniformAMD VisitGroupUMaxNonUniformAMD(Nodes.GroupUMaxNonUniformAMD node)
        {
            var instruction = new OpGroupUMaxNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpGroupSMaxNonUniformAMD VisitGroupSMaxNonUniformAMD(Nodes.GroupSMaxNonUniformAMD node)
        {
            var instruction = new OpGroupSMaxNonUniformAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Execution = Visit(node.Execution);
            instruction.Operation = Visit(node.Operation);
            instruction.X = Visit(node.X);
            return instruction;
        }
        protected virtual OpFragmentMaskFetchAMD VisitFragmentMaskFetchAMD(Nodes.FragmentMaskFetchAMD node)
        {
            var instruction = new OpFragmentMaskFetchAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            instruction.Coordinate = Visit(node.Coordinate);
            return instruction;
        }
        protected virtual OpFragmentFetchAMD VisitFragmentFetchAMD(Nodes.FragmentFetchAMD node)
        {
            var instruction = new OpFragmentFetchAMD();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.FragmentIndex = Visit(node.FragmentIndex);
            return instruction;
        }
        protected virtual OpSubgroupShuffleINTEL VisitSubgroupShuffleINTEL(Nodes.SubgroupShuffleINTEL node)
        {
            var instruction = new OpSubgroupShuffleINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Data = Visit(node.Data);
            instruction.InvocationId = Visit(node.InvocationId);
            return instruction;
        }
        protected virtual OpSubgroupShuffleDownINTEL VisitSubgroupShuffleDownINTEL(Nodes.SubgroupShuffleDownINTEL node)
        {
            var instruction = new OpSubgroupShuffleDownINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Current = Visit(node.Current);
            instruction.Next = Visit(node.Next);
            instruction.Delta = Visit(node.Delta);
            return instruction;
        }
        protected virtual OpSubgroupShuffleUpINTEL VisitSubgroupShuffleUpINTEL(Nodes.SubgroupShuffleUpINTEL node)
        {
            var instruction = new OpSubgroupShuffleUpINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Previous = Visit(node.Previous);
            instruction.Current = Visit(node.Current);
            instruction.Delta = Visit(node.Delta);
            return instruction;
        }
        protected virtual OpSubgroupShuffleXorINTEL VisitSubgroupShuffleXorINTEL(Nodes.SubgroupShuffleXorINTEL node)
        {
            var instruction = new OpSubgroupShuffleXorINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Data = Visit(node.Data);
            instruction.Value = Visit(node.Value);
            return instruction;
        }
        protected virtual OpSubgroupBlockReadINTEL VisitSubgroupBlockReadINTEL(Nodes.SubgroupBlockReadINTEL node)
        {
            var instruction = new OpSubgroupBlockReadINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Ptr = Visit(node.Ptr);
            return instruction;
        }
        protected virtual OpSubgroupBlockWriteINTEL VisitSubgroupBlockWriteINTEL(Nodes.SubgroupBlockWriteINTEL node)
        {
            var instruction = new OpSubgroupBlockWriteINTEL();
            _instructionMap.Add(node, instruction);

            instruction.Ptr = Visit(node.Ptr);
            instruction.Data = Visit(node.Data);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpSubgroupImageBlockReadINTEL VisitSubgroupImageBlockReadINTEL(Nodes.SubgroupImageBlockReadINTEL node)
        {
            var instruction = new OpSubgroupImageBlockReadINTEL();
            _instructionMap.Add(node, instruction);

            instruction.IdResult = (uint)_results.Count;
            _results.Add(instruction);
            if (node.DebugName != null)
            {
                Visit(new Name() {Target = node, Value = node.DebugName});
            }
            VisitDecorations(node);
            instruction.IdResultType = Visit(node.ResultType);

            instruction.Image = Visit(node.Image);
            instruction.Coordinate = Visit(node.Coordinate);
            return instruction;
        }
        protected virtual OpSubgroupImageBlockWriteINTEL VisitSubgroupImageBlockWriteINTEL(Nodes.SubgroupImageBlockWriteINTEL node)
        {
            var instruction = new OpSubgroupImageBlockWriteINTEL();
            _instructionMap.Add(node, instruction);

            instruction.Image = Visit(node.Image);
            instruction.Coordinate = Visit(node.Coordinate);
            instruction.Data = Visit(node.Data);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpDecorateStringGOOGLE VisitDecorateStringGOOGLE(Nodes.DecorateStringGOOGLE node)
        {
            var instruction = new OpDecorateStringGOOGLE();
            _instructionMap.Add(node, instruction);

            instruction.Target = Visit(node.Target);
            instruction.Decoration = Visit(node.Decoration);
            Visit(node.Next);

            return instruction;
        }
        protected virtual OpMemberDecorateStringGOOGLE VisitMemberDecorateStringGOOGLE(Nodes.MemberDecorateStringGOOGLE node)
        {
            var instruction = new OpMemberDecorateStringGOOGLE();
            _instructionMap.Add(node, instruction);

            instruction.StructType = Visit(node.StructType);
            instruction.Member = Visit(node.Member);
            instruction.Decoration = Visit(node.Decoration);
            Visit(node.Next);

            return instruction;
        }
    }
}