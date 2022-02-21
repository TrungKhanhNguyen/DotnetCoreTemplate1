// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var accounts;
    var web3
    $('.connect_wallet').click(function () {
        if ($(this).hasClass('btn-primary')) {
            connectWallet();
        }
        else {
            $(this).val("Metamask is not installed");
            $(this).addClass('.btn-danger');
            return false;
        }
    });

    async function connectWallet(){
        accounts = await window.ethereum.request({ method: 'eth_requestAccounts'})
            .catch((e) => {
                console.error(e.message)
                return
            });
        if (!accounts) { return }
        web3 = new Web3(Web3.givenProvider);
        web3.eth.net.getId()
            .then((networkId) => {
                if (networkId != '97') {
                    try {
                        ethereum.request({
                            method: 'wallet_switchEthereumChain',
                            params: [{ chainId: `0x${Number(97).toString(16)}` }]
                        });
                    } catch (addError) {
                        // handle "add" error
                    }
                }
                
            })
            .catch((err) => {
                // unable to retrieve network id
            });
      
        $('.connect_wallet').removeClass('btn-primary');
        $('.connect_wallet').addClass('btn-outline-primary');
        $('.connect_wallet').text(setTextTrim(accounts[0]));
        $('.btnDeposit').removeClass('disabled');
        $('.btnWithdraw').removeClass('disabled');
    }

    $('.btnDeposit').click(function () {
        var amount = $('#amoutDeposit').val();
        
        var arrayABI = [{ "inputs": [{ "internalType": "address", "name": "tokenAddress", "type": "address" }], "stateMutability": "nonpayable", "type": "constructor" }, { "anonymous": false, "inputs": [{ "indexed": false, "internalType": "address", "name": "buyer", "type": "address" }, { "indexed": false, "internalType": "uint256", "name": "amountOfBNB", "type": "uint256" }, { "indexed": false, "internalType": "uint256", "name": "amountOfTokens", "type": "uint256" }], "name": "BuyTokens", "type": "event" }, { "anonymous": false, "inputs": [{ "indexed": true, "internalType": "address", "name": "previousOwner", "type": "address" }, { "indexed": true, "internalType": "address", "name": "newOwner", "type": "address" }], "name": "OwnershipTransferred", "type": "event" }, { "inputs": [], "name": "buyTokens", "outputs": [{ "internalType": "uint256", "name": "tokenAmount", "type": "uint256" }], "stateMutability": "payable", "type": "function" }, { "inputs": [], "name": "owner", "outputs": [{ "internalType": "address", "name": "", "type": "address" }], "stateMutability": "view", "type": "function" }, { "inputs": [], "name": "renounceOwnership", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "inputs": [{ "internalType": "uint256", "name": "tokenAmountToSell", "type": "uint256" }], "name": "sellTokens", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "inputs": [], "name": "tokensPerBnb", "outputs": [{ "internalType": "uint256", "name": "", "type": "uint256" }], "stateMutability": "view", "type": "function" }, { "inputs": [{ "internalType": "address", "name": "newOwner", "type": "address" }], "name": "transferOwnership", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "inputs": [], "name": "withdraw", "outputs": [], "stateMutability": "nonpayable", "type": "function" }];
        var contractAdd = "0x78dd5028853Cb95de62D9B180e089c7A5cfe8d91";
        
        if (typeof web3 !== 'underfined') {
            var myContract = new web3.eth.Contract(arrayABI, contractAdd);
            var amountEther = web3.utils.toWei(amount, 'ether');
            console.log(accounts[0]);
            myContract.methods.buyTokens().send({ from: accounts[0], value: amountEther });
         
        }
    });

    function setTextTrim(str) {
        if (str.length > 9) {
            return str.substr(0, 4) + '...' + str.substr(str.length - 4, str.length);
        }
        return str;
    }
    async function getAccount() {
        var accounts = await window.ethereum.request({ method: 'eth_requestAccounts' })
            .catch((e) => {
                console.error(e.message)
                return
            });
        if (!accounts) { return }

        return accounts;
    }
 
});