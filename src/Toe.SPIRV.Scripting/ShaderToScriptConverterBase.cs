using System;
using System.Collections.Generic;
using System.Globalization;
using Toe.Scripting;
using Toe.SPIRV.Reflection;
using Toe.SPIRV.Reflection.Types;
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
            var scriptNode = CreateNode(node, node.DebugName ?? "OpNop", "OpNop", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitUndef(Nodes.Undef node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUndef", "OpUndef", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSourceContinued(Nodes.SourceContinued node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSourceContinued", "OpSourceContinued", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSource(Nodes.Source node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSource", "OpSource", false, null, NodeCategory.Unknown, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.File), GetTypeName(node.File?.GetResultType()), GetOutputConnection(node.File)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSourceExtension(Nodes.SourceExtension node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSourceExtension", "OpSourceExtension", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitName(Nodes.Name node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpName", "OpName", false, null, NodeCategory.Unknown, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Target), GetTypeName(node.Target?.GetResultType()), GetOutputConnection(node.Target)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemberName(Nodes.MemberName node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpMemberName", "OpMemberName", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitString(Nodes.String node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpString", "OpString", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLine(Nodes.Line node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLine", "OpLine", false, null, NodeCategory.Unknown, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.File), GetTypeName(node.File?.GetResultType()), GetOutputConnection(node.File)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitExtension(Nodes.Extension node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpExtension", "OpExtension", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitExtInstImport(Nodes.ExtInstImport node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpExtInstImport", "OpExtInstImport", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitExtInst(Nodes.ExtInst node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpExtInst", "OpExtInst", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Set), GetTypeName(node.Set?.GetResultType()), GetOutputConnection(node.Set)));
            if (node.Operands != null)
            {
                for (var index = 0; index < node.Operands.Count; index++)
                {
                    var item = node.Operands[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Operands{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemoryModel(Nodes.MemoryModel node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpMemoryModel", "OpMemoryModel", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitEntryPoint(Nodes.EntryPoint node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpEntryPoint", "OpEntryPoint", false, null, NodeCategory.Unknown, null);
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.Value),null, GetExitConnection(node.Value)));
            if (node.Interface != null)
            {
                for (var index = 0; index < node.Interface.Count; index++)
                {
                    var item = node.Interface[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Interface{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitExecutionMode(Nodes.ExecutionMode node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpExecutionMode", "OpExecutionMode", false, null, NodeCategory.Unknown, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.EntryPoint), GetTypeName(node.EntryPoint?.GetResultType()), GetOutputConnection(node.EntryPoint)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCapability(Nodes.Capability node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCapability", "OpCapability", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantTrue(Nodes.ConstantTrue node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConstantTrue", "OpConstantTrue", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantFalse(Nodes.ConstantFalse node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConstantFalse", "OpConstantFalse", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstant(Nodes.Constant node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConstant", "OpConstant", false, GetTypeName(node.ResultType), NodeCategory.Value, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantComposite(Nodes.ConstantComposite node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConstantComposite", "OpConstantComposite", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            if (node.Constituents != null)
            {
                for (var index = 0; index < node.Constituents.Count; index++)
                {
                    var item = node.Constituents[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Constituents{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantSampler(Nodes.ConstantSampler node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConstantSampler", "OpConstantSampler", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantNull(Nodes.ConstantNull node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConstantNull", "OpConstantNull", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSpecConstantTrue(Nodes.SpecConstantTrue node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSpecConstantTrue", "OpSpecConstantTrue", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSpecConstantFalse(Nodes.SpecConstantFalse node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSpecConstantFalse", "OpSpecConstantFalse", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSpecConstant(Nodes.SpecConstant node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSpecConstant", "OpSpecConstant", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSpecConstantComposite(Nodes.SpecConstantComposite node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSpecConstantComposite", "OpSpecConstantComposite", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            if (node.Constituents != null)
            {
                for (var index = 0; index < node.Constituents.Count; index++)
                {
                    var item = node.Constituents[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Constituents{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitSpecConstantOp(Nodes.SpecConstantOp node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSpecConstantOp", "OpSpecConstantOp", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFunction(Nodes.Function node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFunction", "OpFunction", false, GetTypeName(node.ResultType), NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFunctionParameter(Nodes.FunctionParameter node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFunctionParameter", "OpFunctionParameter", false, GetTypeName(node.ResultType), NodeCategory.Parameter, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitFunctionEnd(Nodes.FunctionEnd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFunctionEnd", "OpFunctionEnd", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFunctionCall(Nodes.FunctionCall node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFunctionCall", "OpFunctionCall", true, GetTypeName(node.ResultType), NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Function), GetTypeName(node.Function?.GetResultType()), GetOutputConnection(node.Function)));
            if (node.Arguments != null)
            {
                for (var index = 0; index < node.Arguments.Count; index++)
                {
                    var item = node.Arguments[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Arguments{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitVariable(Nodes.Variable node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpVariable", "OpVariable", false, GetTypeName(node.ResultType), NodeCategory.Parameter, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Initializer), GetTypeName(node.Initializer?.GetResultType()), GetOutputConnection(node.Initializer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageTexelPointer(Nodes.ImageTexelPointer node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageTexelPointer", "OpImageTexelPointer", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Sample), GetTypeName(node.Sample?.GetResultType()), GetOutputConnection(node.Sample)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitLoad(Nodes.Load node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLoad", "OpLoad", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitStore(Nodes.Store node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpStore", "OpStore", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Object), GetTypeName(node.Object?.GetResultType()), GetOutputConnection(node.Object)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCopyMemory(Nodes.CopyMemory node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCopyMemory", "OpCopyMemory", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Target), GetTypeName(node.Target?.GetResultType()), GetOutputConnection(node.Target)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Source), GetTypeName(node.Source?.GetResultType()), GetOutputConnection(node.Source)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCopyMemorySized(Nodes.CopyMemorySized node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCopyMemorySized", "OpCopyMemorySized", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Target), GetTypeName(node.Target?.GetResultType()), GetOutputConnection(node.Target)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Source), GetTypeName(node.Source?.GetResultType()), GetOutputConnection(node.Source)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Size), GetTypeName(node.Size?.GetResultType()), GetOutputConnection(node.Size)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAccessChain(Nodes.AccessChain node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAccessChain", "OpAccessChain", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            if (node.Indexes != null)
            {
                for (var index = 0; index < node.Indexes.Count; index++)
                {
                    var item = node.Indexes[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Indexes{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitInBoundsAccessChain(Nodes.InBoundsAccessChain node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpInBoundsAccessChain", "OpInBoundsAccessChain", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            if (node.Indexes != null)
            {
                for (var index = 0; index < node.Indexes.Count; index++)
                {
                    var item = node.Indexes[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Indexes{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitPtrAccessChain(Nodes.PtrAccessChain node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpPtrAccessChain", "OpPtrAccessChain", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Element), GetTypeName(node.Element?.GetResultType()), GetOutputConnection(node.Element)));
            if (node.Indexes != null)
            {
                for (var index = 0; index < node.Indexes.Count; index++)
                {
                    var item = node.Indexes[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Indexes{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitArrayLength(Nodes.ArrayLength node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpArrayLength", "OpArrayLength", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Structure), GetTypeName(node.Structure?.GetResultType()), GetOutputConnection(node.Structure)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGenericPtrMemSemantics(Nodes.GenericPtrMemSemantics node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGenericPtrMemSemantics", "OpGenericPtrMemSemantics", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitInBoundsPtrAccessChain(Nodes.InBoundsPtrAccessChain node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpInBoundsPtrAccessChain", "OpInBoundsPtrAccessChain", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Element), GetTypeName(node.Element?.GetResultType()), GetOutputConnection(node.Element)));
            if (node.Indexes != null)
            {
                for (var index = 0; index < node.Indexes.Count; index++)
                {
                    var item = node.Indexes[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Indexes{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitDecorate(Nodes.Decorate node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDecorate", "OpDecorate", false, null, NodeCategory.Unknown, null);
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.Target),null, GetExitConnection(node.Target)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemberDecorate(Nodes.MemberDecorate node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpMemberDecorate", "OpMemberDecorate", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitDecorationGroup(Nodes.DecorationGroup node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDecorationGroup", "OpDecorationGroup", false, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupDecorate(Nodes.GroupDecorate node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupDecorate", "OpGroupDecorate", false, null, NodeCategory.Unknown, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.DecorationGroup), GetTypeName(node.DecorationGroup?.GetResultType()), GetOutputConnection(node.DecorationGroup)));
            if (node.Targets != null)
            {
                for (var index = 0; index < node.Targets.Count; index++)
                {
                    var item = node.Targets[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Targets{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupMemberDecorate(Nodes.GroupMemberDecorate node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupMemberDecorate", "OpGroupMemberDecorate", false, null, NodeCategory.Unknown, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.DecorationGroup), GetTypeName(node.DecorationGroup?.GetResultType()), GetOutputConnection(node.DecorationGroup)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitVectorExtractDynamic(Nodes.VectorExtractDynamic node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpVectorExtractDynamic", "OpVectorExtractDynamic", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector), GetTypeName(node.Vector?.GetResultType()), GetOutputConnection(node.Vector)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Index), GetTypeName(node.Index?.GetResultType()), GetOutputConnection(node.Index)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitVectorInsertDynamic(Nodes.VectorInsertDynamic node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpVectorInsertDynamic", "OpVectorInsertDynamic", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector), GetTypeName(node.Vector?.GetResultType()), GetOutputConnection(node.Vector)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Component), GetTypeName(node.Component?.GetResultType()), GetOutputConnection(node.Component)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Index), GetTypeName(node.Index?.GetResultType()), GetOutputConnection(node.Index)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitVectorShuffle(Nodes.VectorShuffle node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpVectorShuffle", "OpVectorShuffle", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector1), GetTypeName(node.Vector1?.GetResultType()), GetOutputConnection(node.Vector1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector2), GetTypeName(node.Vector2?.GetResultType()), GetOutputConnection(node.Vector2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCompositeConstruct(Nodes.CompositeConstruct node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCompositeConstruct", "OpCompositeConstruct", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            if (node.Constituents != null)
            {
                for (var index = 0; index < node.Constituents.Count; index++)
                {
                    var item = node.Constituents[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "Constituents{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitCompositeExtract(Nodes.CompositeExtract node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCompositeExtract", "OpCompositeExtract", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Composite), GetTypeName(node.Composite?.GetResultType()), GetOutputConnection(node.Composite)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCompositeInsert(Nodes.CompositeInsert node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCompositeInsert", "OpCompositeInsert", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Object), GetTypeName(node.Object?.GetResultType()), GetOutputConnection(node.Object)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Composite), GetTypeName(node.Composite?.GetResultType()), GetOutputConnection(node.Composite)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCopyObject(Nodes.CopyObject node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCopyObject", "OpCopyObject", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand), GetTypeName(node.Operand?.GetResultType()), GetOutputConnection(node.Operand)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitTranspose(Nodes.Transpose node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpTranspose", "OpTranspose", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Matrix), GetTypeName(node.Matrix?.GetResultType()), GetOutputConnection(node.Matrix)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSampledImage(Nodes.SampledImage node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSampledImage", "OpSampledImage", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Sampler), GetTypeName(node.Sampler?.GetResultType()), GetOutputConnection(node.Sampler)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleImplicitLod(Nodes.ImageSampleImplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSampleImplicitLod", "OpImageSampleImplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleExplicitLod(Nodes.ImageSampleExplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSampleExplicitLod", "OpImageSampleExplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleDrefImplicitLod(Nodes.ImageSampleDrefImplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSampleDrefImplicitLod", "OpImageSampleDrefImplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.D_ref), GetTypeName(node.D_ref?.GetResultType()), GetOutputConnection(node.D_ref)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleDrefExplicitLod(Nodes.ImageSampleDrefExplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSampleDrefExplicitLod", "OpImageSampleDrefExplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.D_ref), GetTypeName(node.D_ref?.GetResultType()), GetOutputConnection(node.D_ref)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleProjImplicitLod(Nodes.ImageSampleProjImplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSampleProjImplicitLod", "OpImageSampleProjImplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleProjExplicitLod(Nodes.ImageSampleProjExplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSampleProjExplicitLod", "OpImageSampleProjExplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleProjDrefImplicitLod(Nodes.ImageSampleProjDrefImplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSampleProjDrefImplicitLod", "OpImageSampleProjDrefImplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.D_ref), GetTypeName(node.D_ref?.GetResultType()), GetOutputConnection(node.D_ref)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleProjDrefExplicitLod(Nodes.ImageSampleProjDrefExplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSampleProjDrefExplicitLod", "OpImageSampleProjDrefExplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.D_ref), GetTypeName(node.D_ref?.GetResultType()), GetOutputConnection(node.D_ref)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageFetch(Nodes.ImageFetch node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageFetch", "OpImageFetch", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageGather(Nodes.ImageGather node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageGather", "OpImageGather", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Component), GetTypeName(node.Component?.GetResultType()), GetOutputConnection(node.Component)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageDrefGather(Nodes.ImageDrefGather node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageDrefGather", "OpImageDrefGather", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.D_ref), GetTypeName(node.D_ref?.GetResultType()), GetOutputConnection(node.D_ref)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageRead(Nodes.ImageRead node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageRead", "OpImageRead", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageWrite(Nodes.ImageWrite node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageWrite", "OpImageWrite", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Texel), GetTypeName(node.Texel?.GetResultType()), GetOutputConnection(node.Texel)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImage(Nodes.Image node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImage", "OpImage", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQueryFormat(Nodes.ImageQueryFormat node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageQueryFormat", "OpImageQueryFormat", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQueryOrder(Nodes.ImageQueryOrder node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageQueryOrder", "OpImageQueryOrder", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQuerySizeLod(Nodes.ImageQuerySizeLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageQuerySizeLod", "OpImageQuerySizeLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LevelofDetail), GetTypeName(node.LevelofDetail?.GetResultType()), GetOutputConnection(node.LevelofDetail)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQuerySize(Nodes.ImageQuerySize node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageQuerySize", "OpImageQuerySize", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQueryLod(Nodes.ImageQueryLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageQueryLod", "OpImageQueryLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQueryLevels(Nodes.ImageQueryLevels node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageQueryLevels", "OpImageQueryLevels", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageQuerySamples(Nodes.ImageQuerySamples node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageQuerySamples", "OpImageQuerySamples", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertFToU(Nodes.ConvertFToU node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConvertFToU", "OpConvertFToU", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FloatValue), GetTypeName(node.FloatValue?.GetResultType()), GetOutputConnection(node.FloatValue)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertFToS(Nodes.ConvertFToS node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConvertFToS", "OpConvertFToS", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FloatValue), GetTypeName(node.FloatValue?.GetResultType()), GetOutputConnection(node.FloatValue)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertSToF(Nodes.ConvertSToF node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConvertSToF", "OpConvertSToF", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SignedValue), GetTypeName(node.SignedValue?.GetResultType()), GetOutputConnection(node.SignedValue)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertUToF(Nodes.ConvertUToF node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConvertUToF", "OpConvertUToF", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UnsignedValue), GetTypeName(node.UnsignedValue?.GetResultType()), GetOutputConnection(node.UnsignedValue)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUConvert(Nodes.UConvert node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUConvert", "OpUConvert", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UnsignedValue), GetTypeName(node.UnsignedValue?.GetResultType()), GetOutputConnection(node.UnsignedValue)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSConvert(Nodes.SConvert node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSConvert", "OpSConvert", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SignedValue), GetTypeName(node.SignedValue?.GetResultType()), GetOutputConnection(node.SignedValue)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFConvert(Nodes.FConvert node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFConvert", "OpFConvert", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FloatValue), GetTypeName(node.FloatValue?.GetResultType()), GetOutputConnection(node.FloatValue)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitQuantizeToF16(Nodes.QuantizeToF16 node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpQuantizeToF16", "OpQuantizeToF16", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertPtrToU(Nodes.ConvertPtrToU node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConvertPtrToU", "OpConvertPtrToU", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSatConvertSToU(Nodes.SatConvertSToU node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSatConvertSToU", "OpSatConvertSToU", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SignedValue), GetTypeName(node.SignedValue?.GetResultType()), GetOutputConnection(node.SignedValue)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSatConvertUToS(Nodes.SatConvertUToS node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSatConvertUToS", "OpSatConvertUToS", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UnsignedValue), GetTypeName(node.UnsignedValue?.GetResultType()), GetOutputConnection(node.UnsignedValue)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitConvertUToPtr(Nodes.ConvertUToPtr node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConvertUToPtr", "OpConvertUToPtr", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.IntegerValue), GetTypeName(node.IntegerValue?.GetResultType()), GetOutputConnection(node.IntegerValue)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitPtrCastToGeneric(Nodes.PtrCastToGeneric node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpPtrCastToGeneric", "OpPtrCastToGeneric", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGenericCastToPtr(Nodes.GenericCastToPtr node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGenericCastToPtr", "OpGenericCastToPtr", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGenericCastToPtrExplicit(Nodes.GenericCastToPtrExplicit node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGenericCastToPtrExplicit", "OpGenericCastToPtrExplicit", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitcast(Nodes.Bitcast node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBitcast", "OpBitcast", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand), GetTypeName(node.Operand?.GetResultType()), GetOutputConnection(node.Operand)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSNegate(Nodes.SNegate node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSNegate", "OpSNegate", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand), GetTypeName(node.Operand?.GetResultType()), GetOutputConnection(node.Operand)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFNegate(Nodes.FNegate node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFNegate", "OpFNegate", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand), GetTypeName(node.Operand?.GetResultType()), GetOutputConnection(node.Operand)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIAdd(Nodes.IAdd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIAdd", "OpIAdd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFAdd(Nodes.FAdd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFAdd", "OpFAdd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitISub(Nodes.ISub node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpISub", "OpISub", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFSub(Nodes.FSub node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFSub", "OpFSub", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIMul(Nodes.IMul node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIMul", "OpIMul", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFMul(Nodes.FMul node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFMul", "OpFMul", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUDiv(Nodes.UDiv node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUDiv", "OpUDiv", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSDiv(Nodes.SDiv node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSDiv", "OpSDiv", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFDiv(Nodes.FDiv node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFDiv", "OpFDiv", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUMod(Nodes.UMod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUMod", "OpUMod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSRem(Nodes.SRem node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSRem", "OpSRem", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSMod(Nodes.SMod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSMod", "OpSMod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFRem(Nodes.FRem node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFRem", "OpFRem", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFMod(Nodes.FMod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFMod", "OpFMod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitVectorTimesScalar(Nodes.VectorTimesScalar node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpVectorTimesScalar", "OpVectorTimesScalar", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector), GetTypeName(node.Vector?.GetResultType()), GetOutputConnection(node.Vector)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Scalar), GetTypeName(node.Scalar?.GetResultType()), GetOutputConnection(node.Scalar)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitMatrixTimesScalar(Nodes.MatrixTimesScalar node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpMatrixTimesScalar", "OpMatrixTimesScalar", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Matrix), GetTypeName(node.Matrix?.GetResultType()), GetOutputConnection(node.Matrix)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Scalar), GetTypeName(node.Scalar?.GetResultType()), GetOutputConnection(node.Scalar)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitVectorTimesMatrix(Nodes.VectorTimesMatrix node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpVectorTimesMatrix", "OpVectorTimesMatrix", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector), GetTypeName(node.Vector?.GetResultType()), GetOutputConnection(node.Vector)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Matrix), GetTypeName(node.Matrix?.GetResultType()), GetOutputConnection(node.Matrix)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitMatrixTimesVector(Nodes.MatrixTimesVector node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpMatrixTimesVector", "OpMatrixTimesVector", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Matrix), GetTypeName(node.Matrix?.GetResultType()), GetOutputConnection(node.Matrix)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector), GetTypeName(node.Vector?.GetResultType()), GetOutputConnection(node.Vector)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitMatrixTimesMatrix(Nodes.MatrixTimesMatrix node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpMatrixTimesMatrix", "OpMatrixTimesMatrix", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LeftMatrix), GetTypeName(node.LeftMatrix?.GetResultType()), GetOutputConnection(node.LeftMatrix)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RightMatrix), GetTypeName(node.RightMatrix?.GetResultType()), GetOutputConnection(node.RightMatrix)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitOuterProduct(Nodes.OuterProduct node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpOuterProduct", "OpOuterProduct", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector1), GetTypeName(node.Vector1?.GetResultType()), GetOutputConnection(node.Vector1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector2), GetTypeName(node.Vector2?.GetResultType()), GetOutputConnection(node.Vector2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitDot(Nodes.Dot node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDot", "OpDot", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector1), GetTypeName(node.Vector1?.GetResultType()), GetOutputConnection(node.Vector1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector2), GetTypeName(node.Vector2?.GetResultType()), GetOutputConnection(node.Vector2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIAddCarry(Nodes.IAddCarry node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIAddCarry", "OpIAddCarry", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitISubBorrow(Nodes.ISubBorrow node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpISubBorrow", "OpISubBorrow", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUMulExtended(Nodes.UMulExtended node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUMulExtended", "OpUMulExtended", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSMulExtended(Nodes.SMulExtended node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSMulExtended", "OpSMulExtended", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAny(Nodes.Any node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAny", "OpAny", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector), GetTypeName(node.Vector?.GetResultType()), GetOutputConnection(node.Vector)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAll(Nodes.All node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAll", "OpAll", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Vector), GetTypeName(node.Vector?.GetResultType()), GetOutputConnection(node.Vector)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsNan(Nodes.IsNan node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIsNan", "OpIsNan", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.x), GetTypeName(node.x?.GetResultType()), GetOutputConnection(node.x)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsInf(Nodes.IsInf node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIsInf", "OpIsInf", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.x), GetTypeName(node.x?.GetResultType()), GetOutputConnection(node.x)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsFinite(Nodes.IsFinite node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIsFinite", "OpIsFinite", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.x), GetTypeName(node.x?.GetResultType()), GetOutputConnection(node.x)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsNormal(Nodes.IsNormal node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIsNormal", "OpIsNormal", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.x), GetTypeName(node.x?.GetResultType()), GetOutputConnection(node.x)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSignBitSet(Nodes.SignBitSet node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSignBitSet", "OpSignBitSet", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.x), GetTypeName(node.x?.GetResultType()), GetOutputConnection(node.x)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitLessOrGreater(Nodes.LessOrGreater node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLessOrGreater", "OpLessOrGreater", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.x), GetTypeName(node.x?.GetResultType()), GetOutputConnection(node.x)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.y), GetTypeName(node.y?.GetResultType()), GetOutputConnection(node.y)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitOrdered(Nodes.Ordered node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpOrdered", "OpOrdered", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.x), GetTypeName(node.x?.GetResultType()), GetOutputConnection(node.x)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.y), GetTypeName(node.y?.GetResultType()), GetOutputConnection(node.y)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUnordered(Nodes.Unordered node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUnordered", "OpUnordered", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.x), GetTypeName(node.x?.GetResultType()), GetOutputConnection(node.x)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.y), GetTypeName(node.y?.GetResultType()), GetOutputConnection(node.y)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitLogicalEqual(Nodes.LogicalEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLogicalEqual", "OpLogicalEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitLogicalNotEqual(Nodes.LogicalNotEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLogicalNotEqual", "OpLogicalNotEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitLogicalOr(Nodes.LogicalOr node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLogicalOr", "OpLogicalOr", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitLogicalAnd(Nodes.LogicalAnd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLogicalAnd", "OpLogicalAnd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitLogicalNot(Nodes.LogicalNot node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLogicalNot", "OpLogicalNot", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand), GetTypeName(node.Operand?.GetResultType()), GetOutputConnection(node.Operand)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSelect(Nodes.Select node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSelect", "OpSelect", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Condition), GetTypeName(node.Condition?.GetResultType()), GetOutputConnection(node.Condition)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Object1), GetTypeName(node.Object1?.GetResultType()), GetOutputConnection(node.Object1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Object2), GetTypeName(node.Object2?.GetResultType()), GetOutputConnection(node.Object2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIEqual(Nodes.IEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIEqual", "OpIEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitINotEqual(Nodes.INotEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpINotEqual", "OpINotEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUGreaterThan(Nodes.UGreaterThan node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUGreaterThan", "OpUGreaterThan", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSGreaterThan(Nodes.SGreaterThan node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSGreaterThan", "OpSGreaterThan", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUGreaterThanEqual(Nodes.UGreaterThanEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUGreaterThanEqual", "OpUGreaterThanEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSGreaterThanEqual(Nodes.SGreaterThanEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSGreaterThanEqual", "OpSGreaterThanEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitULessThan(Nodes.ULessThan node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpULessThan", "OpULessThan", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSLessThan(Nodes.SLessThan node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSLessThan", "OpSLessThan", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitULessThanEqual(Nodes.ULessThanEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpULessThanEqual", "OpULessThanEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSLessThanEqual(Nodes.SLessThanEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSLessThanEqual", "OpSLessThanEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdEqual(Nodes.FOrdEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFOrdEqual", "OpFOrdEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordEqual(Nodes.FUnordEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFUnordEqual", "OpFUnordEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdNotEqual(Nodes.FOrdNotEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFOrdNotEqual", "OpFOrdNotEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordNotEqual(Nodes.FUnordNotEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFUnordNotEqual", "OpFUnordNotEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdLessThan(Nodes.FOrdLessThan node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFOrdLessThan", "OpFOrdLessThan", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordLessThan(Nodes.FUnordLessThan node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFUnordLessThan", "OpFUnordLessThan", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdGreaterThan(Nodes.FOrdGreaterThan node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFOrdGreaterThan", "OpFOrdGreaterThan", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordGreaterThan(Nodes.FUnordGreaterThan node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFUnordGreaterThan", "OpFUnordGreaterThan", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdLessThanEqual(Nodes.FOrdLessThanEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFOrdLessThanEqual", "OpFOrdLessThanEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordLessThanEqual(Nodes.FUnordLessThanEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFUnordLessThanEqual", "OpFUnordLessThanEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFOrdGreaterThanEqual(Nodes.FOrdGreaterThanEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFOrdGreaterThanEqual", "OpFOrdGreaterThanEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFUnordGreaterThanEqual(Nodes.FUnordGreaterThanEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFUnordGreaterThanEqual", "OpFUnordGreaterThanEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitShiftRightLogical(Nodes.ShiftRightLogical node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpShiftRightLogical", "OpShiftRightLogical", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Shift), GetTypeName(node.Shift?.GetResultType()), GetOutputConnection(node.Shift)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitShiftRightArithmetic(Nodes.ShiftRightArithmetic node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpShiftRightArithmetic", "OpShiftRightArithmetic", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Shift), GetTypeName(node.Shift?.GetResultType()), GetOutputConnection(node.Shift)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitShiftLeftLogical(Nodes.ShiftLeftLogical node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpShiftLeftLogical", "OpShiftLeftLogical", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Shift), GetTypeName(node.Shift?.GetResultType()), GetOutputConnection(node.Shift)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitwiseOr(Nodes.BitwiseOr node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBitwiseOr", "OpBitwiseOr", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitwiseXor(Nodes.BitwiseXor node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBitwiseXor", "OpBitwiseXor", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitwiseAnd(Nodes.BitwiseAnd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBitwiseAnd", "OpBitwiseAnd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitNot(Nodes.Not node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpNot", "OpNot", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand), GetTypeName(node.Operand?.GetResultType()), GetOutputConnection(node.Operand)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitFieldInsert(Nodes.BitFieldInsert node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBitFieldInsert", "OpBitFieldInsert", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Insert), GetTypeName(node.Insert?.GetResultType()), GetOutputConnection(node.Insert)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Offset), GetTypeName(node.Offset?.GetResultType()), GetOutputConnection(node.Offset)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Count), GetTypeName(node.Count?.GetResultType()), GetOutputConnection(node.Count)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitFieldSExtract(Nodes.BitFieldSExtract node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBitFieldSExtract", "OpBitFieldSExtract", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Offset), GetTypeName(node.Offset?.GetResultType()), GetOutputConnection(node.Offset)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Count), GetTypeName(node.Count?.GetResultType()), GetOutputConnection(node.Count)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitFieldUExtract(Nodes.BitFieldUExtract node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBitFieldUExtract", "OpBitFieldUExtract", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Offset), GetTypeName(node.Offset?.GetResultType()), GetOutputConnection(node.Offset)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Count), GetTypeName(node.Count?.GetResultType()), GetOutputConnection(node.Count)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitReverse(Nodes.BitReverse node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBitReverse", "OpBitReverse", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBitCount(Nodes.BitCount node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBitCount", "OpBitCount", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Base), GetTypeName(node.Base?.GetResultType()), GetOutputConnection(node.Base)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdx(Nodes.DPdx node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDPdx", "OpDPdx", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.P), GetTypeName(node.P?.GetResultType()), GetOutputConnection(node.P)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdy(Nodes.DPdy node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDPdy", "OpDPdy", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.P), GetTypeName(node.P?.GetResultType()), GetOutputConnection(node.P)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFwidth(Nodes.Fwidth node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFwidth", "OpFwidth", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.P), GetTypeName(node.P?.GetResultType()), GetOutputConnection(node.P)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdxFine(Nodes.DPdxFine node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDPdxFine", "OpDPdxFine", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.P), GetTypeName(node.P?.GetResultType()), GetOutputConnection(node.P)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdyFine(Nodes.DPdyFine node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDPdyFine", "OpDPdyFine", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.P), GetTypeName(node.P?.GetResultType()), GetOutputConnection(node.P)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFwidthFine(Nodes.FwidthFine node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFwidthFine", "OpFwidthFine", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.P), GetTypeName(node.P?.GetResultType()), GetOutputConnection(node.P)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdxCoarse(Nodes.DPdxCoarse node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDPdxCoarse", "OpDPdxCoarse", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.P), GetTypeName(node.P?.GetResultType()), GetOutputConnection(node.P)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitDPdyCoarse(Nodes.DPdyCoarse node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDPdyCoarse", "OpDPdyCoarse", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.P), GetTypeName(node.P?.GetResultType()), GetOutputConnection(node.P)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFwidthCoarse(Nodes.FwidthCoarse node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFwidthCoarse", "OpFwidthCoarse", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.P), GetTypeName(node.P?.GetResultType()), GetOutputConnection(node.P)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitEmitVertex(Nodes.EmitVertex node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpEmitVertex", "OpEmitVertex", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitEndPrimitive(Nodes.EndPrimitive node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpEndPrimitive", "OpEndPrimitive", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitEmitStreamVertex(Nodes.EmitStreamVertex node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpEmitStreamVertex", "OpEmitStreamVertex", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Stream), GetTypeName(node.Stream?.GetResultType()), GetOutputConnection(node.Stream)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitEndStreamPrimitive(Nodes.EndStreamPrimitive node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpEndStreamPrimitive", "OpEndStreamPrimitive", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Stream), GetTypeName(node.Stream?.GetResultType()), GetOutputConnection(node.Stream)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitControlBarrier(Nodes.ControlBarrier node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpControlBarrier", "OpControlBarrier", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemoryBarrier(Nodes.MemoryBarrier node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpMemoryBarrier", "OpMemoryBarrier", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicLoad(Nodes.AtomicLoad node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicLoad", "OpAtomicLoad", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicStore(Nodes.AtomicStore node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicStore", "OpAtomicStore", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicExchange(Nodes.AtomicExchange node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicExchange", "OpAtomicExchange", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicCompareExchange(Nodes.AtomicCompareExchange node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicCompareExchange", "OpAtomicCompareExchange", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Comparator), GetTypeName(node.Comparator?.GetResultType()), GetOutputConnection(node.Comparator)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicCompareExchangeWeak(Nodes.AtomicCompareExchangeWeak node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicCompareExchangeWeak", "OpAtomicCompareExchangeWeak", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Comparator), GetTypeName(node.Comparator?.GetResultType()), GetOutputConnection(node.Comparator)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicIIncrement(Nodes.AtomicIIncrement node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicIIncrement", "OpAtomicIIncrement", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicIDecrement(Nodes.AtomicIDecrement node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicIDecrement", "OpAtomicIDecrement", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicIAdd(Nodes.AtomicIAdd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicIAdd", "OpAtomicIAdd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicISub(Nodes.AtomicISub node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicISub", "OpAtomicISub", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicSMin(Nodes.AtomicSMin node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicSMin", "OpAtomicSMin", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicUMin(Nodes.AtomicUMin node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicUMin", "OpAtomicUMin", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicSMax(Nodes.AtomicSMax node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicSMax", "OpAtomicSMax", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicUMax(Nodes.AtomicUMax node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicUMax", "OpAtomicUMax", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicAnd(Nodes.AtomicAnd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicAnd", "OpAtomicAnd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicOr(Nodes.AtomicOr node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicOr", "OpAtomicOr", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicXor(Nodes.AtomicXor node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicXor", "OpAtomicXor", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitPhi(Nodes.Phi node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpPhi", "OpPhi", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLoopMerge(Nodes.LoopMerge node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLoopMerge", "OpLoopMerge", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.MergeBlock),null, GetExitConnection(node.MergeBlock)));
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.ContinueTarget),null, GetExitConnection(node.ContinueTarget)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSelectionMerge(Nodes.SelectionMerge node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSelectionMerge", "OpSelectionMerge", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.MergeBlock),null, GetExitConnection(node.MergeBlock)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitLabel(Nodes.Label node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLabel", "OpLabel", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBranch(Nodes.Branch node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBranch", "OpBranch", true, null, NodeCategory.Unknown, null);
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.TargetLabel),null, GetExitConnection(node.TargetLabel)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBranchConditional(Nodes.BranchConditional node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBranchConditional", "OpBranchConditional", true, null, NodeCategory.Unknown, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Condition), GetTypeName(node.Condition?.GetResultType()), GetOutputConnection(node.Condition)));
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.TrueLabel),null, GetExitConnection(node.TrueLabel)));
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.FalseLabel),null, GetExitConnection(node.FalseLabel)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSwitch(Nodes.Switch node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSwitch", "OpSwitch", true, null, NodeCategory.Unknown, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Selector), GetTypeName(node.Selector?.GetResultType()), GetOutputConnection(node.Selector)));
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.Default),null, GetExitConnection(node.Default)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitKill(Nodes.Kill node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpKill", "OpKill", true, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitReturn(Nodes.Return node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpReturn", "OpReturn", true, null, NodeCategory.Result, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitReturnValue(Nodes.ReturnValue node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpReturnValue", "OpReturnValue", true, null, NodeCategory.Result, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUnreachable(Nodes.Unreachable node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUnreachable", "OpUnreachable", true, null, NodeCategory.Unknown, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitLifetimeStart(Nodes.LifetimeStart node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLifetimeStart", "OpLifetimeStart", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitLifetimeStop(Nodes.LifetimeStop node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpLifetimeStop", "OpLifetimeStop", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupAsyncCopy(Nodes.GroupAsyncCopy node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupAsyncCopy", "OpGroupAsyncCopy", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Destination), GetTypeName(node.Destination?.GetResultType()), GetOutputConnection(node.Destination)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Source), GetTypeName(node.Source?.GetResultType()), GetOutputConnection(node.Source)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NumElements), GetTypeName(node.NumElements?.GetResultType()), GetOutputConnection(node.NumElements)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Stride), GetTypeName(node.Stride?.GetResultType()), GetOutputConnection(node.Stride)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Event), GetTypeName(node.Event?.GetResultType()), GetOutputConnection(node.Event)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupWaitEvents(Nodes.GroupWaitEvents node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupWaitEvents", "OpGroupWaitEvents", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NumEvents), GetTypeName(node.NumEvents?.GetResultType()), GetOutputConnection(node.NumEvents)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.EventsList), GetTypeName(node.EventsList?.GetResultType()), GetOutputConnection(node.EventsList)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupAll(Nodes.GroupAll node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupAll", "OpGroupAll", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Predicate), GetTypeName(node.Predicate?.GetResultType()), GetOutputConnection(node.Predicate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupAny(Nodes.GroupAny node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupAny", "OpGroupAny", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Predicate), GetTypeName(node.Predicate?.GetResultType()), GetOutputConnection(node.Predicate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupBroadcast(Nodes.GroupBroadcast node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupBroadcast", "OpGroupBroadcast", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LocalId), GetTypeName(node.LocalId?.GetResultType()), GetOutputConnection(node.LocalId)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupIAdd(Nodes.GroupIAdd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupIAdd", "OpGroupIAdd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFAdd(Nodes.GroupFAdd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupFAdd", "OpGroupFAdd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFMin(Nodes.GroupFMin node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupFMin", "OpGroupFMin", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupUMin(Nodes.GroupUMin node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupUMin", "OpGroupUMin", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupSMin(Nodes.GroupSMin node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupSMin", "OpGroupSMin", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFMax(Nodes.GroupFMax node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupFMax", "OpGroupFMax", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupUMax(Nodes.GroupUMax node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupUMax", "OpGroupUMax", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupSMax(Nodes.GroupSMax node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupSMax", "OpGroupSMax", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitReadPipe(Nodes.ReadPipe node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpReadPipe", "OpReadPipe", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitWritePipe(Nodes.WritePipe node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpWritePipe", "OpWritePipe", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitReservedReadPipe(Nodes.ReservedReadPipe node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpReservedReadPipe", "OpReservedReadPipe", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ReserveId), GetTypeName(node.ReserveId?.GetResultType()), GetOutputConnection(node.ReserveId)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Index), GetTypeName(node.Index?.GetResultType()), GetOutputConnection(node.Index)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitReservedWritePipe(Nodes.ReservedWritePipe node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpReservedWritePipe", "OpReservedWritePipe", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ReserveId), GetTypeName(node.ReserveId?.GetResultType()), GetOutputConnection(node.ReserveId)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Index), GetTypeName(node.Index?.GetResultType()), GetOutputConnection(node.Index)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitReserveReadPipePackets(Nodes.ReserveReadPipePackets node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpReserveReadPipePackets", "OpReserveReadPipePackets", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NumPackets), GetTypeName(node.NumPackets?.GetResultType()), GetOutputConnection(node.NumPackets)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitReserveWritePipePackets(Nodes.ReserveWritePipePackets node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpReserveWritePipePackets", "OpReserveWritePipePackets", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NumPackets), GetTypeName(node.NumPackets?.GetResultType()), GetOutputConnection(node.NumPackets)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCommitReadPipe(Nodes.CommitReadPipe node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCommitReadPipe", "OpCommitReadPipe", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ReserveId), GetTypeName(node.ReserveId?.GetResultType()), GetOutputConnection(node.ReserveId)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCommitWritePipe(Nodes.CommitWritePipe node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCommitWritePipe", "OpCommitWritePipe", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ReserveId), GetTypeName(node.ReserveId?.GetResultType()), GetOutputConnection(node.ReserveId)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsValidReserveId(Nodes.IsValidReserveId node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIsValidReserveId", "OpIsValidReserveId", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ReserveId), GetTypeName(node.ReserveId?.GetResultType()), GetOutputConnection(node.ReserveId)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetNumPipePackets(Nodes.GetNumPipePackets node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGetNumPipePackets", "OpGetNumPipePackets", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetMaxPipePackets(Nodes.GetMaxPipePackets node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGetMaxPipePackets", "OpGetMaxPipePackets", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupReserveReadPipePackets(Nodes.GroupReserveReadPipePackets node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupReserveReadPipePackets", "OpGroupReserveReadPipePackets", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NumPackets), GetTypeName(node.NumPackets?.GetResultType()), GetOutputConnection(node.NumPackets)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupReserveWritePipePackets(Nodes.GroupReserveWritePipePackets node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupReserveWritePipePackets", "OpGroupReserveWritePipePackets", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NumPackets), GetTypeName(node.NumPackets?.GetResultType()), GetOutputConnection(node.NumPackets)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupCommitReadPipe(Nodes.GroupCommitReadPipe node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupCommitReadPipe", "OpGroupCommitReadPipe", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ReserveId), GetTypeName(node.ReserveId?.GetResultType()), GetOutputConnection(node.ReserveId)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupCommitWritePipe(Nodes.GroupCommitWritePipe node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupCommitWritePipe", "OpGroupCommitWritePipe", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pipe), GetTypeName(node.Pipe?.GetResultType()), GetOutputConnection(node.Pipe)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ReserveId), GetTypeName(node.ReserveId?.GetResultType()), GetOutputConnection(node.ReserveId)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketSize), GetTypeName(node.PacketSize?.GetResultType()), GetOutputConnection(node.PacketSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PacketAlignment), GetTypeName(node.PacketAlignment?.GetResultType()), GetOutputConnection(node.PacketAlignment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitEnqueueMarker(Nodes.EnqueueMarker node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpEnqueueMarker", "OpEnqueueMarker", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Queue), GetTypeName(node.Queue?.GetResultType()), GetOutputConnection(node.Queue)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NumEvents), GetTypeName(node.NumEvents?.GetResultType()), GetOutputConnection(node.NumEvents)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.WaitEvents), GetTypeName(node.WaitEvents?.GetResultType()), GetOutputConnection(node.WaitEvents)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RetEvent), GetTypeName(node.RetEvent?.GetResultType()), GetOutputConnection(node.RetEvent)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitEnqueueKernel(Nodes.EnqueueKernel node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpEnqueueKernel", "OpEnqueueKernel", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Queue), GetTypeName(node.Queue?.GetResultType()), GetOutputConnection(node.Queue)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Flags), GetTypeName(node.Flags?.GetResultType()), GetOutputConnection(node.Flags)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NDRange), GetTypeName(node.NDRange?.GetResultType()), GetOutputConnection(node.NDRange)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NumEvents), GetTypeName(node.NumEvents?.GetResultType()), GetOutputConnection(node.NumEvents)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.WaitEvents), GetTypeName(node.WaitEvents?.GetResultType()), GetOutputConnection(node.WaitEvents)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RetEvent), GetTypeName(node.RetEvent?.GetResultType()), GetOutputConnection(node.RetEvent)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Invoke), GetTypeName(node.Invoke?.GetResultType()), GetOutputConnection(node.Invoke)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Param), GetTypeName(node.Param?.GetResultType()), GetOutputConnection(node.Param)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamSize), GetTypeName(node.ParamSize?.GetResultType()), GetOutputConnection(node.ParamSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamAlign), GetTypeName(node.ParamAlign?.GetResultType()), GetOutputConnection(node.ParamAlign)));
            if (node.LocalSize != null)
            {
                for (var index = 0; index < node.LocalSize.Count; index++)
                {
                    var item = node.LocalSize[index];
                    scriptNode.InputPins.Add(new PinWithConnection(string.Format(CultureInfo.InvariantCulture, "LocalSize{0}", index), GetTypeName(item?.GetResultType()), GetOutputConnection(item)));
                }
            }
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelNDrangeSubGroupCount(Nodes.GetKernelNDrangeSubGroupCount node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGetKernelNDrangeSubGroupCount", "OpGetKernelNDrangeSubGroupCount", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NDRange), GetTypeName(node.NDRange?.GetResultType()), GetOutputConnection(node.NDRange)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Invoke), GetTypeName(node.Invoke?.GetResultType()), GetOutputConnection(node.Invoke)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Param), GetTypeName(node.Param?.GetResultType()), GetOutputConnection(node.Param)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamSize), GetTypeName(node.ParamSize?.GetResultType()), GetOutputConnection(node.ParamSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamAlign), GetTypeName(node.ParamAlign?.GetResultType()), GetOutputConnection(node.ParamAlign)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelNDrangeMaxSubGroupSize(Nodes.GetKernelNDrangeMaxSubGroupSize node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGetKernelNDrangeMaxSubGroupSize", "OpGetKernelNDrangeMaxSubGroupSize", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NDRange), GetTypeName(node.NDRange?.GetResultType()), GetOutputConnection(node.NDRange)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Invoke), GetTypeName(node.Invoke?.GetResultType()), GetOutputConnection(node.Invoke)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Param), GetTypeName(node.Param?.GetResultType()), GetOutputConnection(node.Param)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamSize), GetTypeName(node.ParamSize?.GetResultType()), GetOutputConnection(node.ParamSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamAlign), GetTypeName(node.ParamAlign?.GetResultType()), GetOutputConnection(node.ParamAlign)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelWorkGroupSize(Nodes.GetKernelWorkGroupSize node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGetKernelWorkGroupSize", "OpGetKernelWorkGroupSize", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Invoke), GetTypeName(node.Invoke?.GetResultType()), GetOutputConnection(node.Invoke)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Param), GetTypeName(node.Param?.GetResultType()), GetOutputConnection(node.Param)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamSize), GetTypeName(node.ParamSize?.GetResultType()), GetOutputConnection(node.ParamSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamAlign), GetTypeName(node.ParamAlign?.GetResultType()), GetOutputConnection(node.ParamAlign)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelPreferredWorkGroupSizeMultiple(Nodes.GetKernelPreferredWorkGroupSizeMultiple node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGetKernelPreferredWorkGroupSizeMultiple", "OpGetKernelPreferredWorkGroupSizeMultiple", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Invoke), GetTypeName(node.Invoke?.GetResultType()), GetOutputConnection(node.Invoke)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Param), GetTypeName(node.Param?.GetResultType()), GetOutputConnection(node.Param)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamSize), GetTypeName(node.ParamSize?.GetResultType()), GetOutputConnection(node.ParamSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamAlign), GetTypeName(node.ParamAlign?.GetResultType()), GetOutputConnection(node.ParamAlign)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRetainEvent(Nodes.RetainEvent node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRetainEvent", "OpRetainEvent", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Event), GetTypeName(node.Event?.GetResultType()), GetOutputConnection(node.Event)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitReleaseEvent(Nodes.ReleaseEvent node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpReleaseEvent", "OpReleaseEvent", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Event), GetTypeName(node.Event?.GetResultType()), GetOutputConnection(node.Event)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCreateUserEvent(Nodes.CreateUserEvent node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCreateUserEvent", "OpCreateUserEvent", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsValidEvent(Nodes.IsValidEvent node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIsValidEvent", "OpIsValidEvent", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Event), GetTypeName(node.Event?.GetResultType()), GetOutputConnection(node.Event)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSetUserEventStatus(Nodes.SetUserEventStatus node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSetUserEventStatus", "OpSetUserEventStatus", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Event), GetTypeName(node.Event?.GetResultType()), GetOutputConnection(node.Event)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Status), GetTypeName(node.Status?.GetResultType()), GetOutputConnection(node.Status)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCaptureEventProfilingInfo(Nodes.CaptureEventProfilingInfo node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCaptureEventProfilingInfo", "OpCaptureEventProfilingInfo", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Event), GetTypeName(node.Event?.GetResultType()), GetOutputConnection(node.Event)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ProfilingInfo), GetTypeName(node.ProfilingInfo?.GetResultType()), GetOutputConnection(node.ProfilingInfo)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetDefaultQueue(Nodes.GetDefaultQueue node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGetDefaultQueue", "OpGetDefaultQueue", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitBuildNDRange(Nodes.BuildNDRange node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBuildNDRange", "OpBuildNDRange", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.GlobalWorkSize), GetTypeName(node.GlobalWorkSize?.GetResultType()), GetOutputConnection(node.GlobalWorkSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LocalWorkSize), GetTypeName(node.LocalWorkSize?.GetResultType()), GetOutputConnection(node.LocalWorkSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.GlobalWorkOffset), GetTypeName(node.GlobalWorkOffset?.GetResultType()), GetOutputConnection(node.GlobalWorkOffset)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleImplicitLod(Nodes.ImageSparseSampleImplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseSampleImplicitLod", "OpImageSparseSampleImplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleExplicitLod(Nodes.ImageSparseSampleExplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseSampleExplicitLod", "OpImageSparseSampleExplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleDrefImplicitLod(Nodes.ImageSparseSampleDrefImplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseSampleDrefImplicitLod", "OpImageSparseSampleDrefImplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.D_ref), GetTypeName(node.D_ref?.GetResultType()), GetOutputConnection(node.D_ref)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleDrefExplicitLod(Nodes.ImageSparseSampleDrefExplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseSampleDrefExplicitLod", "OpImageSparseSampleDrefExplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.D_ref), GetTypeName(node.D_ref?.GetResultType()), GetOutputConnection(node.D_ref)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleProjImplicitLod(Nodes.ImageSparseSampleProjImplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseSampleProjImplicitLod", "OpImageSparseSampleProjImplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleProjExplicitLod(Nodes.ImageSparseSampleProjExplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseSampleProjExplicitLod", "OpImageSparseSampleProjExplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleProjDrefImplicitLod(Nodes.ImageSparseSampleProjDrefImplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseSampleProjDrefImplicitLod", "OpImageSparseSampleProjDrefImplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.D_ref), GetTypeName(node.D_ref?.GetResultType()), GetOutputConnection(node.D_ref)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseSampleProjDrefExplicitLod(Nodes.ImageSparseSampleProjDrefExplicitLod node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseSampleProjDrefExplicitLod", "OpImageSparseSampleProjDrefExplicitLod", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.D_ref), GetTypeName(node.D_ref?.GetResultType()), GetOutputConnection(node.D_ref)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseFetch(Nodes.ImageSparseFetch node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseFetch", "OpImageSparseFetch", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseGather(Nodes.ImageSparseGather node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseGather", "OpImageSparseGather", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Component), GetTypeName(node.Component?.GetResultType()), GetOutputConnection(node.Component)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseDrefGather(Nodes.ImageSparseDrefGather node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseDrefGather", "OpImageSparseDrefGather", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.D_ref), GetTypeName(node.D_ref?.GetResultType()), GetOutputConnection(node.D_ref)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseTexelsResident(Nodes.ImageSparseTexelsResident node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseTexelsResident", "OpImageSparseTexelsResident", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ResidentCode), GetTypeName(node.ResidentCode?.GetResultType()), GetOutputConnection(node.ResidentCode)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitNoLine(Nodes.NoLine node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpNoLine", "OpNoLine", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicFlagTestAndSet(Nodes.AtomicFlagTestAndSet node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicFlagTestAndSet", "OpAtomicFlagTestAndSet", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAtomicFlagClear(Nodes.AtomicFlagClear node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAtomicFlagClear", "OpAtomicFlagClear", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSparseRead(Nodes.ImageSparseRead node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSparseRead", "OpImageSparseRead", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSizeOf(Nodes.SizeOf node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSizeOf", "OpSizeOf", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitConstantPipeStorage(Nodes.ConstantPipeStorage node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpConstantPipeStorage", "OpConstantPipeStorage", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitCreatePipeFromPipeStorage(Nodes.CreatePipeFromPipeStorage node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCreatePipeFromPipeStorage", "OpCreatePipeFromPipeStorage", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PipeStorage), GetTypeName(node.PipeStorage?.GetResultType()), GetOutputConnection(node.PipeStorage)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelLocalSizeForSubgroupCount(Nodes.GetKernelLocalSizeForSubgroupCount node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGetKernelLocalSizeForSubgroupCount", "OpGetKernelLocalSizeForSubgroupCount", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SubgroupCount), GetTypeName(node.SubgroupCount?.GetResultType()), GetOutputConnection(node.SubgroupCount)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Invoke), GetTypeName(node.Invoke?.GetResultType()), GetOutputConnection(node.Invoke)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Param), GetTypeName(node.Param?.GetResultType()), GetOutputConnection(node.Param)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamSize), GetTypeName(node.ParamSize?.GetResultType()), GetOutputConnection(node.ParamSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamAlign), GetTypeName(node.ParamAlign?.GetResultType()), GetOutputConnection(node.ParamAlign)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGetKernelMaxNumSubgroups(Nodes.GetKernelMaxNumSubgroups node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGetKernelMaxNumSubgroups", "OpGetKernelMaxNumSubgroups", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Invoke), GetTypeName(node.Invoke?.GetResultType()), GetOutputConnection(node.Invoke)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Param), GetTypeName(node.Param?.GetResultType()), GetOutputConnection(node.Param)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamSize), GetTypeName(node.ParamSize?.GetResultType()), GetOutputConnection(node.ParamSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ParamAlign), GetTypeName(node.ParamAlign?.GetResultType()), GetOutputConnection(node.ParamAlign)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitNamedBarrierInitialize(Nodes.NamedBarrierInitialize node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpNamedBarrierInitialize", "OpNamedBarrierInitialize", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SubgroupCount), GetTypeName(node.SubgroupCount?.GetResultType()), GetOutputConnection(node.SubgroupCount)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemoryNamedBarrier(Nodes.MemoryNamedBarrier node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpMemoryNamedBarrier", "OpMemoryNamedBarrier", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.NamedBarrier), GetTypeName(node.NamedBarrier?.GetResultType()), GetOutputConnection(node.NamedBarrier)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitModuleProcessed(Nodes.ModuleProcessed node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpModuleProcessed", "OpModuleProcessed", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitExecutionModeId(Nodes.ExecutionModeId node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpExecutionModeId", "OpExecutionModeId", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.EntryPoint), GetTypeName(node.EntryPoint?.GetResultType()), GetOutputConnection(node.EntryPoint)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitDecorateId(Nodes.DecorateId node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDecorateId", "OpDecorateId", false, null, NodeCategory.Unknown, null);
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.Target),null, GetExitConnection(node.Target)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformElect(Nodes.GroupNonUniformElect node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformElect", "OpGroupNonUniformElect", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformAll(Nodes.GroupNonUniformAll node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformAll", "OpGroupNonUniformAll", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Predicate), GetTypeName(node.Predicate?.GetResultType()), GetOutputConnection(node.Predicate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformAny(Nodes.GroupNonUniformAny node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformAny", "OpGroupNonUniformAny", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Predicate), GetTypeName(node.Predicate?.GetResultType()), GetOutputConnection(node.Predicate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformAllEqual(Nodes.GroupNonUniformAllEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformAllEqual", "OpGroupNonUniformAllEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBroadcast(Nodes.GroupNonUniformBroadcast node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformBroadcast", "OpGroupNonUniformBroadcast", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Id), GetTypeName(node.Id?.GetResultType()), GetOutputConnection(node.Id)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBroadcastFirst(Nodes.GroupNonUniformBroadcastFirst node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformBroadcastFirst", "OpGroupNonUniformBroadcastFirst", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBallot(Nodes.GroupNonUniformBallot node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformBallot", "OpGroupNonUniformBallot", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Predicate), GetTypeName(node.Predicate?.GetResultType()), GetOutputConnection(node.Predicate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformInverseBallot(Nodes.GroupNonUniformInverseBallot node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformInverseBallot", "OpGroupNonUniformInverseBallot", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBallotBitExtract(Nodes.GroupNonUniformBallotBitExtract node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformBallotBitExtract", "OpGroupNonUniformBallotBitExtract", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Index), GetTypeName(node.Index?.GetResultType()), GetOutputConnection(node.Index)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBallotBitCount(Nodes.GroupNonUniformBallotBitCount node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformBallotBitCount", "OpGroupNonUniformBallotBitCount", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBallotFindLSB(Nodes.GroupNonUniformBallotFindLSB node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformBallotFindLSB", "OpGroupNonUniformBallotFindLSB", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBallotFindMSB(Nodes.GroupNonUniformBallotFindMSB node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformBallotFindMSB", "OpGroupNonUniformBallotFindMSB", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformShuffle(Nodes.GroupNonUniformShuffle node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformShuffle", "OpGroupNonUniformShuffle", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Id), GetTypeName(node.Id?.GetResultType()), GetOutputConnection(node.Id)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformShuffleXor(Nodes.GroupNonUniformShuffleXor node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformShuffleXor", "OpGroupNonUniformShuffleXor", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Mask), GetTypeName(node.Mask?.GetResultType()), GetOutputConnection(node.Mask)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformShuffleUp(Nodes.GroupNonUniformShuffleUp node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformShuffleUp", "OpGroupNonUniformShuffleUp", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Delta), GetTypeName(node.Delta?.GetResultType()), GetOutputConnection(node.Delta)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformShuffleDown(Nodes.GroupNonUniformShuffleDown node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformShuffleDown", "OpGroupNonUniformShuffleDown", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Delta), GetTypeName(node.Delta?.GetResultType()), GetOutputConnection(node.Delta)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformIAdd(Nodes.GroupNonUniformIAdd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformIAdd", "OpGroupNonUniformIAdd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformFAdd(Nodes.GroupNonUniformFAdd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformFAdd", "OpGroupNonUniformFAdd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformIMul(Nodes.GroupNonUniformIMul node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformIMul", "OpGroupNonUniformIMul", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformFMul(Nodes.GroupNonUniformFMul node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformFMul", "OpGroupNonUniformFMul", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformSMin(Nodes.GroupNonUniformSMin node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformSMin", "OpGroupNonUniformSMin", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformUMin(Nodes.GroupNonUniformUMin node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformUMin", "OpGroupNonUniformUMin", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformFMin(Nodes.GroupNonUniformFMin node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformFMin", "OpGroupNonUniformFMin", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformSMax(Nodes.GroupNonUniformSMax node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformSMax", "OpGroupNonUniformSMax", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformUMax(Nodes.GroupNonUniformUMax node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformUMax", "OpGroupNonUniformUMax", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformFMax(Nodes.GroupNonUniformFMax node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformFMax", "OpGroupNonUniformFMax", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBitwiseAnd(Nodes.GroupNonUniformBitwiseAnd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformBitwiseAnd", "OpGroupNonUniformBitwiseAnd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBitwiseOr(Nodes.GroupNonUniformBitwiseOr node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformBitwiseOr", "OpGroupNonUniformBitwiseOr", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformBitwiseXor(Nodes.GroupNonUniformBitwiseXor node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformBitwiseXor", "OpGroupNonUniformBitwiseXor", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformLogicalAnd(Nodes.GroupNonUniformLogicalAnd node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformLogicalAnd", "OpGroupNonUniformLogicalAnd", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformLogicalOr(Nodes.GroupNonUniformLogicalOr node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformLogicalOr", "OpGroupNonUniformLogicalOr", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformLogicalXor(Nodes.GroupNonUniformLogicalXor node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformLogicalXor", "OpGroupNonUniformLogicalXor", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ClusterSize), GetTypeName(node.ClusterSize?.GetResultType()), GetOutputConnection(node.ClusterSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformQuadBroadcast(Nodes.GroupNonUniformQuadBroadcast node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformQuadBroadcast", "OpGroupNonUniformQuadBroadcast", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Index), GetTypeName(node.Index?.GetResultType()), GetOutputConnection(node.Index)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformQuadSwap(Nodes.GroupNonUniformQuadSwap node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformQuadSwap", "OpGroupNonUniformQuadSwap", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Direction), GetTypeName(node.Direction?.GetResultType()), GetOutputConnection(node.Direction)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCopyLogical(Nodes.CopyLogical node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCopyLogical", "OpCopyLogical", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand), GetTypeName(node.Operand?.GetResultType()), GetOutputConnection(node.Operand)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitPtrEqual(Nodes.PtrEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpPtrEqual", "OpPtrEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitPtrNotEqual(Nodes.PtrNotEqual node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpPtrNotEqual", "OpPtrNotEqual", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitPtrDiff(Nodes.PtrDiff node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpPtrDiff", "OpPtrDiff", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupBallotKHR(Nodes.SubgroupBallotKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupBallotKHR", "OpSubgroupBallotKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Predicate), GetTypeName(node.Predicate?.GetResultType()), GetOutputConnection(node.Predicate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupFirstInvocationKHR(Nodes.SubgroupFirstInvocationKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupFirstInvocationKHR", "OpSubgroupFirstInvocationKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAllKHR(Nodes.SubgroupAllKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAllKHR", "OpSubgroupAllKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Predicate), GetTypeName(node.Predicate?.GetResultType()), GetOutputConnection(node.Predicate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAnyKHR(Nodes.SubgroupAnyKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAnyKHR", "OpSubgroupAnyKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Predicate), GetTypeName(node.Predicate?.GetResultType()), GetOutputConnection(node.Predicate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAllEqualKHR(Nodes.SubgroupAllEqualKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAllEqualKHR", "OpSubgroupAllEqualKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Predicate), GetTypeName(node.Predicate?.GetResultType()), GetOutputConnection(node.Predicate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupReadInvocationKHR(Nodes.SubgroupReadInvocationKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupReadInvocationKHR", "OpSubgroupReadInvocationKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Index), GetTypeName(node.Index?.GetResultType()), GetOutputConnection(node.Index)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupIAddNonUniformAMD(Nodes.GroupIAddNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupIAddNonUniformAMD", "OpGroupIAddNonUniformAMD", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFAddNonUniformAMD(Nodes.GroupFAddNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupFAddNonUniformAMD", "OpGroupFAddNonUniformAMD", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFMinNonUniformAMD(Nodes.GroupFMinNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupFMinNonUniformAMD", "OpGroupFMinNonUniformAMD", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupUMinNonUniformAMD(Nodes.GroupUMinNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupUMinNonUniformAMD", "OpGroupUMinNonUniformAMD", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupSMinNonUniformAMD(Nodes.GroupSMinNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupSMinNonUniformAMD", "OpGroupSMinNonUniformAMD", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupFMaxNonUniformAMD(Nodes.GroupFMaxNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupFMaxNonUniformAMD", "OpGroupFMaxNonUniformAMD", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupUMaxNonUniformAMD(Nodes.GroupUMaxNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupUMaxNonUniformAMD", "OpGroupUMaxNonUniformAMD", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupSMaxNonUniformAMD(Nodes.GroupSMaxNonUniformAMD node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupSMaxNonUniformAMD", "OpGroupSMaxNonUniformAMD", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.X), GetTypeName(node.X?.GetResultType()), GetOutputConnection(node.X)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFragmentMaskFetchAMD(Nodes.FragmentMaskFetchAMD node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFragmentMaskFetchAMD", "OpFragmentMaskFetchAMD", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitFragmentFetchAMD(Nodes.FragmentFetchAMD node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpFragmentFetchAMD", "OpFragmentFetchAMD", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FragmentIndex), GetTypeName(node.FragmentIndex?.GetResultType()), GetOutputConnection(node.FragmentIndex)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitReadClockKHR(Nodes.ReadClockKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpReadClockKHR", "OpReadClockKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitImageSampleFootprintNV(Nodes.ImageSampleFootprintNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpImageSampleFootprintNV", "OpImageSampleFootprintNV", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SampledImage), GetTypeName(node.SampledImage?.GetResultType()), GetOutputConnection(node.SampledImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Granularity), GetTypeName(node.Granularity?.GetResultType()), GetOutputConnection(node.Granularity)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coarse), GetTypeName(node.Coarse?.GetResultType()), GetOutputConnection(node.Coarse)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitGroupNonUniformPartitionNV(Nodes.GroupNonUniformPartitionNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpGroupNonUniformPartitionNV", "OpGroupNonUniformPartitionNV", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitWritePackedPrimitiveIndices4x8NV(Nodes.WritePackedPrimitiveIndices4x8NV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpWritePackedPrimitiveIndices4x8NV", "OpWritePackedPrimitiveIndices4x8NV", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.IndexOffset), GetTypeName(node.IndexOffset?.GetResultType()), GetOutputConnection(node.IndexOffset)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedIndices), GetTypeName(node.PackedIndices?.GetResultType()), GetOutputConnection(node.PackedIndices)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitReportIntersectionNV(Nodes.ReportIntersectionNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpReportIntersectionNV", "OpReportIntersectionNV", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Hit), GetTypeName(node.Hit?.GetResultType()), GetOutputConnection(node.Hit)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.HitKind), GetTypeName(node.HitKind?.GetResultType()), GetOutputConnection(node.HitKind)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIgnoreIntersectionNV(Nodes.IgnoreIntersectionNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIgnoreIntersectionNV", "OpIgnoreIntersectionNV", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitTerminateRayNV(Nodes.TerminateRayNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpTerminateRayNV", "OpTerminateRayNV", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitTraceNV(Nodes.TraceNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpTraceNV", "OpTraceNV", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Accel), GetTypeName(node.Accel?.GetResultType()), GetOutputConnection(node.Accel)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayFlags), GetTypeName(node.RayFlags?.GetResultType()), GetOutputConnection(node.RayFlags)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.CullMask), GetTypeName(node.CullMask?.GetResultType()), GetOutputConnection(node.CullMask)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SBTOffset), GetTypeName(node.SBTOffset?.GetResultType()), GetOutputConnection(node.SBTOffset)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SBTStride), GetTypeName(node.SBTStride?.GetResultType()), GetOutputConnection(node.SBTStride)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MissIndex), GetTypeName(node.MissIndex?.GetResultType()), GetOutputConnection(node.MissIndex)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayOrigin), GetTypeName(node.RayOrigin?.GetResultType()), GetOutputConnection(node.RayOrigin)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayTmin), GetTypeName(node.RayTmin?.GetResultType()), GetOutputConnection(node.RayTmin)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayDirection), GetTypeName(node.RayDirection?.GetResultType()), GetOutputConnection(node.RayDirection)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayTmax), GetTypeName(node.RayTmax?.GetResultType()), GetOutputConnection(node.RayTmax)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PayloadId), GetTypeName(node.PayloadId?.GetResultType()), GetOutputConnection(node.PayloadId)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryInitializeKHR(Nodes.RayQueryInitializeKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryInitializeKHR", "OpRayQueryInitializeKHR", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Accel), GetTypeName(node.Accel?.GetResultType()), GetOutputConnection(node.Accel)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayFlags), GetTypeName(node.RayFlags?.GetResultType()), GetOutputConnection(node.RayFlags)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.CullMask), GetTypeName(node.CullMask?.GetResultType()), GetOutputConnection(node.CullMask)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayOrigin), GetTypeName(node.RayOrigin?.GetResultType()), GetOutputConnection(node.RayOrigin)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayTMin), GetTypeName(node.RayTMin?.GetResultType()), GetOutputConnection(node.RayTMin)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayDirection), GetTypeName(node.RayDirection?.GetResultType()), GetOutputConnection(node.RayDirection)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayTMax), GetTypeName(node.RayTMax?.GetResultType()), GetOutputConnection(node.RayTMax)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryTerminateKHR(Nodes.RayQueryTerminateKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryTerminateKHR", "OpRayQueryTerminateKHR", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGenerateIntersectionKHR(Nodes.RayQueryGenerateIntersectionKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGenerateIntersectionKHR", "OpRayQueryGenerateIntersectionKHR", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.HitT), GetTypeName(node.HitT?.GetResultType()), GetOutputConnection(node.HitT)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryConfirmIntersectionKHR(Nodes.RayQueryConfirmIntersectionKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryConfirmIntersectionKHR", "OpRayQueryConfirmIntersectionKHR", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryProceedKHR(Nodes.RayQueryProceedKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryProceedKHR", "OpRayQueryProceedKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionTypeKHR(Nodes.RayQueryGetIntersectionTypeKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionTypeKHR", "OpRayQueryGetIntersectionTypeKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetRayTMinKHR(Nodes.RayQueryGetRayTMinKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetRayTMinKHR", "OpRayQueryGetRayTMinKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetRayFlagsKHR(Nodes.RayQueryGetRayFlagsKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetRayFlagsKHR", "OpRayQueryGetRayFlagsKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionTKHR(Nodes.RayQueryGetIntersectionTKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionTKHR", "OpRayQueryGetIntersectionTKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionInstanceCustomIndexKHR(Nodes.RayQueryGetIntersectionInstanceCustomIndexKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionInstanceCustomIndexKHR", "OpRayQueryGetIntersectionInstanceCustomIndexKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionInstanceIdKHR(Nodes.RayQueryGetIntersectionInstanceIdKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionInstanceIdKHR", "OpRayQueryGetIntersectionInstanceIdKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR(Nodes.RayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR", "OpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionGeometryIndexKHR(Nodes.RayQueryGetIntersectionGeometryIndexKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionGeometryIndexKHR", "OpRayQueryGetIntersectionGeometryIndexKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionPrimitiveIndexKHR(Nodes.RayQueryGetIntersectionPrimitiveIndexKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionPrimitiveIndexKHR", "OpRayQueryGetIntersectionPrimitiveIndexKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionBarycentricsKHR(Nodes.RayQueryGetIntersectionBarycentricsKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionBarycentricsKHR", "OpRayQueryGetIntersectionBarycentricsKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionFrontFaceKHR(Nodes.RayQueryGetIntersectionFrontFaceKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionFrontFaceKHR", "OpRayQueryGetIntersectionFrontFaceKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionCandidateAABBOpaqueKHR(Nodes.RayQueryGetIntersectionCandidateAABBOpaqueKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionCandidateAABBOpaqueKHR", "OpRayQueryGetIntersectionCandidateAABBOpaqueKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionObjectRayDirectionKHR(Nodes.RayQueryGetIntersectionObjectRayDirectionKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionObjectRayDirectionKHR", "OpRayQueryGetIntersectionObjectRayDirectionKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionObjectRayOriginKHR(Nodes.RayQueryGetIntersectionObjectRayOriginKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionObjectRayOriginKHR", "OpRayQueryGetIntersectionObjectRayOriginKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetWorldRayDirectionKHR(Nodes.RayQueryGetWorldRayDirectionKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetWorldRayDirectionKHR", "OpRayQueryGetWorldRayDirectionKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetWorldRayOriginKHR(Nodes.RayQueryGetWorldRayOriginKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetWorldRayOriginKHR", "OpRayQueryGetWorldRayOriginKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionObjectToWorldKHR(Nodes.RayQueryGetIntersectionObjectToWorldKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionObjectToWorldKHR", "OpRayQueryGetIntersectionObjectToWorldKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitRayQueryGetIntersectionWorldToObjectKHR(Nodes.RayQueryGetIntersectionWorldToObjectKHR node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpRayQueryGetIntersectionWorldToObjectKHR", "OpRayQueryGetIntersectionWorldToObjectKHR", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RayQuery), GetTypeName(node.RayQuery?.GetResultType()), GetOutputConnection(node.RayQuery)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Intersection), GetTypeName(node.Intersection?.GetResultType()), GetOutputConnection(node.Intersection)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitExecuteCallableNV(Nodes.ExecuteCallableNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpExecuteCallableNV", "OpExecuteCallableNV", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SBTIndex), GetTypeName(node.SBTIndex?.GetResultType()), GetOutputConnection(node.SBTIndex)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.CallableDataId), GetTypeName(node.CallableDataId?.GetResultType()), GetOutputConnection(node.CallableDataId)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCooperativeMatrixLoadNV(Nodes.CooperativeMatrixLoadNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCooperativeMatrixLoadNV", "OpCooperativeMatrixLoadNV", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Stride), GetTypeName(node.Stride?.GetResultType()), GetOutputConnection(node.Stride)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ColumnMajor), GetTypeName(node.ColumnMajor?.GetResultType()), GetOutputConnection(node.ColumnMajor)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCooperativeMatrixStoreNV(Nodes.CooperativeMatrixStoreNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCooperativeMatrixStoreNV", "OpCooperativeMatrixStoreNV", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Pointer), GetTypeName(node.Pointer?.GetResultType()), GetOutputConnection(node.Pointer)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Object), GetTypeName(node.Object?.GetResultType()), GetOutputConnection(node.Object)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Stride), GetTypeName(node.Stride?.GetResultType()), GetOutputConnection(node.Stride)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ColumnMajor), GetTypeName(node.ColumnMajor?.GetResultType()), GetOutputConnection(node.ColumnMajor)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCooperativeMatrixMulAddNV(Nodes.CooperativeMatrixMulAddNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCooperativeMatrixMulAddNV", "OpCooperativeMatrixMulAddNV", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.A), GetTypeName(node.A?.GetResultType()), GetOutputConnection(node.A)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.B), GetTypeName(node.B?.GetResultType()), GetOutputConnection(node.B)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.C), GetTypeName(node.C?.GetResultType()), GetOutputConnection(node.C)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitCooperativeMatrixLengthNV(Nodes.CooperativeMatrixLengthNV node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpCooperativeMatrixLengthNV", "OpCooperativeMatrixLengthNV", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Type), GetTypeName(node.Type?.GetResultType()), GetOutputConnection(node.Type)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitBeginInvocationInterlockEXT(Nodes.BeginInvocationInterlockEXT node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpBeginInvocationInterlockEXT", "OpBeginInvocationInterlockEXT", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitEndInvocationInterlockEXT(Nodes.EndInvocationInterlockEXT node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpEndInvocationInterlockEXT", "OpEndInvocationInterlockEXT", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitDemoteToHelperInvocationEXT(Nodes.DemoteToHelperInvocationEXT node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDemoteToHelperInvocationEXT", "OpDemoteToHelperInvocationEXT", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIsHelperInvocationEXT(Nodes.IsHelperInvocationEXT node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIsHelperInvocationEXT", "OpIsHelperInvocationEXT", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupShuffleINTEL(Nodes.SubgroupShuffleINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupShuffleINTEL", "OpSubgroupShuffleINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Data), GetTypeName(node.Data?.GetResultType()), GetOutputConnection(node.Data)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.InvocationId), GetTypeName(node.InvocationId?.GetResultType()), GetOutputConnection(node.InvocationId)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupShuffleDownINTEL(Nodes.SubgroupShuffleDownINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupShuffleDownINTEL", "OpSubgroupShuffleDownINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Current), GetTypeName(node.Current?.GetResultType()), GetOutputConnection(node.Current)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Next), GetTypeName(node.Next?.GetResultType()), GetOutputConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Delta), GetTypeName(node.Delta?.GetResultType()), GetOutputConnection(node.Delta)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupShuffleUpINTEL(Nodes.SubgroupShuffleUpINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupShuffleUpINTEL", "OpSubgroupShuffleUpINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Previous), GetTypeName(node.Previous?.GetResultType()), GetOutputConnection(node.Previous)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Current), GetTypeName(node.Current?.GetResultType()), GetOutputConnection(node.Current)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Delta), GetTypeName(node.Delta?.GetResultType()), GetOutputConnection(node.Delta)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupShuffleXorINTEL(Nodes.SubgroupShuffleXorINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupShuffleXorINTEL", "OpSubgroupShuffleXorINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Data), GetTypeName(node.Data?.GetResultType()), GetOutputConnection(node.Data)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Value), GetTypeName(node.Value?.GetResultType()), GetOutputConnection(node.Value)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupBlockReadINTEL(Nodes.SubgroupBlockReadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupBlockReadINTEL", "OpSubgroupBlockReadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Ptr), GetTypeName(node.Ptr?.GetResultType()), GetOutputConnection(node.Ptr)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupBlockWriteINTEL(Nodes.SubgroupBlockWriteINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupBlockWriteINTEL", "OpSubgroupBlockWriteINTEL", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Ptr), GetTypeName(node.Ptr?.GetResultType()), GetOutputConnection(node.Ptr)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Data), GetTypeName(node.Data?.GetResultType()), GetOutputConnection(node.Data)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupImageBlockReadINTEL(Nodes.SubgroupImageBlockReadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupImageBlockReadINTEL", "OpSubgroupImageBlockReadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupImageBlockWriteINTEL(Nodes.SubgroupImageBlockWriteINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupImageBlockWriteINTEL", "OpSubgroupImageBlockWriteINTEL", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Data), GetTypeName(node.Data?.GetResultType()), GetOutputConnection(node.Data)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupImageMediaBlockReadINTEL(Nodes.SubgroupImageMediaBlockReadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupImageMediaBlockReadINTEL", "OpSubgroupImageMediaBlockReadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Width), GetTypeName(node.Width?.GetResultType()), GetOutputConnection(node.Width)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Height), GetTypeName(node.Height?.GetResultType()), GetOutputConnection(node.Height)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupImageMediaBlockWriteINTEL(Nodes.SubgroupImageMediaBlockWriteINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupImageMediaBlockWriteINTEL", "OpSubgroupImageMediaBlockWriteINTEL", true, null, NodeCategory.Procedure, null);
            scriptNode.ExitPins.Add(new PinWithConnection("",null,GetExitConnection(node.Next)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Image), GetTypeName(node.Image?.GetResultType()), GetOutputConnection(node.Image)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Coordinate), GetTypeName(node.Coordinate?.GetResultType()), GetOutputConnection(node.Coordinate)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Width), GetTypeName(node.Width?.GetResultType()), GetOutputConnection(node.Width)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Height), GetTypeName(node.Height?.GetResultType()), GetOutputConnection(node.Height)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Data), GetTypeName(node.Data?.GetResultType()), GetOutputConnection(node.Data)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUCountLeadingZerosINTEL(Nodes.UCountLeadingZerosINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUCountLeadingZerosINTEL", "OpUCountLeadingZerosINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand), GetTypeName(node.Operand?.GetResultType()), GetOutputConnection(node.Operand)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUCountTrailingZerosINTEL(Nodes.UCountTrailingZerosINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUCountTrailingZerosINTEL", "OpUCountTrailingZerosINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand), GetTypeName(node.Operand?.GetResultType()), GetOutputConnection(node.Operand)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAbsISubINTEL(Nodes.AbsISubINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAbsISubINTEL", "OpAbsISubINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitAbsUSubINTEL(Nodes.AbsUSubINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpAbsUSubINTEL", "OpAbsUSubINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIAddSatINTEL(Nodes.IAddSatINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIAddSatINTEL", "OpIAddSatINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUAddSatINTEL(Nodes.UAddSatINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUAddSatINTEL", "OpUAddSatINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIAverageINTEL(Nodes.IAverageINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIAverageINTEL", "OpIAverageINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUAverageINTEL(Nodes.UAverageINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUAverageINTEL", "OpUAverageINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIAverageRoundedINTEL(Nodes.IAverageRoundedINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIAverageRoundedINTEL", "OpIAverageRoundedINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUAverageRoundedINTEL(Nodes.UAverageRoundedINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUAverageRoundedINTEL", "OpUAverageRoundedINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitISubSatINTEL(Nodes.ISubSatINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpISubSatINTEL", "OpISubSatINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUSubSatINTEL(Nodes.USubSatINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUSubSatINTEL", "OpUSubSatINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitIMul32x16INTEL(Nodes.IMul32x16INTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpIMul32x16INTEL", "OpIMul32x16INTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitUMul32x16INTEL(Nodes.UMul32x16INTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpUMul32x16INTEL", "OpUMul32x16INTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand1), GetTypeName(node.Operand1?.GetResultType()), GetOutputConnection(node.Operand1)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Operand2), GetTypeName(node.Operand2?.GetResultType()), GetOutputConnection(node.Operand2)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitDecorateString(Nodes.DecorateString node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpDecorateString", "OpDecorateString", false, null, NodeCategory.Unknown, null);
            scriptNode.ExitPins.Add(new PinWithConnection(nameof(node.Target),null, GetExitConnection(node.Target)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitMemberDecorateString(Nodes.MemberDecorateString node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpMemberDecorateString", "OpMemberDecorateString", false, null, NodeCategory.Unknown, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.StructType), GetTypeName(node.StructType?.GetResultType()), GetOutputConnection(node.StructType)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitVmeImageINTEL(Nodes.VmeImageINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpVmeImageINTEL", "OpVmeImageINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ImageType), GetTypeName(node.ImageType?.GetResultType()), GetOutputConnection(node.ImageType)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Sampler), GetTypeName(node.Sampler?.GetResultType()), GetOutputConnection(node.Sampler)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL", "OpSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SliceType), GetTypeName(node.SliceType?.GetResultType()), GetOutputConnection(node.SliceType)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Qp), GetTypeName(node.Qp?.GetResultType()), GetOutputConnection(node.Qp)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL(Nodes.SubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL", "OpSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ReferenceBasePenalty), GetTypeName(node.ReferenceBasePenalty?.GetResultType()), GetOutputConnection(node.ReferenceBasePenalty)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultInterShapePenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultInterShapePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultInterShapePenaltyINTEL", "OpSubgroupAvcMceGetDefaultInterShapePenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SliceType), GetTypeName(node.SliceType?.GetResultType()), GetOutputConnection(node.SliceType)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Qp), GetTypeName(node.Qp?.GetResultType()), GetOutputConnection(node.Qp)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetInterShapePenaltyINTEL(Nodes.SubgroupAvcMceSetInterShapePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceSetInterShapePenaltyINTEL", "OpSubgroupAvcMceSetInterShapePenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedShapePenalty), GetTypeName(node.PackedShapePenalty?.GetResultType()), GetOutputConnection(node.PackedShapePenalty)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL", "OpSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SliceType), GetTypeName(node.SliceType?.GetResultType()), GetOutputConnection(node.SliceType)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Qp), GetTypeName(node.Qp?.GetResultType()), GetOutputConnection(node.Qp)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetInterDirectionPenaltyINTEL(Nodes.SubgroupAvcMceSetInterDirectionPenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceSetInterDirectionPenaltyINTEL", "OpSubgroupAvcMceSetInterDirectionPenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.DirectionCost), GetTypeName(node.DirectionCost?.GetResultType()), GetOutputConnection(node.DirectionCost)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL", "OpSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SliceType), GetTypeName(node.SliceType?.GetResultType()), GetOutputConnection(node.SliceType)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Qp), GetTypeName(node.Qp?.GetResultType()), GetOutputConnection(node.Qp)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL(Nodes.SubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL", "OpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SliceType), GetTypeName(node.SliceType?.GetResultType()), GetOutputConnection(node.SliceType)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Qp), GetTypeName(node.Qp?.GetResultType()), GetOutputConnection(node.Qp)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL(Nodes.SubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL", "OpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL(Nodes.SubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL", "OpSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL(Nodes.SubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL", "OpSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetMotionVectorCostFunctionINTEL(Nodes.SubgroupAvcMceSetMotionVectorCostFunctionINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL", "OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedCostCenterDelta), GetTypeName(node.PackedCostCenterDelta?.GetResultType()), GetOutputConnection(node.PackedCostCenterDelta)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedCostTable), GetTypeName(node.PackedCostTable?.GetResultType()), GetOutputConnection(node.PackedCostTable)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.CostPrecision), GetTypeName(node.CostPrecision?.GetResultType()), GetOutputConnection(node.CostPrecision)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL", "OpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SliceType), GetTypeName(node.SliceType?.GetResultType()), GetOutputConnection(node.SliceType)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Qp), GetTypeName(node.Qp?.GetResultType()), GetOutputConnection(node.Qp)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL", "OpSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL(Nodes.SubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL", "OpSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetAcOnlyHaarINTEL(Nodes.SubgroupAvcMceSetAcOnlyHaarINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceSetAcOnlyHaarINTEL", "OpSubgroupAvcMceSetAcOnlyHaarINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL(Nodes.SubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL", "OpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SourceFieldPolarity), GetTypeName(node.SourceFieldPolarity?.GetResultType()), GetOutputConnection(node.SourceFieldPolarity)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL(Nodes.SubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL", "OpSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ReferenceFieldPolarity), GetTypeName(node.ReferenceFieldPolarity?.GetResultType()), GetOutputConnection(node.ReferenceFieldPolarity)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL(Nodes.SubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL", "OpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ForwardReferenceFieldPolarity), GetTypeName(node.ForwardReferenceFieldPolarity?.GetResultType()), GetOutputConnection(node.ForwardReferenceFieldPolarity)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BackwardReferenceFieldPolarity), GetTypeName(node.BackwardReferenceFieldPolarity?.GetResultType()), GetOutputConnection(node.BackwardReferenceFieldPolarity)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToImePayloadINTEL(Nodes.SubgroupAvcMceConvertToImePayloadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceConvertToImePayloadINTEL", "OpSubgroupAvcMceConvertToImePayloadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToImeResultINTEL(Nodes.SubgroupAvcMceConvertToImeResultINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceConvertToImeResultINTEL", "OpSubgroupAvcMceConvertToImeResultINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToRefPayloadINTEL(Nodes.SubgroupAvcMceConvertToRefPayloadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceConvertToRefPayloadINTEL", "OpSubgroupAvcMceConvertToRefPayloadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToRefResultINTEL(Nodes.SubgroupAvcMceConvertToRefResultINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceConvertToRefResultINTEL", "OpSubgroupAvcMceConvertToRefResultINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToSicPayloadINTEL(Nodes.SubgroupAvcMceConvertToSicPayloadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceConvertToSicPayloadINTEL", "OpSubgroupAvcMceConvertToSicPayloadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceConvertToSicResultINTEL(Nodes.SubgroupAvcMceConvertToSicResultINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceConvertToSicResultINTEL", "OpSubgroupAvcMceConvertToSicResultINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetMotionVectorsINTEL(Nodes.SubgroupAvcMceGetMotionVectorsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetMotionVectorsINTEL", "OpSubgroupAvcMceGetMotionVectorsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterDistortionsINTEL(Nodes.SubgroupAvcMceGetInterDistortionsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetInterDistortionsINTEL", "OpSubgroupAvcMceGetInterDistortionsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetBestInterDistortionsINTEL(Nodes.SubgroupAvcMceGetBestInterDistortionsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetBestInterDistortionsINTEL", "OpSubgroupAvcMceGetBestInterDistortionsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterMajorShapeINTEL(Nodes.SubgroupAvcMceGetInterMajorShapeINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetInterMajorShapeINTEL", "OpSubgroupAvcMceGetInterMajorShapeINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterMinorShapeINTEL(Nodes.SubgroupAvcMceGetInterMinorShapeINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetInterMinorShapeINTEL", "OpSubgroupAvcMceGetInterMinorShapeINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterDirectionsINTEL(Nodes.SubgroupAvcMceGetInterDirectionsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetInterDirectionsINTEL", "OpSubgroupAvcMceGetInterDirectionsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterMotionVectorCountINTEL(Nodes.SubgroupAvcMceGetInterMotionVectorCountINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetInterMotionVectorCountINTEL", "OpSubgroupAvcMceGetInterMotionVectorCountINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterReferenceIdsINTEL(Nodes.SubgroupAvcMceGetInterReferenceIdsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetInterReferenceIdsINTEL", "OpSubgroupAvcMceGetInterReferenceIdsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL(Nodes.SubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL", "OpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedReferenceIds), GetTypeName(node.PackedReferenceIds?.GetResultType()), GetOutputConnection(node.PackedReferenceIds)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedReferenceParameterFieldPolarities), GetTypeName(node.PackedReferenceParameterFieldPolarities?.GetResultType()), GetOutputConnection(node.PackedReferenceParameterFieldPolarities)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeInitializeINTEL(Nodes.SubgroupAvcImeInitializeINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeInitializeINTEL", "OpSubgroupAvcImeInitializeINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcCoord), GetTypeName(node.SrcCoord?.GetResultType()), GetOutputConnection(node.SrcCoord)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PartitionMask), GetTypeName(node.PartitionMask?.GetResultType()), GetOutputConnection(node.PartitionMask)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SADAdjustment), GetTypeName(node.SADAdjustment?.GetResultType()), GetOutputConnection(node.SADAdjustment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetSingleReferenceINTEL(Nodes.SubgroupAvcImeSetSingleReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeSetSingleReferenceINTEL", "OpSubgroupAvcImeSetSingleReferenceINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RefOffset), GetTypeName(node.RefOffset?.GetResultType()), GetOutputConnection(node.RefOffset)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SearchWindowConfig), GetTypeName(node.SearchWindowConfig?.GetResultType()), GetOutputConnection(node.SearchWindowConfig)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetDualReferenceINTEL(Nodes.SubgroupAvcImeSetDualReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeSetDualReferenceINTEL", "OpSubgroupAvcImeSetDualReferenceINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FwdRefOffset), GetTypeName(node.FwdRefOffset?.GetResultType()), GetOutputConnection(node.FwdRefOffset)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BwdRefOffset), GetTypeName(node.BwdRefOffset?.GetResultType()), GetOutputConnection(node.BwdRefOffset)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SearchWindowConfig), GetTypeName(node.SearchWindowConfig?.GetResultType()), GetOutputConnection(node.SearchWindowConfig)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeRefWindowSizeINTEL(Nodes.SubgroupAvcImeRefWindowSizeINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeRefWindowSizeINTEL", "OpSubgroupAvcImeRefWindowSizeINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SearchWindowConfig), GetTypeName(node.SearchWindowConfig?.GetResultType()), GetOutputConnection(node.SearchWindowConfig)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.DualRef), GetTypeName(node.DualRef?.GetResultType()), GetOutputConnection(node.DualRef)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeAdjustRefOffsetINTEL(Nodes.SubgroupAvcImeAdjustRefOffsetINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeAdjustRefOffsetINTEL", "OpSubgroupAvcImeAdjustRefOffsetINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RefOffset), GetTypeName(node.RefOffset?.GetResultType()), GetOutputConnection(node.RefOffset)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcCoord), GetTypeName(node.SrcCoord?.GetResultType()), GetOutputConnection(node.SrcCoord)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RefWindowSize), GetTypeName(node.RefWindowSize?.GetResultType()), GetOutputConnection(node.RefWindowSize)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ImageSize), GetTypeName(node.ImageSize?.GetResultType()), GetOutputConnection(node.ImageSize)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeConvertToMcePayloadINTEL(Nodes.SubgroupAvcImeConvertToMcePayloadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeConvertToMcePayloadINTEL", "OpSubgroupAvcImeConvertToMcePayloadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetMaxMotionVectorCountINTEL(Nodes.SubgroupAvcImeSetMaxMotionVectorCountINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeSetMaxMotionVectorCountINTEL", "OpSubgroupAvcImeSetMaxMotionVectorCountINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MaxMotionVectorCount), GetTypeName(node.MaxMotionVectorCount?.GetResultType()), GetOutputConnection(node.MaxMotionVectorCount)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetUnidirectionalMixDisableINTEL(Nodes.SubgroupAvcImeSetUnidirectionalMixDisableINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeSetUnidirectionalMixDisableINTEL", "OpSubgroupAvcImeSetUnidirectionalMixDisableINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL(Nodes.SubgroupAvcImeSetEarlySearchTerminationThresholdINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL", "OpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Threshold), GetTypeName(node.Threshold?.GetResultType()), GetOutputConnection(node.Threshold)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeSetWeightedSadINTEL(Nodes.SubgroupAvcImeSetWeightedSadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeSetWeightedSadINTEL", "OpSubgroupAvcImeSetWeightedSadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedSadWeights), GetTypeName(node.PackedSadWeights?.GetResultType()), GetOutputConnection(node.PackedSadWeights)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithSingleReferenceINTEL(Nodes.SubgroupAvcImeEvaluateWithSingleReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeEvaluateWithSingleReferenceINTEL", "OpSubgroupAvcImeEvaluateWithSingleReferenceINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RefImage), GetTypeName(node.RefImage?.GetResultType()), GetOutputConnection(node.RefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithDualReferenceINTEL(Nodes.SubgroupAvcImeEvaluateWithDualReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeEvaluateWithDualReferenceINTEL", "OpSubgroupAvcImeEvaluateWithDualReferenceINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FwdRefImage), GetTypeName(node.FwdRefImage?.GetResultType()), GetOutputConnection(node.FwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BwdRefImage), GetTypeName(node.BwdRefImage?.GetResultType()), GetOutputConnection(node.BwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL(Nodes.SubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL", "OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RefImage), GetTypeName(node.RefImage?.GetResultType()), GetOutputConnection(node.RefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.StreaminComponents), GetTypeName(node.StreaminComponents?.GetResultType()), GetOutputConnection(node.StreaminComponents)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL(Nodes.SubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL", "OpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FwdRefImage), GetTypeName(node.FwdRefImage?.GetResultType()), GetOutputConnection(node.FwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BwdRefImage), GetTypeName(node.BwdRefImage?.GetResultType()), GetOutputConnection(node.BwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.StreaminComponents), GetTypeName(node.StreaminComponents?.GetResultType()), GetOutputConnection(node.StreaminComponents)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL(Nodes.SubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL", "OpSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RefImage), GetTypeName(node.RefImage?.GetResultType()), GetOutputConnection(node.RefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL(Nodes.SubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL", "OpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FwdRefImage), GetTypeName(node.FwdRefImage?.GetResultType()), GetOutputConnection(node.FwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BwdRefImage), GetTypeName(node.BwdRefImage?.GetResultType()), GetOutputConnection(node.BwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL(Nodes.SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL", "OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RefImage), GetTypeName(node.RefImage?.GetResultType()), GetOutputConnection(node.RefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.StreaminComponents), GetTypeName(node.StreaminComponents?.GetResultType()), GetOutputConnection(node.StreaminComponents)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL(Nodes.SubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL", "OpSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FwdRefImage), GetTypeName(node.FwdRefImage?.GetResultType()), GetOutputConnection(node.FwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BwdRefImage), GetTypeName(node.BwdRefImage?.GetResultType()), GetOutputConnection(node.BwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.StreaminComponents), GetTypeName(node.StreaminComponents?.GetResultType()), GetOutputConnection(node.StreaminComponents)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeConvertToMceResultINTEL(Nodes.SubgroupAvcImeConvertToMceResultINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeConvertToMceResultINTEL", "OpSubgroupAvcImeConvertToMceResultINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetSingleReferenceStreaminINTEL(Nodes.SubgroupAvcImeGetSingleReferenceStreaminINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetSingleReferenceStreaminINTEL", "OpSubgroupAvcImeGetSingleReferenceStreaminINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetDualReferenceStreaminINTEL(Nodes.SubgroupAvcImeGetDualReferenceStreaminINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetDualReferenceStreaminINTEL", "OpSubgroupAvcImeGetDualReferenceStreaminINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeStripSingleReferenceStreamoutINTEL(Nodes.SubgroupAvcImeStripSingleReferenceStreamoutINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeStripSingleReferenceStreamoutINTEL", "OpSubgroupAvcImeStripSingleReferenceStreamoutINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeStripDualReferenceStreamoutINTEL(Nodes.SubgroupAvcImeStripDualReferenceStreamoutINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeStripDualReferenceStreamoutINTEL", "OpSubgroupAvcImeStripDualReferenceStreamoutINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL(Nodes.SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL", "OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MajorShape), GetTypeName(node.MajorShape?.GetResultType()), GetOutputConnection(node.MajorShape)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL(Nodes.SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL", "OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MajorShape), GetTypeName(node.MajorShape?.GetResultType()), GetOutputConnection(node.MajorShape)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL(Nodes.SubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL", "OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MajorShape), GetTypeName(node.MajorShape?.GetResultType()), GetOutputConnection(node.MajorShape)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL(Nodes.SubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL", "OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MajorShape), GetTypeName(node.MajorShape?.GetResultType()), GetOutputConnection(node.MajorShape)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Direction), GetTypeName(node.Direction?.GetResultType()), GetOutputConnection(node.Direction)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL(Nodes.SubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL", "OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MajorShape), GetTypeName(node.MajorShape?.GetResultType()), GetOutputConnection(node.MajorShape)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Direction), GetTypeName(node.Direction?.GetResultType()), GetOutputConnection(node.Direction)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL(Nodes.SubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL", "OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MajorShape), GetTypeName(node.MajorShape?.GetResultType()), GetOutputConnection(node.MajorShape)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Direction), GetTypeName(node.Direction?.GetResultType()), GetOutputConnection(node.Direction)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetBorderReachedINTEL(Nodes.SubgroupAvcImeGetBorderReachedINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetBorderReachedINTEL", "OpSubgroupAvcImeGetBorderReachedINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ImageSelect), GetTypeName(node.ImageSelect?.GetResultType()), GetOutputConnection(node.ImageSelect)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetTruncatedSearchIndicationINTEL(Nodes.SubgroupAvcImeGetTruncatedSearchIndicationINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetTruncatedSearchIndicationINTEL", "OpSubgroupAvcImeGetTruncatedSearchIndicationINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL(Nodes.SubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL", "OpSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL(Nodes.SubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL", "OpSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL(Nodes.SubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL", "OpSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcFmeInitializeINTEL(Nodes.SubgroupAvcFmeInitializeINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcFmeInitializeINTEL", "OpSubgroupAvcFmeInitializeINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcCoord), GetTypeName(node.SrcCoord?.GetResultType()), GetOutputConnection(node.SrcCoord)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MotionVectors), GetTypeName(node.MotionVectors?.GetResultType()), GetOutputConnection(node.MotionVectors)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MajorShapes), GetTypeName(node.MajorShapes?.GetResultType()), GetOutputConnection(node.MajorShapes)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MinorShapes), GetTypeName(node.MinorShapes?.GetResultType()), GetOutputConnection(node.MinorShapes)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Direction), GetTypeName(node.Direction?.GetResultType()), GetOutputConnection(node.Direction)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PixelResolution), GetTypeName(node.PixelResolution?.GetResultType()), GetOutputConnection(node.PixelResolution)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SadAdjustment), GetTypeName(node.SadAdjustment?.GetResultType()), GetOutputConnection(node.SadAdjustment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcBmeInitializeINTEL(Nodes.SubgroupAvcBmeInitializeINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcBmeInitializeINTEL", "OpSubgroupAvcBmeInitializeINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcCoord), GetTypeName(node.SrcCoord?.GetResultType()), GetOutputConnection(node.SrcCoord)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MotionVectors), GetTypeName(node.MotionVectors?.GetResultType()), GetOutputConnection(node.MotionVectors)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MajorShapes), GetTypeName(node.MajorShapes?.GetResultType()), GetOutputConnection(node.MajorShapes)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MinorShapes), GetTypeName(node.MinorShapes?.GetResultType()), GetOutputConnection(node.MinorShapes)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Direction), GetTypeName(node.Direction?.GetResultType()), GetOutputConnection(node.Direction)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PixelResolution), GetTypeName(node.PixelResolution?.GetResultType()), GetOutputConnection(node.PixelResolution)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BidirectionalWeight), GetTypeName(node.BidirectionalWeight?.GetResultType()), GetOutputConnection(node.BidirectionalWeight)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SadAdjustment), GetTypeName(node.SadAdjustment?.GetResultType()), GetOutputConnection(node.SadAdjustment)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefConvertToMcePayloadINTEL(Nodes.SubgroupAvcRefConvertToMcePayloadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcRefConvertToMcePayloadINTEL", "OpSubgroupAvcRefConvertToMcePayloadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefSetBidirectionalMixDisableINTEL(Nodes.SubgroupAvcRefSetBidirectionalMixDisableINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcRefSetBidirectionalMixDisableINTEL", "OpSubgroupAvcRefSetBidirectionalMixDisableINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefSetBilinearFilterEnableINTEL(Nodes.SubgroupAvcRefSetBilinearFilterEnableINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcRefSetBilinearFilterEnableINTEL", "OpSubgroupAvcRefSetBilinearFilterEnableINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefEvaluateWithSingleReferenceINTEL(Nodes.SubgroupAvcRefEvaluateWithSingleReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcRefEvaluateWithSingleReferenceINTEL", "OpSubgroupAvcRefEvaluateWithSingleReferenceINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RefImage), GetTypeName(node.RefImage?.GetResultType()), GetOutputConnection(node.RefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefEvaluateWithDualReferenceINTEL(Nodes.SubgroupAvcRefEvaluateWithDualReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcRefEvaluateWithDualReferenceINTEL", "OpSubgroupAvcRefEvaluateWithDualReferenceINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FwdRefImage), GetTypeName(node.FwdRefImage?.GetResultType()), GetOutputConnection(node.FwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BwdRefImage), GetTypeName(node.BwdRefImage?.GetResultType()), GetOutputConnection(node.BwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefEvaluateWithMultiReferenceINTEL(Nodes.SubgroupAvcRefEvaluateWithMultiReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcRefEvaluateWithMultiReferenceINTEL", "OpSubgroupAvcRefEvaluateWithMultiReferenceINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedReferenceIds), GetTypeName(node.PackedReferenceIds?.GetResultType()), GetOutputConnection(node.PackedReferenceIds)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL(Nodes.SubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL", "OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedReferenceIds), GetTypeName(node.PackedReferenceIds?.GetResultType()), GetOutputConnection(node.PackedReferenceIds)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedReferenceFieldPolarities), GetTypeName(node.PackedReferenceFieldPolarities?.GetResultType()), GetOutputConnection(node.PackedReferenceFieldPolarities)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcRefConvertToMceResultINTEL(Nodes.SubgroupAvcRefConvertToMceResultINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcRefConvertToMceResultINTEL", "OpSubgroupAvcRefConvertToMceResultINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicInitializeINTEL(Nodes.SubgroupAvcSicInitializeINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicInitializeINTEL", "OpSubgroupAvcSicInitializeINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcCoord), GetTypeName(node.SrcCoord?.GetResultType()), GetOutputConnection(node.SrcCoord)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicConfigureSkcINTEL(Nodes.SubgroupAvcSicConfigureSkcINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicConfigureSkcINTEL", "OpSubgroupAvcSicConfigureSkcINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SkipBlockPartitionType), GetTypeName(node.SkipBlockPartitionType?.GetResultType()), GetOutputConnection(node.SkipBlockPartitionType)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SkipMotionVectorMask), GetTypeName(node.SkipMotionVectorMask?.GetResultType()), GetOutputConnection(node.SkipMotionVectorMask)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.MotionVectors), GetTypeName(node.MotionVectors?.GetResultType()), GetOutputConnection(node.MotionVectors)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BidirectionalWeight), GetTypeName(node.BidirectionalWeight?.GetResultType()), GetOutputConnection(node.BidirectionalWeight)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SadAdjustment), GetTypeName(node.SadAdjustment?.GetResultType()), GetOutputConnection(node.SadAdjustment)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicConfigureIpeLumaINTEL(Nodes.SubgroupAvcSicConfigureIpeLumaINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicConfigureIpeLumaINTEL", "OpSubgroupAvcSicConfigureIpeLumaINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LumaIntraPartitionMask), GetTypeName(node.LumaIntraPartitionMask?.GetResultType()), GetOutputConnection(node.LumaIntraPartitionMask)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.IntraNeighbourAvailabilty), GetTypeName(node.IntraNeighbourAvailabilty?.GetResultType()), GetOutputConnection(node.IntraNeighbourAvailabilty)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LeftEdgeLumaPixels), GetTypeName(node.LeftEdgeLumaPixels?.GetResultType()), GetOutputConnection(node.LeftEdgeLumaPixels)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UpperLeftCornerLumaPixel), GetTypeName(node.UpperLeftCornerLumaPixel?.GetResultType()), GetOutputConnection(node.UpperLeftCornerLumaPixel)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UpperEdgeLumaPixels), GetTypeName(node.UpperEdgeLumaPixels?.GetResultType()), GetOutputConnection(node.UpperEdgeLumaPixels)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UpperRightEdgeLumaPixels), GetTypeName(node.UpperRightEdgeLumaPixels?.GetResultType()), GetOutputConnection(node.UpperRightEdgeLumaPixels)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SadAdjustment), GetTypeName(node.SadAdjustment?.GetResultType()), GetOutputConnection(node.SadAdjustment)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicConfigureIpeLumaChromaINTEL(Nodes.SubgroupAvcSicConfigureIpeLumaChromaINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicConfigureIpeLumaChromaINTEL", "OpSubgroupAvcSicConfigureIpeLumaChromaINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LumaIntraPartitionMask), GetTypeName(node.LumaIntraPartitionMask?.GetResultType()), GetOutputConnection(node.LumaIntraPartitionMask)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.IntraNeighbourAvailabilty), GetTypeName(node.IntraNeighbourAvailabilty?.GetResultType()), GetOutputConnection(node.IntraNeighbourAvailabilty)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LeftEdgeLumaPixels), GetTypeName(node.LeftEdgeLumaPixels?.GetResultType()), GetOutputConnection(node.LeftEdgeLumaPixels)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UpperLeftCornerLumaPixel), GetTypeName(node.UpperLeftCornerLumaPixel?.GetResultType()), GetOutputConnection(node.UpperLeftCornerLumaPixel)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UpperEdgeLumaPixels), GetTypeName(node.UpperEdgeLumaPixels?.GetResultType()), GetOutputConnection(node.UpperEdgeLumaPixels)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UpperRightEdgeLumaPixels), GetTypeName(node.UpperRightEdgeLumaPixels?.GetResultType()), GetOutputConnection(node.UpperRightEdgeLumaPixels)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LeftEdgeChromaPixels), GetTypeName(node.LeftEdgeChromaPixels?.GetResultType()), GetOutputConnection(node.LeftEdgeChromaPixels)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UpperLeftCornerChromaPixel), GetTypeName(node.UpperLeftCornerChromaPixel?.GetResultType()), GetOutputConnection(node.UpperLeftCornerChromaPixel)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.UpperEdgeChromaPixels), GetTypeName(node.UpperEdgeChromaPixels?.GetResultType()), GetOutputConnection(node.UpperEdgeChromaPixels)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SadAdjustment), GetTypeName(node.SadAdjustment?.GetResultType()), GetOutputConnection(node.SadAdjustment)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetMotionVectorMaskINTEL(Nodes.SubgroupAvcSicGetMotionVectorMaskINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicGetMotionVectorMaskINTEL", "OpSubgroupAvcSicGetMotionVectorMaskINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SkipBlockPartitionType), GetTypeName(node.SkipBlockPartitionType?.GetResultType()), GetOutputConnection(node.SkipBlockPartitionType)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Direction), GetTypeName(node.Direction?.GetResultType()), GetOutputConnection(node.Direction)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicConvertToMcePayloadINTEL(Nodes.SubgroupAvcSicConvertToMcePayloadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicConvertToMcePayloadINTEL", "OpSubgroupAvcSicConvertToMcePayloadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetIntraLumaShapePenaltyINTEL(Nodes.SubgroupAvcSicSetIntraLumaShapePenaltyINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL", "OpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedShapePenalty), GetTypeName(node.PackedShapePenalty?.GetResultType()), GetOutputConnection(node.PackedShapePenalty)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL(Nodes.SubgroupAvcSicSetIntraLumaModeCostFunctionINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL", "OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LumaModePenalty), GetTypeName(node.LumaModePenalty?.GetResultType()), GetOutputConnection(node.LumaModePenalty)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LumaPackedNeighborModes), GetTypeName(node.LumaPackedNeighborModes?.GetResultType()), GetOutputConnection(node.LumaPackedNeighborModes)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.LumaPackedNonDcPenalty), GetTypeName(node.LumaPackedNonDcPenalty?.GetResultType()), GetOutputConnection(node.LumaPackedNonDcPenalty)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL(Nodes.SubgroupAvcSicSetIntraChromaModeCostFunctionINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL", "OpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.ChromaModeBasePenalty), GetTypeName(node.ChromaModeBasePenalty?.GetResultType()), GetOutputConnection(node.ChromaModeBasePenalty)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetBilinearFilterEnableINTEL(Nodes.SubgroupAvcSicSetBilinearFilterEnableINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicSetBilinearFilterEnableINTEL", "OpSubgroupAvcSicSetBilinearFilterEnableINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetSkcForwardTransformEnableINTEL(Nodes.SubgroupAvcSicSetSkcForwardTransformEnableINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicSetSkcForwardTransformEnableINTEL", "OpSubgroupAvcSicSetSkcForwardTransformEnableINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedSadCoefficients), GetTypeName(node.PackedSadCoefficients?.GetResultType()), GetOutputConnection(node.PackedSadCoefficients)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicSetBlockBasedRawSkipSadINTEL(Nodes.SubgroupAvcSicSetBlockBasedRawSkipSadINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicSetBlockBasedRawSkipSadINTEL", "OpSubgroupAvcSicSetBlockBasedRawSkipSadINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BlockBasedSkipType), GetTypeName(node.BlockBasedSkipType?.GetResultType()), GetOutputConnection(node.BlockBasedSkipType)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicEvaluateIpeINTEL(Nodes.SubgroupAvcSicEvaluateIpeINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicEvaluateIpeINTEL", "OpSubgroupAvcSicEvaluateIpeINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicEvaluateWithSingleReferenceINTEL(Nodes.SubgroupAvcSicEvaluateWithSingleReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicEvaluateWithSingleReferenceINTEL", "OpSubgroupAvcSicEvaluateWithSingleReferenceINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.RefImage), GetTypeName(node.RefImage?.GetResultType()), GetOutputConnection(node.RefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicEvaluateWithDualReferenceINTEL(Nodes.SubgroupAvcSicEvaluateWithDualReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicEvaluateWithDualReferenceINTEL", "OpSubgroupAvcSicEvaluateWithDualReferenceINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.FwdRefImage), GetTypeName(node.FwdRefImage?.GetResultType()), GetOutputConnection(node.FwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.BwdRefImage), GetTypeName(node.BwdRefImage?.GetResultType()), GetOutputConnection(node.BwdRefImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicEvaluateWithMultiReferenceINTEL(Nodes.SubgroupAvcSicEvaluateWithMultiReferenceINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicEvaluateWithMultiReferenceINTEL", "OpSubgroupAvcSicEvaluateWithMultiReferenceINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedReferenceIds), GetTypeName(node.PackedReferenceIds?.GetResultType()), GetOutputConnection(node.PackedReferenceIds)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL(Nodes.SubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL", "OpSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.SrcImage), GetTypeName(node.SrcImage?.GetResultType()), GetOutputConnection(node.SrcImage)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedReferenceIds), GetTypeName(node.PackedReferenceIds?.GetResultType()), GetOutputConnection(node.PackedReferenceIds)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.PackedReferenceFieldPolarities), GetTypeName(node.PackedReferenceFieldPolarities?.GetResultType()), GetOutputConnection(node.PackedReferenceFieldPolarities)));
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicConvertToMceResultINTEL(Nodes.SubgroupAvcSicConvertToMceResultINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicConvertToMceResultINTEL", "OpSubgroupAvcSicConvertToMceResultINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetIpeLumaShapeINTEL(Nodes.SubgroupAvcSicGetIpeLumaShapeINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicGetIpeLumaShapeINTEL", "OpSubgroupAvcSicGetIpeLumaShapeINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetBestIpeLumaDistortionINTEL(Nodes.SubgroupAvcSicGetBestIpeLumaDistortionINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicGetBestIpeLumaDistortionINTEL", "OpSubgroupAvcSicGetBestIpeLumaDistortionINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetBestIpeChromaDistortionINTEL(Nodes.SubgroupAvcSicGetBestIpeChromaDistortionINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicGetBestIpeChromaDistortionINTEL", "OpSubgroupAvcSicGetBestIpeChromaDistortionINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetPackedIpeLumaModesINTEL(Nodes.SubgroupAvcSicGetPackedIpeLumaModesINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicGetPackedIpeLumaModesINTEL", "OpSubgroupAvcSicGetPackedIpeLumaModesINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetIpeChromaModeINTEL(Nodes.SubgroupAvcSicGetIpeChromaModeINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicGetIpeChromaModeINTEL", "OpSubgroupAvcSicGetIpeChromaModeINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL(Nodes.SubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL", "OpSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL(Nodes.SubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL", "OpSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }

        protected virtual ScriptNode VisitSubgroupAvcSicGetInterRawSadsINTEL(Nodes.SubgroupAvcSicGetInterRawSadsINTEL node)
        {
            var scriptNode = CreateNode(node, node.DebugName ?? "OpSubgroupAvcSicGetInterRawSadsINTEL", "OpSubgroupAvcSicGetInterRawSadsINTEL", false, GetTypeName(node.ResultType), NodeCategory.Function, null);
            scriptNode.InputPins.Add(new PinWithConnection(nameof(node.Payload), GetTypeName(node.Payload?.GetResultType()), GetOutputConnection(node.Payload)));
            return scriptNode;
        }
        protected string GetTypeName(SpirvTypeBase type)
        {
            if (type == null)
                return null;
            switch (type.OpCode)
            {
                case Op.OpTypeVoid: return GetVoidName((TypeVoid)type);
                case Op.OpTypeBool: return GetBoolName((TypeBool)type);
                case Op.OpTypeInt: return GetIntName((TypeInt)type);
                case Op.OpTypeFloat: return GetFloatName((TypeFloat)type);
                case Op.OpTypeVector: return GetVectorName((TypeVector)type);
                case Op.OpTypeMatrix: return GetMatrixName((TypeMatrix)type);
                case Op.OpTypeImage: return GetImageName((TypeImage)type);
                case Op.OpTypeSampler: return GetSamplerName((TypeSampler)type);
                case Op.OpTypeSampledImage: return GetSampledImageName((TypeSampledImage)type);
                case Op.OpTypeArray: return GetArrayName((TypeArray)type);
                case Op.OpTypeRuntimeArray: return GetRuntimeArrayName((TypeRuntimeArray)type);
                case Op.OpTypeStruct: return GetStructName((TypeStruct)type);
                case Op.OpTypeOpaque: return GetOpaqueName((TypeOpaque)type);
                case Op.OpTypePointer: return GetPointerName((TypePointer)type);
                case Op.OpTypeFunction: return GetFunctionName((TypeFunction)type);
                case Op.OpTypeEvent: return GetEventName((TypeEvent)type);
                case Op.OpTypeDeviceEvent: return GetDeviceEventName((TypeDeviceEvent)type);
                case Op.OpTypeReserveId: return GetReserveIdName((TypeReserveId)type);
                case Op.OpTypeQueue: return GetQueueName((TypeQueue)type);
                case Op.OpTypePipe: return GetPipeName((TypePipe)type);
                case Op.OpTypeForwardPointer: return GetForwardPointerName((TypeForwardPointer)type);
                case Op.OpTypePipeStorage: return GetPipeStorageName((TypePipeStorage)type);
                case Op.OpTypeNamedBarrier: return GetNamedBarrierName((TypeNamedBarrier)type);
                case Op.OpTypeAccelerationStructureNV: return GetAccelerationStructureNVName((TypeAccelerationStructureNV)type);
                case Op.OpTypeRayQueryProvisionalKHR: return GetRayQueryProvisionalKHRName((TypeRayQueryProvisionalKHR)type);
                case Op.OpTypeCooperativeMatrixNV: return GetCooperativeMatrixNVName((TypeCooperativeMatrixNV)type);
                case Op.OpTypeVmeImageINTEL: return GetVmeImageINTELName((TypeVmeImageINTEL)type);
                case Op.OpTypeAvcImePayloadINTEL: return GetAvcImePayloadINTELName((TypeAvcImePayloadINTEL)type);
                case Op.OpTypeAvcRefPayloadINTEL: return GetAvcRefPayloadINTELName((TypeAvcRefPayloadINTEL)type);
                case Op.OpTypeAvcSicPayloadINTEL: return GetAvcSicPayloadINTELName((TypeAvcSicPayloadINTEL)type);
                case Op.OpTypeAvcMcePayloadINTEL: return GetAvcMcePayloadINTELName((TypeAvcMcePayloadINTEL)type);
                case Op.OpTypeAvcMceResultINTEL: return GetAvcMceResultINTELName((TypeAvcMceResultINTEL)type);
                case Op.OpTypeAvcImeResultINTEL: return GetAvcImeResultINTELName((TypeAvcImeResultINTEL)type);
                case Op.OpTypeAvcImeResultSingleReferenceStreamoutINTEL: return GetAvcImeResultSingleReferenceStreamoutINTELName((TypeAvcImeResultSingleReferenceStreamoutINTEL)type);
                case Op.OpTypeAvcImeResultDualReferenceStreamoutINTEL: return GetAvcImeResultDualReferenceStreamoutINTELName((TypeAvcImeResultDualReferenceStreamoutINTEL)type);
                case Op.OpTypeAvcImeSingleReferenceStreaminINTEL: return GetAvcImeSingleReferenceStreaminINTELName((TypeAvcImeSingleReferenceStreaminINTEL)type);
                case Op.OpTypeAvcImeDualReferenceStreaminINTEL: return GetAvcImeDualReferenceStreaminINTELName((TypeAvcImeDualReferenceStreaminINTEL)type);
                case Op.OpTypeAvcRefResultINTEL: return GetAvcRefResultINTELName((TypeAvcRefResultINTEL)type);
                case Op.OpTypeAvcSicResultINTEL: return GetAvcSicResultINTELName((TypeAvcSicResultINTEL)type);
            }
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual Connection GetExitConnection(Node node)
        {
            if (node == null)
                return null;
            return new Connection(VisitNode(node), "");
        }

        protected virtual Connection GetOutputConnection(Node node)
        {
            if (node == null)
                return null;
            return new Connection(VisitNode(node), "");
        }


        protected virtual string GetVoidName(TypeVoid type)
        {
            return "void";
        }

        protected virtual string GetBoolName(TypeBool type)
        {
            return "bool";
        }

        protected virtual string GetIntName(TypeInt type)
        {
            if (type.Signed)
            {
                switch (type.Width)
                {
                    case 8: return "sbyte";
                    case 16: return "short";
                    case 32: return "int";
                    case 64: return "long";
                }
            }
            else
            {
                switch (type.Width)
                {
                    case 8: return "byte";
                    case 16: return "ushort";
                    case 32: return "uint";
                    case 64: return "ulong";
                }
            }
            throw new NotImplementedException(type + " is not implemented yet.");
        }

        protected virtual string GetFloatName(TypeFloat type)
        {
            switch (type.Width)
            {
                case 32: return "float";
                case 64: return "double";
            }
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetVectorName(TypeVector type)
        {
            if (type.ComponentType == SpirvTypeBase.Float)
            {
                switch (type.ComponentCount)
                {
                    case 2: return "vec2";
                    case 3: return "vec3";
                    case 4: return "vec4";
                }
            }
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetMatrixName(TypeMatrix type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetImageName(TypeImage type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetSamplerName(TypeSampler type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetSampledImageName(TypeSampledImage type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetArrayName(TypeArray type)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}[{1}]", GetTypeName(type.ElementType), type.Length);
        }

        protected virtual string GetRuntimeArrayName(TypeRuntimeArray type)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}[*]", GetTypeName(type.ElementType));
        }

        protected virtual string GetStructName(TypeStruct type)
        {
            return type.DebugName;
        }

        protected virtual string GetOpaqueName(TypeOpaque type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetPointerName(TypePointer type)
        {
            return GetTypeName(type.Type)+"*";
        }

        protected virtual string GetFunctionName(TypeFunction type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetEventName(TypeEvent type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetDeviceEventName(TypeDeviceEvent type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetReserveIdName(TypeReserveId type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetQueueName(TypeQueue type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetPipeName(TypePipe type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetForwardPointerName(TypeForwardPointer type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetPipeStorageName(TypePipeStorage type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetNamedBarrierName(TypeNamedBarrier type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAccelerationStructureNVName(TypeAccelerationStructureNV type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetRayQueryProvisionalKHRName(TypeRayQueryProvisionalKHR type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetCooperativeMatrixNVName(TypeCooperativeMatrixNV type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetVmeImageINTELName(TypeVmeImageINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcImePayloadINTELName(TypeAvcImePayloadINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcRefPayloadINTELName(TypeAvcRefPayloadINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcSicPayloadINTELName(TypeAvcSicPayloadINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcMcePayloadINTELName(TypeAvcMcePayloadINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcMceResultINTELName(TypeAvcMceResultINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcImeResultINTELName(TypeAvcImeResultINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcImeResultSingleReferenceStreamoutINTELName(TypeAvcImeResultSingleReferenceStreamoutINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcImeResultDualReferenceStreamoutINTELName(TypeAvcImeResultDualReferenceStreamoutINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcImeSingleReferenceStreaminINTELName(TypeAvcImeSingleReferenceStreaminINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcImeDualReferenceStreaminINTELName(TypeAvcImeDualReferenceStreaminINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcRefResultINTELName(TypeAvcRefResultINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected virtual string GetAvcSicResultINTELName(TypeAvcSicResultINTEL type)
        {
            throw new NotImplementedException(type+" is not implemented yet.");
        }

        protected ScriptNode CreateNode(Node node, string name, string type, bool hasDefaultEnter = false, string outputType = null, NodeCategory category = NodeCategory.Unknown, string value = null)
        {
            var scriptNode = new ScriptNode()
            {
                Name = name,
                Type = type,
                Category = category,
                Value = value
            };
            if (hasDefaultEnter)
            {
                scriptNode.EnterPins.Add(new Pin("",null));
            }
            if (outputType != null)
            {
                scriptNode.OutputPins.Add(new Pin("", outputType));
            }
            _script.Add(scriptNode);
            _nodeMap.Add(node, scriptNode);
            return scriptNode;
        }
    }
}