using System;
using System.Collections.Generic;
using Toe.Scripting;
using Toe.SPIRV.Reflection;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Spv;
using Nodes=Toe.SPIRV.Reflection.Nodes;

namespace Toe.SPIRV
{
    internal class ShaderToScriptConverterBase
    {
        protected Script _script;
        protected Dictionary<Node, ScriptNode> _nodeMap = new Dictionary<Node, ScriptNode>();
        public ShaderToScriptConverterBase()
        {
            _script = new Script();
        }

        protected virtual ScriptNode VisitNode(Node node)
        {
            if (_nodeMap.TryGetValue(node, out var scriptNode))
            {
                return scriptNode;
            }

            switch (node.OpCode)
            {
                case Op.OpNop: return VisitNop((Nodes.Nop) node);
                case Op.OpUndef: return VisitUndef((Nodes.Undef) node);
                case Op.OpSourceContinued: return VisitSourceContinued((Nodes.SourceContinued) node);
                case Op.OpSource: return VisitSource((Nodes.Source) node);
                case Op.OpSourceExtension: return VisitSourceExtension((Nodes.SourceExtension) node);
                case Op.OpName: return VisitName((Nodes.Name) node);
                case Op.OpMemberName: return VisitMemberName((Nodes.MemberName) node);
                case Op.OpString: return VisitString((Nodes.String) node);
                case Op.OpLine: return VisitLine((Nodes.Line) node);
                case Op.OpExtension: return VisitExtension((Nodes.Extension) node);
                case Op.OpExtInstImport: return VisitExtInstImport((Nodes.ExtInstImport) node);
                case Op.OpExtInst: return VisitExtInst((Nodes.ExtInst) node);
                case Op.OpMemoryModel: return VisitMemoryModel((Nodes.MemoryModel) node);
                case Op.OpEntryPoint: return VisitEntryPoint((Nodes.EntryPoint) node);
                case Op.OpExecutionMode: return VisitExecutionMode((Nodes.ExecutionMode) node);
                case Op.OpCapability: return VisitCapability((Nodes.Capability) node);
                case Op.OpConstantTrue: return VisitConstantTrue((Nodes.ConstantTrue) node);
                case Op.OpConstantFalse: return VisitConstantFalse((Nodes.ConstantFalse) node);
                case Op.OpConstant: return VisitConstant((Nodes.Constant) node);
                case Op.OpConstantComposite: return VisitConstantComposite((Nodes.ConstantComposite) node);
                case Op.OpConstantSampler: return VisitConstantSampler((Nodes.ConstantSampler) node);
                case Op.OpConstantNull: return VisitConstantNull((Nodes.ConstantNull) node);
                case Op.OpSpecConstantTrue: return VisitSpecConstantTrue((Nodes.SpecConstantTrue) node);
                case Op.OpSpecConstantFalse: return VisitSpecConstantFalse((Nodes.SpecConstantFalse) node);
                case Op.OpSpecConstant: return VisitSpecConstant((Nodes.SpecConstant) node);
                case Op.OpSpecConstantComposite: return VisitSpecConstantComposite((Nodes.SpecConstantComposite) node);
                case Op.OpSpecConstantOp: return VisitSpecConstantOp((Nodes.SpecConstantOp) node);
                case Op.OpFunction: return VisitFunction((Nodes.Function) node);
                case Op.OpFunctionParameter: return VisitFunctionParameter((Nodes.FunctionParameter) node);
                case Op.OpFunctionEnd: return VisitFunctionEnd((Nodes.FunctionEnd) node);
                case Op.OpFunctionCall: return VisitFunctionCall((Nodes.FunctionCall) node);
                case Op.OpVariable: return VisitVariable((Nodes.Variable) node);
                case Op.OpImageTexelPointer: return VisitImageTexelPointer((Nodes.ImageTexelPointer) node);
                case Op.OpLoad: return VisitLoad((Nodes.Load) node);
                case Op.OpStore: return VisitStore((Nodes.Store) node);
                case Op.OpCopyMemory: return VisitCopyMemory((Nodes.CopyMemory) node);
                case Op.OpCopyMemorySized: return VisitCopyMemorySized((Nodes.CopyMemorySized) node);
                case Op.OpAccessChain: return VisitAccessChain((Nodes.AccessChain) node);
                case Op.OpInBoundsAccessChain: return VisitInBoundsAccessChain((Nodes.InBoundsAccessChain) node);
                case Op.OpPtrAccessChain: return VisitPtrAccessChain((Nodes.PtrAccessChain) node);
                case Op.OpArrayLength: return VisitArrayLength((Nodes.ArrayLength) node);
                case Op.OpGenericPtrMemSemantics: return VisitGenericPtrMemSemantics((Nodes.GenericPtrMemSemantics) node);
                case Op.OpInBoundsPtrAccessChain: return VisitInBoundsPtrAccessChain((Nodes.InBoundsPtrAccessChain) node);
                case Op.OpDecorate: return VisitDecorate((Nodes.Decorate) node);
                case Op.OpMemberDecorate: return VisitMemberDecorate((Nodes.MemberDecorate) node);
                case Op.OpDecorationGroup: return VisitDecorationGroup((Nodes.DecorationGroup) node);
                case Op.OpGroupDecorate: return VisitGroupDecorate((Nodes.GroupDecorate) node);
                case Op.OpGroupMemberDecorate: return VisitGroupMemberDecorate((Nodes.GroupMemberDecorate) node);
                case Op.OpVectorExtractDynamic: return VisitVectorExtractDynamic((Nodes.VectorExtractDynamic) node);
                case Op.OpVectorInsertDynamic: return VisitVectorInsertDynamic((Nodes.VectorInsertDynamic) node);
                case Op.OpVectorShuffle: return VisitVectorShuffle((Nodes.VectorShuffle) node);
                case Op.OpCompositeConstruct: return VisitCompositeConstruct((Nodes.CompositeConstruct) node);
                case Op.OpCompositeExtract: return VisitCompositeExtract((Nodes.CompositeExtract) node);
                case Op.OpCompositeInsert: return VisitCompositeInsert((Nodes.CompositeInsert) node);
                case Op.OpCopyObject: return VisitCopyObject((Nodes.CopyObject) node);
                case Op.OpTranspose: return VisitTranspose((Nodes.Transpose) node);
                case Op.OpSampledImage: return VisitSampledImage((Nodes.SampledImage) node);
                case Op.OpImageSampleImplicitLod: return VisitImageSampleImplicitLod((Nodes.ImageSampleImplicitLod) node);
                case Op.OpImageSampleExplicitLod: return VisitImageSampleExplicitLod((Nodes.ImageSampleExplicitLod) node);
                case Op.OpImageSampleDrefImplicitLod: return VisitImageSampleDrefImplicitLod((Nodes.ImageSampleDrefImplicitLod) node);
                case Op.OpImageSampleDrefExplicitLod: return VisitImageSampleDrefExplicitLod((Nodes.ImageSampleDrefExplicitLod) node);
                case Op.OpImageSampleProjImplicitLod: return VisitImageSampleProjImplicitLod((Nodes.ImageSampleProjImplicitLod) node);
                case Op.OpImageSampleProjExplicitLod: return VisitImageSampleProjExplicitLod((Nodes.ImageSampleProjExplicitLod) node);
                case Op.OpImageSampleProjDrefImplicitLod: return VisitImageSampleProjDrefImplicitLod((Nodes.ImageSampleProjDrefImplicitLod) node);
                case Op.OpImageSampleProjDrefExplicitLod: return VisitImageSampleProjDrefExplicitLod((Nodes.ImageSampleProjDrefExplicitLod) node);
                case Op.OpImageFetch: return VisitImageFetch((Nodes.ImageFetch) node);
                case Op.OpImageGather: return VisitImageGather((Nodes.ImageGather) node);
                case Op.OpImageDrefGather: return VisitImageDrefGather((Nodes.ImageDrefGather) node);
                case Op.OpImageRead: return VisitImageRead((Nodes.ImageRead) node);
                case Op.OpImageWrite: return VisitImageWrite((Nodes.ImageWrite) node);
                case Op.OpImage: return VisitImage((Nodes.Image) node);
                case Op.OpImageQueryFormat: return VisitImageQueryFormat((Nodes.ImageQueryFormat) node);
                case Op.OpImageQueryOrder: return VisitImageQueryOrder((Nodes.ImageQueryOrder) node);
                case Op.OpImageQuerySizeLod: return VisitImageQuerySizeLod((Nodes.ImageQuerySizeLod) node);
                case Op.OpImageQuerySize: return VisitImageQuerySize((Nodes.ImageQuerySize) node);
                case Op.OpImageQueryLod: return VisitImageQueryLod((Nodes.ImageQueryLod) node);
                case Op.OpImageQueryLevels: return VisitImageQueryLevels((Nodes.ImageQueryLevels) node);
                case Op.OpImageQuerySamples: return VisitImageQuerySamples((Nodes.ImageQuerySamples) node);
                case Op.OpConvertFToU: return VisitConvertFToU((Nodes.ConvertFToU) node);
                case Op.OpConvertFToS: return VisitConvertFToS((Nodes.ConvertFToS) node);
                case Op.OpConvertSToF: return VisitConvertSToF((Nodes.ConvertSToF) node);
                case Op.OpConvertUToF: return VisitConvertUToF((Nodes.ConvertUToF) node);
                case Op.OpUConvert: return VisitUConvert((Nodes.UConvert) node);
                case Op.OpSConvert: return VisitSConvert((Nodes.SConvert) node);
                case Op.OpFConvert: return VisitFConvert((Nodes.FConvert) node);
                case Op.OpQuantizeToF16: return VisitQuantizeToF16((Nodes.QuantizeToF16) node);
                case Op.OpConvertPtrToU: return VisitConvertPtrToU((Nodes.ConvertPtrToU) node);
                case Op.OpSatConvertSToU: return VisitSatConvertSToU((Nodes.SatConvertSToU) node);
                case Op.OpSatConvertUToS: return VisitSatConvertUToS((Nodes.SatConvertUToS) node);
                case Op.OpConvertUToPtr: return VisitConvertUToPtr((Nodes.ConvertUToPtr) node);
                case Op.OpPtrCastToGeneric: return VisitPtrCastToGeneric((Nodes.PtrCastToGeneric) node);
                case Op.OpGenericCastToPtr: return VisitGenericCastToPtr((Nodes.GenericCastToPtr) node);
                case Op.OpGenericCastToPtrExplicit: return VisitGenericCastToPtrExplicit((Nodes.GenericCastToPtrExplicit) node);
                case Op.OpBitcast: return VisitBitcast((Nodes.Bitcast) node);
                case Op.OpSNegate: return VisitSNegate((Nodes.SNegate) node);
                case Op.OpFNegate: return VisitFNegate((Nodes.FNegate) node);
                case Op.OpIAdd: return VisitIAdd((Nodes.IAdd) node);
                case Op.OpFAdd: return VisitFAdd((Nodes.FAdd) node);
                case Op.OpISub: return VisitISub((Nodes.ISub) node);
                case Op.OpFSub: return VisitFSub((Nodes.FSub) node);
                case Op.OpIMul: return VisitIMul((Nodes.IMul) node);
                case Op.OpFMul: return VisitFMul((Nodes.FMul) node);
                case Op.OpUDiv: return VisitUDiv((Nodes.UDiv) node);
                case Op.OpSDiv: return VisitSDiv((Nodes.SDiv) node);
                case Op.OpFDiv: return VisitFDiv((Nodes.FDiv) node);
                case Op.OpUMod: return VisitUMod((Nodes.UMod) node);
                case Op.OpSRem: return VisitSRem((Nodes.SRem) node);
                case Op.OpSMod: return VisitSMod((Nodes.SMod) node);
                case Op.OpFRem: return VisitFRem((Nodes.FRem) node);
                case Op.OpFMod: return VisitFMod((Nodes.FMod) node);
                case Op.OpVectorTimesScalar: return VisitVectorTimesScalar((Nodes.VectorTimesScalar) node);
                case Op.OpMatrixTimesScalar: return VisitMatrixTimesScalar((Nodes.MatrixTimesScalar) node);
                case Op.OpVectorTimesMatrix: return VisitVectorTimesMatrix((Nodes.VectorTimesMatrix) node);
                case Op.OpMatrixTimesVector: return VisitMatrixTimesVector((Nodes.MatrixTimesVector) node);
                case Op.OpMatrixTimesMatrix: return VisitMatrixTimesMatrix((Nodes.MatrixTimesMatrix) node);
                case Op.OpOuterProduct: return VisitOuterProduct((Nodes.OuterProduct) node);
                case Op.OpDot: return VisitDot((Nodes.Dot) node);
                case Op.OpIAddCarry: return VisitIAddCarry((Nodes.IAddCarry) node);
                case Op.OpISubBorrow: return VisitISubBorrow((Nodes.ISubBorrow) node);
                case Op.OpUMulExtended: return VisitUMulExtended((Nodes.UMulExtended) node);
                case Op.OpSMulExtended: return VisitSMulExtended((Nodes.SMulExtended) node);
                case Op.OpAny: return VisitAny((Nodes.Any) node);
                case Op.OpAll: return VisitAll((Nodes.All) node);
                case Op.OpIsNan: return VisitIsNan((Nodes.IsNan) node);
                case Op.OpIsInf: return VisitIsInf((Nodes.IsInf) node);
                case Op.OpIsFinite: return VisitIsFinite((Nodes.IsFinite) node);
                case Op.OpIsNormal: return VisitIsNormal((Nodes.IsNormal) node);
                case Op.OpSignBitSet: return VisitSignBitSet((Nodes.SignBitSet) node);
                case Op.OpLessOrGreater: return VisitLessOrGreater((Nodes.LessOrGreater) node);
                case Op.OpOrdered: return VisitOrdered((Nodes.Ordered) node);
                case Op.OpUnordered: return VisitUnordered((Nodes.Unordered) node);
                case Op.OpLogicalEqual: return VisitLogicalEqual((Nodes.LogicalEqual) node);
                case Op.OpLogicalNotEqual: return VisitLogicalNotEqual((Nodes.LogicalNotEqual) node);
                case Op.OpLogicalOr: return VisitLogicalOr((Nodes.LogicalOr) node);
                case Op.OpLogicalAnd: return VisitLogicalAnd((Nodes.LogicalAnd) node);
                case Op.OpLogicalNot: return VisitLogicalNot((Nodes.LogicalNot) node);
                case Op.OpSelect: return VisitSelect((Nodes.Select) node);
                case Op.OpIEqual: return VisitIEqual((Nodes.IEqual) node);
                case Op.OpINotEqual: return VisitINotEqual((Nodes.INotEqual) node);
                case Op.OpUGreaterThan: return VisitUGreaterThan((Nodes.UGreaterThan) node);
                case Op.OpSGreaterThan: return VisitSGreaterThan((Nodes.SGreaterThan) node);
                case Op.OpUGreaterThanEqual: return VisitUGreaterThanEqual((Nodes.UGreaterThanEqual) node);
                case Op.OpSGreaterThanEqual: return VisitSGreaterThanEqual((Nodes.SGreaterThanEqual) node);
                case Op.OpULessThan: return VisitULessThan((Nodes.ULessThan) node);
                case Op.OpSLessThan: return VisitSLessThan((Nodes.SLessThan) node);
                case Op.OpULessThanEqual: return VisitULessThanEqual((Nodes.ULessThanEqual) node);
                case Op.OpSLessThanEqual: return VisitSLessThanEqual((Nodes.SLessThanEqual) node);
                case Op.OpFOrdEqual: return VisitFOrdEqual((Nodes.FOrdEqual) node);
                case Op.OpFUnordEqual: return VisitFUnordEqual((Nodes.FUnordEqual) node);
                case Op.OpFOrdNotEqual: return VisitFOrdNotEqual((Nodes.FOrdNotEqual) node);
                case Op.OpFUnordNotEqual: return VisitFUnordNotEqual((Nodes.FUnordNotEqual) node);
                case Op.OpFOrdLessThan: return VisitFOrdLessThan((Nodes.FOrdLessThan) node);
                case Op.OpFUnordLessThan: return VisitFUnordLessThan((Nodes.FUnordLessThan) node);
                case Op.OpFOrdGreaterThan: return VisitFOrdGreaterThan((Nodes.FOrdGreaterThan) node);
                case Op.OpFUnordGreaterThan: return VisitFUnordGreaterThan((Nodes.FUnordGreaterThan) node);
                case Op.OpFOrdLessThanEqual: return VisitFOrdLessThanEqual((Nodes.FOrdLessThanEqual) node);
                case Op.OpFUnordLessThanEqual: return VisitFUnordLessThanEqual((Nodes.FUnordLessThanEqual) node);
                case Op.OpFOrdGreaterThanEqual: return VisitFOrdGreaterThanEqual((Nodes.FOrdGreaterThanEqual) node);
                case Op.OpFUnordGreaterThanEqual: return VisitFUnordGreaterThanEqual((Nodes.FUnordGreaterThanEqual) node);
                case Op.OpShiftRightLogical: return VisitShiftRightLogical((Nodes.ShiftRightLogical) node);
                case Op.OpShiftRightArithmetic: return VisitShiftRightArithmetic((Nodes.ShiftRightArithmetic) node);
                case Op.OpShiftLeftLogical: return VisitShiftLeftLogical((Nodes.ShiftLeftLogical) node);
                case Op.OpBitwiseOr: return VisitBitwiseOr((Nodes.BitwiseOr) node);
                case Op.OpBitwiseXor: return VisitBitwiseXor((Nodes.BitwiseXor) node);
                case Op.OpBitwiseAnd: return VisitBitwiseAnd((Nodes.BitwiseAnd) node);
                case Op.OpNot: return VisitNot((Nodes.Not) node);
                case Op.OpBitFieldInsert: return VisitBitFieldInsert((Nodes.BitFieldInsert) node);
                case Op.OpBitFieldSExtract: return VisitBitFieldSExtract((Nodes.BitFieldSExtract) node);
                case Op.OpBitFieldUExtract: return VisitBitFieldUExtract((Nodes.BitFieldUExtract) node);
                case Op.OpBitReverse: return VisitBitReverse((Nodes.BitReverse) node);
                case Op.OpBitCount: return VisitBitCount((Nodes.BitCount) node);
                case Op.OpDPdx: return VisitDPdx((Nodes.DPdx) node);
                case Op.OpDPdy: return VisitDPdy((Nodes.DPdy) node);
                case Op.OpFwidth: return VisitFwidth((Nodes.Fwidth) node);
                case Op.OpDPdxFine: return VisitDPdxFine((Nodes.DPdxFine) node);
                case Op.OpDPdyFine: return VisitDPdyFine((Nodes.DPdyFine) node);
                case Op.OpFwidthFine: return VisitFwidthFine((Nodes.FwidthFine) node);
                case Op.OpDPdxCoarse: return VisitDPdxCoarse((Nodes.DPdxCoarse) node);
                case Op.OpDPdyCoarse: return VisitDPdyCoarse((Nodes.DPdyCoarse) node);
                case Op.OpFwidthCoarse: return VisitFwidthCoarse((Nodes.FwidthCoarse) node);
                case Op.OpEmitVertex: return VisitEmitVertex((Nodes.EmitVertex) node);
                case Op.OpEndPrimitive: return VisitEndPrimitive((Nodes.EndPrimitive) node);
                case Op.OpEmitStreamVertex: return VisitEmitStreamVertex((Nodes.EmitStreamVertex) node);
                case Op.OpEndStreamPrimitive: return VisitEndStreamPrimitive((Nodes.EndStreamPrimitive) node);
                case Op.OpControlBarrier: return VisitControlBarrier((Nodes.ControlBarrier) node);
                case Op.OpMemoryBarrier: return VisitMemoryBarrier((Nodes.MemoryBarrier) node);
                case Op.OpAtomicLoad: return VisitAtomicLoad((Nodes.AtomicLoad) node);
                case Op.OpAtomicStore: return VisitAtomicStore((Nodes.AtomicStore) node);
                case Op.OpAtomicExchange: return VisitAtomicExchange((Nodes.AtomicExchange) node);
                case Op.OpAtomicCompareExchange: return VisitAtomicCompareExchange((Nodes.AtomicCompareExchange) node);
                case Op.OpAtomicCompareExchangeWeak: return VisitAtomicCompareExchangeWeak((Nodes.AtomicCompareExchangeWeak) node);
                case Op.OpAtomicIIncrement: return VisitAtomicIIncrement((Nodes.AtomicIIncrement) node);
                case Op.OpAtomicIDecrement: return VisitAtomicIDecrement((Nodes.AtomicIDecrement) node);
                case Op.OpAtomicIAdd: return VisitAtomicIAdd((Nodes.AtomicIAdd) node);
                case Op.OpAtomicISub: return VisitAtomicISub((Nodes.AtomicISub) node);
                case Op.OpAtomicSMin: return VisitAtomicSMin((Nodes.AtomicSMin) node);
                case Op.OpAtomicUMin: return VisitAtomicUMin((Nodes.AtomicUMin) node);
                case Op.OpAtomicSMax: return VisitAtomicSMax((Nodes.AtomicSMax) node);
                case Op.OpAtomicUMax: return VisitAtomicUMax((Nodes.AtomicUMax) node);
                case Op.OpAtomicAnd: return VisitAtomicAnd((Nodes.AtomicAnd) node);
                case Op.OpAtomicOr: return VisitAtomicOr((Nodes.AtomicOr) node);
                case Op.OpAtomicXor: return VisitAtomicXor((Nodes.AtomicXor) node);
                case Op.OpPhi: return VisitPhi((Nodes.Phi) node);
                case Op.OpLoopMerge: return VisitLoopMerge((Nodes.LoopMerge) node);
                case Op.OpSelectionMerge: return VisitSelectionMerge((Nodes.SelectionMerge) node);
                case Op.OpLabel: return VisitLabel((Nodes.Label) node);
                case Op.OpBranch: return VisitBranch((Nodes.Branch) node);
                case Op.OpBranchConditional: return VisitBranchConditional((Nodes.BranchConditional) node);
                case Op.OpSwitch: return VisitSwitch((Nodes.Switch) node);
                case Op.OpKill: return VisitKill((Nodes.Kill) node);
                case Op.OpReturn: return VisitReturn((Nodes.Return) node);
                case Op.OpReturnValue: return VisitReturnValue((Nodes.ReturnValue) node);
                case Op.OpUnreachable: return VisitUnreachable((Nodes.Unreachable) node);
                case Op.OpLifetimeStart: return VisitLifetimeStart((Nodes.LifetimeStart) node);
                case Op.OpLifetimeStop: return VisitLifetimeStop((Nodes.LifetimeStop) node);
                case Op.OpGroupAsyncCopy: return VisitGroupAsyncCopy((Nodes.GroupAsyncCopy) node);
                case Op.OpGroupWaitEvents: return VisitGroupWaitEvents((Nodes.GroupWaitEvents) node);
                case Op.OpGroupAll: return VisitGroupAll((Nodes.GroupAll) node);
                case Op.OpGroupAny: return VisitGroupAny((Nodes.GroupAny) node);
                case Op.OpGroupBroadcast: return VisitGroupBroadcast((Nodes.GroupBroadcast) node);
                case Op.OpGroupIAdd: return VisitGroupIAdd((Nodes.GroupIAdd) node);
                case Op.OpGroupFAdd: return VisitGroupFAdd((Nodes.GroupFAdd) node);
                case Op.OpGroupFMin: return VisitGroupFMin((Nodes.GroupFMin) node);
                case Op.OpGroupUMin: return VisitGroupUMin((Nodes.GroupUMin) node);
                case Op.OpGroupSMin: return VisitGroupSMin((Nodes.GroupSMin) node);
                case Op.OpGroupFMax: return VisitGroupFMax((Nodes.GroupFMax) node);
                case Op.OpGroupUMax: return VisitGroupUMax((Nodes.GroupUMax) node);
                case Op.OpGroupSMax: return VisitGroupSMax((Nodes.GroupSMax) node);
                case Op.OpReadPipe: return VisitReadPipe((Nodes.ReadPipe) node);
                case Op.OpWritePipe: return VisitWritePipe((Nodes.WritePipe) node);
                case Op.OpReservedReadPipe: return VisitReservedReadPipe((Nodes.ReservedReadPipe) node);
                case Op.OpReservedWritePipe: return VisitReservedWritePipe((Nodes.ReservedWritePipe) node);
                case Op.OpReserveReadPipePackets: return VisitReserveReadPipePackets((Nodes.ReserveReadPipePackets) node);
                case Op.OpReserveWritePipePackets: return VisitReserveWritePipePackets((Nodes.ReserveWritePipePackets) node);
                case Op.OpCommitReadPipe: return VisitCommitReadPipe((Nodes.CommitReadPipe) node);
                case Op.OpCommitWritePipe: return VisitCommitWritePipe((Nodes.CommitWritePipe) node);
                case Op.OpIsValidReserveId: return VisitIsValidReserveId((Nodes.IsValidReserveId) node);
                case Op.OpGetNumPipePackets: return VisitGetNumPipePackets((Nodes.GetNumPipePackets) node);
                case Op.OpGetMaxPipePackets: return VisitGetMaxPipePackets((Nodes.GetMaxPipePackets) node);
                case Op.OpGroupReserveReadPipePackets: return VisitGroupReserveReadPipePackets((Nodes.GroupReserveReadPipePackets) node);
                case Op.OpGroupReserveWritePipePackets: return VisitGroupReserveWritePipePackets((Nodes.GroupReserveWritePipePackets) node);
                case Op.OpGroupCommitReadPipe: return VisitGroupCommitReadPipe((Nodes.GroupCommitReadPipe) node);
                case Op.OpGroupCommitWritePipe: return VisitGroupCommitWritePipe((Nodes.GroupCommitWritePipe) node);
                case Op.OpEnqueueMarker: return VisitEnqueueMarker((Nodes.EnqueueMarker) node);
                case Op.OpEnqueueKernel: return VisitEnqueueKernel((Nodes.EnqueueKernel) node);
                case Op.OpGetKernelNDrangeSubGroupCount: return VisitGetKernelNDrangeSubGroupCount((Nodes.GetKernelNDrangeSubGroupCount) node);
                case Op.OpGetKernelNDrangeMaxSubGroupSize: return VisitGetKernelNDrangeMaxSubGroupSize((Nodes.GetKernelNDrangeMaxSubGroupSize) node);
                case Op.OpGetKernelWorkGroupSize: return VisitGetKernelWorkGroupSize((Nodes.GetKernelWorkGroupSize) node);
                case Op.OpGetKernelPreferredWorkGroupSizeMultiple: return VisitGetKernelPreferredWorkGroupSizeMultiple((Nodes.GetKernelPreferredWorkGroupSizeMultiple) node);
                case Op.OpRetainEvent: return VisitRetainEvent((Nodes.RetainEvent) node);
                case Op.OpReleaseEvent: return VisitReleaseEvent((Nodes.ReleaseEvent) node);
                case Op.OpCreateUserEvent: return VisitCreateUserEvent((Nodes.CreateUserEvent) node);
                case Op.OpIsValidEvent: return VisitIsValidEvent((Nodes.IsValidEvent) node);
                case Op.OpSetUserEventStatus: return VisitSetUserEventStatus((Nodes.SetUserEventStatus) node);
                case Op.OpCaptureEventProfilingInfo: return VisitCaptureEventProfilingInfo((Nodes.CaptureEventProfilingInfo) node);
                case Op.OpGetDefaultQueue: return VisitGetDefaultQueue((Nodes.GetDefaultQueue) node);
                case Op.OpBuildNDRange: return VisitBuildNDRange((Nodes.BuildNDRange) node);
                case Op.OpImageSparseSampleImplicitLod: return VisitImageSparseSampleImplicitLod((Nodes.ImageSparseSampleImplicitLod) node);
                case Op.OpImageSparseSampleExplicitLod: return VisitImageSparseSampleExplicitLod((Nodes.ImageSparseSampleExplicitLod) node);
                case Op.OpImageSparseSampleDrefImplicitLod: return VisitImageSparseSampleDrefImplicitLod((Nodes.ImageSparseSampleDrefImplicitLod) node);
                case Op.OpImageSparseSampleDrefExplicitLod: return VisitImageSparseSampleDrefExplicitLod((Nodes.ImageSparseSampleDrefExplicitLod) node);
                case Op.OpImageSparseSampleProjImplicitLod: return VisitImageSparseSampleProjImplicitLod((Nodes.ImageSparseSampleProjImplicitLod) node);
                case Op.OpImageSparseSampleProjExplicitLod: return VisitImageSparseSampleProjExplicitLod((Nodes.ImageSparseSampleProjExplicitLod) node);
                case Op.OpImageSparseSampleProjDrefImplicitLod: return VisitImageSparseSampleProjDrefImplicitLod((Nodes.ImageSparseSampleProjDrefImplicitLod) node);
                case Op.OpImageSparseSampleProjDrefExplicitLod: return VisitImageSparseSampleProjDrefExplicitLod((Nodes.ImageSparseSampleProjDrefExplicitLod) node);
                case Op.OpImageSparseFetch: return VisitImageSparseFetch((Nodes.ImageSparseFetch) node);
                case Op.OpImageSparseGather: return VisitImageSparseGather((Nodes.ImageSparseGather) node);
                case Op.OpImageSparseDrefGather: return VisitImageSparseDrefGather((Nodes.ImageSparseDrefGather) node);
                case Op.OpImageSparseTexelsResident: return VisitImageSparseTexelsResident((Nodes.ImageSparseTexelsResident) node);
                case Op.OpNoLine: return VisitNoLine((Nodes.NoLine) node);
                case Op.OpAtomicFlagTestAndSet: return VisitAtomicFlagTestAndSet((Nodes.AtomicFlagTestAndSet) node);
                case Op.OpAtomicFlagClear: return VisitAtomicFlagClear((Nodes.AtomicFlagClear) node);
                case Op.OpImageSparseRead: return VisitImageSparseRead((Nodes.ImageSparseRead) node);
                case Op.OpSizeOf: return VisitSizeOf((Nodes.SizeOf) node);
                case Op.OpConstantPipeStorage: return VisitConstantPipeStorage((Nodes.ConstantPipeStorage) node);
                case Op.OpCreatePipeFromPipeStorage: return VisitCreatePipeFromPipeStorage((Nodes.CreatePipeFromPipeStorage) node);
                case Op.OpGetKernelLocalSizeForSubgroupCount: return VisitGetKernelLocalSizeForSubgroupCount((Nodes.GetKernelLocalSizeForSubgroupCount) node);
                case Op.OpGetKernelMaxNumSubgroups: return VisitGetKernelMaxNumSubgroups((Nodes.GetKernelMaxNumSubgroups) node);
                case Op.OpNamedBarrierInitialize: return VisitNamedBarrierInitialize((Nodes.NamedBarrierInitialize) node);
                case Op.OpMemoryNamedBarrier: return VisitMemoryNamedBarrier((Nodes.MemoryNamedBarrier) node);
                case Op.OpModuleProcessed: return VisitModuleProcessed((Nodes.ModuleProcessed) node);
                case Op.OpExecutionModeId: return VisitExecutionModeId((Nodes.ExecutionModeId) node);
                case Op.OpDecorateId: return VisitDecorateId((Nodes.DecorateId) node);
                case Op.OpGroupNonUniformElect: return VisitGroupNonUniformElect((Nodes.GroupNonUniformElect) node);
                case Op.OpGroupNonUniformAll: return VisitGroupNonUniformAll((Nodes.GroupNonUniformAll) node);
                case Op.OpGroupNonUniformAny: return VisitGroupNonUniformAny((Nodes.GroupNonUniformAny) node);
                case Op.OpGroupNonUniformAllEqual: return VisitGroupNonUniformAllEqual((Nodes.GroupNonUniformAllEqual) node);
                case Op.OpGroupNonUniformBroadcast: return VisitGroupNonUniformBroadcast((Nodes.GroupNonUniformBroadcast) node);
                case Op.OpGroupNonUniformBroadcastFirst: return VisitGroupNonUniformBroadcastFirst((Nodes.GroupNonUniformBroadcastFirst) node);
                case Op.OpGroupNonUniformBallot: return VisitGroupNonUniformBallot((Nodes.GroupNonUniformBallot) node);
                case Op.OpGroupNonUniformInverseBallot: return VisitGroupNonUniformInverseBallot((Nodes.GroupNonUniformInverseBallot) node);
                case Op.OpGroupNonUniformBallotBitExtract: return VisitGroupNonUniformBallotBitExtract((Nodes.GroupNonUniformBallotBitExtract) node);
                case Op.OpGroupNonUniformBallotBitCount: return VisitGroupNonUniformBallotBitCount((Nodes.GroupNonUniformBallotBitCount) node);
                case Op.OpGroupNonUniformBallotFindLSB: return VisitGroupNonUniformBallotFindLSB((Nodes.GroupNonUniformBallotFindLSB) node);
                case Op.OpGroupNonUniformBallotFindMSB: return VisitGroupNonUniformBallotFindMSB((Nodes.GroupNonUniformBallotFindMSB) node);
                case Op.OpGroupNonUniformShuffle: return VisitGroupNonUniformShuffle((Nodes.GroupNonUniformShuffle) node);
                case Op.OpGroupNonUniformShuffleXor: return VisitGroupNonUniformShuffleXor((Nodes.GroupNonUniformShuffleXor) node);
                case Op.OpGroupNonUniformShuffleUp: return VisitGroupNonUniformShuffleUp((Nodes.GroupNonUniformShuffleUp) node);
                case Op.OpGroupNonUniformShuffleDown: return VisitGroupNonUniformShuffleDown((Nodes.GroupNonUniformShuffleDown) node);
                case Op.OpGroupNonUniformIAdd: return VisitGroupNonUniformIAdd((Nodes.GroupNonUniformIAdd) node);
                case Op.OpGroupNonUniformFAdd: return VisitGroupNonUniformFAdd((Nodes.GroupNonUniformFAdd) node);
                case Op.OpGroupNonUniformIMul: return VisitGroupNonUniformIMul((Nodes.GroupNonUniformIMul) node);
                case Op.OpGroupNonUniformFMul: return VisitGroupNonUniformFMul((Nodes.GroupNonUniformFMul) node);
                case Op.OpGroupNonUniformSMin: return VisitGroupNonUniformSMin((Nodes.GroupNonUniformSMin) node);
                case Op.OpGroupNonUniformUMin: return VisitGroupNonUniformUMin((Nodes.GroupNonUniformUMin) node);
                case Op.OpGroupNonUniformFMin: return VisitGroupNonUniformFMin((Nodes.GroupNonUniformFMin) node);
                case Op.OpGroupNonUniformSMax: return VisitGroupNonUniformSMax((Nodes.GroupNonUniformSMax) node);
                case Op.OpGroupNonUniformUMax: return VisitGroupNonUniformUMax((Nodes.GroupNonUniformUMax) node);
                case Op.OpGroupNonUniformFMax: return VisitGroupNonUniformFMax((Nodes.GroupNonUniformFMax) node);
                case Op.OpGroupNonUniformBitwiseAnd: return VisitGroupNonUniformBitwiseAnd((Nodes.GroupNonUniformBitwiseAnd) node);
                case Op.OpGroupNonUniformBitwiseOr: return VisitGroupNonUniformBitwiseOr((Nodes.GroupNonUniformBitwiseOr) node);
                case Op.OpGroupNonUniformBitwiseXor: return VisitGroupNonUniformBitwiseXor((Nodes.GroupNonUniformBitwiseXor) node);
                case Op.OpGroupNonUniformLogicalAnd: return VisitGroupNonUniformLogicalAnd((Nodes.GroupNonUniformLogicalAnd) node);
                case Op.OpGroupNonUniformLogicalOr: return VisitGroupNonUniformLogicalOr((Nodes.GroupNonUniformLogicalOr) node);
                case Op.OpGroupNonUniformLogicalXor: return VisitGroupNonUniformLogicalXor((Nodes.GroupNonUniformLogicalXor) node);
                case Op.OpGroupNonUniformQuadBroadcast: return VisitGroupNonUniformQuadBroadcast((Nodes.GroupNonUniformQuadBroadcast) node);
                case Op.OpGroupNonUniformQuadSwap: return VisitGroupNonUniformQuadSwap((Nodes.GroupNonUniformQuadSwap) node);
                case Op.OpCopyLogical: return VisitCopyLogical((Nodes.CopyLogical) node);
                case Op.OpPtrEqual: return VisitPtrEqual((Nodes.PtrEqual) node);
                case Op.OpPtrNotEqual: return VisitPtrNotEqual((Nodes.PtrNotEqual) node);
                case Op.OpPtrDiff: return VisitPtrDiff((Nodes.PtrDiff) node);
                case Op.OpSubgroupBallotKHR: return VisitSubgroupBallotKHR((Nodes.SubgroupBallotKHR) node);
                case Op.OpSubgroupFirstInvocationKHR: return VisitSubgroupFirstInvocationKHR((Nodes.SubgroupFirstInvocationKHR) node);
                case Op.OpSubgroupAllKHR: return VisitSubgroupAllKHR((Nodes.SubgroupAllKHR) node);
                case Op.OpSubgroupAnyKHR: return VisitSubgroupAnyKHR((Nodes.SubgroupAnyKHR) node);
                case Op.OpSubgroupAllEqualKHR: return VisitSubgroupAllEqualKHR((Nodes.SubgroupAllEqualKHR) node);
                case Op.OpSubgroupReadInvocationKHR: return VisitSubgroupReadInvocationKHR((Nodes.SubgroupReadInvocationKHR) node);
                case Op.OpGroupIAddNonUniformAMD: return VisitGroupIAddNonUniformAMD((Nodes.GroupIAddNonUniformAMD) node);
                case Op.OpGroupFAddNonUniformAMD: return VisitGroupFAddNonUniformAMD((Nodes.GroupFAddNonUniformAMD) node);
                case Op.OpGroupFMinNonUniformAMD: return VisitGroupFMinNonUniformAMD((Nodes.GroupFMinNonUniformAMD) node);
                case Op.OpGroupUMinNonUniformAMD: return VisitGroupUMinNonUniformAMD((Nodes.GroupUMinNonUniformAMD) node);
                case Op.OpGroupSMinNonUniformAMD: return VisitGroupSMinNonUniformAMD((Nodes.GroupSMinNonUniformAMD) node);
                case Op.OpGroupFMaxNonUniformAMD: return VisitGroupFMaxNonUniformAMD((Nodes.GroupFMaxNonUniformAMD) node);
                case Op.OpGroupUMaxNonUniformAMD: return VisitGroupUMaxNonUniformAMD((Nodes.GroupUMaxNonUniformAMD) node);
                case Op.OpGroupSMaxNonUniformAMD: return VisitGroupSMaxNonUniformAMD((Nodes.GroupSMaxNonUniformAMD) node);
                case Op.OpFragmentMaskFetchAMD: return VisitFragmentMaskFetchAMD((Nodes.FragmentMaskFetchAMD) node);
                case Op.OpFragmentFetchAMD: return VisitFragmentFetchAMD((Nodes.FragmentFetchAMD) node);
                case Op.OpReadClockKHR: return VisitReadClockKHR((Nodes.ReadClockKHR) node);
                case Op.OpImageSampleFootprintNV: return VisitImageSampleFootprintNV((Nodes.ImageSampleFootprintNV) node);
                case Op.OpGroupNonUniformPartitionNV: return VisitGroupNonUniformPartitionNV((Nodes.GroupNonUniformPartitionNV) node);
                case Op.OpWritePackedPrimitiveIndices4x8NV: return VisitWritePackedPrimitiveIndices4x8NV((Nodes.WritePackedPrimitiveIndices4x8NV) node);
                case Op.OpReportIntersectionNV: return VisitReportIntersectionNV((Nodes.ReportIntersectionNV) node);
                case Op.OpIgnoreIntersectionNV: return VisitIgnoreIntersectionNV((Nodes.IgnoreIntersectionNV) node);
                case Op.OpTerminateRayNV: return VisitTerminateRayNV((Nodes.TerminateRayNV) node);
                case Op.OpTraceNV: return VisitTraceNV((Nodes.TraceNV) node);
                case Op.OpRayQueryInitializeKHR: return VisitRayQueryInitializeKHR((Nodes.RayQueryInitializeKHR) node);
                case Op.OpRayQueryTerminateKHR: return VisitRayQueryTerminateKHR((Nodes.RayQueryTerminateKHR) node);
                case Op.OpRayQueryGenerateIntersectionKHR: return VisitRayQueryGenerateIntersectionKHR((Nodes.RayQueryGenerateIntersectionKHR) node);
                case Op.OpRayQueryConfirmIntersectionKHR: return VisitRayQueryConfirmIntersectionKHR((Nodes.RayQueryConfirmIntersectionKHR) node);
                case Op.OpRayQueryProceedKHR: return VisitRayQueryProceedKHR((Nodes.RayQueryProceedKHR) node);
                case Op.OpRayQueryGetIntersectionTypeKHR: return VisitRayQueryGetIntersectionTypeKHR((Nodes.RayQueryGetIntersectionTypeKHR) node);
                case Op.OpRayQueryGetRayTMinKHR: return VisitRayQueryGetRayTMinKHR((Nodes.RayQueryGetRayTMinKHR) node);
                case Op.OpRayQueryGetRayFlagsKHR: return VisitRayQueryGetRayFlagsKHR((Nodes.RayQueryGetRayFlagsKHR) node);
                case Op.OpRayQueryGetIntersectionTKHR: return VisitRayQueryGetIntersectionTKHR((Nodes.RayQueryGetIntersectionTKHR) node);
                case Op.OpRayQueryGetIntersectionInstanceCustomIndexKHR: return VisitRayQueryGetIntersectionInstanceCustomIndexKHR((Nodes.RayQueryGetIntersectionInstanceCustomIndexKHR) node);
                case Op.OpRayQueryGetIntersectionInstanceIdKHR: return VisitRayQueryGetIntersectionInstanceIdKHR((Nodes.RayQueryGetIntersectionInstanceIdKHR) node);
                case Op.OpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR: return VisitRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR((Nodes.RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR) node);
                case Op.OpRayQueryGetIntersectionGeometryIndexKHR: return VisitRayQueryGetIntersectionGeometryIndexKHR((Nodes.RayQueryGetIntersectionGeometryIndexKHR) node);
                case Op.OpRayQueryGetIntersectionPrimitiveIndexKHR: return VisitRayQueryGetIntersectionPrimitiveIndexKHR((Nodes.RayQueryGetIntersectionPrimitiveIndexKHR) node);
                case Op.OpRayQueryGetIntersectionBarycentricsKHR: return VisitRayQueryGetIntersectionBarycentricsKHR((Nodes.RayQueryGetIntersectionBarycentricsKHR) node);
                case Op.OpRayQueryGetIntersectionFrontFaceKHR: return VisitRayQueryGetIntersectionFrontFaceKHR((Nodes.RayQueryGetIntersectionFrontFaceKHR) node);
                case Op.OpRayQueryGetIntersectionCandidateAABBOpaqueKHR: return VisitRayQueryGetIntersectionCandidateAABBOpaqueKHR((Nodes.RayQueryGetIntersectionCandidateAABBOpaqueKHR) node);
                case Op.OpRayQueryGetIntersectionObjectRayDirectionKHR: return VisitRayQueryGetIntersectionObjectRayDirectionKHR((Nodes.RayQueryGetIntersectionObjectRayDirectionKHR) node);
                case Op.OpRayQueryGetIntersectionObjectRayOriginKHR: return VisitRayQueryGetIntersectionObjectRayOriginKHR((Nodes.RayQueryGetIntersectionObjectRayOriginKHR) node);
                case Op.OpRayQueryGetWorldRayDirectionKHR: return VisitRayQueryGetWorldRayDirectionKHR((Nodes.RayQueryGetWorldRayDirectionKHR) node);
                case Op.OpRayQueryGetWorldRayOriginKHR: return VisitRayQueryGetWorldRayOriginKHR((Nodes.RayQueryGetWorldRayOriginKHR) node);
                case Op.OpRayQueryGetIntersectionObjectToWorldKHR: return VisitRayQueryGetIntersectionObjectToWorldKHR((Nodes.RayQueryGetIntersectionObjectToWorldKHR) node);
                case Op.OpRayQueryGetIntersectionWorldToObjectKHR: return VisitRayQueryGetIntersectionWorldToObjectKHR((Nodes.RayQueryGetIntersectionWorldToObjectKHR) node);
                case Op.OpExecuteCallableNV: return VisitExecuteCallableNV((Nodes.ExecuteCallableNV) node);
                case Op.OpCooperativeMatrixLoadNV: return VisitCooperativeMatrixLoadNV((Nodes.CooperativeMatrixLoadNV) node);
                case Op.OpCooperativeMatrixStoreNV: return VisitCooperativeMatrixStoreNV((Nodes.CooperativeMatrixStoreNV) node);
                case Op.OpCooperativeMatrixMulAddNV: return VisitCooperativeMatrixMulAddNV((Nodes.CooperativeMatrixMulAddNV) node);
                case Op.OpCooperativeMatrixLengthNV: return VisitCooperativeMatrixLengthNV((Nodes.CooperativeMatrixLengthNV) node);
                case Op.OpBeginInvocationInterlockEXT: return VisitBeginInvocationInterlockEXT((Nodes.BeginInvocationInterlockEXT) node);
                case Op.OpEndInvocationInterlockEXT: return VisitEndInvocationInterlockEXT((Nodes.EndInvocationInterlockEXT) node);
                case Op.OpDemoteToHelperInvocationEXT: return VisitDemoteToHelperInvocationEXT((Nodes.DemoteToHelperInvocationEXT) node);
                case Op.OpIsHelperInvocationEXT: return VisitIsHelperInvocationEXT((Nodes.IsHelperInvocationEXT) node);
                case Op.OpSubgroupShuffleINTEL: return VisitSubgroupShuffleINTEL((Nodes.SubgroupShuffleINTEL) node);
                case Op.OpSubgroupShuffleDownINTEL: return VisitSubgroupShuffleDownINTEL((Nodes.SubgroupShuffleDownINTEL) node);
                case Op.OpSubgroupShuffleUpINTEL: return VisitSubgroupShuffleUpINTEL((Nodes.SubgroupShuffleUpINTEL) node);
                case Op.OpSubgroupShuffleXorINTEL: return VisitSubgroupShuffleXorINTEL((Nodes.SubgroupShuffleXorINTEL) node);
                case Op.OpSubgroupBlockReadINTEL: return VisitSubgroupBlockReadINTEL((Nodes.SubgroupBlockReadINTEL) node);
                case Op.OpSubgroupBlockWriteINTEL: return VisitSubgroupBlockWriteINTEL((Nodes.SubgroupBlockWriteINTEL) node);
                case Op.OpSubgroupImageBlockReadINTEL: return VisitSubgroupImageBlockReadINTEL((Nodes.SubgroupImageBlockReadINTEL) node);
                case Op.OpSubgroupImageBlockWriteINTEL: return VisitSubgroupImageBlockWriteINTEL((Nodes.SubgroupImageBlockWriteINTEL) node);
                case Op.OpSubgroupImageMediaBlockReadINTEL: return VisitSubgroupImageMediaBlockReadINTEL((Nodes.SubgroupImageMediaBlockReadINTEL) node);
                case Op.OpSubgroupImageMediaBlockWriteINTEL: return VisitSubgroupImageMediaBlockWriteINTEL((Nodes.SubgroupImageMediaBlockWriteINTEL) node);
                case Op.OpUCountLeadingZerosINTEL: return VisitUCountLeadingZerosINTEL((Nodes.UCountLeadingZerosINTEL) node);
                case Op.OpUCountTrailingZerosINTEL: return VisitUCountTrailingZerosINTEL((Nodes.UCountTrailingZerosINTEL) node);
                case Op.OpAbsISubINTEL: return VisitAbsISubINTEL((Nodes.AbsISubINTEL) node);
                case Op.OpAbsUSubINTEL: return VisitAbsUSubINTEL((Nodes.AbsUSubINTEL) node);
                case Op.OpIAddSatINTEL: return VisitIAddSatINTEL((Nodes.IAddSatINTEL) node);
                case Op.OpUAddSatINTEL: return VisitUAddSatINTEL((Nodes.UAddSatINTEL) node);
                case Op.OpIAverageINTEL: return VisitIAverageINTEL((Nodes.IAverageINTEL) node);
                case Op.OpUAverageINTEL: return VisitUAverageINTEL((Nodes.UAverageINTEL) node);
                case Op.OpIAverageRoundedINTEL: return VisitIAverageRoundedINTEL((Nodes.IAverageRoundedINTEL) node);
                case Op.OpUAverageRoundedINTEL: return VisitUAverageRoundedINTEL((Nodes.UAverageRoundedINTEL) node);
                case Op.OpISubSatINTEL: return VisitISubSatINTEL((Nodes.ISubSatINTEL) node);
                case Op.OpUSubSatINTEL: return VisitUSubSatINTEL((Nodes.USubSatINTEL) node);
                case Op.OpIMul32x16INTEL: return VisitIMul32x16INTEL((Nodes.IMul32x16INTEL) node);
                case Op.OpUMul32x16INTEL: return VisitUMul32x16INTEL((Nodes.UMul32x16INTEL) node);
                case Op.OpDecorateString: return VisitDecorateString((Nodes.DecorateString) node);
                case Op.OpMemberDecorateString: return VisitMemberDecorateString((Nodes.MemberDecorateString) node);
                case Op.OpVmeImageINTEL: return VisitVmeImageINTEL((Nodes.VmeImageINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL: return VisitSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL((Nodes.SubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL) node);
                case Op.OpSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL: return VisitSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL((Nodes.SubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultInterShapePenaltyINTEL: return VisitSubgroupAvcMceGetDefaultInterShapePenaltyINTEL((Nodes.SubgroupAvcMceGetDefaultInterShapePenaltyINTEL) node);
                case Op.OpSubgroupAvcMceSetInterShapePenaltyINTEL: return VisitSubgroupAvcMceSetInterShapePenaltyINTEL((Nodes.SubgroupAvcMceSetInterShapePenaltyINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL: return VisitSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL((Nodes.SubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL) node);
                case Op.OpSubgroupAvcMceSetInterDirectionPenaltyINTEL: return VisitSubgroupAvcMceSetInterDirectionPenaltyINTEL((Nodes.SubgroupAvcMceSetInterDirectionPenaltyINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL: return VisitSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL((Nodes.SubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL: return VisitSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL((Nodes.SubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL: return VisitSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL((Nodes.SubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL: return VisitSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL((Nodes.SubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL: return VisitSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL((Nodes.SubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL) node);
                case Op.OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL: return VisitSubgroupAvcMceSetMotionVectorCostFunctionINTEL((Nodes.SubgroupAvcMceSetMotionVectorCostFunctionINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL: return VisitSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL((Nodes.SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL: return VisitSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL((Nodes.SubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL) node);
                case Op.OpSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL: return VisitSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL((Nodes.SubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL) node);
                case Op.OpSubgroupAvcMceSetAcOnlyHaarINTEL: return VisitSubgroupAvcMceSetAcOnlyHaarINTEL((Nodes.SubgroupAvcMceSetAcOnlyHaarINTEL) node);
                case Op.OpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL: return VisitSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL((Nodes.SubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL) node);
                case Op.OpSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL: return VisitSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL((Nodes.SubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL) node);
                case Op.OpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL: return VisitSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL((Nodes.SubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL) node);
                case Op.OpSubgroupAvcMceConvertToImePayloadINTEL: return VisitSubgroupAvcMceConvertToImePayloadINTEL((Nodes.SubgroupAvcMceConvertToImePayloadINTEL) node);
                case Op.OpSubgroupAvcMceConvertToImeResultINTEL: return VisitSubgroupAvcMceConvertToImeResultINTEL((Nodes.SubgroupAvcMceConvertToImeResultINTEL) node);
                case Op.OpSubgroupAvcMceConvertToRefPayloadINTEL: return VisitSubgroupAvcMceConvertToRefPayloadINTEL((Nodes.SubgroupAvcMceConvertToRefPayloadINTEL) node);
                case Op.OpSubgroupAvcMceConvertToRefResultINTEL: return VisitSubgroupAvcMceConvertToRefResultINTEL((Nodes.SubgroupAvcMceConvertToRefResultINTEL) node);
                case Op.OpSubgroupAvcMceConvertToSicPayloadINTEL: return VisitSubgroupAvcMceConvertToSicPayloadINTEL((Nodes.SubgroupAvcMceConvertToSicPayloadINTEL) node);
                case Op.OpSubgroupAvcMceConvertToSicResultINTEL: return VisitSubgroupAvcMceConvertToSicResultINTEL((Nodes.SubgroupAvcMceConvertToSicResultINTEL) node);
                case Op.OpSubgroupAvcMceGetMotionVectorsINTEL: return VisitSubgroupAvcMceGetMotionVectorsINTEL((Nodes.SubgroupAvcMceGetMotionVectorsINTEL) node);
                case Op.OpSubgroupAvcMceGetInterDistortionsINTEL: return VisitSubgroupAvcMceGetInterDistortionsINTEL((Nodes.SubgroupAvcMceGetInterDistortionsINTEL) node);
                case Op.OpSubgroupAvcMceGetBestInterDistortionsINTEL: return VisitSubgroupAvcMceGetBestInterDistortionsINTEL((Nodes.SubgroupAvcMceGetBestInterDistortionsINTEL) node);
                case Op.OpSubgroupAvcMceGetInterMajorShapeINTEL: return VisitSubgroupAvcMceGetInterMajorShapeINTEL((Nodes.SubgroupAvcMceGetInterMajorShapeINTEL) node);
                case Op.OpSubgroupAvcMceGetInterMinorShapeINTEL: return VisitSubgroupAvcMceGetInterMinorShapeINTEL((Nodes.SubgroupAvcMceGetInterMinorShapeINTEL) node);
                case Op.OpSubgroupAvcMceGetInterDirectionsINTEL: return VisitSubgroupAvcMceGetInterDirectionsINTEL((Nodes.SubgroupAvcMceGetInterDirectionsINTEL) node);
                case Op.OpSubgroupAvcMceGetInterMotionVectorCountINTEL: return VisitSubgroupAvcMceGetInterMotionVectorCountINTEL((Nodes.SubgroupAvcMceGetInterMotionVectorCountINTEL) node);
                case Op.OpSubgroupAvcMceGetInterReferenceIdsINTEL: return VisitSubgroupAvcMceGetInterReferenceIdsINTEL((Nodes.SubgroupAvcMceGetInterReferenceIdsINTEL) node);
                case Op.OpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL: return VisitSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL((Nodes.SubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL) node);
                case Op.OpSubgroupAvcImeInitializeINTEL: return VisitSubgroupAvcImeInitializeINTEL((Nodes.SubgroupAvcImeInitializeINTEL) node);
                case Op.OpSubgroupAvcImeSetSingleReferenceINTEL: return VisitSubgroupAvcImeSetSingleReferenceINTEL((Nodes.SubgroupAvcImeSetSingleReferenceINTEL) node);
                case Op.OpSubgroupAvcImeSetDualReferenceINTEL: return VisitSubgroupAvcImeSetDualReferenceINTEL((Nodes.SubgroupAvcImeSetDualReferenceINTEL) node);
                case Op.OpSubgroupAvcImeRefWindowSizeINTEL: return VisitSubgroupAvcImeRefWindowSizeINTEL((Nodes.SubgroupAvcImeRefWindowSizeINTEL) node);
                case Op.OpSubgroupAvcImeAdjustRefOffsetINTEL: return VisitSubgroupAvcImeAdjustRefOffsetINTEL((Nodes.SubgroupAvcImeAdjustRefOffsetINTEL) node);
                case Op.OpSubgroupAvcImeConvertToMcePayloadINTEL: return VisitSubgroupAvcImeConvertToMcePayloadINTEL((Nodes.SubgroupAvcImeConvertToMcePayloadINTEL) node);
                case Op.OpSubgroupAvcImeSetMaxMotionVectorCountINTEL: return VisitSubgroupAvcImeSetMaxMotionVectorCountINTEL((Nodes.SubgroupAvcImeSetMaxMotionVectorCountINTEL) node);
                case Op.OpSubgroupAvcImeSetUnidirectionalMixDisableINTEL: return VisitSubgroupAvcImeSetUnidirectionalMixDisableINTEL((Nodes.SubgroupAvcImeSetUnidirectionalMixDisableINTEL) node);
                case Op.OpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL: return VisitSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL((Nodes.SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL) node);
                case Op.OpSubgroupAvcImeSetWeightedSadINTEL: return VisitSubgroupAvcImeSetWeightedSadINTEL((Nodes.SubgroupAvcImeSetWeightedSadINTEL) node);
                case Op.OpSubgroupAvcImeEvaluateWithSingleReferenceINTEL: return VisitSubgroupAvcImeEvaluateWithSingleReferenceINTEL((Nodes.SubgroupAvcImeEvaluateWithSingleReferenceINTEL) node);
                case Op.OpSubgroupAvcImeEvaluateWithDualReferenceINTEL: return VisitSubgroupAvcImeEvaluateWithDualReferenceINTEL((Nodes.SubgroupAvcImeEvaluateWithDualReferenceINTEL) node);
                case Op.OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL: return VisitSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL((Nodes.SubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL) node);
                case Op.OpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL: return VisitSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL((Nodes.SubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL) node);
                case Op.OpSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL: return VisitSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL((Nodes.SubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL) node);
                case Op.OpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL: return VisitSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL((Nodes.SubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL) node);
                case Op.OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL: return VisitSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL((Nodes.SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL) node);
                case Op.OpSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL: return VisitSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL((Nodes.SubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL) node);
                case Op.OpSubgroupAvcImeConvertToMceResultINTEL: return VisitSubgroupAvcImeConvertToMceResultINTEL((Nodes.SubgroupAvcImeConvertToMceResultINTEL) node);
                case Op.OpSubgroupAvcImeGetSingleReferenceStreaminINTEL: return VisitSubgroupAvcImeGetSingleReferenceStreaminINTEL((Nodes.SubgroupAvcImeGetSingleReferenceStreaminINTEL) node);
                case Op.OpSubgroupAvcImeGetDualReferenceStreaminINTEL: return VisitSubgroupAvcImeGetDualReferenceStreaminINTEL((Nodes.SubgroupAvcImeGetDualReferenceStreaminINTEL) node);
                case Op.OpSubgroupAvcImeStripSingleReferenceStreamoutINTEL: return VisitSubgroupAvcImeStripSingleReferenceStreamoutINTEL((Nodes.SubgroupAvcImeStripSingleReferenceStreamoutINTEL) node);
                case Op.OpSubgroupAvcImeStripDualReferenceStreamoutINTEL: return VisitSubgroupAvcImeStripDualReferenceStreamoutINTEL((Nodes.SubgroupAvcImeStripDualReferenceStreamoutINTEL) node);
                case Op.OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL: return VisitSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL((Nodes.SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL) node);
                case Op.OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL: return VisitSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL((Nodes.SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL) node);
                case Op.OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL: return VisitSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL((Nodes.SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL) node);
                case Op.OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL: return VisitSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL((Nodes.SubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL) node);
                case Op.OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL: return VisitSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL((Nodes.SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL) node);
                case Op.OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL: return VisitSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL((Nodes.SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL) node);
                case Op.OpSubgroupAvcImeGetBorderReachedINTEL: return VisitSubgroupAvcImeGetBorderReachedINTEL((Nodes.SubgroupAvcImeGetBorderReachedINTEL) node);
                case Op.OpSubgroupAvcImeGetTruncatedSearchIndicationINTEL: return VisitSubgroupAvcImeGetTruncatedSearchIndicationINTEL((Nodes.SubgroupAvcImeGetTruncatedSearchIndicationINTEL) node);
                case Op.OpSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL: return VisitSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL((Nodes.SubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL) node);
                case Op.OpSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL: return VisitSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL((Nodes.SubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL) node);
                case Op.OpSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL: return VisitSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL((Nodes.SubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL) node);
                case Op.OpSubgroupAvcFmeInitializeINTEL: return VisitSubgroupAvcFmeInitializeINTEL((Nodes.SubgroupAvcFmeInitializeINTEL) node);
                case Op.OpSubgroupAvcBmeInitializeINTEL: return VisitSubgroupAvcBmeInitializeINTEL((Nodes.SubgroupAvcBmeInitializeINTEL) node);
                case Op.OpSubgroupAvcRefConvertToMcePayloadINTEL: return VisitSubgroupAvcRefConvertToMcePayloadINTEL((Nodes.SubgroupAvcRefConvertToMcePayloadINTEL) node);
                case Op.OpSubgroupAvcRefSetBidirectionalMixDisableINTEL: return VisitSubgroupAvcRefSetBidirectionalMixDisableINTEL((Nodes.SubgroupAvcRefSetBidirectionalMixDisableINTEL) node);
                case Op.OpSubgroupAvcRefSetBilinearFilterEnableINTEL: return VisitSubgroupAvcRefSetBilinearFilterEnableINTEL((Nodes.SubgroupAvcRefSetBilinearFilterEnableINTEL) node);
                case Op.OpSubgroupAvcRefEvaluateWithSingleReferenceINTEL: return VisitSubgroupAvcRefEvaluateWithSingleReferenceINTEL((Nodes.SubgroupAvcRefEvaluateWithSingleReferenceINTEL) node);
                case Op.OpSubgroupAvcRefEvaluateWithDualReferenceINTEL: return VisitSubgroupAvcRefEvaluateWithDualReferenceINTEL((Nodes.SubgroupAvcRefEvaluateWithDualReferenceINTEL) node);
                case Op.OpSubgroupAvcRefEvaluateWithMultiReferenceINTEL: return VisitSubgroupAvcRefEvaluateWithMultiReferenceINTEL((Nodes.SubgroupAvcRefEvaluateWithMultiReferenceINTEL) node);
                case Op.OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL: return VisitSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL((Nodes.SubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL) node);
                case Op.OpSubgroupAvcRefConvertToMceResultINTEL: return VisitSubgroupAvcRefConvertToMceResultINTEL((Nodes.SubgroupAvcRefConvertToMceResultINTEL) node);
                case Op.OpSubgroupAvcSicInitializeINTEL: return VisitSubgroupAvcSicInitializeINTEL((Nodes.SubgroupAvcSicInitializeINTEL) node);
                case Op.OpSubgroupAvcSicConfigureSkcINTEL: return VisitSubgroupAvcSicConfigureSkcINTEL((Nodes.SubgroupAvcSicConfigureSkcINTEL) node);
                case Op.OpSubgroupAvcSicConfigureIpeLumaINTEL: return VisitSubgroupAvcSicConfigureIpeLumaINTEL((Nodes.SubgroupAvcSicConfigureIpeLumaINTEL) node);
                case Op.OpSubgroupAvcSicConfigureIpeLumaChromaINTEL: return VisitSubgroupAvcSicConfigureIpeLumaChromaINTEL((Nodes.SubgroupAvcSicConfigureIpeLumaChromaINTEL) node);
                case Op.OpSubgroupAvcSicGetMotionVectorMaskINTEL: return VisitSubgroupAvcSicGetMotionVectorMaskINTEL((Nodes.SubgroupAvcSicGetMotionVectorMaskINTEL) node);
                case Op.OpSubgroupAvcSicConvertToMcePayloadINTEL: return VisitSubgroupAvcSicConvertToMcePayloadINTEL((Nodes.SubgroupAvcSicConvertToMcePayloadINTEL) node);
                case Op.OpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL: return VisitSubgroupAvcSicSetIntraLumaShapePenaltyINTEL((Nodes.SubgroupAvcSicSetIntraLumaShapePenaltyINTEL) node);
                case Op.OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL: return VisitSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL((Nodes.SubgroupAvcSicSetIntraLumaModeCostFunctionINTEL) node);
                case Op.OpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL: return VisitSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL((Nodes.SubgroupAvcSicSetIntraChromaModeCostFunctionINTEL) node);
                case Op.OpSubgroupAvcSicSetBilinearFilterEnableINTEL: return VisitSubgroupAvcSicSetBilinearFilterEnableINTEL((Nodes.SubgroupAvcSicSetBilinearFilterEnableINTEL) node);
                case Op.OpSubgroupAvcSicSetSkcForwardTransformEnableINTEL: return VisitSubgroupAvcSicSetSkcForwardTransformEnableINTEL((Nodes.SubgroupAvcSicSetSkcForwardTransformEnableINTEL) node);
                case Op.OpSubgroupAvcSicSetBlockBasedRawSkipSadINTEL: return VisitSubgroupAvcSicSetBlockBasedRawSkipSadINTEL((Nodes.SubgroupAvcSicSetBlockBasedRawSkipSadINTEL) node);
                case Op.OpSubgroupAvcSicEvaluateIpeINTEL: return VisitSubgroupAvcSicEvaluateIpeINTEL((Nodes.SubgroupAvcSicEvaluateIpeINTEL) node);
                case Op.OpSubgroupAvcSicEvaluateWithSingleReferenceINTEL: return VisitSubgroupAvcSicEvaluateWithSingleReferenceINTEL((Nodes.SubgroupAvcSicEvaluateWithSingleReferenceINTEL) node);
                case Op.OpSubgroupAvcSicEvaluateWithDualReferenceINTEL: return VisitSubgroupAvcSicEvaluateWithDualReferenceINTEL((Nodes.SubgroupAvcSicEvaluateWithDualReferenceINTEL) node);
                case Op.OpSubgroupAvcSicEvaluateWithMultiReferenceINTEL: return VisitSubgroupAvcSicEvaluateWithMultiReferenceINTEL((Nodes.SubgroupAvcSicEvaluateWithMultiReferenceINTEL) node);
                case Op.OpSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL: return VisitSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL((Nodes.SubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL) node);
                case Op.OpSubgroupAvcSicConvertToMceResultINTEL: return VisitSubgroupAvcSicConvertToMceResultINTEL((Nodes.SubgroupAvcSicConvertToMceResultINTEL) node);
                case Op.OpSubgroupAvcSicGetIpeLumaShapeINTEL: return VisitSubgroupAvcSicGetIpeLumaShapeINTEL((Nodes.SubgroupAvcSicGetIpeLumaShapeINTEL) node);
                case Op.OpSubgroupAvcSicGetBestIpeLumaDistortionINTEL: return VisitSubgroupAvcSicGetBestIpeLumaDistortionINTEL((Nodes.SubgroupAvcSicGetBestIpeLumaDistortionINTEL) node);
                case Op.OpSubgroupAvcSicGetBestIpeChromaDistortionINTEL: return VisitSubgroupAvcSicGetBestIpeChromaDistortionINTEL((Nodes.SubgroupAvcSicGetBestIpeChromaDistortionINTEL) node);
                case Op.OpSubgroupAvcSicGetPackedIpeLumaModesINTEL: return VisitSubgroupAvcSicGetPackedIpeLumaModesINTEL((Nodes.SubgroupAvcSicGetPackedIpeLumaModesINTEL) node);
                case Op.OpSubgroupAvcSicGetIpeChromaModeINTEL: return VisitSubgroupAvcSicGetIpeChromaModeINTEL((Nodes.SubgroupAvcSicGetIpeChromaModeINTEL) node);
                case Op.OpSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL: return VisitSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL((Nodes.SubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL) node);
                case Op.OpSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL: return VisitSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL((Nodes.SubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL) node);
                case Op.OpSubgroupAvcSicGetInterRawSadsINTEL: return VisitSubgroupAvcSicGetInterRawSadsINTEL((Nodes.SubgroupAvcSicGetInterRawSadsINTEL) node);
            }

            throw new NotImplementedException(node.OpCode+" is not implemented yet.");
        }


        protected virtual ScriptNode VisitNop(Nodes.Nop node)
        {
            var scriptNode = CreateNode(node, "OpNop", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUndef(Nodes.Undef node)
        {
            var scriptNode = CreateNode(node, "OpUndef", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSourceContinued(Nodes.SourceContinued node)
        {
            var scriptNode = CreateNode(node, "OpSourceContinued", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSource(Nodes.Source node)
        {
            var scriptNode = CreateNode(node, "OpSource", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSourceExtension(Nodes.SourceExtension node)
        {
            var scriptNode = CreateNode(node, "OpSourceExtension", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitName(Nodes.Name node)
        {
            var scriptNode = CreateNode(node, "OpName", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemberName(Nodes.MemberName node)
        {
            var scriptNode = CreateNode(node, "OpMemberName", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitString(Nodes.String node)
        {
            var scriptNode = CreateNode(node, "OpString", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLine(Nodes.Line node)
        {
            var scriptNode = CreateNode(node, "OpLine", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitExtension(Nodes.Extension node)
        {
            var scriptNode = CreateNode(node, "OpExtension", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitExtInstImport(Nodes.ExtInstImport node)
        {
            var scriptNode = CreateNode(node, "OpExtInstImport", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitExtInst(Nodes.ExtInst node)
        {
            var scriptNode = CreateNode(node, "OpExtInst", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemoryModel(Nodes.MemoryModel node)
        {
            var scriptNode = CreateNode(node, "OpMemoryModel", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitEntryPoint(Nodes.EntryPoint node)
        {
            var scriptNode = CreateNode(node, "OpEntryPoint", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitExecutionMode(Nodes.ExecutionMode node)
        {
            var scriptNode = CreateNode(node, "OpExecutionMode", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCapability(Nodes.Capability node)
        {
            var scriptNode = CreateNode(node, "OpCapability", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantTrue(Nodes.ConstantTrue node)
        {
            var scriptNode = CreateNode(node, "OpConstantTrue", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantFalse(Nodes.ConstantFalse node)
        {
            var scriptNode = CreateNode(node, "OpConstantFalse", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstant(Nodes.Constant node)
        {
            var scriptNode = CreateNode(node, "OpConstant", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantComposite(Nodes.ConstantComposite node)
        {
            var scriptNode = CreateNode(node, "OpConstantComposite", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantSampler(Nodes.ConstantSampler node)
        {
            var scriptNode = CreateNode(node, "OpConstantSampler", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantNull(Nodes.ConstantNull node)
        {
            var scriptNode = CreateNode(node, "OpConstantNull", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSpecConstantTrue(Nodes.SpecConstantTrue node)
        {
            var scriptNode = CreateNode(node, "OpSpecConstantTrue", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSpecConstantFalse(Nodes.SpecConstantFalse node)
        {
            var scriptNode = CreateNode(node, "OpSpecConstantFalse", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSpecConstant(Nodes.SpecConstant node)
        {
            var scriptNode = CreateNode(node, "OpSpecConstant", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSpecConstantComposite(Nodes.SpecConstantComposite node)
        {
            var scriptNode = CreateNode(node, "OpSpecConstantComposite", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSpecConstantOp(Nodes.SpecConstantOp node)
        {
            var scriptNode = CreateNode(node, "OpSpecConstantOp", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFunction(Nodes.Function node)
        {
            var scriptNode = CreateNode(node, "OpFunction", false, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitFunctionParameter(Nodes.FunctionParameter node)
        {
            var scriptNode = CreateNode(node, "OpFunctionParameter", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFunctionEnd(Nodes.FunctionEnd node)
        {
            var scriptNode = CreateNode(node, "OpFunctionEnd", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitFunctionCall(Nodes.FunctionCall node)
        {
            var scriptNode = CreateNode(node, "OpFunctionCall", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitVariable(Nodes.Variable node)
        {
            var scriptNode = CreateNode(node, "OpVariable", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageTexelPointer(Nodes.ImageTexelPointer node)
        {
            var scriptNode = CreateNode(node, "OpImageTexelPointer", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLoad(Nodes.Load node)
        {
            var scriptNode = CreateNode(node, "OpLoad", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitStore(Nodes.Store node)
        {
            var scriptNode = CreateNode(node, "OpStore", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitCopyMemory(Nodes.CopyMemory node)
        {
            var scriptNode = CreateNode(node, "OpCopyMemory", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitCopyMemorySized(Nodes.CopyMemorySized node)
        {
            var scriptNode = CreateNode(node, "OpCopyMemorySized", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitAccessChain(Nodes.AccessChain node)
        {
            var scriptNode = CreateNode(node, "OpAccessChain", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitInBoundsAccessChain(Nodes.InBoundsAccessChain node)
        {
            var scriptNode = CreateNode(node, "OpInBoundsAccessChain", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitPtrAccessChain(Nodes.PtrAccessChain node)
        {
            var scriptNode = CreateNode(node, "OpPtrAccessChain", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitArrayLength(Nodes.ArrayLength node)
        {
            var scriptNode = CreateNode(node, "OpArrayLength", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGenericPtrMemSemantics(Nodes.GenericPtrMemSemantics node)
        {
            var scriptNode = CreateNode(node, "OpGenericPtrMemSemantics", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitInBoundsPtrAccessChain(Nodes.InBoundsPtrAccessChain node)
        {
            var scriptNode = CreateNode(node, "OpInBoundsPtrAccessChain", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDecorate(Nodes.Decorate node)
        {
            var scriptNode = CreateNode(node, "OpDecorate", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemberDecorate(Nodes.MemberDecorate node)
        {
            var scriptNode = CreateNode(node, "OpMemberDecorate", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDecorationGroup(Nodes.DecorationGroup node)
        {
            var scriptNode = CreateNode(node, "OpDecorationGroup", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupDecorate(Nodes.GroupDecorate node)
        {
            var scriptNode = CreateNode(node, "OpGroupDecorate", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupMemberDecorate(Nodes.GroupMemberDecorate node)
        {
            var scriptNode = CreateNode(node, "OpGroupMemberDecorate", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitVectorExtractDynamic(Nodes.VectorExtractDynamic node)
        {
            var scriptNode = CreateNode(node, "OpVectorExtractDynamic", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitVectorInsertDynamic(Nodes.VectorInsertDynamic node)
        {
            var scriptNode = CreateNode(node, "OpVectorInsertDynamic", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitVectorShuffle(Nodes.VectorShuffle node)
        {
            var scriptNode = CreateNode(node, "OpVectorShuffle", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCompositeConstruct(Nodes.CompositeConstruct node)
        {
            var scriptNode = CreateNode(node, "OpCompositeConstruct", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCompositeExtract(Nodes.CompositeExtract node)
        {
            var scriptNode = CreateNode(node, "OpCompositeExtract", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCompositeInsert(Nodes.CompositeInsert node)
        {
            var scriptNode = CreateNode(node, "OpCompositeInsert", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCopyObject(Nodes.CopyObject node)
        {
            var scriptNode = CreateNode(node, "OpCopyObject", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitTranspose(Nodes.Transpose node)
        {
            var scriptNode = CreateNode(node, "OpTranspose", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSampledImage(Nodes.SampledImage node)
        {
            var scriptNode = CreateNode(node, "OpSampledImage", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleImplicitLod(Nodes.ImageSampleImplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSampleImplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleExplicitLod(Nodes.ImageSampleExplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSampleExplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleDrefImplicitLod(Nodes.ImageSampleDrefImplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSampleDrefImplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleDrefExplicitLod(Nodes.ImageSampleDrefExplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSampleDrefExplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleProjImplicitLod(Nodes.ImageSampleProjImplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSampleProjImplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleProjExplicitLod(Nodes.ImageSampleProjExplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSampleProjExplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleProjDrefImplicitLod(Nodes.ImageSampleProjDrefImplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSampleProjDrefImplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleProjDrefExplicitLod(Nodes.ImageSampleProjDrefExplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSampleProjDrefExplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageFetch(Nodes.ImageFetch node)
        {
            var scriptNode = CreateNode(node, "OpImageFetch", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageGather(Nodes.ImageGather node)
        {
            var scriptNode = CreateNode(node, "OpImageGather", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageDrefGather(Nodes.ImageDrefGather node)
        {
            var scriptNode = CreateNode(node, "OpImageDrefGather", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageRead(Nodes.ImageRead node)
        {
            var scriptNode = CreateNode(node, "OpImageRead", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageWrite(Nodes.ImageWrite node)
        {
            var scriptNode = CreateNode(node, "OpImageWrite", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitImage(Nodes.Image node)
        {
            var scriptNode = CreateNode(node, "OpImage", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQueryFormat(Nodes.ImageQueryFormat node)
        {
            var scriptNode = CreateNode(node, "OpImageQueryFormat", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQueryOrder(Nodes.ImageQueryOrder node)
        {
            var scriptNode = CreateNode(node, "OpImageQueryOrder", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQuerySizeLod(Nodes.ImageQuerySizeLod node)
        {
            var scriptNode = CreateNode(node, "OpImageQuerySizeLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQuerySize(Nodes.ImageQuerySize node)
        {
            var scriptNode = CreateNode(node, "OpImageQuerySize", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQueryLod(Nodes.ImageQueryLod node)
        {
            var scriptNode = CreateNode(node, "OpImageQueryLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQueryLevels(Nodes.ImageQueryLevels node)
        {
            var scriptNode = CreateNode(node, "OpImageQueryLevels", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQuerySamples(Nodes.ImageQuerySamples node)
        {
            var scriptNode = CreateNode(node, "OpImageQuerySamples", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertFToU(Nodes.ConvertFToU node)
        {
            var scriptNode = CreateNode(node, "OpConvertFToU", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertFToS(Nodes.ConvertFToS node)
        {
            var scriptNode = CreateNode(node, "OpConvertFToS", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertSToF(Nodes.ConvertSToF node)
        {
            var scriptNode = CreateNode(node, "OpConvertSToF", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertUToF(Nodes.ConvertUToF node)
        {
            var scriptNode = CreateNode(node, "OpConvertUToF", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUConvert(Nodes.UConvert node)
        {
            var scriptNode = CreateNode(node, "OpUConvert", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSConvert(Nodes.SConvert node)
        {
            var scriptNode = CreateNode(node, "OpSConvert", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFConvert(Nodes.FConvert node)
        {
            var scriptNode = CreateNode(node, "OpFConvert", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitQuantizeToF16(Nodes.QuantizeToF16 node)
        {
            var scriptNode = CreateNode(node, "OpQuantizeToF16", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertPtrToU(Nodes.ConvertPtrToU node)
        {
            var scriptNode = CreateNode(node, "OpConvertPtrToU", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSatConvertSToU(Nodes.SatConvertSToU node)
        {
            var scriptNode = CreateNode(node, "OpSatConvertSToU", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSatConvertUToS(Nodes.SatConvertUToS node)
        {
            var scriptNode = CreateNode(node, "OpSatConvertUToS", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertUToPtr(Nodes.ConvertUToPtr node)
        {
            var scriptNode = CreateNode(node, "OpConvertUToPtr", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitPtrCastToGeneric(Nodes.PtrCastToGeneric node)
        {
            var scriptNode = CreateNode(node, "OpPtrCastToGeneric", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGenericCastToPtr(Nodes.GenericCastToPtr node)
        {
            var scriptNode = CreateNode(node, "OpGenericCastToPtr", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGenericCastToPtrExplicit(Nodes.GenericCastToPtrExplicit node)
        {
            var scriptNode = CreateNode(node, "OpGenericCastToPtrExplicit", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitcast(Nodes.Bitcast node)
        {
            var scriptNode = CreateNode(node, "OpBitcast", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSNegate(Nodes.SNegate node)
        {
            var scriptNode = CreateNode(node, "OpSNegate", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFNegate(Nodes.FNegate node)
        {
            var scriptNode = CreateNode(node, "OpFNegate", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIAdd(Nodes.IAdd node)
        {
            var scriptNode = CreateNode(node, "OpIAdd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFAdd(Nodes.FAdd node)
        {
            var scriptNode = CreateNode(node, "OpFAdd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitISub(Nodes.ISub node)
        {
            var scriptNode = CreateNode(node, "OpISub", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFSub(Nodes.FSub node)
        {
            var scriptNode = CreateNode(node, "OpFSub", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIMul(Nodes.IMul node)
        {
            var scriptNode = CreateNode(node, "OpIMul", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFMul(Nodes.FMul node)
        {
            var scriptNode = CreateNode(node, "OpFMul", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUDiv(Nodes.UDiv node)
        {
            var scriptNode = CreateNode(node, "OpUDiv", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSDiv(Nodes.SDiv node)
        {
            var scriptNode = CreateNode(node, "OpSDiv", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFDiv(Nodes.FDiv node)
        {
            var scriptNode = CreateNode(node, "OpFDiv", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUMod(Nodes.UMod node)
        {
            var scriptNode = CreateNode(node, "OpUMod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSRem(Nodes.SRem node)
        {
            var scriptNode = CreateNode(node, "OpSRem", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSMod(Nodes.SMod node)
        {
            var scriptNode = CreateNode(node, "OpSMod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFRem(Nodes.FRem node)
        {
            var scriptNode = CreateNode(node, "OpFRem", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFMod(Nodes.FMod node)
        {
            var scriptNode = CreateNode(node, "OpFMod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitVectorTimesScalar(Nodes.VectorTimesScalar node)
        {
            var scriptNode = CreateNode(node, "OpVectorTimesScalar", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitMatrixTimesScalar(Nodes.MatrixTimesScalar node)
        {
            var scriptNode = CreateNode(node, "OpMatrixTimesScalar", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitVectorTimesMatrix(Nodes.VectorTimesMatrix node)
        {
            var scriptNode = CreateNode(node, "OpVectorTimesMatrix", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitMatrixTimesVector(Nodes.MatrixTimesVector node)
        {
            var scriptNode = CreateNode(node, "OpMatrixTimesVector", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitMatrixTimesMatrix(Nodes.MatrixTimesMatrix node)
        {
            var scriptNode = CreateNode(node, "OpMatrixTimesMatrix", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitOuterProduct(Nodes.OuterProduct node)
        {
            var scriptNode = CreateNode(node, "OpOuterProduct", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDot(Nodes.Dot node)
        {
            var scriptNode = CreateNode(node, "OpDot", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIAddCarry(Nodes.IAddCarry node)
        {
            var scriptNode = CreateNode(node, "OpIAddCarry", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitISubBorrow(Nodes.ISubBorrow node)
        {
            var scriptNode = CreateNode(node, "OpISubBorrow", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUMulExtended(Nodes.UMulExtended node)
        {
            var scriptNode = CreateNode(node, "OpUMulExtended", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSMulExtended(Nodes.SMulExtended node)
        {
            var scriptNode = CreateNode(node, "OpSMulExtended", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAny(Nodes.Any node)
        {
            var scriptNode = CreateNode(node, "OpAny", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAll(Nodes.All node)
        {
            var scriptNode = CreateNode(node, "OpAll", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsNan(Nodes.IsNan node)
        {
            var scriptNode = CreateNode(node, "OpIsNan", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsInf(Nodes.IsInf node)
        {
            var scriptNode = CreateNode(node, "OpIsInf", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsFinite(Nodes.IsFinite node)
        {
            var scriptNode = CreateNode(node, "OpIsFinite", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsNormal(Nodes.IsNormal node)
        {
            var scriptNode = CreateNode(node, "OpIsNormal", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSignBitSet(Nodes.SignBitSet node)
        {
            var scriptNode = CreateNode(node, "OpSignBitSet", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLessOrGreater(Nodes.LessOrGreater node)
        {
            var scriptNode = CreateNode(node, "OpLessOrGreater", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitOrdered(Nodes.Ordered node)
        {
            var scriptNode = CreateNode(node, "OpOrdered", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUnordered(Nodes.Unordered node)
        {
            var scriptNode = CreateNode(node, "OpUnordered", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLogicalEqual(Nodes.LogicalEqual node)
        {
            var scriptNode = CreateNode(node, "OpLogicalEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLogicalNotEqual(Nodes.LogicalNotEqual node)
        {
            var scriptNode = CreateNode(node, "OpLogicalNotEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLogicalOr(Nodes.LogicalOr node)
        {
            var scriptNode = CreateNode(node, "OpLogicalOr", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLogicalAnd(Nodes.LogicalAnd node)
        {
            var scriptNode = CreateNode(node, "OpLogicalAnd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLogicalNot(Nodes.LogicalNot node)
        {
            var scriptNode = CreateNode(node, "OpLogicalNot", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSelect(Nodes.Select node)
        {
            var scriptNode = CreateNode(node, "OpSelect", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIEqual(Nodes.IEqual node)
        {
            var scriptNode = CreateNode(node, "OpIEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitINotEqual(Nodes.INotEqual node)
        {
            var scriptNode = CreateNode(node, "OpINotEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUGreaterThan(Nodes.UGreaterThan node)
        {
            var scriptNode = CreateNode(node, "OpUGreaterThan", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSGreaterThan(Nodes.SGreaterThan node)
        {
            var scriptNode = CreateNode(node, "OpSGreaterThan", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUGreaterThanEqual(Nodes.UGreaterThanEqual node)
        {
            var scriptNode = CreateNode(node, "OpUGreaterThanEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSGreaterThanEqual(Nodes.SGreaterThanEqual node)
        {
            var scriptNode = CreateNode(node, "OpSGreaterThanEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitULessThan(Nodes.ULessThan node)
        {
            var scriptNode = CreateNode(node, "OpULessThan", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSLessThan(Nodes.SLessThan node)
        {
            var scriptNode = CreateNode(node, "OpSLessThan", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitULessThanEqual(Nodes.ULessThanEqual node)
        {
            var scriptNode = CreateNode(node, "OpULessThanEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSLessThanEqual(Nodes.SLessThanEqual node)
        {
            var scriptNode = CreateNode(node, "OpSLessThanEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdEqual(Nodes.FOrdEqual node)
        {
            var scriptNode = CreateNode(node, "OpFOrdEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordEqual(Nodes.FUnordEqual node)
        {
            var scriptNode = CreateNode(node, "OpFUnordEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdNotEqual(Nodes.FOrdNotEqual node)
        {
            var scriptNode = CreateNode(node, "OpFOrdNotEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordNotEqual(Nodes.FUnordNotEqual node)
        {
            var scriptNode = CreateNode(node, "OpFUnordNotEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdLessThan(Nodes.FOrdLessThan node)
        {
            var scriptNode = CreateNode(node, "OpFOrdLessThan", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordLessThan(Nodes.FUnordLessThan node)
        {
            var scriptNode = CreateNode(node, "OpFUnordLessThan", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdGreaterThan(Nodes.FOrdGreaterThan node)
        {
            var scriptNode = CreateNode(node, "OpFOrdGreaterThan", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordGreaterThan(Nodes.FUnordGreaterThan node)
        {
            var scriptNode = CreateNode(node, "OpFUnordGreaterThan", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdLessThanEqual(Nodes.FOrdLessThanEqual node)
        {
            var scriptNode = CreateNode(node, "OpFOrdLessThanEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordLessThanEqual(Nodes.FUnordLessThanEqual node)
        {
            var scriptNode = CreateNode(node, "OpFUnordLessThanEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdGreaterThanEqual(Nodes.FOrdGreaterThanEqual node)
        {
            var scriptNode = CreateNode(node, "OpFOrdGreaterThanEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordGreaterThanEqual(Nodes.FUnordGreaterThanEqual node)
        {
            var scriptNode = CreateNode(node, "OpFUnordGreaterThanEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitShiftRightLogical(Nodes.ShiftRightLogical node)
        {
            var scriptNode = CreateNode(node, "OpShiftRightLogical", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitShiftRightArithmetic(Nodes.ShiftRightArithmetic node)
        {
            var scriptNode = CreateNode(node, "OpShiftRightArithmetic", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitShiftLeftLogical(Nodes.ShiftLeftLogical node)
        {
            var scriptNode = CreateNode(node, "OpShiftLeftLogical", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitwiseOr(Nodes.BitwiseOr node)
        {
            var scriptNode = CreateNode(node, "OpBitwiseOr", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitwiseXor(Nodes.BitwiseXor node)
        {
            var scriptNode = CreateNode(node, "OpBitwiseXor", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitwiseAnd(Nodes.BitwiseAnd node)
        {
            var scriptNode = CreateNode(node, "OpBitwiseAnd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitNot(Nodes.Not node)
        {
            var scriptNode = CreateNode(node, "OpNot", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitFieldInsert(Nodes.BitFieldInsert node)
        {
            var scriptNode = CreateNode(node, "OpBitFieldInsert", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitFieldSExtract(Nodes.BitFieldSExtract node)
        {
            var scriptNode = CreateNode(node, "OpBitFieldSExtract", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitFieldUExtract(Nodes.BitFieldUExtract node)
        {
            var scriptNode = CreateNode(node, "OpBitFieldUExtract", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitReverse(Nodes.BitReverse node)
        {
            var scriptNode = CreateNode(node, "OpBitReverse", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitCount(Nodes.BitCount node)
        {
            var scriptNode = CreateNode(node, "OpBitCount", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdx(Nodes.DPdx node)
        {
            var scriptNode = CreateNode(node, "OpDPdx", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdy(Nodes.DPdy node)
        {
            var scriptNode = CreateNode(node, "OpDPdy", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFwidth(Nodes.Fwidth node)
        {
            var scriptNode = CreateNode(node, "OpFwidth", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdxFine(Nodes.DPdxFine node)
        {
            var scriptNode = CreateNode(node, "OpDPdxFine", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdyFine(Nodes.DPdyFine node)
        {
            var scriptNode = CreateNode(node, "OpDPdyFine", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFwidthFine(Nodes.FwidthFine node)
        {
            var scriptNode = CreateNode(node, "OpFwidthFine", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdxCoarse(Nodes.DPdxCoarse node)
        {
            var scriptNode = CreateNode(node, "OpDPdxCoarse", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdyCoarse(Nodes.DPdyCoarse node)
        {
            var scriptNode = CreateNode(node, "OpDPdyCoarse", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFwidthCoarse(Nodes.FwidthCoarse node)
        {
            var scriptNode = CreateNode(node, "OpFwidthCoarse", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitEmitVertex(Nodes.EmitVertex node)
        {
            var scriptNode = CreateNode(node, "OpEmitVertex", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitEndPrimitive(Nodes.EndPrimitive node)
        {
            var scriptNode = CreateNode(node, "OpEndPrimitive", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitEmitStreamVertex(Nodes.EmitStreamVertex node)
        {
            var scriptNode = CreateNode(node, "OpEmitStreamVertex", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitEndStreamPrimitive(Nodes.EndStreamPrimitive node)
        {
            var scriptNode = CreateNode(node, "OpEndStreamPrimitive", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitControlBarrier(Nodes.ControlBarrier node)
        {
            var scriptNode = CreateNode(node, "OpControlBarrier", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemoryBarrier(Nodes.MemoryBarrier node)
        {
            var scriptNode = CreateNode(node, "OpMemoryBarrier", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicLoad(Nodes.AtomicLoad node)
        {
            var scriptNode = CreateNode(node, "OpAtomicLoad", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicStore(Nodes.AtomicStore node)
        {
            var scriptNode = CreateNode(node, "OpAtomicStore", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicExchange(Nodes.AtomicExchange node)
        {
            var scriptNode = CreateNode(node, "OpAtomicExchange", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicCompareExchange(Nodes.AtomicCompareExchange node)
        {
            var scriptNode = CreateNode(node, "OpAtomicCompareExchange", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicCompareExchangeWeak(Nodes.AtomicCompareExchangeWeak node)
        {
            var scriptNode = CreateNode(node, "OpAtomicCompareExchangeWeak", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicIIncrement(Nodes.AtomicIIncrement node)
        {
            var scriptNode = CreateNode(node, "OpAtomicIIncrement", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicIDecrement(Nodes.AtomicIDecrement node)
        {
            var scriptNode = CreateNode(node, "OpAtomicIDecrement", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicIAdd(Nodes.AtomicIAdd node)
        {
            var scriptNode = CreateNode(node, "OpAtomicIAdd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicISub(Nodes.AtomicISub node)
        {
            var scriptNode = CreateNode(node, "OpAtomicISub", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicSMin(Nodes.AtomicSMin node)
        {
            var scriptNode = CreateNode(node, "OpAtomicSMin", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicUMin(Nodes.AtomicUMin node)
        {
            var scriptNode = CreateNode(node, "OpAtomicUMin", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicSMax(Nodes.AtomicSMax node)
        {
            var scriptNode = CreateNode(node, "OpAtomicSMax", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicUMax(Nodes.AtomicUMax node)
        {
            var scriptNode = CreateNode(node, "OpAtomicUMax", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicAnd(Nodes.AtomicAnd node)
        {
            var scriptNode = CreateNode(node, "OpAtomicAnd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicOr(Nodes.AtomicOr node)
        {
            var scriptNode = CreateNode(node, "OpAtomicOr", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicXor(Nodes.AtomicXor node)
        {
            var scriptNode = CreateNode(node, "OpAtomicXor", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitPhi(Nodes.Phi node)
        {
            var scriptNode = CreateNode(node, "OpPhi", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLoopMerge(Nodes.LoopMerge node)
        {
            var scriptNode = CreateNode(node, "OpLoopMerge", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitSelectionMerge(Nodes.SelectionMerge node)
        {
            var scriptNode = CreateNode(node, "OpSelectionMerge", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitLabel(Nodes.Label node)
        {
            var scriptNode = CreateNode(node, "OpLabel", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitBranch(Nodes.Branch node)
        {
            var scriptNode = CreateNode(node, "OpBranch", true, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBranchConditional(Nodes.BranchConditional node)
        {
            var scriptNode = CreateNode(node, "OpBranchConditional", true, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSwitch(Nodes.Switch node)
        {
            var scriptNode = CreateNode(node, "OpSwitch", true, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitKill(Nodes.Kill node)
        {
            var scriptNode = CreateNode(node, "OpKill", true, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitReturn(Nodes.Return node)
        {
            var scriptNode = CreateNode(node, "OpReturn", true, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitReturnValue(Nodes.ReturnValue node)
        {
            var scriptNode = CreateNode(node, "OpReturnValue", true, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUnreachable(Nodes.Unreachable node)
        {
            var scriptNode = CreateNode(node, "OpUnreachable", true, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLifetimeStart(Nodes.LifetimeStart node)
        {
            var scriptNode = CreateNode(node, "OpLifetimeStart", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitLifetimeStop(Nodes.LifetimeStop node)
        {
            var scriptNode = CreateNode(node, "OpLifetimeStop", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupAsyncCopy(Nodes.GroupAsyncCopy node)
        {
            var scriptNode = CreateNode(node, "OpGroupAsyncCopy", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupWaitEvents(Nodes.GroupWaitEvents node)
        {
            var scriptNode = CreateNode(node, "OpGroupWaitEvents", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupAll(Nodes.GroupAll node)
        {
            var scriptNode = CreateNode(node, "OpGroupAll", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupAny(Nodes.GroupAny node)
        {
            var scriptNode = CreateNode(node, "OpGroupAny", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupBroadcast(Nodes.GroupBroadcast node)
        {
            var scriptNode = CreateNode(node, "OpGroupBroadcast", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupIAdd(Nodes.GroupIAdd node)
        {
            var scriptNode = CreateNode(node, "OpGroupIAdd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFAdd(Nodes.GroupFAdd node)
        {
            var scriptNode = CreateNode(node, "OpGroupFAdd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFMin(Nodes.GroupFMin node)
        {
            var scriptNode = CreateNode(node, "OpGroupFMin", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupUMin(Nodes.GroupUMin node)
        {
            var scriptNode = CreateNode(node, "OpGroupUMin", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupSMin(Nodes.GroupSMin node)
        {
            var scriptNode = CreateNode(node, "OpGroupSMin", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFMax(Nodes.GroupFMax node)
        {
            var scriptNode = CreateNode(node, "OpGroupFMax", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupUMax(Nodes.GroupUMax node)
        {
            var scriptNode = CreateNode(node, "OpGroupUMax", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupSMax(Nodes.GroupSMax node)
        {
            var scriptNode = CreateNode(node, "OpGroupSMax", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitReadPipe(Nodes.ReadPipe node)
        {
            var scriptNode = CreateNode(node, "OpReadPipe", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitWritePipe(Nodes.WritePipe node)
        {
            var scriptNode = CreateNode(node, "OpWritePipe", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitReservedReadPipe(Nodes.ReservedReadPipe node)
        {
            var scriptNode = CreateNode(node, "OpReservedReadPipe", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitReservedWritePipe(Nodes.ReservedWritePipe node)
        {
            var scriptNode = CreateNode(node, "OpReservedWritePipe", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitReserveReadPipePackets(Nodes.ReserveReadPipePackets node)
        {
            var scriptNode = CreateNode(node, "OpReserveReadPipePackets", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitReserveWritePipePackets(Nodes.ReserveWritePipePackets node)
        {
            var scriptNode = CreateNode(node, "OpReserveWritePipePackets", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCommitReadPipe(Nodes.CommitReadPipe node)
        {
            var scriptNode = CreateNode(node, "OpCommitReadPipe", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitCommitWritePipe(Nodes.CommitWritePipe node)
        {
            var scriptNode = CreateNode(node, "OpCommitWritePipe", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsValidReserveId(Nodes.IsValidReserveId node)
        {
            var scriptNode = CreateNode(node, "OpIsValidReserveId", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetNumPipePackets(Nodes.GetNumPipePackets node)
        {
            var scriptNode = CreateNode(node, "OpGetNumPipePackets", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetMaxPipePackets(Nodes.GetMaxPipePackets node)
        {
            var scriptNode = CreateNode(node, "OpGetMaxPipePackets", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupReserveReadPipePackets(Nodes.GroupReserveReadPipePackets node)
        {
            var scriptNode = CreateNode(node, "OpGroupReserveReadPipePackets", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupReserveWritePipePackets(Nodes.GroupReserveWritePipePackets node)
        {
            var scriptNode = CreateNode(node, "OpGroupReserveWritePipePackets", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupCommitReadPipe(Nodes.GroupCommitReadPipe node)
        {
            var scriptNode = CreateNode(node, "OpGroupCommitReadPipe", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupCommitWritePipe(Nodes.GroupCommitWritePipe node)
        {
            var scriptNode = CreateNode(node, "OpGroupCommitWritePipe", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitEnqueueMarker(Nodes.EnqueueMarker node)
        {
            var scriptNode = CreateNode(node, "OpEnqueueMarker", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitEnqueueKernel(Nodes.EnqueueKernel node)
        {
            var scriptNode = CreateNode(node, "OpEnqueueKernel", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelNDrangeSubGroupCount(Nodes.GetKernelNDrangeSubGroupCount node)
        {
            var scriptNode = CreateNode(node, "OpGetKernelNDrangeSubGroupCount", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelNDrangeMaxSubGroupSize(Nodes.GetKernelNDrangeMaxSubGroupSize node)
        {
            var scriptNode = CreateNode(node, "OpGetKernelNDrangeMaxSubGroupSize", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelWorkGroupSize(Nodes.GetKernelWorkGroupSize node)
        {
            var scriptNode = CreateNode(node, "OpGetKernelWorkGroupSize", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelPreferredWorkGroupSizeMultiple(Nodes.GetKernelPreferredWorkGroupSizeMultiple node)
        {
            var scriptNode = CreateNode(node, "OpGetKernelPreferredWorkGroupSizeMultiple", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRetainEvent(Nodes.RetainEvent node)
        {
            var scriptNode = CreateNode(node, "OpRetainEvent", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitReleaseEvent(Nodes.ReleaseEvent node)
        {
            var scriptNode = CreateNode(node, "OpReleaseEvent", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitCreateUserEvent(Nodes.CreateUserEvent node)
        {
            var scriptNode = CreateNode(node, "OpCreateUserEvent", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsValidEvent(Nodes.IsValidEvent node)
        {
            var scriptNode = CreateNode(node, "OpIsValidEvent", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSetUserEventStatus(Nodes.SetUserEventStatus node)
        {
            var scriptNode = CreateNode(node, "OpSetUserEventStatus", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitCaptureEventProfilingInfo(Nodes.CaptureEventProfilingInfo node)
        {
            var scriptNode = CreateNode(node, "OpCaptureEventProfilingInfo", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetDefaultQueue(Nodes.GetDefaultQueue node)
        {
            var scriptNode = CreateNode(node, "OpGetDefaultQueue", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBuildNDRange(Nodes.BuildNDRange node)
        {
            var scriptNode = CreateNode(node, "OpBuildNDRange", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleImplicitLod(Nodes.ImageSparseSampleImplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseSampleImplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleExplicitLod(Nodes.ImageSparseSampleExplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseSampleExplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleDrefImplicitLod(Nodes.ImageSparseSampleDrefImplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseSampleDrefImplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleDrefExplicitLod(Nodes.ImageSparseSampleDrefExplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseSampleDrefExplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleProjImplicitLod(Nodes.ImageSparseSampleProjImplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseSampleProjImplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleProjExplicitLod(Nodes.ImageSparseSampleProjExplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseSampleProjExplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleProjDrefImplicitLod(Nodes.ImageSparseSampleProjDrefImplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseSampleProjDrefImplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleProjDrefExplicitLod(Nodes.ImageSparseSampleProjDrefExplicitLod node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseSampleProjDrefExplicitLod", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseFetch(Nodes.ImageSparseFetch node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseFetch", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseGather(Nodes.ImageSparseGather node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseGather", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseDrefGather(Nodes.ImageSparseDrefGather node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseDrefGather", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseTexelsResident(Nodes.ImageSparseTexelsResident node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseTexelsResident", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitNoLine(Nodes.NoLine node)
        {
            var scriptNode = CreateNode(node, "OpNoLine", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicFlagTestAndSet(Nodes.AtomicFlagTestAndSet node)
        {
            var scriptNode = CreateNode(node, "OpAtomicFlagTestAndSet", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicFlagClear(Nodes.AtomicFlagClear node)
        {
            var scriptNode = CreateNode(node, "OpAtomicFlagClear", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseRead(Nodes.ImageSparseRead node)
        {
            var scriptNode = CreateNode(node, "OpImageSparseRead", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSizeOf(Nodes.SizeOf node)
        {
            var scriptNode = CreateNode(node, "OpSizeOf", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantPipeStorage(Nodes.ConstantPipeStorage node)
        {
            var scriptNode = CreateNode(node, "OpConstantPipeStorage", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCreatePipeFromPipeStorage(Nodes.CreatePipeFromPipeStorage node)
        {
            var scriptNode = CreateNode(node, "OpCreatePipeFromPipeStorage", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelLocalSizeForSubgroupCount(Nodes.GetKernelLocalSizeForSubgroupCount node)
        {
            var scriptNode = CreateNode(node, "OpGetKernelLocalSizeForSubgroupCount", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelMaxNumSubgroups(Nodes.GetKernelMaxNumSubgroups node)
        {
            var scriptNode = CreateNode(node, "OpGetKernelMaxNumSubgroups", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitNamedBarrierInitialize(Nodes.NamedBarrierInitialize node)
        {
            var scriptNode = CreateNode(node, "OpNamedBarrierInitialize", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemoryNamedBarrier(Nodes.MemoryNamedBarrier node)
        {
            var scriptNode = CreateNode(node, "OpMemoryNamedBarrier", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitModuleProcessed(Nodes.ModuleProcessed node)
        {
            var scriptNode = CreateNode(node, "OpModuleProcessed", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitExecutionModeId(Nodes.ExecutionModeId node)
        {
            var scriptNode = CreateNode(node, "OpExecutionModeId", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitDecorateId(Nodes.DecorateId node)
        {
            var scriptNode = CreateNode(node, "OpDecorateId", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformElect(Nodes.GroupNonUniformElect node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformElect", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformAll(Nodes.GroupNonUniformAll node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformAll", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformAny(Nodes.GroupNonUniformAny node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformAny", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformAllEqual(Nodes.GroupNonUniformAllEqual node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformAllEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBroadcast(Nodes.GroupNonUniformBroadcast node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformBroadcast", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBroadcastFirst(Nodes.GroupNonUniformBroadcastFirst node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformBroadcastFirst", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBallot(Nodes.GroupNonUniformBallot node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformBallot", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformInverseBallot(Nodes.GroupNonUniformInverseBallot node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformInverseBallot", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBallotBitExtract(Nodes.GroupNonUniformBallotBitExtract node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformBallotBitExtract", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBallotBitCount(Nodes.GroupNonUniformBallotBitCount node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformBallotBitCount", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBallotFindLSB(Nodes.GroupNonUniformBallotFindLSB node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformBallotFindLSB", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBallotFindMSB(Nodes.GroupNonUniformBallotFindMSB node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformBallotFindMSB", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformShuffle(Nodes.GroupNonUniformShuffle node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformShuffle", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformShuffleXor(Nodes.GroupNonUniformShuffleXor node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformShuffleXor", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformShuffleUp(Nodes.GroupNonUniformShuffleUp node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformShuffleUp", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformShuffleDown(Nodes.GroupNonUniformShuffleDown node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformShuffleDown", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformIAdd(Nodes.GroupNonUniformIAdd node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformIAdd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformFAdd(Nodes.GroupNonUniformFAdd node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformFAdd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformIMul(Nodes.GroupNonUniformIMul node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformIMul", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformFMul(Nodes.GroupNonUniformFMul node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformFMul", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformSMin(Nodes.GroupNonUniformSMin node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformSMin", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformUMin(Nodes.GroupNonUniformUMin node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformUMin", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformFMin(Nodes.GroupNonUniformFMin node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformFMin", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformSMax(Nodes.GroupNonUniformSMax node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformSMax", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformUMax(Nodes.GroupNonUniformUMax node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformUMax", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformFMax(Nodes.GroupNonUniformFMax node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformFMax", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBitwiseAnd(Nodes.GroupNonUniformBitwiseAnd node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformBitwiseAnd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBitwiseOr(Nodes.GroupNonUniformBitwiseOr node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformBitwiseOr", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBitwiseXor(Nodes.GroupNonUniformBitwiseXor node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformBitwiseXor", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformLogicalAnd(Nodes.GroupNonUniformLogicalAnd node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformLogicalAnd", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformLogicalOr(Nodes.GroupNonUniformLogicalOr node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformLogicalOr", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformLogicalXor(Nodes.GroupNonUniformLogicalXor node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformLogicalXor", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformQuadBroadcast(Nodes.GroupNonUniformQuadBroadcast node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformQuadBroadcast", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformQuadSwap(Nodes.GroupNonUniformQuadSwap node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformQuadSwap", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCopyLogical(Nodes.CopyLogical node)
        {
            var scriptNode = CreateNode(node, "OpCopyLogical", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitPtrEqual(Nodes.PtrEqual node)
        {
            var scriptNode = CreateNode(node, "OpPtrEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitPtrNotEqual(Nodes.PtrNotEqual node)
        {
            var scriptNode = CreateNode(node, "OpPtrNotEqual", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitPtrDiff(Nodes.PtrDiff node)
        {
            var scriptNode = CreateNode(node, "OpPtrDiff", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupBallotKHR(Nodes.SubgroupBallotKHR node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupBallotKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupFirstInvocationKHR(Nodes.SubgroupFirstInvocationKHR node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupFirstInvocationKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAllKHR(Nodes.SubgroupAllKHR node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAllKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAnyKHR(Nodes.SubgroupAnyKHR node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAnyKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAllEqualKHR(Nodes.SubgroupAllEqualKHR node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAllEqualKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupReadInvocationKHR(Nodes.SubgroupReadInvocationKHR node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupReadInvocationKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupIAddNonUniformAMD(Nodes.GroupIAddNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, "OpGroupIAddNonUniformAMD", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFAddNonUniformAMD(Nodes.GroupFAddNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, "OpGroupFAddNonUniformAMD", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFMinNonUniformAMD(Nodes.GroupFMinNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, "OpGroupFMinNonUniformAMD", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupUMinNonUniformAMD(Nodes.GroupUMinNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, "OpGroupUMinNonUniformAMD", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupSMinNonUniformAMD(Nodes.GroupSMinNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, "OpGroupSMinNonUniformAMD", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFMaxNonUniformAMD(Nodes.GroupFMaxNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, "OpGroupFMaxNonUniformAMD", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupUMaxNonUniformAMD(Nodes.GroupUMaxNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, "OpGroupUMaxNonUniformAMD", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupSMaxNonUniformAMD(Nodes.GroupSMaxNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, "OpGroupSMaxNonUniformAMD", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFragmentMaskFetchAMD(Nodes.FragmentMaskFetchAMD node)
        {
            var scriptNode = CreateNode(node, "OpFragmentMaskFetchAMD", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFragmentFetchAMD(Nodes.FragmentFetchAMD node)
        {
            var scriptNode = CreateNode(node, "OpFragmentFetchAMD", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitReadClockKHR(Nodes.ReadClockKHR node)
        {
            var scriptNode = CreateNode(node, "OpReadClockKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleFootprintNV(Nodes.ImageSampleFootprintNV node)
        {
            var scriptNode = CreateNode(node, "OpImageSampleFootprintNV", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformPartitionNV(Nodes.GroupNonUniformPartitionNV node)
        {
            var scriptNode = CreateNode(node, "OpGroupNonUniformPartitionNV", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitWritePackedPrimitiveIndices4x8NV(Nodes.WritePackedPrimitiveIndices4x8NV node)
        {
            var scriptNode = CreateNode(node, "OpWritePackedPrimitiveIndices4x8NV", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitReportIntersectionNV(Nodes.ReportIntersectionNV node)
        {
            var scriptNode = CreateNode(node, "OpReportIntersectionNV", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIgnoreIntersectionNV(Nodes.IgnoreIntersectionNV node)
        {
            var scriptNode = CreateNode(node, "OpIgnoreIntersectionNV", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitTerminateRayNV(Nodes.TerminateRayNV node)
        {
            var scriptNode = CreateNode(node, "OpTerminateRayNV", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitTraceNV(Nodes.TraceNV node)
        {
            var scriptNode = CreateNode(node, "OpTraceNV", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryInitializeKHR(Nodes.RayQueryInitializeKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryInitializeKHR", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryTerminateKHR(Nodes.RayQueryTerminateKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryTerminateKHR", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGenerateIntersectionKHR(Nodes.RayQueryGenerateIntersectionKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGenerateIntersectionKHR", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryConfirmIntersectionKHR(Nodes.RayQueryConfirmIntersectionKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryConfirmIntersectionKHR", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryProceedKHR(Nodes.RayQueryProceedKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryProceedKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionTypeKHR(Nodes.RayQueryGetIntersectionTypeKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionTypeKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetRayTMinKHR(Nodes.RayQueryGetRayTMinKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetRayTMinKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetRayFlagsKHR(Nodes.RayQueryGetRayFlagsKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetRayFlagsKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionTKHR(Nodes.RayQueryGetIntersectionTKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionTKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionInstanceCustomIndexKHR(Nodes.RayQueryGetIntersectionInstanceCustomIndexKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionInstanceCustomIndexKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionInstanceIdKHR(Nodes.RayQueryGetIntersectionInstanceIdKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionInstanceIdKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR(Nodes.RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionGeometryIndexKHR(Nodes.RayQueryGetIntersectionGeometryIndexKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionGeometryIndexKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionPrimitiveIndexKHR(Nodes.RayQueryGetIntersectionPrimitiveIndexKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionPrimitiveIndexKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionBarycentricsKHR(Nodes.RayQueryGetIntersectionBarycentricsKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionBarycentricsKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionFrontFaceKHR(Nodes.RayQueryGetIntersectionFrontFaceKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionFrontFaceKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionCandidateAABBOpaqueKHR(Nodes.RayQueryGetIntersectionCandidateAABBOpaqueKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionCandidateAABBOpaqueKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionObjectRayDirectionKHR(Nodes.RayQueryGetIntersectionObjectRayDirectionKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionObjectRayDirectionKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionObjectRayOriginKHR(Nodes.RayQueryGetIntersectionObjectRayOriginKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionObjectRayOriginKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetWorldRayDirectionKHR(Nodes.RayQueryGetWorldRayDirectionKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetWorldRayDirectionKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetWorldRayOriginKHR(Nodes.RayQueryGetWorldRayOriginKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetWorldRayOriginKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionObjectToWorldKHR(Nodes.RayQueryGetIntersectionObjectToWorldKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionObjectToWorldKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionWorldToObjectKHR(Nodes.RayQueryGetIntersectionWorldToObjectKHR node)
        {
            var scriptNode = CreateNode(node, "OpRayQueryGetIntersectionWorldToObjectKHR", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitExecuteCallableNV(Nodes.ExecuteCallableNV node)
        {
            var scriptNode = CreateNode(node, "OpExecuteCallableNV", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitCooperativeMatrixLoadNV(Nodes.CooperativeMatrixLoadNV node)
        {
            var scriptNode = CreateNode(node, "OpCooperativeMatrixLoadNV", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCooperativeMatrixStoreNV(Nodes.CooperativeMatrixStoreNV node)
        {
            var scriptNode = CreateNode(node, "OpCooperativeMatrixStoreNV", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitCooperativeMatrixMulAddNV(Nodes.CooperativeMatrixMulAddNV node)
        {
            var scriptNode = CreateNode(node, "OpCooperativeMatrixMulAddNV", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCooperativeMatrixLengthNV(Nodes.CooperativeMatrixLengthNV node)
        {
            var scriptNode = CreateNode(node, "OpCooperativeMatrixLengthNV", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBeginInvocationInterlockEXT(Nodes.BeginInvocationInterlockEXT node)
        {
            var scriptNode = CreateNode(node, "OpBeginInvocationInterlockEXT", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitEndInvocationInterlockEXT(Nodes.EndInvocationInterlockEXT node)
        {
            var scriptNode = CreateNode(node, "OpEndInvocationInterlockEXT", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitDemoteToHelperInvocationEXT(Nodes.DemoteToHelperInvocationEXT node)
        {
            var scriptNode = CreateNode(node, "OpDemoteToHelperInvocationEXT", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsHelperInvocationEXT(Nodes.IsHelperInvocationEXT node)
        {
            var scriptNode = CreateNode(node, "OpIsHelperInvocationEXT", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupShuffleINTEL(Nodes.SubgroupShuffleINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupShuffleINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupShuffleDownINTEL(Nodes.SubgroupShuffleDownINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupShuffleDownINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupShuffleUpINTEL(Nodes.SubgroupShuffleUpINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupShuffleUpINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupShuffleXorINTEL(Nodes.SubgroupShuffleXorINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupShuffleXorINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupBlockReadINTEL(Nodes.SubgroupBlockReadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupBlockReadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupBlockWriteINTEL(Nodes.SubgroupBlockWriteINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupBlockWriteINTEL", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupImageBlockReadINTEL(Nodes.SubgroupImageBlockReadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupImageBlockReadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupImageBlockWriteINTEL(Nodes.SubgroupImageBlockWriteINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupImageBlockWriteINTEL", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupImageMediaBlockReadINTEL(Nodes.SubgroupImageMediaBlockReadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupImageMediaBlockReadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupImageMediaBlockWriteINTEL(Nodes.SubgroupImageMediaBlockWriteINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupImageMediaBlockWriteINTEL", true, true, NodeCategory.Function, null);
            scriptNode.ExitPins[0].Connection = new Connection(VisitNode(node.Next), "");
            return scriptNode;
        }

        protected virtual ScriptNode VisitUCountLeadingZerosINTEL(Nodes.UCountLeadingZerosINTEL node)
        {
            var scriptNode = CreateNode(node, "OpUCountLeadingZerosINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUCountTrailingZerosINTEL(Nodes.UCountTrailingZerosINTEL node)
        {
            var scriptNode = CreateNode(node, "OpUCountTrailingZerosINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAbsISubINTEL(Nodes.AbsISubINTEL node)
        {
            var scriptNode = CreateNode(node, "OpAbsISubINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitAbsUSubINTEL(Nodes.AbsUSubINTEL node)
        {
            var scriptNode = CreateNode(node, "OpAbsUSubINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIAddSatINTEL(Nodes.IAddSatINTEL node)
        {
            var scriptNode = CreateNode(node, "OpIAddSatINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUAddSatINTEL(Nodes.UAddSatINTEL node)
        {
            var scriptNode = CreateNode(node, "OpUAddSatINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIAverageINTEL(Nodes.IAverageINTEL node)
        {
            var scriptNode = CreateNode(node, "OpIAverageINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUAverageINTEL(Nodes.UAverageINTEL node)
        {
            var scriptNode = CreateNode(node, "OpUAverageINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIAverageRoundedINTEL(Nodes.IAverageRoundedINTEL node)
        {
            var scriptNode = CreateNode(node, "OpIAverageRoundedINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUAverageRoundedINTEL(Nodes.UAverageRoundedINTEL node)
        {
            var scriptNode = CreateNode(node, "OpUAverageRoundedINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitISubSatINTEL(Nodes.ISubSatINTEL node)
        {
            var scriptNode = CreateNode(node, "OpISubSatINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUSubSatINTEL(Nodes.USubSatINTEL node)
        {
            var scriptNode = CreateNode(node, "OpUSubSatINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIMul32x16INTEL(Nodes.IMul32x16INTEL node)
        {
            var scriptNode = CreateNode(node, "OpIMul32x16INTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUMul32x16INTEL(Nodes.UMul32x16INTEL node)
        {
            var scriptNode = CreateNode(node, "OpUMul32x16INTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDecorateString(Nodes.DecorateString node)
        {
            var scriptNode = CreateNode(node, "OpDecorateString", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemberDecorateString(Nodes.MemberDecorateString node)
        {
            var scriptNode = CreateNode(node, "OpMemberDecorateString", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitVmeImageINTEL(Nodes.VmeImageINTEL node)
        {
            var scriptNode = CreateNode(node, "OpVmeImageINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL(Nodes.SubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultInterShapePenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultInterShapePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultInterShapePenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetInterShapePenaltyINTEL(Nodes.SubgroupAvcMceSetInterShapePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceSetInterShapePenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetInterDirectionPenaltyINTEL(Nodes.SubgroupAvcMceSetInterDirectionPenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceSetInterDirectionPenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL(Nodes.SubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL(Nodes.SubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL(Nodes.SubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL(Nodes.SubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetMotionVectorCostFunctionINTEL(Nodes.SubgroupAvcMceSetMotionVectorCostFunctionINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetAcOnlyHaarINTEL(Nodes.SubgroupAvcMceSetAcOnlyHaarINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceSetAcOnlyHaarINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL(Nodes.SubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL(Nodes.SubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL(Nodes.SubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToImePayloadINTEL(Nodes.SubgroupAvcMceConvertToImePayloadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceConvertToImePayloadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToImeResultINTEL(Nodes.SubgroupAvcMceConvertToImeResultINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceConvertToImeResultINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToRefPayloadINTEL(Nodes.SubgroupAvcMceConvertToRefPayloadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceConvertToRefPayloadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToRefResultINTEL(Nodes.SubgroupAvcMceConvertToRefResultINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceConvertToRefResultINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToSicPayloadINTEL(Nodes.SubgroupAvcMceConvertToSicPayloadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceConvertToSicPayloadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToSicResultINTEL(Nodes.SubgroupAvcMceConvertToSicResultINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceConvertToSicResultINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetMotionVectorsINTEL(Nodes.SubgroupAvcMceGetMotionVectorsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetMotionVectorsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterDistortionsINTEL(Nodes.SubgroupAvcMceGetInterDistortionsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetInterDistortionsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetBestInterDistortionsINTEL(Nodes.SubgroupAvcMceGetBestInterDistortionsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetBestInterDistortionsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterMajorShapeINTEL(Nodes.SubgroupAvcMceGetInterMajorShapeINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetInterMajorShapeINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterMinorShapeINTEL(Nodes.SubgroupAvcMceGetInterMinorShapeINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetInterMinorShapeINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterDirectionsINTEL(Nodes.SubgroupAvcMceGetInterDirectionsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetInterDirectionsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterMotionVectorCountINTEL(Nodes.SubgroupAvcMceGetInterMotionVectorCountINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetInterMotionVectorCountINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterReferenceIdsINTEL(Nodes.SubgroupAvcMceGetInterReferenceIdsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetInterReferenceIdsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL(Nodes.SubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeInitializeINTEL(Nodes.SubgroupAvcImeInitializeINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeInitializeINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetSingleReferenceINTEL(Nodes.SubgroupAvcImeSetSingleReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeSetSingleReferenceINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetDualReferenceINTEL(Nodes.SubgroupAvcImeSetDualReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeSetDualReferenceINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeRefWindowSizeINTEL(Nodes.SubgroupAvcImeRefWindowSizeINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeRefWindowSizeINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeAdjustRefOffsetINTEL(Nodes.SubgroupAvcImeAdjustRefOffsetINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeAdjustRefOffsetINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeConvertToMcePayloadINTEL(Nodes.SubgroupAvcImeConvertToMcePayloadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeConvertToMcePayloadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetMaxMotionVectorCountINTEL(Nodes.SubgroupAvcImeSetMaxMotionVectorCountINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeSetMaxMotionVectorCountINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetUnidirectionalMixDisableINTEL(Nodes.SubgroupAvcImeSetUnidirectionalMixDisableINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeSetUnidirectionalMixDisableINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL(Nodes.SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetWeightedSadINTEL(Nodes.SubgroupAvcImeSetWeightedSadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeSetWeightedSadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithSingleReferenceINTEL(Nodes.SubgroupAvcImeEvaluateWithSingleReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeEvaluateWithSingleReferenceINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithDualReferenceINTEL(Nodes.SubgroupAvcImeEvaluateWithDualReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeEvaluateWithDualReferenceINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL(Nodes.SubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL(Nodes.SubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL(Nodes.SubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL(Nodes.SubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL(Nodes.SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL(Nodes.SubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeConvertToMceResultINTEL(Nodes.SubgroupAvcImeConvertToMceResultINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeConvertToMceResultINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetSingleReferenceStreaminINTEL(Nodes.SubgroupAvcImeGetSingleReferenceStreaminINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetSingleReferenceStreaminINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetDualReferenceStreaminINTEL(Nodes.SubgroupAvcImeGetDualReferenceStreaminINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetDualReferenceStreaminINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeStripSingleReferenceStreamoutINTEL(Nodes.SubgroupAvcImeStripSingleReferenceStreamoutINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeStripSingleReferenceStreamoutINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeStripDualReferenceStreamoutINTEL(Nodes.SubgroupAvcImeStripDualReferenceStreamoutINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeStripDualReferenceStreamoutINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL(Nodes.SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL(Nodes.SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL(Nodes.SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL(Nodes.SubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL(Nodes.SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL(Nodes.SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetBorderReachedINTEL(Nodes.SubgroupAvcImeGetBorderReachedINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetBorderReachedINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetTruncatedSearchIndicationINTEL(Nodes.SubgroupAvcImeGetTruncatedSearchIndicationINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetTruncatedSearchIndicationINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL(Nodes.SubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL(Nodes.SubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL(Nodes.SubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcFmeInitializeINTEL(Nodes.SubgroupAvcFmeInitializeINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcFmeInitializeINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcBmeInitializeINTEL(Nodes.SubgroupAvcBmeInitializeINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcBmeInitializeINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefConvertToMcePayloadINTEL(Nodes.SubgroupAvcRefConvertToMcePayloadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcRefConvertToMcePayloadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefSetBidirectionalMixDisableINTEL(Nodes.SubgroupAvcRefSetBidirectionalMixDisableINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcRefSetBidirectionalMixDisableINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefSetBilinearFilterEnableINTEL(Nodes.SubgroupAvcRefSetBilinearFilterEnableINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcRefSetBilinearFilterEnableINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefEvaluateWithSingleReferenceINTEL(Nodes.SubgroupAvcRefEvaluateWithSingleReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcRefEvaluateWithSingleReferenceINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefEvaluateWithDualReferenceINTEL(Nodes.SubgroupAvcRefEvaluateWithDualReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcRefEvaluateWithDualReferenceINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefEvaluateWithMultiReferenceINTEL(Nodes.SubgroupAvcRefEvaluateWithMultiReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcRefEvaluateWithMultiReferenceINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL(Nodes.SubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefConvertToMceResultINTEL(Nodes.SubgroupAvcRefConvertToMceResultINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcRefConvertToMceResultINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicInitializeINTEL(Nodes.SubgroupAvcSicInitializeINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicInitializeINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicConfigureSkcINTEL(Nodes.SubgroupAvcSicConfigureSkcINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicConfigureSkcINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicConfigureIpeLumaINTEL(Nodes.SubgroupAvcSicConfigureIpeLumaINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicConfigureIpeLumaINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicConfigureIpeLumaChromaINTEL(Nodes.SubgroupAvcSicConfigureIpeLumaChromaINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicConfigureIpeLumaChromaINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetMotionVectorMaskINTEL(Nodes.SubgroupAvcSicGetMotionVectorMaskINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicGetMotionVectorMaskINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicConvertToMcePayloadINTEL(Nodes.SubgroupAvcSicConvertToMcePayloadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicConvertToMcePayloadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetIntraLumaShapePenaltyINTEL(Nodes.SubgroupAvcSicSetIntraLumaShapePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL(Nodes.SubgroupAvcSicSetIntraLumaModeCostFunctionINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL(Nodes.SubgroupAvcSicSetIntraChromaModeCostFunctionINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetBilinearFilterEnableINTEL(Nodes.SubgroupAvcSicSetBilinearFilterEnableINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicSetBilinearFilterEnableINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetSkcForwardTransformEnableINTEL(Nodes.SubgroupAvcSicSetSkcForwardTransformEnableINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicSetSkcForwardTransformEnableINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetBlockBasedRawSkipSadINTEL(Nodes.SubgroupAvcSicSetBlockBasedRawSkipSadINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicSetBlockBasedRawSkipSadINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicEvaluateIpeINTEL(Nodes.SubgroupAvcSicEvaluateIpeINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicEvaluateIpeINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicEvaluateWithSingleReferenceINTEL(Nodes.SubgroupAvcSicEvaluateWithSingleReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicEvaluateWithSingleReferenceINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicEvaluateWithDualReferenceINTEL(Nodes.SubgroupAvcSicEvaluateWithDualReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicEvaluateWithDualReferenceINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicEvaluateWithMultiReferenceINTEL(Nodes.SubgroupAvcSicEvaluateWithMultiReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicEvaluateWithMultiReferenceINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL(Nodes.SubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicConvertToMceResultINTEL(Nodes.SubgroupAvcSicConvertToMceResultINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicConvertToMceResultINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetIpeLumaShapeINTEL(Nodes.SubgroupAvcSicGetIpeLumaShapeINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicGetIpeLumaShapeINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetBestIpeLumaDistortionINTEL(Nodes.SubgroupAvcSicGetBestIpeLumaDistortionINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicGetBestIpeLumaDistortionINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetBestIpeChromaDistortionINTEL(Nodes.SubgroupAvcSicGetBestIpeChromaDistortionINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicGetBestIpeChromaDistortionINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetPackedIpeLumaModesINTEL(Nodes.SubgroupAvcSicGetPackedIpeLumaModesINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicGetPackedIpeLumaModesINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetIpeChromaModeINTEL(Nodes.SubgroupAvcSicGetIpeChromaModeINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicGetIpeChromaModeINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL(Nodes.SubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL(Nodes.SubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetInterRawSadsINTEL(Nodes.SubgroupAvcSicGetInterRawSadsINTEL node)
        {
            var scriptNode = CreateNode(node, "OpSubgroupAvcSicGetInterRawSadsINTEL", false, false, NodeCategory.Function, null);
            return scriptNode;
        }

        protected ScriptNode CreateNode(Node node, string name, bool hasDefaultEnter = false, bool hasDefaultExit = false, NodeCategory category = NodeCategory.Unknown, string value = null)
        {
            var scriptNode = new ScriptNode()
            {
                Name = name,
                Category = category,
                Value = value
            };
            if (hasDefaultEnter)
            {
                scriptNode.EnterPins.Add(new Pin("",null));
            }
            if (hasDefaultExit)
            {
                scriptNode.ExitPins.Add(new PinWithConnection("",null));
            }
            _script.Add(scriptNode);
            _nodeMap.Add(node, scriptNode);
            return scriptNode;
        }
    }
}