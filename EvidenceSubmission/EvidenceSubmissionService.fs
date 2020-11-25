namespace Start.Contracts.EvidenceSubmission

open System
open System.Threading.Tasks
open System.Collections.Generic
open System.Numerics
open Nethereum.Hex.HexTypes
open Nethereum.ABI.FunctionEncoding.Attributes
open Nethereum.Web3
open Nethereum.RPC.Eth.DTOs
open Nethereum.Contracts.CQS
open Nethereum.Contracts.ContractHandlers
open Nethereum.Contracts
open System.Threading
open Start.Contracts.EvidenceSubmission.ContractDefinition


    type EvidenceSubmissionService (web3: Web3, contractAddress: string) =
    
        member val Web3 = web3 with get
        member val ContractHandler = web3.Eth.GetContractHandler(contractAddress) with get
    
        static member DeployContractAndWaitForReceiptAsync(web3: Web3, evidenceSubmissionDeployment: EvidenceSubmissionDeployment, ?cancellationTokenSource : CancellationTokenSource): Task<TransactionReceipt> = 
            let cancellationTokenSourceVal = defaultArg cancellationTokenSource null
            web3.Eth.GetContractDeploymentHandler<EvidenceSubmissionDeployment>().SendRequestAndWaitForReceiptAsync(evidenceSubmissionDeployment, cancellationTokenSourceVal)
        
        static member DeployContractAsync(web3: Web3, evidenceSubmissionDeployment: EvidenceSubmissionDeployment): Task<string> =
            web3.Eth.GetContractDeploymentHandler<EvidenceSubmissionDeployment>().SendRequestAsync(evidenceSubmissionDeployment)
        
        static member DeployContractAndGetServiceAsync(web3: Web3, evidenceSubmissionDeployment: EvidenceSubmissionDeployment, ?cancellationTokenSource : CancellationTokenSource) = async {
            let cancellationTokenSourceVal = defaultArg cancellationTokenSource null
            let! receipt = EvidenceSubmissionService.DeployContractAndWaitForReceiptAsync(web3, evidenceSubmissionDeployment, cancellationTokenSourceVal) |> Async.AwaitTask
            return new EvidenceSubmissionService(web3, receipt.ContractAddress);
            }
    

    

