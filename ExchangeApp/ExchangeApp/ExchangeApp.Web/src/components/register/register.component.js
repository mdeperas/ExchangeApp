class RegisterController {
    constructor(AuthService, $state) {
        this.authService = AuthService;
        this.user = {};
        this.errorMessage = "";
        this.state = $state;
    }

    register(event) {
        //temporary
        this.user.name = "TestName";
        this.user.surname = "TestSurname";
        this.authService.register(this.user).then((response) => {
            this.state.go('free.login');
        },
            (error) => {
                console.log(error);
                error = error.data || error;
                this.errorMessage = error.modelState[""][0];
            });
    }

    update(newUserData) {
        this.user = newUserData;
    }
}

export let RegisterComponent = {
    controller: RegisterController,
    template: require('./register.component.html')
}