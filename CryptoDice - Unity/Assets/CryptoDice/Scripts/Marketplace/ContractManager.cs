using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractManager : MonoBehaviour
{
    public static ContractManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }


	public static object[] GetAbiObject()
	{
		object[] newAbi = new object[3];

		// constructor
		object[] cInputParams = new object[0];
		newAbi[0] = new { inputs = cInputParams, name = "", stateMutability = "nonpayable", type = "constructor" };

		// getGreeting
		object[] gInputParams = new object[0];
		object[] gOutputParams = new object[1];
		gOutputParams[0] = new { internalType = "string", name = "", type = "string" };
		newAbi[1] = new { inputs = gInputParams, outputs = gOutputParams, name = "getGreeting", stateMutability = "view", type = "function" };

		// setGreeting
		object[] sInputParams = new object[1];
		sInputParams[0] = new { internalType = "string", name = "greeting", type = "string" };
		object[] sOutputParams = null;
		newAbi[2] = new { inputs = sInputParams, outputs = sOutputParams, name = "setGreeting", stateMutability = "nonpayable", type = "function" };

		return newAbi;
	}


	public static object[] GetAbiObject1()
	{
		object[] newAbi = new object[100];

		// constructor
		object[] cInputParams = new object[0];
		newAbi[0] = new { inputs = cInputParams, name = "", stateMutability = "nonpayable", type = "constructor" };

		// getGreeting
		object[] gInputParams = new object[0];
		object[] gOutputParams = new object[1];
		gOutputParams[0] = new { internalType = "string", name = "", type = "string" };
		newAbi[1] = new { inputs = gInputParams, outputs = gOutputParams, name = "getGreeting", stateMutability = "view", type = "function" };

		// setGreeting
		object[] sInputParams = new object[1];
		sInputParams[0] = new { internalType = "string", name = "greeting", type = "string" };
		object[] sOutputParams = null;
		newAbi[2] = new { inputs = sInputParams, outputs = sOutputParams, name = "setGreeting", stateMutability = "nonpayable", type = "function" };

		// transferOwnership
		object[] inputParams1 = new object[1];
		inputParams1[0] = new { internalType = "address", name = "newOwner", type = "address" };
		object[] outputParams1 = null;
		newAbi[2] = new { inputs = inputParams1, outputs = outputParams1, name = "transferOwnership", stateMutability = "nonpayable", type = "function" };

		// transferFrom
		object[] inputParams2 = new object[3];
		inputParams2[0] = new { internalType = "address", name = "from", type = "address" };
		inputParams2[1] = new { internalType = "address", name = "to", type = "address" };
		inputParams2[2] = new { internalType = "uint256", name = "amount", type = "uint256" };


		object[] outputParams2 = new object[1];
		outputParams2[0] = new { internalType = "bool", name = "", type = "bool" };
		newAbi[2] = new { inputs = inputParams1, outputs = outputParams2, name = "transferFrom", stateMutability = "nonpayable", type = "function" };



		// transfer
		object[] inputParams3 = new object[2];
		inputParams3[0] = new { internalType = "address", name = "to", type = "address" };
		//inputParams3[1] = new { internalType = "address", name = "to", type = "address" };
		inputParams3[1] = new { internalType = "uint256", name = "amount", type = "uint256" };


		object[] outputParams3 = new object[1];
		outputParams3[0] = new { internalType = "bool", name = "", type = "bool" };
		newAbi[2] = new { inputs = inputParams3, outputs = outputParams3, name = "transfer", stateMutability = "nonpayable", type = "function" };

		// totalSupply
		object[] inputParams4 = new object[0];
		


		object[] outputParams4 = new object[1];
		outputParams4[0] = new { internalType = "uint256", name = "", type = "uint256" };
		newAbi[2] = new { inputs = inputParams4, outputs = outputParams4, name = "totalSupply", stateMutability = "view", type = "function" };



		return newAbi;
	}


}

/*[
	{
		"inputs": [],
		"stateMutability": "nonpayable",
		"type": "constructor"
	},
	{
	"anonymous": false,
		"inputs": [
			{
		"indexed": true,
				"internalType": "address",
				"name": "owner",
				"type": "address"
			},
			{
		"indexed": true,
				"internalType": "address",
				"name": "spender",
				"type": "address"
			},
			{
		"indexed": false,
				"internalType": "uint256",
				"name": "value",
				"type": "uint256"
			}
		],
		"name": "Approval",
		"type": "event"
	},
	{
	"anonymous": false,
		"inputs": [
			{
		"indexed": false,
				"internalType": "uint256",
				"name": "amount",
				"type": "uint256"
			}
		],
		"name": "Bought",
		"type": "event"
	},
	{
	"anonymous": false,
		"inputs": [
			{
		"indexed": false,
				"internalType": "address",
				"name": "buyer",
				"type": "address"
			},
			{
		"indexed": false,
				"internalType": "uint256",
				"name": "amountOfETH",
				"type": "uint256"
			},
			{
		"indexed": false,
				"internalType": "uint256",
				"name": "amountOfTokens",
				"type": "uint256"
			}
		],
		"name": "BuyTokens",
		"type": "event"
	},
	{
	"anonymous": false,
		"inputs": [
			{
		"indexed": true,
				"internalType": "address",
				"name": "previousOwner",
				"type": "address"
			},
			{
		"indexed": true,
				"internalType": "address",
				"name": "newOwner",
				"type": "address"
			}
		],
		"name": "OwnershipTransferred",
		"type": "event"
	},
	{
	"anonymous": false,
		"inputs": [
			{
		"indexed": false,
				"internalType": "uint256",
				"name": "amount",
				"type": "uint256"
			}
		],
		"name": "Sold",
		"type": "event"
	},
	{
	"anonymous": false,
		"inputs": [
			{
		"indexed": true,
				"internalType": "address",
				"name": "from",
				"type": "address"
			},
			{
		"indexed": true,
				"internalType": "address",
				"name": "to",
				"type": "address"
			},
			{
		"indexed": false,
				"internalType": "uint256",
				"name": "value",
				"type": "uint256"
			}
		],
		"name": "Transfer",
		"type": "event"
	},
	{
	"inputs": [
			{
		"internalType": "uint256",
				"name": "_price",
				"type": "uint256"
			}
		],
		"name": "SetChipsPrice",
		"outputs": [],
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
	"inputs": [
			{
		"internalType": "address",
				"name": "owner",
				"type": "address"
			},
			{
		"internalType": "address",
				"name": "spender",
				"type": "address"
			}
		],
		"name": "allowance",
		"outputs": [
			{
		"internalType": "uint256",
				"name": "",
				"type": "uint256"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
	"inputs": [
			{
		"internalType": "address",
				"name": "spender",
				"type": "address"
			},
			{
		"internalType": "uint256",
				"name": "amount",
				"type": "uint256"
			}
		],
		"name": "approve",
		"outputs": [
			{
		"internalType": "bool",
				"name": "",
				"type": "bool"
			}
		],
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
	"inputs": [
			{
		"internalType": "address",
				"name": "account",
				"type": "address"
			}
		],
		"name": "balanceOf",
		"outputs": [
			{
		"internalType": "uint256",
				"name": "",
				"type": "uint256"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
	"inputs": [
			{
		"internalType": "uint256",
				"name": "amt",
				"type": "uint256"
			}
		],
		"name": "bid",
		"outputs": [
			{
		"internalType": "bool",
				"name": "",
				"type": "bool"
			}
		],
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
	"inputs": [],
		"name": "buyTokens",
		"outputs": [
			{
		"internalType": "uint256",
				"name": "tokenAmount",
				"type": "uint256"
			}
		],
		"stateMutability": "payable",
		"type": "function"
	},
	{
	"inputs": [],
		"name": "chipsValue",
		"outputs": [
			{
		"internalType": "uint256",
				"name": "",
				"type": "uint256"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
	"inputs": [],
		"name": "decimals",
		"outputs": [
			{
		"internalType": "uint8",
				"name": "",
				"type": "uint8"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
	"inputs": [
			{
		"internalType": "address",
				"name": "spender",
				"type": "address"
			},
			{
		"internalType": "uint256",
				"name": "subtractedValue",
				"type": "uint256"
			}
		],
		"name": "decreaseAllowance",
		"outputs": [
			{
		"internalType": "bool",
				"name": "",
				"type": "bool"
			}
		],
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
	"inputs": [],
		"name": "getChipsPrice",
		"outputs": [
			{
		"internalType": "uint256",
				"name": "",
				"type": "uint256"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
	"inputs": [
			{
		"internalType": "uint256",
				"name": "amt",
				"type": "uint256"
			}
		],
		"name": "getPrize",
		"outputs": [
			{
		"internalType": "bool",
				"name": "",
				"type": "bool"
			}
		],
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
	"inputs": [
			{
		"internalType": "address",
				"name": "spender",
				"type": "address"
			},
			{
		"internalType": "uint256",
				"name": "addedValue",
				"type": "uint256"
			}
		],
		"name": "increaseAllowance",
		"outputs": [
			{
		"internalType": "bool",
				"name": "",
				"type": "bool"
			}
		],
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
	"inputs": [],
		"name": "name",
		"outputs": [
			{
		"internalType": "string",
				"name": "",
				"type": "string"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
	"inputs": [],
		"name": "owner",
		"outputs": [
			{
		"internalType": "address",
				"name": "",
				"type": "address"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
	"inputs": [],
		"name": "ownerAdd",
		"outputs": [
			{
		"internalType": "address",
				"name": "",
				"type": "address"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	{
	"inputs": [],
		"name": "renounceOwnership",
		"outputs": [],
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
	"inputs": [
			{
		"internalType": "uint256",
				"name": "tokenAmountToSell",
				"type": "uint256"
			}
		],
		"name": "sellTokens",
		"outputs": [],
		"stateMutability": "nonpayable",
		"type": "function"
	},
	{
	"inputs": [],
		"name": "symbol",
		"outputs": [
			{
		"internalType": "string",
				"name": "",
				"type": "string"
			}
		],
		"stateMutability": "view",
		"type": "function"
	},
	
	
	
	
]*/
