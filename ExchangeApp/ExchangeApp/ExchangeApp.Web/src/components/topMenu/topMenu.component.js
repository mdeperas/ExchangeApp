require('./topMenu.component.scss');

class TopMenuController {
    constructor(PrincipalService) {
        this.principalService = PrincipalService;
    }
}

export let TopMenuComponent = {
    bindings: {
        onLogout: '&'
    },
    controller: TopMenuController,
    template: require('./topMenu.component.html')
}