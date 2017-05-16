class LoginFormController {
    constructor() {
    }

    update()
    {
        this.onUpdate({user: this.user});
    }
}

export let LoginFormComponent = {
    bindings: {
        formName: '<',
        onUpdate: '&'
    },
    controller: LoginFormController,
    template: require('./login.form.component.html')
}