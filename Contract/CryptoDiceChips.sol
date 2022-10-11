// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;
import "hardhat/console.sol";
import "https://github.com/OpenZeppelin/openzeppelin-contracts/blob/master/contracts/token/ERC20/ERC20.sol";
import "https://github.com/OpenZeppelin/openzeppelin-contracts/blob/master/contracts/access/Ownable.sol";

contract CryptoDiceChips is ERC20,Ownable {

    address public ownerAdd;
    uint256 public chipsValue=2000000000000000;


   constructor() ERC20('CHPS','CryptoDiceChips'){
       ownerAdd=msg.sender;
        _mint(msg.sender,100*10**10);
    }


    event Bought(uint256 amount);
    event Sold(uint256 amount);




//uint256 public chipsValue = 500; // One Chips cost 500 Wei
//address constant public deployerAddress = owner;
event BuyTokens(address buyer, uint256 amountOfETH, uint256 amountOfTokens);
    
    function buyTokens() public payable returns (uint256 tokenAmount) {
    require(msg.value > 0, "Send ETH to buy some tokens");

    uint256 amountToBuy = msg.value / chipsValue;

    // check if the Vendor Contract has enough amount of tokens for the transaction
    uint256 vendorBalance = balanceOf(ownerAdd);
    require(vendorBalance >= amountToBuy, "Vendor contract has not enough tokens in its balance");

    // Transfer token to the msg.sender
    _transfer(ownerAdd, msg.sender, amountToBuy);
    //require(sent, "Failed to transfer token to user");

    // emit the event
    emit BuyTokens(msg.sender, msg.value, amountToBuy);

    return amountToBuy;
  }

function sellTokens(uint256 tokenAmountToSell) public {
    // Check that the requested amount of tokens to sell is more than 0
    require(tokenAmountToSell > 0, "Specify an amount of token greater than zero");

    // Check that the user's token balance is enough to do the swap
    uint256 userBalance = balanceOf(msg.sender);
    require(userBalance >= tokenAmountToSell, "Your balance is lower than the amount of tokens you want to sell");

    // Check that the Vendor's balance is enough to do the swap
    uint256 amountOfETHToTransfer = tokenAmountToSell * chipsValue;
    uint256 ownerETHBalance = ownerAdd.balance;
    require(ownerETHBalance >= amountOfETHToTransfer, "Vendor has not enough funds to accept the sell request");

     _transfer(msg.sender, ownerAdd, tokenAmountToSell);
    //require(sent, "Failed to transfer tokens from user to vendor");


    bool etherSent;
    (etherSent, )=msg.sender.call{value: amountOfETHToTransfer}("");
    require(etherSent, "Failed to send ETH to the user");
    require(address(this).balance>amountOfETHToTransfer,"Contract Balance Low to Pay");
    payable(msg.sender).transfer(amountOfETHToTransfer);
  }


  function SetChipsPrice(uint256 _price) public onlyOwner{
      chipsValue=_price;

  }

  function getChipsPrice() public view returns (uint256){
      uint256 _chipValue = chipsValue;
      return _chipValue;

  }




  function bid(uint256 amt) public returns (bool){
      bool sent = false;
      _transfer(msg.sender,ownerAdd,amt);
      sent =true;
      return sent;
  }

  function getPrize(uint amt) public returns (bool){
      bool received=false;
      _transfer(ownerAdd,msg.sender,amt);
      received=true;
      return received;
  }

  function AddBalanceToContract() public payable{
    require(msg.value > 0, "Send TCRO to store in contract");
  }

}

