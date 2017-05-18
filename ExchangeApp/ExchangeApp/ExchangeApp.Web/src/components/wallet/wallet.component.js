class WalletController {
    constructor() {
    }
}

export let WalletComponent = {
    bindings: {
        currencies: '<'
    },
    controller: WalletController,
    template: require('./wallet.component.html')
}