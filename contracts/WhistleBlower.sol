// SPDX-License-Identifier: MIT
pragma solidity >=0.4.22 <0.8.0;

contract WhistleBlower {
  //TokenCreator is a contract type that is defined below.
  //It is fine to reference it as long as it is not used
  //to create a new contract.
  WhistleBlower creator;
  address owner;
  whistle name;
  // This is the constructor which registers the 
  // creator and the assigned name.


  constructor(whistle_name) public {
  }
}
