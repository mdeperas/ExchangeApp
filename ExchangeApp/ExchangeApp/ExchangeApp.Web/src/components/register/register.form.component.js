class RegisterFormController {
    constructor() {
    }

    update() {
        this.onUpdate({ user: this.user });
    }
}

export let RegisterFormComponent = {
    bindings: {
        formName: "<",
        onUpdate: "&",
        currencies: "<"
    },
    controller: RegisterFormController,
    template: require('./register.form.component.html')
}