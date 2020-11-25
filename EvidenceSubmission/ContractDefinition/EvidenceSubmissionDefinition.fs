namespace Start.Contracts.EvidenceSubmission.ContractDefinition

open System
open System.Threading.Tasks
open System.Collections.Generic
open System.Numerics
open Nethereum.Hex.HexTypes
open Nethereum.ABI.FunctionEncoding.Attributes
open Nethereum.Web3
open Nethereum.RPC.Eth.DTOs
open Nethereum.Contracts.CQS
open Nethereum.Contracts
open System.Threading

    
    
    type EvidenceSubmissionDeployment(byteCode: string) =
        inherit ContractDeploymentMessage(byteCode)
        
        static let BYTECODE = "6080604052348015600f57600080fd5b50603f80601d6000396000f3fe6080604052600080fdfea2646970667358221220cf51a0ef5f54f3a666a9df877041ff69d8076b81b53b6cfb9d63fe5ec85c6cbd64736f6c63430007050033"
        
        new() = EvidenceSubmissionDeployment(BYTECODE)
        

    

